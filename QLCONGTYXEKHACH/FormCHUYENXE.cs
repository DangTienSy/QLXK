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
    public partial class FormCHUYENXE : Form
    {
        DataAccess DataAccess = new DataAccess();
        public FormCHUYENXE()
        {
            InitializeComponent();
        }

        private void FormCHUYENXE_Load(object sender, EventArgs e)
        {
            LoadComboBox();LoadComboXE();
            LoadDataGridView();
            huy();
        }
        private void LoadComboBox()
        {
            cboLOAIVE.Items.Clear();
            DataTable dataTable = DataAccess.GetDataTable("select tenLOAIVE from LOAIVE");
            foreach (DataRow dataRow in dataTable.Rows)
            {
                cboLOAIVE.Items.Add(dataRow[0].ToString());
            }
            ///////////
            cboGIO.Items.Clear();
            DataTable dataTable1 = DataAccess.GetDataTable("select gio from khunggio");
            foreach (DataRow dataRow in dataTable1.Rows)
            {
                cboGIO.Items.Add(dataRow[0].ToString());
            }
            ////////////
            cboTUYEN.Items.Clear();
            DataTable dataTable2 = DataAccess.GetDataTable("select TUYEN from TUYEN_BENXE");
            foreach (DataRow dataRow in dataTable2.Rows)
            {
                cboTUYEN.Items.Add(dataRow[0].ToString());
            }
            ///////////
            
        }
        private void LoadComboXE()
        {
            
            cboXE.Items.Clear();
            if(cboLOAIVE.Text=="") return;
            DataTable dataTable3 = DataAccess.GetDataTable("select biensoxe from XE where maloaive=(select maloaive from loaive where tenloaive=N'"+cboLOAIVE.Text+"')");
            foreach (DataRow dataRow in dataTable3.Rows)
            {
                cboXE.Items.Add(dataRow[0].ToString());
            }
        }
        private void LoadDataGridView()
        {
            dgv.DataSource = DataAccess.GetDataTable("select * from CHUYENXE_DETAILS");
        }
        private void btnthoat_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Thoát", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                this.Close();
        }

        private void huy()
        {
            cboLOAIVE.Text =cboTUYEN.Text = cboLOAIVE.Text = cboXE.Text = "";
             dtpNS.Text = DateTime.Now.ToShortDateString();
            btnthem.Visible = btnluu.Visible = btnhuy.Visible = false;
            btnnhapmoi.Visible = btnsua.Visible = btnxoa.Visible = true;
            panelnhap.Enabled = false;
            dgv.Enabled = true;
            dgvTAIXE.DataSource = null;
        }
        private void btnnhapmoi_Click(object sender, EventArgs e)
        {
            btnthem.Visible = btnhuy.Visible = true;
            btnsua.Visible = btnxoa.Visible = btnnhapmoi.Visible = false;
            cboLOAIVE.Text = cboTUYEN.Text = cboLOAIVE.Text = cboXE.Text = "";
            dtpNS.Text = DateTime.Now.ToShortDateString();
            panelnhap.Enabled = true;
            dgv.ClearSelection();
            dgvTAIXE.DataSource = null;
            
        }



        private void btnthem_Click(object sender, EventArgs e)
        {
            if (!DataAccess.Connect())
            {
                MessageBox.Show("Thoát?", "Không thể kết nối", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }
            string tuyen=cboTUYEN.Text; string loaive=cboLOAIVE.Text; FormNhapGiaVe f = new FormNhapGiaVe(tuyen, loaive);

            if (cboTUYEN.Text=="") tuyen = "NULL";
            else tuyen = "N'"+ cboTUYEN.Text.ToUpper()+"'";

            
            if (cboLOAIVE.Text == "") loaive = "NULL";
            else loaive = "N'" + cboLOAIVE.Text.ToUpper() + "'";

            string xe;
            if (cboXE.Text == "") xe = "NULL";
            else xe = "N'" + cboXE.Text.ToUpper() + "'";

            string gio;
            if (cboGIO.Text == "") gio = "NULL";
            else gio = "N'" + cboGIO.Text.ToUpper() + "'";

            string nd = dtpNS.Value.ToString("yyyy-MM-dd");
            nd = String.Format("'{0}'", nd);

            string mtx="NULL";
            if (dgvTAIXE.DataSource!=null&& dgvTAIXE.Rows.Count > 0) mtx = dgvTAIXE.Rows[0].Cells[0].Value.ToString();


            string cmd =  String.Format("exec CHUYENXE_THEM {0},{1},{2},{3},{4},{5}",tuyen,  nd, gio, loaive, xe, mtx);
            if (DataAccess.Execute(cmd))
            {
                LoadDataGridView();
                huy();
            }

            string gia = DataAccess.GetFirstCellValue("select sotien from chuyenxe_details cx, banggia_tuyen_loaive bg " +
                "where cx.tuyen=bg.tuyen and cx.tenloaive=bg.tenloaive and CX.tuyen=" + tuyen + " and CX.tenloaive=" + loaive + "");
            if(gia == "")
            {
                MessageBox.Show("Tuyến này chưa nhập giá vé");
                f.ShowDialog();
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
                        string cmd = String.Format("delete from CHUYENXE WHERE MACHUYENXE={0}", ma);
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

                        string mTX = dgv.Rows[i].Cells[6].Value.ToString(); if (mTX == "") mTX = "NULL";

                        //cboTUYEN.SelectedIndex = cboTUYEN.FindString(dgv.Rows[i].Cells[1].Value.ToString());
                        //cboLOAIVE.SelectedIndex = cboLOAIVE.FindString(dgv.Rows[i].Cells[2].Value.ToString());
                        //cboGIO.SelectedIndex = cboGIO.FindString(dgv.Rows[i].Cells[4].Value.ToString());
                        //cboXE.SelectedIndex = cboXE.FindString(dgv.Rows[i].Cells[5].Value.ToString());
                        cboTUYEN.Text = dgv.Rows[i].Cells[1].Value.ToString();
                        cboLOAIVE.Text = dgv.Rows[i].Cells[2].Value.ToString();
                        cboGIO.Text = dgv.Rows[i].Cells[4].Value.ToString();
                        cboXE.Text = dgv.Rows[i].Cells[5].Value.ToString();
                        dtpNS.Text = dgv.Rows[i].Cells[3].Value.ToString();

                        LoadTAIXE(mTX);
                        LoadComboXE();

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
                    string tuyen = cboTUYEN.Text; string loaive = cboLOAIVE.Text; FormNhapGiaVe f = new FormNhapGiaVe(tuyen, loaive);
                    
                    if (cboTUYEN.Text == "") tuyen = "NULL";
                    else tuyen = "N'" + cboTUYEN.Text.ToUpper() + "'";

                    if (cboLOAIVE.Text == "") loaive = "NULL";
                    else loaive = "N'" + cboLOAIVE.Text.ToUpper() + "'";

                    string xe;
                    if (cboXE.Text == "") xe = "NULL";
                    else xe = "N'" + cboXE.Text.ToUpper() + "'";

                    string gio;
                    if (cboGIO.Text == "") gio = "NULL";
                    else gio = "N'" + cboGIO.Text.ToUpper() + "'";

                    string nd = dtpNS.Value.ToString("yyyy-MM-dd");
                    nd = String.Format("'{0}'", nd);

                    string mtx = "NULL";
                    if (dgvTAIXE.Rows.Count >= 0) mtx = dgvTAIXE.Rows[0].Cells[0].Value.ToString();


                    string cmd = String.Format("exec CHUYENXE_SUA {0},{1},{2},{3},{4},{5},{6}",ma, tuyen, nd, gio, loaive, xe, mtx);
                    if (DataAccess.Execute(cmd))
                    {
                        LoadDataGridView();
                        huy();
                    }
                    string gia = DataAccess.GetFirstCellValue("select sotien from chuyenxe_details cx, banggia_tuyen_loaive bg " +
                        "where cx.tuyen=bg.tuyen and cx.tenloaive=bg.tenloaive and CX.tuyen=" + tuyen + " and CX.tenloaive=" + loaive + "");
                    if (gia == "")
                    {
                        MessageBox.Show("Tuyến này chưa nhập giá vé");
                        f.ShowDialog();
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
                        string mTX = dgv.Rows[i].Cells[6].Value.ToString(); if (mTX == "") mTX = "NULL";

                        //cboTUYEN.SelectedIndex = cboTUYEN.FindString(dgv.Rows[i].Cells[1].Value.ToString());
                        //cboLOAIVE.SelectedIndex = cboLOAIVE.FindString(dgv.Rows[i].Cells[2].Value.ToString());
                        //cboGIO.SelectedIndex = cboGIO.FindString(dgv.Rows[i].Cells[4].Value.ToString());
                        //cboXE.SelectedIndex = cboXE.FindString(dgv.Rows[i].Cells[5].Value.ToString());
                        cboTUYEN.Text = dgv.Rows[i].Cells[1].Value.ToString();
                        cboLOAIVE.Text = dgv.Rows[i].Cells[2].Value.ToString();
                        cboGIO.Text = dgv.Rows[i].Cells[4].Value.ToString();
                        cboXE.Text = dgv.Rows[i].Cells[5].Value.ToString();
                        dtpNS.Text = dgv.Rows[i].Cells[3].Value.ToString();
                        dtpNS.Text = dgv.Rows[i].Cells[3].Value.ToString();
                        LoadTAIXE(mTX);
                        LoadComboXE();

                    }
                    catch (Exception m)
                    {
                        MessageBox.Show(m.Message);
                    }

                }
        }

        private void btnCHONTAIXE_Click(object sender, EventArgs e)
        {
            FormCHONTAIXE f= new FormCHONTAIXE();
            f.ShowDialog();

            LoadTAIXE(f.MaTaiXe.ToString());
        }
        private void LoadTAIXE(string m)
        {
            dgvTAIXE.DataSource = DataAccess.GetDataTable("select MANHANVIEN, HOTEN, TENCHUCVU, NGAYSINH, DIENTHOAI, DIACHI from NHANVIEN N, CHUCVU C WHERE N.MACHUCVU=C.MACHUCVU and n.manhanvien=" + m);

        }

        private void button1_Click(object sender, EventArgs e)
        {
            FormXE f= new FormXE();
            f.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            FormTUYEN f= new FormTUYEN();
            f.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            FormLOAIVE f= new FormLOAIVE();
            f.ShowDialog();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            FormKHUNGGIO formKHUNGGIO = new FormKHUNGGIO();
            formKHUNGGIO.ShowDialog();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            FormBANGGIA formBANGGIA = new FormBANGGIA();
            formBANGGIA.ShowDialog();
        }

        private void cboLOAIVE_SelectedIndexChanged(object sender, EventArgs e)
        {
            cboXE.Text = "";
            LoadComboXE();
        }
    }
}
