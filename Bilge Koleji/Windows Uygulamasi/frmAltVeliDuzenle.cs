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
    public partial class frmAltVeliDuzenle : Form
    {
        string VeriID;
        SqlConnection conn = dbIslem.baglantiOlustur();
        Kullanici kln = new Kullanici();

        public frmAltVeliDuzenle(string _veriID)
        {
            InitializeComponent();
            VeriID = _veriID;
        }

        private void frmAltVeliDuzenle_Load(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("SELECT * FROM Veliler v JOIN aspnet_Membership am ON v.VeliID=am.UserId WHERE VeliID = @VeliID", conn);
            cmd.Parameters.AddWithValue("@VeliID", VeriID);
            conn.Open();
            SqlDataReader sdr = cmd.ExecuteReader();
            if (sdr.HasRows)
            {
                sdr.Read();
                txtVeliAdi.Text = sdr["VeliAdi"].ToString();
                txtVeliSoyadi.Text = sdr["VeliSoyadi"].ToString();
                mtxtVeliTel.Text = sdr["EvTelefonu"].ToString();
                mtxtVeliIsTel.Text = sdr["IsTelefonu"].ToString();
                txtVeliAdres.Text = sdr["EvAdresi"].ToString();
                txtVeliSehir.Text = sdr["Sehir"].ToString();
                txtVeliIlce.Text = sdr["Ilce"].ToString();
                txtVeliSemt.Text = sdr["Mahalle"].ToString();
                txtVeliEmail.Text = sdr["Email"].ToString();
            }
            conn.Close();
        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            HataTutucu ht = new HataTutucu();
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
                if (dbIslem.aynisiVarmi("aspnet_Membership", "!UserId", "Email", VeriID, txtVeliEmail.Text))
                    ht.hataEkle(txtVeliEmail.Text + ", mail adresiyle zaten kayıt yapılmış");
            if (txtVeliSifre.Text.Length < 6 & txtVeliSifre.Text.Length > 0)
                ht.hataEkle("Veli şifresi 6 karakterden az olamaz");
            if (ht.HataVarMi)
            {
                ht.HatalariGoster();
            }
            else
            {
                GuidConverter gc = new GuidConverter();
                Object UserID = gc.ConvertFromString(VeriID);
                MembershipUser muUye = Membership.GetUser(UserID);
                muUye.Email = txtVeliEmail.Text;
                if (txtVeliSifre.Text.Length > 0)
                {
                    string yeniSifre = muUye.ResetPassword();
                    bool degistiMi = muUye.ChangePassword(yeniSifre, txtVeliSifre.Text);
                }
                Membership.UpdateUser(muUye);
                if (muUye != null)
                {
                    string IsTel = "";
                    if (mtxtVeliIsTel.Text != "(   )    -")
                        IsTel = mtxtVeliIsTel.Text;
                    dbIslem.dbHizliGuncelle("Veliler", "VeliID", VeriID, "VeliAdi", "VeliSoyadi", "EvTelefonu", "IsTelefonu", "EvAdresi", "Sehir", "Ilce", "Mahalle", txtVeliAdi.Text, txtVeliSoyadi.Text, mtxtVeliTel.Text, IsTel, txtVeliAdres.Text, txtVeliSehir.Text, txtVeliIlce.Text, txtVeliSemt.Text);
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
