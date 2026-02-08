using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Drawing.Printing;

namespace Windows_Uygulamasi
{
    public partial class frmAltBelgeDetay : Form
    {
        string veriID, belgeBaslik, OkulAdi;

        public frmAltBelgeDetay(string _veriID, string _belgeBaslik)
        {
            InitializeComponent();
            veriID = _veriID;
            belgeBaslik = _belgeBaslik;
        }

        private void frmAltBelgeDetay_Load(object sender, EventArgs e)
        {
            PaperSize ps = new PaperSize();
            ps.Height = 583;
            ps.Width = 840;
            ps.PaperName = "Belge";
            printDocument1.DefaultPageSettings.PaperSize = ps;
            
            SqlConnection conn = dbIslem.baglantiOlustur();
            SqlCommand cmd = new SqlCommand("SELECT * FROM Ayarlar", conn);
            conn.Open();
            SqlDataReader sdr = cmd.ExecuteReader();
            if (sdr.HasRows)
            {
                sdr.Read();
                OkulAdi = sdr["OkulAdi"].ToString();
            }
            conn.Close();
        }

        string tabloAdi, idSutunAdi;
        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            switch (belgeBaslik)
            {
                case "ONUR BELGESİ":
                    tabloAdi = "BelgeOnur";
                    break;
                case "TEŞEKKÜR BELGESİ":
                    tabloAdi = "BelgeTesekkur";
                    break;
                default:
                    tabloAdi = "BelgeTakdir";
                    break;
            }
            idSutunAdi = "b." + tabloAdi + "ID";
            SqlConnection conn = dbIslem.baglantiOlustur();


            SqlCommand cmd = new SqlCommand("SELECT * FROM " + tabloAdi + " b JOIN Ogrenciler o ON o.OgrenciID=b.OgrenciID JOIN Siniflar s ON s.SinifID=o.SinifID JOIN Sezonlar z ON z.SezonID=b.SezonID JOIN Ogretmenler m ON m.OgretmenID=z.MudurID WHERE " + idSutunAdi + "=@belgeID", conn);
            cmd.Parameters.AddWithValue("@belgeID", veriID);
            conn.Open();
            SqlDataReader sdr = cmd.ExecuteReader();
            if (sdr.HasRows)
            {
                sdr.Read();
                Pen Kalem = new Pen(Color.Black, 1f);
                Brush Firca = Kalem.Brush;
                Font font1 = new Font("Times New Roman", 18, FontStyle.Regular);
                Font font2 = new Font("Times New Roman", 32, FontStyle.Bold);
                Font font3 = new Font("Times New Roman", 18, FontStyle.Bold);
                Graphics gp = e.Graphics;
                Image img = Image.FromFile("certificate_template.png");
                gp.DrawImage(img, 0, 0, 840, 583);
                YaziYaz(gp, font2, Firca, 100, belgeBaslik);
                YaziYaz(gp, font1, Firca, 200, "Okulumuzun "+ sdr["Kademe"] + sdr["Sube"] + " sınıfı "+sdr["OkulNo"]+" numaralı öğrencisi");
                YaziYaz(gp, font1, Firca, 230, sdr["OgrenciAdi"] + " " + sdr["OgrenciSoyadi"] + " " + sdr["Donem1"] + "-" + sdr["Donem2"] + " ders yılı "+sdr["Donem"]+". döneminde");
                YaziYaz(gp, font1, Firca, 260, "okul içinde ve dışında, arkadaşlarına ve çevresine örnek olarak");
                YaziYaz(gp, font1, Firca, 290, "erdemli davranışlarından ve derslerindeki gayret ve başarısından");
                YaziYaz(gp, font1, Firca, 320, "dolayı bu " + belgeBaslik + "'ni almaya hak kazanmıştır.");
                YaziYaz(gp, font3, Firca, 420, sdr["OgretmenAdi"] + " " + sdr["OgretmenSoyadi"]);
                YaziYaz(gp, font1, Firca, 450, OkulAdi + " Okul Müdürü");
            }
            conn.Close();
        }

        void YaziYaz(Graphics gp, Font YaziFontu, Brush Firca, int YukMesafe, string Yazi)
        {
            int genislik = 840;
            SizeF Boyut = gp.MeasureString(Yazi, YaziFontu);
            float YaziGen = Boyut.Width;
            float sonuc = (genislik - YaziGen) / 2;
            gp.DrawString(Yazi, YaziFontu, Firca, sonuc, YukMesafe);
        }

        private void btnOnizleme_Click(object sender, EventArgs e)
        {
            printPreviewDialog1.Document = printDocument1;
            printPreviewDialog1.ShowDialog();
        }

        private void btnYazdir_Click(object sender, EventArgs e)
        {
            dbIslem.dbHizliGuncelle(tabloAdi, tabloAdi+"ID", veriID, "PrintEdildiMi", "1");
            printDocument1.Print();
        }
    }
}
