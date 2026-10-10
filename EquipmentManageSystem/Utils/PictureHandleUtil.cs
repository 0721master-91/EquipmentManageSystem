﻿﻿﻿﻿﻿using System;
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
                        Image = Image.FromFile(fullPath),
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
    }
}