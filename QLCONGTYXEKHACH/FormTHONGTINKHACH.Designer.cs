namespace QLCONGTYXEKHACH
{
    partial class FormTHONGTINKHACH
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnthem = new System.Windows.Forms.Button();
            this.panelnhap = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.txtSDT = new System.Windows.Forms.TextBox();
            this.LBLDIACHI = new System.Windows.Forms.Label();
            this.txtDiaChi = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txttenKHACH = new System.Windows.Forms.TextBox();
            this.panelnhap.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnthem
            // 
            this.btnthem.BackColor = System.Drawing.Color.DarkSalmon;
            this.btnthem.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.btnthem.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnthem.Location = new System.Drawing.Point(132, 235);
            this.btnthem.Name = "btnthem";
            this.btnthem.Size = new System.Drawing.Size(135, 50);
            this.btnthem.TabIndex = 6;
            this.btnthem.Text = "THÊM";
            this.btnthem.UseVisualStyleBackColor = false;
            this.btnthem.Click += new System.EventHandler(this.btnthem_Click);
            // 
            // panelnhap
            // 
            this.panelnhap.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panelnhap.Controls.Add(this.label3);
            this.panelnhap.Controls.Add(this.txtSDT);
            this.panelnhap.Controls.Add(this.LBLDIACHI);
            this.panelnhap.Controls.Add(this.txtDiaChi);
            this.panelnhap.Controls.Add(this.label1);
            this.panelnhap.Controls.Add(this.txttenKHACH);
            this.panelnhap.Location = new System.Drawing.Point(12, 12);
            this.panelnhap.Name = "panelnhap";
            this.panelnhap.Size = new System.Drawing.Size(386, 217);
            this.panelnhap.TabIndex = 7;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(2, 142);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(104, 20);
            this.label3.TabIndex = 5;
            this.label3.Text = "ĐIỆN THOẠI";
            // 
            // txtSDT
            // 
            this.txtSDT.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSDT.Location = new System.Drawing.Point(6, 165);
            this.txtSDT.Name = "txtSDT";
            this.txtSDT.Size = new System.Drawing.Size(370, 30);
            this.txtSDT.TabIndex = 4;
            // 
            // LBLDIACHI
            // 
            this.LBLDIACHI.AutoSize = true;
            this.LBLDIACHI.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LBLDIACHI.Location = new System.Drawing.Point(4, 80);
            this.LBLDIACHI.Name = "LBLDIACHI";
            this.LBLDIACHI.Size = new System.Drawing.Size(70, 20);
            this.LBLDIACHI.TabIndex = 3;
            this.LBLDIACHI.Text = "ĐỊA CHỈ";
            // 
            // txtDiaChi
            // 
            this.txtDiaChi.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDiaChi.Location = new System.Drawing.Point(8, 103);
            this.txtDiaChi.Name = "txtDiaChi";
            this.txtDiaChi.Size = new System.Drawing.Size(370, 30);
            this.txtDiaChi.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(4, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(73, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "HỌ TÊN";
            // 
            // txttenKHACH
            // 
            this.txttenKHACH.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txttenKHACH.Location = new System.Drawing.Point(8, 44);
            this.txttenKHACH.Name = "txttenKHACH";
            this.txttenKHACH.Size = new System.Drawing.Size(370, 30);
            this.txttenKHACH.TabIndex = 0;
            // 
            // FormTHONGTINKHACH
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(413, 295);
            this.Controls.Add(this.btnthem);
            this.Controls.Add(this.panelnhap);
            this.Name = "FormTHONGTINKHACH";
            this.Text = "FormTHONGTINKHACH";
            this.Load += new System.EventHandler(this.FormTHONGTINKHACH_Load);
            this.panelnhap.ResumeLayout(false);
            this.panelnhap.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnthem;
        private System.Windows.Forms.Panel panelnhap;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtSDT;
        private System.Windows.Forms.Label LBLDIACHI;
        private System.Windows.Forms.TextBox txtDiaChi;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txttenKHACH;
    }
}