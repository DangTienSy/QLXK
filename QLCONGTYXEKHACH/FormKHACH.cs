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
    public partial class FormKHACH : Form
    {
        DataAccess DataAccess = new DataAccess();
        public FormKHACH()
        {
            InitializeComponent();
        }

        private void FormKHACH_Load(object sender, EventArgs e)
        {
            LoadDataGridView();
            huy();
        }

        private void LoadDataGridView()
        {
            dgv.DataSource = DataAccess.GetDataTable("select * from KHACH order by MAKHACH");
        }
        private void btnthoat_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Thoát", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                this.Close();
        }

        private void huy()
        {
            txtDiaChi.Text = txtSDT.Text = txttenKHACH.Text = "";

            btnthem.Visible = btnluu.Visible = btnhuy.Visible = false;
            btnnhapmoi.Visible = btnsua.Visible = btnxoa.Visible = true;
            panelnhap.Enabled = false;
            dgv.Enabled = true;
        }
        private void btnnhapmoi_Click(object sender, EventArgs e)
        {
            btnthem.Visible = btnhuy.Visible = true;
            btnsua.Visible = btnxoa.Visible = btnnhapmoi.Visible = false;
            txtDiaChi.Text = txtSDT.Text = txttenKHACH.Text = "";
            panelnhap.Enabled = true;
            txttenKHACH.Focus();
        }



        private void btnthem_Click(object sender, EventArgs e)
        {
            if (!DataAccess.Connect())
            {
                MessageBox.Show("Thoát?", "Không thể kết nối", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }
            string t = txttenKHACH.Text.ToUpper();
            if (t == "") t = "NULL"; else t = String.Format("N'{0}'", t);
            string dc = txtDiaChi.Text.ToUpper();
            if (dc == "") dc = "NULL"; else dc = String.Format("N'{0}'", dc);
            string dt = txtSDT.Text.ToUpper();
            if (dt == "") dt = "NULL"; else dt = String.Format("N'{0}'", dt);
            string cmd = String.Format("insert into KHACH(HOTEN, diachi,DIENTHOAI) values ({0},{1},{2})", t, dc, dt);
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
                        string cmd = String.Format("delete from KHACH WHERE MAKHACH={0}", ma);
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
                        txttenKHACH.Text = dgv.Rows[i].Cells[1].Value.ToString();
                        txtDiaChi.Text = dgv.Rows[i].Cells[3].Value.ToString();
                        txtSDT.Text = dgv.Rows[i].Cells[2].Value.ToString();
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
                    string t = txttenKHACH.Text.ToUpper();
                    if (t == "") t = "NULL"; else t = String.Format("N'{0}'", t);
                    string dc = txtDiaChi.Text.ToUpper();
                    if (dc == "") dc = "NULL"; else dc = String.Format("N'{0}'", dc);
                    string dt = txtSDT.Text.ToUpper();
                    if (dt == "") dt = "NULL"; else dt = String.Format("N'{0}'", dt);

                    string cmd = String.Format("update KHACH set hoten={0},DIACHI={1},dienthoai={2} WHERE MAKHACH={3}", t, dc, dt, ma);
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
            txttenKHACH.Focus();
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
                        txttenKHACH.Text = dgv.Rows[i].Cells[1].Value.ToString();
                        txtDiaChi.Text = dgv.Rows[i].Cells[3].Value.ToString();
                        txtSDT.Text = dgv.Rows[i].Cells[2].Value.ToString();
                    }
                    catch (Exception m)
                    {
                        MessageBox.Show(m.Message);
                    }

                }
        }
    }
}
