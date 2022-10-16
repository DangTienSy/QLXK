using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace QLCONGTYXEKHACH
{
    public partial class FormDATVE1 : Form
    {
        

        public DataAccess DataAccess = new DataAccess();
        public FormDATVE1()
        {
            InitializeComponent();
            DATVE.listchon = new List<string>();
        }
        
        private void FormDATVE1_Load(object sender, EventArgs e)
        {
            LoadComboBox();
            LoadComboBoxLV();
            if (!String.IsNullOrEmpty(DATVE.Tuyen)) cboTUYEN.Text = DATVE.Tuyen;
            if (!String.IsNullOrEmpty(DATVE.LoaiVe)) cboLOAIVE.Text = DATVE.LoaiVe;
            if (!String.IsNullOrEmpty(DATVE.Ngay)) dtpNS.Text = DATVE.Ngay;
            else dtpNS.Value = DateTime.Now;
        }
        private void LoadComboBox()
        {
            cboTUYEN.Items.Clear();
            DataTable dataTable = DataAccess.GetDataTable("select DISTINCT TUYEN from CHUYEN_DATVE2");
            foreach (DataRow dataRow in dataTable.Rows)
                cboTUYEN.Items.Add(dataRow[0].ToString());
        }
       private void LoadComboBoxLV()
        {   
            cboLOAIVE.Items.Clear();
            if (cboTUYEN.Text == "") cboLOAIVE.Enabled = false;
            else
            {
                DataTable dataTable1 = DataAccess.GetDataTable("select distinct tenloaive from chuyen_datve2 where tuyen=N'"+cboTUYEN.Text+"'");
                foreach (DataRow dataRow in dataTable1.Rows)
                {
                    cboLOAIVE.Items.Add(dataRow[0].ToString());
                }
                cboLOAIVE.Enabled = true;
            }
           
        }
        private void btnthoat_Click(object sender, EventArgs e)
        {
            
                this.Close();
        }

        private void BTNCHON_Click(object sender, EventArgs e)
        {
            if (cboTUYEN.Text == "")
            {
                MessageBox.Show("Chưa chọn tuyến");
                return;
            }
            
            if (dtpNS.Value.Date.CompareTo(DateTime.Now.Date) < 0)
            {
                MessageBox.Show("Hãy chọn lại ngày đi");
                return;
            }
            DATVE.Tuyen = cboTUYEN.Text;
            DATVE.Ngay = dtpNS.Value.ToString("yyyy-MM-dd");
            DATVE.LoaiVe = cboLOAIVE.Text;
            this.Hide();
            FormDATVE2 f = new FormDATVE2();
            f.ShowDialog();

        }

        private void cboLOAIVE_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void cboTUYEN_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadComboBoxLV();
        }
    }
}
