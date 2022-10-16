using QLCONGTYXEKHACH.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ZXing;
using ZXing.Common;
using ZXing.QrCode.Internal;
using ZXing.Rendering;

namespace QLCONGTYXEKHACH
{
    public partial class FormTHANHTOANMOMO : Form
    {
        string sotien;
        public FormTHANHTOANMOMO(string SOTIEN)
        {
            InitializeComponent();
            sotien = SOTIEN;
        }

        private void FormTHANHTOANMOMO_Load(object sender, EventArgs e)
        {
            btnQR_Click(sender, e);
        }
        private void btnQR_Click(object sender, EventArgs e)
        {
            string hoten = "Đặng Tiến Sỹ";
            string sdt = "0777770164";
            string email = "sss@gmail.com";
            var qrcode_text = $"2|99|{sdt.Trim()}|{hoten.Trim()}|{email.Trim()}|0|0|{sotien.Trim()}";
            BarcodeWriter barcodeWriter = new BarcodeWriter();
            EncodingOptions encodingOptions = new EncodingOptions() { Width = 250, Height = 250, Margin = 0, PureBarcode = false };
            encodingOptions.Hints.Add(EncodeHintType.ERROR_CORRECTION, ErrorCorrectionLevel.H);
            barcodeWriter.Renderer = new BitmapRenderer();
            barcodeWriter.Options = encodingOptions;
            barcodeWriter.Format = BarcodeFormat.QR_CODE;
            Bitmap bitmap = barcodeWriter.Write(qrcode_text);
            try
            {
                Image image= Image.FromFile(@"C:\Users\ASUS\Documents\lap trinh\THLTW\QLCONGTYXEKHACH\Resources\MoMo_Logo.png", true);
                Bitmap logo = resizeImage(image, 64, 64) as Bitmap;
                Graphics g = Graphics.FromImage(bitmap);
                g.DrawImage(logo, new Point((bitmap.Width - logo.Width) / 2, (bitmap.Height - logo.Height) / 2));
            }
            catch (System.IO.FileNotFoundException)
            {
                MessageBox.Show("There was an error opening the bitmap." +
                    "Please check the path.");
            }
            picQR.Image = bitmap;
        }

        public Image resizeImage(Image image, int new_height, int new_width)
        {
            Bitmap new_image = new Bitmap(new_width, new_height);
            Graphics g = Graphics.FromImage((Image)new_image);
            g.InterpolationMode = InterpolationMode.High;
            g.DrawImage(image, 0, 0, new_width, new_height);
            return new_image;
        }
    }
}
