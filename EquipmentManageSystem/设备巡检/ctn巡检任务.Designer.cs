
namespace EquipmentManageSystem.设备巡检
{
    partial class ctn巡检任务
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ctn巡检任务));
            SLQLControls.控件.控件公用类.SlpInfoStop同时停启用相关信息 slpInfoStop同时停启用相关信息1 = new SLQLControls.控件.控件公用类.SlpInfoStop同时停启用相关信息();
            SLQLControls.控件.控件公用类.SlpInfoStop启用前判断 slpInfoStop启用前判断1 = new SLQLControls.控件.控件公用类.SlpInfoStop启用前判断();
            this.label执行状态 = new System.Windows.Forms.Label();
            this.comboBox执行状态 = new System.Windows.Forms.ComboBox();
            this.comboBox过期状态 = new System.Windows.Forms.ComboBox();
            this.label过期状态 = new System.Windows.Forms.Label();
            this.label模糊查询 = new System.Windows.Forms.Label();
            this.textBox模糊查询 = new System.Windows.Forms.TextBox();
            this.slFlatButton导入 = new SLQLControls.控件.SLFlatButton();
            this.button查看详细 = new System.Windows.Forms.Button();
            this.label位置简称 = new System.Windows.Forms.Label();
            this.textBox位置简称 = new System.Windows.Forms.TextBox();
            this.label计划执行日期 = new System.Windows.Forms.Label();
            this.dateTimePicker计划执行日期开始日期 = new System.Windows.Forms.DateTimePicker();
            this.label计划执行日期连接符 = new System.Windows.Forms.Label();
            this.dateTimePicker计划执行日期结束日期 = new System.Windows.Forms.DateTimePicker();
            this.dateTimePicker巡检开始时间结束时间 = new System.Windows.Forms.DateTimePicker();
            this.label巡检开始时间连接符 = new System.Windows.Forms.Label();
            this.dateTimePicker巡检开始时间起始时间 = new System.Windows.Forms.DateTimePicker();
            this.label巡检开始时间 = new System.Windows.Forms.Label();
            this.label创建时间 = new System.Windows.Forms.Label();
            this.dateTimePicker创建时间结束时间 = new System.Windows.Forms.DateTimePicker();
            this.label创建时间连接符 = new System.Windows.Forms.Label();
            this.dateTimePicker创建时间起始时间 = new System.Windows.Forms.DateTimePicker();
            this.comboBox巡检人员 = new System.Windows.Forms.ComboBox();
            this.label巡检人员 = new System.Windows.Forms.Label();
            this.label所属组织 = new System.Windows.Forms.Label();
            this.comboBox所属组织 = new System.Windows.Forms.ComboBox();
            this.panel1.SuspendLayout();
            this.panel5.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel4.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.button查看详细);
            this.panel1.Location = new System.Drawing.Point(0, 626);
            this.panel1.Size = new System.Drawing.Size(1692, 62);
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
            this.button查询条件.Location = new System.Drawing.Point(632, 19);
            // 
            // panel5
            // 
            this.panel5.Location = new System.Drawing.Point(1093, 0);
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
            this.panel2.Controls.Add(this.comboBox巡检人员);
            this.panel2.Controls.Add(this.label巡检人员);
            this.panel2.Controls.Add(this.dateTimePicker创建时间结束时间);
            this.panel2.Controls.Add(this.label创建时间连接符);
            this.panel2.Controls.Add(this.dateTimePicker创建时间起始时间);
            this.panel2.Controls.Add(this.label创建时间);
            this.panel2.Controls.Add(this.dateTimePicker巡检开始时间结束时间);
            this.panel2.Controls.Add(this.label巡检开始时间连接符);
            this.panel2.Controls.Add(this.dateTimePicker巡检开始时间起始时间);
            this.panel2.Controls.Add(this.label巡检开始时间);
            this.panel2.Controls.Add(this.dateTimePicker计划执行日期结束日期);
            this.panel2.Controls.Add(this.label计划执行日期连接符);
            this.panel2.Controls.Add(this.dateTimePicker计划执行日期开始日期);
            this.panel2.Controls.Add(this.label计划执行日期);
            this.panel2.Controls.Add(this.textBox位置简称);
            this.panel2.Controls.Add(this.label位置简称);
            this.panel2.Controls.Add(this.comboBox所属组织);
            this.panel2.Controls.Add(this.label所属组织);
            this.panel2.Controls.Add(this.textBox模糊查询);
            this.panel2.Controls.Add(this.label模糊查询);
            this.panel2.Controls.Add(this.comboBox过期状态);
            this.panel2.Controls.Add(this.label过期状态);
            this.panel2.Controls.Add(this.comboBox执行状态);
            this.panel2.Controls.Add(this.label执行状态);
            this.panel2.Size = new System.Drawing.Size(1692, 146);
            this.panel2.Controls.SetChildIndex(this.label执行状态, 0);
            this.panel2.Controls.SetChildIndex(this.comboBox执行状态, 0);
            this.panel2.Controls.SetChildIndex(this.label过期状态, 0);
            this.panel2.Controls.SetChildIndex(this.comboBox过期状态, 0);
            this.panel2.Controls.SetChildIndex(this.label模糊查询, 0);
            this.panel2.Controls.SetChildIndex(this.textBox模糊查询, 0);
            this.panel2.Controls.SetChildIndex(this.label所属组织, 0);
            this.panel2.Controls.SetChildIndex(this.comboBox所属组织, 0);
            this.panel2.Controls.SetChildIndex(this.label位置简称, 0);
            this.panel2.Controls.SetChildIndex(this.textBox位置简称, 0);
            this.panel2.Controls.SetChildIndex(this.label计划执行日期, 0);
            this.panel2.Controls.SetChildIndex(this.dateTimePicker计划执行日期开始日期, 0);
            this.panel2.Controls.SetChildIndex(this.label计划执行日期连接符, 0);
            this.panel2.Controls.SetChildIndex(this.dateTimePicker计划执行日期结束日期, 0);
            this.panel2.Controls.SetChildIndex(this.label巡检开始时间, 0);
            this.panel2.Controls.SetChildIndex(this.dateTimePicker巡检开始时间起始时间, 0);
            this.panel2.Controls.SetChildIndex(this.label巡检开始时间连接符, 0);
            this.panel2.Controls.SetChildIndex(this.dateTimePicker巡检开始时间结束时间, 0);
            this.panel2.Controls.SetChildIndex(this.label创建时间, 0);
            this.panel2.Controls.SetChildIndex(this.dateTimePicker创建时间起始时间, 0);
            this.panel2.Controls.SetChildIndex(this.label创建时间连接符, 0);
            this.panel2.Controls.SetChildIndex(this.dateTimePicker创建时间结束时间, 0);
            this.panel2.Controls.SetChildIndex(this.label巡检人员, 0);
            this.panel2.Controls.SetChildIndex(this.comboBox巡检人员, 0);
            this.panel2.Controls.SetChildIndex(this.panel4, 0);
            this.panel2.Controls.SetChildIndex(this.buttonFocus, 0);
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
            this.button筛选.Location = new System.Drawing.Point(89, 10);
            // 
            // button刷新
            // 
            this.button刷新.FlatAppearance.BorderSize = 0;
            this.button刷新.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.button刷新.Location = new System.Drawing.Point(16, 10);
            // 
            // panel3
            // 
            this.panel3.Location = new System.Drawing.Point(0, 146);
            this.panel3.Size = new System.Drawing.Size(1692, 480);
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
            this.panel4.Controls.Add(this.slFlatButton导入);
            this.panel4.Location = new System.Drawing.Point(1346, 0);
            this.panel4.Size = new System.Drawing.Size(346, 146);
            this.panel4.Controls.SetChildIndex(this.button刷新, 0);
            this.panel4.Controls.SetChildIndex(this.button筛选, 0);
            this.panel4.Controls.SetChildIndex(this.button定位, 0);
            this.panel4.Controls.SetChildIndex(this.slFlatButton导入, 0);
            // 
            // label执行状态
            // 
            this.label执行状态.AutoSize = true;
            this.label执行状态.Font = new System.Drawing.Font("宋体", 11F);
            this.label执行状态.Location = new System.Drawing.Point(13, 48);
            this.label执行状态.Name = "label执行状态";
            this.label执行状态.Size = new System.Drawing.Size(104, 19);
            this.label执行状态.TabIndex = 17;
            this.label执行状态.Text = "执行状态：";
            // 
            // comboBox执行状态
            // 
            this.comboBox执行状态.Font = new System.Drawing.Font("宋体", 11F);
            this.comboBox执行状态.FormattingEnabled = true;
            this.comboBox执行状态.Location = new System.Drawing.Point(112, 44);
            this.comboBox执行状态.Name = "comboBox执行状态";
            this.comboBox执行状态.Size = new System.Drawing.Size(121, 26);
            this.comboBox执行状态.TabIndex = 18;
            // 
            // comboBox过期状态
            // 
            this.comboBox过期状态.Font = new System.Drawing.Font("宋体", 11F);
            this.comboBox过期状态.FormattingEnabled = true;
            this.comboBox过期状态.Location = new System.Drawing.Point(356, 44);
            this.comboBox过期状态.Name = "comboBox过期状态";
            this.comboBox过期状态.Size = new System.Drawing.Size(121, 26);
            this.comboBox过期状态.TabIndex = 20;
            // 
            // label过期状态
            // 
            this.label过期状态.AutoSize = true;
            this.label过期状态.Font = new System.Drawing.Font("宋体", 11F);
            this.label过期状态.Location = new System.Drawing.Point(260, 48);
            this.label过期状态.Name = "label过期状态";
            this.label过期状态.Size = new System.Drawing.Size(104, 19);
            this.label过期状态.TabIndex = 19;
            this.label过期状态.Text = "过期状态：";
            // 
            // label模糊查询
            // 
            this.label模糊查询.AutoSize = true;
            this.label模糊查询.Font = new System.Drawing.Font("宋体", 11F);
            this.label模糊查询.Location = new System.Drawing.Point(13, 114);
            this.label模糊查询.Name = "label模糊查询";
            this.label模糊查询.Size = new System.Drawing.Size(104, 19);
            this.label模糊查询.TabIndex = 21;
            this.label模糊查询.Text = "模糊查询：";
            // 
            // textBox模糊查询
            // 
            this.textBox模糊查询.Font = new System.Drawing.Font("宋体", 11F);
            this.textBox模糊查询.Location = new System.Drawing.Point(107, 109);
            this.textBox模糊查询.Name = "textBox模糊查询";
            this.textBox模糊查询.Size = new System.Drawing.Size(230, 28);
            this.textBox模糊查询.TabIndex = 22;
            this.textBox模糊查询.TextChanged += new System.EventHandler(this.FuzzyQuery);
            // 
            // slFlatButton导入
            // 
            this.slFlatButton导入.FlatAppearance.BorderSize = 0;
            this.slFlatButton导入.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.slFlatButton导入.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.slFlatButton导入.GetFocusControl = null;
            this.slFlatButton导入.Location = new System.Drawing.Point(233, 7);
            this.slFlatButton导入.Name = "slFlatButton导入";
            this.slFlatButton导入.Size = new System.Drawing.Size(80, 35);
            this.slFlatButton导入.TabIndex = 7;
            this.slFlatButton导入.Text = "✅️ 导出";
            this.slFlatButton导入.UseVisualStyleBackColor = true;
            this.slFlatButton导入.Click += new System.EventHandler(this.slFlatButton导入_Click);
            // 
            // button查看详细
            // 
            this.button查看详细.BackColor = System.Drawing.Color.RoyalBlue;
            this.button查看详细.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button查看详细.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.button查看详细.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button查看详细.ForeColor = System.Drawing.Color.White;
            this.button查看详细.Location = new System.Drawing.Point(499, 19);
            this.button查看详细.Name = "button查看详细";
            this.button查看详细.Size = new System.Drawing.Size(100, 29);
            this.button查看详细.TabIndex = 34;
            this.button查看详细.Text = "查看详细";
            this.button查看详细.UseVisualStyleBackColor = false;
            this.button查看详细.Click += new System.EventHandler(this.button查看详细_Click);
            // 
            // label位置简称
            // 
            this.label位置简称.AutoSize = true;
            this.label位置简称.Font = new System.Drawing.Font("宋体", 11F);
            this.label位置简称.Location = new System.Drawing.Point(315, 15);
            this.label位置简称.Name = "label位置简称";
            this.label位置简称.Size = new System.Drawing.Size(104, 19);
            this.label位置简称.TabIndex = 25;
            this.label位置简称.Text = "位置简称：";
            // 
            // textBox位置简称
            // 
            this.textBox位置简称.Font = new System.Drawing.Font("宋体", 11F);
            this.textBox位置简称.Location = new System.Drawing.Point(410, 10);
            this.textBox位置简称.Name = "textBox位置简称";
            this.textBox位置简称.Size = new System.Drawing.Size(213, 28);
            this.textBox位置简称.TabIndex = 26;
            // 
            // label计划执行日期
            // 
            this.label计划执行日期.AutoSize = true;
            this.label计划执行日期.Font = new System.Drawing.Font("宋体", 11F);
            this.label计划执行日期.Location = new System.Drawing.Point(651, 15);
            this.label计划执行日期.Name = "label计划执行日期";
            this.label计划执行日期.Size = new System.Drawing.Size(142, 19);
            this.label计划执行日期.TabIndex = 27;
            this.label计划执行日期.Text = "计划执行日期：";
            // 
            // dateTimePicker计划执行日期开始日期
            // 
            this.dateTimePicker计划执行日期开始日期.CalendarFont = new System.Drawing.Font("宋体", 11F);
            this.dateTimePicker计划执行日期开始日期.CustomFormat = "yyyy-MM-dd";
            this.dateTimePicker计划执行日期开始日期.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePicker计划执行日期开始日期.Location = new System.Drawing.Point(787, 12);
            this.dateTimePicker计划执行日期开始日期.Name = "dateTimePicker计划执行日期开始日期";
            this.dateTimePicker计划执行日期开始日期.Size = new System.Drawing.Size(159, 25);
            this.dateTimePicker计划执行日期开始日期.TabIndex = 28;
            this.dateTimePicker计划执行日期开始日期.ValueChanged += new System.EventHandler(this.VerifyPlanExecuteDate);
            // 
            // label计划执行日期连接符
            // 
            this.label计划执行日期连接符.AutoSize = true;
            this.label计划执行日期连接符.Font = new System.Drawing.Font("宋体", 14F);
            this.label计划执行日期连接符.Location = new System.Drawing.Point(950, 13);
            this.label计划执行日期连接符.Name = "label计划执行日期连接符";
            this.label计划执行日期连接符.Size = new System.Drawing.Size(22, 24);
            this.label计划执行日期连接符.TabIndex = 29;
            this.label计划执行日期连接符.Text = "-";
            // 
            // dateTimePicker计划执行日期结束日期
            // 
            this.dateTimePicker计划执行日期结束日期.CalendarFont = new System.Drawing.Font("宋体", 11F);
            this.dateTimePicker计划执行日期结束日期.CustomFormat = "yyyy-MM-dd";
            this.dateTimePicker计划执行日期结束日期.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePicker计划执行日期结束日期.Location = new System.Drawing.Point(973, 12);
            this.dateTimePicker计划执行日期结束日期.Name = "dateTimePicker计划执行日期结束日期";
            this.dateTimePicker计划执行日期结束日期.Size = new System.Drawing.Size(159, 25);
            this.dateTimePicker计划执行日期结束日期.TabIndex = 30;
            this.dateTimePicker计划执行日期结束日期.ValueChanged += new System.EventHandler(this.VerifyPlanExecuteDate);
            // 
            // dateTimePicker巡检开始时间结束时间
            // 
            this.dateTimePicker巡检开始时间结束时间.CalendarFont = new System.Drawing.Font("宋体", 11F);
            this.dateTimePicker巡检开始时间结束时间.CustomFormat = "yyyy-MM-dd HH:mm:ss";
            this.dateTimePicker巡检开始时间结束时间.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePicker巡检开始时间结束时间.Location = new System.Drawing.Point(371, 77);
            this.dateTimePicker巡检开始时间结束时间.Name = "dateTimePicker巡检开始时间结束时间";
            this.dateTimePicker巡检开始时间结束时间.Size = new System.Drawing.Size(200, 25);
            this.dateTimePicker巡检开始时间结束时间.TabIndex = 34;
            this.dateTimePicker巡检开始时间结束时间.ValueChanged += new System.EventHandler(this.VerifyInspectStartTime);
            // 
            // label巡检开始时间连接符
            // 
            this.label巡检开始时间连接符.AutoSize = true;
            this.label巡检开始时间连接符.Font = new System.Drawing.Font("宋体", 14F);
            this.label巡检开始时间连接符.Location = new System.Drawing.Point(348, 78);
            this.label巡检开始时间连接符.Name = "label巡检开始时间连接符";
            this.label巡检开始时间连接符.Size = new System.Drawing.Size(22, 24);
            this.label巡检开始时间连接符.TabIndex = 33;
            this.label巡检开始时间连接符.Text = "-";
            // 
            // dateTimePicker巡检开始时间起始时间
            // 
            this.dateTimePicker巡检开始时间起始时间.CalendarFont = new System.Drawing.Font("宋体", 11F);
            this.dateTimePicker巡检开始时间起始时间.CustomFormat = "yyyy-MM-dd HH:mm:ss";
            this.dateTimePicker巡检开始时间起始时间.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePicker巡检开始时间起始时间.Location = new System.Drawing.Point(146, 77);
            this.dateTimePicker巡检开始时间起始时间.Name = "dateTimePicker巡检开始时间起始时间";
            this.dateTimePicker巡检开始时间起始时间.Size = new System.Drawing.Size(200, 25);
            this.dateTimePicker巡检开始时间起始时间.TabIndex = 32;
            this.dateTimePicker巡检开始时间起始时间.ValueChanged += new System.EventHandler(this.VerifyInspectStartTime);
            // 
            // label巡检开始时间
            // 
            this.label巡检开始时间.AutoSize = true;
            this.label巡检开始时间.Font = new System.Drawing.Font("宋体", 11F);
            this.label巡检开始时间.Location = new System.Drawing.Point(13, 80);
            this.label巡检开始时间.Name = "label巡检开始时间";
            this.label巡检开始时间.Size = new System.Drawing.Size(142, 19);
            this.label巡检开始时间.TabIndex = 31;
            this.label巡检开始时间.Text = "巡检开始时间：";
            // 
            // label创建时间
            // 
            this.label创建时间.AutoSize = true;
            this.label创建时间.Font = new System.Drawing.Font("宋体", 11F);
            this.label创建时间.Location = new System.Drawing.Point(605, 80);
            this.label创建时间.Name = "label创建时间";
            this.label创建时间.Size = new System.Drawing.Size(104, 19);
            this.label创建时间.TabIndex = 35;
            this.label创建时间.Text = "创建时间：";
            // 
            // dateTimePicker创建时间结束时间
            // 
            this.dateTimePicker创建时间结束时间.CalendarFont = new System.Drawing.Font("宋体", 11F);
            this.dateTimePicker创建时间结束时间.CustomFormat = "yyyy-MM-dd HH:mm:ss";
            this.dateTimePicker创建时间结束时间.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePicker创建时间结束时间.Location = new System.Drawing.Point(925, 77);
            this.dateTimePicker创建时间结束时间.Name = "dateTimePicker创建时间结束时间";
            this.dateTimePicker创建时间结束时间.Size = new System.Drawing.Size(200, 25);
            this.dateTimePicker创建时间结束时间.TabIndex = 38;
            this.dateTimePicker创建时间结束时间.ValueChanged += new System.EventHandler(this.VerifyCreateTime);
            // 
            // label创建时间连接符
            // 
            this.label创建时间连接符.AutoSize = true;
            this.label创建时间连接符.Font = new System.Drawing.Font("宋体", 14F);
            this.label创建时间连接符.Location = new System.Drawing.Point(902, 77);
            this.label创建时间连接符.Name = "label创建时间连接符";
            this.label创建时间连接符.Size = new System.Drawing.Size(22, 24);
            this.label创建时间连接符.TabIndex = 37;
            this.label创建时间连接符.Text = "-";
            // 
            // dateTimePicker创建时间起始时间
            // 
            this.dateTimePicker创建时间起始时间.CalendarFont = new System.Drawing.Font("宋体", 11F);
            this.dateTimePicker创建时间起始时间.CustomFormat = "yyyy-MM-dd HH:mm:ss";
            this.dateTimePicker创建时间起始时间.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePicker创建时间起始时间.Location = new System.Drawing.Point(700, 77);
            this.dateTimePicker创建时间起始时间.Name = "dateTimePicker创建时间起始时间";
            this.dateTimePicker创建时间起始时间.Size = new System.Drawing.Size(200, 25);
            this.dateTimePicker创建时间起始时间.TabIndex = 36;
            this.dateTimePicker创建时间起始时间.ValueChanged += new System.EventHandler(this.VerifyCreateTime);
            // 
            // comboBox巡检人员
            // 
            this.comboBox巡检人员.Font = new System.Drawing.Font("宋体", 11F);
            this.comboBox巡检人员.FormattingEnabled = true;
            this.comboBox巡检人员.Location = new System.Drawing.Point(618, 44);
            this.comboBox巡检人员.Name = "comboBox巡检人员";
            this.comboBox巡检人员.Size = new System.Drawing.Size(216, 26);
            this.comboBox巡检人员.TabIndex = 40;
            this.comboBox巡检人员.MouseDown += new System.Windows.Forms.MouseEventHandler(this.comboBox巡检人员_MouseDown);
            // 
            // label巡检人员
            // 
            this.label巡检人员.AutoSize = true;
            this.label巡检人员.Font = new System.Drawing.Font("宋体", 11F);
            this.label巡检人员.Location = new System.Drawing.Point(519, 48);
            this.label巡检人员.Name = "label巡检人员";
            this.label巡检人员.Size = new System.Drawing.Size(104, 19);
            this.label巡检人员.TabIndex = 39;
            this.label巡检人员.Text = "巡检人员：";
            // 
            // label所属组织
            // 
            this.label所属组织.AutoSize = true;
            this.label所属组织.Font = new System.Drawing.Font("宋体", 11F);
            this.label所属组织.Location = new System.Drawing.Point(13, 15);
            this.label所属组织.Name = "label所属组织";
            this.label所属组织.Size = new System.Drawing.Size(104, 19);
            this.label所属组织.TabIndex = 23;
            this.label所属组织.Text = "所属组织：";
            // 
            // comboBox所属组织
            // 
            this.comboBox所属组织.Font = new System.Drawing.Font("宋体", 11F);
            this.comboBox所属组织.FormattingEnabled = true;
            this.comboBox所属组织.Location = new System.Drawing.Point(112, 12);
            this.comboBox所属组织.Name = "comboBox所属组织";
            this.comboBox所属组织.Size = new System.Drawing.Size(178, 26);
            this.comboBox所属组织.TabIndex = 24;
            this.comboBox所属组织.MouseDown += new System.Windows.Forms.MouseEventHandler(this.comboBox所属组织_MouseDown);
            // 
            // ctn巡检任务
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1692, 688);
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
            this.Name = "ctn巡检任务";
            this.TableName = "巡检任务";
            this.Text = "巡检任务";
            this.After操作 += new SLQLControls.控件.控件公用类.SlkEditGridEventHandle.AfterEventHandler(this.ctn巡检任务_After操作);
            this.AfterChangeDataSource += new SLQLControls.模板.temp标准报表GridControl.AfterChangeDataSourceEventHandle(this.ctn巡检任务_AfterChangeDataSource);
            this.BeforeChangeDataSource += new SLQLControls.公用类.SlcQLPublic.BoolEventHandle(this.ctn巡检任务_BeforeChangeDataSource);
            this.Load += new System.EventHandler(this.ctn巡检任务_Load);
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

        private System.Windows.Forms.Label label执行状态;
        private System.Windows.Forms.ComboBox comboBox执行状态;
        private System.Windows.Forms.ComboBox comboBox过期状态;
        private System.Windows.Forms.Label label过期状态;
        private System.Windows.Forms.Label label模糊查询;
        private System.Windows.Forms.TextBox textBox模糊查询;
        private SLQLControls.控件.SLFlatButton slFlatButton导入;
        private System.Windows.Forms.Button button查看详细;
        private System.Windows.Forms.Label label位置简称;
        private System.Windows.Forms.TextBox textBox位置简称;
        private System.Windows.Forms.Label label计划执行日期;
        private System.Windows.Forms.DateTimePicker dateTimePicker计划执行日期开始日期;
        private System.Windows.Forms.DateTimePicker dateTimePicker巡检开始时间结束时间;
        private System.Windows.Forms.Label label巡检开始时间连接符;
        private System.Windows.Forms.DateTimePicker dateTimePicker巡检开始时间起始时间;
        private System.Windows.Forms.Label label巡检开始时间;
        private System.Windows.Forms.DateTimePicker dateTimePicker计划执行日期结束日期;
        private System.Windows.Forms.Label label计划执行日期连接符;
        private System.Windows.Forms.Label label创建时间;
        private System.Windows.Forms.DateTimePicker dateTimePicker创建时间结束时间;
        private System.Windows.Forms.Label label创建时间连接符;
        private System.Windows.Forms.DateTimePicker dateTimePicker创建时间起始时间;
        private System.Windows.Forms.ComboBox comboBox巡检人员;
        private System.Windows.Forms.Label label巡检人员;
        private System.Windows.Forms.ComboBox comboBox所属组织;
        private System.Windows.Forms.Label label所属组织;
    }
}