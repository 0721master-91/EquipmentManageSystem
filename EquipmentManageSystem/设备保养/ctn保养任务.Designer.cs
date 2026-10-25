
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
            SLQLControls.控件.控件公用类.SlpInfoStop同时停启用相关信息 slpInfoStop同时停启用相关信息3 = new SLQLControls.控件.控件公用类.SlpInfoStop同时停启用相关信息();
            SLQLControls.控件.控件公用类.SlpInfoStop启用前判断 slpInfoStop启用前判断3 = new SLQLControls.控件.控件公用类.SlpInfoStop启用前判断();
            this.label位置简称 = new System.Windows.Forms.Label();
            this.textBox位置简称 = new System.Windows.Forms.TextBox();
            this.label过期状态 = new System.Windows.Forms.Label();
            this.comboBox过期状态 = new System.Windows.Forms.ComboBox();
            this.label保养人员 = new System.Windows.Forms.Label();
            this.comboBox保养人员 = new System.Windows.Forms.ComboBox();
            this.comboBox保养状态 = new System.Windows.Forms.ComboBox();
            this.label保养状态 = new System.Windows.Forms.Label();
            this.textBox模糊查询 = new System.Windows.Forms.TextBox();
            this.label模糊查询 = new System.Windows.Forms.Label();
            this.slDataTablePrinter1 = new SLControls.SLPrinter.SlDataTablePrinter(this.components);
            this.slFlatButton导出 = new SLQLControls.控件.SLFlatButton();
            this.button查看详细 = new System.Windows.Forms.Button();
            this.dateTimePicker计划执行日期结束日期 = new System.Windows.Forms.DateTimePicker();
            this.label计划执行日期连接符 = new System.Windows.Forms.Label();
            this.dateTimePicker计划执行日期开始日期 = new System.Windows.Forms.DateTimePicker();
            this.label计划执行日期 = new System.Windows.Forms.Label();
            this.comboBox所属组织 = new System.Windows.Forms.ComboBox();
            this.label所属组织 = new System.Windows.Forms.Label();
            this.dateTimePicker保养结束时间结束时间 = new System.Windows.Forms.DateTimePicker();
            this.label保养结束时间连接符 = new System.Windows.Forms.Label();
            this.dateTimePicker保养结束时间起始时间 = new System.Windows.Forms.DateTimePicker();
            this.label巡检开始时间 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.panel5.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel4.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.button查看详细);
            this.panel1.Location = new System.Drawing.Point(0, 625);
            this.panel1.Size = new System.Drawing.Size(1452, 62);
            this.panel1.Controls.SetChildIndex(this.panel5, 0);
            this.panel1.Controls.SetChildIndex(this.button停用, 0);
            this.panel1.Controls.SetChildIndex(this.button查询条件, 0);
            this.panel1.Controls.SetChildIndex(this.button修改, 0);
            this.panel1.Controls.SetChildIndex(this.button复制新增, 0);
            this.panel1.Controls.SetChildIndex(this.button删除, 0);
            this.panel1.Controls.SetChildIndex(this.button新增, 0);
            this.panel1.Controls.SetChildIndex(this.button查看详细, 0);
            // 
            // button查询条件
            // 
            this.button查询条件.Location = new System.Drawing.Point(793, 19);
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
            this.panel2.Controls.Add(this.dateTimePicker保养结束时间结束时间);
            this.panel2.Controls.Add(this.label保养结束时间连接符);
            this.panel2.Controls.Add(this.dateTimePicker保养结束时间起始时间);
            this.panel2.Controls.Add(this.label巡检开始时间);
            this.panel2.Controls.Add(this.comboBox所属组织);
            this.panel2.Controls.Add(this.label所属组织);
            this.panel2.Controls.Add(this.dateTimePicker计划执行日期结束日期);
            this.panel2.Controls.Add(this.label计划执行日期连接符);
            this.panel2.Controls.Add(this.dateTimePicker计划执行日期开始日期);
            this.panel2.Controls.Add(this.label计划执行日期);
            this.panel2.Controls.Add(this.textBox模糊查询);
            this.panel2.Controls.Add(this.label模糊查询);
            this.panel2.Controls.Add(this.comboBox保养状态);
            this.panel2.Controls.Add(this.label保养状态);
            this.panel2.Controls.Add(this.comboBox保养人员);
            this.panel2.Controls.Add(this.label保养人员);
            this.panel2.Controls.Add(this.comboBox过期状态);
            this.panel2.Controls.Add(this.label过期状态);
            this.panel2.Controls.Add(this.textBox位置简称);
            this.panel2.Controls.Add(this.label位置简称);
            this.panel2.Size = new System.Drawing.Size(1452, 139);
            this.panel2.Controls.SetChildIndex(this.label位置简称, 0);
            this.panel2.Controls.SetChildIndex(this.textBox位置简称, 0);
            this.panel2.Controls.SetChildIndex(this.label过期状态, 0);
            this.panel2.Controls.SetChildIndex(this.comboBox过期状态, 0);
            this.panel2.Controls.SetChildIndex(this.label保养人员, 0);
            this.panel2.Controls.SetChildIndex(this.comboBox保养人员, 0);
            this.panel2.Controls.SetChildIndex(this.label保养状态, 0);
            this.panel2.Controls.SetChildIndex(this.comboBox保养状态, 0);
            this.panel2.Controls.SetChildIndex(this.panel4, 0);
            this.panel2.Controls.SetChildIndex(this.buttonFocus, 0);
            this.panel2.Controls.SetChildIndex(this.label模糊查询, 0);
            this.panel2.Controls.SetChildIndex(this.textBox模糊查询, 0);
            this.panel2.Controls.SetChildIndex(this.label计划执行日期, 0);
            this.panel2.Controls.SetChildIndex(this.dateTimePicker计划执行日期开始日期, 0);
            this.panel2.Controls.SetChildIndex(this.label计划执行日期连接符, 0);
            this.panel2.Controls.SetChildIndex(this.dateTimePicker计划执行日期结束日期, 0);
            this.panel2.Controls.SetChildIndex(this.label所属组织, 0);
            this.panel2.Controls.SetChildIndex(this.comboBox所属组织, 0);
            this.panel2.Controls.SetChildIndex(this.label巡检开始时间, 0);
            this.panel2.Controls.SetChildIndex(this.dateTimePicker保养结束时间起始时间, 0);
            this.panel2.Controls.SetChildIndex(this.label保养结束时间连接符, 0);
            this.panel2.Controls.SetChildIndex(this.dateTimePicker保养结束时间结束时间, 0);
            // 
            // button定位
            // 
            this.button定位.FlatAppearance.BorderSize = 0;
            this.button定位.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.button定位.Location = new System.Drawing.Point(169, 10);
            // 
            // button筛选
            // 
            this.button筛选.FlatAppearance.BorderSize = 0;
            this.button筛选.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.button筛选.Location = new System.Drawing.Point(91, 10);
            // 
            // button刷新
            // 
            this.button刷新.FlatAppearance.BorderSize = 0;
            this.button刷新.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.button刷新.Location = new System.Drawing.Point(14, 10);
            // 
            // panel3
            // 
            this.panel3.Location = new System.Drawing.Point(0, 139);
            this.panel3.Size = new System.Drawing.Size(1452, 486);
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
            this.panel4.Controls.Add(this.slFlatButton导出);
            this.panel4.Location = new System.Drawing.Point(1174, 0);
            this.panel4.Size = new System.Drawing.Size(278, 139);
            this.panel4.Controls.SetChildIndex(this.button刷新, 0);
            this.panel4.Controls.SetChildIndex(this.button筛选, 0);
            this.panel4.Controls.SetChildIndex(this.button定位, 0);
            this.panel4.Controls.SetChildIndex(this.slFlatButton导出, 0);
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
            this.label过期状态.Location = new System.Drawing.Point(20, 43);
            this.label过期状态.Name = "label过期状态";
            this.label过期状态.Size = new System.Drawing.Size(104, 19);
            this.label过期状态.TabIndex = 19;
            this.label过期状态.Text = "过期状态：";
            // 
            // comboBox过期状态
            // 
            this.comboBox过期状态.Font = new System.Drawing.Font("宋体", 11F);
            this.comboBox过期状态.FormattingEnabled = true;
            this.comboBox过期状态.Location = new System.Drawing.Point(116, 39);
            this.comboBox过期状态.Name = "comboBox过期状态";
            this.comboBox过期状态.Size = new System.Drawing.Size(121, 26);
            this.comboBox过期状态.TabIndex = 20;
            // 
            // label保养人员
            // 
            this.label保养人员.AutoSize = true;
            this.label保养人员.Font = new System.Drawing.Font("宋体", 11F);
            this.label保养人员.Location = new System.Drawing.Point(281, 43);
            this.label保养人员.Name = "label保养人员";
            this.label保养人员.Size = new System.Drawing.Size(104, 19);
            this.label保养人员.TabIndex = 21;
            this.label保养人员.Text = "保养人员：";
            // 
            // comboBox保养人员
            // 
            this.comboBox保养人员.Cursor = System.Windows.Forms.Cursors.Hand;
            this.comboBox保养人员.DropDownHeight = 1;
            this.comboBox保养人员.DropDownWidth = 1;
            this.comboBox保养人员.Font = new System.Drawing.Font("宋体", 11F);
            this.comboBox保养人员.FormattingEnabled = true;
            this.comboBox保养人员.IntegralHeight = false;
            this.comboBox保养人员.Location = new System.Drawing.Point(372, 38);
            this.comboBox保养人员.Name = "comboBox保养人员";
            this.comboBox保养人员.Size = new System.Drawing.Size(285, 26);
            this.comboBox保养人员.TabIndex = 22;
            this.comboBox保养人员.MouseDown += new System.Windows.Forms.MouseEventHandler(this.comboBox保养人员_MouseDown);
            // 
            // comboBox保养状态
            // 
            this.comboBox保养状态.Font = new System.Drawing.Font("宋体", 11F);
            this.comboBox保养状态.FormattingEnabled = true;
            this.comboBox保养状态.Location = new System.Drawing.Point(806, 39);
            this.comboBox保养状态.Name = "comboBox保养状态";
            this.comboBox保养状态.Size = new System.Drawing.Size(121, 26);
            this.comboBox保养状态.TabIndex = 24;
            // 
            // label保养状态
            // 
            this.label保养状态.AutoSize = true;
            this.label保养状态.Font = new System.Drawing.Font("宋体", 11F);
            this.label保养状态.Location = new System.Drawing.Point(710, 43);
            this.label保养状态.Name = "label保养状态";
            this.label保养状态.Size = new System.Drawing.Size(104, 19);
            this.label保养状态.TabIndex = 23;
            this.label保养状态.Text = "保养状态：";
            // 
            // textBox模糊查询
            // 
            this.textBox模糊查询.Font = new System.Drawing.Font("宋体", 11F);
            this.textBox模糊查询.Location = new System.Drawing.Point(116, 102);
            this.textBox模糊查询.Name = "textBox模糊查询";
            this.textBox模糊查询.Size = new System.Drawing.Size(221, 28);
            this.textBox模糊查询.TabIndex = 26;
            this.textBox模糊查询.TextChanged += new System.EventHandler(this.FuzzyQuery);
            // 
            // label模糊查询
            // 
            this.label模糊查询.AutoSize = true;
            this.label模糊查询.Font = new System.Drawing.Font("宋体", 11F);
            this.label模糊查询.Location = new System.Drawing.Point(20, 107);
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
            // slFlatButton导出
            // 
            this.slFlatButton导出.FlatAppearance.BorderSize = 0;
            this.slFlatButton导出.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.slFlatButton导出.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.slFlatButton导出.GetFocusControl = null;
            this.slFlatButton导出.Location = new System.Drawing.Point(9, 36);
            this.slFlatButton导出.Name = "slFlatButton导出";
            this.slFlatButton导出.Size = new System.Drawing.Size(90, 32);
            this.slFlatButton导出.TabIndex = 10;
            this.slFlatButton导出.Text = "✅️ 导出";
            this.slFlatButton导出.UseVisualStyleBackColor = true;
            this.slFlatButton导出.Click += new System.EventHandler(this.slFlatButton导出_Click);
            // 
            // button查看详细
            // 
            this.button查看详细.BackColor = System.Drawing.Color.RoyalBlue;
            this.button查看详细.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button查看详细.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.button查看详细.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button查看详细.ForeColor = System.Drawing.Color.White;
            this.button查看详细.Location = new System.Drawing.Point(497, 19);
            this.button查看详细.Name = "button查看详细";
            this.button查看详细.Size = new System.Drawing.Size(100, 29);
            this.button查看详细.TabIndex = 34;
            this.button查看详细.Text = "查看详细";
            this.button查看详细.UseVisualStyleBackColor = false;
            this.button查看详细.Click += new System.EventHandler(this.button查看详细_Click);
            // 
            // dateTimePicker计划执行日期结束日期
            // 
            this.dateTimePicker计划执行日期结束日期.CalendarFont = new System.Drawing.Font("宋体", 11F);
            this.dateTimePicker计划执行日期结束日期.CustomFormat = "yyyy-MM-dd";
            this.dateTimePicker计划执行日期结束日期.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePicker计划执行日期结束日期.Location = new System.Drawing.Point(650, 7);
            this.dateTimePicker计划执行日期结束日期.Name = "dateTimePicker计划执行日期结束日期";
            this.dateTimePicker计划执行日期结束日期.Size = new System.Drawing.Size(159, 25);
            this.dateTimePicker计划执行日期结束日期.TabIndex = 34;
            this.dateTimePicker计划执行日期结束日期.ValueChanged += new System.EventHandler(this.VerifyPlanExecuteDate);
            // 
            // label计划执行日期连接符
            // 
            this.label计划执行日期连接符.AutoSize = true;
            this.label计划执行日期连接符.Font = new System.Drawing.Font("宋体", 14F);
            this.label计划执行日期连接符.Location = new System.Drawing.Point(627, 8);
            this.label计划执行日期连接符.Name = "label计划执行日期连接符";
            this.label计划执行日期连接符.Size = new System.Drawing.Size(22, 24);
            this.label计划执行日期连接符.TabIndex = 33;
            this.label计划执行日期连接符.Text = "-";
            // 
            // dateTimePicker计划执行日期开始日期
            // 
            this.dateTimePicker计划执行日期开始日期.CalendarFont = new System.Drawing.Font("宋体", 11F);
            this.dateTimePicker计划执行日期开始日期.CustomFormat = "yyyy-MM-dd";
            this.dateTimePicker计划执行日期开始日期.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePicker计划执行日期开始日期.Location = new System.Drawing.Point(464, 7);
            this.dateTimePicker计划执行日期开始日期.Name = "dateTimePicker计划执行日期开始日期";
            this.dateTimePicker计划执行日期开始日期.Size = new System.Drawing.Size(159, 25);
            this.dateTimePicker计划执行日期开始日期.TabIndex = 32;
            this.dateTimePicker计划执行日期开始日期.ValueChanged += new System.EventHandler(this.VerifyPlanExecuteDate);
            // 
            // label计划执行日期
            // 
            this.label计划执行日期.AutoSize = true;
            this.label计划执行日期.Font = new System.Drawing.Font("宋体", 11F);
            this.label计划执行日期.Location = new System.Drawing.Point(328, 10);
            this.label计划执行日期.Name = "label计划执行日期";
            this.label计划执行日期.Size = new System.Drawing.Size(142, 19);
            this.label计划执行日期.TabIndex = 31;
            this.label计划执行日期.Text = "计划执行日期：";
            // 
            // comboBox所属组织
            // 
            this.comboBox所属组织.Font = new System.Drawing.Font("宋体", 11F);
            this.comboBox所属组织.FormattingEnabled = true;
            this.comboBox所属组织.Location = new System.Drawing.Point(954, 6);
            this.comboBox所属组织.Name = "comboBox所属组织";
            this.comboBox所属组织.Size = new System.Drawing.Size(178, 26);
            this.comboBox所属组织.TabIndex = 36;
            this.comboBox所属组织.MouseDown += new System.Windows.Forms.MouseEventHandler(this.comboBox所属组织_MouseDown);
            // 
            // label所属组织
            // 
            this.label所属组织.AutoSize = true;
            this.label所属组织.Font = new System.Drawing.Font("宋体", 11F);
            this.label所属组织.Location = new System.Drawing.Point(855, 10);
            this.label所属组织.Name = "label所属组织";
            this.label所属组织.Size = new System.Drawing.Size(104, 19);
            this.label所属组织.TabIndex = 35;
            this.label所属组织.Text = "所属组织：";
            // 
            // dateTimePicker保养结束时间结束时间
            // 
            this.dateTimePicker保养结束时间结束时间.CalendarFont = new System.Drawing.Font("宋体", 11F);
            this.dateTimePicker保养结束时间结束时间.CustomFormat = "yyyy-MM-dd HH:mm:ss";
            this.dateTimePicker保养结束时间结束时间.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePicker保养结束时间结束时间.Location = new System.Drawing.Point(378, 73);
            this.dateTimePicker保养结束时间结束时间.Name = "dateTimePicker保养结束时间结束时间";
            this.dateTimePicker保养结束时间结束时间.Size = new System.Drawing.Size(200, 25);
            this.dateTimePicker保养结束时间结束时间.TabIndex = 40;
            this.dateTimePicker保养结束时间结束时间.ValueChanged += new System.EventHandler(this.VerifyMaintenanceEndDateTime);
            // 
            // label保养结束时间连接符
            // 
            this.label保养结束时间连接符.AutoSize = true;
            this.label保养结束时间连接符.Font = new System.Drawing.Font("宋体", 14F);
            this.label保养结束时间连接符.Location = new System.Drawing.Point(355, 74);
            this.label保养结束时间连接符.Name = "label保养结束时间连接符";
            this.label保养结束时间连接符.Size = new System.Drawing.Size(22, 24);
            this.label保养结束时间连接符.TabIndex = 39;
            this.label保养结束时间连接符.Text = "-";
            // 
            // dateTimePicker保养结束时间起始时间
            // 
            this.dateTimePicker保养结束时间起始时间.CalendarFont = new System.Drawing.Font("宋体", 11F);
            this.dateTimePicker保养结束时间起始时间.CustomFormat = "yyyy-MM-dd HH:mm:ss";
            this.dateTimePicker保养结束时间起始时间.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePicker保养结束时间起始时间.Location = new System.Drawing.Point(153, 73);
            this.dateTimePicker保养结束时间起始时间.Name = "dateTimePicker保养结束时间起始时间";
            this.dateTimePicker保养结束时间起始时间.Size = new System.Drawing.Size(200, 25);
            this.dateTimePicker保养结束时间起始时间.TabIndex = 38;
            this.dateTimePicker保养结束时间起始时间.ValueChanged += new System.EventHandler(this.VerifyMaintenanceEndDateTime);
            // 
            // label巡检开始时间
            // 
            this.label巡检开始时间.AutoSize = true;
            this.label巡检开始时间.Font = new System.Drawing.Font("宋体", 11F);
            this.label巡检开始时间.Location = new System.Drawing.Point(20, 76);
            this.label巡检开始时间.Name = "label巡检开始时间";
            this.label巡检开始时间.Size = new System.Drawing.Size(142, 19);
            this.label巡检开始时间.TabIndex = 37;
            this.label巡检开始时间.Text = "保养结束时间：";
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
            slpInfoStop同时停启用相关信息3.停用时提示信息 = "";
            slpInfoStop同时停启用相关信息3.启用时提示信息 = "";
            this.Info停用启用.Info同时停启用相关信息 = slpInfoStop同时停启用相关信息3;
            slpInfoStop启用前判断3.ColName启用时需要判断 = "";
            slpInfoStop启用前判断3.不能启用时提示信息 = "";
            this.Info停用启用.Info启用前判断 = slpInfoStop启用前判断3;
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
        private System.Windows.Forms.Label label保养人员;
        private System.Windows.Forms.ComboBox comboBox过期状态;
        private System.Windows.Forms.ComboBox comboBox保养人员;
        private System.Windows.Forms.TextBox textBox模糊查询;
        private System.Windows.Forms.Label label模糊查询;
        private System.Windows.Forms.ComboBox comboBox保养状态;
        private System.Windows.Forms.Label label保养状态;
        private SLControls.SLPrinter.SlDataTablePrinter slDataTablePrinter1;
        private SLQLControls.控件.SLFlatButton slFlatButton导出;
        private System.Windows.Forms.Button button查看详细;
        private System.Windows.Forms.DateTimePicker dateTimePicker计划执行日期结束日期;
        private System.Windows.Forms.Label label计划执行日期连接符;
        private System.Windows.Forms.DateTimePicker dateTimePicker计划执行日期开始日期;
        private System.Windows.Forms.Label label计划执行日期;
        private System.Windows.Forms.ComboBox comboBox所属组织;
        private System.Windows.Forms.Label label所属组织;
        private System.Windows.Forms.DateTimePicker dateTimePicker保养结束时间结束时间;
        private System.Windows.Forms.Label label保养结束时间连接符;
        private System.Windows.Forms.DateTimePicker dateTimePicker保养结束时间起始时间;
        private System.Windows.Forms.Label label巡检开始时间;
    }
}