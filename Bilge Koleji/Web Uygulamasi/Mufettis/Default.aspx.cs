using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;

namespace Web_Uygulamasi.Mufettis
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            SqlConnection conn = dbIslem.baglantiOlustur();
            SqlDataAdapter sda = new SqlDataAdapter("SELECT d.DuyuruID, d.Baslik, d.Mesaj, d.Tarih, d.KitleTuru, o.OgretmenAdi + ' ' + o.OgretmenSoyadi AS Ogretmen, d.YazanID, CASE o.Gorev WHEN 1 THEN 'Müdür' WHEN 2 THEN 'Müdür Yardımcısı' ELSE 'Öğretmen' END AS Statu FROM Duyuru d JOIN Ogretmenler o ON d.YazanID=o.OgretmenID WHERE d.KitleTuru='0' ORDER BY Tarih DESC", conn);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            ListView1.DataSource = dt;
            ListView1.DataBind();
        }
    }
}