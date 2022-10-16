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
    public partial class FormLICHSUDATVE : Form
    {
        DataAccess DataAccess = new DataAccess();

        public FormLICHSUDATVE()
        {
            InitializeComponent();
        }
        

        private void FormTRACUUCHUYENDI_Load(object sender, EventArgs e)
        {
            txtSDT.Text = FormMAIN.sodienthoai;
            txttenKHACH.Text = DataAccess.GetFirstCellValue("select hoten from khach where dienthoai='" + txtSDT.Text + "'");
            txtDiaChi.Text = DataAccess.GetFirstCellValue("select diachi from khach where dienthoai='" + txtSDT.Text + "'");
            foreach (TabPage tab in tabControl1.TabPages) if (!tab.Equals(tabKHACHDAT)) tabControl1.TabPages.Remove(tab);
            LoadDGV();
        }

        private void LoadDGV()
        {
            string cmd = String.Format("SELECT CX.MACHUYENXE,CX.TUYEN,CX.TENLOAIVE,NGAYDI,GIOXUATBEN,SOTIEN " +
                "FROM PHIEUDATVE P, CHUYENXE_DETAILS CX, KHACH K, BANGGIA_TUYEN_LOAIVE BG WHERE P.MACHUYEN= CX.MACHUYENXE" +
                " AND P.MAKHACH=K.MAKHACH AND BG.TENLOAIVE=CX.TENLOAIVE AND BG.TUYEN= CX.TUYEN AND DIENTHOAI='"+txtSDT.Text+"' " +
               "  AND CAST(NGAYDI AS datetime)+CAST(GIOXUATBEN AS dateTIME)>=CURRENT_TIMESTAMP ORDER BY NGAYDI DESC, GIOXUATBEN ASC");

            dgv.DataSource = DataAccess.GetDataTable(cmd);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            LoadDGV();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            string cmd = String.Format("SELECT CX.MACHUYENXE,CX.TUYEN,CX.TENLOAIVE,NGAYDI,GIOXUATBEN,SOTIEN " +
                 "FROM PHIEUDATVE P, CHUYENXE_DETAILS CX, KHACH K, BANGGIA_TUYEN_LOAIVE BG WHERE P.MACHUYEN= CX.MACHUYENXE" +
                 " AND P.MAKHACH=K.MAKHACH AND BG.TENLOAIVE=CX.TENLOAIVE AND BG.TUYEN= CX.TUYEN AND DIENTHOAI='" + txtSDT.Text + "' " +
                "  AND CAST(NGAYDI AS datetime)+CAST(GIOXUATBEN AS dateTIME)<CURRENT_TIMESTAMP ORDER BY NGAYDI DESC, GIOXUATBEN ASC");

            dgv.DataSource = DataAccess.GetDataTable(cmd);
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
                    string chuyen = dgv.Rows[i].Cells[0].Value.ToString();
                    LBLGIAVE.Text = String.Format("{0:0,0}", int.Parse(dgv.Rows[i].Cells[5].Value.ToString()));
                    string cmd = "SELECT soghe FROM PHIEUDATVE P, KHACH K, CHITIETDATVE ct WHERE P.MAKHACH=K.MAKHACH " +
                        "AND p.MAPHIEUDATVE=ct.MAPHIEUDATVE AND DIENTHOAI='"+txtSDT.Text+"' and MACHUYEN="+chuyen;
                    dgvVe.DataSource = DataAccess.GetDataTable(cmd);
                    List<string> list = new List<string>();
                    foreach(DataRow dr in (dgvVe.DataSource as DataTable).Rows)
                    {
                        list.Add(dr[0].ToString());
                    }
                    LBLSL.Text = list.Count.ToString();
                    LBLTT.Text= String.Format("{0}",int.Parse(LBLSL.Text)* int.Parse(LBLGIAVE.Text.Replace(".","")));
                    CHONCHUYEN(chuyen,list);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

       
        

        

       

        private void CHONCHUYEN(string chuyen , List<string> listchon)
        {
            foreach (TabPage tab in tabControl1.TabPages) if (!tab.Equals(tabKHACHDAT)) tabControl1.TabPages.Remove(tab);


            {
                
                //
                List<string> listvedadat = new List<string>();
                DataTable dt = DataAccess.GetDataTable("select soghe from CHITIETDATVE ct, PHIEUDATVE p, CHUYENXE cx\r\nwhere ct.MAPHIEUDATVE=p.MAPHIEUDATVE and p.MACHUYEN=cx.MACHUYENXE and cx.MACHUYENXE=" + chuyen);
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
                TabPage tabSODOCHO = new TabPage();
                switch (DataAccess.GetFirstCellValue("select tenloaive from chuyen_datve2 where machuyenxe=" + chuyen))
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
                foreach (string s in listchon)
                    foreach (Button b in listBT)
                        if (s == b.Text)
                        {
                            b.BackColor = btnbandat.BackColor;
                        }

            }
        }


        private void BTNTHANHTOAN_Click(object sender, EventArgs e)
        {
            FormTHANHTOANMOMO f = new FormTHANHTOANMOMO(LBLTT.Text.Replace(",", ""));
            f.ShowDialog();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if(button4.Text == "LƯU THÔNG TIN")
            {
                string t = txttenKHACH.Text.ToUpper();
                if (t == "") t = "NULL"; else t = String.Format("N'{0}'", t);
                string dc = txtDiaChi.Text.ToUpper();
                if (dc == "") dc = "NULL"; else dc = String.Format("N'{0}'", dc);
                string cmd = String.Format("update KHACH set hoten={0},DIACHI={1} WHERE dienthoai={2}", t, dc, txtSDT.Text);
                if (!DataAccess.Execute(cmd))
                {
                    txttenKHACH.Text = DataAccess.GetFirstCellValue("select hoten from khach where dienthoai='" + txtSDT.Text + "'");
                    txtDiaChi.Text = DataAccess.GetFirstCellValue("select diachi from khach where dienthoai='" + txtSDT.Text + "'");

                }
                button4.Text = "SỬA THÔNG TIN";
                panelnhap.Enabled = false;           
            }
            else if (button4.Text == "SỬA THÔNG TIN")
            {
                button4.Text = "LƯU THÔNG TIN";
                panelnhap.Enabled = true;
            }
        }
    }

}
