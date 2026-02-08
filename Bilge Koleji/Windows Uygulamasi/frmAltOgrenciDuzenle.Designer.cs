namespace Windows_Uygulamasi
{
    partial class frmAltOgrenciDuzenle
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
            this.btnKaydet = new System.Windows.Forms.Button();
            this.comboOgrenciSinif = new System.Windows.Forms.ComboBox();
            this.label18 = new System.Windows.Forms.Label();
            this.gbOgrenci = new System.Windows.Forms.GroupBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtOgrenciAdi = new System.Windows.Forms.TextBox();
            this.btnOgrenciSifeOlustur = new System.Windows.Forms.Button();
            this.txtOgrenciSoyadi = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.comboOgrenciCinsiyet = new System.Windows.Forms.ComboBox();
            this.txtOgrenciSifre = new System.Windows.Forms.TextBox();
            this.label20 = new System.Windows.Forms.Label();
            this.txtOgrenciMail = new System.Windows.Forms.TextBox();
            this.txtOgrenciKademe = new System.Windows.Forms.TextBox();
            this.txtOgrenciMezunOkul = new System.Windows.Forms.TextBox();
            this.txtOgrenciMezuniyetNotu = new System.Windows.Forms.TextBox();
            this.gbOgrenci.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnKaydet
            // 
            this.btnKaydet.Location = new System.Drawing.Point(12, 267);
            this.btnKaydet.Name = "btnKaydet";
            this.btnKaydet.Size = new System.Drawing.Size(260, 29);
            this.btnKaydet.TabIndex = 28;
            this.btnKaydet.Text = "Kaydet";
            this.btnKaydet.UseVisualStyleBackColor = true;
            this.btnKaydet.Click += new System.EventHandler(this.btnKaydet_Click);
            // 
            // comboOgrenciSinif
            // 
            this.comboOgrenciSinif.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboOgrenciSinif.FormattingEnabled = true;
            this.comboOgrenciSinif.Location = new System.Drawing.Point(117, 222);
            this.comboOgrenciSinif.Name = "comboOgrenciSinif";
            this.comboOgrenciSinif.Size = new System.Drawing.Size(137, 21);
            this.comboOgrenciSinif.TabIndex = 9;
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(6, 225);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(30, 13);
            this.label18.TabIndex = 1;
            this.label18.Text = "Sınıf:";
            // 
            // gbOgrenci
            // 
            this.gbOgrenci.Controls.Add(this.label18);
            this.gbOgrenci.Controls.Add(this.label7);
            this.gbOgrenci.Controls.Add(this.comboOgrenciSinif);
            this.gbOgrenci.Controls.Add(this.label1);
            this.gbOgrenci.Controls.Add(this.txtOgrenciAdi);
            this.gbOgrenci.Controls.Add(this.btnOgrenciSifeOlustur);
            this.gbOgrenci.Controls.Add(this.txtOgrenciSoyadi);
            this.gbOgrenci.Controls.Add(this.label5);
            this.gbOgrenci.Controls.Add(this.label6);
            this.gbOgrenci.Controls.Add(this.label4);
            this.gbOgrenci.Controls.Add(this.label3);
            this.gbOgrenci.Controls.Add(this.label2);
            this.gbOgrenci.Controls.Add(this.comboOgrenciCinsiyet);
            this.gbOgrenci.Controls.Add(this.txtOgrenciSifre);
            this.gbOgrenci.Controls.Add(this.label20);
            this.gbOgrenci.Controls.Add(this.txtOgrenciMail);
            this.gbOgrenci.Controls.Add(this.txtOgrenciKademe);
            this.gbOgrenci.Controls.Add(this.txtOgrenciMezunOkul);
            this.gbOgrenci.Controls.Add(this.txtOgrenciMezuniyetNotu);
            this.gbOgrenci.Location = new System.Drawing.Point(12, 12);
            this.gbOgrenci.Name = "gbOgrenci";
            this.gbOgrenci.Size = new System.Drawing.Size(260, 249);
            this.gbOgrenci.TabIndex = 24;
            this.gbOgrenci.TabStop = false;
            this.gbOgrenci.Text = "Öğrenci";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(6, 199);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(61, 13);
            this.label7.TabIndex = 13;
            this.label7.Text = "Giriş Şifresi:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Öğrenci Adı:";
            // 
            // txtOgrenciAdi
            // 
            this.txtOgrenciAdi.Location = new System.Drawing.Point(117, 13);
            this.txtOgrenciAdi.MaxLength = 16;
            this.txtOgrenciAdi.Name = "txtOgrenciAdi";
            this.txtOgrenciAdi.Size = new System.Drawing.Size(138, 20);
            this.txtOgrenciAdi.TabIndex = 0;
            // 
            // btnOgrenciSifeOlustur
            // 
            this.btnOgrenciSifeOlustur.Location = new System.Drawing.Point(235, 196);
            this.btnOgrenciSifeOlustur.Name = "btnOgrenciSifeOlustur";
            this.btnOgrenciSifeOlustur.Size = new System.Drawing.Size(20, 20);
            this.btnOgrenciSifeOlustur.TabIndex = 8;
            this.btnOgrenciSifeOlustur.Text = "R";
            this.btnOgrenciSifeOlustur.UseVisualStyleBackColor = true;
            this.btnOgrenciSifeOlustur.Click += new System.EventHandler(this.btnOgrenciSifeOlustur_Click);
            // 
            // txtOgrenciSoyadi
            // 
            this.txtOgrenciSoyadi.Location = new System.Drawing.Point(117, 39);
            this.txtOgrenciSoyadi.MaxLength = 16;
            this.txtOgrenciSoyadi.Name = "txtOgrenciSoyadi";
            this.txtOgrenciSoyadi.Size = new System.Drawing.Size(138, 20);
            this.txtOgrenciSoyadi.TabIndex = 1;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 121);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(84, 13);
            this.label5.TabIndex = 9;
            this.label5.Text = "Mezuniyet Notu:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 173);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(67, 13);
            this.label6.TabIndex = 12;
            this.label6.Text = "Email Adresi:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 95);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(104, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "Mezun Olduğu Okul:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 68);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(46, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Cinsiyet:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 42);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(82, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Öğrenci Soyadı:";
            // 
            // comboOgrenciCinsiyet
            // 
            this.comboOgrenciCinsiyet.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboOgrenciCinsiyet.FormattingEnabled = true;
            this.comboOgrenciCinsiyet.Location = new System.Drawing.Point(117, 65);
            this.comboOgrenciCinsiyet.Name = "comboOgrenciCinsiyet";
            this.comboOgrenciCinsiyet.Size = new System.Drawing.Size(70, 21);
            this.comboOgrenciCinsiyet.TabIndex = 2;
            // 
            // txtOgrenciSifre
            // 
            this.txtOgrenciSifre.Location = new System.Drawing.Point(117, 196);
            this.txtOgrenciSifre.MaxLength = 16;
            this.txtOgrenciSifre.Name = "txtOgrenciSifre";
            this.txtOgrenciSifre.Size = new System.Drawing.Size(112, 20);
            this.txtOgrenciSifre.TabIndex = 7;
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(6, 147);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(79, 13);
            this.label20.TabIndex = 9;
            this.label20.Text = "Sınıf Kademesi:";
            // 
            // txtOgrenciMail
            // 
            this.txtOgrenciMail.Location = new System.Drawing.Point(117, 170);
            this.txtOgrenciMail.MaxLength = 255;
            this.txtOgrenciMail.Name = "txtOgrenciMail";
            this.txtOgrenciMail.Size = new System.Drawing.Size(138, 20);
            this.txtOgrenciMail.TabIndex = 6;
            // 
            // txtOgrenciKademe
            // 
            this.txtOgrenciKademe.Location = new System.Drawing.Point(117, 144);
            this.txtOgrenciKademe.MaxLength = 2;
            this.txtOgrenciKademe.Name = "txtOgrenciKademe";
            this.txtOgrenciKademe.Size = new System.Drawing.Size(71, 20);
            this.txtOgrenciKademe.TabIndex = 5;
            // 
            // txtOgrenciMezunOkul
            // 
            this.txtOgrenciMezunOkul.Location = new System.Drawing.Point(117, 92);
            this.txtOgrenciMezunOkul.MaxLength = 35;
            this.txtOgrenciMezunOkul.Name = "txtOgrenciMezunOkul";
            this.txtOgrenciMezunOkul.Size = new System.Drawing.Size(138, 20);
            this.txtOgrenciMezunOkul.TabIndex = 3;
            // 
            // txtOgrenciMezuniyetNotu
            // 
            this.txtOgrenciMezuniyetNotu.Location = new System.Drawing.Point(117, 118);
            this.txtOgrenciMezuniyetNotu.MaxLength = 5;
            this.txtOgrenciMezuniyetNotu.Name = "txtOgrenciMezuniyetNotu";
            this.txtOgrenciMezuniyetNotu.Size = new System.Drawing.Size(71, 20);
            this.txtOgrenciMezuniyetNotu.TabIndex = 4;
            // 
            // frmAltOgrenciDuzenle
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(283, 307);
            this.Controls.Add(this.btnKaydet);
            this.Controls.Add(this.gbOgrenci);
            this.Name = "frmAltOgrenciDuzenle";
            this.Text = "frmAltOgrenciDuzenle";
            this.Load += new System.EventHandler(this.frmAltOgrenciDuzenle_Load);
            this.gbOgrenci.ResumeLayout(false);
            this.gbOgrenci.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnKaydet;
        private System.Windows.Forms.ComboBox comboOgrenciSinif;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.GroupBox gbOgrenci;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtOgrenciAdi;
        private System.Windows.Forms.Button btnOgrenciSifeOlustur;
        private System.Windows.Forms.TextBox txtOgrenciSoyadi;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox comboOgrenciCinsiyet;
        private System.Windows.Forms.TextBox txtOgrenciSifre;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.TextBox txtOgrenciMail;
        private System.Windows.Forms.TextBox txtOgrenciKademe;
        private System.Windows.Forms.TextBox txtOgrenciMezunOkul;
        private System.Windows.Forms.TextBox txtOgrenciMezuniyetNotu;
    }
}