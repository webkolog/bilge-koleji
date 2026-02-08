using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Printing;
using System.Data.SqlClient;

namespace Windows_Uygulamasi
{
    public partial class frmAltKarneDetay : Form
    {
        string veriID;
        bool karne2Donem = true;
        SqlConnection conn = dbIslem.baglantiOlustur();

        public frmAltKarneDetay(string _veriID)
        {
            veriID = _veriID;
            InitializeComponent();
        }

        private void frmAltKarneDetay_Load(object sender, EventArgs e)
        {
            PaperSize ps = new PaperSize();
            ps.Height = 595;
            ps.Width = 820;
            ps.PaperName = "Karne";
            printDocument1.DefaultPageSettings.PaperSize = ps;
        }

        private void btnOnizle_Click(object sender, EventArgs e)
        {
            printPreviewDialog1.Document = printDocument1;
            printPreviewDialog1.ShowDialog();
        }

        private void btnYazdir_Click(object sender, EventArgs e)
        {
            printDocument1.Print();
            if (karne2Donem)
                dbIslem.dbHizliGuncelle("Karneler", "KarneID", veriID, "D2PrintEdildiMi", "1");
            else
                dbIslem.dbHizliGuncelle("Karneler", "KarneID", veriID, "D1PrintEdildiMi", "1");
        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            Graphics gr = e.Graphics;
            Pen kalem = new Pen(Color.Black, 1f);
            int fark = 32;
            int farkYarisi = fark / 2;
            int yatayCizgi1Gen = (fark * 11) + (fark / 2);
            int bas2 = yatayCizgi1Gen + fark * 3;
            int yatayCizgi2GenYarisi = fark * 5;
            int yaziBaslikBoyutu = fark / 4;
            Font yaziBaslikFontu = new Font(FontFamily.GenericSansSerif, yaziBaslikBoyutu, FontStyle.Regular);
            Font yaziFontuBuyuk = new Font(FontFamily.GenericSansSerif, fark / 2, FontStyle.Regular);
            Brush yaziBaslikFirca = kalem.Brush;
            StringFormat yaziYatayFormati = new StringFormat();
            yaziYatayFormati.FormatFlags = StringFormatFlags.DirectionVertical;

            SqlCommand cmd = new SqlCommand("SELECT * FROM Karneler k JOIN Ogrenciler o ON k.OgrenciID=o.OgrenciID JOIN Siniflar s ON s.SinifID=o.SinifID WHERE k.KarneID = @KarneID", conn);
            cmd.Parameters.AddWithValue("@KarneID", veriID);
            conn.Open();
            SqlDataReader sdr = cmd.ExecuteReader();
            if (sdr.HasRows)
            {
                sdr.Read();
                YaziYaz(fark, fark * 13 + farkYarisi, fark, sdr["OgrenciAdi"] + " " + sdr["OgrenciSoyadi"], yaziFontuBuyuk, yaziBaslikFirca, gr);
                YaziYaz(fark, fark * 6 + farkYarisi, fark * 2 + farkYarisi, sdr["Kademe"] + " " + sdr["Sube"], yaziBaslikFontu, yaziBaslikFirca, gr);
                YaziYaz(fark, fark * 6 + farkYarisi, fark * 2 + farkYarisi * 2, sdr["OkulNo"].ToString(), yaziBaslikFontu, yaziBaslikFirca, gr);
                double TopDevOlu = 0, TopDevOsuz = 0;
                TopDevOlu = Convert.ToDouble(sdr["D1DevamsizlikOzurlu"]) + Convert.ToDouble(sdr["D2DevamsizlikOzurlu"]);
                TopDevOsuz = Convert.ToDouble(sdr["D1DevamsizlikOzursuz"]) + Convert.ToDouble(sdr["D2DevamsizlikOzursuz"]);
                YaziYaz(fark, fark * 10 + farkYarisi, farkYarisi * 33, sdr["D1DevamsizlikOzurlu"].ToString(), yaziBaslikFontu, yaziBaslikFirca, gr);
                YaziYaz(fark, fark * 13 + farkYarisi, farkYarisi * 33, sdr["D1DevamsizlikOzursuz"].ToString(), yaziBaslikFontu, yaziBaslikFirca, gr);
                YaziYaz(fark, fark * 10 + farkYarisi, farkYarisi * 34, sdr["D2DevamsizlikOzurlu"].ToString(), yaziBaslikFontu, yaziBaslikFirca, gr);
                YaziYaz(fark, fark * 13 + farkYarisi, farkYarisi * 34, sdr["D2DevamsizlikOzursuz"].ToString(), yaziBaslikFontu, yaziBaslikFirca, gr);
                YaziYaz(fark, fark * 10 + farkYarisi, farkYarisi * 35, TopDevOlu.ToString(), yaziBaslikFontu, yaziBaslikFirca, gr);
                YaziYaz(fark, fark * 13 + farkYarisi, farkYarisi * 35, TopDevOsuz.ToString(), yaziBaslikFontu, yaziBaslikFirca, gr);
                if (sdr["Sonuc"].ToString() == "true")
                {
                    gr.FillRectangle(yaziBaslikFirca, (yatayCizgi1Gen + fark * 8) + 4, (fark * 2 + 4), farkYarisi / 2, farkYarisi / 2);
                }
                else if (sdr["Sonuc"].ToString() == "false")
                {
                    gr.FillRectangle(yaziBaslikFirca, (yatayCizgi1Gen + fark * 8) + 4, (farkYarisi * 5 + 4), farkYarisi / 2, farkYarisi / 2);
                }
                else
                {
                    karne2Donem = false;
                }
            }
            conn.Close();

            cmd = new SqlCommand("SELECT * FROM Ayarlar", conn);
            conn.Open();
            sdr = cmd.ExecuteReader();
            if (sdr.HasRows)
            {
                sdr.Read();
                YaziYaz(fark, fark * 13 + farkYarisi, fark * 2, sdr["OkulAdi"].ToString(), yaziBaslikFontu, yaziBaslikFirca, gr);
                YaziYaz(fark, fark * 13 + farkYarisi, fark * 2 + farkYarisi * 2, sdr["OkulAdres"].ToString(), yaziBaslikFontu, yaziBaslikFirca, gr);
            }
            conn.Close();

            cmd = new SqlCommand("SELECT * FROM Sezonlar ORDER BY SezonID DESC", conn);
            conn.Open();
            sdr = cmd.ExecuteReader();
            if (sdr.HasRows)
            {
                sdr.Read();
                YaziYaz(fark, fark * 13 + farkYarisi, fark * 2 + farkYarisi, sdr["Donem1"] + "-" + sdr["Donem2"], yaziBaslikFontu, yaziBaslikFirca, gr);
            }
            conn.Close();

            cmd = new SqlCommand("SELECT * FROM KarneNotlari kn JOIN Karneler k ON k.KarneID=kn.KarneID JOIN Ogrenciler o ON o.OgrenciID=k.OgrenciID JOIN AltDersler alt ON alt.AltDersID=kn.AltDersID JOIN AnaDersler ana ON ana.AnaDersID=alt.AnaDersID WHERE k.KarneID= @KarneID", conn);
            cmd.Parameters.AddWithValue("@KarneID", veriID);

            conn.Open();
            sdr = cmd.ExecuteReader();
            int hat = fark * 3 + farkYarisi * 5 + 2;
            while (sdr.Read())
            {
                gr.DrawString(sdr["DersAdi"].ToString(), yaziBaslikFontu, yaziBaslikFirca, fark, hat);
                gr.DrawString(sdr["HaftalikDersSaati"].ToString(), yaziBaslikFontu, yaziBaslikFirca, farkYarisi * 17, hat);
                gr.DrawString(sdr["Donem1Notu"].ToString(), yaziBaslikFontu, yaziBaslikFirca, farkYarisi * 19, hat);
                if (karne2Donem)
                {
                    decimal TopNot = Convert.ToInt32(sdr["Donem1Notu"]) + Convert.ToInt32(sdr["Donem2Notu"]);
                    decimal Ortalama = Math.Ceiling(TopNot / 2);
                    gr.DrawString(sdr["Donem2Notu"].ToString(), yaziBaslikFontu, yaziBaslikFirca, farkYarisi * 21, hat);
                    gr.DrawString(Ortalama.ToString(), yaziBaslikFontu, yaziBaslikFirca, farkYarisi * 23, hat);
                    hat += farkYarisi;
                }
            }
            conn.Close();

            YaziYaz(fark, fark * 13 + farkYarisi, farkYarisi * 31, "@YIL SONU NOTU", yaziBaslikFontu, yaziBaslikFirca, gr);

            gr.DrawString("Öğrencinin", yaziBaslikFontu, yaziBaslikFirca, fark, fark + 2);
            gr.DrawString("Adı Soyadı", yaziBaslikFontu, yaziBaslikFirca, fark, fark + farkYarisi + 2);
            gr.DrawString("Okul", yaziBaslikFontu, yaziBaslikFirca, fark, fark * 2 + 2);
            gr.DrawString("Sınıf", yaziBaslikFontu, yaziBaslikFirca, fark, fark * 2 + farkYarisi + 2);
            gr.DrawString("Okul No", yaziBaslikFontu, yaziBaslikFirca, fark, fark * 3 + 2);
            gr.DrawString("Ders Yılı", yaziBaslikFontu, yaziBaslikFirca, fark * 5 + farkYarisi, fark * 2 + farkYarisi + 2);
            gr.DrawString("İl/İlçe", yaziBaslikFontu, yaziBaslikFirca, fark * 5 + farkYarisi, fark * 3 + 2);
            gr.DrawString("Dersler", yaziBaslikFontu, yaziBaslikFirca, fark, fark * 3 + farkYarisi + 2);
            gr.DrawString("Haftalık", yaziBaslikFontu, yaziBaslikFirca, fark * 9, fark * 3 + farkYarisi + 2, yaziYatayFormati);
            gr.DrawString("Ders Saati", yaziBaslikFontu, yaziBaslikFirca, fark * 8 + farkYarisi, fark * 3 + farkYarisi + 2, yaziYatayFormati);
            gr.DrawString("1. Dönem", yaziBaslikFontu, yaziBaslikFirca, fark * 10, fark * 3 + farkYarisi + 2, yaziYatayFormati);
            gr.DrawString("Notları", yaziBaslikFontu, yaziBaslikFirca, fark * 9 + farkYarisi, fark * 3 + farkYarisi + 2, yaziYatayFormati);
            gr.DrawString("2. Dönem", yaziBaslikFontu, yaziBaslikFirca, fark * 11, fark * 3 + farkYarisi + 2, yaziYatayFormati);
            gr.DrawString("Notları", yaziBaslikFontu, yaziBaslikFirca, fark * 10 + farkYarisi, fark * 3 + farkYarisi + 2, yaziYatayFormati);
            gr.DrawString("Yıl Sonu", yaziBaslikFontu, yaziBaslikFirca, fark * 12, fark * 3 + farkYarisi + 2, yaziYatayFormati);
            gr.DrawString("Notları", yaziBaslikFontu, yaziBaslikFirca, fark * 11 + farkYarisi, fark * 3 + farkYarisi + 2, yaziYatayFormati);
            gr.DrawString("Yıl Sonu Notu", yaziBaslikFontu, yaziBaslikFirca, fark, farkYarisi * 31 + 2);
            gr.DrawString("Devam Etmediği Günler", yaziBaslikFontu, yaziBaslikFirca, fark, farkYarisi * 32 + 2);
            gr.DrawString("Özürlü", yaziBaslikFontu, yaziBaslikFirca, farkYarisi * 13, farkYarisi * 32 + 2);
            gr.DrawString("Özürsüz", yaziBaslikFontu, yaziBaslikFirca, farkYarisi * 19, farkYarisi * 32 + 2);
            gr.DrawString("1. Dönem", yaziBaslikFontu, yaziBaslikFirca, fark, farkYarisi * 33 + 2);
            gr.DrawString("2. Dönem", yaziBaslikFontu, yaziBaslikFirca, fark, farkYarisi * 34 + 2);
            gr.DrawString("Toplam", yaziBaslikFontu, yaziBaslikFirca, fark, farkYarisi * 35 + 2);
            gr.DrawString("Not Düzeni", yaziBaslikFontu, yaziBaslikFirca, yatayCizgi1Gen + fark * 3, fark + 2);
            gr.DrawString("Sonuç", yaziBaslikFontu, yaziBaslikFirca, yatayCizgi2GenYarisi + yatayCizgi1Gen + fark * 3, fark + 2);
            gr.DrawString("Puan", yaziBaslikFontu, yaziBaslikFirca, yatayCizgi1Gen + fark * 3, fark * 2 + 2);

            gr.DrawString("85 - 100", yaziBaslikFontu, yaziBaslikFirca, yatayCizgi1Gen + fark * 3, farkYarisi * 5);
            gr.DrawString("70 - 84", yaziBaslikFontu, yaziBaslikFirca, yatayCizgi1Gen + fark * 3, farkYarisi * 6);
            gr.DrawString("55 - 69", yaziBaslikFontu, yaziBaslikFirca, yatayCizgi1Gen + fark * 3, farkYarisi * 7);
            gr.DrawString("45 - 54", yaziBaslikFontu, yaziBaslikFirca, yatayCizgi1Gen + fark * 3, farkYarisi * 8);
            gr.DrawString("25 - 44", yaziBaslikFontu, yaziBaslikFirca, yatayCizgi1Gen + fark * 3, farkYarisi * 9);
            gr.DrawString("0 - 24", yaziBaslikFontu, yaziBaslikFirca, yatayCizgi1Gen + fark * 3, farkYarisi * 10);
            gr.DrawString("Not", yaziBaslikFontu, yaziBaslikFirca, yatayCizgi1Gen + fark * 5, fark * 2 + 2);
            gr.DrawString("5", yaziBaslikFontu, yaziBaslikFirca, yatayCizgi1Gen + fark * 5, farkYarisi * 5);
            gr.DrawString("4", yaziBaslikFontu, yaziBaslikFirca, yatayCizgi1Gen + fark * 5, farkYarisi * 6);
            gr.DrawString("3", yaziBaslikFontu, yaziBaslikFirca, yatayCizgi1Gen + fark * 5, farkYarisi * 7);
            gr.DrawString("2", yaziBaslikFontu, yaziBaslikFirca, yatayCizgi1Gen + fark * 5, farkYarisi * 8);
            gr.DrawString("1", yaziBaslikFontu, yaziBaslikFirca, yatayCizgi1Gen + fark * 5, farkYarisi * 9);
            gr.DrawString("0", yaziBaslikFontu, yaziBaslikFirca, yatayCizgi1Gen + fark * 5, farkYarisi * 10);
            gr.DrawString("Derece", yaziBaslikFontu, yaziBaslikFirca, yatayCizgi1Gen + fark * 6, fark * 2 + 2);
            gr.DrawString("Pekiyi", yaziBaslikFontu, yaziBaslikFirca, yatayCizgi1Gen + fark * 6, farkYarisi * 5);
            gr.DrawString("İyi", yaziBaslikFontu, yaziBaslikFirca, yatayCizgi1Gen + fark * 6, farkYarisi * 6);
            gr.DrawString("Orta", yaziBaslikFontu, yaziBaslikFirca, yatayCizgi1Gen + fark * 6, farkYarisi * 7);
            gr.DrawString("Geçer", yaziBaslikFontu, yaziBaslikFirca, yatayCizgi1Gen + fark * 6, farkYarisi * 8);
            gr.DrawString("Geçmez", yaziBaslikFontu, yaziBaslikFirca, yatayCizgi1Gen + fark * 6, farkYarisi * 9);
            gr.DrawString("Etkisiz", yaziBaslikFontu, yaziBaslikFirca, yatayCizgi1Gen + fark * 6, farkYarisi * 10);
            gr.DrawRectangle(kalem, (yatayCizgi1Gen + fark * 8) + 4, (fark * 2 + 4), farkYarisi / 2, farkYarisi / 2);
            gr.DrawString("Geçti", yaziBaslikFontu, yaziBaslikFirca, yatayCizgi1Gen + (fark * 8) + farkYarisi, fark * 2 + 2);
            gr.DrawRectangle(kalem, (yatayCizgi1Gen + fark * 8) + 4, (farkYarisi * 5 + 4), farkYarisi / 2, farkYarisi / 2);
            gr.DrawString("Sınıf Tekrarı", yaziBaslikFontu, yaziBaslikFirca, yatayCizgi1Gen + (fark * 8) + farkYarisi, farkYarisi * 5 + 2);
            gr.DrawString("Sınıf Öğretmeni Görüşü", yaziBaslikFontu, yaziBaslikFirca, yatayCizgi1Gen + fark * 3, fark * 6 + 2);
            gr.DrawString("1.Dönem", yaziBaslikFontu, yaziBaslikFirca, yatayCizgi1Gen + fark * 3, fark * 6 + farkYarisi + 2);
            gr.DrawString("2.Dönem", yaziBaslikFontu, yaziBaslikFirca, yatayCizgi1Gen + fark * 3 + yatayCizgi2GenYarisi, fark * 6 + farkYarisi + 2);
            gr.DrawString("İmzalar", yaziBaslikFontu, yaziBaslikFirca, yatayCizgi1Gen + fark * 3, fark * 15 + farkYarisi + 2);
            gr.DrawString("1.Dönem", yaziBaslikFontu, yaziBaslikFirca, yatayCizgi2GenYarisi + yatayCizgi1Gen + fark * 3, fark * 15 + farkYarisi + 2);
            gr.DrawString("2.Dönem", yaziBaslikFontu, yaziBaslikFirca, (yatayCizgi2GenYarisi / 2) * 3 + yatayCizgi1Gen + fark * 3, fark * 15 + farkYarisi + 2);
            gr.DrawString("Sınıf Öğretmeni", yaziBaslikFontu, yaziBaslikFirca, yatayCizgi1Gen + fark * 3, fark * 16 + 2);
            gr.DrawString("Müdür", yaziBaslikFontu, yaziBaslikFirca, yatayCizgi1Gen + fark * 3, fark * 16 + farkYarisi + 2);
            gr.DrawString("Öğretmenler, Yeni Nesil Sizin Eseriniz Olacak!", yaziBaslikFontu, yaziBaslikFirca, yatayCizgi1Gen + fark * 3, fark * 17 + 2);
            gr.DrawString("Mustafa Kemal Atatürk", yaziBaslikFontu, yaziBaslikFirca, yatayCizgi1Gen + fark * 3, fark * 17 + farkYarisi + 2);
            Rectangle[] dikdortgenler = {
            new Rectangle(fark,fark,yatayCizgi1Gen,fark), //adı soyadı
            new Rectangle(fark,fark*2,yatayCizgi1Gen,farkYarisi), //okulu
            new Rectangle(fark,farkYarisi*5,yatayCizgi1Gen,farkYarisi), //sınıf - ders yılı
            new Rectangle(fark,fark*3,yatayCizgi1Gen,farkYarisi), //okul no - il/ilçe
            new Rectangle(fark,farkYarisi*5,farkYarisi*9,fark), //ayraç
            new Rectangle(fark,farkYarisi*7,yatayCizgi1Gen,fark*2), //derler başlık
            new Rectangle(farkYarisi*17,farkYarisi*7,fark,fark*2), //haftalık ders saati başlık
            new Rectangle(farkYarisi*21,farkYarisi*7,fark,fark*2), //2. dönem ders notları başlık
            new Rectangle(fark,farkYarisi*11,yatayCizgi1Gen,fark*10), //derler
            new Rectangle(farkYarisi*17,farkYarisi*11,fark,fark*10), //haftalık ders saati
            new Rectangle(farkYarisi*21,farkYarisi*11,fark,fark*10), //2. dönem ders notları
            new Rectangle(fark,farkYarisi*31,farkYarisi*11,farkYarisi), //yılsonu notu başlık
            new Rectangle(farkYarisi*13,farkYarisi*31,fark*6,farkYarisi), //yıl sonu notu
            new Rectangle(fark,fark*16,farkYarisi*11,farkYarisi), //devam etmediği günler dönem başlık
            new Rectangle(farkYarisi*13,fark*16,fark*3,farkYarisi), //özürlü başlık
            new Rectangle(farkYarisi*19,fark*16,fark*3,farkYarisi), //özürsz başlık
            new Rectangle(fark,farkYarisi*33,farkYarisi*11,farkYarisi), //devam etmediği günler 1.dönem
            new Rectangle(farkYarisi*13,farkYarisi*33,fark*3,farkYarisi), //özürlü
            new Rectangle(farkYarisi*19,farkYarisi*33,fark*3,farkYarisi), //özürsüz
            new Rectangle(fark,fark*17,farkYarisi*11,farkYarisi), //devam etmediği günler 2.dönem
            new Rectangle(farkYarisi*13,fark*17,fark*3,farkYarisi), //özürlü
            new Rectangle(farkYarisi*19,fark*17,fark*3,farkYarisi), //özürsüz
            new Rectangle(fark,farkYarisi*35,farkYarisi*11,farkYarisi), //devam etmediği günler toplam
            new Rectangle(farkYarisi*13,farkYarisi*35,fark*3,farkYarisi), //özürlü
            new Rectangle(farkYarisi*19,farkYarisi*35,fark*3,farkYarisi), //özürsüz
            new Rectangle(bas2,fark,yatayCizgi2GenYarisi,fark), //not düzeni başlık
            new Rectangle(bas2 + yatayCizgi2GenYarisi,fark,yatayCizgi2GenYarisi,fark), //sonuç baslik
            new Rectangle(bas2,fark*2,yatayCizgi2GenYarisi,fark*4), //not düzeni
            new Rectangle(bas2 + yatayCizgi2GenYarisi,fark*2,yatayCizgi2GenYarisi,fark*4), //sonuç
            new Rectangle(bas2,fark*6,yatayCizgi2GenYarisi*2,farkYarisi), //öğretmeninin görüşü başlık
            new Rectangle(bas2,farkYarisi*13,yatayCizgi2GenYarisi,fark*9), //1.d öğretmeninin görüşü
            new Rectangle(bas2+yatayCizgi2GenYarisi,farkYarisi*13,yatayCizgi2GenYarisi,fark*9), //2.d ög
            new Rectangle(bas2,farkYarisi*31,yatayCizgi2GenYarisi,farkYarisi), //imzalar başlık
            new Rectangle(bas2+yatayCizgi2GenYarisi,farkYarisi*31,yatayCizgi2GenYarisi / 2,farkYarisi), //1db
            new Rectangle(bas2+(yatayCizgi2GenYarisi/2)*3,farkYarisi*31,yatayCizgi2GenYarisi / 2,farkYarisi), //2db
            new Rectangle(bas2,fark*16,yatayCizgi2GenYarisi,farkYarisi), //öğrt imza başlık
            new Rectangle(bas2+yatayCizgi2GenYarisi,fark*16,yatayCizgi2GenYarisi / 2,farkYarisi), 
            new Rectangle(bas2+(yatayCizgi2GenYarisi/2)*3,fark*16,yatayCizgi2GenYarisi / 2,farkYarisi),
            new Rectangle(bas2,farkYarisi*33,yatayCizgi2GenYarisi,farkYarisi), //müdür imza başlık
            new Rectangle(bas2+yatayCizgi2GenYarisi,farkYarisi*33,yatayCizgi2GenYarisi / 2,farkYarisi), 
            new Rectangle(bas2+(yatayCizgi2GenYarisi/2)*3,farkYarisi*33,yatayCizgi2GenYarisi / 2,farkYarisi), 
            new Rectangle(bas2,fark*17,yatayCizgi2GenYarisi*2,fark), //söz
            };
            gr.DrawRectangles(kalem, dikdortgenler);
        }

        void YaziYaz(int bas, int bit, int yukseklik, string yazi, Font yaziTipi, Brush firca, Graphics gr)
        {
            int uzunluk = bit - bas;
            SizeF yaziOlcum = gr.MeasureString(yazi, yaziTipi);
            int kalan = uzunluk - Convert.ToInt32(yaziOlcum.Width);
            gr.DrawString(yazi, yaziTipi, firca, kalan, yukseklik + 2);
        }
    }
}
