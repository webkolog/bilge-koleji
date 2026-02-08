namespace Windows_Uygulamasi
{
    partial class frmAltVeliDuzenle
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
            this.gbVeli = new System.Windows.Forms.GroupBox();
            this.mtxtVeliIsTel = new System.Windows.Forms.MaskedTextBox();
            this.mtxtVeliTel = new System.Windows.Forms.MaskedTextBox();
            this.btnVeliSifreOlustur = new System.Windows.Forms.Button();
            this.label14 = new System.Windows.Forms.Label();
            this.txtVeliAdi = new System.Windows.Forms.TextBox();
            this.label17 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.txtVeliSifre = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.txtVeliEmail = new System.Windows.Forms.TextBox();
            this.txtVeliSemt = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtVeliSehir = new System.Windows.Forms.TextBox();
            this.txtVeliIlce = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.txtVeliSoyadi = new System.Windows.Forms.TextBox();
            this.txtVeliAdres = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.gbVeli.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnKaydet
            // 
            this.btnKaydet.Location = new System.Drawing.Point(12, 349);
            this.btnKaydet.Name = "btnKaydet";
            this.btnKaydet.Size = new System.Drawing.Size(278, 29);
            this.btnKaydet.TabIndex = 11;
            this.btnKaydet.Text = "Kaydet";
            this.btnKaydet.UseVisualStyleBackColor = true;
            this.btnKaydet.Click += new System.EventHandler(this.btnKaydet_Click);
            // 
            // gbVeli
            // 
            this.gbVeli.Controls.Add(this.mtxtVeliIsTel);
            this.gbVeli.Controls.Add(this.mtxtVeliTel);
            this.gbVeli.Controls.Add(this.btnVeliSifreOlustur);
            this.gbVeli.Controls.Add(this.label14);
            this.gbVeli.Controls.Add(this.txtVeliAdi);
            this.gbVeli.Controls.Add(this.label17);
            this.gbVeli.Controls.Add(this.label13);
            this.gbVeli.Controls.Add(this.label12);
            this.gbVeli.Controls.Add(this.label9);
            this.gbVeli.Controls.Add(this.txtVeliSifre);
            this.gbVeli.Controls.Add(this.label15);
            this.gbVeli.Controls.Add(this.label16);
            this.gbVeli.Controls.Add(this.txtVeliEmail);
            this.gbVeli.Controls.Add(this.txtVeliSemt);
            this.gbVeli.Controls.Add(this.label8);
            this.gbVeli.Controls.Add(this.txtVeliSehir);
            this.gbVeli.Controls.Add(this.txtVeliIlce);
            this.gbVeli.Controls.Add(this.label10);
            this.gbVeli.Controls.Add(this.txtVeliSoyadi);
            this.gbVeli.Controls.Add(this.txtVeliAdres);
            this.gbVeli.Controls.Add(this.label11);
            this.gbVeli.Location = new System.Drawing.Point(12, 12);
            this.gbVeli.Name = "gbVeli";
            this.gbVeli.Size = new System.Drawing.Size(278, 331);
            this.gbVeli.TabIndex = 27;
            this.gbVeli.TabStop = false;
            this.gbVeli.Text = "Veli";
            // 
            // mtxtVeliIsTel
            // 
            this.mtxtVeliIsTel.Location = new System.Drawing.Point(83, 92);
            this.mtxtVeliIsTel.Mask = "(999) 000-0000";
            this.mtxtVeliIsTel.Name = "mtxtVeliIsTel";
            this.mtxtVeliIsTel.Size = new System.Drawing.Size(138, 20);
            this.mtxtVeliIsTel.TabIndex = 3;
            // 
            // mtxtVeliTel
            // 
            this.mtxtVeliTel.Location = new System.Drawing.Point(83, 66);
            this.mtxtVeliTel.Mask = "(999) 000-0000";
            this.mtxtVeliTel.Name = "mtxtVeliTel";
            this.mtxtVeliTel.Size = new System.Drawing.Size(138, 20);
            this.mtxtVeliTel.TabIndex = 2;
            // 
            // btnVeliSifreOlustur
            // 
            this.btnVeliSifreOlustur.Location = new System.Drawing.Point(201, 299);
            this.btnVeliSifreOlustur.Name = "btnVeliSifreOlustur";
            this.btnVeliSifreOlustur.Size = new System.Drawing.Size(20, 20);
            this.btnVeliSifreOlustur.TabIndex = 10;
            this.btnVeliSifreOlustur.Text = "R";
            this.btnVeliSifreOlustur.UseVisualStyleBackColor = true;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(6, 16);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(45, 13);
            this.label14.TabIndex = 1;
            this.label14.Text = "Veli Adı:";
            // 
            // txtVeliAdi
            // 
            this.txtVeliAdi.Location = new System.Drawing.Point(83, 13);
            this.txtVeliAdi.MaxLength = 16;
            this.txtVeliAdi.Name = "txtVeliAdi";
            this.txtVeliAdi.Size = new System.Drawing.Size(138, 20);
            this.txtVeliAdi.TabIndex = 0;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(6, 303);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(61, 13);
            this.label17.TabIndex = 13;
            this.label17.Text = "Giriş Şifresi:";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(5, 198);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(15, 13);
            this.label13.TabIndex = 13;
            this.label13.Text = "İl:";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(6, 224);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(27, 13);
            this.label12.TabIndex = 12;
            this.label12.Text = "İlçe:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(6, 42);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(62, 13);
            this.label9.TabIndex = 6;
            this.label9.Text = "Veli Soyadı:";
            // 
            // txtVeliSifre
            // 
            this.txtVeliSifre.Location = new System.Drawing.Point(83, 299);
            this.txtVeliSifre.MaxLength = 16;
            this.txtVeliSifre.Name = "txtVeliSifre";
            this.txtVeliSifre.Size = new System.Drawing.Size(112, 20);
            this.txtVeliSifre.TabIndex = 9;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(6, 250);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(34, 13);
            this.label15.TabIndex = 12;
            this.label15.Text = "Semt:";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(6, 276);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(67, 13);
            this.label16.TabIndex = 12;
            this.label16.Text = "Email Adresi:";
            // 
            // txtVeliEmail
            // 
            this.txtVeliEmail.Location = new System.Drawing.Point(83, 273);
            this.txtVeliEmail.MaxLength = 255;
            this.txtVeliEmail.Name = "txtVeliEmail";
            this.txtVeliEmail.Size = new System.Drawing.Size(138, 20);
            this.txtVeliEmail.TabIndex = 8;
            // 
            // txtVeliSemt
            // 
            this.txtVeliSemt.Location = new System.Drawing.Point(83, 247);
            this.txtVeliSemt.MaxLength = 35;
            this.txtVeliSemt.Name = "txtVeliSemt";
            this.txtVeliSemt.Size = new System.Drawing.Size(138, 20);
            this.txtVeliSemt.TabIndex = 7;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(6, 95);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(63, 13);
            this.label8.TabIndex = 8;
            this.label8.Text = "İş Telefonu:";
            // 
            // txtVeliSehir
            // 
            this.txtVeliSehir.Location = new System.Drawing.Point(83, 195);
            this.txtVeliSehir.MaxLength = 35;
            this.txtVeliSehir.Name = "txtVeliSehir";
            this.txtVeliSehir.Size = new System.Drawing.Size(138, 20);
            this.txtVeliSehir.TabIndex = 5;
            // 
            // txtVeliIlce
            // 
            this.txtVeliIlce.Location = new System.Drawing.Point(83, 221);
            this.txtVeliIlce.MaxLength = 35;
            this.txtVeliIlce.Name = "txtVeliIlce";
            this.txtVeliIlce.Size = new System.Drawing.Size(138, 20);
            this.txtVeliIlce.TabIndex = 6;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(6, 69);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(68, 13);
            this.label10.TabIndex = 8;
            this.label10.Text = "Ev Telefonu:";
            // 
            // txtVeliSoyadi
            // 
            this.txtVeliSoyadi.Location = new System.Drawing.Point(83, 39);
            this.txtVeliSoyadi.MaxLength = 16;
            this.txtVeliSoyadi.Name = "txtVeliSoyadi";
            this.txtVeliSoyadi.Size = new System.Drawing.Size(138, 20);
            this.txtVeliSoyadi.TabIndex = 1;
            // 
            // txtVeliAdres
            // 
            this.txtVeliAdres.Location = new System.Drawing.Point(83, 118);
            this.txtVeliAdres.MaxLength = 150;
            this.txtVeliAdres.Multiline = true;
            this.txtVeliAdres.Name = "txtVeliAdres";
            this.txtVeliAdres.Size = new System.Drawing.Size(186, 71);
            this.txtVeliAdres.TabIndex = 4;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(6, 118);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(55, 13);
            this.label11.TabIndex = 9;
            this.label11.Text = "Ev Adresi:";
            // 
            // frmAltVeliDuzenle
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(303, 390);
            this.Controls.Add(this.btnKaydet);
            this.Controls.Add(this.gbVeli);
            this.Name = "frmAltVeliDuzenle";
            this.Text = "frmAltVeliDuzenle";
            this.Load += new System.EventHandler(this.frmAltVeliDuzenle_Load);
            this.gbVeli.ResumeLayout(false);
            this.gbVeli.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnKaydet;
        private System.Windows.Forms.GroupBox gbVeli;
        private System.Windows.Forms.MaskedTextBox mtxtVeliIsTel;
        private System.Windows.Forms.MaskedTextBox mtxtVeliTel;
        private System.Windows.Forms.Button btnVeliSifreOlustur;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox txtVeliAdi;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtVeliSifre;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.TextBox txtVeliEmail;
        private System.Windows.Forms.TextBox txtVeliSemt;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtVeliSehir;
        private System.Windows.Forms.TextBox txtVeliIlce;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtVeliSoyadi;
        private System.Windows.Forms.TextBox txtVeliAdres;
        private System.Windows.Forms.Label label11;
    }
}