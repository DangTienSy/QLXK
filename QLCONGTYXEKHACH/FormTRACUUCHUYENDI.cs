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

namespace QLCONGTYXEKHACH
{
    public partial class FormTRACUUCHUYENDI : Form
    {
        DataAccess DataAccess = new DataAccess();
        static string BENDAU, BENCUOI, TUNGAY, DENNGAY, LOAIVE, CHUYEN;
        public FormTRACUUCHUYENDI()
        {
            InitializeComponent();
        }
        private void LoadComboBox()
        {
            cboBENDAU.Items.Clear(); cboBENCUOI.Items.Clear();
            DataTable dataTable = DataAccess.GetDataTable("select TENBENXE from BENXE");
            foreach (DataRow dataRow in dataTable.Rows)
            {
                cboBENDAU.Items.Add(dataRow[0].ToString());
                cboBENCUOI.Items.Add(dataRow[0].ToString());
            }
            cboLOAIVE.Items.Clear();
            cboLOAIVE.Items.Add("--Tất cả--");
            DataTable dataTable1 = DataAccess.GetDataTable("select tenloaive from loaive");
            foreach (DataRow dataRow in dataTable1.Rows)
            {
                cboLOAIVE.Items.Add(dataRow[0].ToString());
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FormTRACUUCHUYENDI_Load(object sender, EventArgs e)
        
        {
            LoadComboBox();
            if (!String.IsNullOrEmpty(BENDAU)) cboBENDAU.Text = BENDAU;
            if (!String.IsNullOrEmpty(BENCUOI)) cboBENCUOI.Text = BENCUOI;
            if (!String.IsNullOrEmpty(LOAIVE)) cboLOAIVE.Text = LOAIVE ;
            if (!String.IsNullOrEmpty(TUNGAY)) dtp1.Text = TUNGAY;
            else dtp1.Value =DateTime.Now;
            if (!String.IsNullOrEmpty(DENNGAY)) dtp2.Text = DENNGAY;
            else dtp2.Value = DateTime.Now;
            if (!(cboBENDAU.Text == "")|| (cboBENCUOI.Text == "")||(cboBENDAU.Text == cboBENCUOI.Text)
            ||(cboLOAIVE.Text == "")|| (dtp1.Value.Date.CompareTo(DateTime.Now.Date) < 0 || dtp2.Value.CompareTo(dtp1.Value) < 0)
            )
            {
                BENDAU = cboBENDAU.Text;
                BENCUOI = cboBENCUOI.Text;
                TUNGAY = dtp1.Value.ToString("yyyy-MM-dd");
                DENNGAY = dtp2.Value.ToString("yyyy-MM-dd");
                LOAIVE = cboLOAIVE.Text;
                string cmd;
                if (LOAIVE == "--Tất cả--")
                    cmd = String.Format("SELECT MACHUYENXE, c.tuyen,c.tenloaive, XUATBEN, DEN,CONCHO, sotien FROM CHUYEN_DATVE2 c, BANGGIA_TUYEN_LOAIVE g where c.TUYEN=g.TUYEN and c.TENLOAIVE=g.TENLOAIVE" +
                    " and c.TUYEN=N'{0}'  AND CAST(XUATBEN AS DATE)>='" + TUNGAY + "' AND CAST(XUATBEN AS DATE)<='" + DENNGAY + "' order by XUATBEN ", (BENDAU + " - " + BENCUOI));
                else cmd = String.Format("SELECT MACHUYENXE, c.tuyen,c.tenloaive, XUATBEN, DEN,CONCHO, sotien FROM CHUYEN_DATVE2 c, BANGGIA_TUYEN_LOAIVE g where c.TUYEN=g.TUYEN and c.TENLOAIVE=g.TENLOAIVE" +
                   " and c.TUYEN=N'{0}' AND c.TENLOAIVE=N'{1}' AND CAST(XUATBEN AS DATE)>='" + TUNGAY + "' AND CAST(XUATBEN AS DATE)<='" + DENNGAY + "' order by XUATBEN ", (BENDAU + " - " + BENCUOI), LOAIVE);

                dgv.DataSource = DataAccess.GetDataTable(cmd);
                foreach (DataGridViewRow r in dgv.Rows)
                    if ( r.Cells[0].Value.ToString() == CHUYEN)
                       r.Selected = true;
                    else 
                        r.Selected = false;

            }
           if(FormMAIN.DANGNHAP!=0&& FormMAIN.DANGNHAP != 4)
            {
                button1.Visible = false;
            }
            
        }



        private void button2_Click(object sender, EventArgs e)
        {
            if (cboBENDAU.Text == "")
            {
                MessageBox.Show("Chưa chọn bến đầu");
                return;
            }
            if (cboBENCUOI.Text == "")
            {
                MessageBox.Show("Chưa chọn bến cuối");
                return;
            }
            if (cboBENDAU.Text == cboBENCUOI.Text)
            {
                MessageBox.Show("Hãy chọn bến cuối không trùng bến đầu");
                return;
            }
            if (cboLOAIVE.Text == "")
            {
                MessageBox.Show("Chưa chọn loại vé");
                return;
            }
            if ((dtp1.Value.Date.CompareTo(DateTime.Now.Date) < 0) || dtp2.Value.CompareTo(dtp1.Value) < 0)
            {
                MessageBox.Show("Hãy chọn lại ngày");
                return;
            }
            BENDAU = cboBENDAU.Text;
            BENCUOI = cboBENCUOI.Text;
            TUNGAY = dtp1.Value.ToString("yyyy-MM-dd");
            DENNGAY = dtp2.Value.ToString("yyyy-MM-dd");
            LOAIVE = cboLOAIVE.Text;
            string cmd;
            if (LOAIVE == "--Tất cả--")
               cmd = String.Format("SELECT MACHUYENXE, c.tuyen,c.tenloaive, XUATBEN, DEN,CONCHO, sotien FROM CHUYEN_DATVE2 c, BANGGIA_TUYEN_LOAIVE g where c.TUYEN=g.TUYEN and c.TENLOAIVE=g.TENLOAIVE" +
               " and c.TUYEN=N'{0}'  AND CAST(XUATBEN AS DATE)>='" + TUNGAY + "' AND CAST(XUATBEN AS DATE)<='" + DENNGAY + "' order by XUATBEN ", (BENDAU + " - " + BENCUOI));
            else cmd = String.Format("SELECT MACHUYENXE, c.tuyen,c.tenloaive, XUATBEN, DEN,CONCHO, sotien FROM CHUYEN_DATVE2 c, BANGGIA_TUYEN_LOAIVE g where c.TUYEN=g.TUYEN and c.TENLOAIVE=g.TENLOAIVE" +
               " and c.TUYEN=N'{0}' AND c.TENLOAIVE=N'{1}' AND CAST(XUATBEN AS DATE)>='" + TUNGAY + "' AND CAST(XUATBEN AS DATE)<='" + DENNGAY + "' order by XUATBEN ", (BENDAU + " - " + BENCUOI), LOAIVE);

            dgv.DataSource = DataAccess.GetDataTable(cmd);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (dgv.SelectedCells.Count > 0 && dgv.SelectedCells[0].Selected)
            {
                DataGridViewCell cell = dgv.SelectedCells[0];
                int i = cell.RowIndex;
                foreach (DataGridViewRow r in dgv.Rows) r.Selected = false;
                dgv.Rows[i].Selected = true;
                if(dgv.Rows[i].Cells[5].Value.ToString()=="0")
                {
                    MessageBox.Show("Hết chỗ");
                    return;
                }
                string chuyen = dgv.Rows[i].Cells[0].Value.ToString();
                string tuyen = dgv.Rows[i].Cells[1].Value.ToString();
                string lv = dgv.Rows[i].Cells[2].Value.ToString();
                string xb = dgv.Rows[i].Cells[3].Value.ToString();
                string d = dgv.Rows[i].Cells[4].Value.ToString();
                string gv = dgv.Rows[i].Cells[6].Value.ToString();

                this.Hide();
                FormDATVE3 f = new FormDATVE3(1);
                DATVE.Tuyen = tuyen;
                DATVE.LoaiVe = lv;
                DATVE.XUATBEN =DATVE.Ngay= xb;
                DATVE.DEN = d;
               CHUYEN= DATVE.MACHUYEN = chuyen;
                DATVE.GIAVE = gv;
                DATVE.listchon = new List<string>();
                f.ShowDialog();
            }
        }

        private void FormTRACUUCHUYENDI_Activated(object sender, EventArgs e)
        {

        }

        private void dgv_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }

}
