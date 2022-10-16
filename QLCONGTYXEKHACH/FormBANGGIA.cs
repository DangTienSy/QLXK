using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace QLCONGTYXEKHACH
{
    public partial class FormBANGGIA : Form
    {
        DataAccess DataAccess = new DataAccess();
        public FormBANGGIA()
        {
            InitializeComponent();
        }

        private void FormBANGGIA_Load(object sender, EventArgs e)
        {
            LoadDataGridView(); LoadComboBox();
            huy();
        }

        private void LoadDataGridView()
        {
            dgv.DataSource = DataAccess.GetDataTable("SELECT TUYEN,TENLOAIVE,SOTIEN FROM BANGGIA_TUYEN_LOAIVE");
        }
        private void LoadComboBox()
        {
            cboLOAIVE.Items.Clear();
            DataTable dataTable = DataAccess.GetDataTable("select TENLOAIVE from LOAIVE");
            foreach (DataRow dataRow in dataTable.Rows)
            {
                cboLOAIVE.Items.Add(dataRow[0].ToString());
            }
            cboTUYEN.Items.Clear();
            DataTable dataTable1 = DataAccess.GetDataTable("select TUYEN from TUYEN_BENXE");
            foreach (DataRow dataRow in dataTable1.Rows)
            {
                cboTUYEN.Items.Add(dataRow[0].ToString());
            }
        }
        private void btnthoat_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Thoát", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                this.Close();
        }

        private void huy()
        {
            numGIA.Value = 0; 
            cboLOAIVE.Text=""; cboTUYEN.Text = "";
            btnthem.Visible = btnluu.Visible = btnhuy.Visible = false;
            btnnhapmoi.Visible = btnsua.Visible = btnxoa.Visible = true;
            panelnhap.Enabled = false;
            dgv.Enabled = true;
        }
        private void btnnhapmoi_Click(object sender, EventArgs e)
        {
            btnthem.Visible = btnhuy.Visible = true;
            btnsua.Visible = btnxoa.Visible = btnnhapmoi.Visible = false;
            numGIA.Value = 0; cboLOAIVE.Text = ""; cboTUYEN.Text = "";
            panelnhap.Enabled = true;
        }



        private void btnthem_Click(object sender, EventArgs e)
        {
            if (!DataAccess.Connect())
            {
                MessageBox.Show("Thoát?", "Không thể kết nối", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }

            string GIA = ((int)numGIA.Value).ToString(); if (GIA == "0") GIA = "NULL";

            string T = cboTUYEN.Text; T = String.Format("N'{0}'", T);
            string LV = cboLOAIVE.Text; LV = String.Format("N'{0}'", LV);


            string cmd = String.Format("declare @T int = (select maTUYEN from TUYEN_BENXE where TUYEN= {0})\n", T);
            cmd += String.Format("declare @LV int = (select maLOAIVE from LOAIVE where tenLOAIVE= {0})\n", LV);
            cmd += String.Format("insert into BANGGIA values (@T,@LV,{0})", GIA);
            if (DataAccess.Execute(cmd))
            {
                LoadDataGridView();
                huy();
            }

        }

        private void btnxoa_Click(object sender, EventArgs e)
        {
            if (!DataAccess.Connect())
            {
                MessageBox.Show("Thoát?", "Không thể kết nối", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }
            if (dgv.SelectedCells.Count == 0)
            {
                MessageBox.Show("Hãy chọn 1 dòng để xóa");
                return;
            }
            foreach (DataGridViewCell cell in dgv.SelectedCells)
                if (cell.Selected)
                {
                    try
                    {
                        int i = cell.RowIndex;
                        string T = dgv.Rows[i].Cells[0].Value.ToString(); T = String.Format("N'{0}'", T);
                        string LV = dgv.Rows[i].Cells[1].Value.ToString(); LV = String.Format("N'{0}'", LV);
                        string cmd = String.Format("declare @T int = (select maTUYEN from TUYEN_BENXE where TUYEN= {0})\n", T);
                        cmd += String.Format("declare @LV int = (select maLOAIVE from LOAIVE where tenLOAIVE= {0})\n", LV);
                        cmd += String.Format("delete from BANGGIA WHERE MATUYEN=@T AND MALOAIVE=@LV");
                        DataAccess.Execute(cmd);
                    }
                    catch (Exception m)
                    {
                        MessageBox.Show(m.Message);
                    }

                }

            LoadDataGridView();
            huy();
        }

        private void btnhuy_Click(object sender, EventArgs e)
        {
            huy();
        }

        private void dgv_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgv.SelectedCells.Count > 0) if (dgv.SelectedCells[0].Selected)
                {
                    int i = dgv.SelectedCells[0].RowIndex;
                    try
                    {
                        cboTUYEN.Text = dgv.Rows[i].Cells[0].Value.ToString();
                        cboLOAIVE.Text = dgv.Rows[i].Cells[1].Value.ToString();
                        string qd = dgv.Rows[i].Cells[2].Value.ToString();
                        numGIA.Value = decimal.Parse(qd);
                        

                    }
                    catch (Exception m)
                    {
                        MessageBox.Show(m.Message);
                    }

                }
        }

        private void btnluu_Click(object sender, EventArgs e)
        {
            if (!DataAccess.Connect())
            {
                MessageBox.Show("Thoát?", "Không thể kết nối", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }
            if (dgv.SelectedRows.Count != 1)
            {
                MessageBox.Show("Hãy chọn 1 dòng để sửa");
                return;
            }
            if (dgv.SelectedCells[0].Selected)
            {
                try
                {

                    int i = dgv.SelectedCells[0].RowIndex;

                    string T = dgv.Rows[i].Cells[0].Value.ToString(); T = String.Format("N'{0}'", T);
                    string LV = dgv.Rows[i].Cells[1].Value.ToString(); LV = String.Format("N'{0}'", LV);

                    string GIA = ((int)numGIA.Value).ToString(); if (GIA == "0") GIA = "NULL";

                    string T2 = cboTUYEN.Text; T2 = String.Format("N'{0}'", T2);
                    string LV2 = cboLOAIVE.Text; LV2 = String.Format("N'{0}'", LV2);

                    string cmd = String.Format("declare @T int = (select maTUYEN from TUYEN_BENXE where TUYEN= {0})\n", T);
                    cmd += String.Format("declare @LV int = (select maLOAIVE from LOAIVE where tenLOAIVE= {0})\n", LV);
                    cmd+= String.Format("declare @T2 int = (select maTUYEN from TUYEN_BENXE where TUYEN= {0})\n", T2);
                    cmd += String.Format("declare @LV2 int = (select maLOAIVE from LOAIVE where tenLOAIVE= {0})\n", LV2);
                    cmd += String.Format("UPDATE BANGGIA SET MATUYEN=@T2,MALOAIVE=@LV2,SOTIEN={0} WHERE MATUYEN=@T AND MALOAIVE=@LV", GIA);

                    if (DataAccess.Execute(cmd))
                    {
                        LoadDataGridView();
                        huy();
                    }
                }
                catch (Exception m)
                {
                    MessageBox.Show(m.Message);
                }
            }
        }

        private void btnsua_Click(object sender, EventArgs e)
        {
            if (dgv.SelectedCells.Count == 0)
            {
                MessageBox.Show("Hãy chọn 1 dòng để sửa");
                return;
            }
            if (dgv.SelectedCells[0].Selected)
            {
                DataGridViewCell cell = dgv.SelectedCells[0];
                int i = cell.RowIndex;
                foreach (DataGridViewRow r in dgv.Rows) r.Selected = false;
                dgv.Rows[i].Selected = true;

            }
            dgv.Enabled = false;
            panelnhap.Enabled = true;
            btnluu.Visible = btnhuy.Visible = true;
            btnthem.Visible = btnxoa.Visible = btnnhapmoi.Visible = btnsua.Visible = false;

        }

        private void dgv_SelectionChanged(object sender, EventArgs e)
        {
            if (dgv.SelectedCells.Count > 0) if (dgv.SelectedCells[0].Selected)
                {
                    int i = dgv.SelectedCells[0].RowIndex;
                    try
                    {
                        cboTUYEN.Text = dgv.Rows[i].Cells[0].Value.ToString();
                        cboLOAIVE.Text = dgv.Rows[i].Cells[1].Value.ToString();
                        string qd = dgv.Rows[i].Cells[2].Value.ToString();
                        numGIA.Value = decimal.Parse(qd);
                    }
                    catch (Exception m)
                    {
                        MessageBox.Show(m.Message);
                    }

                }
        }

        private void btnBENXE_Click(object sender, EventArgs e)
        {
            FormTUYEN fbx = new FormTUYEN();
            fbx.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FormLOAIVE F= new FormLOAIVE(); F.ShowDialog();
        }
    }
}
