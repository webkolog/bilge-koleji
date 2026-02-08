using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;

namespace Web_Uygulamasi.Veli
{
    public partial class Ogretmenler : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            SqlConnection conn = dbIslem.baglantiOlustur();
            SqlDataAdapter sda = new SqlDataAdapter("SELECT OgretmenID, OgretmenAdi + ' ' + OgretmenSoyadi AS Ogretmen, CASE Gorev WHEN 1 THEN 'Müdür' WHEN 2 THEN 'Müdür Yardımcısı' ELSE 'Öğretmen' END AS Gorevi, * FROM Ogretmenler o JOIN AnaDersler d ON o.Brans=d.AnaDersID ORDER BY OgretmenAdi, OgretmenSoyadi", conn);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            GridView1.DataSource = dt;
            GridView1.DataBind();
        }
    }
}