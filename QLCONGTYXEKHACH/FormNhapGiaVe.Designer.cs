namespace QLCONGTYXEKHACH
{
    partial class FormNhapGiaVe
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
            this.NUMGIA = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.LBLTUYEN = new System.Windows.Forms.Label();
            this.LBLLOAIVE = new System.Windows.Forms.Label();
            this.OK = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.NUMGIA)).BeginInit();
            this.SuspendLayout();
            // 
            // NUMGIA
            // 
            this.NUMGIA.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NUMGIA.Increment = new decimal(new int[] {
            50000,
            0,
            0,
            0});
            this.NUMGIA.Location = new System.Drawing.Point(32, 87);
            this.NUMGIA.Maximum = new decimal(new int[] {
            5000000,
            0,
            0,
            0});
            this.NUMGIA.Name = "NUMGIA";
            this.NUMGIA.Size = new System.Drawing.Size(203, 30);
            this.NUMGIA.TabIndex = 0;
            this.NUMGIA.ThousandsSeparator = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(29, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(54, 16);
            this.label1.TabIndex = 1;
            this.label1.Text = "TUYẾN";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(29, 53);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(57, 16);
            this.label2.TabIndex = 2;
            this.label2.Text = "LOẠI VÉ";
            // 
            // LBLTUYEN
            // 
            this.LBLTUYEN.AutoSize = true;
            this.LBLTUYEN.Location = new System.Drawing.Point(110, 25);
            this.LBLTUYEN.Name = "LBLTUYEN";
            this.LBLTUYEN.Size = new System.Drawing.Size(0, 16);
            this.LBLTUYEN.TabIndex = 3;
            // 
            // LBLLOAIVE
            // 
            this.LBLLOAIVE.AutoSize = true;
            this.LBLLOAIVE.Location = new System.Drawing.Point(110, 53);
            this.LBLLOAIVE.Name = "LBLLOAIVE";
            this.LBLLOAIVE.Size = new System.Drawing.Size(0, 16);
            this.LBLLOAIVE.TabIndex = 4;
            // 
            // OK
            // 
            this.OK.Location = new System.Drawing.Point(32, 123);
            this.OK.Name = "OK";
            this.OK.Size = new System.Drawing.Size(75, 23);
            this.OK.TabIndex = 5;
            this.OK.Text = "OK";
            this.OK.UseVisualStyleBackColor = true;
            this.OK.Click += new System.EventHandler(this.OK_Click);
            // 
            // FormNhapGiaVe
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(275, 176);
            this.Controls.Add(this.OK);
            this.Controls.Add(this.LBLLOAIVE);
            this.Controls.Add(this.LBLTUYEN);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.NUMGIA);
            this.Name = "FormNhapGiaVe";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FormNhapGiaVe";
            this.Load += new System.EventHandler(this.FormNhapGiaVe_Load);
            ((System.ComponentModel.ISupportInitialize)(this.NUMGIA)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.NumericUpDown NUMGIA;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label LBLTUYEN;
        private System.Windows.Forms.Label LBLLOAIVE;
        private System.Windows.Forms.Button OK;
    }
}