
using grproLib;

namespace EquipmentManageSystem.设备保养
{
    partial class ctn保养任务
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ctn保养任务));
            SLQLControls.控件.控件公用类.SlpInfoStop同时停启用相关信息 slpInfoStop同时停启用相关信息1 = new SLQLControls.控件.控件公用类.SlpInfoStop同时停启用相关信息();
            SLQLControls.控件.控件公用类.SlpInfoStop启用前判断 slpInfoStop启用前判断1 = new SLQLControls.控件.控件公用类.SlpInfoStop启用前判断();
            this.label位置简称 = new System.Windows.Forms.Label();
            this.textBox位置简称 = new System.Windows.Forms.TextBox();
            this.label过期状态 = new System.Windows.Forms.Label();
            this.comboBox过期状态 = new System.Windows.Forms.ComboBox();
            this.label保养人 = new System.Windows.Forms.Label();
            this.comboBox保养人员 = new System.Windows.Forms.ComboBox();
            this.comboBox保养状态 = new System.Windows.Forms.ComboBox();
            this.label保养状态 = new System.Windows.Forms.Label();
            this.textBox模糊查询 = new System.Windows.Forms.TextBox();
            this.label模糊查询 = new System.Windows.Forms.Label();
            this.slDataTablePrinter1 = new SLControls.SLPrinter.SlDataTablePrinter(this.components);
            this.panel1.SuspendLayout();
            this.panel5.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel4.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Location = new System.Drawing.Point(0, 625);
            this.panel1.Size = new System.Drawing.Size(1452, 62);
            // 
            // panel5
            // 
            this.panel5.Location = new System.Drawing.Point(853, 0);
            // 
            // button退出
            // 
            this.button退出.Visible = false;
            // 
            // button帮助
            // 
            this.button帮助.Visible = false;
            // 
            // button打印
            // 
            this.button打印.Visible = false;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.textBox模糊查询);
            this.panel2.Controls.Add(this.label模糊查询);
            this.panel2.Controls.Add(this.comboBox保养状态);
            this.panel2.Controls.Add(this.label保养状态);
            this.panel2.Controls.Add(this.comboBox保养人员);
            this.panel2.Controls.Add(this.label保养人);
            this.panel2.Controls.Add(this.comboBox过期状态);
            this.panel2.Controls.Add(this.label过期状态);
            this.panel2.Controls.Add(this.textBox位置简称);
            this.panel2.Controls.Add(this.label位置简称);
            this.panel2.Size = new System.Drawing.Size(1452, 72);
            this.panel2.Controls.SetChildIndex(this.label位置简称, 0);
            this.panel2.Controls.SetChildIndex(this.textBox位置简称, 0);
            this.panel2.Controls.SetChildIndex(this.label过期状态, 0);
            this.panel2.Controls.SetChildIndex(this.comboBox过期状态, 0);
            this.panel2.Controls.SetChildIndex(this.label保养人, 0);
            this.panel2.Controls.SetChildIndex(this.comboBox保养人员, 0);
            this.panel2.Controls.SetChildIndex(this.label保养状态, 0);
            this.panel2.Controls.SetChildIndex(this.comboBox保养状态, 0);
            this.panel2.Controls.SetChildIndex(this.panel4, 0);
            this.panel2.Controls.SetChildIndex(this.buttonFocus, 0);
            this.panel2.Controls.SetChildIndex(this.label模糊查询, 0);
            this.panel2.Controls.SetChildIndex(this.textBox模糊查询, 0);
            // 
            // button定位
            // 
            this.button定位.FlatAppearance.BorderSize = 0;
            this.button定位.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            // 
            // button筛选
            // 
            this.button筛选.FlatAppearance.BorderSize = 0;
            this.button筛选.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            // 
            // button刷新
            // 
            this.button刷新.FlatAppearance.BorderSize = 0;
            this.button刷新.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            // 
            // panel3
            // 
            this.panel3.Location = new System.Drawing.Point(0, 72);
            this.panel3.Size = new System.Drawing.Size(1452, 553);
            // 
            // slDataTablePrinter
            // 
            this.slDataTablePrinter.ThePrintInfo.GridReport = null;
            this.slDataTablePrinter.ThePrintInfo.PageFooter.Height = 1D;
            this.slDataTablePrinter.ThePrintInfo.PageFooter.RtfBox1 = null;
            this.slDataTablePrinter.ThePrintInfo.PageFooter.RtfBox2 = null;
            this.slDataTablePrinter.ThePrintInfo.PageFooter.RtfBox3 = null;
            this.slDataTablePrinter.ThePrintInfo.PageHeader.Height = 1D;
            this.slDataTablePrinter.ThePrintInfo.PageHeader.RtfBox1 = null;
            this.slDataTablePrinter.ThePrintInfo.PageHeader.RtfBox2 = null;
            this.slDataTablePrinter.ThePrintInfo.PageHeader.RtfBox3 = null;
            this.slDataTablePrinter.ThePrintInfo.PageHeader.TextBox2.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.slDataTablePrinter.ThePrintInfo.PageHeader.TextBox2.HorizonAlign = System.Windows.Forms.VisualStyles.HorizontalAlign.Center;
            this.slDataTablePrinter.ThePrintInfo.ReportFooter.RtfBox1 = null;
            this.slDataTablePrinter.ThePrintInfo.ReportFooter.RtfBox2 = null;
            this.slDataTablePrinter.ThePrintInfo.ReportFooter.RtfBox3 = null;
            this.slDataTablePrinter.ThePrintInfo.ReportFooter.TextBox2.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.slDataTablePrinter.ThePrintInfo.ReportHeader.RtfBox1 = null;
            this.slDataTablePrinter.ThePrintInfo.ReportHeader.RtfBox2 = null;
            this.slDataTablePrinter.ThePrintInfo.ReportHeader.RtfBox3 = null;
            // 
            // panel4
            // 
            this.panel4.Location = new System.Drawing.Point(1184, 0);
            this.panel4.Size = new System.Drawing.Size(268, 72);
            // 
            // label位置简称
            // 
            this.label位置简称.AutoSize = true;
            this.label位置简称.Font = new System.Drawing.Font("宋体", 11F);
            this.label位置简称.Location = new System.Drawing.Point(20, 10);
            this.label位置简称.Name = "label位置简称";
            this.label位置简称.Size = new System.Drawing.Size(104, 19);
            this.label位置简称.TabIndex = 17;
            this.label位置简称.Text = "位置简称：";
            // 
            // textBox位置简称
            // 
            this.textBox位置简称.Font = new System.Drawing.Font("宋体", 11F);
            this.textBox位置简称.Location = new System.Drawing.Point(116, 5);
            this.textBox位置简称.Name = "textBox位置简称";
            this.textBox位置简称.Size = new System.Drawing.Size(161, 28);
            this.textBox位置简称.TabIndex = 18;
            // 
            // label过期状态
            // 
            this.label过期状态.AutoSize = true;
            this.label过期状态.Font = new System.Drawing.Font("宋体", 11F);
            this.label过期状态.Location = new System.Drawing.Point(299, 10);
            this.label过期状态.Name = "label过期状态";
            this.label过期状态.Size = new System.Drawing.Size(104, 19);
            this.label过期状态.TabIndex = 19;
            this.label过期状态.Text = "过期状态：";
            // 
            // comboBox过期状态
            // 
            this.comboBox过期状态.Font = new System.Drawing.Font("宋体", 11F);
            this.comboBox过期状态.FormattingEnabled = true;
            this.comboBox过期状态.Location = new System.Drawing.Point(395, 6);
            this.comboBox过期状态.Name = "comboBox过期状态";
            this.comboBox过期状态.Size = new System.Drawing.Size(121, 26);
            this.comboBox过期状态.TabIndex = 20;
            // 
            // label保养人
            // 
            this.label保养人.AutoSize = true;
            this.label保养人.Font = new System.Drawing.Font("宋体", 11F);
            this.label保养人.Location = new System.Drawing.Point(541, 10);
            this.label保养人.Name = "label保养人";
            this.label保养人.Size = new System.Drawing.Size(85, 19);
            this.label保养人.TabIndex = 21;
            this.label保养人.Text = "保养人：";
            // 
            // comboBox保养人员
            // 
            this.comboBox保养人员.Cursor = System.Windows.Forms.Cursors.Hand;
            this.comboBox保养人员.DropDownHeight = 1;
            this.comboBox保养人员.DropDownWidth = 1;
            this.comboBox保养人员.Font = new System.Drawing.Font("宋体", 11F);
            this.comboBox保养人员.FormattingEnabled = true;
            this.comboBox保养人员.IntegralHeight = false;
            this.comboBox保养人员.Location = new System.Drawing.Point(619, 6);
            this.comboBox保养人员.Name = "comboBox保养人员";
            this.comboBox保养人员.Size = new System.Drawing.Size(142, 26);
            this.comboBox保养人员.TabIndex = 22;
            this.comboBox保养人员.MouseDown += new System.Windows.Forms.MouseEventHandler(this.comboBox保养人员_MouseDown);
            // 
            // comboBox保养状态
            // 
            this.comboBox保养状态.Font = new System.Drawing.Font("宋体", 11F);
            this.comboBox保养状态.FormattingEnabled = true;
            this.comboBox保养状态.Location = new System.Drawing.Point(885, 6);
            this.comboBox保养状态.Name = "comboBox保养状态";
            this.comboBox保养状态.Size = new System.Drawing.Size(121, 26);
            this.comboBox保养状态.TabIndex = 24;
            // 
            // label保养状态
            // 
            this.label保养状态.AutoSize = true;
            this.label保养状态.Font = new System.Drawing.Font("宋体", 11F);
            this.label保养状态.Location = new System.Drawing.Point(789, 10);
            this.label保养状态.Name = "label保养状态";
            this.label保养状态.Size = new System.Drawing.Size(104, 19);
            this.label保养状态.TabIndex = 23;
            this.label保养状态.Text = "保养状态：";
            // 
            // textBox模糊查询
            // 
            this.textBox模糊查询.Font = new System.Drawing.Font("宋体", 11F);
            this.textBox模糊查询.Location = new System.Drawing.Point(116, 38);
            this.textBox模糊查询.Name = "textBox模糊查询";
            this.textBox模糊查询.Size = new System.Drawing.Size(221, 28);
            this.textBox模糊查询.TabIndex = 26;
            this.textBox模糊查询.TextChanged += new System.EventHandler(this.FuzzyQuery);
            // 
            // label模糊查询
            // 
            this.label模糊查询.AutoSize = true;
            this.label模糊查询.Font = new System.Drawing.Font("宋体", 11F);
            this.label模糊查询.Location = new System.Drawing.Point(20, 43);
            this.label模糊查询.Name = "label模糊查询";
            this.label模糊查询.Size = new System.Drawing.Size(104, 19);
            this.label模糊查询.TabIndex = 25;
            this.label模糊查询.Text = "模糊查询：";
            // 
            // slDataTablePrinter1
            // 
            this.slDataTablePrinter1.TheDataTable = null;
            this.slDataTablePrinter1.ThePrintInfo.GridReport = null;
            this.slDataTablePrinter1.ThePrintInfo.PageFooter.RtfBox1 = null;
            this.slDataTablePrinter1.ThePrintInfo.PageFooter.RtfBox2 = null;
            this.slDataTablePrinter1.ThePrintInfo.PageFooter.RtfBox3 = null;
            this.slDataTablePrinter1.ThePrintInfo.PageHeader.RtfBox1 = null;
            this.slDataTablePrinter1.ThePrintInfo.PageHeader.RtfBox2 = null;
            this.slDataTablePrinter1.ThePrintInfo.PageHeader.RtfBox3 = null;
            this.slDataTablePrinter1.ThePrintInfo.ReportFooter.RtfBox1 = null;
            this.slDataTablePrinter1.ThePrintInfo.ReportFooter.RtfBox2 = null;
            this.slDataTablePrinter1.ThePrintInfo.ReportFooter.RtfBox3 = null;
            this.slDataTablePrinter1.ThePrintInfo.ReportHeader.RtfBox1 = null;
            this.slDataTablePrinter1.ThePrintInfo.ReportHeader.RtfBox2 = null;
            this.slDataTablePrinter1.ThePrintInfo.ReportHeader.RtfBox3 = null;
            // 
            // ctn保养任务
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1452, 687);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Info停用启用.ColName停用 = "";
            this.Info停用启用.Color停用 = System.Drawing.Color.Red;
            this.Info停用启用.FieldName停用 = "";
            slpInfoStop同时停启用相关信息1.停用时提示信息 = "";
            slpInfoStop同时停启用相关信息1.启用时提示信息 = "";
            this.Info停用启用.Info同时停启用相关信息 = slpInfoStop同时停启用相关信息1;
            slpInfoStop启用前判断1.ColName启用时需要判断 = "";
            slpInfoStop启用前判断1.不能启用时提示信息 = "";
            this.Info停用启用.Info启用前判断 = slpInfoStop启用前判断1;
            this.Info列配置.CurUserID = ((long)(0));
            this.Info列配置.列配置信息 = "";
            this.Info列配置.标识 = "";
            this.Info数据查询.ColNameID = "ID";
            this.Info数据查询.FieldNameID = "ID";
            this.Info数据查询.SqlSelByID = "SELECT M.* FROM () M WHERE M.ID={0}";
            this.Info数据查询.SqlSelTop1 = "SELECT TOP 1 M.* FROM () M ORDER BY M.ID DESC";
            this.Info数据查询.Sql查询 = "";
            this.Info数据编辑.FieldName不能修改 = "";
            this.Info数据编辑.FieldName不能删除 = "";
            this.Info数据编辑.Params = null;
            this.Info数据编辑.Type编辑窗口 = null;
            this.Name = "ctn保养任务";
            this.TableName = "保养任务";
            this.Text = "保养任务";
            this.AfterChangeDataSource += new SLQLControls.模板.temp标准报表GridControl.AfterChangeDataSourceEventHandle(this.ctn保养任务_AfterChangeDataSource);
            this.BeforeChangeDataSource += new SLQLControls.公用类.SlcQLPublic.BoolEventHandle(this.ctn保养任务_BeforeChangeDataSource);
            this.Load += new System.EventHandler(this.ctn保养任务_Load);
            this.Controls.SetChildIndex(this.panel2, 0);
            this.Controls.SetChildIndex(this.panel1, 0);
            this.Controls.SetChildIndex(this.panel3, 0);
            this.panel1.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label位置简称;
        private System.Windows.Forms.Label label过期状态;
        private System.Windows.Forms.TextBox textBox位置简称;
        private System.Windows.Forms.Label label保养人;
        private System.Windows.Forms.ComboBox comboBox过期状态;
        private System.Windows.Forms.ComboBox comboBox保养人员;
        private System.Windows.Forms.TextBox textBox模糊查询;
        private System.Windows.Forms.Label label模糊查询;
        private System.Windows.Forms.ComboBox comboBox保养状态;
        private System.Windows.Forms.Label label保养状态;
        private SLControls.SLPrinter.SlDataTablePrinter slDataTablePrinter1;
    }
}