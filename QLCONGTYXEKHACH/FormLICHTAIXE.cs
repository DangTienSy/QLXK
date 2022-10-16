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
    public partial class FormLICHTAIXE : Form
    {
        DataAccess DataAccess = new DataAccess();
        public FormLICHTAIXE()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string cmd = "select NGAYDI, GIOXUATBEN, MATAIXE, HOTEN,TUYEN, TENLOAIVE , BIENSOXE from CHUYENXE_DETAILS where mataixe="+FormMAIN.manhanvien+" and ngaydi>cast(\r\ncurrent_timestamp as date) order by ngaydi, GIOXUATBEN";
            dgv.DataSource = DataAccess.GetDataTable(cmd);
        }

        private void FormLICHTAIXE_Load(object sender, EventArgs e)
        {
            if (FormMAIN.DANGNHAP!=5)
            {
               button2.Visible= button1.Visible = false;
            }
            string cmd = "select NGAYDI, GIOXUATBEN, MATAIXE, HOTEN,TUYEN, TENLOAIVE , BIENSOXE from CHUYENXE_DETAILS where ngaydi>cast(\r\ncurrent_timestamp as date) order by ngaydi, GIOXUATBEN";
            dgv.DataSource = DataAccess.GetDataTable(cmd);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string cmd = "select NGAYDI, GIOXUATBEN, MATAIXE, HOTEN,TUYEN, TENLOAIVE , BIENSOXE from CHUYENXE_DETAILS where ngaydi>cast(\r\ncurrent_timestamp as date) order by ngaydi, GIOXUATBEN";
            dgv.DataSource = DataAccess.GetDataTable(cmd);
        }
    }
}
