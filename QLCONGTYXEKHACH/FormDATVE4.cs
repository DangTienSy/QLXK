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
    public partial class FormDATVE4 : Form
    {
        DataAccess DataAccess = new DataAccess();

        public FormDATVE4()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            txtLoaive.Text = DATVE.LoaiVe;
            txtTuyen.Text = DATVE.Tuyen;
            txtgia.Text = DATVE.GIAVE;
            txtgioxb.Text = DATVE.XUATBEN;
            txtgioden.Text = DATVE.DEN;
            //
            txtbien.Text= DataAccess.GetFirstCellValue("SELECT BIENSOXE FROM CHUYENXE_DETAILS WHERE MACHUYENXE="+ DATVE.MACHUYEN);
            lsbchon.Items.Clear();
            foreach (string s in DATVE.listchon)
                lsbchon.Items.Add(s);
            lblsove.Text = DATVE.listchon.Count.ToString();
            if (!String.IsNullOrEmpty(txtgia.Text))
                lblthanhtien.Text = String.Format("{0}", DATVE.listchon.Count * int.Parse(txtgia.Text.Replace(".", "")));
            txtDT.Focus();
            if(!String.IsNullOrEmpty(FormMAIN.sodienthoai)) txtDT.Text= FormMAIN.sodienthoai;

        }

        

        
        private void button10_Click(object sender, EventArgs e)
        {
            this.Hide();
            FormDATVE3 f = new FormDATVE3(FormDATVE3.fnc); f.ShowDialog();

        }

        private void button11_Click(object sender, EventArgs e)
        {
            if (txtDT.Text == "" || txtHOTEN.Text == "")
            {
                MessageBox.Show("Vui lòng nhập số điện thoại và họ tên");
                return;
            }
            string MAKHACH = DataAccess.GetFirstCellValue("SELECT MAKHACH FROM khach WHERE dienthoai='" + txtDT.Text + "'");
            if (MAKHACH == "")
            {
                string dc = txtDC.Text.ToUpper(); if (dc == "") dc = "NULL"; else dc = "N'" + dc + "'";
                DataAccess.Execute(String.Format("insert into KHACH(HOTEN,DIENTHOAI,DIACHI) values(N'{0}','{1}',{2})", txtHOTEN.Text.ToUpper(), txtDT.Text, dc));
                MAKHACH = DataAccess.GetFirstCellValue("SELECT MAKHACH FROM khach WHERE dienthoai='" + txtDT.Text + "'");
            }
            string ngaydat = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            DataAccess.Execute(String.Format("insert into phieudatve(ngaydat,makhach,machuyen) values('{0}',{1},{2})", ngaydat, MAKHACH, DATVE.MACHUYEN));
            string maphieu = DataAccess.GetFirstCellValue("select maphieudatve from phieudatve where makhach=" + MAKHACH + " and ngaydat='" + ngaydat + "' and machuyen= " + DATVE.MACHUYEN);
            bool re = true;
            foreach( string ghe in DATVE.listchon)
            if(!DataAccess.Execute(String.Format("insert into chitietdatve(maphieudatve,soghe) values({0},'{1}')", maphieu, ghe))) re=false;
            if (re)
            {
                MessageBox.Show("Đặt vé thành công, chúng tôi sẽ gọi vào số " + txtDT.Text + " để xác nhận.");
                FormMAIN.sodienthoai=txtDT.Text;
                groupBox1.Enabled = false;
                button11.Visible=button10.Visible=false;
                button1.Visible = true;
                
            }
        }

        private void txtDT_TextChanged(object sender, EventArgs e)
        {
            if (txtDT.Text.Length == 10)
            {
                string sdt = txtDT.Text;
                DataTable dt = DataAccess.GetDataTable("SELECT * FROM khach WHERE dienthoai='" + sdt+"'");
                if(dt.Rows.Count > 0)
                {
                    txtHOTEN.Text= dt.Rows[0][1].ToString();
                    txtDC.Text= dt.Rows[0][3].ToString();
                }

            }else
            {
                txtHOTEN.Text = "";
                txtDC.Text ="";
            }
        }

        private void txtDT_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(!char.IsDigit(e.KeyChar))e.Handled = true;
            if (e.KeyChar == (char)Keys.Back) e.Handled = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FormTHANHTOANMOMO F = new FormTHANHTOANMOMO(lblthanhtien.Text.Replace(",", ""));
            F.ShowDialog();
                
        }
    }
}
