
namespace EquipmentManageSystem.数据报表
{
    partial class uc设备总体概况人员工作量
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
            this.panel标题区 = new System.Windows.Forms.Panel();
            this.button人员工作量导出 = new System.Windows.Forms.Button();
            this.label二级标题 = new System.Windows.Forms.Label();
            this.label一级标题 = new System.Windows.Forms.Label();
            this.panel柱状图标签区 = new System.Windows.Forms.Panel();
            this.label巡检 = new System.Windows.Forms.Label();
            this.pictureBox巡检颜色 = new System.Windows.Forms.PictureBox();
            this.label维修 = new System.Windows.Forms.Label();
            this.pictureBox维修颜色 = new System.Windows.Forms.PictureBox();
            this.label保养 = new System.Windows.Forms.Label();
            this.pictureBox保养颜色 = new System.Windows.Forms.PictureBox();
            this.panel柱状图内容区 = new System.Windows.Forms.Panel();
            this.panel标题区.SuspendLayout();
            this.panel柱状图标签区.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox巡检颜色)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox维修颜色)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox保养颜色)).BeginInit();
            this.SuspendLayout();
            // 
            // panel标题区
            // 
            this.panel标题区.Controls.Add(this.button人员工作量导出);
            this.panel标题区.Controls.Add(this.label二级标题);
            this.panel标题区.Controls.Add(this.label一级标题);
            this.panel标题区.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel标题区.Location = new System.Drawing.Point(0, 0);
            this.panel标题区.Name = "panel标题区";
            this.panel标题区.Size = new System.Drawing.Size(720, 52);
            this.panel标题区.TabIndex = 1;
            // 
            // button人员工作量导出
            // 
            this.button人员工作量导出.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button人员工作量导出.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.button人员工作量导出.FlatAppearance.BorderSize = 0;
            this.button人员工作量导出.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button人员工作量导出.Font = new System.Drawing.Font("宋体", 11F);
            this.button人员工作量导出.Location = new System.Drawing.Point(626, 8);
            this.button人员工作量导出.Name = "button人员工作量导出";
            this.button人员工作量导出.Size = new System.Drawing.Size(83, 32);
            this.button人员工作量导出.TabIndex = 2;
            this.button人员工作量导出.Text = "导出";
            this.button人员工作量导出.UseVisualStyleBackColor = false;
            this.button人员工作量导出.Click += new System.EventHandler(this.button人员工作量导出_Click);
            // 
            // label二级标题
            // 
            this.label二级标题.AutoSize = true;
            this.label二级标题.Location = new System.Drawing.Point(45, 33);
            this.label二级标题.Name = "label二级标题";
            this.label二级标题.Size = new System.Drawing.Size(204, 15);
            this.label二级标题.TabIndex = 1;
            this.label二级标题.Text = "维修/巡检/保养  完成工单数";
            // 
            // label一级标题
            // 
            this.label一级标题.Font = new System.Drawing.Font("宋体", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label一级标题.Location = new System.Drawing.Point(3, 3);
            this.label一级标题.Name = "label一级标题";
            this.label一级标题.Size = new System.Drawing.Size(174, 24);
            this.label一级标题.TabIndex = 0;
            this.label一级标题.Text = "📌 人员工作量";
            // 
            // panel柱状图标签区
            // 
            this.panel柱状图标签区.Controls.Add(this.label巡检);
            this.panel柱状图标签区.Controls.Add(this.pictureBox巡检颜色);
            this.panel柱状图标签区.Controls.Add(this.label维修);
            this.panel柱状图标签区.Controls.Add(this.pictureBox维修颜色);
            this.panel柱状图标签区.Controls.Add(this.label保养);
            this.panel柱状图标签区.Controls.Add(this.pictureBox保养颜色);
            this.panel柱状图标签区.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel柱状图标签区.Location = new System.Drawing.Point(0, 52);
            this.panel柱状图标签区.Name = "panel柱状图标签区";
            this.panel柱状图标签区.Size = new System.Drawing.Size(720, 39);
            this.panel柱状图标签区.TabIndex = 2;
            // 
            // label巡检
            // 
            this.label巡检.AutoSize = true;
            this.label巡检.Location = new System.Drawing.Point(342, 14);
            this.label巡检.Name = "label巡检";
            this.label巡检.Size = new System.Drawing.Size(37, 15);
            this.label巡检.TabIndex = 5;
            this.label巡检.Text = "巡检";
            // 
            // pictureBox巡检颜色
            // 
            this.pictureBox巡检颜色.BackColor = System.Drawing.Color.Orange;
            this.pictureBox巡检颜色.Location = new System.Drawing.Point(322, 12);
            this.pictureBox巡检颜色.Name = "pictureBox巡检颜色";
            this.pictureBox巡检颜色.Size = new System.Drawing.Size(18, 18);
            this.pictureBox巡检颜色.TabIndex = 4;
            this.pictureBox巡检颜色.TabStop = false;
            // 
            // label维修
            // 
            this.label维修.AutoSize = true;
            this.label维修.Location = new System.Drawing.Point(414, 14);
            this.label维修.Name = "label维修";
            this.label维修.Size = new System.Drawing.Size(37, 15);
            this.label维修.TabIndex = 3;
            this.label维修.Text = "维修";
            // 
            // pictureBox维修颜色
            // 
            this.pictureBox维修颜色.BackColor = System.Drawing.Color.Red;
            this.pictureBox维修颜色.Location = new System.Drawing.Point(394, 12);
            this.pictureBox维修颜色.Name = "pictureBox维修颜色";
            this.pictureBox维修颜色.Size = new System.Drawing.Size(18, 18);
            this.pictureBox维修颜色.TabIndex = 2;
            this.pictureBox维修颜色.TabStop = false;
            // 
            // label保养
            // 
            this.label保养.AutoSize = true;
            this.label保养.Location = new System.Drawing.Point(268, 14);
            this.label保养.Name = "label保养";
            this.label保养.Size = new System.Drawing.Size(37, 15);
            this.label保养.TabIndex = 1;
            this.label保养.Text = "保养";
            // 
            // pictureBox保养颜色
            // 
            this.pictureBox保养颜色.BackColor = System.Drawing.Color.SpringGreen;
            this.pictureBox保养颜色.Location = new System.Drawing.Point(248, 12);
            this.pictureBox保养颜色.Name = "pictureBox保养颜色";
            this.pictureBox保养颜色.Size = new System.Drawing.Size(18, 18);
            this.pictureBox保养颜色.TabIndex = 0;
            this.pictureBox保养颜色.TabStop = false;
            // 
            // panel柱状图内容区
            // 
            this.panel柱状图内容区.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel柱状图内容区.Location = new System.Drawing.Point(0, 91);
            this.panel柱状图内容区.Name = "panel柱状图内容区";
            this.panel柱状图内容区.Size = new System.Drawing.Size(720, 389);
            this.panel柱状图内容区.TabIndex = 3;
            // 
            // uc设备总体概况人员工作量
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.Controls.Add(this.panel柱状图内容区);
            this.Controls.Add(this.panel柱状图标签区);
            this.Controls.Add(this.panel标题区);
            this.Name = "uc设备总体概况人员工作量";
            this.Size = new System.Drawing.Size(720, 480);
            this.panel标题区.ResumeLayout(false);
            this.panel标题区.PerformLayout();
            this.panel柱状图标签区.ResumeLayout(false);
            this.panel柱状图标签区.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox巡检颜色)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox维修颜色)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox保养颜色)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel标题区;
        private System.Windows.Forms.Label label二级标题;
        private System.Windows.Forms.Label label一级标题;
        private System.Windows.Forms.Panel panel柱状图标签区;
        private System.Windows.Forms.Panel panel柱状图内容区;
        private System.Windows.Forms.Label label保养;
        private System.Windows.Forms.PictureBox pictureBox保养颜色;
        private System.Windows.Forms.Label label巡检;
        private System.Windows.Forms.PictureBox pictureBox巡检颜色;
        private System.Windows.Forms.Label label维修;
        private System.Windows.Forms.PictureBox pictureBox维修颜色;
        private System.Windows.Forms.Button button人员工作量导出;
    }
}
