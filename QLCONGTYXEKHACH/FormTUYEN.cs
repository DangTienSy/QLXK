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
    public partial class FormTUYEN : Form
    {
        DataAccess DataAccess = new DataAccess();
        public FormTUYEN()
        {
            InitializeComponent();
        }

        private void FormTUYEN_Load(object sender, EventArgs e)
        {
            LoadDataGridView(); LoadComboBox();
            huy();
        }

        private void LoadDataGridView()
        {
            dgv.DataSource = DataAccess.GetDataTable("SELECT MATUYEN,TUYEN,QUANGDUONG,TGDUKIEN FROM TUYEN_BENXE order by BENDAU");
        }
        private void LoadComboBox()
        {
            cboBENCUOI.Items.Clear();
            cboBENDAU.Items.Clear();
            DataTable dataTable = DataAccess.GetDataTable("select TENBENXE from BENXE");
            foreach (DataRow dataRow in dataTable.Rows)
            {
                cboBENCUOI.Items.Add(dataRow[0].ToString());
                cboBENDAU.Items.Add(dataRow[0].ToString());
            }
        }
        private void btnthoat_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Thoát", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                this.Close();
        }

        private void huy()
        {
            numQUANDUONG.Value = 0; numGIO.Value = 0; numPHUT.Value = 0;
            cboBENCUOI.SelectedIndex = -1; cboBENDAU.SelectedIndex = -1;
            btnthem.Visible = btnluu.Visible = btnhuy.Visible = false;
            btnnhapmoi.Visible = btnsua.Visible = btnxoa.Visible = true;
            panelnhap.Enabled = false;
            dgv.Enabled = true;
        }
        private void btnnhapmoi_Click(object sender, EventArgs e)
        {
            btnthem.Visible = btnhuy.Visible = true;
            btnsua.Visible = btnxoa.Visible = btnnhapmoi.Visible = false;
            numQUANDUONG.Value = 0; numGIO.Value = 0; numPHUT.Value = 0;
            cboBENCUOI.SelectedIndex = -1; cboBENDAU.SelectedIndex = -1; panelnhap.Enabled = true;
        }



        private void btnthem_Click(object sender, EventArgs e)
        {
            if (!DataAccess.Connect())
            {
                MessageBox.Show("Thoát?", "Không thể kết nối", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }
            
            string tg =((int)numGIO.Value*60+ (int)numPHUT.Value).ToString(); if (tg == "0") tg = "NULL";
            string qd = ((int)numQUANDUONG.Value).ToString(); if (qd == "0") qd = "NULL";

            string bd = cboBENDAU.Text;bd = String.Format("N'{0}'", bd);
            string bc = cboBENCUOI.Text; bc = String.Format("N'{0}'", bc);


            string cmd = String.Format("declare @bd int = (select mabenxe from benxe where tenbenxe= {0})\n", bd);
            cmd+= String.Format("declare @bc int = (select mabenxe from benxe where tenbenxe= {0})\n", bc);
            cmd += String.Format("insert into TUYEN(bendau, bencuoi, quangduong, thoigiandukien) values (@bd,@bc,{0},{1})",qd,tg);
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
                        string cmd = String.Format("delete from tuyen WHERE MATUYEN={0}", ma);
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
                        string[] ben = dgv.Rows[i].Cells[1].Value.ToString().Split(new string[] {" - "},StringSplitOptions.RemoveEmptyEntries);
                        string bendau = ben[0]; string bencuoi =ben[1];
                        cboBENDAU.SelectedIndex = cboBENDAU.FindString(bendau);
                        cboBENCUOI.SelectedIndex = cboBENDAU.FindString(bencuoi);
                        string qd=dgv.Rows[i].Cells[2].Value.ToString();
                        if (String.IsNullOrEmpty(qd)) numQUANDUONG.Value = 0;
                        else numQUANDUONG.Value= decimal.Parse(qd);
                        string time= dgv.Rows[i].Cells[3].Value.ToString();
                        if (String.IsNullOrEmpty(time)) numGIO.Value = numPHUT.Value = 0;
                        else 
                        {
                            string[] tg = time.Split(new string[] { " GIỜ ", " PHÚT" }, StringSplitOptions.RemoveEmptyEntries);
                            numGIO.Value = decimal.Parse(tg[0]);
                            numPHUT.Value = decimal.Parse(tg[1]);
                        } 

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

                    string tg = ((int)numGIO.Value * 60 + (int)numPHUT.Value).ToString(); if (tg == "0") tg = "NULL";
                    string qd = ((int)numQUANDUONG.Value).ToString(); if (qd == "0") qd = "NULL";

                    string bd = cboBENDAU.Text; bd = String.Format("N'{0}'", bd);
                    string bc = cboBENCUOI.Text; bc = String.Format("N'{0}'", bc);


                    string cmd = String.Format("declare @bd int = (select mabenxe from benxe where tenbenxe= {0})\n", bd);
                    cmd += String.Format("declare @bc int = (select mabenxe from benxe where tenbenxe= {0})\n", bc);
                    cmd += String.Format("update TUYEN set bendau=@bd,bencuoi=@bc, quangduong={0}, thoigiandukien={1} WHERE MATUYEN={2}", qd, tg, ma);
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
                        string[] ben = dgv.Rows[i].Cells[1].Value.ToString().Split(new string[] { " - " }, StringSplitOptions.RemoveEmptyEntries);
                        string bendau = ben[0]; string bencuoi = ben[1];
                        cboBENDAU.SelectedIndex = cboBENDAU.FindString(bendau);
                        cboBENCUOI.SelectedIndex = cboBENDAU.FindString(bencuoi);
                        string qd = dgv.Rows[i].Cells[2].Value.ToString();
                        if (String.IsNullOrEmpty(qd)) numQUANDUONG.Value = 0;
                        else numQUANDUONG.Value = decimal.Parse(qd);
                        string time = dgv.Rows[i].Cells[3].Value.ToString();
                        if (String.IsNullOrEmpty(time)) numGIO.Value = numPHUT.Value = 0;
                        else
                        {
                            string[] tg = time.Split(new string[] { " GIỜ ", " PHÚT" }, StringSplitOptions.RemoveEmptyEntries);
                            numGIO.Value = decimal.Parse(tg[0]);
                            numPHUT.Value = decimal.Parse(tg[1]);
                        }
                    }
                    catch (Exception m)
                    {
                        MessageBox.Show(m.Message);
                    }

                }
        }

        private void btnBENXE_Click(object sender, EventArgs e)
        {
            FormBENXE fbx= new FormBENXE();
            fbx.ShowDialog();
        }
    }
}
