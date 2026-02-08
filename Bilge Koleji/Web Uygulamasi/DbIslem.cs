using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Configuration;

namespace Web_Uygulamasi
{
    public class dbIslem
    {
        public static SqlConnection baglantiOlustur()
        {
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["LocalSqlServer"].ConnectionString);
            return conn;
        }

        public static string dbEkleVeriIslem(string tablo, string sidSutunAdi, string sonID, params string[] parametreler)
        {
            SqlConnection conn = dbIslem.baglantiOlustur();
            string sorgu = null, sutunlar = null, degerler = null, kosullar = null;
            int j = parametreler.Count() / 2;
            for (int i = 0; i < j; i++)
            {
                sutunlar += parametreler[i] + ",";
                degerler += "@" + parametreler[i] + ",";
            }
            for (int i = 0; i < j; i++)
                kosullar += parametreler[i] + " = @" + parametreler[i] + " AND ";
            if (sonID != null)
            {
                sutunlar += sidSutunAdi + ",";
                degerler += "@" + sidSutunAdi + ",";
                kosullar += sidSutunAdi + " = @" + sidSutunAdi + " AND ";
            }
            sorgu = "SELECT * FROM " + tablo + " WHERE " + kosullar.Substring(0, kosullar.Length - 4);
            SqlCommand cmdKontrol = new SqlCommand(sorgu, conn);
            for (int i = 0; i < j; i++)
                cmdKontrol.Parameters.AddWithValue("@" + parametreler[i], parametreler[i + j]);
            if (sonID != null)
                cmdKontrol.Parameters.AddWithValue("@" + sidSutunAdi, sonID);
            conn.Open();
            bool KayitVarMi = false;
            try
            {
                SqlDataReader sdr = cmdKontrol.ExecuteReader();
                KayitVarMi = sdr.HasRows;
                sdr.Read();
                sonID = sdr[0].ToString();
            }
            catch
            {
                KayitVarMi = false;
            }
            if (!KayitVarMi)
            {
                conn.Close();
                //bu kayıt daha önce eklenmemişse
                sorgu = "INSERT INTO " + tablo + " (" + sutunlar.Substring(0, sutunlar.Length
                                            - 1) + ") VALUES (" + degerler.Substring(0, degerler.Length
                                            - 1) + ")";
                SqlCommand cmdEkle = new SqlCommand(sorgu + "; SELECT @@IDENTITY;", conn);
                for (int i = 0; i < j; i++)
                    cmdEkle.Parameters.AddWithValue("@" + parametreler[i], parametreler[i + j]);
                if (sonID != null)
                    cmdEkle.Parameters.AddWithValue("@" + sidSutunAdi, sonID);
                conn.Open();
                sonID = cmdEkle.ExecuteScalar().ToString();
            }
            conn.Close();
            return sonID;
        }

        public static int dbHizliGuncelle(string tablo, string filtreSutun, string filtreDeger, params string[] parametreler)
        {
            SqlConnection conn = dbIslem.baglantiOlustur();
            string sorgu = null, kosul = null, guncellenecekler = null;
            int j = parametreler.Count() / 2, etki = 0;
            for (int i = 0; i < j; i++)
                guncellenecekler += parametreler[i] + " = @" + parametreler[i] + ",";
            if (filtreDeger != null)
                kosul += filtreSutun + " = @" + filtreSutun;
            if (filtreDeger != null)
                kosul = " WHERE " + kosul;
            sorgu = "UPDATE " + tablo + " SET " + guncellenecekler.Substring(0, guncellenecekler.Length - 1) + kosul;
            SqlCommand cmd = new SqlCommand(sorgu, conn);
            for (int i = 0; i < j; i++)
                cmd.Parameters.AddWithValue("@" + parametreler[i], parametreler[i + j]);
            if (filtreDeger != null)
                cmd.Parameters.AddWithValue("@" + filtreSutun, filtreDeger);
            conn.Open();
            etki = cmd.ExecuteNonQuery();
            conn.Close();
            return etki;
        }

        public static int dbVeriSil(string tablo, params string[] parametreler)
        {
            SqlConnection conn = dbIslem.baglantiOlustur();
            string sorgu = null, kosullar = null;
            int j = parametreler.Count() / 2, etki = 0;
            for (int i = 0; i < j; i++)
                kosullar += parametreler[i] + " = @" + parametreler[i] + " AND ";
            sorgu = "DELETE FROM " + tablo + " WHERE " + kosullar.Substring(0, kosullar.Length - 4);
            SqlCommand cmd = new SqlCommand(sorgu, conn);
            for (int i = 0; i < j; i++)
                cmd.Parameters.AddWithValue("@" + parametreler[i], parametreler[i + j]);
            conn.Open();
            etki = cmd.ExecuteNonQuery();
            conn.Close();
            return etki;
        }

        public static bool aynisiVarmi(string tablo, params string[] parametreler)
        {
            SqlConnection conn = dbIslem.baglantiOlustur();
            string sorgu = null, kosullar = null;
            int j = parametreler.Count() / 2;
            for (int i = 0; i < j; i++)
            {
                if (parametreler[i].Remove(1) == "!")
                    kosullar += parametreler[i].Substring(1, parametreler[i].Length - 1) + " != @" + parametreler[i].Substring(1, parametreler[i].Length - 1) + " AND ";
                else
                    kosullar += parametreler[i] + " = @" + parametreler[i] + " AND ";
            }
            sorgu = "SELECT * FROM " + tablo;
            sorgu += parametreler.Count() < 2 ? null : " WHERE " + kosullar.Substring(0, kosullar.Length - 4);
            SqlCommand cmd = new SqlCommand(sorgu, conn);
            if (parametreler.Count() >= 2)
            {
                for (int i = 0; i < j; i++)
                    if (parametreler[i].Remove(1) == "!")
                        cmd.Parameters.AddWithValue("@" + parametreler[i].Substring(1, parametreler[i].Length - 1), parametreler[i + j]);
                    else
                        cmd.Parameters.AddWithValue("@" + parametreler[i], parametreler[i + j]);
            }
            conn.Open();
            bool kayitVarMi = cmd.ExecuteReader().HasRows;
            conn.Close();
            return kayitVarMi;
        }

        public static string tekVeriCek(string tablo, string kosulSutun, string kosulDeger, string donecekDeger)
        {
            SqlConnection conn = baglantiOlustur();
            string sorgu = "SELECT * FROM " + tablo + " WHERE " + kosulSutun + " = @" + kosulSutun;
            SqlCommand cmd = new SqlCommand(sorgu, conn);
            cmd.Parameters.AddWithValue("@" + kosulSutun, kosulDeger);
            conn.Open();
            SqlDataReader sdr = cmd.ExecuteReader();
            if (sdr.HasRows)
            {
                sdr.Read();
                donecekDeger = sdr[donecekDeger].ToString();
            }
            else
            {
                donecekDeger = null;
            }
            conn.Close();
            return donecekDeger;
        }

        public static int KayitToplami(string tablo, string hesaplanacakSutun, params string[] parametreler)
        {
            SqlConnection conn = dbIslem.baglantiOlustur();
            string sorgu = null, kosullar = null;
            int j = parametreler.Count() / 2, etki = 0;
            for (int i = 0; i < j; i++)
                kosullar += parametreler[i] + " = @" + parametreler[i] + " AND ";
            sorgu = "SELECT COUNT(" + hesaplanacakSutun + ") FROM " + tablo + " WHERE " + kosullar.Substring(0, kosullar.Length - 4) + " GROUP BY " + hesaplanacakSutun;
            SqlCommand cmd = new SqlCommand(sorgu, conn);
            for (int i = 0; i < j; i++)
                cmd.Parameters.AddWithValue("@" + parametreler[i], parametreler[i + j]);
            conn.Open();

            SqlDataReader sdr = cmd.ExecuteReader();
            int ToplamKayit;
            if (sdr.HasRows)
            {
                sdr.Read();
                ToplamKayit = Convert.ToInt32(sdr[0]);
            }
            else
            {
                ToplamKayit = 0;
            }
            conn.Close();
            return ToplamKayit;
        }
    }
}