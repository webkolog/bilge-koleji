using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Web.Security;

namespace Web_Uygulamasi.Ogretmen
{
    public partial class NotlarSiniflar : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string VeriID = Membership.GetUser(HttpContext.Current.User.Identity.Name).ProviderUserKey.ToString();
            SqlConnection conn = dbIslem.baglantiOlustur();
            SqlCommand cmd;
            SqlDataReader sdr;
            cmd = new SqlCommand("SELECT DISTINCT s.SinifID, s.Kademe, s.Sube, s.DerslikID, d.DerslikAdi, d.Kat FROM Siniflar s JOIN Derslikler d ON s.DerslikID=d.DerslikID JOIN DersProgrami dp ON s.SinifID=dp.SinifID WHERE dp.OgretmenID=@VeriID ORDER BY s.Kademe, s.Sube", conn);
            cmd.Parameters.AddWithValue("@VeriID", VeriID);
            conn.Open();
            sdr = cmd.ExecuteReader();
            while (sdr.Read())
            {
                TableRow tr = new TableRow();
                tr.Cells.Add(new TableCell() { Text = sdr["Kademe"].ToString(), Width = Unit.Percentage(10) });
                tr.Cells.Add(new TableCell() { Text = sdr["Sube"].ToString(), Width = Unit.Percentage(10) });
                tr.Cells.Add(new TableCell() { Text = "<a href=\"NotlarSinifDetay.aspx?ID=" + sdr["SinifID"] + "&Donem=1\">1.Dönem</a> | <a href=\"NotlarSinifDetay.aspx?ID=" + sdr["SinifID"] + "&Donem=2\">2.Dönem</a>" });
                tr.Cells.Add(new TableCell() { Text = sdr["DerslikAdi"].ToString() });
                tr.Cells.Add(new TableCell() { Text = sdr["Kat"] + ". kat" });
                tblDersSinif.Rows.Add(tr);
            }
            conn.Close();
        }
    }
}