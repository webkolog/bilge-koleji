using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using System.Data.SqlClient;
using System.Text.RegularExpressions;
using System.Web.Security;
using System.ComponentModel;
using System.Drawing;

namespace Windows_Uygulamasi
{

    class Kullanici
    {
        public string SifreOlusturucu(int karakter)
        {
            ArrayList sifreDizisi = new ArrayList();
            Random rnd = new Random();
            string sifre = null;
            for (int i = 48; i < 58; i++)
                sifreDizisi.Add(Convert.ToChar(i));
            for (int i = 65; i < 91; i++)
                sifreDizisi.Add(Convert.ToChar(i));
            for (int i = 97; i < 123; i++)
                sifreDizisi.Add(Convert.ToChar(i));
            for (int i = 0; i < karakter; i++)
                sifre += sifreDizisi[rnd.Next(0, sifreDizisi.Count)];
            return sifre;
        }

        public bool EmailKontrol(string EmailAdresi)
        {
            string Kurallar = "^([0-9a-zA-Z]([-.\\w]*[0-9a-zA-Z])*@([0-9a-zA-Z][-\\w]*[0-9a-zA-Z]\\.)+[a-zA-Z]{2,9})$";
            return Regex.IsMatch(EmailAdresi, Kurallar);
        }

        public bool UrlKontrol(string url)
        {
            string Kurallar = @"^(http|https|ftp)\://[a-zA-Z0-9\-\.]+\.[a-zA-Z]{2,3}(:[a-zA-Z0-9]*)?/?([a-zA-Z0-9\-\._\?\,\'/\\\+&amp;%\$#\=~])*[^\.\,\)\(\s]$";
            Regex reg = new Regex(Kurallar, RegexOptions.Compiled | RegexOptions.IgnoreCase);
            return reg.IsMatch(url);
        }

        public bool TelKontrol(string telno)
        {
            string Kurallar = @"^\([0-9]{3}\) [0-9]{3}-[0-9]{4}$";
            return Regex.IsMatch(telno, Kurallar);
        }

        public bool TcKimlikKontrol(string tcKimlik)
        {
            string Kurallar = @"^[0-9]{11}$";
            return Regex.IsMatch(tcKimlik, Kurallar);
        }

        private string mailDomain = "@bilgekoleji.com";

        public string mailOlusturucu(string isim, string soyad)
        {
            char[] Kelimeler = { 'Ğ', 'Ü', 'Ş', 'İ', 'Ö', 'Ç', 'ğ', 'ü', 'ş', 'ı', 'ö', 'ç' };
            char[] yeniKelimeler = { 'G', 'U', 'S', 'I', 'O', 'C', 'g', 'u', 's', 'i', 'o', 'c' };
            for (int i = 0; i <= 11; i++)
                isim = isim.Replace(Kelimeler[i], yeniKelimeler[i]);
            for (int i = 0; i <= 11; i++)
                soyad = soyad.Replace(Kelimeler[i], yeniKelimeler[i]);
            isim = isim.ToLowerInvariant();
            soyad = soyad.ToLowerInvariant();
            string mailAdres;
            if (soyad.Trim().Length > 0)
                mailAdres = isim.Trim().Replace(' ', '.') + "." + soyad.Trim() + mailDomain;
            else
                mailAdres = isim.Trim().Replace(' ', '.') + mailDomain;
            return mailAdres;
        }
    }

    class HataTutucu
    {
        private string _Hatalar;
        private bool _HataVarMi;

        public bool HataVarMi
        {
            get
            {
                return _HataVarMi;
            }
            set
            {
                throw new Exception("Bu özellik sadece okunabilir!");
            }
        }

        public void hataEkle(string Hata)
        {
            _HataVarMi = true;
            _Hatalar += Hata + "!\n";
        }

        public void HatalariGoster()
        {
            System.Windows.Forms.MessageBox.Show(_Hatalar, "Uyarı");
        }
    }

    class VeriTututucu
    {
        public string veriID;
        public string VeriAdi;
        public override string ToString()
        {
            return VeriAdi;
        }
    }

    class tsMiContainer
    {
        private ToolStripMenuItem[] KontrollerSL = new ToolStripMenuItem[] { };
        private string[] SutunlarSL = new string[] { };

        public void Ekle(ToolStripMenuItem tsMi, string strSutun)
        {
            Array.Resize(ref KontrollerSL, KontrollerSL.Length + 1);
            KontrollerSL[KontrollerSL.Length - 1] = tsMi;
            Array.Resize(ref SutunlarSL, SutunlarSL.Length + 1);
            SutunlarSL[SutunlarSL.Length - 1] = strSutun;
        }

        public ToolStripMenuItem[] Kontroller
        {
            get
            {
                return KontrollerSL;
            }
        }

        public string[] Sutunlar
        {
            get
            {
                return SutunlarSL;
            }
        }
    }

    class tsCbContainer
    {
        private ToolStripComboBox[] KontrollerFL = new ToolStripComboBox[] { };
        private string[] SutunlarFL = new string[] { };

        public void Ekle(ToolStripComboBox tsMi, string strSutun)
        {
            Array.Resize(ref KontrollerFL, KontrollerFL.Length + 1);
            KontrollerFL[KontrollerFL.Length - 1] = tsMi;
            Array.Resize(ref SutunlarFL, SutunlarFL.Length + 1);
            SutunlarFL[SutunlarFL.Length - 1] = strSutun;
        }

        public ToolStripComboBox[] Kontroller { get { return KontrollerFL; } }
        public string[] Sutunlar { get { return SutunlarFL; } }
    }

    class OrtakListeleme
    {
        private ListView lstView;
        private ToolStripTextBox tsTxtBoxArama;
        private ToolStripButton tsBtnArama, tsBtnAramaIptal;
        private ToolStripMenuItem tsMiSiralamaAZ, tsMiSiralamaZA;
        private string SqlSorgusu, SqlIdSutunAdi;
        private string[] _SqlSutunlar, _SqlSutunlarArama;
        tsMiContainer tsMiC = new tsMiContainer();
        tsCbContainer tsCbC = new tsCbContainer();
        private object _SeciliSiraTipiTSMI;
        private object _SeciliSiraSutunTSMI;
        private string Tablo;



        public bool Arama
        {
            set
            {
                tsBtnAramaIptal.Enabled = value;
            }
        }

        public object SeciliSiraTipiTSMI
        {
            set
            {
                _SeciliSiraTipiTSMI = value;
            }
        }

        public object SeciliSiraSutunTSMI
        {
            set
            {
                _SeciliSiraSutunTSMI = value;
            }
        }

        public ListView ListView
        {
            get
            {
                return lstView;
            }
        }

        public tsMiContainer Siralama
        {
            get
            {
                return tsMiC;
            }
        }

        public tsCbContainer Filtre
        {
            get
            {
                return tsCbC;
            }
        }

        public void KontrolleriEkle(ListView _lstView, ToolStripTextBox _tsTxtBox, ToolStripButton _tsBtnArama, ToolStripButton _tsBtnAramaIptal)
        {
            lstView = _lstView;
            tsTxtBoxArama = _tsTxtBox;
            tsBtnArama = _tsBtnArama;
            tsBtnAramaIptal = _tsBtnAramaIptal;
        }

        public void SiralamaKontrolleri(ToolStripMenuItem _tsMiSiralamaAZ, ToolStripMenuItem _tsMiSiralamaZA)
        {
            tsMiSiralamaAZ = _tsMiSiralamaAZ;
            tsMiSiralamaZA = _tsMiSiralamaZA;
        }

        public void SqlSorgusuYarat(string SqlSorgu, string IdSutunAdi)
        {
            SqlSorgusu = SqlSorgu;
            SqlIdSutunAdi = IdSutunAdi;
            string KelimeBaslangic = "FROM ";
            int IndexBaslangic = SqlSorgusu.IndexOf(KelimeBaslangic) + KelimeBaslangic.Length;
            int IndexBitis = SqlSorgusu.IndexOf(' ', IndexBaslangic);
            int Genislik = IndexBitis - IndexBaslangic;
            Tablo = SqlSorgusu.Substring(IndexBaslangic, Genislik < 0 ? (SqlSorgusu.Length - IndexBaslangic) : Genislik);
        }

        public void SqlSutunlar(params string[] sutunlar)
        {
            _SqlSutunlar = sutunlar;
        }

        public void SqlSutunlarArama(params string[] sutunlar)
        {
            _SqlSutunlarArama = sutunlar;
        }

        public void AramaYap(bool aramaGecerliMi)
        {
            if (aramaGecerliMi & tsTxtBoxArama.Text.Length > 0)
            {
                tsBtnAramaIptal.Enabled = true;
            }
            else
            {
                tsBtnAramaIptal.Enabled = false;
            }
            Listele();
        }

        public void Listele()
        {
            string AramaKelime = null, SqlFiltre = null, SqlSiraYonu = null, SqlSiraTuru = SqlIdSutunAdi;
            string[] SqlFiltrecikler = new string[] { };
            if (tsBtnAramaIptal.Enabled)
            {
                AramaKelime = tsTxtBoxArama.Text;
            }
            else
            {
                tsTxtBoxArama.Clear();
                AramaKelime = null;
            }
            for (int i = 0; i < tsCbC.Sutunlar.Length; i++)
            {
                if (tsCbC.Kontroller[i].Text != "Hepsi")
                    if (SqlFiltre != null)
                        SqlFiltre += " AND " + tsCbC.Sutunlar[i] + "=@" + tsCbC.Sutunlar[i].Split('.').Last();
                    else
                        SqlFiltre += " " + tsCbC.Sutunlar[i] + "=@" + tsCbC.Sutunlar[i].Split('.').Last();
            }
            if (tsMiSiralamaZA.Name == (_SeciliSiraTipiTSMI as ToolStripMenuItem).Name)
            {
                tsMiSiralamaZA.Checked = true;
                tsMiSiralamaAZ.Checked = false;
            }
            else
            {
                tsMiSiralamaZA.Checked = false;
                tsMiSiralamaAZ.Checked = true;
            }
            if (tsMiSiralamaZA.Checked)
                SqlSiraYonu = "DESC";
            else
                SqlSiraYonu = "ASC";

            for (int i = 0; i < tsMiC.Sutunlar.Length; i++)
            {
                if ((_SeciliSiraSutunTSMI as ToolStripMenuItem).Name == tsMiC.Kontroller[i].Name)
                {
                    tsMiC.Kontroller[i].Checked = true;
                    SqlSiraTuru = tsMiC.Sutunlar[i];
                }
                else
                {
                    tsMiC.Kontroller[i].Checked = false;
                }
            }
            if (AramaKelime != null)
            {
                int i = 0;
                foreach (string SqlAramaSutunu in _SqlSutunlarArama)
                {
                    Array.Resize(ref SqlFiltrecikler, SqlFiltrecikler.Length + 1);
                    if (SqlFiltre != null)
                        SqlFiltrecikler[SqlFiltrecikler.Length - 1] = SqlFiltre + " AND " + SqlAramaSutunu + " LIKE '%'+@AraKelime+'%'";
                    else
                        SqlFiltrecikler[SqlFiltrecikler.Length - 1] = SqlFiltre + " " + SqlAramaSutunu + " LIKE '%'+@AraKelime+'%'";
                    i++;
                }
                for (i = 0; i < SqlFiltrecikler.Length; i++)
                {
                    if (i > 0)
                        SqlFiltre += " OR " + SqlFiltrecikler[i];
                    else
                        SqlFiltre = SqlFiltrecikler[i];
                }
            }
            else
            {
                tsTxtBoxArama.Clear();
            }
            if (SqlFiltre != null)
                SqlFiltre = " WHERE" + SqlFiltre;
            string[] SqlSiraTuruBol = SqlSiraTuru.Split(',');
            SqlSiraTuru = null;
            foreach (string item in SqlSiraTuruBol)
            {
                if (SqlSiraTuru == null)
                    SqlSiraTuru += item + " " + SqlSiraYonu;
                else
                    SqlSiraTuru += "," + item + " " + SqlSiraYonu;
            }
            string aktifSQLSorgusu = SqlSorgusu + SqlFiltre + " ORDER BY " + SqlSiraTuru;
            SqlConnection conn = dbIslem.baglantiOlustur();
            SqlCommand cmd = new SqlCommand(aktifSQLSorgusu, conn);
            if (AramaKelime != null)
                cmd.Parameters.AddWithValue("@AraKelime", AramaKelime);
            for (int i = 0; i < tsCbC.Sutunlar.Length; i++)
            {
                if (tsCbC.Kontroller[i].Text != "Hepsi")
                    if (SqlFiltre != null)
                        if (tsCbC.Kontroller[i].SelectedItem is VeriTututucu)
                            cmd.Parameters.AddWithValue("@" + tsCbC.Sutunlar[i].ToString().Split('.').Last(), (tsCbC.Kontroller[i].SelectedItem as VeriTututucu).veriID);
                        else
                            cmd.Parameters.AddWithValue("@" + tsCbC.Sutunlar[i].Split('.').Last(), tsCbC.Kontroller[i].Text);
            }
            conn.Open();
            SqlDataReader sdr = cmd.ExecuteReader();
            lstView.Items.Clear();
            while (sdr.Read())
            {
                ListViewItem li = new ListViewItem();
                li.Text = sdr[_SqlSutunlar[0].Split('.').Last()].ToString();
                foreach (string sutun in _SqlSutunlar)
                {
                    if (_SqlSutunlar[0] != sutun)
                        li.SubItems.Add(sdr[sutun.Split('.').Last()].ToString());
                }
                li.Tag = sdr[SqlIdSutunAdi.Split('.').Last()].ToString();
                if (Tablo == "Mesajlar")
                    if (Convert.ToBoolean(sdr["OkunduMu"]))
                        li.Font = new Font("Arial", 8f, FontStyle.Regular);
                    else
                        li.Font = new Font("Arial", 8f, FontStyle.Bold);
                lstView.Items.Add(li);
            }
            conn.Close();
        }

        public void SecilileriSil()
        {
            if (lstView.SelectedItems.Count > 0)
            {
                try
                {
                    foreach (ListViewItem item in lstView.SelectedItems)
                    {

                        if (Tablo == "Ogrenciler" | Tablo == "Veliler" | Tablo == "Ogretmenler" | Tablo == "IliskisiKesilmisler")
                        {
                            dbIslem.dbVeriSil("aspnet_UsersInRoles", "UserId", item.Tag.ToString());
                            int kayTop = 0;
                            GuidConverter gc = new GuidConverter();
                            object KisiID = gc.ConvertFromString(item.Tag.ToString());
                            MembershipUser muKisi = Membership.GetUser(KisiID);
                            if (Tablo == "Ogrenciler")
                            {
                                string veliId = dbIslem.tekVeriCek(Tablo, "OgrenciID", item.Tag.ToString(), "VeliID");
                                kayTop = dbIslem.KayitToplami(Tablo, "VeliID", "VeliID", veliId);
                                if (kayTop < 2)
                                {
                                    //velinin 1'den fazla çocuğu yoksa ve çocuğu silinmişse veliyide sil
                                    dbIslem.dbVeriSil("aspnet_UsersInRoles", "UserId", veliId);
                                    dbIslem.dbVeriSil("Veliler", "VeliID", veliId);
                                    dbIslem.dbVeriSil(Tablo, SqlIdSutunAdi.Split('.').Last(), item.Tag.ToString());
                                    GuidConverter gc2 = new GuidConverter();
                                    object KisiID2 = gc.ConvertFromString(veliId);
                                    MembershipUser muKisi2 = Membership.GetUser(KisiID2);
                                    Membership.DeleteUser(muKisi2.UserName);
                                }
                                else
                                {
                                    dbIslem.dbVeriSil(Tablo, SqlIdSutunAdi.Split('.').Last(), item.Tag.ToString());
                                }
                            }
                            else if (Tablo == "IliskisiKesilmisler")
                            {
                                string veliId = dbIslem.tekVeriCek("Ogrenciler", "OgrenciID", item.Tag.ToString(), "VeliID");
                                dbIslem.dbVeriSil("aspnet_UsersInRoles", "UserId", veliId);
                                dbIslem.dbVeriSil("Veliler", "VeliID", veliId);
                                dbIslem.dbVeriSil(Tablo, SqlIdSutunAdi.Split('.').Last(), item.Tag.ToString());
                                dbIslem.dbVeriSil("Ogrenciler", SqlIdSutunAdi.Split('.').Last(), item.Tag.ToString());
                                GuidConverter gc2 = new GuidConverter();
                                object KisiID2 = gc.ConvertFromString(veliId);
                                MembershipUser muKisi2 = Membership.GetUser(KisiID2);
                                Membership.DeleteUser(muKisi2.UserName);
                            }
                            else if (Tablo == "Ogretmenler")
                            {
                                dbIslem.dbVeriSil(Tablo, SqlIdSutunAdi.Split('.').Last(), item.Tag.ToString());
                            }
                            Membership.DeleteUser(muKisi.UserName);
                        }
                        else
                        {
                            dbIslem.dbVeriSil(Tablo, SqlIdSutunAdi.Split('.').Last(), item.Tag.ToString());
                        }
                    }
                }
                catch
                {
                    MessageBox.Show("Seçili alanlardaki verilerin bazıları başka kayıtlar tarafından kullanılıyor!\nÖnce bağlı olduğu kayıtı silmeniz gerekli!");
                }
                Listele();
            }
            else
            {
                MessageBox.Show("Silebilmek için en az bir adet satır seçmelisiniz!");
            }
        }

        public bool SatirSeciliMi
        {
            get
            {
                return lstView.SelectedItems.Count > 0 ? true : false;
            }
        }

        public string SatirIndex
        {
            get
            {
                if (lstView.SelectedItems.Count > 0)
                {
                    return lstView.SelectedItems[0].Tag.ToString();
                }
                else
                {
                    return "-1";
                }
            }
        }
    }

}
