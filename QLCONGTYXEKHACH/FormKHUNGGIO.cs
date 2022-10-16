using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace QLCONGTYXEKHACH
{
    public partial class FormKHUNGGIO : Form
    {
        DataAccess DataAccess = new DataAccess();
        public FormKHUNGGIO()
        {
            InitializeComponent();
        }

        private void FormKHUNGGIO_Load(object sender, EventArgs e)
        {
            LoadDataGridView();
            huy();
        }

        private void LoadDataGridView()
        {
            dgv.DataSource = DataAccess.GetDataTable("select FORMAT(cast(gio as datetime),'hh:mm tt') as KHUNGGIO from KHUNGGIO order by gio");
        }
        private void btnthoat_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Thoát", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                this.Close();
        }

        private void huy()
        {
            numGIO.Value=1; numPHUT.Value=0; radAM.Checked = true;
            btnthem.Visible = btnluu.Visible = btnhuy.Visible = false;
            btnnhapmoi.Visible = btnsua.Visible = btnxoa.Visible = true;
            panelnhap.Enabled = false;
            dgv.Enabled = true;
        }
        private void btnnhapmoi_Click(object sender, EventArgs e)
        {
            btnthem.Visible = btnhuy.Visible = true;
            btnsua.Visible = btnxoa.Visible = btnnhapmoi.Visible = false;
            numGIO.Value = 1; numPHUT.Value = 0; radAM.Checked = true;
            panelnhap.Enabled = true;
           
        }



        private void btnthem_Click(object sender, EventArgs e)
        {
            if (!DataAccess.Connect())
            {
                MessageBox.Show("Thoát?", "Không thể kết nối", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }
            string h = numGIO.Value.ToString(); string m = numPHUT.Value.ToString();
            string t = (radAM.Checked) ? "AM" : "PM";
            string gio= String.Format("'{0}:{1}:00 {2}'",h,m,t);
            string cmd = String.Format("insert into KHUNGGIO(GIO) values ({0})", gio);
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
                        string ma = dgv.Rows[i].Cells[0].Value.ToString(); ma = "'" + ma + "'";

                        string cmd = String.Format("delete from KHUNGGIO WHERE GIO={0}", ma);
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
                        string[] part = dgv.Rows[i].Cells[0].Value.ToString().Split(new char[] { ':', ' ' }, System.StringSplitOptions.RemoveEmptyEntries);

                        numGIO.Value = decimal.Parse(part[0]);
                        numPHUT.Value = decimal.Parse(part[1]);
                        if (part[2] == "AM") radAM.Checked = true; else radPM.Checked = true;
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
                    string ma =dgv.Rows[i].Cells[0].Value.ToString();
                    ma = "'" + ma + "'";

                    string h = numGIO.Value.ToString(); string m = numPHUT.Value.ToString();
                    string t = (radAM.Checked) ? "AM" : "PM";
                    string gio = String.Format("'{0}:{1}:00 {2}'", h, m, t);
                    string cmd = String.Format("update KHUNGGIO set GIO={0} WHERE GIO={1}", gio, ma);
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
                        string[] part = dgv.Rows[i].Cells[0].Value.ToString().Split(new char[] { ':', ' ' }, System.StringSplitOptions.RemoveEmptyEntries);

                        numGIO.Value = decimal.Parse(part[0]);
                        numPHUT.Value = decimal.Parse(part[1]);
                        if (part[2] == "AM") radAM.Checked = true; else radPM.Checked = true;
                    }
                    catch (Exception m)
                    {
                        MessageBox.Show(m.Message);
                    }

                }
        }

        private void numGIO_ValueChanged(object sender, EventArgs e)
        {
            NumericUpDown n = sender as NumericUpDown;
            if (n.Value == n.Maximum) n.Value = n.Minimum+n.Increment;
            else if (n.Value == n.Minimum) n.Value = n.Maximum-n.Increment;
        }


    }
}
