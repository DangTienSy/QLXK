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
    public partial class FormNHANVIEN : Form
    {
        DataAccess DataAccess = new DataAccess();
        public int MaTaiXe { get; set; }
        public FormNHANVIEN()
        {
            InitializeComponent();
        }

        private void FormNHANVIEN_Load(object sender, EventArgs e)
        {
            LoadComboBox();
            LoadDataGridView();
            huy();
        }
        private void LoadComboBox()
        {
            cboCHUCVU.Items.Clear();
            DataTable dataTable = DataAccess.GetDataTable("select tenchucvu from chucvu");
            foreach (DataRow dataRow in dataTable.Rows)
            {
                cboCHUCVU.Items.Add(dataRow[0].ToString());
            }
        }
        private void LoadDataGridView()
        {
            dgv.DataSource = DataAccess.GetDataTable("select MANHANVIEN, HOTEN, TENCHUCVU, NGAYSINH, DIENTHOAI, DIACHI from NHANVIEN N, CHUCVU C WHERE N.MACHUCVU=C.MACHUCVU order by HOTEN");
        }
        private void btnthoat_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Thoát", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                this.Close();
        }

        private void huy()
        {
            txtDiaChi.Text = txtSDT.Text = txttenNHANVIEN.Text = "";
            cboCHUCVU.SelectedIndex = -1; dtpNS.Text = "1/1/2000";
            btnthem.Visible = btnluu.Visible = btnhuy.Visible = false;
            btnnhapmoi.Visible = btnsua.Visible = btnxoa.Visible = true;
            panelnhap.Enabled = false;
            dgv.Enabled = true;
        }
        private void btnnhapmoi_Click(object sender, EventArgs e)
        {
            btnthem.Visible = btnhuy.Visible = true;
            btnsua.Visible = btnxoa.Visible = btnnhapmoi.Visible = false;
            txtDiaChi.Text = txtSDT.Text = txttenNHANVIEN.Text = "";
            cboCHUCVU.SelectedIndex = -1; dtpNS.Text = "1/1/2000";
            panelnhap.Enabled = true;
            txttenNHANVIEN.Focus();
        }



        private void btnthem_Click(object sender, EventArgs e)
        {
            if (!DataAccess.Connect())
            {
                MessageBox.Show("Thoát?", "Không thể kết nối", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }
            string t = txttenNHANVIEN.Text.ToUpper();
            if (t == "") t = "NULL"; else t = String.Format("N'{0}'", t);
            string dc = txtDiaChi.Text.ToUpper();
            if (dc == "") dc = "NULL"; else dc = String.Format("N'{0}'", dc);
            string dt = txtSDT.Text.ToUpper();
            if (dt == "") dt = "NULL"; else dt = String.Format("N'{0}'", dt);
            string ns = dtpNS.Value.ToString("yyyy-MM-dd");

            ns = String.Format("'{0}'", ns);
            string chucvu = cboCHUCVU.Text;
            if (chucvu == "") chucvu = "NULL"; else chucvu = String.Format("N'{0}'", chucvu);
            string cmd = String.Format("declare @id int = (select machucvu from chucvu where tenchucvu= {0})\n", chucvu);
            cmd+= String.Format("insert into NHANVIEN(HOTEN, diachi,DIENTHOAI, ngaysinh , MACHUCVU) values ({0},{1},{2},{3},@id)", t, dc, dt,ns);
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
                        string cmd = String.Format("delete from NHANVIEN WHERE MANHANVIEN={0}", ma);
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
                        txttenNHANVIEN.Text = dgv.Rows[i].Cells[1].Value.ToString();
                        cboCHUCVU.SelectedIndex = cboCHUCVU.FindString(dgv.Rows[i].Cells[2].Value.ToString());
                        dtpNS.Text = dgv.Rows[i].Cells[3].Value.ToString();
                        txtDiaChi.Text = dgv.Rows[i].Cells[5].Value.ToString();
                        txtSDT.Text = dgv.Rows[i].Cells[4].Value.ToString();
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
                    string t = txttenNHANVIEN.Text.ToUpper();
                    if (t == "") t = "NULL"; else t = String.Format("N'{0}'", t);
                    string dc = txtDiaChi.Text.ToUpper();
                    if (dc == "") dc = "NULL"; else dc = String.Format("N'{0}'", dc);
                    string dt = txtSDT.Text.ToUpper();
                    if (dt == "") dt = "NULL"; else dt = String.Format("N'{0}'", dt);
                    string ns = dtpNS.Value.ToString("yyyy-MM-dd");
                    ns = String.Format("'{0}'", ns);
                    string chucvu = cboCHUCVU.Text;
                    if (chucvu == "") chucvu = "NULL"; else chucvu = String.Format("N'{0}'", chucvu);
                    string cmd = String.Format("declare @id int = (select machucvu from chucvu where tenchucvu= {0})\n", chucvu);
                    cmd += String.Format("update NHANVIEN set hoten={0},DIACHI={1},dienthoai={2},ngaysinh={3}, machucvu=@id WHERE MANHANVIEN={4}", t, dc, dt,ns, ma);
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
            txttenNHANVIEN.Focus();
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
                        txttenNHANVIEN.Text = dgv.Rows[i].Cells[1].Value.ToString();
                        cboCHUCVU.SelectedIndex = cboCHUCVU.FindString(dgv.Rows[i].Cells[2].Value.ToString());
                        dtpNS.Text = dgv.Rows[i].Cells[3].Value.ToString();
                        txtDiaChi.Text = dgv.Rows[i].Cells[5].Value.ToString();
                        txtSDT.Text = dgv.Rows[i].Cells[4].Value.ToString();
                    }
                    catch (Exception m)
                    {
                        MessageBox.Show(m.Message);
                    }

                }
        }

        private void BTNCHON_Click(object sender, EventArgs e)
        {
            if (dgv.SelectedCells.Count == 0)
            {
                MessageBox.Show("Hãy chọn 1 dòng để sửa");
                return;
            }
            if (dgv.SelectedCells[0].Selected)
            {
                int i = dgv.SelectedCells[0].RowIndex;
                try
                {
                    if(!dgv.Rows[i].Cells[2].Value.ToString().Equals("TÀI XẾ")){
                        MessageBox.Show("Phải chọn tài xế");
                        return;
                    }
                    MaTaiXe = int.Parse(dgv.Rows[i].Cells[0].Value.ToString());
                    this.Close();
                }
                catch (Exception m)
                {
                    MessageBox.Show(m.Message);
                }

            }
        }

        private void btnCHUCVU_Click(object sender, EventArgs e)
        {
            FormCHUCVU f = new FormCHUCVU();
            f.ShowDialog();
        }
    }
}
