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
    public partial class FormTHONGTINDATVE : Form
    {
        DataAccess DataAccess = new DataAccess();

        public FormTHONGTINDATVE()
        {
            InitializeComponent();
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
            textBox1.Enabled = false;
            LoadComboBox();
             button5.Visible = FormMAIN.DANGNHAP == 2; 
            button3.Visible = FormMAIN.DANGNHAP == 4;
            foreach (TabPage tab in tabControl1.TabPages) if (!tab.Equals(tabKHACHDAT)) tabControl1.TabPages.Remove(tab);
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
            string cmd= String.Format("SELECT MACHUYENXE, c.tuyen,c.tenloaive, XUATBEN, DEN,CONCHO, sotien FROM CHUYEN_DATVE2 c, BANGGIA_TUYEN_LOAIVE g where c.TUYEN=g.TUYEN and c.TENLOAIVE=g.TENLOAIVE" +
               " and c.TUYEN=N'{0}' AND c.TENLOAIVE=N'{1}' AND CAST(XUATBEN AS DATE)>='" + Ngay1 + "' AND CAST(XUATBEN AS DATE)<='" + Ngay2 + "' order by XUATBEN ", Tuyen , LoaiVe);

            dgv.DataSource = DataAccess.GetDataTable(cmd);
            LBLCHUYEN.Text = "";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string cmd = String.Format("SELECT MACHUYENXE, c.tuyen,c.tenloaive, XUATBEN, DEN,CONCHO, sotien FROM CHUYEN_DATVE2 c, BANGGIA_TUYEN_LOAIVE g where c.TUYEN=g.TUYEN and c.TENLOAIVE=g.TENLOAIVE"
                +" AND XUATBEN>=CURRENT_TIMESTAMP  order by XUATBEN "
               );
            dgv.DataSource = DataAccess.GetDataTable(cmd);
            cboTUYEN.Text = ""; cboLOAIVE.Text = ""; cboLOAIVE.Enabled = false;
            dtp1.Value = dtp2.Value = DateTime.Now;
            LBLCHUYEN.Text = "";

        }

        private void cboTUYEN_SelectedIndexChanged(object sender, EventArgs e)
        {
            cboLOAIVE.Text = "";
            cboLOAIVE.Items.Clear();
            DataTable dataTable = DataAccess.GetDataTable("SELECT DISTINCT TENLOAIVE FROM CHUYEN_DATVE2 WHERE TUYEN=N'"+cboTUYEN.Text+"'");
            foreach (DataRow dataRow in dataTable.Rows)
            {
                cboLOAIVE.Items.Add(dataRow[0].ToString());
            }
            cboLOAIVE.Enabled = true;

        }

        private void dgv_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (dgv.SelectedCells.Count > 0 && dgv.SelectedCells[0].Selected)
                {
                    DataGridViewCell cell = dgv.SelectedCells[0];
                    int i = cell.RowIndex;
                    LBLCHUYEN.Text = dgv.Rows[i].Cells[0].Value.ToString();
                    foreach (DataGridViewRow r in dgv.Rows) r.Selected = false;
                    dgv.Rows[i].Selected = true;
                    string cmd = "select DIENTHOAI, hoten , ngaydat,  count(soghe) as soghe, diachi " +
                    " from PHIEUDATVE p, KHACH k , CHITIETDATVE ct where p.MAKHACH=k.MAKHACH and p.MAPHIEUDATVE=ct.MAPHIEUDATVE" +
                    " and p.MACHUYEN=" + dgv.Rows[i].Cells[0].Value.ToString() + " group by k.DIENTHOAI, hoten, ngaydat, diachi";
                    dgvKhach.DataSource = DataAccess.GetDataTable(cmd);
                    LBLGIAVE.Text = String.Format("{0:0,0}",int.Parse(dgv.Rows[i].Cells[6].Value.ToString()));
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void dgvKhach_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvKhach.SelectedCells.Count > 0 && dgvKhach.SelectedCells[0].Selected)
            {
                DataGridViewCell cell = dgvKhach.SelectedCells[0];
                int i = cell.RowIndex;
                foreach (DataGridViewRow r in dgvKhach.Rows) r.Selected = false;
                dgvKhach.Rows[i].Selected = true;
                string cmd = "select soghe from PHIEUDATVE p, KHACH k , CHITIETDATVE ct" +
                       " where p.MAKHACH=k.MAKHACH and p.MAPHIEUDATVE=ct.MAPHIEUDATVE AND MACHUYEN=" + LBLCHUYEN.Text +
                       " AND DIENTHOAI='"+ dgvKhach.Rows[i].Cells[0].Value.ToString() + "'";
                dgvVe.DataSource = DataAccess.GetDataTable(cmd);
                GROUPBOXCT.Visible = true;
                LBLSL.Text= dgvKhach.Rows[i].Cells[3].Value.ToString();
                LBLTT.Text = String.Format("{0:0,0}", int.Parse(LBLSL.Text) * int.Parse(LBLGIAVE.Text.Replace(",", "")));
            }
           
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            string cmd = "select DIENTHOAI, hoten , ngaydat,  count(soghe) as soghe, diachi " +
                    " from PHIEUDATVE p, KHACH k , CHITIETDATVE ct where p.MAKHACH=k.MAKHACH and p.MAPHIEUDATVE=ct.MAPHIEUDATVE"+
                    " and p.MACHUYEN=" + LBLCHUYEN.Text ;
            if (textBox1.Text != "") cmd +=  " and DIENTHOAI like '%" + textBox1.Text + "%'";
           cmd+=         " group by k.DIENTHOAI, hoten, ngaydat, diachi";
            dgvKhach.DataSource = DataAccess.GetDataTable(cmd);
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(!char.IsDigit(e.KeyChar))e.Handled = true;
            if (e.KeyChar == (char)Keys.Back) e.Handled = false;
        }

        private void LBLCHUYEN_TextChanged(object sender, EventArgs e)
        {
            foreach (TabPage tab in tabControl1.TabPages) if (!tab.Equals(tabKHACHDAT)) tabControl1.TabPages.Remove(tab);

            textBox1.Text = "";
            if (LBLCHUYEN.Text == "")
            {
                textBox1.Enabled = false;
            }
            else
            {
                textBox1.Enabled = true;//
                //
                List<string> listvedadat = new List<string>();
                DataTable dt = DataAccess.GetDataTable("select soghe from CHITIETDATVE ct, PHIEUDATVE p, CHUYENXE cx\r\nwhere ct.MAPHIEUDATVE=p.MAPHIEUDATVE and p.MACHUYEN=cx.MACHUYENXE and cx.MACHUYENXE=" + LBLCHUYEN.Text);
                foreach (DataRow dr in dt.Rows) listvedadat.Add(dr[0].ToString());
                List<Button> listgiuongnam = new List<Button>()
            {
                btnA01, btnA02, btnA03, btnA04, btnA05, btnA06,btnA07, btnA08, btnA09, btnA10, btnA11, btnA12, btnA13, btnA14, btnA15, btnA16,btnA17,btnA18,
                btnB01, btnB02, btnB03, btnB04, btnB05, btnB06,btnB07, btnB08, btnB09, btnB10, btnB11, btnB12, btnB13, btnB14, btnB15, btnB16,btnB17,btnB18
            };
                List<Button> listGHENGOI = new List<Button>()
            {
                btnA1, btnA2, btnA3, btnA4, btnB1, btnB2, btnB3, btnB4, btnC1, btnC2, btnC3, btnC4, btnD1, btnD2, btnD3, btnD4,
                btnE1, btnE2, btnE3, btnE4, btnF1, btnF2, btnF3, btnF4, btnG1, btnG2, btnG3, btnG4, btnH1, btnH2, btnH3, btnH4,
                btnI1, btnI2, btnI3, btnI4, btnJ1, btnJ2, btnJ3, btnJ4, btnK1, btnK2, btnK3, btnK4, btnK5
            };
                List<Button> listGHENAM = new List<Button>()
            {
                btnN1,btnN2,btnN3,btnN4,btnN5,btnN6,btnN7,btnN8,btnN9,btnN10,btnN11,btnN12,btnN13,btnN14,btnN15,
                btnN16,btnN17,btnN18,btnN19,btnN20,btnN21,btnN22,btnN23,btnN24,btnN25,btnN26,btnN27,btnN28,btnN29,btnN30,
                btnN31,btnN32,btnN33,btnN34,btnN35,btnN36,btnN37,btnN38,btnN39,btnN40,btnN41,btnN42,btnN43,btnN44,btnN45
            };
                List<Button> listPHONG = new List<Button>()
            {
                btnPD01, btnPD02, btnPD03, btnPD04, btnPD05, btnPD06, btnPD07, btnPD08, btnPD09, btnPD10, btnPD11, btnPD12,
                btnPT01, btnPT02, btnPT03, btnPT04, btnPT05, btnPT06, btnPT07, btnPT08, btnPT09, btnPT10, btnPT11, btnPT12
            };
                //
                List<Button> listBT = new List<Button>();
                TabPage tabSODOCHO= new TabPage();
                switch (DataAccess.GetFirstCellValue("select tenloaive from chuyen_datve2 where machuyenxe=" + LBLCHUYEN.Text))
                {
                    case "GIƯỜNG NẰM": listBT = listgiuongnam; tabSODOCHO = tabGIUONGNAM; break;
                    case "GHẾ NẰM": listBT = listGHENAM; tabSODOCHO = tabGHENAM; break;
                    case "GHẾ NGỒI": listBT = listGHENGOI; tabSODOCHO = tabGHENGOI; break;
                    case "PHÒNG": listBT = listPHONG; tabSODOCHO = tabPHONG; break;
                }
                tabControl1.TabPages.Add(tabSODOCHO);
                //
                foreach (Button b in listBT)
                {
                    b.BackColor = btncon.BackColor;
                    b.Enabled = false;
                }
                foreach (string s in listvedadat)
                    foreach (Button b in listBT)
                        if (s == b.Text)
                        {
                            b.BackColor = btnhet.BackColor;
                        }

            }
        }

        private void dgvKhach_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvKhach.SelectedRows.Count == 0) GROUPBOXCT.Visible = false;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (LBLCHUYEN.Text == "")
            {
                MessageBox.Show("Chưa chọn chuyến");
                return;
            }
            string tuyen = DataAccess.GetFirstCellValue("SELECT tuyen FROM CHUYEN_DATVE2 where MACHUYENXE=" + LBLCHUYEN.Text);
            string lv = DataAccess.GetFirstCellValue("SELECT tenloaive FROM CHUYEN_DATVE2 where MACHUYENXE=" + LBLCHUYEN.Text);
            string xb = DataAccess.GetFirstCellValue("SELECT xuatben FROM CHUYEN_DATVE2 where MACHUYENXE=" + LBLCHUYEN.Text);
            string d = DataAccess.GetFirstCellValue("SELECT den FROM CHUYEN_DATVE2 where MACHUYENXE=" + LBLCHUYEN.Text);


            FormDATVE3 f = new FormDATVE3(2);
            DATVE.Tuyen=tuyen;
            DATVE.LoaiVe = lv;
            DATVE.XUATBEN = xb;
            DATVE.DEN = d;
            DATVE.MACHUYEN = LBLCHUYEN.Text;
            DATVE.listchon = new List<string>();
            
            f.ShowDialog();
        }

        private void FormTHONGTINDATVE_Activated(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(LBLCHUYEN.Text)) return;
            FormDOANHTHUCHUYEN formDOANHTHUCHUYEN = new FormDOANHTHUCHUYEN(LBLCHUYEN.Text);
            formDOANHTHUCHUYEN.ShowDialog();
        }

        private void BTNTHANHTOAN_Click(object sender, EventArgs e)
        {
            FormTHANHTOANMOMO f = new FormTHANHTOANMOMO(LBLTT.Text.Replace(",", ""));
            f.ShowDialog();
        }

        private void btnA1_Click(object sender, EventArgs e)
        {

        }
    }

}
