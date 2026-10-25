﻿﻿﻿﻿﻿﻿﻿﻿﻿﻿﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace EquipmentManageSystem.Utils
{
    /// <summary>
    /// 图片处理工具类
    /// </summary>
    public static class PictureHandleUtil
    {
        /// <summary>
        /// 保存图片并获取保存路径
        /// </summary>
        /// <param name="picturePaths">图片路径集合</param>
        /// <param name="subDir">子目录名称</param>
        /// <returns>图片保存路径</returns>
        public static string SavePicturesAndGetSavePath(IEnumerable<string> picturePaths, string subDir,string dateSub = "")
        {
            if (picturePaths == null || !picturePaths.Any())
            {
                return "";
            }

            List<string> pathList = picturePaths.ToList();
            if (pathList.Any(p => string.IsNullOrEmpty(p) || !File.Exists(p)))
            {
                return null;
            }

            string root = AppDomain.CurrentDomain.BaseDirectory;

            if (string.IsNullOrEmpty(dateSub))
            {
                dateSub = DateTime.Now.ToString("yyyyMMdd");
            }
            string saveDir = Path.Combine(root, "Pictures", subDir, dateSub);
            Directory.CreateDirectory(saveDir);

            List<string> savedPaths = new List<string>();
            List<string> createdFiles = new List<string>(); // 记录本次已创建的文件，用于失败时回滚

            foreach (string sourcePath in pathList)
            {
                try
                {
                    string fileName = Guid.NewGuid().ToString("N") + Path.GetExtension(sourcePath);
                    string fullPath = Path.Combine(saveDir, fileName);

                    File.Copy(sourcePath, fullPath, false);
                    createdFiles.Add(fullPath);
                    savedPaths.Add(Path.Combine("Pictures", subDir, dateSub, fileName));
                }
                catch (Exception ex)
                {
                    // 复制失败：清理本次已保存的文件
                    foreach (string f in createdFiles)
                    {
                        try { File.Delete(f); } catch { }
                    }
                    System.Diagnostics.Debug.WriteLine(ex.Message);
                    return null;
                }
            }

            return string.Join(",", savedPaths);
        }

        /// <summary>
        /// 删除图片（相对路径）
        /// </summary>
        /// <param name="picturePaths">需要删除的图片相对路径集合</param>
        public static void DeletePictures(IEnumerable<string> picturePaths)
        {
            if (picturePaths == null) return;

            string root = AppDomain.CurrentDomain.BaseDirectory;

            foreach (string path in picturePaths)
            {
                if (string.IsNullOrEmpty(path)) continue;

                try
            {
                string fullPath = Path.IsPathRooted(path)
                    ? path
                    : Path.Combine(root, path);

                if (File.Exists(fullPath))
                    File.Delete(fullPath);
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message);
            }
            }
        }

        /// <summary>
        /// 选择图片并加载到面板
        /// </summary>
        /// <param name="panel">目标画板</param>
        public static void SelectPicturesToPanel(FlowLayoutPanel panel)
        {
            using (var ofd = new OpenFileDialog())
            {
                ofd.Filter = "图片文件|*.jpg;*.jpeg;*.png;*.bmp;*.gif;*.jfif";
                ofd.Multiselect = true;
                ofd.Title = "选择上传图片";

                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    panel.Controls.Clear();
                    foreach (var path in ofd.FileNames)
                    {
                        var pic = new PictureBox()
                        {
                            Image = Image.FromFile(path),
                            SizeMode = PictureBoxSizeMode.Zoom,
                            Size = new Size(100, 60),
                            Tag = path,
                            Margin = new Padding(5),
                            BorderStyle = BorderStyle.FixedSingle
                        };
                        pic.Click += (s, e2) => {
                            var frm = new Form
                            {
                                Text = "查看图片",
                                StartPosition = FormStartPosition.CenterScreen,
                                WindowState = FormWindowState.Normal,
                                Size = new Size(900, 700)
                            };
                            var big = new PictureBox
                            {
                                Dock = DockStyle.Fill,
                                SizeMode = PictureBoxSizeMode.Zoom,
                                Image = pic.Image
                            };
                            frm.Controls.Add(big);
                            frm.ShowDialog();
                        };
                        panel.Controls.Add(pic);
                    }
                }
            }
        }

        /// <summary>
        /// 加载图片到面板
        /// </summary>
        /// <param name="panel">目标面板</param>
        /// <param name="picturePaths">图片路径（相对路径，多个以逗号分隔）</param>
        public static void LoadPicturesToPanel(FlowLayoutPanel panel, string picturePaths)
        {
            if (string.IsNullOrEmpty(picturePaths)) return;

            panel.Controls.Clear();
            string root = AppDomain.CurrentDomain.BaseDirectory;

            foreach (string relPath in picturePaths.Split(','))
            {
                string path = relPath.Trim();
                if (string.IsNullOrEmpty(path)) continue;

                string fullPath = Path.IsPathRooted(path) ? path : Path.Combine(root, path);
                if (!File.Exists(fullPath)) continue;

                try
                {
                    var pic = new PictureBox()
                    {
                        Image = LoadImageWithoutLock(fullPath),
                        SizeMode = PictureBoxSizeMode.Zoom,
                        Size = new Size(100, 60),
                        Tag = fullPath,
                        Margin = new Padding(5),
                        BorderStyle = BorderStyle.FixedSingle
                    };
                    pic.Click += (s, e) => ShowBigImage(fullPath);
                    panel.Controls.Add(pic);
                }
                catch (Exception ex)
                {
                    System.Diagnostics.Debug.WriteLine(ex.Message);
                }
            }
        }

        /// <summary>
        /// 加载图片到图片框控件
        /// </summary>
        /// <param name="pictureBox">pictureBox控件对象</param>
        /// <param name="picturePath">图片相对路径</param>
        public static void LoadPictureToPictureBox(PictureBox pictureBox, string picturePath)
        {
            if (string.IsNullOrEmpty(picturePath)) return;

            // 统一分隔符：\ 、\、//、/ 都归一化为当前系统的目录分隔符
            string clean = picturePath.Trim().Replace('\\', Path.DirectorySeparatorChar).Replace('/', Path.DirectorySeparatorChar);
            clean = clean.Replace(string.Concat(Path.DirectorySeparatorChar, Path.DirectorySeparatorChar), Path.DirectorySeparatorChar.ToString());

            string fullPath;
            if (Path.IsPathRooted(clean))
            {
                // 已是绝对路径，直接使用
                fullPath = clean;
            }
            else
            {
                // 相对路径：与程序启动目录正确拼接
                fullPath = Path.Combine(Application.StartupPath, clean.TrimStart(Path.DirectorySeparatorChar));
            }

            if (File.Exists(fullPath))
            {
                if (pictureBox.Image != null)
                {
                    pictureBox.Image.Dispose();
                }
                pictureBox.Image = Image.FromFile(fullPath);
                pictureBox.SizeMode = PictureBoxSizeMode.Zoom;
            }
        }

        /// <summary>
        /// 通过内存流读取图片，避免锁定源文件
        /// </summary>
        private static Image LoadImageWithoutLock(string fullPath)
        {
            using (FileStream fs = new FileStream(fullPath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
            using (MemoryStream ms = new MemoryStream())
            {
                fs.CopyTo(ms);
                ms.Position = 0;
                return Image.FromStream(ms);
            }
        }

        /// <summary>
        /// 点击查看大图
        /// </summary>
        private static void ShowBigImage(string imagePath)
        {
            if (string.IsNullOrEmpty(imagePath) || !File.Exists(imagePath)) return;

            var frm = new Form
            {
                Text = "查看图片",
                StartPosition = FormStartPosition.CenterScreen,
                WindowState = FormWindowState.Normal,
                Size = new Size(900, 700)
            };
            var big = new PictureBox
            {
                Dock = DockStyle.Fill,
                SizeMode = PictureBoxSizeMode.Zoom,
                Image = Image.FromFile(imagePath)
            };
            frm.Controls.Add(big);
            frm.ShowDialog();
        }

        /// <summary>
        /// 判断两组照片路径是否完全相同
        /// </summary>
        /// <param name="currentPicturePaths">当前面板中的图片路径</param>
        /// <param name="oldPicturePaths">  旧图片路径集合</param>
        /// <returns>相同返回 true，否则 false</returns>
        public static bool IsSamePictures(IEnumerable<string> currentPicturePaths, IEnumerable<string> oldPicturePaths)
        {


            // 当前图片：统一转绝对路径 -> 排序
            List<string> currentPaths = (currentPicturePaths ?? Enumerable.Empty<string>())
                .Where(p => !string.IsNullOrWhiteSpace(p))
                .Select(p => ToAbsolutePicturePath(p))
                .Where(s => !string.IsNullOrEmpty(s))
                .OrderBy(s => s, StringComparer.OrdinalIgnoreCase)
                .ToList();

            // 旧图片：统一转绝对路径 -> 排序
            List<string> oldPaths = (oldPicturePaths ?? Enumerable.Empty<string>())
                .Where(s => !string.IsNullOrWhiteSpace(s))
                .Select(s => ToAbsolutePicturePath(s.Trim()))
                .Where(s => !string.IsNullOrEmpty(s))
                .OrderBy(s => s, StringComparer.OrdinalIgnoreCase)
                .ToList();

            // 排序后逐个比较
            return currentPaths.SequenceEqual(oldPaths, StringComparer.OrdinalIgnoreCase);
        }

        /// <summary>
        /// 将相对路径转为绝对路径
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        private static string ToAbsolutePicturePath(string path)
        {
            if (string.IsNullOrEmpty(path)) return string.Empty;
            string s = path.Replace('/', '\\').Trim();
            if (Path.IsPathRooted(s))           // 已是绝对路径
            {
                return s;
            }
            return Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, s));
        }
    }
}