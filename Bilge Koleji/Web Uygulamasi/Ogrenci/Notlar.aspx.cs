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
    public partial class Notlar : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            SqlConnection conn = dbIslem.baglantiOlustur();
            string SezonID = null;
            SqlCommand cmd = new SqlCommand("SELECT * FROM Sezonlar ORDER BY SezonID DESC", conn);
            conn.Open();
            SqlDataReader sdr = cmd.ExecuteReader();
            if (sdr.HasRows)
            {
                sdr.Read();
                SezonID = sdr["SezonID"].ToString();
            }
            conn.Close();
            if (SezonID != null)
            {
                string OgrenciID = Membership.GetUser(HttpContext.Current.User.Identity.Name).ProviderUserKey.ToString();
                SqlDataAdapter sda = new SqlDataAdapter("SELECT DISTINCT n.AltDersID, anaD.DersAdi, Donem1SozluNotu1 AS s1, Donem1SozluNotu2 AS s2, Donem1SozluNotu3 AS s3, Donem1SozluNotu4 AS s4, Donem1SinavNotu1 AS y1, Donem1SinavNotu2 AS y2, Donem1SinavNotu3 AS y3, Donem1SinavNotu4 AS y4, Donem1OdevNotu AS Odev FROM AnaDersler anaD JOIN DersProgrami dp ON dp.AnaDersID=anaD.AnaDersID JOIN Siniflar s ON s.SinifID=dp.SinifID JOIN Ogrenciler o ON o.SinifID=s.SinifID JOIN AltDersler altD ON anaD.AnaDersID=altD.AnaDersID JOIN Notlar n ON altD.AltDersID=n.AltDersID AND n.SezonID=@SezonID AND n.OgrenciID=@OgrenciID ORDER BY anaD.DersAdi", conn);
                sda.SelectCommand.Parameters.AddWithValue("@OgrenciID", OgrenciID);
                sda.SelectCommand.Parameters.AddWithValue("@SezonID", SezonID);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                GridView1.DataSource = dt;
                GridView1.DataBind();
                sda = new SqlDataAdapter("SELECT DISTINCT n.AltDersID, anaD.DersAdi, Donem2SozluNotu1 AS s1, Donem2SozluNotu2 AS s2, Donem2SozluNotu3 AS s3, Donem2SozluNotu4 AS s4, Donem2SinavNotu1 AS y1, Donem2SinavNotu2 AS y2, Donem2SinavNotu3 AS y3, Donem2SinavNotu4 AS y4, Donem2OdevNotu AS Odev FROM AnaDersler anaD JOIN DersProgrami dp ON dp.AnaDersID=anaD.AnaDersID JOIN Siniflar s ON s.SinifID=dp.SinifID JOIN Ogrenciler o ON o.SinifID=s.SinifID JOIN AltDersler altD ON anaD.AnaDersID=altD.AnaDersID JOIN Notlar n ON altD.AltDersID=n.AltDersID AND n.SezonID=@SezonID AND n.OgrenciID=@OgrenciID ORDER BY anaD.DersAdi", conn);
                sda.SelectCommand.Parameters.AddWithValue("@OgrenciID", OgrenciID);
                sda.SelectCommand.Parameters.AddWithValue("@SezonID", SezonID);
                dt = new DataTable();
                sda.Fill(dt);
                GridView2.DataSource = dt;
                GridView2.DataBind();
            }
        }
    }
}