﻿﻿﻿using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace EquipmentManageSystem.模板
{
    public static class InfoShowUtil
    {
        //普通提示（蓝)
        public static void Info(Control container, string message, int duration = 3000)
        {
            Show(container, message,
                Color.FromArgb(220, 240, 255),
                Color.FromArgb(0, 80, 180),
                duration);
        }

        //成功提示（绿）
        public static void Success(Control container, string message, int duration = 3000)
        {
            Show(container, message,
                Color.FromArgb(220, 245, 220),
                Color.FromArgb(0, 100, 0),
                duration);
        }

        //警告提示（黄）
        public static void Warning(Control container, string message, int duration = 3000)
        {
            Show(container, message,
                Color.FromArgb(255, 250, 210),
                Color.FromArgb(150, 120, 0),
                duration);
        }

        //错误提示（红）
        public static void Error(Control container, string message, int duration = 3000)
        {
            Show(container, message,
                Color.FromArgb(255, 225, 225),
                Color.FromArgb(180, 0, 0),
                duration);
        }

        private static void Show(Control container, string message, Color bgColor, Color textColor, int duration)
        {
            if (container == null || container.IsDisposed) return;

            //--- 创建浮动 Panel ---
            Panel toast = new Panel();
            toast.BackColor = bgColor;

            //--- 提示文字 ---
            Label label = new Label();
            label.Text = message;
            label.AutoSize = true;
            label.MaximumSize = new Size(550, 80);
            label.TextAlign = ContentAlignment.MiddleLeft;
            label.Font = new Font("微软雅黑", 12F, FontStyle.Bold);
            label.ForeColor = textColor;
            label.Padding = new Padding(30, 15, 30, 15);
            label.Location = new Point(0, 0);

            toast.Controls.Add(label);
            label.PerformLayout();
            toast.Size = new Size(label.Width, label.Height);

            // 设置圆角 Region
            int radius = 10;
            using (GraphicsPath path = GetRoundedPath(new Rectangle(0, 0, toast.Width, toast.Height), radius))
                toast.Region = new Region(path);

            // Paint 圆角背景
            toast.Paint += (s, e) =>
            {
                Panel p = s as Panel;
                if (p == null) return;
                using (GraphicsPath path = GetRoundedPath(p.ClientRectangle, radius))
                using (SolidBrush brush = new SolidBrush(p.BackColor))
                {
                    e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
                    e.Graphics.FillPath(brush, path);
                }
            };

            //--- 定位：顶部居中 ---
            container.Controls.Add(toast);
            toast.BringToFront();
            CenterToast(container, toast);

            //窗口大小变化时重新居中
            EventHandler onResize = null;
            onResize = (s, e) =>
            {
                if (toast.IsDisposed) { container.Resize -= onResize; return; }
                CenterToast(container, toast);
            };
            container.Resize += onResize;
            toast.Disposed += (s, e) => container.Resize -= onResize;

            //--- 自动消失 ---
            Timer timer = new Timer();
            timer.Interval = duration;
            timer.Tick += (s, e) =>
            {
                timer.Stop();
                timer.Dispose();
                CloseToast(toast);
            };
            timer.Start();
        }

        private static void CloseToast(Panel toast)
        {
            if (toast != null && !toast.IsDisposed)
                toast.Dispose();
        }

        private static void CenterToast(Control container, Panel toast)
        {
            if (container == null || toast == null || toast.IsDisposed) return;
            toast.Location = new Point(
                (container.ClientSize.Width - toast.Width) / 2,
                15
            );
        }

        private static GraphicsPath GetRoundedPath(Rectangle rect, int radius)
        {
            GraphicsPath path = new GraphicsPath();
            int r2 = radius * 2;
            path.AddArc(rect.X, rect.Y, r2, r2, 180, 90);
            path.AddArc(rect.Right - r2, rect.Y, r2, r2, 270, 90);
            path.AddArc(rect.Right - r2, rect.Bottom - r2, r2, r2, 0, 90);
            path.AddArc(rect.X, rect.Bottom - r2, r2, r2, 90, 90);
            path.CloseFigure();
            return path;
        }
    }
}