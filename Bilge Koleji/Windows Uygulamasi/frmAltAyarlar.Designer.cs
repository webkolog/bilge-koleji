namespace Windows_Uygulamasi
{
    partial class frmAltAyarlar
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
            this.txtOkulAdi = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtAdres = new System.Windows.Forms.TextBox();
            this.mtxtTel = new System.Windows.Forms.MaskedTextBox();
            this.mtxtTel2 = new System.Windows.Forms.MaskedTextBox();
            this.mtxtFax = new System.Windows.Forms.MaskedTextBox();
            this.txtEMail = new System.Windows.Forms.TextBox();
            this.txtWeb = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.btnKaydet = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txtOkulAdi
            // 
            this.txtOkulAdi.Location = new System.Drawing.Point(90, 12);
            this.txtOkulAdi.MaxLength = 150;
            this.txtOkulAdi.Name = "txtOkulAdi";
            this.txtOkulAdi.Size = new System.Drawing.Size(182, 20);
            this.txtOkulAdi.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(50, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Okul Adı:";
            // 
            // txtAdres
            // 
            this.txtAdres.Location = new System.Drawing.Point(90, 38);
            this.txtAdres.MaxLength = 250;
            this.txtAdres.Multiline = true;
            this.txtAdres.Name = "txtAdres";
            this.txtAdres.Size = new System.Drawing.Size(182, 102);
            this.txtAdres.TabIndex = 1;
            // 
            // mtxtTel
            // 
            this.mtxtTel.Location = new System.Drawing.Point(90, 146);
            this.mtxtTel.Mask = "(999) 000-0000";
            this.mtxtTel.Name = "mtxtTel";
            this.mtxtTel.Size = new System.Drawing.Size(83, 20);
            this.mtxtTel.TabIndex = 2;
            // 
            // mtxtTel2
            // 
            this.mtxtTel2.Location = new System.Drawing.Point(90, 172);
            this.mtxtTel2.Mask = "(999) 000-0000";
            this.mtxtTel2.Name = "mtxtTel2";
            this.mtxtTel2.Size = new System.Drawing.Size(83, 20);
            this.mtxtTel2.TabIndex = 3;
            // 
            // mtxtFax
            // 
            this.mtxtFax.Location = new System.Drawing.Point(90, 198);
            this.mtxtFax.Mask = "(999) 000-0000";
            this.mtxtFax.Name = "mtxtFax";
            this.mtxtFax.Size = new System.Drawing.Size(83, 20);
            this.mtxtFax.TabIndex = 4;
            // 
            // txtEMail
            // 
            this.txtEMail.Location = new System.Drawing.Point(90, 225);
            this.txtEMail.MaxLength = 256;
            this.txtEMail.Name = "txtEMail";
            this.txtEMail.Size = new System.Drawing.Size(182, 20);
            this.txtEMail.TabIndex = 5;
            // 
            // txtWeb
            // 
            this.txtWeb.Location = new System.Drawing.Point(90, 252);
            this.txtWeb.MaxLength = 82;
            this.txtWeb.Name = "txtWeb";
            this.txtWeb.Size = new System.Drawing.Size(182, 20);
            this.txtWeb.TabIndex = 6;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 41);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(37, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Adres:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 149);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(43, 13);
            this.label3.TabIndex = 1;
            this.label3.Text = "Telefon";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 175);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(55, 13);
            this.label4.TabIndex = 1;
            this.label4.Text = "Telefon 2:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 201);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(27, 13);
            this.label5.TabIndex = 1;
            this.label5.Text = "Fax:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(12, 228);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(35, 13);
            this.label6.TabIndex = 1;
            this.label6.Text = "Email:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(12, 255);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(63, 13);
            this.label7.TabIndex = 1;
            this.label7.Text = "Web Adres:";
            // 
            // btnKaydet
            // 
            this.btnKaydet.Location = new System.Drawing.Point(90, 279);
            this.btnKaydet.Name = "btnKaydet";
            this.btnKaydet.Size = new System.Drawing.Size(95, 23);
            this.btnKaydet.TabIndex = 7;
            this.btnKaydet.Text = "Kaydet";
            this.btnKaydet.UseVisualStyleBackColor = true;
            this.btnKaydet.Click += new System.EventHandler(this.btnKaydet_Click);
            // 
            // frmAltAyarlar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 310);
            this.Controls.Add(this.btnKaydet);
            this.Controls.Add(this.txtWeb);
            this.Controls.Add(this.txtEMail);
            this.Controls.Add(this.mtxtFax);
            this.Controls.Add(this.mtxtTel2);
            this.Controls.Add(this.mtxtTel);
            this.Controls.Add(this.txtAdres);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtOkulAdi);
            this.Name = "frmAltAyarlar";
            this.Text = "frmAltAyarlar";
            this.Load += new System.EventHandler(this.frmAltAyarlar_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtOkulAdi;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtAdres;
        private System.Windows.Forms.MaskedTextBox mtxtTel;
        private System.Windows.Forms.MaskedTextBox mtxtTel2;
        private System.Windows.Forms.MaskedTextBox mtxtFax;
        private System.Windows.Forms.TextBox txtEMail;
        private System.Windows.Forms.TextBox txtWeb;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button btnKaydet;
    }
}