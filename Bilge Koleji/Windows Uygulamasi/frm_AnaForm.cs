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
    public partial class frm_AnaForm : Form
    {
        public string uyeID, sezonID;
        private OrtakListeleme Listeleme;
        SqlConnection conn = dbIslem.baglantiOlustur();

        public frm_AnaForm()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            SqlCommand cmd;
            SqlDataReader sdr;
            if (!dbIslem.aynisiVarmi("Sezonlar"))
            {
                frmAltSezonOlustur frm = new frmAltSezonOlustur();
                altFormAc(frm, "Sezon Oluştur");
            }
            else
            {
                cmd = new SqlCommand("SELECT * FROM Sezonlar ORDER BY SezonID DESC", conn);
                conn.Open();
                sdr = cmd.ExecuteReader();
                sdr.Read();
                sezonID = sdr["SezonID"].ToString();
                string OgretimYili = sdr["Donem1"].ToString() + "-" + sdr["Donem2"].ToString() + " Öğretim Yılı";
                conn.Close();
                this.Text = "Okul Otomasyon Programı " + Application.ProductVersion + " - " + OgretimYili;
                cmd = new SqlCommand("SELECT * FROM Siniflar ORDER BY Kademe, Sube", conn);
                conn.Open();
                sdr = cmd.ExecuteReader();
                while (sdr.Read())
                {
                    VeriTututucu vt = new VeriTututucu();
                    vt.veriID = sdr["SinifID"].ToString();
                    vt.VeriAdi = sdr["Kademe"] + " " + sdr["Sube"];
                    comboSinif.Items.Add(vt);
                }
                conn.Close();
            }
            btnDersEkle.Enabled = false;
            btnDersSil.Enabled = false;
            int saat = 0, gun = 0;
            for (int i = 1; i <= 66; i++)
            {
                Label lbl = new Label();
                lbl.AutoSize = false;
                lbl.BackColor = Color.White;
                lbl.BorderStyle = BorderStyle.FixedSingle;
                lbl.TextAlign = ContentAlignment.MiddleCenter;
                switch (i)
                {
                    case 1:
                        lbl.Size = new Size(43, 23);
                        lbl.Font = new Font("Microsoft Sans Serif", 10f, FontStyle.Bold);
                        lbl.Name = "lblBasSaat";
                        lbl.Text = "Saat";
                        break;
                    case 2:
                        lbl.Size = new Size(129, 23);
                        lbl.Font = new Font("Microsoft Sans Serif", 10f, FontStyle.Bold);
                        lbl.Name = "lbl_Gun_1";
                        lbl.Text = "Pazartesi";
                        break;
                    case 3:
                        lbl.Size = new Size(129, 23);
                        lbl.Font = new Font("Microsoft Sans Serif", 10f, FontStyle.Bold);
                        lbl.Name = "lbl_Gun_2";
                        lbl.Text = "Salı";
                        break;
                    case 4:
                        lbl.Size = new Size(129, 23);
                        lbl.Font = new Font("Microsoft Sans Serif", 10f, FontStyle.Bold);
                        lbl.Name = "lbl_Gun_3";
                        lbl.Text = "Çarşamba";
                        break;
                    case 5:
                        lbl.Size = new Size(129, 23);
                        lbl.Font = new Font("Microsoft Sans Serif", 10f, FontStyle.Bold);
                        lbl.Name = "lbl_Gun_4";
                        lbl.Text = "Perşembe";
                        break;
                    case 6:
                        lbl.Size = new Size(129, 23);
                        lbl.Font = new Font("Microsoft Sans Serif", 10f, FontStyle.Bold);
                        lbl.Name = "lbl_Gun_5";
                        lbl.Text = "Cuma";
                        break;
                    default:
                        if ((i - 1) % 6 == 0)
                        {
                            saat = i / 6;
                            gun = 0;
                            lbl.Size = new Size(43, 29);
                            lbl.Font = new Font("Microsoft Sans Serif", 10f, FontStyle.Bold);
                            lbl.Name = "lbl_DS_" + saat;
                            lbl.Text = saat.ToString();
                        }
                        else
                        {
                            gun++;
                            lbl.Size = new Size(129, 29);
                            lbl.Font = new Font("Microsoft Sans Serif", 8f, FontStyle.Regular);
                            lbl.Name = "lbl_Ders_" + gun + "_" + saat;
                            lbl.Tag = "Ders";
                            lbl.Cursor = Cursors.Hand;
                            lbl.Click += new EventHandler(lbl_Click);
                        }
                        break;
                }
                flowLayoutPanel1.Controls.Add(lbl);
            }
            tabMenu.SelectedIndex = 1;
            tabMenu.SelectedIndex = 0;
        }

        private void altFormAc(Form gelenFrm, string Baslik)
        {
            gelenFrm.Text = Baslik;
            gelenFrm.StartPosition = FormStartPosition.CenterScreen;
            gelenFrm.MaximizeBox = false;
            gelenFrm.MinimizeBox = false;
            gelenFrm.FormBorderStyle = FormBorderStyle.FixedSingle;
            gelenFrm.Icon = this.Icon;
            gelenFrm.ShowDialog(this);
        }

        public void girisFormunuAc()
        {
            frmGiris frm = new frmGiris();
            Application.Run(frm);
        }

        public void Listele()
        {
            Listeleme.Listele();
        }

        private void secilmeHatasi()
        {
            MessageBox.Show("Hiç bir alan seçili değil!");
        }

        string gunAdi(string gun)
        {
            string gunIsim = null;
            switch (gun)
            {
                case "1":
                    gunIsim = "Pazartesi";
                    break;
                case "2":
                    gunIsim = "Salı";
                    break;
                case "3":
                    gunIsim = "Çarşamba";
                    break;
                case "4":
                    gunIsim = "Perşembe";
                    break;
                case "5":
                    gunIsim = "Cuma";
                    break;
            }
            return gunIsim;
        }

        private void tabMenu_SelectedIndexChanged(object sender, EventArgs e)
        {
            //--TAB DEĞİŞTİRME
            /*
             * 0. Öğrenci
             * 1. Veliler
             * 2. Öğretmenler
             * 3. Derslik
             * 4. Sınıflar
             * 5. Mesajlar
             * 6. Duyurular
             * 7. Dersler
             * 8. Ders Programları
             * 9. Devamsızlar
             * 10. Belgeler
             * 11.İlişkisi Kesilmişler
             */
            /*
                     tsComboDerslikKat.Items.Clear();
                    tsComboDerslikKat.Items.Add("Hepsi");
                    for (int i = 0; i < 15; i++)
                        tsComboDerslikKat.Items.Add(i);
                    tsComboDerslikKat.SelectedIndex = 0;
                    tsTxtDerslikArama.Clear();
                    
                    OrtakListeleme ol = new OrtakListeleme();
                    ol.KontrolleriEkle();
                    ol.SiralamaKontrolleri();
                    ol.SqlSorgusuYarat();
                    ol.SqlSutunlar();
                    ol.SqlSutunlarArama();
                    ol.Siralama.Ekle();
                    ol.Siralama.Ekle();
                    ol.Siralama.Ekle();
                    ol.Siralama.Ekle();
                    ol.Filtre.Ekle();
                    ol.Filtre.Ekle();
                    ol.Filtre.Ekle();
                    ol.Filtre.Ekle();
                    ol.SeciliSiraSutunTSMI = ;
                    ol.SeciliSiraTipiTSMI = ;
                    ol.Arama = false;
                    ol.Listele();
                    Listeleme = ol;
             
             * ___________________________________
                         * Sıralama:
            Listeleme.SeciliSiraTipiTSMI = sender;
            Listeleme.Listele();
                         
                         * Filtreleme:
             try
            {
                Listeleme.Listele();
            }
            catch
            {

            }
                         
                         * Arama
            Listeleme.AramaYap(true);
        

            tsBtnDersikAramaIptal.Enabled = false;
            Listeleme.Listele();
                     */
            SqlCommand cmd;
            SqlDataReader sdr;
            tabMenu.TabPages[5].Text = "Mesajlar (" + dbIslem.KayitToplami("Mesajlar", "KimeID", "KimeID", "OkunduMu", uyeID, "false") + ")";
            switch (tabMenu.SelectedIndex)
            {
                case 0:
                    {
                        //öğrenci
                        tsCbOgrenciKademe.Items.Clear();
                        tsCbOgrenciSinif.Items.Clear();
                        tsCbOgrenciCinsiyet.Items.Clear();
                        tsCbOgrenciDurum.Items.Clear();
                        tsCbOgrenciKademe.Items.Add("Hepsi");
                        for (int i = 9; i <= 12; i++)
                            tsCbOgrenciKademe.Items.Add(i.ToString());
                        tsCbOgrenciSinif.Items.Add("Hepsi");
                        cmd = new SqlCommand("SELECT * FROM Siniflar ORDER BY Kademe, Sube", conn);
                        conn.Open();
                        sdr = cmd.ExecuteReader();
                        while (sdr.Read())
                        {
                            VeriTututucu vt = new VeriTututucu();
                            vt.veriID = sdr["SinifID"].ToString();
                            vt.VeriAdi = sdr["Kademe"] + " " + sdr["Sube"];
                            tsCbOgrenciSinif.Items.Add(vt);
                        }
                        conn.Close();
                        tsCbOgrenciCinsiyet.Items.Add("Hepsi");
                        for (int i = 0; i <= 1; i++)
                        {
                            VeriTututucu vt = new VeriTututucu();
                            vt.veriID = i.ToString();
                            vt.VeriAdi = i == 0 ? "Erkek" : "Bayan";
                            tsCbOgrenciCinsiyet.Items.Add(vt);
                        }
                        tsCbOgrenciDurum.Items.Add("Hepsi");
                        for (int i = 0; i <= 1; i++)
                        {
                            VeriTututucu vt = new VeriTututucu();
                            vt.veriID = i.ToString();
                            vt.VeriAdi = i == 0 ? "Devam Etmeyenler" : "Devam Edenler";
                            tsCbOgrenciDurum.Items.Add(vt);
                        }
                        tsCbOgrenciKademe.SelectedIndex = 0;
                        tsCbOgrenciSinif.SelectedIndex = 0;
                        tsCbOgrenciCinsiyet.SelectedIndex = 0;
                        tsCbOgrenciDurum.SelectedIndex = 2;
                        tsTxtOgrenciArama.Clear();
                        OrtakListeleme ol = new OrtakListeleme();
                        ol.KontrolleriEkle(lvOgrenciler, tsTxtOgrenciArama, tsBtnOgrenciArama, tsBtnOgrenciAramaIptal);
                        ol.SiralamaKontrolleri(miOgrenciSiralamaAZ, miOgrenciSiralamaZA);
                        ol.SqlSorgusuYarat("SELECT o.OgrenciID, o.OkulNo, CASE WHEN CONVERT(NVARCHAR,s.Kademe) IS NULL THEN '' ELSE CONVERT(NVARCHAR,s.Kademe) END AS Kademe, CASE WHEN CONVERT(NVARCHAR,s.Sube) IS NULL THEN '' ELSE CONVERT(NVARCHAR,s.Sube) END AS Sube, o.OgrenciAdi, o.OgrenciSoyadi, CASE o.Cinsiyet WHEN 0 THEN 'Erkek' ELSE 'Bayan' END AS Cinsiyet, CASE o.DevamEdiyorMu WHEN 1 THEN 'Devam Ediyor' ELSE 'Devam Etmiyor' END AS Durum, o.NotOrtalamasi, o.Kademe AS oKademe FROM Ogrenciler o LEFT JOIN Siniflar s ON o.SinifID=s.SinifID", "o.OgrenciID");
                        ol.SqlSutunlar("OkulNo", "Kademe", "Sube", "OgrenciAdi", "OgrenciSoyadi", "Cinsiyet", "Durum", "NotOrtalamasi");
                        ol.SqlSutunlarArama("o.OgrenciAdi", "o.OgrenciSoyadi");
                        ol.Siralama.Ekle(miOgrenciSiralamaAdaGore, "o.OgrenciAdi, o.OgrenciSoyadi");
                        ol.Siralama.Ekle(miOgrenciSiralamaSinifaGore, "s.Kademe, s.Sube");
                        ol.Siralama.Ekle(miOgrenciSiraOkulNosunaGore, "o.OkulNo");
                        ol.Siralama.Ekle(miOgrenciSiraNotOrtGore, "o.NotOrtalamasi");
                        ol.Siralama.Ekle(miOgrenciKademeyeGore, "o.Kademe");
                        ol.Filtre.Ekle(tsCbOgrenciKademe, "o.Kademe");
                        ol.Filtre.Ekle(tsCbOgrenciSinif, "s.SinifID");
                        ol.Filtre.Ekle(tsCbOgrenciCinsiyet, "o.Cinsiyet");
                        ol.Filtre.Ekle(tsCbOgrenciDurum, "o.DevamEdiyorMu");
                        ol.SeciliSiraSutunTSMI = miOgrenciSiralamaAdaGore;
                        ol.SeciliSiraTipiTSMI = miOgrenciSiralamaAZ;
                        ol.Arama = false;
                        ol.Listele();
                        Listeleme = ol;
                        break;
                    }
                case 1:
                    {
                        //veliler
                        tsTxtVeliArama.Clear();
                        OrtakListeleme ol = new OrtakListeleme();
                        ol.KontrolleriEkle(lvVeliler, tsTxtVeliArama, tsBtnVeliArama, tsBtnVeliAramaIptal);
                        ol.SiralamaKontrolleri(miVeliSiraAZ, miVeliSiraZA);
                        ol.SqlSorgusuYarat("SELECT DISTINCT v.VeliID, v.VeliID, v.VeliAdi, v.VeliSoyadi, v.EvTelefonu, v.IsTelefonu, v.Sehir, v.Ilce, v.Mahalle FROM Veliler v JOIN Ogrenciler o ON v.VeliID=o.VeliID AND o.DevamEdiyorMu=1", "v.VeliID");
                        ol.SqlSutunlar("VeliAdi", "VeliSoyadi", "EvTelefonu", "IsTelefonu", "Sehir", "Ilce", "Mahalle");
                        ol.SqlSutunlarArama("v.VeliAdi", "v.VeliSoyadi");
                        ol.Siralama.Ekle(miVeliSiraAdaGore, "v.VeliAdi, v.VeliSoyadi");
                        ol.SeciliSiraSutunTSMI = miVeliSiraAdaGore;
                        ol.SeciliSiraTipiTSMI = miVeliSiraAZ;
                        ol.Arama = false;
                        ol.Listele();
                        Listeleme = ol;
                        break;
                    }
                case 2:
                    {
                        //Öğretmenler
                        tsComboOgretmenFiltreBrans.Items.Clear();
                        tsComboOgretmenFiltreBrans.Items.Add("Hepsi");
                        cmd = new SqlCommand("SELECT * FROM AnaDersler ORDER BY DersAdi", conn);
                        conn.Open();
                        sdr = cmd.ExecuteReader();
                        while (sdr.Read())
                        {
                            VeriTututucu vt = new VeriTututucu();
                            vt.VeriAdi = sdr["DersAdi"].ToString();
                            vt.veriID = sdr["AnaDersID"].ToString();
                            tsComboOgretmenFiltreBrans.Items.Add(vt);
                        }
                        conn.Close();
                        tsComboOgretmenFiltreBrans.SelectedIndex = 0;
                        OrtakListeleme ol = new OrtakListeleme();
                        ol.KontrolleriEkle(lvOgretmenler, tsTxtOgretmenArama, tsBtnOgretmenAra, tsBtnOgretmenAraIptal);
                        ol.SiralamaKontrolleri(miOgretmenSiraAZ, miOgretmenSiraZA);
                        ol.SqlSorgusuYarat("SELECT o.OgretmenID, o.OgretmenAdi, o.OgretmenSoyadi, CASE o.Gorev WHEN 1 THEN 'Müdür' WHEN 2 THEN 'Müdür Yardımcısı' ELSE '' END as OgretmenGorev, o.Brans, a.DersAdi as OgretmenBrans FROM Ogretmenler o LEFT JOIN AnaDersler a ON o.Brans=a.AnaDersID", "o.OgretmenID");
                        ol.SqlSutunlar("o.OgretmenAdi", "o.OgretmenSoyadi", "OgretmenGorev", "OgretmenBrans");
                        ol.SqlSutunlarArama("o.OgretmenAdi", "o.OgretmenSoyadi");
                        ol.Siralama.Ekle(miOgretmenSiraAdaGore, "o.OgretmenAdi, o. OgretmenSoyadi");
                        ol.Siralama.Ekle(miOgretmenSiraBransaGore, "a.DersAdi");
                        ol.Filtre.Ekle(tsComboOgretmenFiltreBrans, "o.Brans");
                        ol.SeciliSiraSutunTSMI = miOgretmenSiraAdaGore;
                        ol.SeciliSiraTipiTSMI = miOgretmenSiraAZ;
                        ol.Arama = false;
                        ol.Listele();
                        Listeleme = ol;
                        break;
                    }
                case 3:
                    {
                        //Derslikler
                        tsComboDerslikKat.Items.Clear();
                        tsComboDerslikKat.Items.Add("Hepsi");
                        for (int i = 0; i < 15; i++)
                            tsComboDerslikKat.Items.Add(i);
                        tsComboDerslikKat.SelectedIndex = 0;
                        tsTxtDerslikArama.Clear();
                        OrtakListeleme ol = new OrtakListeleme();
                        ol.KontrolleriEkle(lvDerslikler, tsTxtDerslikArama, tsBtnDerslikArama, tsBtnDersikAramaIptal);
                        ol.SiralamaKontrolleri(miDerslikSiraAZ, miDerslikSiraZA);
                        ol.SqlSorgusuYarat("SELECT * FROM Derslikler", "DerslikID");
                        ol.SqlSutunlar("DerslikAdi", "Kat", "Kapasite");
                        ol.SqlSutunlarArama("DerslikAdi");
                        ol.Siralama.Ekle(miDerslikSiraEklenmeTarihineGore, "DerslikID");
                        ol.Siralama.Ekle(miDerslikSiraAdaGore, "DerslikAdi");
                        ol.Filtre.Ekle(tsComboDerslikKat, "Kat");
                        ol.SeciliSiraSutunTSMI = miDerslikSiraEklenmeTarihineGore;
                        ol.SeciliSiraTipiTSMI = miDerslikSiraAZ;
                        ol.Arama = false;
                        ol.Listele();
                        Listeleme = ol;
                        break;
                    }
                case 4:
                    {
                        //Sınıflar
                        tsComboDerslikKat.Items.Clear();
                        tsComboDerslikKat.Items.Add("Hepsi");
                        for (int i = 0; i < 15; i++)
                            tsComboDerslikKat.Items.Add(i);
                        tsComboDerslikKat.SelectedIndex = 0;
                        tsTxtDerslikArama.Clear();
                        tsComboSinifFiltreKademe.Items.Clear();
                        tsComboSinifFiltreKat.Items.Clear();
                        tsComboSinifFiltreSube.Items.Clear();
                        tsComboSinifFiltreKademe.Items.Add("Hepsi");
                        tsComboSinifFiltreKat.Items.Add("Hepsi");
                        tsComboSinifFiltreSube.Items.Add("Hepsi");
                        for (int i = 9; i <= 12; i++)
                            tsComboSinifFiltreKademe.Items.Add(i.ToString());
                        for (int i = 0; i < 15; i++)
                            tsComboSinifFiltreKat.Items.Add(i.ToString());
                        foreach (char item in "ABCDEFGHIJKLMNOPRSTUVYZ")
                            tsComboSinifFiltreSube.Items.Add(item.ToString());
                        tsComboSinifFiltreKademe.SelectedIndex = 0;
                        tsComboSinifFiltreKat.SelectedIndex = 0;
                        tsComboSinifFiltreSube.SelectedIndex = 0;
                        OrtakListeleme ol = new OrtakListeleme();
                        ol.KontrolleriEkle(lvSiniflar, tsTxtSinifArama, tsBtnSinifArama, tsBtnSinifAramaIptal);
                        ol.SiralamaKontrolleri(miSinifSiraAZ, miSinifSiraZA);
                        ol.SqlSorgusuYarat("SELECT s.SinifID, s.Kademe, s.Sube, o.OgretmenAdi + ' ' + o.OgretmenSoyadi AS RehberOgretmen, d.DerslikAdi, d.Kat FROM Siniflar s JOIN Derslikler d ON s.DerslikID=d.DerslikID JOIN Ogretmenler o ON o.OgretmenID=s.OgretmenID", "s.SinifID");
                        ol.SqlSutunlar("Kademe", "Sube", "RehberOgretmen", "DerslikAdi", "Kat");
                        ol.SqlSutunlarArama("s.Kademe", "s.Sube", "d.DerslikAdi", "o.OgretmenAdi", "o.OgretmenSoyadi");
                        ol.Siralama.Ekle(miSinifSiraKademeGore, "s.Kademe, s.Sube");
                        ol.Siralama.Ekle(miSinifSiraKataGore, "d.Kat");
                        ol.Filtre.Ekle(tsComboSinifFiltreKademe, "s.Kademe");
                        ol.Filtre.Ekle(tsComboSinifFiltreKat, "d.Kat");
                        ol.Filtre.Ekle(tsComboSinifFiltreSube, "s.Sube");
                        ol.SeciliSiraSutunTSMI = miSinifSiraKademeGore;
                        ol.SeciliSiraTipiTSMI = miSinifSiraAZ;
                        ol.Arama = false;
                        ol.Listele();
                        Listeleme = ol;
                        break;
                    }
                case 5:
                    {
                        //Mesajlar
                        tabControl1_SelectedIndexChanged(sender, e);
                        break;
                    }
                case 6:
                    {
                        //Duyurular
                        tsComboDuyuruFiltreKitle.Items.Clear();
                        tsComboDuyuruFiltreKitle.Items.Add("Hepsi");
                        for (int i = 0; i < 2; i++)
                        {
                            VeriTututucu vt = new VeriTututucu();
                            vt.veriID = i.ToString();
                            vt.VeriAdi = i == 0 ? "Herkes" : "Sınıf";
                            tsComboDuyuruFiltreKitle.Items.Add(vt);
                        }
                        tsComboDuyuruFiltreKitle.SelectedIndex = 0;
                        tsComboDuyuruFiltreYazanlar.Items.Clear();
                        tsComboDuyuruFiltreYazanlar.Items.Add("Hepsi");
                        cmd = new SqlCommand("SELECT * FROM Ogretmenler ORDER BY OgretmenAdi, OgretmenSoyadi", conn);
                        conn.Open();
                        sdr = cmd.ExecuteReader();
                        while (sdr.Read())
                        {
                            VeriTututucu vt = new VeriTututucu();
                            vt.VeriAdi = sdr["OgretmenAdi"].ToString() + " " + sdr["OgretmenSoyadi"].ToString();
                            vt.veriID = sdr["OgretmenID"].ToString();
                            tsComboDuyuruFiltreYazanlar.Items.Add(vt);
                        }
                        conn.Close();
                        tsComboDuyuruFiltreYazanlar.SelectedIndex = 0;
                        OrtakListeleme ol = new OrtakListeleme();
                        ol.KontrolleriEkle(lvDuyurular, tsTxtDuyuruArama, tsBtnDuyuruArama, tsBtnDuyuruAramaIptal);
                        ol.SiralamaKontrolleri(miDuyuruSiralaAZ, miDuyuruSiralaZA);
                        ol.SqlSorgusuYarat("SELECT d.DuyuruID, o.OgretmenID, o.OgretmenAdi + ' ' + o.OgretmenSoyadi AS Yazan, d.Baslik, d.Mesaj, d.Tarih, CASE d.KitleTuru WHEN '1' THEN 'Sınıf' WHEN '0' THEN 'Herkes' END AS KitleTuru FROM Duyuru d JOIN Ogretmenler o ON d.YazanID = o.OgretmenID", "d.DuyuruID");
                        ol.SqlSutunlar("Yazan", "KitleTuru", "Baslik", "Tarih");
                        ol.SqlSutunlarArama("d.Baslik", "d.Mesaj");
                        ol.Siralama.Ekle(miDuyuruSiralaBasligaGore, "d.Baslik");
                        ol.Siralama.Ekle(miDuyuruSiralaTariheGore, "d.Tarih");
                        ol.Filtre.Ekle(tsComboDuyuruFiltreKitle, "d.KitleTuru");
                        ol.Filtre.Ekle(tsComboDuyuruFiltreYazanlar, "o.OgretmenID");
                        ol.SeciliSiraSutunTSMI = miDuyuruSiralaBasligaGore;
                        ol.SeciliSiraTipiTSMI = miDuyuruSiralaAZ;
                        ol.Arama = false;
                        ol.Listele();
                        Listeleme = ol;
                        break;
                    }
                case 7:
                    {
                        //Dersler
                        miComboDersFiltreAnaDers.Items.Clear();
                        miComboDersFiltreAnaDers.Items.Add("Hepsi");
                        cmd = new SqlCommand("SELECT * FROM AnaDersler ORDER BY DersAdi", conn);
                        conn.Open();
                        sdr = cmd.ExecuteReader();
                        while (sdr.Read())
                        {
                            VeriTututucu vt = new VeriTututucu();
                            vt.VeriAdi = sdr["DersAdi"].ToString();
                            vt.veriID = sdr["AnaDersID"].ToString();
                            miComboDersFiltreAnaDers.Items.Add(vt);
                        }
                        conn.Close();
                        miComboDersFiltreAnaDers.SelectedIndex = 0;
                        miComboDersFiltreKademe.Items.Clear();
                        miComboDersFiltreKademe.Items.Add("Hepsi");
                        for (int i = 9; i <= 12; i++)
                            miComboDersFiltreKademe.Items.Add(i.ToString());
                        miComboDersFiltreKademe.SelectedIndex = 0;
                        tsComboDerslikKat.Items.Clear();
                        tsComboDerslikKat.Items.Add("Hepsi");
                        for (int i = 0; i < 15; i++)
                            tsComboDerslikKat.Items.Add(i);
                        tsComboDerslikKat.SelectedIndex = 0;
                        tsTxtDerslikArama.Clear();
                        OrtakListeleme ol = new OrtakListeleme();
                        ol.KontrolleriEkle(lvDersler, tsTxtDersArama, tsBtnDersArama, tsBtnDersAramaIptal);
                        ol.SiralamaKontrolleri(miDersSiraAZ, miDersSiraZA);
                        ol.SqlSorgusuYarat("SELECT altDer.AltDersID, altDer.DersKodu, anaDer.AnaDersID, anaDer.DersAdi, altDer.Kademe, altDer.HaftalikDersSaati FROM AltDersler altDer FULL JOIN AnaDersler anaDer ON altDer.AnaDersID=anaDer.AnaDersID", "altDer.AltDersID");
                        ol.SqlSutunlar("DersKodu", "DersAdi", "Kademe", "HaftalikDersSaati");
                        ol.SqlSutunlarArama("DersKodu", "DersAdi");
                        ol.Siralama.Ekle(miDersSiraTariheGore, "altDer.AltDersID");
                        ol.Siralama.Ekle(miDersSiraKodaGore, "altDer.DersKodu");
                        ol.Siralama.Ekle(miDersSiraAdaGore, "anaDer.DersAdi");
                        ol.Siralama.Ekle(miDersSiraKadameyeGore, "altDer.Kademe");
                        ol.Siralama.Ekle(miDersSiraHDSGore, "altDer.HaftalikDersSaati");
                        ol.Filtre.Ekle(miComboDersFiltreAnaDers, "anaDer.AnaDersID");
                        ol.Filtre.Ekle(miComboDersFiltreKademe, "altDer.Kademe");
                        ol.SeciliSiraSutunTSMI = miDersSiraKodaGore;
                        ol.SeciliSiraTipiTSMI = miDersSiraAZ;
                        ol.Arama = false;
                        ol.Listele();
                        Listeleme = ol;
                        break;
                    }
                case 8:
                    {
                        //Ders Programi
                        comboSinif.Items.Clear();
                        cmd = new SqlCommand("SELECT * FROM Siniflar ORDER BY Kademe, Sube", conn);
                        conn.Open();
                        sdr = cmd.ExecuteReader();
                        while (sdr.Read())
                        {
                            VeriTututucu vt = new VeriTututucu();
                            vt.veriID = sdr["SinifID"].ToString();
                            vt.VeriAdi = sdr["Kademe"] + " " + sdr["Sube"];
                            comboSinif.Items.Add(vt);
                        }
                        conn.Close();

                        break;
                    }
                case 9:
                    {
                        //Devamsızlıklar
                        if (sezonID == null)
                            return;
                        tsTxtDevamsizlikArama.Clear();
                        tsCbDevamsizlikSinif.Items.Clear();
                        tsCbDevamsizlikSinif.Items.Add("Hepsi");
                        cmd = new SqlCommand("SELECT * FROM Siniflar ORDER BY Kademe, Sube", conn);
                        conn.Open();
                        sdr = cmd.ExecuteReader();
                        while (sdr.Read())
                        {
                            VeriTututucu vt = new VeriTututucu();
                            vt.veriID = sdr["SinifID"].ToString();
                            vt.VeriAdi = sdr["Kademe"] + " " + sdr["Sube"];
                            tsCbDevamsizlikSinif.Items.Add(vt);
                        }
                        conn.Close();
                        tsCbDevamsizlikSinif.SelectedIndex = 0;
                        OrtakListeleme ol = new OrtakListeleme();
                        ol.KontrolleriEkle(lvDevamsizlik, tsTxtDevamsizlikArama, tsBtnDevamsizlikArama, tsBtnDevamsizlikAramaIptal);
                        ol.SiralamaKontrolleri(miDevamsizlikSiraAZ, miDevamsizlikSiraZA);
                        ol.SqlSorgusuYarat("SELECT od.odID, od.SezonID, o.OkulNo, s.SinifID, s.Kademe, s.Sube, o.OgrenciAdi, o.OgrenciSoyadi, od.Tarih, CASE od.TamGunMu WHEN 1 THEN 'Tam' ELSE 'Yarım' END AS Gun, CASE od.OzelNeden WHEN 1 THEN 'Reporlu' WHEN 2 THEN 'İzinli' ELSE '' END AS OzelNeden FROM OgrenciDevamsizlik od JOIN Ogrenciler o ON o.OgrenciID=od.OgrenciID JOIN Siniflar s ON s.SinifID=o.SinifID AND od.SezonID='" + sezonID + "'", "od.odID");
                        ol.SqlSutunlar("OkulNo", "Kademe", "Sube", "OgrenciAdi", "OgrenciSoyadi", "Tarih", "Gun", "OzelNeden");
                        ol.SqlSutunlarArama("o.OgrenciAdi", "o.OgrenciSoyadi");
                        ol.Siralama.Ekle(miDevamsizlikSiraAdaGore, "o.OgrenciAdi, o.OgrenciSoyadi");
                        ol.Siralama.Ekle(miDevamsizlikSiraOkulNoGore, "o.OkulNo");
                        ol.Siralama.Ekle(miDevamsizlikSiraSinifaGore, "s.Kademe, s.Sube");
                        ol.Siralama.Ekle(miDevamsizlikSiraTariheGore, "od.Tarih");
                        ol.Filtre.Ekle(tsCbDevamsizlikSinif, "s.SinifID");
                        ol.SeciliSiraSutunTSMI = miDevamsizlikSiraTariheGore;
                        ol.SeciliSiraTipiTSMI = miDevamsizlikSiraZA;
                        ol.Arama = false;
                        ol.Listele();
                        Listeleme = ol;
                        break;
                    }
                case 10:
                    {
                        //Karneler ve Belgeler
                        tabControl2_SelectedIndexChanged(sender, e);
                        break;
                    }
                case 11:
                    {
                        //İlişkisi kesilmişler listesi
                        tsTxtIkArama.Clear();
                        tsCbIkSebep.Items.Clear();
                        tsCbIkSebep.Items.Add("Hepsi");
                        for (int i = 0; i <= 3; i++)
                        {
                            VeriTututucu vt = new VeriTututucu();
                            switch (i)
                            {
                                case 0:
                                    vt.VeriAdi = "Mezun Olanlar";
                                    break;
                                case 1:
                                    vt.VeriAdi = "Okuldan Atılanlar";
                                    break;
                                case 2:
                                    vt.VeriAdi = "Nakiledilenler";
                                    break;
                                default:
                                    vt.VeriAdi = "Okulu Bırakanlar";
                                    break;
                            }
                            vt.veriID = i.ToString();
                            tsCbIkSebep.Items.Add(vt);
                        }
                        tsCbIkSebep.SelectedIndex = 0;
                        OrtakListeleme ol = new OrtakListeleme();
                        ol.KontrolleriEkle(lvIk, tsTxtIkArama, tsBtnIkArama, tsBtnIkAramaIptal);
                        ol.SiralamaKontrolleri(miIkSiraAZ, miIkSiraZA);
                        ol.SqlSorgusuYarat("SELECT ik.OgrenciID, CASE ik.Sebep WHEN 0 THEN 'Mezun Oldu' WHEN 1 THEN 'Okuldan Atıldı' WHEN 2 THEN 'Nakiledildi' ELSE 'Okulu Bıraktı' END AS Sebep, o.OgrenciAdi, o.OgrenciSoyadi, CASE o.Cinsiyet WHEN 1 THEN 'Bayan' ELSE 'Erkek' END AS Cinsiyet, o.Kademe, o.NotOrtalamasi, o.BitirdigiOkul, o.OkulNo FROM IliskisiKesilmisler ik JOIN Ogrenciler o ON ik.OgrenciID=o.OgrenciID AND o.DevamEdiyorMu=0", "ik.OgrenciID");
                        ol.SqlSutunlar("OkulNo", "OgrenciAdi", "OgrenciSoyadi", "Cinsiyet", "Sebep", "NotOrtalamasi", "Kademe");
                        ol.SqlSutunlarArama("o.OgrenciAdi", "o.OgrenciSoyadi");
                        ol.Siralama.Ekle(miIkSiraAdaGore, "o.OgrenciAdi, o.OgrenciSoyadi");
                        ol.Siralama.Ekle(miIkSiraNotOrt, "o.NotOrtalamasi");
                        ol.Filtre.Ekle(tsCbIkSebep, "ik.Sebep");
                        ol.SeciliSiraSutunTSMI = miIkSiraAdaGore;
                        ol.SeciliSiraTipiTSMI = miIkSiraAZ;
                        ol.Arama = false;
                        ol.Listele();
                        Listeleme = ol;
                        break;
                    }

            }
        }

        string seciliGun, seciliSaat;
        void lbl_Click(object sender, EventArgs e)
        {
            Label lbl = sender as Label;
            if (lbl.Tag != null)
            {
                foreach (Label cLabel in flowLayoutPanel1.Controls)
                    cLabel.BackColor = Color.White;
                lbl.BackColor = Color.LightCyan;
                if (lbl.Text == "")
                {
                    btnDersEkle.Enabled = true;
                    btnDersSil.Enabled = false;
                }
                else
                {
                    btnDersEkle.Enabled = false;
                    btnDersSil.Enabled = true;
                }
                seciliGun = lbl.Name.Split('_')[2];
                seciliSaat = lbl.Name.Split('_').Last();
                foreach (Label cLabel in flowLayoutPanel1.Controls)
                {
                    if (cLabel.Name == "lbl_Gun_" + seciliGun)
                        cLabel.BackColor = Color.LightCyan;
                    if (cLabel.Name == "lbl_DS_" + seciliSaat)
                        cLabel.BackColor = Color.LightCyan;
                }
                lblSecilen.Text = "Seçilen: " + gunAdi(seciliGun) + ", " + seciliSaat + ". ders";
            }
        }

        private void tsBtnDerslikEkle_Click(object sender, EventArgs e)
        {
            frmAltDerslikEkle frm = new frmAltDerslikEkle();
            altFormAc(frm, "Derslik Ekle");
        }

        private void tsBtnDerslikDuzenle_Click(object sender, EventArgs e)
        {
            if (Listeleme.SatirSeciliMi)
            {
                frmAltDerslikDuzenle frm = new frmAltDerslikDuzenle(Listeleme.SatirIndex);
                altFormAc(frm, "Derslik Düzenle");
            }
            else { secilmeHatasi(); }
        }

        private void tsBtnDersEkle_Click(object sender, EventArgs e)
        {
            frmAltDersEkle frm = new frmAltDersEkle();
            altFormAc(frm, "Ders Ekle");
        }

        private void miAltDersDuzenle_Click(object sender, EventArgs e)
        {
            if (Listeleme.SatirSeciliMi)
            {
                frmAltDersDuzenle frm = new frmAltDersDuzenle(Listeleme.SatirIndex, false);
                altFormAc(frm, "Ders Düzenle");
            }
            else { secilmeHatasi(); }
        }

        private void miAnaDersDuzenle_Click(object sender, EventArgs e)
        {
            if (Listeleme.SatirSeciliMi)
            {
                frmAltDersDuzenle frm = new frmAltDersDuzenle(Listeleme.SatirIndex, true);
                altFormAc(frm, "Ders Düzenle");
            }
            else { secilmeHatasi(); }
        }

        private void miAnaDersSil_Click(object sender, EventArgs e)
        {
            if (Listeleme.SatirSeciliMi)
            {
                try
                {
                    foreach (ListViewItem lv in Listeleme.ListView.SelectedItems)
                        dbIslem.dbVeriSil("AnaDersler", "DersAdi", lv.SubItems[1].Text);
                }
                catch
                {
                    MessageBox.Show("Seçili alanlardaki verilerin bazıları başka kayıtlar tarafından kullanılıyor!\nÖnce bağlı olduğu kayıtı silmeniz gerekli!");
                }
                Listeleme.Listele();
            }
            else { secilmeHatasi(); }
        }

        private void tsBtnOgretmenEkle_Click(object sender, EventArgs e)
        {
            frmAltOgretmenEkle frm = new frmAltOgretmenEkle();
            altFormAc(frm, "Öğretmen Ekle");
        }

        private void tsBtnOgretmenDuzenle_Click(object sender, EventArgs e)
        {
            if (Listeleme.SatirSeciliMi)
            {
                frmAltOgretmenDuzenle frm = new frmAltOgretmenDuzenle(Listeleme.SatirIndex);
                altFormAc(frm, "Öğretmen Düzenle");
            }
            else { secilmeHatasi(); }
        }

        private void tsDuyuruEkle_Click(object sender, EventArgs e)
        {
            frmAltDuyuruEkle frm = new frmAltDuyuruEkle(uyeID);
            altFormAc(frm, "Duyuru Ekle");
        }

        private void tsBtnDuyuruDuzenle_Click(object sender, EventArgs e)
        {
            if (Listeleme.SatirSeciliMi)
            {
                frmAltDuyuruDuzenle frm = new frmAltDuyuruDuzenle(uyeID, Listeleme.SatirIndex);
                altFormAc(frm, "Duyuru Düzenle");
            }
        }

        private void tsBtnSinifEkle_Click(object sender, EventArgs e)
        {
            frmAltSinifEkle frm = new frmAltSinifEkle();
            altFormAc(frm, "Sınıf Ekle");
        }

        private void tsBtnSinifDuzenle_Click(object sender, EventArgs e)
        {
            if (Listeleme.SatirSeciliMi)
            {
                frmAltSinifDuzenle frm = new frmAltSinifDuzenle(Listeleme.SatirIndex);
                altFormAc(frm, "Sınıfı Düzenle");
            }
        }

        private void tsOkulAyarlari_Click(object sender, EventArgs e)
        {
            frmAltAyarlar frm = new frmAltAyarlar();
            altFormAc(frm, "Okul Ayarları");
        }

        private void tsKullaniciDegistir_Click(object sender, EventArgs e)
        {
            System.Threading.Thread Thr = new System.Threading.Thread(new System.Threading.ThreadStart(girisFormunuAc));
            Thr.Start();
            this.Close();
        }

        private void tsHakkinda_Click(object sender, EventArgs e)
        {
            AboutBoxHakkinda frm = new AboutBoxHakkinda();
            altFormAc(frm, "Program Hakkında");
        }

        private void tsSifreDegistir_Click(object sender, EventArgs e)
        {
            frmAltSifreDegistir frm = new frmAltSifreDegistir(uyeID);
            altFormAc(frm, "Şifre Değiştir");
        }

        private void tsSezonAyarlari_Click(object sender, EventArgs e)
        {
            if (dbIslem.aynisiVarmi("Sezonlar"))
            {
                if (dbIslem.aynisiVarmi("Karneler", "D2PrintEdildiMi", "SezonID", "False", sezonID) | !dbIslem.aynisiVarmi("Karneler"))
                {
                    MessageBox.Show("Henüz basılmamış karneler var!\nKarneleri yazdırdıktan sonra yeni öğretim yılına geçiş yapabilirsiniz.", "Uyarı!");
                    return;
                }
                if (dbIslem.aynisiVarmi("BelgeOnur", "PrintEdildiMi", "SezonID", "False", sezonID) | dbIslem.aynisiVarmi("BelgeTekdir", "PrintEdildiMi", "SezonID", "False", sezonID) | dbIslem.aynisiVarmi("BelgeTesekkur", "PrintEdildiMi", "SezonID", "False", sezonID))
                {
                    MessageBox.Show("Henüz basılmamış belgeler var!\nTaktir, Teşekkür ve Onur belgelerini yazdırdıktan sonra yeni öğretim yılına geçiş yapabilirsiniz.", "Uyarı!");
                    return;
                }
                string mudurID = dbIslem.tekVeriCek("Ogretmenler", "Gorev", "1", "OgretmenID");
                string mudurYID = dbIslem.tekVeriCek("Ogretmenler", "Gorev", "2", "OgretmenID");
                string Donem1 = null;
                string Donem2 = null;
                if (mudurID == null)
                {
                    MessageBox.Show("Herhangi bir müdür belirlenmediği için sezon yaratılamadı!\nLütfen Okul Müdürünü belirtledikten sonra uygulamayı tekrar çalıştırın.", "Uyarı!");
                    this.Close();
                }
                else if (mudurYID == null)
                {
                    MessageBox.Show("Herhangi bir müdür yardımcısı belirlenmediği için sezon yaratılamadı!\nLütfen Okul Müdür Yardımcısını belirtledikten sonra uygulamayı tekrar çalıştırın.", "Uyarı!");
                    this.Close();
                }
                SqlCommand cmd = new SqlCommand("SELECT * FROM Sezonlar ORDER BY SezonID DESC", conn);
                conn.Open();
                SqlDataReader sdr = cmd.ExecuteReader();
                //zaten yukarda veri var mı yok mu kontrolü yaptık
                sdr.Read();
                Donem1 = (Convert.ToInt32(sdr["Donem1"]) + 1).ToString();
                Donem2 = (Convert.ToInt32(sdr["Donem2"]) + 1).ToString();
                conn.Close();
                dbIslem.dbEkleVeriIslem("Sezonlar", null, null, "Donem1", "Donem2", "MudurID", "MudurYardimciID", Donem1, Donem2, mudurID, mudurYID);
                cmd = new SqlCommand("SELECT o.OgrenciID, * FROM Ogrenciler o JOIN Karneler k ON o.OgrenciID=k.OgrenciID JOIN Siniflar s ON o.SinifID=s.SinifID", conn);
                sdr = cmd.ExecuteReader();
                while (sdr.Read())
                {
                    if (sdr["Sonuc"].ToString() == "1")
                    {
                        string ustSinifID = dbIslem.tekVeriCek2("Siniflar", "SinifID", "Kademe", (Convert.ToInt32(sdr["Kademe"]) + 1).ToString(), "Sube", sdr["Sube"].ToString());
                        if (ustSinifID == null)
                        {
                            //mezun oldu
                            dbIslem.dbEkleVeriIslem("IliskisiKesilmisler", "", "IliskisiKesilmisId", "OgrenciID", sdr["OgrenciID"].ToString(), "Sebep", "0");
                            dbIslem.dbHizliGuncelle("Ogrenciler", "OgrenciID", sdr["OgrenciID"].ToString(), "DevamEdiyorMu", "0");
                        }
                        else
                        {
                            //sınıf geçti
                            dbIslem.dbHizliGuncelle("Ogrenciler", "OgrenciID", sdr["OgrenciID"].ToString(), "SinifID", ustSinifID);
                        }
                    }
                    dbIslem.dbVeriSil("OgrenciDevamsizlik", "OgrenciID", sdr["OgrenciID"].ToString());
                    dbIslem.dbVeriSil("BelgeOnur", "OgrenciID", sdr["OgrenciID"].ToString());
                    dbIslem.dbVeriSil("BelgeTakdir", "OgrenciID", sdr["OgrenciID"].ToString());
                    dbIslem.dbVeriSil("BelgeTesekkur", "OgrenciID", sdr["OgrenciID"].ToString());
                    dbIslem.dbVeriSil("KarneNotlari", "KarneID", sdr["KarneID"].ToString());
                    dbIslem.dbVeriSil("Karneler", "OgrenciID", sdr["OgrenciID"].ToString());
                }
            }
            else
            {
                frmAltSezonOlustur frm = new frmAltSezonOlustur();
                altFormAc(frm, "Sezon Oluştur");
            }
        }

        private void tsBtnKarneOlustur_Click(object sender, EventArgs e)
        {
            if (dbIslem.aynisiVarmi("Sezonlar"))
            {
                if (!dbIslem.aynisiVarmi("Karneler", "SezonID", sezonID))
                {
                    string KarneID;
                    //1.dönem Karneleri oluştur
                    SqlCommand cmd = new SqlCommand("SELECT * FROM Ogrenciler", conn);
                    conn.Open();
                    SqlDataReader sdr = cmd.ExecuteReader();
                    while (sdr.Read())
                    {
                        string OgretmenID = dbIslem.tekVeriCek("Siniflar", "SinifID", sdr["SinifID"].ToString(), "OgretmenID");
                        if (OgretmenID == null)
                            return;
                        float Ozurlu = 0, Ozursuz = 0;
                        SqlConnection conn2 = dbIslem.baglantiOlustur();
                        SqlCommand cmd2 = new SqlCommand("SELECT * FROM OgrenciDevamsizlik WHERE OgrenciID=@OgrenciID", conn2);
                        cmd2.Parameters.AddWithValue("@OgrenciID", sdr["OgrenciID"].ToString());
                        conn2.Open();
                        SqlDataReader sdr2 = cmd2.ExecuteReader();
                        while (sdr2.Read())
                        {
                            if (sdr2["OzelNeden"].ToString() == "0")
                                Ozursuz += sdr2["TamGunMu"].ToString() == "1" ? 1 : 0.5f;
                            else
                                Ozurlu += sdr2["TamGunMu"].ToString() == "1" ? 1 : 0.5f;
                        }
                        conn2.Close();
                        KarneID = dbIslem.dbEkleVeriIslem("Karneler", null, null, "OgrenciID", "OgretmenID", "SinifID", "SezonID", "D1DevamsizlikOzurlu", "D1DevamsizlikOzursuz", "D2DevamsizlikOzurlu", "D2DevamsizlikOzursuz", "D1PrintEdildiMi", "D2PrintEdildiMi", sdr["OgrenciID"].ToString(), OgretmenID, sdr["SinifID"].ToString(), sezonID, Ozurlu.ToString().Replace(',', '.'), Ozursuz.ToString().Replace(',', '.'), "0", "0", "false", "false");
                        //notları ver
                        cmd2 = new SqlCommand("SELECT * FROM Notlar WHERE OgrenciID=@OgrenciID", conn2);
                        cmd2.Parameters.AddWithValue("@OgrenciID", sdr["OgrenciID"].ToString());
                        conn2.Open();
                        sdr2 = cmd2.ExecuteReader();
                        while (sdr2.Read())
                        {
                            float OdevNotu = 0, SinavNotu = 0, SozluNotu = 0;
                            int SinavSayisi = 0, SozluSayisi = 0;

                            if (sdr2["Donem1OdevNotu"].ToString() != "-1")
                            {
                                OdevNotu = Convert.ToSingle(sdr2["Donem1OdevNotu"]) * 0.30f;
                            }
                            if (sdr2["Donem1SinavNotu1"].ToString() != "-1")
                            {
                                SinavNotu += Convert.ToSingle(sdr2["Donem1SinavNotu1"]);
                                SinavSayisi++;
                            }
                            if (sdr2["Donem1SinavNotu2"].ToString() != "-1")
                            {
                                SinavNotu += Convert.ToSingle(sdr2["Donem1SinavNotu2"]);
                                SinavSayisi++;
                            }
                            if (sdr2["Donem1SinavNotu3"].ToString() != "-1")
                            {
                                SinavNotu += Convert.ToSingle(sdr2["Donem1SinavNotu3"]);
                                SinavSayisi++;
                            }
                            if (sdr2["Donem1SinavNotu4"].ToString() != "-1")
                            {
                                SinavNotu += Convert.ToSingle(sdr2["Donem1SinavNotu4"]);
                                SinavSayisi++;
                            }
                            if (SinavNotu != 0 & SinavSayisi != 0)
                                SinavNotu = (SinavNotu / SinavSayisi) * 0.40f;
                            if (sdr2["Donem1SozluNotu1"].ToString() != "-1")
                            {
                                SozluNotu += Convert.ToSingle(sdr2["Donem1SozluNotu1"]);
                                SozluSayisi++;
                            }
                            if (sdr2["Donem1SozluNotu2"].ToString() != "-1")
                            {
                                SozluNotu += Convert.ToSingle(sdr2["Donem1SozluNotu2"]);
                                SozluSayisi++;
                            }
                            if (sdr2["Donem1SozluNotu3"].ToString() != "-1")
                            {
                                SozluNotu += Convert.ToSingle(sdr2["Donem1SozluNotu3"]);
                                SozluSayisi++;
                            }
                            if (sdr2["Donem1SozluNotu4"].ToString() != "-1")
                            {
                                SozluNotu += Convert.ToSingle(sdr2["Donem1SozluNotu4"]);
                                SozluSayisi++;
                            }
                            if (SozluNotu != 0 & SozluSayisi != 0)
                                SozluNotu = (SozluNotu / SozluSayisi) * 0.30f;
                            dbIslem.dbEkleVeriIslem("KarneNotlari", null, null, "KarneID", "AltDersID", "Donem1Notu", KarneID, sdr2["AltDersID"].ToString(), NotBul(Math.Round(OdevNotu + SinavNotu + SozluNotu).ToString()));
                        }
                        conn2.Close();
                        if (!dbIslem.aynisiVarmi("OgrenciDevamsizlik", "OgrenciID", sdr["OgrenciID"].ToString()))
                        {
                            //1. dönem Onur Belgesi
                            dbIslem.dbEkleVeriIslem("BelgeOnur", null, null, "OgrenciID", "SezonID", "Donem", "PrintEdildiMi", sdr["OgrenciID"].ToString(), sezonID, "1", "0");
                        }
                        if (!dbIslem.aynisiVarmi("KarneNotlari", "Donem1Notu", "KarneID", "0", KarneID) & !dbIslem.aynisiVarmi("KarneNotlari", "Donem1Notu", "KarneID", "1", KarneID) & !dbIslem.aynisiVarmi("KarneNotlari", "Donem1Notu", "KarneID", "2", KarneID))
                        {
                            if (!dbIslem.aynisiVarmi("KarneNotlari", "Donem1Notu", "KarneID", "3", KarneID))
                            {
                                //1. dönem takdir belgesi
                                if (dbIslem.aynisiVarmi("KarneNotlari", "Donem1Notu", "KarneID", "4", KarneID) | dbIslem.aynisiVarmi("KarneNotlari", "Donem1Notu", "KarneID", "5", KarneID))
                                    dbIslem.dbEkleVeriIslem("BelgeTakdir", null, null, "OgrenciID", "SezonID", "Donem", "PrintEdildiMi", sdr["OgrenciID"].ToString(), sezonID, "1", "0");
                            }
                            else
                            {
                                //1. dönem teşekkür belgesi
                                if (dbIslem.aynisiVarmi("KarneNotlari", "Donem1Notu", "KarneID", "3", KarneID) | dbIslem.aynisiVarmi("KarneNotlari", "Donem1Notu", "KarneID", "4", KarneID) | dbIslem.aynisiVarmi("KarneNotlari", "Donem1Notu", "KarneID", "5", KarneID))
                                    dbIslem.dbEkleVeriIslem("BelgeTesekkur", null, null, "OgrenciID", "SezonID", "Donem", "PrintEdildiMi", sdr["OgrenciID"].ToString(), sezonID, "1", "0");
                            }
                        }
                    }
                    conn.Close();
                    MessageBox.Show("1.Dönem karneleri oluşturuldu!");
                }
                else
                {
                    if (dbIslem.aynisiVarmi("Karneler", "SezonID", "D1PrintEdildiMi", sezonID, "0"))
                    {
                        MessageBox.Show("Henüz çıktısı alınmamış 1.dönem karneleri mevcut!\n1.dönem karnelerini yızdırdıktan sonra tekrar deneyin.");
                    }
                    else
                    {
                        //2.Dönem Karneleri oluştur
                        SqlCommand cmd = new SqlCommand("SELECT * FROM Ogrenciler", conn);
                        conn.Open();
                        SqlDataReader sdr = cmd.ExecuteReader();
                        while (sdr.Read())
                        {
                            float Ozurlu = 0, Ozursuz = 0, eskiOzurlu = 0, eskiOzursuz = 0;
                            SqlConnection conn2 = dbIslem.baglantiOlustur();
                            SqlCommand cmd2 = new SqlCommand("SELECT * FROM OgrenciDevamsizlik WHERE OgrenciID=@OgrenciID", conn2);
                            cmd2.Parameters.AddWithValue("@OgrenciID", sdr["OgrenciID"].ToString());
                            conn2.Open();
                            SqlDataReader sdr2 = cmd2.ExecuteReader();
                            while (sdr2.Read())
                            {
                                if (sdr2["OzelNeden"].ToString() == "0")
                                    Ozursuz += sdr2["TamGunMu"].ToString() == "1" ? 1 : 0.5f;
                                else
                                    Ozurlu += sdr2["TamGunMu"].ToString() == "1" ? 1 : 0.5f;
                            }
                            conn2.Close();
                            eskiOzurlu = Convert.ToSingle(dbIslem.tekVeriCek("Karneler", "OgrenciID", sdr["OgrenciID"].ToString(), "D1DevamsizlikOzurlu"));
                            eskiOzursuz = Convert.ToSingle(dbIslem.tekVeriCek("Karneler", "OgrenciID", sdr["OgrenciID"].ToString(), "D1DevamsizlikOzursuz"));
                            Ozursuz -= eskiOzursuz;
                            Ozurlu -= eskiOzurlu;
                            //notları ver
                            string KarneID = dbIslem.tekVeriCek("Karneler", "OgrenciID", sdr["OgrenciID"].ToString(), "KarneID");
                            cmd2 = new SqlCommand("SELECT * FROM Notlar WHERE OgrenciID=@OgrenciID", conn2);
                            cmd2.Parameters.AddWithValue("@OgrenciID", sdr["OgrenciID"].ToString());
                            conn2.Open();
                            sdr2 = cmd2.ExecuteReader();
                            while (sdr2.Read())
                            {
                                float OdevNotu = 0, SinavNotu = 0, SozluNotu = 0;
                                int SinavSayisi = 0, SozluSayisi = 0;

                                if (sdr2["Donem2OdevNotu"].ToString() != "-1")
                                {
                                    OdevNotu = Convert.ToSingle(sdr2["Donem2OdevNotu"]) * 0.30f;
                                }
                                if (sdr2["Donem2SinavNotu1"].ToString() != "-1")
                                {
                                    SinavNotu += Convert.ToSingle(sdr2["Donem2SinavNotu1"]);
                                    SinavSayisi++;
                                }
                                if (sdr2["Donem2SinavNotu2"].ToString() != "-1")
                                {
                                    SinavNotu += Convert.ToSingle(sdr2["Donem2SinavNotu2"]);
                                    SinavSayisi++;
                                }
                                if (sdr2["Donem2SinavNotu3"].ToString() != "-1")
                                {
                                    SinavNotu += Convert.ToSingle(sdr2["Donem2SinavNotu3"]);
                                    SinavSayisi++;
                                }
                                if (sdr2["Donem2SinavNotu4"].ToString() != "-1")
                                {
                                    SinavNotu += Convert.ToSingle(sdr2["Donem2SinavNotu4"]);
                                    SinavSayisi++;
                                }
                                if (SinavNotu != 0 & SinavSayisi != 0)
                                    SinavNotu = (SinavNotu / SinavSayisi) * 0.40f;
                                if (sdr2["Donem2SozluNotu1"].ToString() != "-1")
                                {
                                    SozluNotu += Convert.ToSingle(sdr2["Donem2SozluNotu1"]);
                                    SozluSayisi++;
                                }
                                if (sdr2["Donem2SozluNotu2"].ToString() != "-1")
                                {
                                    SozluNotu += Convert.ToSingle(sdr2["Donem2SozluNotu2"]);
                                    SozluSayisi++;
                                }
                                if (sdr2["Donem2SozluNotu3"].ToString() != "-1")
                                {
                                    SozluNotu += Convert.ToSingle(sdr2["Donem2SozluNotu3"]);
                                    SozluSayisi++;
                                }
                                if (sdr2["Donem2SozluNotu4"].ToString() != "-1")
                                {
                                    SozluNotu += Convert.ToSingle(sdr2["Donem2SozluNotu4"]);
                                    SozluSayisi++;
                                }
                                if (SozluNotu != 0 & SozluSayisi != 0)
                                    SozluNotu = (SozluNotu / SozluSayisi) * 0.30f;
                                SqlConnection conn3 = dbIslem.baglantiOlustur();
                                SqlCommand cmd3 = new SqlCommand("UPDATE KarneNotlari SET Donem2Notu=@Donem2Notu WHERE KarneID=@KarneID", conn3);
                                cmd3.Parameters.AddWithValue("@KarneID", KarneID);
                                cmd3.Parameters.AddWithValue("@Donem2Notu", NotBul(Math.Round(OdevNotu + SinavNotu + SozluNotu).ToString()));
                                conn3.Open();
                                cmd3.ExecuteNonQuery();
                                conn3.Close();
                            }
                            conn2.Close();
                            bool GectiMi = true;
                            if ((Ozursuz + eskiOzursuz) >= 20)
                                GectiMi = false;
                            //devamsızlıkta sıkıntı yok ise derslerden kalıp kalmadığını kontrol edelim
                            if (GectiMi)
                            {
                                cmd2 = new SqlCommand("SELECT * FROM KarneNotlari WHERE KarneID = @KarneID", conn2);
                                cmd2.Parameters.AddWithValue("@KarneID", KarneID);
                                conn2.Open();
                                sdr2 = cmd2.ExecuteReader();
                                while (sdr2.Read())
                                {
                                    double ortalama = Math.Ceiling(((Convert.ToDouble(sdr2["Donem1Notu"]) + Convert.ToDouble(sdr2["Donem2Notu"]))) / 2);
                                    if (ortalama <= 1)
                                    {
                                        GectiMi = false;
                                        break;
                                    }
                                }
                                conn2.Close();
                            }
                            dbIslem.dbHizliGuncelle("Karneler", "KarneID", KarneID, "D2DevamsizlikOzurlu", "D2DevamsizlikOzursuz", "Sonuc", Ozurlu.ToString().Replace(',', '.'), Ozursuz.ToString().Replace(',', '.'), GectiMi.ToString());
                            if (!dbIslem.aynisiVarmi("OgrenciDevamsizlik", "OgrenciID", sdr["OgrenciID"].ToString()))
                            {
                                //2. dönem Onur Belgesi
                                dbIslem.dbEkleVeriIslem("BelgeOnur", null, null, "OgrenciID", "SezonID", "Donem", "PrintEdildiMi", sdr["OgrenciID"].ToString(), sezonID, "2", "0");
                            }
                            if (!dbIslem.aynisiVarmi("KarneNotlari", "Donem1Notu", "KarneID", "0", KarneID) & !dbIslem.aynisiVarmi("KarneNotlari", "Donem1Notu", "KarneID", "1", KarneID) & !dbIslem.aynisiVarmi("KarneNotlari", "Donem1Notu", "KarneID", "2", KarneID))
                            {
                                if (!dbIslem.aynisiVarmi("KarneNotlari", "Donem1Notu", "KarneID", "3", KarneID))
                                {
                                    //2. dönem takdir belgesi
                                    dbIslem.dbEkleVeriIslem("BelgeTakdir", null, null, "OgrenciID", "SezonID", "Donem", "PrintEdildiMi", sdr["OgrenciID"].ToString(), sezonID, "2", "0");
                                }
                                else
                                {
                                    //2. dönem teşekkür belgesi
                                    dbIslem.dbEkleVeriIslem("BelgeTesekkur", null, null, "OgrenciID", "SezonID", "Donem", "PrintEdildiMi", sdr["OgrenciID"].ToString(), sezonID, "2", "0");
                                }
                            }
                        }
                        conn.Close();
                        MessageBox.Show("2.Dönem karneleri oluşturuldu!");
                    }

                }
            }
            else
            {
                frmAltSezonOlustur frm = new frmAltSezonOlustur();
                altFormAc(frm, "Sezon Oluştur");
            }
        }

        private void btnDersEkle_Click(object sender, EventArgs e)
        {
            //Ders programına ders ekle
            string sinif = null;
            if (comboSinif.SelectedIndex != -1)
            {
                sinif = (comboSinif.SelectedItem as VeriTututucu).veriID;
                frmAltDersProgramEkle frm = new frmAltDersProgramEkle(sinif, seciliGun, seciliSaat);
                altFormAc(frm, "Ders Programi Ekle");
            }
            else
            {
                MessageBox.Show("Sınf seçmediniz");
            }
        }

        private void btnDersSil_Click(object sender, EventArgs e)
        {
            //Ders programından ders sil
            int etki = 0;
            foreach (Label lbl in flowLayoutPanel1.Controls)
                if (lbl.BackColor == Color.LightCyan & lbl.Tag != null)
                    etki = dbIslem.dbVeriSil("DersProgrami", "DersProgramiID", lbl.Tag.ToString());
            if (etki > 0)
                DersProgramiListele((comboSinif.SelectedItem as VeriTututucu).veriID);
        }

        private void comboSinif_SelectedIndexChanged(object sender, EventArgs e)
        {
            DersProgramiListele((comboSinif.SelectedItem as VeriTututucu).veriID);
        }

        public void DersProgramiListele(string sinif)
        {
            btnDersEkle.Enabled = false;
            btnDersSil.Enabled = false;
            foreach (Label lbl in flowLayoutPanel1.Controls)
            {
                if (lbl.Tag != null)
                {
                    lbl.Text = "";
                    lbl.Tag = "Ders";
                }
                lbl.BackColor = Color.White;
            }
            SqlCommand cmd = new SqlCommand("SELECT dp.DersProgramiID, dp.Gun, dp.Saat, ad.DersAdi, o.OgretmenAdi + ' ' + o.OgretmenSoyadi AS Ogretmen FROM DersProgrami dp JOIN AnaDersler ad ON dp.AnaDersID=ad.AnaDersID JOIN Ogretmenler o ON dp.OgretmenID=o.OgretmenID WHERE dp.SinifID=@SinifID", conn);
            cmd.Parameters.AddWithValue("@SinifID", sinif);
            conn.Open();
            SqlDataReader sdr = cmd.ExecuteReader();
            while (sdr.Read())
            {
                foreach (Label lbl in flowLayoutPanel1.Controls)
                {
                    if (lbl.Name == "lbl_Ders_" + sdr["Gun"] + "_" + sdr["Saat"])
                    {
                        lbl.Text = sdr["DersAdi"] + "\n" + sdr["Ogretmen"];
                        lbl.Tag = sdr["DersProgramiID"].ToString();
                    }
                }
            }
            conn.Close();
            string kademe = dbIslem.tekVeriCek("Siniflar", "SinifID", sinif, "Kademe");
            int TopDersSaatSayisi = 0;
            cmd = new SqlCommand("SELECT SUM(HaftalikDersSaati) AS Toplam FROM AltDersler WHERE Kademe='" + kademe + "' GROUP BY Kademe", conn);
            conn.Open();
            sdr = cmd.ExecuteReader();
            if (sdr.HasRows)
            {
                sdr.Read();
                TopDersSaatSayisi = Convert.ToInt32(sdr["Toplam"]);
            }
            conn.Close();
            int SnfDersSaatSayisi = dbIslem.KayitToplami("DersProgrami", "SinifID", "SinifID", sinif);
            lblDersKapasite.Text = "Dersler: (" + SnfDersSaatSayisi + "/" + TopDersSaatSayisi + ")";
        }

        private void tsBtnOgrenciEkle_Click(object sender, EventArgs e)
        {
            frmAltOgrenciEkle frm = new frmAltOgrenciEkle();
            altFormAc(frm, "Öğrenci Ekle");
        }

        private void tsBtnOgrenciDuzenle_Click(object sender, EventArgs e)
        {
            if (Listeleme.SatirSeciliMi)
            {
                frmAltOgrenciDuzenle frm = new frmAltOgrenciDuzenle(Listeleme.SatirIndex);
                altFormAc(frm, "Öğrenci Düzenle");
            }
        }

        private void filtreDegisimi_SelectedIndexChanged(object sender, EventArgs e)
        {
            try { Listeleme.Listele(); }
            catch { }
        }

        private void ortakTipselSiralama_Click(object sender, EventArgs e)
        {
            Listeleme.SeciliSiraTipiTSMI = sender;
            Listeleme.Listele();
        }

        private void ortakSutunSiralama_Click(object sender, EventArgs e)
        {
            Listeleme.SeciliSiraSutunTSMI = sender;
            Listeleme.Listele();
        }

        private void ortakArama_Click(object sender, EventArgs e)
        {
            Listeleme.AramaYap(true);
        }

        private void ortakAramaIptal_Click(object sender, EventArgs e)
        {
            Listeleme.AramaYap(false);
        }

        private void ortakSil_Click(object sender, EventArgs e)
        {
            Listeleme.SecilileriSil();
        }

        private void tsBtnVeliDuzenle_Click(object sender, EventArgs e)
        {
            if (Listeleme.SatirSeciliMi)
            {
                frmAltVeliDuzenle frm = new frmAltVeliDuzenle(Listeleme.SatirIndex);
                altFormAc(frm, "Veli Düzenle");
            }
        }

        private void ogrenciDurumIslemleri_Click(object sender, EventArgs e)
        {
            if (Listeleme.SatirSeciliMi)
            {
                ToolStripMenuItem tsmiOgrenciDurum = sender as ToolStripMenuItem;
                if (dbIslem.aynisiVarmi("IliskisiKesilmisler", "OgrenciID", Listeleme.SatirIndex))
                {
                    dbIslem.dbHizliGuncelle("IliskisiKesilmisler", "OgrenciID", Listeleme.SatirIndex, "Sebep", tsmiOgrenciDurum.Tag.ToString());
                }
                else
                {
                    dbIslem.dbEkleVeriIslem("IliskisiKesilmisler", null, null, "OgrenciID", "Sebep", Listeleme.SatirIndex, tsmiOgrenciDurum.Tag.ToString());
                    dbIslem.dbHizliGuncelle("Ogrenciler", "OgrenciID", Listeleme.SatirIndex, "DevamEdiyorMu", "0");

                }
                Listeleme.Listele();
            }
            else
            {
                MessageBox.Show("Hiç öğrenci seçmediniz!");
            }
        }

        private void ortakMesajGonder_Click(object sender, EventArgs e)
        {
            if (Listeleme.SatirSeciliMi)
            {
                frmlAltMesajGonder frm = new frmlAltMesajGonder(uyeID, Listeleme.SatirIndex, null);
                altFormAc(frm, "Mesaj Gönder");
            }
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (tabControl1.SelectedIndex)
            {
                case 0:
                    {
                        //gelen kutusu
                        tsTxtGelenMsjArama.Clear();
                        OrtakListeleme ol = new OrtakListeleme();
                        ol.KontrolleriEkle(lvGelenMsj, tsTxtGelenMsjArama, tsBtnGelenMsjArama, tsBtnGelenMsjAramaIptal);
                        ol.SiralamaKontrolleri(miGelenMsjSiraAZ, miGelenMsjSiraZA);
                        ol.SqlSorgusuYarat("SELECT m.MesajID, CASE m.KimdenID WHEN fo.OgrenciID THEN fo.OgrenciAdi + ' ' + fo.OgrenciSoyadi WHEN fv.VeliID THEN  fv.VeliAdi + ' ' + fv.VeliSoyadi WHEN fe.OgretmenID THEN fe.OgretmenAdi + ' ' + fe.OgretmenSoyadi END AS Kimden, CASE m.KimeID WHEN tor.OgrenciID THEN tor.OgrenciAdi + ' ' + tor.OgrenciSoyadi WHEN tv.VeliID THEN  tv.VeliAdi + ' ' + tv.VeliSoyadi WHEN te.OgretmenID THEN te.OgretmenAdi + ' ' + te.OgretmenSoyadi END AS Kime, m.KimdenID, m.KimeID, m.Baslik, m.Tarih, CASE WHEN fe.Gorev = 1 THEN 'Müdür' WHEN fe.Gorev = 2 THEN 'Müdür Yardımcısı' WHEN m.KimdenID=fo.OgrenciID THEN 'Öğrenci' WHEN m.KimdenID=fv.VeliID THEN 'Veli' WHEN m.KimdenID=fe.OgretmenID THEN 'Öğretmen' END AS Statu, m.OkunduMu FROM Mesajlar m LEFT JOIN Ogrenciler fo ON fo.OgrenciID=m.KimdenID LEFT JOIN Ogretmenler fe ON fe.OgretmenID=m.KimdenID LEFT JOIN Veliler fv ON fv.VeliID=m.KimdenID LEFT JOIN Ogrenciler tor ON tor.OgrenciID=m.KimeID LEFT JOIN Ogretmenler te ON te.OgretmenID=m.KimeID LEFT JOIN Veliler tv ON tv.VeliID=m.KimeID WHERE m.KimeID='" + uyeID + "'", "m.MesajID");
                        ol.SqlSutunlar("Kimden", "Baslik", "Tarih", "Statu");
                        ol.SqlSutunlarArama("m.Baslik");
                        ol.Siralama.Ekle(miGelenMsjSiraAdaGore, "Kimden");
                        ol.Siralama.Ekle(miGelenMsjSiraKonuyaGore, "m.Baslik");
                        ol.Siralama.Ekle(miGelenMsjTariheGore, "m.Tarih");
                        ol.SeciliSiraSutunTSMI = miGelenMsjTariheGore;
                        ol.SeciliSiraTipiTSMI = miGelenMsjSiraZA;
                        ol.Arama = false;
                        ol.Listele();
                        Listeleme = ol;
                        break;
                    }
                default:
                    {
                        //giden kutusu
                        tsTxtGidenMjsArama.Clear();
                        OrtakListeleme ol = new OrtakListeleme();
                        ol.KontrolleriEkle(lvGidenMsj, tsTxtGidenMjsArama, tsBtnGidenMsjArama, tsBtnGidenMsjAramaIptal);
                        ol.SiralamaKontrolleri(miGidenMsjSiraAZ, miGidenMsjSiraZA);
                        ol.SqlSorgusuYarat("SELECT m.MesajID, CASE m.KimdenID WHEN fo.OgrenciID THEN fo.OgrenciAdi + ' ' + fo.OgrenciSoyadi WHEN fv.VeliID THEN  fv.VeliAdi + ' ' + fv.VeliSoyadi WHEN fe.OgretmenID THEN fe.OgretmenAdi + ' ' + fe.OgretmenSoyadi END AS Kimden, CASE m.KimeID WHEN tor.OgrenciID THEN tor.OgrenciAdi + ' ' + tor.OgrenciSoyadi WHEN tv.VeliID THEN  tv.VeliAdi + ' ' + tv.VeliSoyadi WHEN te.OgretmenID THEN te.OgretmenAdi + ' ' + te.OgretmenSoyadi END AS Kime, m.KimdenID, m.KimeID, m.Baslik, m.Tarih, CASE WHEN te.Gorev = 1 THEN 'Müdür' WHEN te.Gorev = 2 THEN 'Müdür Yardımcısı' WHEN m.KimeID=fo.OgrenciID THEN 'Öğrenci' WHEN m.KimeID=fv.VeliID THEN 'Veli' WHEN m.KimeID=fe.OgretmenID THEN 'Öğretmen' END AS Statu, m.OkunduMu FROM Mesajlar m LEFT JOIN Ogrenciler fo ON fo.OgrenciID=m.KimdenID LEFT JOIN Ogretmenler fe ON fe.OgretmenID=m.KimdenID LEFT JOIN Veliler fv ON fv.VeliID=m.KimdenID LEFT JOIN Ogrenciler tor ON tor.OgrenciID=m.KimeID LEFT JOIN Ogretmenler te ON te.OgretmenID=m.KimeID LEFT JOIN Veliler tv ON tv.VeliID=m.KimeID WHERE m.KimdenID='" + uyeID + "'", "m.MesajID");
                        ol.SqlSutunlar("Kime", "Baslik", "Tarih", "Statu");
                        ol.SqlSutunlarArama("m.Baslik");
                        ol.Siralama.Ekle(miGidenMsjSiraAdaGore, "Kime");
                        ol.Siralama.Ekle(miGidenMsjSiraKonuyaGore, "m.Baslik");
                        ol.Siralama.Ekle(miGidenMsjSiraTariheGore, "m.Tarih");
                        ol.SeciliSiraSutunTSMI = miGidenMsjSiraTariheGore;
                        ol.SeciliSiraTipiTSMI = miGidenMsjSiraZA;
                        ol.Arama = false;
                        ol.Listele();
                        Listeleme = ol;
                        break;
                    }
            }
        }

        private void tsBtnMsjCevapYaz_Click(object sender, EventArgs e)
        {
            if (Listeleme.SatirSeciliMi)
            {
                frmlAltMesajGonder frm = new frmlAltMesajGonder(uyeID, null, Listeleme.SatirIndex);
                altFormAc(frm, "Cevap Yaz");
            }
        }

        private void lvGelenMsj_DoubleClick(object sender, EventArgs e)
        {
            if (Listeleme.SatirSeciliMi)
            {
                frmAltMesajOku frm = new frmAltMesajOku(Listeleme.SatirIndex);
                altFormAc(frm, "Mesaj Oku");
            }
        }

        private void tsBtnDevamsizlikEkle_Click(object sender, EventArgs e)
        {
            frmAltDevamsizlikEkle frm = new frmAltDevamsizlikEkle();
            altFormAc(frm, "Devamsızlık Ekle");
        }

        private void DevamsizlikIslem_Click(object sender, EventArgs e)
        {
            if (Listeleme.SatirSeciliMi)
            {
                ToolStripMenuItem tsmi = sender as ToolStripMenuItem;
                dbIslem.dbHizliGuncelle("OgrenciDevamsizlik", "odID", Listeleme.SatirIndex, "OzelNeden", tsmi.Tag.ToString());
                Listeleme.Listele();
            }
            else
            {
                MessageBox.Show("Hiç öğrenci seçmediniz!");
            }
        }

        private void lvOgrenciler_DoubleClick(object sender, EventArgs e)
        {
            if (Listeleme.SatirSeciliMi)
            {
                frmAltOgrenciGoster frm = new frmAltOgrenciGoster(Listeleme.SatirIndex);
                altFormAc(frm, "Öğrenci Bilgileri");
            }
        }

        private void tabControl2_SelectedIndexChanged(object sender, EventArgs e)
        {
            /*
             tsComboDerslikKat.Items.Clear();
                    tsComboDerslikKat.Items.Add("Hepsi");
                    for (int i = 0; i < 15; i++)
                        tsComboDerslikKat.Items.Add(i);
                    tsComboDerslikKat.SelectedIndex = 0;
                    tsTxtDerslikArama.Clear();
                    
                    OrtakListeleme ol = new OrtakListeleme();
                    ol.KontrolleriEkle();
                    ol.SiralamaKontrolleri();
                    ol.SqlSorgusuYarat();
                    ol.SqlSutunlar();
                    ol.SqlSutunlarArama();
                    ol.Siralama.Ekle();
                    ol.Siralama.Ekle();
                    ol.Siralama.Ekle();
                    ol.Siralama.Ekle();
                    ol.Filtre.Ekle();
                    ol.Filtre.Ekle();
                    ol.Filtre.Ekle();
                    ol.Filtre.Ekle();
                    ol.SeciliSiraSutunTSMI = ;
                    ol.SeciliSiraTipiTSMI = ;
                    ol.Arama = false;
                    ol.Listele();
                    Listeleme = ol;
             */
            SqlCommand cmd;
            SqlDataReader sdr;
            switch (tabControl2.SelectedIndex)
            {
                case 0:
                    {
                        //Karneler
                        tsCbKarneSinif.Items.Clear();
                        tsCbKarneKademe.Items.Clear();
                        tsCbKarneD1Print.Items.Clear();
                        tsCbKarneD2Print.Items.Clear();
                        tsCbKarneSinif.Items.Add("Hepsi");
                        cmd = new SqlCommand("SELECT * FROM Siniflar ORDER BY Kademe, Sube", conn);
                        conn.Open();
                        sdr = cmd.ExecuteReader();
                        while (sdr.Read())
                        {
                            VeriTututucu vt = new VeriTututucu();
                            vt.veriID = sdr["SinifID"].ToString();
                            vt.VeriAdi = sdr["Kademe"] + " " + sdr["Sube"];
                            tsCbKarneSinif.Items.Add(vt);
                        }
                        conn.Close();
                        tsCbKarneKademe.Items.Add("Hepsi");
                        for (int i = 9; i < 13; i++)
                            tsCbKarneKademe.Items.Add(i.ToString());
                        tsCbKarneD1Print.Items.Add("Hepsi");
                        for (int i = 0; i < 3; i++)
                        {
                            VeriTututucu vt = new VeriTututucu();
                            vt.veriID = i.ToString();
                            vt.VeriAdi = i == 0 ? "1.D Yazdırılmışlar" : "1.D Yazdırılmamışlar";
                            tsCbKarneD1Print.Items.Add(vt);
                        }
                        tsCbKarneD2Print.Items.Add("Hepsi");
                        for (int i = 0; i < 3; i++)
                        {
                            VeriTututucu vt = new VeriTututucu();
                            vt.veriID = i.ToString();
                            vt.VeriAdi = i == 0 ? "2.D Yazdırılmışlar" : "2.D Yazdırılmamışlar";
                            tsCbKarneD2Print.Items.Add(vt);
                        }
                        tsCbKarneSinif.SelectedIndex = 0;
                        tsCbKarneKademe.SelectedIndex = 0;
                        tsCbKarneD1Print.SelectedIndex = 0;
                        tsCbKarneD2Print.SelectedIndex = 0;
                        OrtakListeleme ol = new OrtakListeleme();
                        ol.KontrolleriEkle(lvKarne, tsTxtKarneArama, tsBtnKarneArama, tsBtnKarneAramaIptal);
                        ol.SiralamaKontrolleri(tsMiKarneSiraAZ, tsMiKarneSiraZA);
                        ol.SqlSorgusuYarat("SELECT k.KarneID, o.OgrenciID, o.OkulNo, o.OgrenciAdi + ' ' + o.OgrenciSoyadi AS Ogrenci, CONVERT(NVARCHAR(2),s.Kademe) + ' ' + s.Sube AS Sinif, CASE k.D1PrintEdildiMi WHEN 1 THEN 'Alındı' ELSE 'Alınmadı' END AS D1PE, CASE k.D2PrintEdildiMi WHEN 1 THEN 'Alındı' ELSE 'Alınmadı' END AS D2PE FROM Ogrenciler o JOIN Karneler k ON k.OgrenciID=o.OgrenciID JOIN Siniflar s ON s.SinifID=o.SinifID", "k.KarneID");
                        ol.SqlSutunlar("OkulNo", "Ogrenci", "Sinif", "D1PE", "D2PE");
                        ol.SqlSutunlarArama("o.OgrenciAdi", "o.OgrenciSoyadi", "o.OkulNo");
                        ol.Siralama.Ekle(tsMiKarneAdaGore, "o.OgrenciAdi, o.OgrenciSoyadi");
                        ol.Siralama.Ekle(tsMiKarneOkulNoGore, "o.OkulNo");
                        ol.Siralama.Ekle(tsMiKarneSinifaGore, "s.Kademe, s.Sube");
                        ol.Filtre.Ekle(tsCbKarneKademe, "s.Kademe");
                        ol.Filtre.Ekle(tsCbKarneSinif, "s.SinifID");
                        ol.Filtre.Ekle(tsCbKarneD1Print, "k.D1PrintEdildiMi");
                        ol.Filtre.Ekle(tsCbKarneD2Print, "k.D2PrintEdildiMi");
                        ol.SeciliSiraSutunTSMI = tsMiKarneAdaGore;
                        ol.SeciliSiraTipiTSMI = tsMiKarneSiraAZ;
                        ol.Arama = false;
                        ol.Listele();
                        Listeleme = ol;
                        break;
                    }
                case 1:
                    {
                        //Onur Belgesi
                        cbBonurSinif.Items.Clear();
                        cbBonurKademe.Items.Clear();
                        cbBonurPrint.Items.Clear();
                        cbBonurSinif.Items.Add("Hepsi");
                        cmd = new SqlCommand("SELECT * FROM Siniflar ORDER BY Kademe, Sube", conn);
                        conn.Open();
                        sdr = cmd.ExecuteReader();
                        while (sdr.Read())
                        {
                            VeriTututucu vt = new VeriTututucu();
                            vt.veriID = sdr["SinifID"].ToString();
                            vt.VeriAdi = sdr["Kademe"] + " " + sdr["Sube"];
                            cbBonurSinif.Items.Add(vt);
                        }
                        conn.Close();
                        cbBonurKademe.Items.Add("Hepsi");
                        for (int i = 9; i < 13; i++)
                            cbBonurKademe.Items.Add(i.ToString());
                        cbBonurPrint.Items.Add("Hepsi");
                        for (int i = 0; i < 3; i++)
                        {
                            VeriTututucu vt = new VeriTututucu();
                            vt.veriID = i.ToString();
                            vt.VeriAdi = i == 0 ? "1.D Yazdırılmışlar" : "1.D Yazdırılmamışlar";
                            cbBonurPrint.Items.Add(vt);
                        }
                        cbBonurSinif.SelectedIndex = 0;
                        cbBonurKademe.SelectedIndex = 0;
                        cbBonurPrint.SelectedIndex = 0;
                        OrtakListeleme ol = new OrtakListeleme();
                        ol.KontrolleriEkle(lvBelgeOnur, tsTxtBonurArama, tsBtnBonurArama, tsBtnBonurAramaIptal);
                        ol.SiralamaKontrolleri(tsMiBonurAZ, tsMiBonurZA);
                        ol.SqlSorgusuYarat("SELECT bo.BelgeOnurID, o.OgrenciID, o.OkulNo, o.OgrenciAdi + ' ' + o.OgrenciSoyadi AS Ogrenci, CONVERT(NVARCHAR(2),s.Kademe) + ' ' + s.Sube AS Sinif, bo.Donem, CASE bo.PrintEdildiMi WHEN 1 THEN 'Alındı' ELSE 'Alınmadı' END AS DPE FROM Ogrenciler o JOIN BelgeOnur bo ON bo.OgrenciID=o.OgrenciID JOIN Siniflar s ON s.SinifID=o.SinifID", "bo.BelgeOnurID");
                        ol.SqlSutunlar("OkulNo", "Ogrenci", "Sinif", "Donem", "DPE");
                        ol.SqlSutunlarArama("o.OgrenciAdi", "o.OgrenciSoyadi", "o.OkulNo");
                        ol.Siralama.Ekle(tsMiBonurAdaGore, "o.OgrenciAdi, o.OgrenciSoyadi");
                        ol.Siralama.Ekle(tsMiBonurOkulaGore, "o.OkulNo");
                        ol.Siralama.Ekle(tsMiBonurSinifaGore, "s.Kademe, s.Sube");
                        ol.Filtre.Ekle(cbBonurKademe, "s.Kademe");
                        ol.Filtre.Ekle(cbBonurSinif, "s.SinifID");
                        ol.Filtre.Ekle(cbBonurPrint, "bo.PrintEdildiMi");
                        ol.SeciliSiraSutunTSMI = tsMiBonurAdaGore;
                        ol.SeciliSiraTipiTSMI = tsMiBonurAZ;
                        ol.Arama = false;
                        ol.Listele();
                        Listeleme = ol;
                        break;
                    }
                case 2:
                    {
                        //Teşekkür Belgesi
                        cbBtskSinif.Items.Clear();
                        cbTskKademe.Items.Clear();
                        cbTskPrint.Items.Clear();
                        cbBtskSinif.Items.Add("Hepsi");
                        cmd = new SqlCommand("SELECT * FROM Siniflar ORDER BY Kademe, Sube", conn);
                        conn.Open();
                        sdr = cmd.ExecuteReader();
                        while (sdr.Read())
                        {
                            VeriTututucu vt = new VeriTututucu();
                            vt.veriID = sdr["SinifID"].ToString();
                            vt.VeriAdi = sdr["Kademe"] + " " + sdr["Sube"];
                            cbBtskSinif.Items.Add(vt);
                        }
                        conn.Close();
                        cbTskKademe.Items.Add("Hepsi");
                        for (int i = 9; i < 13; i++)
                            cbTskKademe.Items.Add(i.ToString());
                        cbTskPrint.Items.Add("Hepsi");
                        for (int i = 0; i < 3; i++)
                        {
                            VeriTututucu vt = new VeriTututucu();
                            vt.veriID = i.ToString();
                            vt.VeriAdi = i == 0 ? "1.D Yazdırılmışlar" : "1.D Yazdırılmamışlar";
                            cbTskPrint.Items.Add(vt);
                        }
                        cbBtskSinif.SelectedIndex = 0;
                        cbTskKademe.SelectedIndex = 0;
                        cbTskPrint.SelectedIndex = 0;
                        OrtakListeleme ol = new OrtakListeleme();
                        ol.KontrolleriEkle(lvBelgeTesekkur, tsTxtTskArama, tsBtnBtskArama, tsBtnBtskAramaIptal);
                        ol.SiralamaKontrolleri(miBtskSiraAZ, miBtskSiraZA);
                        ol.SqlSorgusuYarat("SELECT bt.BelgeTesekkurID, o.OgrenciID, o.OkulNo, o.OgrenciAdi + ' ' + o.OgrenciSoyadi AS Ogrenci, CONVERT(NVARCHAR(2),s.Kademe) + ' ' + s.Sube AS Sinif, bt.Donem, CASE bt.PrintEdildiMi WHEN 1 THEN 'Alındı' ELSE 'Alınmadı' END AS DPE FROM Ogrenciler o JOIN BelgeTesekkur bt ON bt.OgrenciID=o.OgrenciID JOIN Siniflar s ON s.SinifID=o.SinifID", "bo.BelgeTesekkurID");
                        ol.SqlSutunlar("OkulNo", "Ogrenci", "Sinif", "Donem", "DPE");
                        ol.SqlSutunlarArama("o.OgrenciAdi", "o.OgrenciSoyadi", "o.OkulNo");
                        ol.Siralama.Ekle(miBtskAdaGore, "o.OgrenciAdi, o.OgrenciSoyadi");
                        ol.Siralama.Ekle(miBtskNoyaGore, "o.OkulNo");
                        ol.Siralama.Ekle(miBtskSinifaGore, "s.Kademe, s.Sube");
                        ol.Filtre.Ekle(cbTskKademe, "s.Kademe");
                        ol.Filtre.Ekle(cbBtskSinif, "s.SinifID");
                        ol.Filtre.Ekle(cbTskPrint, "bo.PrintEdildiMi");
                        ol.SeciliSiraSutunTSMI = miBtskAdaGore;
                        ol.SeciliSiraTipiTSMI = miBtskSiraAZ;
                        ol.Arama = false;
                        ol.Listele();
                        Listeleme = ol;
                        break;
                    }
                case 3:
                    {
                        //Takdir Belgesi

                        cbTakSinif.Items.Clear();
                        cbTakKademe.Items.Clear();
                        cbTskPrint.Items.Clear();
                        cbTakPrint.Items.Add("Hepsi");
                        cmd = new SqlCommand("SELECT * FROM Siniflar ORDER BY Kademe, Sube", conn);
                        conn.Open();
                        sdr = cmd.ExecuteReader();
                        while (sdr.Read())
                        {
                            VeriTututucu vt = new VeriTututucu();
                            vt.veriID = sdr["SinifID"].ToString();
                            vt.VeriAdi = sdr["Kademe"] + " " + sdr["Sube"];
                            cbTakSinif.Items.Add(vt);
                        }
                        conn.Close();
                        cbTakKademe.Items.Add("Hepsi");
                        for (int i = 9; i < 13; i++)
                            cbTakKademe.Items.Add(i.ToString());
                        cbTakPrint.Items.Add("Hepsi");
                        for (int i = 0; i < 3; i++)
                        {
                            VeriTututucu vt = new VeriTututucu();
                            vt.veriID = i.ToString();
                            vt.VeriAdi = i == 0 ? "1.D Yazdırılmışlar" : "1.D Yazdırılmamışlar";
                            cbTakPrint.Items.Add(vt);
                        }
                        cbTakSinif.SelectedIndex = 0;
                        cbTakKademe.SelectedIndex = 0;
                        cbTakPrint.SelectedIndex = 0;
                        OrtakListeleme ol = new OrtakListeleme();
                        ol.KontrolleriEkle(lvBelgeTaktir, tsTxtTakArama, tsBtnTakArama, tsBtnTakAramaIptal);
                        ol.SiralamaKontrolleri(miTakAZ, miTakZA);
                        ol.SqlSorgusuYarat("SELECT bt.BelgeTekdirID, o.OgrenciID, o.OkulNo, o.OgrenciAdi + ' ' + o.OgrenciSoyadi AS Ogrenci, CONVERT(NVARCHAR(2),s.Kademe) + ' ' + s.Sube AS Sinif, bt.Donem, CASE bt.PrintEdildiMi WHEN 1 THEN 'Alındı' ELSE 'Alınmadı' END AS DPE FROM Ogrenciler o JOIN BelgeTakdir bt ON bt.OgrenciID=o.OgrenciID JOIN Siniflar s ON s.SinifID=o.SinifID", "bo.BelgeTekdirID");
                        ol.SqlSutunlar("OkulNo", "Ogrenci", "Sinif", "Donem", "DPE");
                        ol.SqlSutunlarArama("o.OgrenciAdi", "o.OgrenciSoyadi", "o.OkulNo");
                        ol.Siralama.Ekle(miTakAdaGore, "o.OgrenciAdi, o.OgrenciSoyadi");
                        ol.Siralama.Ekle(miTakNoyaGore, "o.OkulNo");
                        ol.Siralama.Ekle(miTakSinifaGore, "s.Kademe, s.Sube");
                        ol.Filtre.Ekle(cbTakKademe, "s.Kademe");
                        ol.Filtre.Ekle(cbTakSinif, "s.SinifID");
                        ol.Filtre.Ekle(cbTakPrint, "bo.PrintEdildiMi");
                        ol.SeciliSiraSutunTSMI = miTakAdaGore;
                        ol.SeciliSiraTipiTSMI = miTakAZ;
                        ol.Arama = false;
                        ol.Listele();
                        Listeleme = ol;
                        break;
                    }
            }

        }

        string NotBul(string puan)
        {
            int sayi = Convert.ToInt32(puan);
            string not = null;
            if (sayi >= 85)
            {
                not = "5";
            }
            else if (sayi >= 75)
            {
                not = "4";
            }
            else if (sayi >= 55)
            {
                not = "3";
            }
            else if (sayi >= 45)
            {
                not = "2";
            }
            else if (sayi >= 21)
            {
                not = "1";
            }
            else
            {
                not = "0";
            }
            return not;
        }

        private void lvKarne_DoubleClick(object sender, EventArgs e)
        {
            if (Listeleme.SatirSeciliMi)
            {
                frmAltKarneDetay frm = new frmAltKarneDetay(Listeleme.SatirIndex);
                altFormAc(frm, "Karne Detay");
            }
        }

        private void lvBelgeOnur_DoubleClick(object sender, EventArgs e)
        {
            if (Listeleme.SatirSeciliMi)
            {
                frmAltBelgeDetay frm = new frmAltBelgeDetay(Listeleme.SatirIndex, "ONUR BELGESİ");
                altFormAc(frm, "Belge Detay");
            }
        }

        private void lvBelgeTesekkur_DoubleClick(object sender, EventArgs e)
        {
            if (Listeleme.SatirSeciliMi)
            {
                frmAltBelgeDetay frm = new frmAltBelgeDetay(Listeleme.SatirIndex, "TEŞEKKÜR BELGESİ");
                altFormAc(frm, "Belge Detay");
            }
        }

        private void lvBelgeTaktir_DoubleClick(object sender, EventArgs e)
        {
            if (Listeleme.SatirSeciliMi)
            {
                frmAltBelgeDetay frm = new frmAltBelgeDetay(Listeleme.SatirIndex, "TAKTİR BELGESİ");
                altFormAc(frm, "Belge Detay");
            }
        }
    }
}
