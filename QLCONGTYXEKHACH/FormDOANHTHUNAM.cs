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
    public partial class FormDOANHTHUNAM : Form
    {
        public FormDOANHTHUNAM()
        {
            InitializeComponent();
            
        }

        private void FormDOANHTHUNAM_Load(object sender, EventArgs e)
        {
            numericUpDown1.Value = DateTime.Now.Year;
           numericUpDown1_ValueChanged(sender, e);  
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            DataTable dt = new DataAccess().GetDataTable("select * from doanhthunamthang2 WHERE NAM=" + numericUpDown1.Value);
            if(dt.Rows.Count <= 0)
            {
                listBox1.Items.Add("KHÔNG CÓ DỮ LIỆU");
                return;
            }
            listBox1.Items.Add("DOANH THU NĂM " + numericUpDown1.Value + ": ");
            DataRow dr = dt.Rows[0];
            for (int i = 1; i <= 12; i++)
            {
                string s = dr[i].ToString();
                listBox1.Items.Add("THÁNG " + (i) + ": " +((s=="")?"0":s) );
            }
            listBox1.Items.Add("Tổng kết năm " + numericUpDown1.Value + ": " + new DataAccess().GetFirstCellValue("select format(doanhthunam, '#,#') from doanhthunam where nam="+ numericUpDown1.Value));

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            int i = listBox1.SelectedIndex;
            if (i < 1 || i > 12 || listBox1.Items[i].ToString() == "THÁNG " + (i) + ": 0") return;
            FormDOANHTHUCHUYEN obj = (FormDOANHTHUCHUYEN)Application.OpenForms["FormDOANHTHUCHUYEN"]; if(obj!=null)obj.Close();
            FormDOANHTHUCHUYEN formDOANHTHUCHUYEN = new FormDOANHTHUCHUYEN(i,(int)numericUpDown1.Value);
            formDOANHTHUCHUYEN.Show();
               
        }
    }
}
