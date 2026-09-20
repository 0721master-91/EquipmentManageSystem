
namespace EquipmentManageSystem.模板.导入导出模板
{
    partial class UserControl数据导入
    {
        /// <summary> 
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.panel文件选择 = new System.Windows.Forms.Panel();
            this.button选择文件 = new System.Windows.Forms.Button();
            this.label选择文件全称 = new System.Windows.Forms.Label();
            this.label选择文件 = new System.Windows.Forms.Label();
            this.panel数据验证 = new System.Windows.Forms.Panel();
            this.button确认导入 = new System.Windows.Forms.Button();
            this.panel数据预览 = new System.Windows.Forms.Panel();
            this.dataGridView预览数据 = new System.Windows.Forms.DataGridView();
            this.label数据概况详细 = new System.Windows.Forms.Label();
            this.label数据概况 = new System.Windows.Forms.Label();
            this.label数据验证 = new System.Windows.Forms.Label();
            this.panel导入结果 = new System.Windows.Forms.Panel();
            this.label具体进度 = new System.Windows.Forms.Label();
            this.label导入进度 = new System.Windows.Forms.Label();
            this.progressBar导入进度条 = new System.Windows.Forms.ProgressBar();
            this.label数据导入 = new System.Windows.Forms.Label();
            this.button模板下载 = new System.Windows.Forms.Button();
            this.panel模块获取 = new System.Windows.Forms.Panel();
            this.panel文件选择.SuspendLayout();
            this.panel数据验证.SuspendLayout();
            this.panel数据预览.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView预览数据)).BeginInit();
            this.panel导入结果.SuspendLayout();
            this.panel模块获取.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel文件选择
            // 
            this.panel文件选择.Controls.Add(this.button选择文件);
            this.panel文件选择.Controls.Add(this.label选择文件全称);
            this.panel文件选择.Controls.Add(this.label选择文件);
            this.panel文件选择.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel文件选择.Location = new System.Drawing.Point(0, 71);
            this.panel文件选择.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.panel文件选择.Name = "panel文件选择";
            this.panel文件选择.Size = new System.Drawing.Size(1153, 115);
            this.panel文件选择.TabIndex = 1;
            // 
            // button选择文件
            // 
            this.button选择文件.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.button选择文件.Location = new System.Drawing.Point(20, 47);
            this.button选择文件.Name = "button选择文件";
            this.button选择文件.Size = new System.Drawing.Size(99, 29);
            this.button选择文件.TabIndex = 2;
            this.button选择文件.Text = "选择文件";
            this.button选择文件.UseVisualStyleBackColor = false;
            this.button选择文件.Click += new System.EventHandler(this.button选择文件_Click);
            // 
            // label选择文件全称
            // 
            this.label选择文件全称.AutoSize = true;
            this.label选择文件全称.Location = new System.Drawing.Point(23, 86);
            this.label选择文件全称.Name = "label选择文件全称";
            this.label选择文件全称.Size = new System.Drawing.Size(85, 19);
            this.label选择文件全称.TabIndex = 1;
            this.label选择文件全称.Text = "暂无文件";
            // 
            // label选择文件
            // 
            this.label选择文件.AutoSize = true;
            this.label选择文件.Font = new System.Drawing.Font("宋体", 18F);
            this.label选择文件.Location = new System.Drawing.Point(4, 8);
            this.label选择文件.Name = "label选择文件";
            this.label选择文件.Size = new System.Drawing.Size(148, 30);
            this.label选择文件.TabIndex = 0;
            this.label选择文件.Text = "选择Excel";
            // 
            // panel数据验证
            // 
            this.panel数据验证.Controls.Add(this.button确认导入);
            this.panel数据验证.Controls.Add(this.panel数据预览);
            this.panel数据验证.Controls.Add(this.label数据概况详细);
            this.panel数据验证.Controls.Add(this.label数据概况);
            this.panel数据验证.Controls.Add(this.label数据验证);
            this.panel数据验证.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel数据验证.Location = new System.Drawing.Point(0, 186);
            this.panel数据验证.Name = "panel数据验证";
            this.panel数据验证.Size = new System.Drawing.Size(1153, 333);
            this.panel数据验证.TabIndex = 2;
            // 
            // button确认导入
            // 
            this.button确认导入.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.button确认导入.Enabled = false;
            this.button确认导入.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.button确认导入.Location = new System.Drawing.Point(540, 300);
            this.button确认导入.Name = "button确认导入";
            this.button确认导入.Size = new System.Drawing.Size(103, 32);
            this.button确认导入.TabIndex = 5;
            this.button确认导入.Text = "确认导入";
            this.button确认导入.UseVisualStyleBackColor = false;
            this.button确认导入.Visible = false;
            this.button确认导入.Click += new System.EventHandler(this.button确认导入_Click);
            // 
            // panel数据预览
            // 
            this.panel数据预览.AutoScroll = true;
            this.panel数据预览.Controls.Add(this.dataGridView预览数据);
            this.panel数据预览.Location = new System.Drawing.Point(0, 77);
            this.panel数据预览.Name = "panel数据预览";
            this.panel数据预览.Size = new System.Drawing.Size(1153, 207);
            this.panel数据预览.TabIndex = 4;
            // 
            // dataGridView预览数据
            // 
            this.dataGridView预览数据.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView预览数据.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dataGridView预览数据.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView预览数据.Location = new System.Drawing.Point(0, 0);
            this.dataGridView预览数据.Name = "dataGridView预览数据";
            this.dataGridView预览数据.RowHeadersWidth = 51;
            this.dataGridView预览数据.RowTemplate.Height = 27;
            this.dataGridView预览数据.Size = new System.Drawing.Size(1125, 207);
            this.dataGridView预览数据.TabIndex = 0;
            // 
            // label数据概况详细
            // 
            this.label数据概况详细.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.label数据概况详细.AutoSize = true;
            this.label数据概况详细.Location = new System.Drawing.Point(119, 52);
            this.label数据概况详细.Name = "label数据概况详细";
            this.label数据概况详细.Size = new System.Drawing.Size(85, 19);
            this.label数据概况详细.TabIndex = 3;
            this.label数据概况详细.Text = "暂无数据";
            // 
            // label数据概况
            // 
            this.label数据概况.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.label数据概况.AutoSize = true;
            this.label数据概况.Location = new System.Drawing.Point(27, 52);
            this.label数据概况.Name = "label数据概况";
            this.label数据概况.Size = new System.Drawing.Size(104, 19);
            this.label数据概况.TabIndex = 2;
            this.label数据概况.Text = "数据概况：";
            // 
            // label数据验证
            // 
            this.label数据验证.AutoSize = true;
            this.label数据验证.Font = new System.Drawing.Font("宋体", 18F);
            this.label数据验证.Location = new System.Drawing.Point(4, 6);
            this.label数据验证.Name = "label数据验证";
            this.label数据验证.Size = new System.Drawing.Size(133, 30);
            this.label数据验证.TabIndex = 1;
            this.label数据验证.Text = "数据验证";
            // 
            // panel导入结果
            // 
            this.panel导入结果.Controls.Add(this.label具体进度);
            this.panel导入结果.Controls.Add(this.label导入进度);
            this.panel导入结果.Controls.Add(this.progressBar导入进度条);
            this.panel导入结果.Controls.Add(this.label数据导入);
            this.panel导入结果.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel导入结果.Location = new System.Drawing.Point(0, 519);
            this.panel导入结果.Name = "panel导入结果";
            this.panel导入结果.Size = new System.Drawing.Size(1153, 183);
            this.panel导入结果.TabIndex = 3;
            // 
            // label具体进度
            // 
            this.label具体进度.AutoSize = true;
            this.label具体进度.Location = new System.Drawing.Point(690, 70);
            this.label具体进度.Name = "label具体进度";
            this.label具体进度.Size = new System.Drawing.Size(29, 19);
            this.label具体进度.TabIndex = 5;
            this.label具体进度.Text = "  ";
            // 
            // label导入进度
            // 
            this.label导入进度.AutoSize = true;
            this.label导入进度.Location = new System.Drawing.Point(398, 72);
            this.label导入进度.Name = "label导入进度";
            this.label导入进度.Size = new System.Drawing.Size(104, 19);
            this.label导入进度.TabIndex = 4;
            this.label导入进度.Text = "导入进度：";
            // 
            // progressBar导入进度条
            // 
            this.progressBar导入进度条.Location = new System.Drawing.Point(497, 70);
            this.progressBar导入进度条.Name = "progressBar导入进度条";
            this.progressBar导入进度条.Size = new System.Drawing.Size(186, 23);
            this.progressBar导入进度条.TabIndex = 3;
            // 
            // label数据导入
            // 
            this.label数据导入.AutoSize = true;
            this.label数据导入.Font = new System.Drawing.Font("宋体", 18F);
            this.label数据导入.Location = new System.Drawing.Point(4, 12);
            this.label数据导入.Name = "label数据导入";
            this.label数据导入.Size = new System.Drawing.Size(133, 30);
            this.label数据导入.TabIndex = 2;
            this.label数据导入.Text = "数据导入";
            // 
            // button模板下载
            // 
            this.button模板下载.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.button模板下载.Location = new System.Drawing.Point(3, 12);
            this.button模板下载.Name = "button模板下载";
            this.button模板下载.Size = new System.Drawing.Size(144, 43);
            this.button模板下载.TabIndex = 0;
            this.button模板下载.Text = "模版下载";
            this.button模板下载.UseVisualStyleBackColor = true;
            this.button模板下载.Click += new System.EventHandler(this.button模板下载_Click);
            // 
            // panel模块获取
            // 
            this.panel模块获取.Controls.Add(this.button模板下载);
            this.panel模块获取.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel模块获取.Location = new System.Drawing.Point(0, 0);
            this.panel模块获取.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.panel模块获取.Name = "panel模块获取";
            this.panel模块获取.Size = new System.Drawing.Size(1153, 71);
            this.panel模块获取.TabIndex = 0;
            // 
            // UserControl数据导入
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel导入结果);
            this.Controls.Add(this.panel数据验证);
            this.Controls.Add(this.panel文件选择);
            this.Controls.Add(this.panel模块获取);
            this.Font = new System.Drawing.Font("宋体", 11F);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "UserControl数据导入";
            this.Size = new System.Drawing.Size(1153, 800);
            this.panel文件选择.ResumeLayout(false);
            this.panel文件选择.PerformLayout();
            this.panel数据验证.ResumeLayout(false);
            this.panel数据验证.PerformLayout();
            this.panel数据预览.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView预览数据)).EndInit();
            this.panel导入结果.ResumeLayout(false);
            this.panel导入结果.PerformLayout();
            this.panel模块获取.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panel文件选择;
        private System.Windows.Forms.Button button选择文件;
        private System.Windows.Forms.Label label选择文件全称;
        private System.Windows.Forms.Label label选择文件;
        private System.Windows.Forms.Panel panel数据验证;
        private System.Windows.Forms.Label label数据概况详细;
        private System.Windows.Forms.Label label数据概况;
        private System.Windows.Forms.Label label数据验证;
        private System.Windows.Forms.Button button确认导入;
        private System.Windows.Forms.DataGridView dataGridView预览数据;
        private System.Windows.Forms.Panel panel导入结果;
        private System.Windows.Forms.Label label具体进度;
        private System.Windows.Forms.Label label导入进度;
        private System.Windows.Forms.ProgressBar progressBar导入进度条;
        private System.Windows.Forms.Label label数据导入;
        private System.Windows.Forms.Panel panel数据预览;
        private System.Windows.Forms.Button button模板下载;
        private System.Windows.Forms.Panel panel模块获取;
    }
}
