using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Windows_Uygulamasi
{
    public partial class frmAltAyarlar : Form
    {
        SqlConnection conn = dbIslem.baglantiOlustur();

        public frmAltAyarlar()
        {
            InitializeComponent();
        }

        private void frmAltAyarlar_Load(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("SELECT * FROM Ayarlar ", conn);
            conn.Open();
            SqlDataReader sdr = cmd.ExecuteReader();
            if (sdr.HasRows)
            {
                sdr.Read();
                txtOkulAdi.Text = sdr["OkulAdi"].ToString();
                txtAdres.Text = sdr["OkulAdres"].ToString();
                mtxtTel.Text = sdr["OkulTel"].ToString();
                mtxtTel2.Text = sdr["OkulTel2"].ToString();
                mtxtFax.Text = sdr["OkulFax"].ToString();
                txtEMail.Text = sdr["OkulMail"].ToString();
                txtWeb.Text = sdr["OkulWeb"].ToString();
            }
            else
            {
                txtWeb.Text = "http://";
            }
            conn.Close();
        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            Kullanici kln = new Kullanici();
            HataTutucu ht = new HataTutucu();
            if (txtOkulAdi.Text.Length < 3)
                ht.hataEkle("Okul adı en az 3 karakter olmalı");
            if (txtAdres.Text.Length < 3)
                ht.hataEkle("Okul adresi en az 3 karakter olmalı");
            if (!kln.TelKontrol(mtxtTel.Text))
                ht.hataEkle("1.Telefon numarası hatalı");
            if (mtxtTel2.Text != "(   )    -")
                if (!kln.TelKontrol(mtxtTel2.Text))
                    ht.hataEkle("2.Telefon numarası hatalı");
            if (mtxtFax.Text != "(   )    -")
                if (!kln.TelKontrol(mtxtFax.Text))
                    ht.hataEkle("Fax numarası hatalı");
            if (txtEMail.Text.Length == 1)
                ht.hataEkle("Email adresini yazmadınız");
            else
                if (!kln.EmailKontrol(txtEMail.Text))
                    ht.hataEkle("Email adresini hatalı yazdınız");
            if (txtWeb.Text.Length == 0)
                ht.hataEkle("Web adresini yazmadınız");
            else
                if (!kln.UrlKontrol(txtWeb.Text))
                    ht.hataEkle("Web adresini hatalı yazdınız");
            if (ht.HataVarMi)
            {
                ht.HatalariGoster();
            }
            else
            {
                SqlCommand cmd = new SqlCommand("SELECT * FROM Ayarlar ", conn);
                conn.Open();
                SqlDataReader sdr = cmd.ExecuteReader();
                if (sdr.HasRows)
                {
                    dbIslem.dbHizliGuncelle("Ayarlar", null, null, "OkulAdi", "OkulAdres", "OkulTel", "OkulTel2", "OkulFax", "OkulMail", "OkulWeb", txtOkulAdi.Text, txtAdres.Text, mtxtTel.Text, mtxtTel2.Text, mtxtFax.Text, txtEMail.Text, txtWeb.Text);
                }
                else
                {
                    dbIslem.dbEkleVeriIslem("Ayarlar", null, null, "OkulAdi", "OkulAdres", "OkulTel", "OkulTel2", "OkulFax", "OkulMail", "OkulWeb", txtOkulAdi.Text, txtAdres.Text, mtxtTel.Text, mtxtTel2.Text, mtxtFax.Text, txtEMail.Text, txtWeb.Text);
                }
                conn.Close();
                this.Close();
            }
        }
    }
}
