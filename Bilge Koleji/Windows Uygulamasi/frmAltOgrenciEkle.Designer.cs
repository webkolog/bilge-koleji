namespace Windows_Uygulamasi
{
    partial class frmAltOgrenciEkle
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
            this.txtOgrenciAdi = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtOgrenciSoyadi = new System.Windows.Forms.TextBox();
            this.comboOgrenciCinsiyet = new System.Windows.Forms.ComboBox();
            this.txtOgrenciMezunOkul = new System.Windows.Forms.TextBox();
            this.txtOgrenciMezuniyetNotu = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtOgrenciMail = new System.Windows.Forms.TextBox();
            this.txtOgrenciSifre = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.gbOgrenci = new System.Windows.Forms.GroupBox();
            this.label22 = new System.Windows.Forms.Label();
            this.txtOgrenciTcKimlik = new System.Windows.Forms.TextBox();
            this.btnOgrenciSifeOlustur = new System.Windows.Forms.Button();
            this.label20 = new System.Windows.Forms.Label();
            this.txtOgrenciKademe = new System.Windows.Forms.TextBox();
            this.gbVeli = new System.Windows.Forms.GroupBox();
            this.mtxtVeliIsTel = new System.Windows.Forms.MaskedTextBox();
            this.mtxtVeliTel = new System.Windows.Forms.MaskedTextBox();
            this.btnVeliSifreOlustur = new System.Windows.Forms.Button();
            this.label21 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.txtVeliTcKimlik = new System.Windows.Forms.TextBox();
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
            this.gbSinif = new System.Windows.Forms.GroupBox();
            this.comboOgrenciSinif = new System.Windows.Forms.ComboBox();
            this.label18 = new System.Windows.Forms.Label();
            this.gbVeliSecimi = new System.Windows.Forms.GroupBox();
            this.label19 = new System.Windows.Forms.Label();
            this.comboVeliSec = new System.Windows.Forms.ComboBox();
            this.rbVeliOlustur = new System.Windows.Forms.RadioButton();
            this.rbVeliKayitli = new System.Windows.Forms.RadioButton();
            this.btnKaydet = new System.Windows.Forms.Button();
            this.gbOgrenci.SuspendLayout();
            this.gbVeli.SuspendLayout();
            this.gbSinif.SuspendLayout();
            this.gbVeliSecimi.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtOgrenciAdi
            // 
            this.txtOgrenciAdi.Location = new System.Drawing.Point(118, 39);
            this.txtOgrenciAdi.MaxLength = 16;
            this.txtOgrenciAdi.Name = "txtOgrenciAdi";
            this.txtOgrenciAdi.Size = new System.Drawing.Size(138, 20);
            this.txtOgrenciAdi.TabIndex = 1;
            this.txtOgrenciAdi.TextChanged += new System.EventHandler(this.txtOgrenciSoyadi_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 42);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Öğrenci Adı:";
            // 
            // txtOgrenciSoyadi
            // 
            this.txtOgrenciSoyadi.Location = new System.Drawing.Point(118, 65);
            this.txtOgrenciSoyadi.MaxLength = 16;
            this.txtOgrenciSoyadi.Name = "txtOgrenciSoyadi";
            this.txtOgrenciSoyadi.Size = new System.Drawing.Size(138, 20);
            this.txtOgrenciSoyadi.TabIndex = 2;
            this.txtOgrenciSoyadi.TextChanged += new System.EventHandler(this.txtOgrenciSoyadi_TextChanged);
            // 
            // comboOgrenciCinsiyet
            // 
            this.comboOgrenciCinsiyet.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboOgrenciCinsiyet.FormattingEnabled = true;
            this.comboOgrenciCinsiyet.Location = new System.Drawing.Point(118, 91);
            this.comboOgrenciCinsiyet.Name = "comboOgrenciCinsiyet";
            this.comboOgrenciCinsiyet.Size = new System.Drawing.Size(70, 21);
            this.comboOgrenciCinsiyet.TabIndex = 3;
            // 
            // txtOgrenciMezunOkul
            // 
            this.txtOgrenciMezunOkul.Location = new System.Drawing.Point(118, 118);
            this.txtOgrenciMezunOkul.MaxLength = 35;
            this.txtOgrenciMezunOkul.Name = "txtOgrenciMezunOkul";
            this.txtOgrenciMezunOkul.Size = new System.Drawing.Size(138, 20);
            this.txtOgrenciMezunOkul.TabIndex = 4;
            // 
            // txtOgrenciMezuniyetNotu
            // 
            this.txtOgrenciMezuniyetNotu.Location = new System.Drawing.Point(118, 144);
            this.txtOgrenciMezuniyetNotu.MaxLength = 5;
            this.txtOgrenciMezuniyetNotu.Name = "txtOgrenciMezuniyetNotu";
            this.txtOgrenciMezuniyetNotu.Size = new System.Drawing.Size(71, 20);
            this.txtOgrenciMezuniyetNotu.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(7, 68);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(82, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Öğrenci Soyadı:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(7, 94);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(46, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Cinsiyet:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(7, 121);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(104, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "Mezun Olduğu Okul:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(7, 147);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(84, 13);
            this.label5.TabIndex = 9;
            this.label5.Text = "Mezuniyet Notu:";
            // 
            // txtOgrenciMail
            // 
            this.txtOgrenciMail.Location = new System.Drawing.Point(118, 196);
            this.txtOgrenciMail.MaxLength = 255;
            this.txtOgrenciMail.Name = "txtOgrenciMail";
            this.txtOgrenciMail.Size = new System.Drawing.Size(138, 20);
            this.txtOgrenciMail.TabIndex = 7;
            this.txtOgrenciMail.Text = "@bilgekoleji.com";
            // 
            // txtOgrenciSifre
            // 
            this.txtOgrenciSifre.Location = new System.Drawing.Point(118, 222);
            this.txtOgrenciSifre.MaxLength = 16;
            this.txtOgrenciSifre.Name = "txtOgrenciSifre";
            this.txtOgrenciSifre.Size = new System.Drawing.Size(112, 20);
            this.txtOgrenciSifre.TabIndex = 8;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(7, 199);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(67, 13);
            this.label6.TabIndex = 12;
            this.label6.Text = "Email Adresi:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(7, 225);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(61, 13);
            this.label7.TabIndex = 13;
            this.label7.Text = "Giriş Şifresi:";
            // 
            // gbOgrenci
            // 
            this.gbOgrenci.Controls.Add(this.label7);
            this.gbOgrenci.Controls.Add(this.label22);
            this.gbOgrenci.Controls.Add(this.label1);
            this.gbOgrenci.Controls.Add(this.txtOgrenciTcKimlik);
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
            this.gbOgrenci.Size = new System.Drawing.Size(260, 248);
            this.gbOgrenci.TabIndex = 0;
            this.gbOgrenci.TabStop = false;
            this.gbOgrenci.Text = "Öğrenci";
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Location = new System.Drawing.Point(7, 16);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(71, 13);
            this.label22.TabIndex = 1;
            this.label22.Text = "TC Kimlik No:";
            // 
            // txtOgrenciTcKimlik
            // 
            this.txtOgrenciTcKimlik.Location = new System.Drawing.Point(117, 13);
            this.txtOgrenciTcKimlik.MaxLength = 11;
            this.txtOgrenciTcKimlik.Name = "txtOgrenciTcKimlik";
            this.txtOgrenciTcKimlik.Size = new System.Drawing.Size(138, 20);
            this.txtOgrenciTcKimlik.TabIndex = 0;
            // 
            // btnOgrenciSifeOlustur
            // 
            this.btnOgrenciSifeOlustur.Location = new System.Drawing.Point(234, 222);
            this.btnOgrenciSifeOlustur.Name = "btnOgrenciSifeOlustur";
            this.btnOgrenciSifeOlustur.Size = new System.Drawing.Size(20, 20);
            this.btnOgrenciSifeOlustur.TabIndex = 9;
            this.btnOgrenciSifeOlustur.Text = "R";
            this.btnOgrenciSifeOlustur.UseVisualStyleBackColor = true;
            this.btnOgrenciSifeOlustur.Click += new System.EventHandler(this.btnOgrenciSifeOlustur_Click);
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(7, 173);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(79, 13);
            this.label20.TabIndex = 9;
            this.label20.Text = "Sınıf Kademesi:";
            // 
            // txtOgrenciKademe
            // 
            this.txtOgrenciKademe.Location = new System.Drawing.Point(118, 170);
            this.txtOgrenciKademe.MaxLength = 2;
            this.txtOgrenciKademe.Name = "txtOgrenciKademe";
            this.txtOgrenciKademe.Size = new System.Drawing.Size(71, 20);
            this.txtOgrenciKademe.TabIndex = 6;
            // 
            // gbVeli
            // 
            this.gbVeli.Controls.Add(this.mtxtVeliIsTel);
            this.gbVeli.Controls.Add(this.mtxtVeliTel);
            this.gbVeli.Controls.Add(this.btnVeliSifreOlustur);
            this.gbVeli.Controls.Add(this.label21);
            this.gbVeli.Controls.Add(this.label14);
            this.gbVeli.Controls.Add(this.txtVeliTcKimlik);
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
            this.gbVeli.Location = new System.Drawing.Point(278, 12);
            this.gbVeli.Name = "gbVeli";
            this.gbVeli.Size = new System.Drawing.Size(278, 357);
            this.gbVeli.TabIndex = 3;
            this.gbVeli.TabStop = false;
            this.gbVeli.Text = "Veli";
            // 
            // mtxtVeliIsTel
            // 
            this.mtxtVeliIsTel.Location = new System.Drawing.Point(83, 118);
            this.mtxtVeliIsTel.Mask = "(999) 000-0000";
            this.mtxtVeliIsTel.Name = "mtxtVeliIsTel";
            this.mtxtVeliIsTel.Size = new System.Drawing.Size(138, 20);
            this.mtxtVeliIsTel.TabIndex = 24;
            // 
            // mtxtVeliTel
            // 
            this.mtxtVeliTel.Location = new System.Drawing.Point(83, 92);
            this.mtxtVeliTel.Mask = "(999) 000-0000";
            this.mtxtVeliTel.Name = "mtxtVeliTel";
            this.mtxtVeliTel.Size = new System.Drawing.Size(138, 20);
            this.mtxtVeliTel.TabIndex = 23;
            // 
            // btnVeliSifreOlustur
            // 
            this.btnVeliSifreOlustur.Location = new System.Drawing.Point(201, 325);
            this.btnVeliSifreOlustur.Name = "btnVeliSifreOlustur";
            this.btnVeliSifreOlustur.Size = new System.Drawing.Size(20, 20);
            this.btnVeliSifreOlustur.TabIndex = 31;
            this.btnVeliSifreOlustur.Text = "R";
            this.btnVeliSifreOlustur.UseVisualStyleBackColor = true;
            this.btnVeliSifreOlustur.Click += new System.EventHandler(this.btnVeliSifreOlustur_Click);
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(6, 16);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(71, 13);
            this.label21.TabIndex = 1;
            this.label21.Text = "TC Kimlik No:";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(6, 42);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(45, 13);
            this.label14.TabIndex = 1;
            this.label14.Text = "Veli Adı:";
            // 
            // txtVeliTcKimlik
            // 
            this.txtVeliTcKimlik.Location = new System.Drawing.Point(83, 13);
            this.txtVeliTcKimlik.MaxLength = 11;
            this.txtVeliTcKimlik.Name = "txtVeliTcKimlik";
            this.txtVeliTcKimlik.Size = new System.Drawing.Size(138, 20);
            this.txtVeliTcKimlik.TabIndex = 20;
            // 
            // txtVeliAdi
            // 
            this.txtVeliAdi.Location = new System.Drawing.Point(83, 39);
            this.txtVeliAdi.MaxLength = 16;
            this.txtVeliAdi.Name = "txtVeliAdi";
            this.txtVeliAdi.Size = new System.Drawing.Size(138, 20);
            this.txtVeliAdi.TabIndex = 21;
            this.txtVeliAdi.TextChanged += new System.EventHandler(this.txtVeliAdi_TextChanged);
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(6, 329);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(61, 13);
            this.label17.TabIndex = 13;
            this.label17.Text = "Giriş Şifresi:";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(6, 224);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(15, 13);
            this.label13.TabIndex = 13;
            this.label13.Text = "İl:";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(6, 247);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(27, 13);
            this.label12.TabIndex = 12;
            this.label12.Text = "İlçe:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(6, 68);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(62, 13);
            this.label9.TabIndex = 6;
            this.label9.Text = "Veli Soyadı:";
            // 
            // txtVeliSifre
            // 
            this.txtVeliSifre.Location = new System.Drawing.Point(83, 325);
            this.txtVeliSifre.MaxLength = 16;
            this.txtVeliSifre.Name = "txtVeliSifre";
            this.txtVeliSifre.Size = new System.Drawing.Size(112, 20);
            this.txtVeliSifre.TabIndex = 30;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(6, 276);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(34, 13);
            this.label15.TabIndex = 12;
            this.label15.Text = "Semt:";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(6, 302);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(67, 13);
            this.label16.TabIndex = 12;
            this.label16.Text = "Email Adresi:";
            // 
            // txtVeliEmail
            // 
            this.txtVeliEmail.Location = new System.Drawing.Point(83, 299);
            this.txtVeliEmail.MaxLength = 255;
            this.txtVeliEmail.Name = "txtVeliEmail";
            this.txtVeliEmail.Size = new System.Drawing.Size(138, 20);
            this.txtVeliEmail.TabIndex = 29;
            this.txtVeliEmail.Text = "@bilgekoleji.com";
            // 
            // txtVeliSemt
            // 
            this.txtVeliSemt.Location = new System.Drawing.Point(83, 273);
            this.txtVeliSemt.MaxLength = 35;
            this.txtVeliSemt.Name = "txtVeliSemt";
            this.txtVeliSemt.Size = new System.Drawing.Size(138, 20);
            this.txtVeliSemt.TabIndex = 28;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(6, 121);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(63, 13);
            this.label8.TabIndex = 8;
            this.label8.Text = "İş Telefonu:";
            // 
            // txtVeliSehir
            // 
            this.txtVeliSehir.Location = new System.Drawing.Point(83, 221);
            this.txtVeliSehir.MaxLength = 35;
            this.txtVeliSehir.Name = "txtVeliSehir";
            this.txtVeliSehir.Size = new System.Drawing.Size(138, 20);
            this.txtVeliSehir.TabIndex = 26;
            // 
            // txtVeliIlce
            // 
            this.txtVeliIlce.Location = new System.Drawing.Point(83, 247);
            this.txtVeliIlce.MaxLength = 35;
            this.txtVeliIlce.Name = "txtVeliIlce";
            this.txtVeliIlce.Size = new System.Drawing.Size(138, 20);
            this.txtVeliIlce.TabIndex = 27;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(6, 95);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(68, 13);
            this.label10.TabIndex = 8;
            this.label10.Text = "Ev Telefonu:";
            // 
            // txtVeliSoyadi
            // 
            this.txtVeliSoyadi.Location = new System.Drawing.Point(83, 65);
            this.txtVeliSoyadi.MaxLength = 16;
            this.txtVeliSoyadi.Name = "txtVeliSoyadi";
            this.txtVeliSoyadi.Size = new System.Drawing.Size(138, 20);
            this.txtVeliSoyadi.TabIndex = 22;
            this.txtVeliSoyadi.TextChanged += new System.EventHandler(this.txtVeliAdi_TextChanged);
            // 
            // txtVeliAdres
            // 
            this.txtVeliAdres.Location = new System.Drawing.Point(83, 144);
            this.txtVeliAdres.MaxLength = 150;
            this.txtVeliAdres.Multiline = true;
            this.txtVeliAdres.Name = "txtVeliAdres";
            this.txtVeliAdres.Size = new System.Drawing.Size(186, 71);
            this.txtVeliAdres.TabIndex = 25;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(6, 144);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(55, 13);
            this.label11.TabIndex = 9;
            this.label11.Text = "Ev Adresi:";
            // 
            // gbSinif
            // 
            this.gbSinif.Controls.Add(this.comboOgrenciSinif);
            this.gbSinif.Controls.Add(this.label18);
            this.gbSinif.Location = new System.Drawing.Point(12, 260);
            this.gbSinif.Name = "gbSinif";
            this.gbSinif.Size = new System.Drawing.Size(260, 48);
            this.gbSinif.TabIndex = 1;
            this.gbSinif.TabStop = false;
            this.gbSinif.Text = "Zorunlu Olamayan Alanlar";
            // 
            // comboOgrenciSinif
            // 
            this.comboOgrenciSinif.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboOgrenciSinif.FormattingEnabled = true;
            this.comboOgrenciSinif.Location = new System.Drawing.Point(117, 20);
            this.comboOgrenciSinif.Name = "comboOgrenciSinif";
            this.comboOgrenciSinif.Size = new System.Drawing.Size(137, 21);
            this.comboOgrenciSinif.TabIndex = 11;
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(6, 18);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(30, 13);
            this.label18.TabIndex = 1;
            this.label18.Text = "Sınıf:";
            // 
            // gbVeliSecimi
            // 
            this.gbVeliSecimi.Controls.Add(this.label19);
            this.gbVeliSecimi.Controls.Add(this.comboVeliSec);
            this.gbVeliSecimi.Controls.Add(this.rbVeliOlustur);
            this.gbVeliSecimi.Controls.Add(this.rbVeliKayitli);
            this.gbVeliSecimi.Location = new System.Drawing.Point(12, 308);
            this.gbVeliSecimi.Name = "gbVeliSecimi";
            this.gbVeliSecimi.Size = new System.Drawing.Size(260, 61);
            this.gbVeliSecimi.TabIndex = 2;
            this.gbVeliSecimi.TabStop = false;
            this.gbVeliSecimi.Text = "Veli Seçimi";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(6, 34);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(49, 13);
            this.label19.TabIndex = 18;
            this.label19.Text = "Veli Seç:";
            // 
            // comboVeliSec
            // 
            this.comboVeliSec.FormattingEnabled = true;
            this.comboVeliSec.Location = new System.Drawing.Point(117, 31);
            this.comboVeliSec.Name = "comboVeliSec";
            this.comboVeliSec.Size = new System.Drawing.Size(138, 21);
            this.comboVeliSec.TabIndex = 17;
            // 
            // rbVeliOlustur
            // 
            this.rbVeliOlustur.AutoSize = true;
            this.rbVeliOlustur.Location = new System.Drawing.Point(118, 13);
            this.rbVeliOlustur.Name = "rbVeliOlustur";
            this.rbVeliOlustur.Size = new System.Drawing.Size(66, 17);
            this.rbVeliOlustur.TabIndex = 16;
            this.rbVeliOlustur.TabStop = true;
            this.rbVeliOlustur.Text = "Yeni Veli";
            this.rbVeliOlustur.UseVisualStyleBackColor = true;
            this.rbVeliOlustur.CheckedChanged += new System.EventHandler(this.rbVeliOlustur_CheckedChanged);
            // 
            // rbVeliKayitli
            // 
            this.rbVeliKayitli.AutoSize = true;
            this.rbVeliKayitli.Location = new System.Drawing.Point(9, 13);
            this.rbVeliKayitli.Name = "rbVeliKayitli";
            this.rbVeliKayitli.Size = new System.Drawing.Size(72, 17);
            this.rbVeliKayitli.TabIndex = 15;
            this.rbVeliKayitli.TabStop = true;
            this.rbVeliKayitli.Text = "Kayıtlı Veli";
            this.rbVeliKayitli.UseVisualStyleBackColor = true;
            this.rbVeliKayitli.CheckedChanged += new System.EventHandler(this.rbVeliOlustur_CheckedChanged);
            // 
            // btnKaydet
            // 
            this.btnKaydet.Location = new System.Drawing.Point(146, 375);
            this.btnKaydet.Name = "btnKaydet";
            this.btnKaydet.Size = new System.Drawing.Size(248, 29);
            this.btnKaydet.TabIndex = 40;
            this.btnKaydet.Text = "Kaydet";
            this.btnKaydet.UseVisualStyleBackColor = true;
            this.btnKaydet.Click += new System.EventHandler(this.btnKaydet_Click);
            // 
            // frmAltOgrenciEkle
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(569, 411);
            this.Controls.Add(this.btnKaydet);
            this.Controls.Add(this.gbVeliSecimi);
            this.Controls.Add(this.gbSinif);
            this.Controls.Add(this.gbVeli);
            this.Controls.Add(this.gbOgrenci);
            this.Name = "frmAltOgrenciEkle";
            this.Text = "frmAltOgrenciEkle";
            this.Load += new System.EventHandler(this.frmAltOgrenciEkle_Load);
            this.gbOgrenci.ResumeLayout(false);
            this.gbOgrenci.PerformLayout();
            this.gbVeli.ResumeLayout(false);
            this.gbVeli.PerformLayout();
            this.gbSinif.ResumeLayout(false);
            this.gbSinif.PerformLayout();
            this.gbVeliSecimi.ResumeLayout(false);
            this.gbVeliSecimi.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox txtOgrenciAdi;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtOgrenciSoyadi;
        private System.Windows.Forms.ComboBox comboOgrenciCinsiyet;
        private System.Windows.Forms.TextBox txtOgrenciMezunOkul;
        private System.Windows.Forms.TextBox txtOgrenciMezuniyetNotu;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtOgrenciMail;
        private System.Windows.Forms.TextBox txtOgrenciSifre;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.GroupBox gbOgrenci;
        private System.Windows.Forms.Button btnOgrenciSifeOlustur;
        private System.Windows.Forms.GroupBox gbVeli;
        private System.Windows.Forms.Button btnVeliSifreOlustur;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox txtVeliAdi;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.TextBox txtVeliSifre;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtVeliEmail;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtVeliSehir;
        private System.Windows.Forms.TextBox txtVeliSemt;
        private System.Windows.Forms.TextBox txtVeliIlce;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtVeliSoyadi;
        private System.Windows.Forms.TextBox txtVeliAdres;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.GroupBox gbSinif;
        private System.Windows.Forms.ComboBox comboOgrenciSinif;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.GroupBox gbVeliSecimi;
        private System.Windows.Forms.Button btnKaydet;
        private System.Windows.Forms.MaskedTextBox mtxtVeliIsTel;
        private System.Windows.Forms.MaskedTextBox mtxtVeliTel;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.ComboBox comboVeliSec;
        private System.Windows.Forms.RadioButton rbVeliOlustur;
        private System.Windows.Forms.RadioButton rbVeliKayitli;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.TextBox txtOgrenciKademe;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.TextBox txtVeliTcKimlik;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.TextBox txtOgrenciTcKimlik;
    }
}