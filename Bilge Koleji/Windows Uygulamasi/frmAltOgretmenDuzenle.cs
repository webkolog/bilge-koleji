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
    public partial class frmAltOgretmenDuzenle : Form
    {
        SqlConnection conn = dbIslem.baglantiOlustur();
        Kullanici kln = new Kullanici();
        string veriID;
        public frmAltOgretmenDuzenle(string _veriID)
        {
            InitializeComponent();
            veriID = _veriID;
        }

        private void frmAltOgretmenDuzenle_Load(object sender, EventArgs e)
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
            cmd = new SqlCommand("SELECT o.OgretmenID, o.OgretmenAdi, o.OgretmenSoyadi, CASE o.Gorev WHEN 1 THEN 'Müdür' WHEN 2 THEN 'Müdür Yardımcısı' ELSE 'Öğretmen' END as OgretmenGorev, a.DersAdi as OgretmenBrans, m.Email, m.Password FROM Ogretmenler o LEFT JOIN AnaDersler a ON o.Brans=a.AnaDersID LEFT JOIN aspnet_Membership m ON o.OgretmenID=m.UserId WHERE o.OgretmenID=@OgretmenID", conn);
            cmd.Parameters.AddWithValue("@OgretmenID", veriID);
            conn.Open();
            sdr = cmd.ExecuteReader();
            if (sdr.HasRows)
            {
                sdr.Read();
                txtAdi.Text = sdr["OgretmenAdi"].ToString();
                txtSoyadi.Text = sdr["OgretmenSoyadi"].ToString();
                comboGorev.Text = sdr["OgretmenGorev"].ToString();
                comboBrans.Text = sdr["OgretmenBrans"].ToString();
                txtEMail.Text = sdr["Email"].ToString();
            }
            conn.Close();
        }

        private void BtnKaydet_Click_1(object sender, EventArgs e)
        {
            HataTutucu ht = new HataTutucu();
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
                if (dbIslem.aynisiVarmi("aspnet_Membership", "!UserId", "Email", veriID, txtEMail.Text))
                    ht.hataEkle(txtEMail.Text + ", mail adresiyle zaten bir kayıt mevcut");
            if (txtSifre.Text.Length > 0 & txtSifre.Text.Length < 6)
                ht.hataEkle("Şifre en az 6 karakter olmalı");
            if (ht.HataVarMi)
            {
                ht.HatalariGoster();
            }
            else
            {
                GuidConverter gc = new GuidConverter();
                Object UserID = gc.ConvertFromString(veriID);
                MembershipUser muUye = Membership.GetUser(UserID);
                muUye.Email = txtEMail.Text;
                if (txtSifre.Text.Length > 0)
                {
                    string yeniSifre = muUye.ResetPassword();
                    bool degistiMi = muUye.ChangePassword(yeniSifre, txtSifre.Text);
                }
                Membership.UpdateUser(muUye);
                if (muUye != null)
                {
                    dbIslem.dbHizliGuncelle("Ogretmenler", "OgretmenID", veriID, "OgretmenAdi", "OgretmenSoyadi", "Gorev", "Brans", txtAdi.Text, txtSoyadi.Text, (comboGorev.SelectedItem as VeriTututucu).veriID, (comboBrans.SelectedItem as VeriTututucu).veriID);

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

        private void BtnRandomSifre_Click_1(object sender, EventArgs e)
        {
            txtSifre.Text = kln.SifreOlusturucu(8);
        }
    }
}
