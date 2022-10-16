using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLCONGTYXEKHACH
{
    public partial class FormDATVE3 : Form
    {
        DataAccess DataAccess= new DataAccess();
        
        List<string> listvedadat = new List<string>();
        public static int fnc=0;

        public FormDATVE3(int fnc)
        {
            InitializeComponent();
            FormDATVE3.fnc = fnc;
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            txtLoaive.Text = DATVE.LoaiVe;
            txtTuyen.Text = DATVE.Tuyen ;
            txtgia.Text = DATVE.GIAVE;
            txtgioxb.Text = DATVE.XUATBEN;
            txtgioden.Text = DATVE.DEN;
            //
            DataTable dt = DataAccess.GetDataTable("select soghe from CHITIETDATVE ct, PHIEUDATVE p, CHUYENXE cx\r\nwhere ct.MAPHIEUDATVE=p.MAPHIEUDATVE and p.MACHUYEN=cx.MACHUYENXE and cx.MACHUYENXE="+ DATVE.MACHUYEN);
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
            tct.TabPages.Remove(tabGHENGOI); tct.TabPages.Remove(tabGHENAM);tct.TabPages.Remove(tabGIUONGNAM); tct.TabPages.Remove(tabPHONG);
            //
            List<Button> listBT= new List<Button>();
            TabPage tabPage= new TabPage();
            switch (DATVE.LoaiVe)
            {
                case "GIƯỜNG NẰM":  listBT = listgiuongnam; tabPage = tabGIUONGNAM; break;
                case "GHẾ NẰM": listBT = listGHENAM; tabPage = tabGHENAM; break;
                case "GHẾ NGỒI": listBT = listGHENGOI; tabPage = tabGHENGOI; break;
                case "PHÒNG": listBT = listPHONG; tabPage = tabPHONG; break;
            }
            tct.TabPages.Add(tabPage);
            tct.SelectedTab = tabPage;
            //
            foreach (Button b in listBT)
            {
               b.BackColor = btncon.BackColor;
            }
            foreach (string s in listvedadat)
                foreach(Button b in listBT)
                    if (s == b.Text)
                    {
                        b.BackColor = btnhet.BackColor;
                        b.Enabled = false;
                    }
            foreach (string s in DATVE.listchon)
                foreach (Button b in listBT)
                    if (s == b.Text)
                    {
                        b.BackColor = btndang.BackColor;
                    }
        }

        private void btnA1_Click(object sender, EventArgs e)
        {
            Button b = sender as Button;
            if (b.BackColor == btncon.BackColor)
            {
                DATVE.listchon.Add(b.Text);
                b.BackColor = btndang.BackColor;
            }
            else if (b.BackColor == btndang.BackColor)
            {
                DATVE.listchon.Remove(b.Text);
                b.BackColor = btncon.BackColor;
            }
            LoadLsb();
        }

        private void LoadLsb()
        {
            lsbchon.Items.Clear();
            DATVE.listchon.Sort();
            foreach (string s in DATVE.listchon)
                lsbchon.Items.Add(s);
            lblsove.Text= DATVE.listchon.Count.ToString();
            if(!String.IsNullOrEmpty(txtgia.Text))
            lblthanhtien.Text = String.Format("{0}", DATVE.listchon.Count * int.Parse(txtgia.Text.Replace(".", "")));  
        }

        private void button10_Click(object sender, EventArgs e)
        {
            this.Hide();
            if (fnc == 0)
            {
                FormDATVE2 F = new FormDATVE2(); F.ShowDialog();
            }
            else if(fnc==1)
            {
                FormTRACUUCHUYENDI F = new FormTRACUUCHUYENDI(); F.ShowDialog();
            }
            else if (fnc == 2)
            {
                FormTHONGTINDATVE F = new FormTHONGTINDATVE(); F.ShowDialog();
            }
        }

        private void button11_Click(object sender, EventArgs e)
        {
            if(DATVE.listchon.Count == 0)
            {
                MessageBox.Show("Bạn chưa chọn vị trí ghế");
                return;
            }
            this.Hide();
            FormDATVE4 f = new FormDATVE4();
            f.ShowDialog();
        }

        private void button12_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
