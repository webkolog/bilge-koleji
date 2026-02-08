using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Web.Security;

namespace Windows_Uygulamasi
{
    public partial class frmAltOgrenciEkle : Form
    {
        SqlConnection conn = dbIslem.baglantiOlustur();
        Kullanici kln = new Kullanici();

        public frmAltOgrenciEkle()
        {
            InitializeComponent();
        }

        private void frmAltOgrenciEkle_Load(object sender, EventArgs e)
        {
            for (int i = 0; i <= 1; i++)
            {
                VeriTututucu vt = new VeriTututucu();
                vt.veriID = i.ToString();
                vt.VeriAdi = i == 0 ? "Erkek" : "Bayan";
                comboOgrenciCinsiyet.Items.Add(vt);
            }
            SqlCommand cmd = new SqlCommand("SELECT s.DerslikID, * FROM Siniflar s JOIN Derslikler d ON s.DerslikID = d.DerslikID ORDER BY Kademe, Sube", conn);
            conn.Open();
            SqlDataReader sdr = cmd.ExecuteReader();
            while (sdr.Read())
            {
                int bosYer = (Convert.ToInt32(sdr["Kapasite"]) - Convert.ToInt32(dbIslem.KayitToplami("Ogrenciler", "SinifID", "SinifID", sdr["SinifID"].ToString())));
                VeriTututucu vt = new VeriTututucu();
                vt.veriID = sdr["SinifID"].ToString();
                vt.VeriAdi = sdr["Kademe"] + " " + sdr["Sube"] + "  => Boşluk: " + bosYer + " kişi";
                if (bosYer > 0)
                    comboOgrenciSinif.Items.Add(vt);
            }
            conn.Close();
            rbVeliOlustur.Checked = true;
            comboVeliSec.Enabled = false;
            cmd = new SqlCommand("SELECT * FROM Veliler ORDER BY VeliAdi, VeliSoyadi", conn);
            conn.Open();
            sdr = cmd.ExecuteReader();
            while (sdr.Read())
            {
                VeriTututucu vt = new VeriTututucu();
                vt.veriID = sdr["VeliID"].ToString();
                vt.VeriAdi = sdr["VeliAdi"] + " " + sdr["VeliSoyadi"];
                comboVeliSec.Items.Add(vt);
            }
            conn.Close();

            //----------------------------------------------------------
            //----------------------------------------------------------
            //----------------------------------------------------------
            //txtOgrenciAdi.Text = "OgrenciAd";
            //txtOgrenciSoyadi.Text = "Soyad";
            comboOgrenciCinsiyet.SelectedIndex = 0;
            txtOgrenciMezunOkul.Text = "Test";
            txtOgrenciMezuniyetNotu.Text = "12.4";
            //txtOgrenciKademe.Text = "9";
            //txtOgrenciMail.Text = "ogrenci.mail@bilgekoleji.com";
            txtOgrenciSifre.Text = "123456";

            //txtVeliAdi.Text = "VeliAd";
            //txtVeliSoyadi.Text = "Soyad";
            mtxtVeliTel.Text = "1234567890";
            //mtxtVeliIsTel.Text = "1234567890";
            txtVeliAdres.Text = "Test";
            txtVeliSehir.Text = "Test";
            txtVeliIlce.Text = "Test";
            txtVeliSemt.Text = "Test";
            //txtVeliEmail.Text = "veli.mail@bilgekoleji.com";
            txtVeliSifre.Text = "123456";

            //----------------------------------------------------------
            //----------------------------------------------------------
            //----------------------------------------------------------
        }

        private void rbVeliOlustur_CheckedChanged(object sender, EventArgs e)
        {
            if (rbVeliKayitli.Checked)
            {
                comboVeliSec.Enabled = true;
                gbVeli.Enabled = false;
            }
            else
            {
                comboVeliSec.Enabled = false;
                gbVeli.Enabled = true;
            }
        }

        private void btnOgrenciSifeOlustur_Click(object sender, EventArgs e)
        {
            txtOgrenciSifre.Text = kln.SifreOlusturucu(8);
        }

        private void btnVeliSifreOlustur_Click(object sender, EventArgs e)
        {
            txtVeliSifre.Text = kln.SifreOlusturucu(8);
        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            HataTutucu ht = new HataTutucu();
            float mezuniyetNotu = 0;
            byte mezuniyetKademe;
            if (!kln.TcKimlikKontrol(txtOgrenciTcKimlik.Text))
                ht.hataEkle("Öğrenci TC kimlik nosunu hatalı yazdınız");
            else
                if (dbIslem.aynisiVarmi("aspnet_Users", "UserName", txtOgrenciTcKimlik.Text))
                    ht.hataEkle("Öğrenci " + txtOgrenciTcKimlik.Text + ", nolu TC Kimlik nosu ile zaten kayıt yapılmış");
            if (txtOgrenciAdi.Text.Length < 2)
                ht.hataEkle("Öğrenci adı 2 karakterden az olamaz");
            if (txtOgrenciSoyadi.Text.Length < 2)
                ht.hataEkle("Öğrenci soyadı 2 karakterden az olamaz");
            if (comboOgrenciCinsiyet.SelectedIndex == -1)
                ht.hataEkle("Öğrenci cinsiyetini seçmediniz");
            if (txtOgrenciMezunOkul.Text.Length < 3)
                ht.hataEkle("Öğrencinin mezun olduğu okul 3 karakterden az olamaz");
            try
            {
                mezuniyetNotu = Convert.ToSingle(txtOgrenciMezuniyetNotu.Text);
                if (txtOgrenciMezuniyetNotu.Text.IndexOf(",") > -1)
                    throw new Exception("Hatalı yazım");
            }
            catch
            {
                ht.hataEkle("Mezuniyet notunu hatalı yazdınız");
            }
            try
            {
                mezuniyetKademe = Convert.ToByte(txtOgrenciKademe.Text);
            }
            catch
            {
                ht.hataEkle("Sınıf Kademesini hatalı yazdınız");
            }
            if (!kln.EmailKontrol(txtOgrenciMail.Text))
                ht.hataEkle("Öğrenci mail'i hatalı");
            else
                if (dbIslem.aynisiVarmi("aspnet_Membership", "Email", txtOgrenciMail.Text))
                    ht.hataEkle(txtOgrenciMail.Text + ", mail adresiyle zaten kayıt yapılmış");
            if (txtOgrenciSifre.Text.Length < 6)
                ht.hataEkle("Öğrenci şifresi 6 karakterden az olamaz");
            if (rbVeliKayitli.Checked)
            {
                if (comboVeliSec.SelectedIndex == -1)
                    ht.hataEkle("Veli seçmediniz");
            }
            else
            {
                if (!kln.TcKimlikKontrol(txtVeliTcKimlik.Text))
                    ht.hataEkle("Veli TC kimlik nosunu hatalı yazdınız");
                else
                    if (dbIslem.aynisiVarmi("aspnet_Users", "UserName", txtVeliTcKimlik.Text))
                        ht.hataEkle("Velinin " + txtVeliTcKimlik.Text + ", nolu TC Kimlik nosu ile zaten kayıt yapılmış");
                if (txtOgrenciTcKimlik.Text == txtVeliTcKimlik.Text)
                    ht.hataEkle("Öğrenci ile Veli TC kimlik nosu aynı");
                if (txtVeliAdi.Text.Length < 2)
                    ht.hataEkle("Veli adı 2 karakterden az olamaz");
                if (txtVeliSoyadi.Text.Length < 2)
                    ht.hataEkle("Veli soyadı 2 karakterden az olamaz");
                if (!kln.TelKontrol(mtxtVeliTel.Text))
                    ht.hataEkle("Veli ev telefonu hatalı");
                if (mtxtVeliIsTel.Text != "(   )    -" & !kln.TelKontrol(mtxtVeliIsTel.Text))
                    ht.hataEkle("Veli iş telefonu hatalı");
                if (txtVeliAdres.Text.Length < 3)
                    ht.hataEkle("Veli adresi 3 karakterden az olamaz");
                if (txtVeliSehir.Text.Length < 3)
                    ht.hataEkle("Veli il 3 karakterden az olamaz");
                if (txtVeliIlce.Text.Length < 3)
                    ht.hataEkle("Veli ilçe 3 karakterden az olamaz");
                if (txtVeliSemt.Text.Length < 3)
                    ht.hataEkle("Veli semt 3 karakterden az olamaz");
                if (!kln.EmailKontrol(txtVeliEmail.Text))
                    ht.hataEkle("Veli mail'i hatalı");
                else
                    if (dbIslem.aynisiVarmi("aspnet_Membership", "Email", txtVeliEmail.Text))
                        ht.hataEkle(txtVeliEmail.Text + ", mail adresiyle zaten kayıt yapılmış");
                if (txtVeliSifre.Text.Length < 6)
                    ht.hataEkle("Veli şifresi 6 karakterden az olamaz");
            }
            if (ht.HataVarMi)
            {
                ht.HatalariGoster();
            }
            else
            {
                string sinifID = "0", Donem1 = null, OgrenciNo = null;
                int sonOkulNo = 0;
                SqlCommand cmd = new SqlCommand("SELECT * FROM Sezonlar ORDER BY SezonID DESC", conn);
                conn.Open();
                SqlDataReader sdr = cmd.ExecuteReader();
                if (sdr.HasRows)
                {
                    sdr.Read();
                    Donem1 = sdr["Donem1"].ToString();
                }
                else
                {
                    MessageBox.Show("Sezon oluşturmadan öğrenci ekelenemez!");
                    return;
                }
                conn.Close();
                cmd = new SqlCommand("SELECT * FROM Ogrenciler WHERE KayitYili=" + Donem1 + " ORDER BY OkulNo DESC", conn);
                conn.Open();
                sdr = cmd.ExecuteReader();
                if (sdr.HasRows)
                {
                    sdr.Read();
                    sonOkulNo = Convert.ToInt32(sdr["OkulNo"]);
                }
                conn.Close();
                if (sonOkulNo < 100)
                    sonOkulNo = 100;
                else
                    sonOkulNo += 2;
                OgrenciNo = sonOkulNo.ToString();
                if (comboOgrenciSinif.SelectedIndex != -1)
                    sinifID = (comboOgrenciSinif.SelectedItem as VeriTututucu).veriID;
                string RolID = "";
                MembershipUser mOgrenci = Membership.CreateUser(txtOgrenciTcKimlik.Text, txtOgrenciSifre.Text, txtOgrenciMail.Text);
                if (mOgrenci != null)
                {
                    RolID = dbIslem.tekVeriCek("aspnet_Roles", "RoleName", "Öğrenci", "RoleId");
                    dbIslem.dbEkleVeriIslem("aspnet_UsersInRoles", null, null, "UserId", "RoleId", mOgrenci.ProviderUserKey.ToString(), RolID);
                    if (rbVeliKayitli.Checked)
                    {
                        //VeliID ile
                        dbIslem.dbEkleVeriIslem("Ogrenciler", null, null, "OgrenciID", "OkulNo", "KayitYili", "OgrenciAdi", "OgrenciSoyadi", "Cinsiyet", "DevamEdiyorMu", "BitirdigiOkul", "NotOrtalamasi", "VeliID", "SinifID", "Kademe", mOgrenci.ProviderUserKey.ToString(), OgrenciNo, Donem1, txtOgrenciAdi.Text, txtOgrenciSoyadi.Text, (comboOgrenciCinsiyet.SelectedItem as VeriTututucu).veriID, "true", txtOgrenciMezunOkul.Text, txtOgrenciMezuniyetNotu.Text, (comboVeliSec.SelectedItem as VeriTututucu).veriID, sinifID, txtOgrenciKademe.Text);
                    }
                    else
                    {
                        //veliOlusturarak
                        MembershipUser mVeli = Membership.CreateUser(txtVeliTcKimlik.Text,txtVeliSifre.Text, txtVeliEmail.Text);
                        RolID = dbIslem.tekVeriCek("aspnet_Roles", "RoleName", "Veli", "RoleId");
                        dbIslem.dbEkleVeriIslem("aspnet_UsersInRoles", null, null, "UserId", "RoleId", mVeli.ProviderUserKey.ToString(), RolID);
                        string IsTel = "";
                        if (mtxtVeliIsTel.Text != "(   )    -")
                            IsTel = mtxtVeliIsTel.Text;
                        dbIslem.dbEkleVeriIslem("Veliler", null, null, "VeliID", "VeliAdi", "VeliSoyadi", "EvTelefonu", "IsTelefonu", "EvAdresi", "Sehir", "Ilce", "Mahalle", mVeli.ProviderUserKey.ToString(), txtVeliAdi.Text, txtVeliSoyadi.Text, mtxtVeliTel.Text, IsTel, txtVeliAdres.Text, txtVeliSehir.Text, txtVeliIlce.Text, txtVeliSemt.Text);
                        dbIslem.dbEkleVeriIslem("Ogrenciler", null, null, "OgrenciID", "OkulNo", "KayitYili", "OgrenciAdi", "OgrenciSoyadi", "Cinsiyet", "DevamEdiyorMu", "BitirdigiOkul", "NotOrtalamasi", "VeliID", "SinifID", "Kademe", mOgrenci.ProviderUserKey.ToString(), OgrenciNo, Donem1, txtOgrenciAdi.Text, txtOgrenciSoyadi.Text, (comboOgrenciCinsiyet.SelectedItem as VeriTututucu).veriID, "true", txtOgrenciMezunOkul.Text, txtOgrenciMezuniyetNotu.Text, mVeli.ProviderUserKey.ToString(), sinifID, txtOgrenciKademe.Text);
                    }
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

        private void txtOgrenciSoyadi_TextChanged(object sender, EventArgs e)
        {
            txtOgrenciMail.Text = kln.mailOlusturucu(txtOgrenciAdi.Text, txtOgrenciSoyadi.Text);
        }

        private void txtVeliAdi_TextChanged(object sender, EventArgs e)
        {
            txtVeliEmail.Text = kln.mailOlusturucu(txtVeliAdi.Text, txtVeliSoyadi.Text);
        }
    }
}
