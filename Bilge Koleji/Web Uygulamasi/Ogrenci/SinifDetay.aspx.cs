using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;

namespace Web_Uygulamasi.Ogrenci
{
    public partial class SinifDetay : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string sinifID = Request.QueryString["ID"];
            if (sinifID != null)
            {
                SqlConnection conn = dbIslem.baglantiOlustur();
                SqlCommand cmd = new SqlCommand("SELECT o.OgretmenID, * FROM Siniflar s JOIN Derslikler d ON s.DerslikID=d.DerslikID JOIN Ogretmenler o ON s.OgretmenID=o.OgretmenID WHERE s.SinifID = @SinifID", conn);
                cmd.Parameters.AddWithValue("SinifID", sinifID);
                conn.Open();
                SqlDataReader sdr = cmd.ExecuteReader();
                if (sdr.HasRows)
                {
                    sdr.Read();
                    lblDers.Text = "Derslik: " + sdr["DerslikAdi"] + ", Kat: " + sdr["Kat"];
                    ltrSinifAdi.Text = sdr["Kademe"] + "" + sdr["Sube"];
                    hlRehberOgretmen.Text = sdr["OgretmenAdi"] + " " + sdr["OgretmenSoyadi"];
                    hlRehberOgretmen.NavigateUrl = "KullaniciDetay.aspx?ID=" + sdr["OgretmenID"];
                }
                conn.Close();
                SqlDataAdapter sda = new SqlDataAdapter("SELECT OgrenciAdi + ' ' + OgrenciSoyadi AS Ogrenci, CASE Cinsiyet WHEN 1 THEN 'Bayan' ELSE 'Erkek' END AS Cins, * FROM Ogrenciler WHERE SinifID=@SinifID ORDER BY OgrenciAdi, OgrenciSoyadi", conn);
                sda.SelectCommand.Parameters.AddWithValue("@SinifID", sinifID);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                GridView1.DataSource = dt;
                GridView1.DataBind();
                sda = new SqlDataAdapter("SELECT DISTINCT dp.Saat, ad1.DersAdi AS g1Ders, ad2.DersAdi AS g2Ders, ad3.DersAdi AS g3Ders, ad4.DersAdi AS g4Ders, ad5.DersAdi AS g5Ders, o1.OgretmenAdi + ' ' + o1.OgretmenSoyadi AS g1Ogretmen, o2.OgretmenAdi + ' ' + o2.OgretmenSoyadi AS g2Ogretmen, o3.OgretmenAdi + ' ' + o3.OgretmenSoyadi AS g3Ogretmen, o4.OgretmenAdi + ' ' + o4.OgretmenSoyadi AS g4Ogretmen, o5.OgretmenAdi + ' ' + o5.OgretmenSoyadi AS g5Ogretmen FROM DersProgrami dp LEFT JOIN DersProgrami dp1 ON dp1.Gun='1' AND dp1.SinifID=dp.SinifID AND dp1.Saat=dp.Saat LEFT JOIN DersProgrami dp2 ON dp2.Gun='2' AND dp2.SinifID=dp.SinifID AND dp2.Saat=dp.Saat LEFT JOIN DersProgrami dp3 ON dp3.Gun='3' AND dp3.SinifID=dp.SinifID AND dp3.Saat=dp.Saat LEFT JOIN DersProgrami dp4 ON dp4.Gun='4' AND dp4.SinifID=dp.SinifID AND dp4.Saat=dp.Saat LEFT JOIN DersProgrami dp5 ON dp5.Gun='5' AND dp5.SinifID=dp.SinifID AND dp5.Saat=dp.Saat LEFT JOIN AnaDersler ad1 ON ad1.AnaDersID=dp1.AnaDersID LEFT JOIN AnaDersler ad2 ON ad2.AnaDersID=dp2.AnaDersID LEFT JOIN AnaDersler ad3 ON ad3.AnaDersID=dp3.AnaDersID LEFT JOIN AnaDersler ad4 ON ad4.AnaDersID=dp4.AnaDersID LEFT JOIN AnaDersler ad5 ON ad5.AnaDersID=dp5.AnaDersID LEFT JOIN Ogretmenler o1 ON o1.OgretmenID=dp1.OgretmenID LEFT JOIN Ogretmenler o2 ON o2.OgretmenID=dp2.OgretmenID LEFT JOIN Ogretmenler o3 ON o3.OgretmenID=dp3.OgretmenID LEFT JOIN Ogretmenler o4 ON o4.OgretmenID=dp4.OgretmenID LEFT JOIN Ogretmenler o5 ON o5.OgretmenID=dp5.OgretmenID WHERE dp.SinifID=@SinifID ORDER BY dp.Saat", conn);
                sda.SelectCommand.Parameters.AddWithValue("@SinifID", sinifID);
                dt = new DataTable();
                sda.Fill(dt);
                Repeater1.DataSource = dt;
                Repeater1.DataBind();
            }
        }
    }
}