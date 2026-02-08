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
    public partial class frmAltOgrenciGoster : Form
    {
        string OgrenciID;

        public frmAltOgrenciGoster(string _OgrenciID)
        {
            InitializeComponent();
            OgrenciID = _OgrenciID;
        }

        private void frmAltOgrenciGoster_Load(object sender, EventArgs e)
        {
            string VeliID = null;
            SqlConnection conn = dbIslem.baglantiOlustur();
            SqlCommand cmd = new SqlCommand("SELECT CASE o.Cinsiyet WHEN 1 THEN 'Bayan' ELSE 'Erkek' END AS Cins, CASE o.DevamEdiyorMu WHEN 1 THEN 'Devam Ediyor' ELSE 'Devam Etmiyor' END AS Durum, * FROM Ogrenciler o JOIN Siniflar s ON o.SinifID=s.SinifID JOIN aspnet_Users au ON au.UserId=o.OgrenciID WHERE o.OgrenciID = @OgrenciID", conn);
            cmd.Parameters.AddWithValue("@OgrenciID", OgrenciID);
            conn.Open();
            SqlDataReader sdr = cmd.ExecuteReader();
            if (sdr.HasRows)
            {
                sdr.Read();
                lblOgrenciNo.Text = sdr["OkulNo"].ToString();
                lblOgrenciSinif.Text = sdr["Kademe"].ToString() + sdr["Sube"].ToString();
                lblOgrenciTCK.Text = sdr["UserName"].ToString();
                lblOgrenciAdi.Text = sdr["OgrenciAdi"].ToString();
                lblOgrenciSoyadi.Text = sdr["OgrenciSoyadi"].ToString();
                lblOgrenciCinsiyet.Text = sdr["Cins"].ToString();
                lblOgrenciDurum.Text = sdr["Durum"].ToString();
                lblMezuniyetNotu.Text = sdr["NotOrtalamasi"].ToString();
                lblBitirdigiOkul.Text = sdr["BitirdigiOkul"].ToString();
                VeliID = sdr["VeliID"].ToString();
            }
            conn.Close();
            cmd = new SqlCommand("SELECT * FROM Veliler v JOIN aspnet_Users au ON au.UserId=v.VeliID WHERE v.VeliID=@VeliID", conn);
            cmd.Parameters.AddWithValue("@VeliID", VeliID);
            conn.Open();
            sdr = cmd.ExecuteReader();
            if (sdr.HasRows)
            {
                sdr.Read();
                lblVeliTCK.Text = sdr["UserName"].ToString();
                lblVeliAdi.Text = sdr["VeliAdi"].ToString();
                lblVeliSoyadi.Text = sdr["VeliSoyadi"].ToString();
                lblEvTel.Text = sdr["EvTelefonu"].ToString();
                lblIsTel.Text = sdr["IsTelefonu"].ToString();
                lblIl.Text = sdr["Sehir"].ToString();
                lblIlce.Text = sdr["Ilce"].ToString();
                lblSemt.Text = sdr["Mahalle"].ToString();
                LblAdres.Text = sdr["EvAdresi"].ToString();
            }
            conn.Close();
            cmd = new SqlCommand("SELECT * FROM Notlar n JOIN Ogrenciler o ON o.OgrenciID=n.OgrenciID JOIN AltDersler ad ON ad.AltDersID=n.AltDersID WHERE o.OgrenciID = @OgrenciID", conn);
            cmd.Parameters.AddWithValue("@OgrenciID", OgrenciID);
            conn.Open();
            sdr = cmd.ExecuteReader();
            while (sdr.Read())
            {
                ListViewItem li1 = new ListViewItem();
                li1.Text = sdr["DersKodu"].ToString();
                li1.SubItems.Add(sdr["Donem1SinavNotu1"].ToString() == "-1" ? "" : sdr["Donem1SinavNotu1"].ToString());
                li1.SubItems.Add(sdr["Donem1SinavNotu2"].ToString() == "-1" ? "" : sdr["Donem1SinavNotu2"].ToString());
                li1.SubItems.Add(sdr["Donem1SinavNotu3"].ToString() == "-1" ? "" : sdr["Donem1SinavNotu3"].ToString());
                li1.SubItems.Add(sdr["Donem1SinavNotu4"].ToString() == "-1" ? "" : sdr["Donem1SinavNotu4"].ToString());
                li1.SubItems.Add(sdr["Donem1SozluNotu1"].ToString() == "-1" ? "" : sdr["Donem1SozluNotu1"].ToString());
                li1.SubItems.Add(sdr["Donem1SozluNotu2"].ToString() == "-1" ? "" : sdr["Donem1SozluNotu2"].ToString());
                li1.SubItems.Add(sdr["Donem1SozluNotu3"].ToString() == "-1" ? "" : sdr["Donem1SozluNotu3"].ToString());
                li1.SubItems.Add(sdr["Donem1SozluNotu4"].ToString() == "-1" ? "" : sdr["Donem1SozluNotu4"].ToString());
                li1.SubItems.Add(sdr["Donem1OdevNotu"].ToString() == "-1" ? "" : sdr["Donem1OdevNotu"].ToString());
                listView1.Items.Add(li1);
                ListViewItem li2 = new ListViewItem();
                li2.Text = sdr["DersKodu"].ToString();
                li2.SubItems.Add(sdr["Donem2SinavNotu1"].ToString() == "-1" ? "" : sdr["Donem2SinavNotu1"].ToString());
                li2.SubItems.Add(sdr["Donem2SinavNotu2"].ToString() == "-1" ? "" : sdr["Donem2SinavNotu2"].ToString());
                li2.SubItems.Add(sdr["Donem2SinavNotu3"].ToString() == "-1" ? "" : sdr["Donem2SinavNotu3"].ToString());
                li2.SubItems.Add(sdr["Donem2SinavNotu4"].ToString() == "-1" ? "" : sdr["Donem2SinavNotu4"].ToString());
                li2.SubItems.Add(sdr["Donem2SozluNotu1"].ToString() == "-1" ? "" : sdr["Donem2SozluNotu1"].ToString());
                li2.SubItems.Add(sdr["Donem2SozluNotu2"].ToString() == "-1" ? "" : sdr["Donem2SozluNotu2"].ToString());
                li2.SubItems.Add(sdr["Donem2SozluNotu3"].ToString() == "-1" ? "" : sdr["Donem2SozluNotu3"].ToString());
                li2.SubItems.Add(sdr["Donem2SozluNotu4"].ToString() == "-1" ? "" : sdr["Donem2SozluNotu4"].ToString());
                li2.SubItems.Add(sdr["Donem2OdevNotu"].ToString() == "-1" ? "" : sdr["Donem2OdevNotu"].ToString());
                listView2.Items.Add(li2);
            }
            conn.Close();
            float Ozurlu = 0, Ozursuz = 0;
            cmd = new SqlCommand("SELECT CASE OzelNeden WHEN 1 THEN 'Raporlu' WHEN 2 THEN 'İzinli' ELSE '' END AS Sebep, CASE TamGunMu WHEN 1 THEN 'Tam' ELSE 'Yarım' END AS Gun, * FROM OgrenciDevamsizlik WHERE OgrenciID = @OgrenciID", conn);
            cmd.Parameters.AddWithValue("@OgrenciID", OgrenciID);
            conn.Open();
            sdr = cmd.ExecuteReader();
            while (sdr.Read())
            {
                if (sdr["Sebep"].ToString() == "")
                    Ozursuz += sdr["Gun"].ToString() == "Tam" ? 1 : 0.5f;
                else
                    Ozurlu += sdr["Gun"].ToString() == "Tam" ? 1 : 0.5f;
                ListViewItem li = new ListViewItem();
                li.Text = Convert.ToDateTime(sdr["Tarih"]).ToString("dd.MM.yyyy");
                li.SubItems.Add(sdr["Gun"].ToString());
                li.SubItems.Add(sdr["Sebep"].ToString());
                listView3.Items.Add(li);
            }
            conn.Close();
            lblDevamsizlik.Text = "Özürsüz " + Ozursuz.ToString() + " gün, Özürlü " + Ozurlu.ToString() + " gün";
        }
    }
}
