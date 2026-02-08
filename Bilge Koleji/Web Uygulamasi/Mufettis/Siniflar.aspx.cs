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
    public partial class Siniflar : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            SqlConnection conn = dbIslem.baglantiOlustur();
            SqlDataAdapter sda = new SqlDataAdapter("SELECT s.SinifID, o.OgretmenID, CONVERT(NVARCHAR(2),s.Kademe) + ' ' + s.Sube AS Sinif, o.OgretmenAdi + ' ' + o.OgretmenSoyadi AS Ogretmen, * FROM Siniflar s JOIN Derslikler d ON s.DerslikID=d.DerslikID JOIN Ogretmenler o ON o.OgretmenID=s.OgretmenID ORDER BY s.Kademe, s.Sube", conn);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            GridView1.DataSource = dt;
            GridView1.DataBind();
        }
    }
}