using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;
using System.Data.SqlClient;
using System.Data;

namespace Web_Uygulamasi.Veli
{
    public partial class Ogrenciler : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string VeliId = Membership.GetUser(HttpContext.Current.User.Identity.Name).ProviderUserKey.ToString();
            SqlConnection conn = dbIslem.baglantiOlustur();
            SqlDataAdapter sda = new SqlDataAdapter("SELECT o.OgrenciID, o.OgrenciAdi + ' ' + O.OgrenciSoyadi AS Ogrenci, CONVERT(NVARCHAR(2),s.Kademe) + ' ' + s.Sube AS Sinif, CASE o.DevamEdiyorMu WHEN 1 THEN 'Devam Ediyor' ELSE 'Devam Etmiyor' END AS Durum, d.DerslikAdi, d.Kat FROM Ogrenciler o JOIN Siniflar s ON o.SinifID=s.SinifID JOIN Derslikler d ON d.DerslikID=s.DerslikID WHERE o.VeliID=@VeliID ORDER BY o.OgrenciAdi, o.OgrenciSoyadi", conn);
            sda.SelectCommand.Parameters.AddWithValue("@VeliID", VeliId);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            GridView1.DataSource = dt;
            GridView1.DataBind();
        }
    }
}