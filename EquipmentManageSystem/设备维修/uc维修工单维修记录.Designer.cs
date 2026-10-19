
namespace EquipmentManageSystem.设备维修
{
    partial class uc维修工单维修记录
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
            this.groupBox维修记录 = new System.Windows.Forms.GroupBox();
            this.dataGridView维修记录 = new System.Windows.Forms.DataGridView();
            this.groupBox维修记录.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView维修记录)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox维修记录
            // 
            this.groupBox维修记录.Controls.Add(this.dataGridView维修记录);
            this.groupBox维修记录.Font = new System.Drawing.Font("宋体", 11F);
            this.groupBox维修记录.Location = new System.Drawing.Point(3, 3);
            this.groupBox维修记录.Name = "groupBox维修记录";
            this.groupBox维修记录.Size = new System.Drawing.Size(1275, 303);
            this.groupBox维修记录.TabIndex = 0;
            this.groupBox维修记录.TabStop = false;
            this.groupBox维修记录.Text = "维修记录";
            // 
            // dataGridView维修记录
            // 
            this.dataGridView维修记录.AllowUserToAddRows = false;
            this.dataGridView维修记录.AllowUserToDeleteRows = false;
            this.dataGridView维修记录.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dataGridView维修记录.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView维修记录.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView维修记录.Location = new System.Drawing.Point(3, 24);
            this.dataGridView维修记录.Name = "dataGridView维修记录";
            this.dataGridView维修记录.ReadOnly = true;
            this.dataGridView维修记录.RowHeadersWidth = 51;
            this.dataGridView维修记录.RowTemplate.Height = 27;
            this.dataGridView维修记录.Size = new System.Drawing.Size(1269, 276);
            this.dataGridView维修记录.TabIndex = 0;
            // 
            // uc维修工单维修记录
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.Controls.Add(this.groupBox维修记录);
            this.Name = "uc维修工单维修记录";
            this.Size = new System.Drawing.Size(1281, 309);
            this.Load += new System.EventHandler(this.uc维修工单维修记录_Load);
            this.groupBox维修记录.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView维修记录)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox维修记录;
        private System.Windows.Forms.DataGridView dataGridView维修记录;
    }
}
