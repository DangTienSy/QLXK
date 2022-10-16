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
    public partial class FormTRACUUBEN : Form
    {
        public FormTRACUUBEN()
        {
            InitializeComponent();
            DataTable dt = new DataAccess().GetDataTable("select tenbenxe, diachi, hotline from benxe ORDER BY TENBENXE");
            foreach (DataRow dr in dt.Rows)
            {
                listBox1.Items.Add("BẾN XE: " + dr[0].ToString());
                listBox1.Items.Add("ĐỊA CHỈ: "+dr[1].ToString());
                listBox1.Items.Add("HOTLINE: " + dr[2].ToString());
                listBox1.Items.Add("---------------------------------------------");
                
            }
        }
    }
}
