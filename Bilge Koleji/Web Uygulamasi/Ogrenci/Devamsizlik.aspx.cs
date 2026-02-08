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
    public partial class Devamsizlik : System.Web.UI.Page
    {
        SqlConnection conn = dbIslem.baglantiOlustur();
        protected void Page_Load(object sender, EventArgs e)
        {
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
                string SqlSorgusu = "SELECT od.Tarih, CASE TamGunMu WHEN 1 THEN 'Tam Gün' ELSE 'Yarım Gün' END AS Gun, CASE od.OzelNeden WHEN 1 THEN 'Raporlu' WHEN 2 THEN 'İzinli' ELSE '' END AS Sebep FROM OgrenciDevamsizlik od JOIN Ogrenciler o ON o.OgrenciID=od.OgrenciID WHERE o.OgrenciID=@OgrenciID AND od.SezonID=@SezonID ORDER BY od.Tarih DESC";
                SqlDataAdapter sda = new SqlDataAdapter(SqlSorgusu, conn);
                sda.SelectCommand.Parameters.AddWithValue("@OgrenciID", OgrenciID);
                sda.SelectCommand.Parameters.AddWithValue("@SezonID", SezonID);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                GridView1.DataSource = dt;
                GridView1.DataBind();
                cmd = new SqlCommand(SqlSorgusu, conn);
                cmd.Parameters.AddWithValue("@OgrenciID", OgrenciID);
                cmd.Parameters.AddWithValue("@SezonID", SezonID);
                conn.Open();
                sdr = cmd.ExecuteReader();
                float Ozurlu = 0, Ozursuz=0;

                while (sdr.Read())
                {
                    if (sdr["Sebep"].ToString() == "")
                        Ozursuz += sdr["Gun"].ToString() == "Tam Gün" ? 1 : 0.5f;
                    else
                        Ozurlu += sdr["Gun"].ToString() == "Tam Gün" ? 1 : 0.5f;
                }
                conn.Close();
                ltrTopDevasizlik.Text = "Özürsüz " + Ozursuz.ToString()  + " gün, Özürlü " + Ozurlu.ToString() + " gün";
            }
        }
    }
}