using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Collections;
using System.Web.Security;

namespace Windows_Uygulamasi
{
    public partial class frmAltOgretmenEkle : Form
    {
        SqlConnection conn = dbIslem.baglantiOlustur();
        Kullanici kln = new Kullanici();
        public frmAltOgretmenEkle()
        {
            InitializeComponent();
        }

        private void frmAltOgretmenEkle_Load(object sender, EventArgs e)
        {
            for (int i = 0; i < 3; i++)
            {
                VeriTututucu vt = new VeriTututucu();
                vt.veriID = i.ToString();
                switch (i)
                {
                    case 0:
                        vt.VeriAdi = "Öğretmen";
                        break;
                    case 1:
                        vt.VeriAdi = "Müdür";
                        break;
                    case 2:
                        vt.VeriAdi = "Müdür Yardımcısı";
                        break;
                }
                comboGorev.Items.Add(vt);
            }
            SqlCommand cmd = new SqlCommand("SELECT * FROM AnaDersler ORDER BY DersAdi ASC", conn);
            conn.Open();
            SqlDataReader sdr = cmd.ExecuteReader();
            while (sdr.Read())
            {
                VeriTututucu vt = new VeriTututucu();
                vt.VeriAdi = sdr["DersAdi"].ToString();
                vt.veriID = sdr["AnaDersID"].ToString();
                comboBrans.Items.Add(vt);
            }
            conn.Close();
        }

        private void BtnRandomSifre_Click(object sender, EventArgs e)
        {
            txtSifre.Text = kln.SifreOlusturucu(8);
        }

        private void BtnKaydet_Click(object sender, EventArgs e)
        {
            HataTutucu ht = new HataTutucu();
            if (!kln.TcKimlikKontrol(txtTcKimlikNo.Text))
                ht.hataEkle("TC kimlik nosunu hatalı yazdınız");
            else
                if (dbIslem.aynisiVarmi("aspnet_Users", "UserName", txtTcKimlikNo.Text))
                    ht.hataEkle(txtTcKimlikNo.Text + ", nolu TC Kimlik nosu ile zaten kayıt yapılmış");
            if (txtAdi.Text.Length < 2)
                ht.hataEkle("İsim en az 2 karakter olmalı");
            if (txtSoyadi.Text.Length < 2)
                ht.hataEkle("Soyad en az 2 karakter olmalı");
            if (comboGorev.SelectedIndex == -1)
                ht.hataEkle("Görev seçmediniz");
            if (comboBrans.SelectedIndex == -1)
                ht.hataEkle("Branş seçmediniz");
            if (!kln.EmailKontrol(txtEMail.Text))
                ht.hataEkle("Email adresini yazmadınız");
            else
                if (dbIslem.aynisiVarmi("aspnet_Membership", "Email", txtEMail.Text))
                    ht.hataEkle(txtEMail.Text + ", mail adresiyle zaten kayıt yapılmış");
            if (txtSifre.Text.Length < 6)
                ht.hataEkle("Şifre en az 6 karakter olmalı");
            if (ht.HataVarMi)
            {
                ht.HatalariGoster();
            }
            else
            {
                string RolID = "";
                MembershipUser muUye = Membership.CreateUser(txtTcKimlikNo.Text, txtSifre.Text, txtEMail.Text);
                if (muUye != null)
                {
                    string gorev = comboGorev.Text;
                    RolID = dbIslem.tekVeriCek("aspnet_Roles", "RoleName", gorev, "RoleId");
                    dbIslem.dbEkleVeriIslem("aspnet_UsersInRoles", null, null, "UserId", "RoleId", muUye.ProviderUserKey.ToString(), RolID);
                    dbIslem.dbEkleVeriIslem("Ogretmenler", null, null, "OgretmenID", "OgretmenAdi", "OgretmenSoyadi", "Gorev", "Brans", muUye.ProviderUserKey.ToString(), txtAdi.Text, txtSoyadi.Text, (comboGorev.SelectedItem as VeriTututucu).veriID, (comboBrans.SelectedItem as VeriTututucu).veriID);
                    (Application.OpenForms[0] as frm_AnaForm).Listele();
                    this.Close();
                }
                else
                {
                    ht.hataEkle("Veri eklenemiyor");
                    ht.HatalariGoster();
                }
            }
        }

        private void txtSoyadi_TextChanged(object sender, EventArgs e)
        {
            txtEMail.Text = kln.mailOlusturucu(txtAdi.Text,txtSoyadi.Text);
        }
    }
}


