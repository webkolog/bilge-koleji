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
    public partial class OgrenciDetay : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            SqlConnection conn = dbIslem.baglantiOlustur();
            string OgrenciID = null;
            OgrenciID = Request.QueryString["ID"];
            if (OgrenciID != null)
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
                    string SqlSorgusu = "SELECT od.Tarih, CASE TamGunMu WHEN 1 THEN 'Tam Gün' ELSE 'Yarım Gün' END AS Gun, CASE od.OzelNeden WHEN 1 THEN 'Raporlu' WHEN 2 THEN 'İzinli' ELSE '' END AS Sebep FROM OgrenciDevamsizlik od JOIN Ogrenciler o ON o.OgrenciID=od.OgrenciID WHERE o.OgrenciID=@OgrenciID AND od.SezonID=@SezonID ORDER BY od.Tarih DESC";
                    sda = new SqlDataAdapter(SqlSorgusu, conn);
                    sda.SelectCommand.Parameters.AddWithValue("@OgrenciID", OgrenciID);
                    sda.SelectCommand.Parameters.AddWithValue("@SezonID", SezonID);
                    dt = new DataTable();
                    sda.Fill(dt);
                    GridView3.DataSource = dt;
                    GridView3.DataBind();
                    cmd = new SqlCommand(SqlSorgusu, conn);
                    cmd.Parameters.AddWithValue("@OgrenciID", OgrenciID);
                    cmd.Parameters.AddWithValue("@SezonID", SezonID);
                    conn.Open();
                    sdr = cmd.ExecuteReader();
                    float Ozurlu = 0, Ozursuz = 0;
                    while (sdr.Read())
                    {
                        if (sdr["Sebep"].ToString() == "")
                            Ozursuz += sdr["Gun"].ToString() == "Tam Gün" ? 1 : 0.5f;
                        else
                            Ozurlu += sdr["Gun"].ToString() == "Tam Gün" ? 1 : 0.5f;
                    }
                    conn.Close();
                    ltrTopDevasizlik.Text = "Özürsüz " + Ozursuz.ToString() + " gün, Özürlü " + Ozurlu.ToString() + " gün";
                    cmd = new SqlCommand("SELECT * FROM Ogrenciler WHERE OgrenciID = @OgrenciID", conn);
                    cmd.Parameters.AddWithValue("@OgrenciID", OgrenciID);
                    conn.Open();
                    sdr = cmd.ExecuteReader();
                    if (sdr.HasRows)
                    {
                        sdr.Read();
                        Baslik.InnerText = sdr["OgrenciAdi"] + " " + sdr["OgrenciSoyadi"];
                    }
                    conn.Close();
                }
            }
        }
    }
}