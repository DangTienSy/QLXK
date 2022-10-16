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
    public partial class FormTHONGTINKHACH : Form
    {
        public FormTHONGTINKHACH()
        {
            InitializeComponent();
        }

        private void FormTHONGTINKHACH_Load(object sender, EventArgs e)
        {
            if(!String.IsNullOrEmpty(FormMAIN.sodienthoai)) txtSDT.Text = FormMAIN.sodienthoai;
        }

        private void btnthem_Click(object sender, EventArgs e)
        {
            string t = txttenKHACH.Text.ToUpper();
            if (t == "") t = "NULL"; else t = String.Format("N'{0}'", t);
            string dc = txtDiaChi.Text.ToUpper();
            if (dc == "") dc = "NULL"; else dc = String.Format("N'{0}'", dc);
            string dt = txtSDT.Text.ToUpper();
            if (dt == "") dt = "NULL"; else dt = String.Format("N'{0}'", dt);
            string cmd = String.Format("insert into KHACH(HOTEN, diachi,DIENTHOAI) values ({0},{1},{2})", t, dc, dt);
            if (new DataAccess().Execute(cmd))
            {
                MessageBox.Show("Đã đăng kí thông tin thành công, chúng tôi sẽ gọi lại vào số " + txtSDT.Text+ " để xác nhận");
                FormMAIN.sodienthoai= txtSDT.Text;
                this.Close();
            }
        }
    }
}
