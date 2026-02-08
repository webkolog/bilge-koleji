using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Web.Security;

namespace Web_Uygulamasi.Ogrenci
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            SqlConnection conn = dbIslem.baglantiOlustur();
            SqlDataAdapter sda = new SqlDataAdapter("SELECT d.DuyuruID, d.Baslik, d.Mesaj, d.Tarih, d.KitleTuru, o.OgretmenAdi + ' ' + o.OgretmenSoyadi AS Ogretmen, d.YazanID, CASE o.Gorev WHEN 1 THEN 'Müdür' WHEN 2 THEN 'Müdür Yardımcısı' ELSE 'Öğretmen' END AS Statu FROM Duyuru d JOIN Ogretmenler o ON d.YazanID=o.OgretmenID LEFT JOIN Siniflar s  ON s.OgretmenID=o.OgretmenID LEFT JOIN Ogrenciler ogrn ON ogrn.SinifID=s.SinifID WHERE d.KitleTuru='0' OR ogrn.OgrenciID=@OgrenciID ORDER BY Tarih DESC", conn);
            sda.SelectCommand.Parameters.AddWithValue("@OgrenciID", Membership.GetUser(HttpContext.Current.User.Identity.Name).ProviderUserKey.ToString());
            DataTable dt = new DataTable();
            sda.Fill(dt);
            ListView1.DataSource = dt;
            ListView1.DataBind();
        }
    }
}