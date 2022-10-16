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
    public partial class FormXE : Form
    {
        DataAccess DataAccess = new DataAccess();
        public FormXE()
        {
            InitializeComponent();
        }

        private void FormXE_Load(object sender, EventArgs e)
        {
            LoadDataGridView(); LoadComboBox();
            huy();
        }

        private void LoadDataGridView()
        {
            dgv.DataSource = DataAccess.GetDataTable("select MAXE, BIENSOXE,SOCHO, TENLOAIVE from XE X, LOAIVE L  where X.MALOAIVE=L.MALOAIVE order by L.MALOAIVE");
        }
        private void LoadComboBox()
        {
            cboLOAIVE.Items.Clear();
            DataTable dataTable = DataAccess.GetDataTable("select tenloaive from LOAIVE");
            foreach (DataRow dataRow in dataTable.Rows)
            {
                cboLOAIVE.Items.Add(dataRow[0].ToString());
            }
        }
        private void btnthoat_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Thoát", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                this.Close();
        }

        private void huy()
        {
            txtBIENSOXE.Text = ""; numSOCHO.Value = 1; cboLOAIVE.SelectedIndex = 0;
            btnthem.Visible = btnluu.Visible = btnhuy.Visible = false;
            btnnhapmoi.Visible = btnsua.Visible = btnxoa.Visible = true;
            panelnhap.Enabled = false;
            dgv.Enabled = true;
        }
        private void btnnhapmoi_Click(object sender, EventArgs e)
        {
            btnthem.Visible = btnhuy.Visible = true;
            btnsua.Visible = btnxoa.Visible = btnnhapmoi.Visible = false;
            txtBIENSOXE.Text = ""; numSOCHO.Value = 1; cboLOAIVE.SelectedIndex = 0;
            panelnhap.Enabled = true;
            txtBIENSOXE.Focus();
        }



        private void btnthem_Click(object sender, EventArgs e)
        {
            if (!DataAccess.Connect())
            {
                MessageBox.Show("Thoát?", "Không thể kết nối", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }
            string t = txtBIENSOXE.Text.ToUpper();
            if (t == "") t = "NULL"; else t = String.Format("N'{0}'", t);
            int socho = (int)numSOCHO.Value;
            string tenloaive= cboLOAIVE.Text; if (tenloaive == "") tenloaive = "NULL"; else tenloaive = String.Format("N'{0}'", tenloaive);

            string cmd = String.Format("declare @id int = (select maloaive from loaive where tenloaive= {0})\n" , tenloaive);
                cmd+=String.Format("insert into XE(biensoxe, socho, maloaive) values ({0},{1},@id)", t,socho);
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
                        int ma = int.Parse(dgv.Rows[i].Cells[0].Value.ToString());
                        string cmd = String.Format("delete from XE WHERE MAXE={0}", ma);
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
                        txtBIENSOXE.Text = dgv.Rows[i].Cells[1].Value.ToString();
                        numSOCHO.Value = decimal.Parse(dgv.Rows[i].Cells[2].Value.ToString());
                        cboLOAIVE.SelectedIndex = cboLOAIVE.FindString(dgv.Rows[i].Cells[3].Value.ToString());
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
                    int i = dgv.SelectedRows[0].Index;
                    int ma = int.Parse(dgv.Rows[i].Cells[0].Value.ToString());
                    
                    string t = txtBIENSOXE.Text.ToUpper();
                    if (t == "") t = "NULL"; else t = String.Format("N'{0}'", t);
                    int socho = (int)numSOCHO.Value;
                    string tenloaive = cboLOAIVE.Text; if (tenloaive == "") tenloaive = "NULL"; else tenloaive = String.Format("N'{0}'", tenloaive);

                    string cmd = String.Format("declare @id int = (select maloaive from loaive where tenloaive= {0})\n", tenloaive);
                    cmd +=String.Format("update XE set biensoXE={0},socho={1}, maloaive=@id WHERE MAXE={2}", t,socho, ma);
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
            txtBIENSOXE.Focus();
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
                        txtBIENSOXE.Text = dgv.Rows[i].Cells[1].Value.ToString();
                        numSOCHO.Value = decimal.Parse(dgv.Rows[i].Cells[2].Value.ToString());
                        cboLOAIVE.SelectedIndex = cboLOAIVE.FindString(dgv.Rows[i].Cells[3].Value.ToString());
                    }
                    catch (Exception m)
                    {
                        MessageBox.Show(m.Message);
                    }

                }
        }

        private void btnLOAIVE_Click(object sender, EventArgs e)
        {
            FormLOAIVE  f = new FormLOAIVE();
            f.ShowDialog();
        }

        private void cboLOAIVE_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboLOAIVE.Text == "GIƯỜNG NẰM") numSOCHO.Value = 36;
            else if (cboLOAIVE.Text == "PHÒNG") numSOCHO.Value = 24;
            else numSOCHO.Value = 45;
        }
    }
}
