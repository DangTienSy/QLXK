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
    public partial class FormCHUCVU : Form
    {
        DataAccess DataAccess = new DataAccess();
        public FormCHUCVU()
        {
            InitializeComponent();
        }

        private void FormCHUCVU_Load(object sender, EventArgs e)
        {
            LoadDataGridView();
            huy();        
        }

        private void LoadDataGridView()
        {
            dgv.DataSource = DataAccess.GetDataTable("select * from CHUCVU order by MACHUCVU");
        }
        private void btnthoat_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Thoát", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                this.Close();
            
        }

        private void huy()
        {
            txttenloai.Text = "";
            btnthem.Visible =btnluu.Visible= btnhuy.Visible= false;
            btnnhapmoi.Visible=btnsua.Visible= btnxoa.Visible= true;
            panelnhap.Enabled = false;
            dgv.Enabled = true;
        }
        private void btnnhapmoi_Click(object sender, EventArgs e)
        {
            btnthem.Visible = btnhuy.Visible = true;
            btnsua.Visible = btnxoa.Visible=btnnhapmoi.Visible = false;
            txttenloai.Text = "";
            panelnhap.Enabled = true;
            txttenloai.Focus();
        }



        private void btnthem_Click(object sender, EventArgs e)
        {
            if (!DataAccess.Connect())
            {
                MessageBox.Show("Thoát?", "Không thể kết nối", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }
            string t = txttenloai.Text.ToUpper();
            if (t == "") t = "NULL"; else t = String.Format("N'{0}'", t);
            string cmd = String.Format("insert into CHUCVU(tenCHUCVU) values ({0})", t);
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
                    string cmd = String.Format("delete from CHUCVU WHERE MACHUCVU={0}", ma);
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
                        txttenloai.Text = dgv.Rows[i].Cells[1].Value.ToString();
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
                    string t = txttenloai.Text.ToUpper();
                    if (t == "") t = "NULL"; else t = String.Format("N'{0}'", t);

                    string cmd = String.Format("update CHUCVU set TENCHUCVU={0} WHERE MACHUCVU={1}", t, ma);
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
                dgv.Rows[i].Selected=true;
                
            }
            dgv.Enabled = false;
            panelnhap.Enabled = true;
            txttenloai.Focus();
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
                        txttenloai.Text = dgv.Rows[i].Cells[1].Value.ToString();
                    }
                    catch (Exception m)
                    {
                        MessageBox.Show(m.Message);
                    }

                }
        }
    }
}
