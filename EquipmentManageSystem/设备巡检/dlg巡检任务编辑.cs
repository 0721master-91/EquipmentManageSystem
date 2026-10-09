using EquipmentManageSystem.Global;
using EquipmentManageSystem.Utils;
using SLControls;
using SLControls.SLGlobal;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace EquipmentManageSystem.设备巡检
{
    public partial class dlg巡检任务编辑 : SLAomTmpForm
    {

        private string TaskCode; // 巡检任务编码
        public dlg巡检任务编辑()
        {
            InitializeComponent();
        }


        private void dlg巡检任务编辑_Load(object sender, EventArgs e)
        {
            if(this.OperFlag == SleOperFlag.New || this.OperFlag == SleOperFlag.CopyNew)
            {
                this.slTextBox巡检任务编码.Text = SqlCommonUtil.GenerateCode("XJRW", "巡检任务", "巡检任务编码");
                this.slTextBox单据类型.Text = "巡检任务";
                this.slTextBox单据来源.Text = "自建";
                this.slTextBox执行状态.Text = "待执行";
                this.slTextBox过期状态.Text = "未过期";
            }

            DataTable dt = new DataTable();
            dt.Columns.Add("是否故障",typeof(string));
            DataRow row = dt.NewRow();
            row["是否故障"] = "是";
            dt.Rows.Add(row);
            row = dt.NewRow();
            row["是否故障"] = "否";
            dt.Rows.Add(row);
            this.slComboBox是否故障.DataSource = dt;
            this.slComboBox是否故障.DisplayMember = "是否故障";
            this.slComboBox是否故障.ValueMember = "是否故障";
            this.slComboBox是否故障.Text = "否";
        }

        // 点击添加图片
        private void AddPictures(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            string panelName = "flowLayoutPanel" + btn.Name.Substring(8);
            Control[] found = btn.Parent.Controls.Find(panelName, true);

            FlowLayoutPanel panel = found[0] as FlowLayoutPanel;

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

        private void dlg巡检任务编辑_AfterFillControls()
        {
           this.TaskCode = this.slTextBox巡检任务编码.Text;
            
            if(this.OperFlag == SleOperFlag.Modify)
            {
                string positionCode = this.slTextBox功能位置编码.Text;
                if (string.IsNullOrEmpty(positionCode))
                    this.uc巡检任务标准.positionCode = positionCode;
            }
        }

        /// <summary>
        /// 点击选择设备功能位置
        /// </summary>
        private void OpenFunctionPositionDialog(object sender, EventArgs e)
        {
            using (dlg设备功能位置选择 dlg = new dlg设备功能位置选择())
            {
                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    this.slTextBox功能位置编码.Text = dlg.PositionCode;
                    this.textBox功能位置描述.Text = dlg.PositionDescription;
                    this.textBox位置简称.Text = dlg.PositionShortName;
                    this.textBox所属区域.Text = dlg.Area;
                    this.textBox设备管理部门.Text = dlg.Department;
                    this.textBox设备负责人.Text = dlg.ResponsiblePerson;
                }
                this.uc巡检任务标准.positionCode = dlg.PositionCode;
                this.ActiveControl = null;
            }
        }

        /// <summary>
        /// 点击选择成员
        /// </summary>
        private void OpenMemberSelectedDialog(object sender, EventArgs e)
        {
            using(dlg人员选择 dlg = new dlg人员选择("巡检人员选择") { IsMultiSelect = true })
            {
                if(dlg.ShowDialog() == DialogResult.OK)
                {
                    this.textBox巡检人员.Text = dlg.SelectedMemberNames;
                    this.textBox巡检人员.Tag = dlg.SelectedMemberIDs;
                }
                this.ActiveControl = null;
            }
        }
    }
}
