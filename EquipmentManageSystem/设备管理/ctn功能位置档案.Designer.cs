
namespace EquipmentManageSystem.设备管理
{
    partial class ctn功能位置档案
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ctn功能位置档案));
            SLQLControls.控件.控件公用类.SlpInfoStop同时停启用相关信息 slpInfoStop同时停启用相关信息1 = new SLQLControls.控件.控件公用类.SlpInfoStop同时停启用相关信息();
            SLQLControls.控件.控件公用类.SlpInfoStop启用前判断 slpInfoStop启用前判断1 = new SLQLControls.控件.控件公用类.SlpInfoStop启用前判断();
            this.panel1.SuspendLayout();
            this.panel5.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel4.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Location = new System.Drawing.Point(0, 641);
            this.panel1.Size = new System.Drawing.Size(1498, 62);
            // 
            // panel5
            // 
            this.panel5.Location = new System.Drawing.Point(899, 0);
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
            this.panel2.Size = new System.Drawing.Size(1498, 74);
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
            this.panel3.Location = new System.Drawing.Point(0, 74);
            this.panel3.Size = new System.Drawing.Size(1498, 567);
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
            this.panel4.Location = new System.Drawing.Point(1230, 0);
            this.panel4.Size = new System.Drawing.Size(268, 74);
            // 
            // ctn功能位置档案
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1498, 703);
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
            this.Name = "ctn功能位置档案";
            this.Text = "ctn设备功能位置档案";
            this.BeforeChangeDataSource += new SLQLControls.公用类.SlcQLPublic.BoolEventHandle(this.ctn功能位置档案_BeforeChangeDataSource);
            this.Load += new System.EventHandler(this.ctn功能位置档案_Load);
            this.Controls.SetChildIndex(this.panel2, 0);
            this.Controls.SetChildIndex(this.panel1, 0);
            this.Controls.SetChildIndex(this.panel3, 0);
            this.panel1.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
    }
}