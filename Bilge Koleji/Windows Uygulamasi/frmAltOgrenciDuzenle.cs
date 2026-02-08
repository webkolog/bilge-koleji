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
    public partial class frmAltOgrenciDuzenle : Form
    {
        string VeriID;
        SqlConnection conn = dbIslem.baglantiOlustur();
        Kullanici kln = new Kullanici();

        public frmAltOgrenciDuzenle(string _veriID)
        {
            InitializeComponent();
            VeriID = _veriID;
        }

        private void frmAltOgrenciDuzenle_Load(object sender, EventArgs e)
        {
            string SinifiID = dbIslem.tekVeriCek("Ogrenciler", "OgrenciID", VeriID, "SinifID");
            for (int i = 0; i <= 1; i++)
            {
                VeriTututucu vt = new VeriTututucu();
                vt.veriID = i == 0 ? "false" : "true";
                vt.VeriAdi = i == 0 ? "Erkek" : "Bayan";
                comboOgrenciCinsiyet.Items.Add(vt);
            }
            comboOgrenciSinif.Items.Add("");
            SqlCommand cmd = new SqlCommand("SELECT s.DerslikID, * FROM Siniflar s JOIN Derslikler d ON s.DerslikID = d.DerslikID ORDER BY Kademe, Sube", conn);
            conn.Open();
            SqlDataReader sdr = cmd.ExecuteReader();
            while (sdr.Read())
            {
                int bosYer = (Convert.ToInt32(sdr["Kapasite"]) - Convert.ToInt32(dbIslem.KayitToplami("Ogrenciler", "SinifID", "SinifID", sdr["SinifID"].ToString())));
                VeriTututucu vt = new VeriTututucu();
                vt.veriID = sdr["SinifID"].ToString();
                vt.VeriAdi = sdr["Kademe"] + " " + sdr["Sube"] + "  => Boşluk: " + bosYer + " kişi";
                if (bosYer > 0 | SinifiID==sdr["SinifID"].ToString())
                    comboOgrenciSinif.Items.Add(vt);
            }
            conn.Close();
            cmd = new SqlCommand("SELECT o.OgrenciAdi, o.OgrenciSoyadi, o.Cinsiyet, o.BitirdigiOkul, o.NotOrtalamasi, o.Kademe AS oKademe, am.Email, CONVERT(NVARCHAR(2), s.Kademe) + ' ' + s.Sube AS SinifAdi, s.SinifID, s.DerslikID FROM Ogrenciler o JOIN aspnet_Membership am ON o.OgrenciID=am.UserId LEFT JOIN Siniflar s ON s.SinifID=o.SinifID WHERE OgrenciID = @OgrenciID", conn);
            cmd.Parameters.AddWithValue("@OgrenciID", VeriID);
            conn.Open();
            sdr = cmd.ExecuteReader();
            if (sdr.HasRows)
            {
                sdr.Read();
                int bosYer = (Convert.ToInt32(dbIslem.tekVeriCek("Derslikler","DerslikID",sdr["DerslikID"].ToString(),"Kapasite")) - Convert.ToInt32(dbIslem.KayitToplami("Ogrenciler", "SinifID", "SinifID", sdr["SinifID"].ToString())));
                txtOgrenciAdi.Text = sdr["OgrenciAdi"].ToString();
                txtOgrenciSoyadi.Text = sdr["OgrenciSoyadi"].ToString();
                comboOgrenciCinsiyet.SelectedIndex = Convert.ToBoolean(sdr["Cinsiyet"]) ? 1 : 0;
                txtOgrenciMezunOkul.Text = sdr["BitirdigiOkul"].ToString();
                txtOgrenciMezuniyetNotu.Text = sdr["NotOrtalamasi"].ToString().Replace(',', '.');
                txtOgrenciKademe.Text = sdr["oKademe"].ToString();
                txtOgrenciMail.Text = sdr["Email"].ToString();
                comboOgrenciSinif.Text = sdr["SinifAdi"].ToString() + "  => Boşluk: " + bosYer + " kişi";
            }
            conn.Close();
        }

        private void btnOgrenciSifeOlustur_Click(object sender, EventArgs e)
        {
            txtOgrenciSifre.Text = kln.SifreOlusturucu(8);
        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            HataTutucu ht = new HataTutucu();
            float mezuniyetNotu = 0;
            byte mezuniyetKademe;
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
                    throw new Exception("Virgül olmamalı!");
            }
            catch
            {
                ht.hataEkle("Mezuniyet notunu hatalı yazdınız");
            }
            try
            {
                mezuniyetKademe = Convert.ToByte(txtOgrenciKademe.Text);
                if (mezuniyetKademe < 9 | mezuniyetKademe > 12)
                    ht.hataEkle("Sınıf kademesi 9 ile 12 arasında olmadlıdır");
            }
            catch
            {
                ht.hataEkle("Sınıf Kademesini hatalı yazdınız");
            }
            if (!kln.EmailKontrol(txtOgrenciMail.Text))
                ht.hataEkle("Öğrenci mail'i hatalı");
            else
                if (dbIslem.aynisiVarmi("aspnet_Membership", "!UserId", "Email", VeriID, txtOgrenciMail.Text))
                    ht.hataEkle(txtOgrenciMail.Text + ", mail adresiyle zaten kayıt yapılmış");
            if (txtOgrenciSifre.Text.Length < 6 & txtOgrenciSifre.Text.Length > 0)
                ht.hataEkle("Öğrenci şifresi 6 karakterden az olamaz");
            if (ht.HataVarMi)
            {
                ht.HatalariGoster();
            }
            else
            {
                string sinifID = "0";
                if (comboOgrenciSinif.SelectedIndex != -1 & comboOgrenciSinif.SelectedIndex != 0)
                    sinifID = (comboOgrenciSinif.SelectedItem as VeriTututucu).veriID;
                GuidConverter gc = new GuidConverter();
                Object UserID = gc.ConvertFromString(VeriID);
                MembershipUser muUye = Membership.GetUser(UserID);
                muUye.Email = txtOgrenciMail.Text;
                if (txtOgrenciSifre.Text.Length > 0)
                {
                    string yeniSifre = muUye.ResetPassword();
                    bool degistiMi = muUye.ChangePassword(yeniSifre, txtOgrenciSifre.Text);
                }
                Membership.UpdateUser(muUye);
                if (muUye != null)
                {
                    dbIslem.dbHizliGuncelle("Ogrenciler", "OgrenciID", VeriID, "OgrenciAdi", "OgrenciSoyadi", "Cinsiyet", "DevamEdiyorMu", "BitirdigiOkul", "NotOrtalamasi", "SinifID", "Kademe", txtOgrenciAdi.Text, txtOgrenciSoyadi.Text, (comboOgrenciCinsiyet.SelectedItem as VeriTututucu).veriID, "true", txtOgrenciMezunOkul.Text, txtOgrenciMezuniyetNotu.Text, sinifID, txtOgrenciKademe.Text);
                    (Application.OpenForms[0] as frm_AnaForm).Listele();
                    this.Close();
                }
                else
                {
                    ht.hataEkle("Veri güncellenemiyor");
                    ht.HatalariGoster();
                }
            }
        }
    }
}
