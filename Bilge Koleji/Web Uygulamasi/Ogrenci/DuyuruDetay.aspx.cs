using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Text.RegularExpressions;

namespace Web_Uygulamasi.Ogrenci
{
    public partial class DuyuruDetay : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string gelenVeri = Request.QueryString["ID"];
            if (!Regex.IsMatch(gelenVeri, "[0-9]"))
            {
                ltrMesaj.Text = "Kayıt Yok!";
            }
            else
            {
                SqlConnection conn = dbIslem.baglantiOlustur();
                SqlCommand cmd = new SqlCommand("SELECT d.DuyuruID, d.Baslik, d.Mesaj, d.Tarih, d.KitleTuru, o.OgretmenAdi + ' ' + o.OgretmenSoyadi AS Ogretmen, d.YazanID, CASE o.Gorev WHEN 1 THEN 'Müdür' WHEN 2 THEN 'Müdür Yardımcısı' ELSE 'Öğretmen' END AS Statu FROM Duyuru d JOIN Ogretmenler o ON d.YazanID=o.OgretmenID WHERE d.DuyuruID = @DuyuruID", conn);
                cmd.Parameters.AddWithValue("@DuyuruID", gelenVeri);
                conn.Open();
                SqlDataReader sdr = cmd.ExecuteReader();
                if (sdr.HasRows)
                {
                    sdr.Read();
                    ltrBaslik.Text = sdr["Baslik"].ToString();
                    ltrMesaj.Text = sdr["Mesaj"].ToString().Replace("\r\n", "<br />");
                    ltrTarih.Text = ((DateTime)sdr["Tarih"]).ToString("dd MMMM yyyy");
                    hlYazan.NavigateUrl = "KullaniciDetay.aspx?ID=" + sdr["YazanID"];
                    hlYazan.Text = sdr["Ogretmen"] + " (" + sdr["Statu"] + ")";
                }
                conn.Close();
            }
        }
    }
}