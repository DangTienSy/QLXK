using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ZXing.Aztec.Internal;

namespace QLCONGTYXEKHACH
{
    public partial class FormDOANHTHUCHUYEN : Form
    {
        DataAccess DataAccess = new DataAccess();
        int thang = 0, nam = 0;
        string chuyen;
        public FormDOANHTHUCHUYEN()
        {
            InitializeComponent();
        }
        public FormDOANHTHUCHUYEN(int thang, int nam)
        {
            InitializeComponent();
            this.thang = thang;
            this.nam = nam;
        }
        public FormDOANHTHUCHUYEN(string chuyen)
        {
            InitializeComponent();
            this.chuyen = chuyen;
        }
        private void LoadComboBox()
        {
            cboTUYEN.Items.Clear();
            DataTable dataTable = DataAccess.GetDataTable("SELECT DISTINCT TUYEN FROM CHUYEN_DATVE2");
            foreach (DataRow dataRow in dataTable.Rows)
            {
                cboTUYEN.Items.Add(dataRow[0].ToString());
            }
        }

        private void FormTRACUUCHUYENDI_Load(object sender, EventArgs e)
        {
            dtp1.Value = dtp2.Value = DateTime.Now;
            cboLOAIVE.Enabled = false;
            LoadComboBox();
            if(thang!=0&& nam != 0)
            {
                string cmd = String.Format("SELECT S.MACHUYENXE,dadat,dadat*SOTIEN AS DOANHTHU, C.TUYEN, C.TENLOAIVE,xuatben\r\nFROM sochodadat S, CHUYEN_DATVE2 C, BANGGIA_TUYEN_LOAIVE BG\r\nWHERE S.machuyenxe=C.MACHUYENXE AND BG.TENLOAIVE=C.TENLOAIVE AND BG.TUYEN=C.TUYEN" +
               " AND month(CAST(XUATBEN AS DATE))=" + thang + " AND year(CAST(XUATBEN AS DATE))=" + nam +" order by XUATBEN desc ");

                dgv.DataSource = DataAccess.GetDataTable(cmd);
                panel1.Visible = false;
                panelnhap.Visible = false;
                dgv.Location = panelnhap.Location;
                dgv.Height+=panelnhap.Height;

            }
            else if (!String.IsNullOrEmpty(chuyen))
            {
                string cmd = String.Format("SELECT S.MACHUYENXE,dadat,dadat*SOTIEN AS DOANHTHU, C.TUYEN, C.TENLOAIVE,xuatben\r\nFROM sochodadat S, CHUYEN_DATVE2 C, BANGGIA_TUYEN_LOAIVE BG\r\nWHERE S.machuyenxe=C.MACHUYENXE AND BG.TENLOAIVE=C.TENLOAIVE AND BG.TUYEN=C.TUYEN" +
               " AND s.machuyenxe="+chuyen);

                dgv.DataSource = DataAccess.GetDataTable(cmd);
                panel1.Visible = true;
                dgv_CellContentClick(sender, null);
            }
                
        }



        private void button2_Click(object sender, EventArgs e)
        {
            if (cboTUYEN.Text == "")
            {
                MessageBox.Show("Chưa chọn tuyến");
                return;
            }

            if (cboLOAIVE.Text == "")
            {
                MessageBox.Show("Chưa chọn loại vé");
                return;
            }
            if (dtp2.Value.CompareTo(dtp1.Value) < 0)
            {
                MessageBox.Show("Hãy chọn lại ngày");
                return;
            }
            string Tuyen = cboTUYEN.Text;
            string Ngay1 = dtp1.Value.ToString("yyyy-MM-dd");
            string Ngay2 = dtp2.Value.ToString("yyyy-MM-dd");
            string LoaiVe = cboLOAIVE.Text;
            string cmd = String.Format("SELECT S.MACHUYENXE,dadat,dadat*SOTIEN AS DOANHTHU, C.TUYEN, C.TENLOAIVE,xuatben\r\nFROM sochodadat S, CHUYEN_DATVE2 C, BANGGIA_TUYEN_LOAIVE BG\r\nWHERE S.machuyenxe=C.MACHUYENXE AND BG.TENLOAIVE=C.TENLOAIVE AND BG.TUYEN=C.TUYEN" +
               " and c.TUYEN=N'{0}' AND c.TENLOAIVE=N'{1}' AND CAST(XUATBEN AS DATE)>='" + Ngay1 + "' AND CAST(XUATBEN AS DATE)<='" + Ngay2 + "' order by XUATBEN desc ", Tuyen, LoaiVe);

            dgv.DataSource = DataAccess.GetDataTable(cmd);
            panel1.Visible = false;
        }

        

        private void cboTUYEN_SelectedIndexChanged(object sender, EventArgs e)
        {
            cboLOAIVE.Text = "";
            cboLOAIVE.Items.Clear();
            DataTable dataTable = DataAccess.GetDataTable("SELECT DISTINCT TENLOAIVE FROM CHUYEN_DATVE2 WHERE TUYEN=N'" + cboTUYEN.Text + "'");
            foreach (DataRow dataRow in dataTable.Rows)
            {
                cboLOAIVE.Items.Add(dataRow[0].ToString());
            }
            cboLOAIVE.Enabled = true;

        }
        private void button1_Click(object sender, EventArgs e)
        {
            panel1.Visible = false;
            string cmd = String.Format("SELECT S.MACHUYENXE,dadat,dadat*SOTIEN AS DOANHTHU, C.TUYEN, C.TENLOAIVE,xuatben\r\nFROM sochodadat S, CHUYEN_DATVE2 C, BANGGIA_TUYEN_LOAIVE BG\r\nWHERE S.machuyenxe=C.MACHUYENXE AND BG.TENLOAIVE=C.TENLOAIVE AND BG.TUYEN=C.TUYEN"
                + " AND XUATBEN>=CURRENT_TIMESTAMP  order by XUATBEN "
               );
            dgv.DataSource = DataAccess.GetDataTable(cmd);
            cboTUYEN.Text = ""; cboLOAIVE.Text = ""; cboLOAIVE.Enabled = false;
            dtp1.Value = dtp2.Value = DateTime.Now;

        }
        private void dgv_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (dgv.SelectedCells.Count > 0 && dgv.SelectedCells[0].Selected)
                {
                    DataGridViewCell cell = dgv.SelectedCells[0];
                    int i = cell.RowIndex;
                    foreach (DataGridViewRow r in dgv.Rows) r.Selected = false;
                    dgv.Rows[i].Selected = true;
                    LBLTUYEN.Text = dgv.Rows[i].Cells[3].Value.ToString();
                    LBLLOAIVE.Text = dgv.Rows[i].Cells[4].Value.ToString();
                    LBLXUATBEN.Text = dgv.Rows[i].Cells[5].Value.ToString();
                    LBLDADAT.Text = dgv.Rows[i].Cells[1].Value.ToString();
                    LBLDOANHTHU.Text = String.Format("{0:0,0}",int.Parse(dgv.Rows[i].Cells[2].Value.ToString()));
                    panel1.Visible = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        
    }

}
