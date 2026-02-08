using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text.RegularExpressions;
using System.Collections;

namespace Web_Uygulamasi
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
            string Kurallar = @"^\([0-9]{3,3}\) [0-9]{3,3}-[0-9]{4,4}$";
            return Regex.IsMatch(telno, Kurallar);
        }

        public bool TcKimlikKontrol(string tcKimlik)
        {
            string Kurallar = @"^[0-9]{11,11}$";
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

        public string HatalariGonder
        {
            get
            {
                return _Hatalar;
            }
            set
            {

            }
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

}