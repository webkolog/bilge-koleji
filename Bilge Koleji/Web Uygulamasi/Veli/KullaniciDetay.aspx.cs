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
    public partial class KullaniciDetay : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            divOgretmen.Style.Add("Display", "None");
            divOgrenci.Style.Add("Display", "None");
            divMuffetis.Style.Add("Display", "None");
            divVeli.Style.Add("Display", "None");
            string veriId = Request.QueryString["ID"];
            if (veriId != null)
            {
                SqlConnection conn = dbIslem.baglantiOlustur();
                if (dbIslem.aynisiVarmi("Ogrenciler", "OgrenciID", veriId))
                {
                    divOgrenci.Style.Add("Display", "");
                    SqlCommand cmd = new SqlCommand("SELECT o.OgrenciID, o.OgrenciAdi, o.OgrenciSoyadi, CASE o.Cinsiyet WHEN 0 THEN 'Erkek' ELSE 'Bayan' END AS Cinsiyet, o.BitirdigiOkul, CASE o.DevamEdiyorMu WHEN 0 THEN 'Devam Etmiyor' ELSE 'Devam Ediyor' END AS Durum, o.KayitYili, o.OkulNo, o.SinifID, s.Kademe, s.Sube FROM Ogrenciler o LEFT JOIN Siniflar s ON o.SinifID=s.SinifID WHERE o.OgrenciID=@VeriID", conn);
                    cmd.Parameters.AddWithValue("@VeriID", veriId);
                    conn.Open();
                    SqlDataReader sdr = cmd.ExecuteReader();
                    if (sdr.HasRows)
                    {
                        sdr.Read();
                        ltrOgrenciAdi.Text = sdr["OgrenciAdi"] + " " + sdr["OgrenciSoyadi"];
                        hlOgrenciSinif.Text = sdr["Kademe"] + " " + sdr["Sube"];
                        hlOgrenciSinif.NavigateUrl = "SinifDetay.aspx?ID=" + sdr["SinifID"];
                        ltrOgrenciCinsiyet.Text = sdr["Cinsiyet"].ToString();
                        ltrOgrenciDurumu.Text = sdr["Durum"].ToString();
                        ltrOgrenciKayitYili.Text = sdr["KayitYili"].ToString();
                        ltrOgrenciOkul.Text = sdr["BitirdigiOkul"].ToString();
                        ltrOgrenciOkulNo.Text = sdr["OkulNo"].ToString();
                        hlOgrenciMG.NavigateUrl = "MesajYaz.aspx?ID=" + veriId;
                    }
                    conn.Close();
                }
                else if (dbIslem.aynisiVarmi("Ogretmenler", "OgretmenID", veriId))
                {
                    divOgretmen.Style.Add("Display", "");
                    SqlCommand cmd = new SqlCommand("SELECT o.OgretmenID, o.OgretmenAdi, o.OgretmenSoyadi, CASE o.Gorev WHEN 1 THEN 'Müdür' WHEN 2 THEN 'Müdür Yardımcısı' ELSE '' END AS OgretmenGorev, ad.DersAdi, s.Kademe, s.Sube, s.SinifID FROM Ogretmenler o JOIN AnaDersler ad ON o.Brans=ad.AnaDersID LEFT JOIN Siniflar s ON s.OgretmenID=o.OgretmenID WHERE o.OgretmenID=@VeriID", conn);
                    cmd.Parameters.AddWithValue("@VeriID", veriId);
                    conn.Open();
                    SqlDataReader sdr = cmd.ExecuteReader();
                    if (sdr.HasRows)
                    {
                        sdr.Read();
                        ltrOgretmenAdi.Text = sdr["OgretmenAdi"] + " " + sdr["OgretmenSoyadi"];
                        ltrOgretmenBrans.Text = sdr["DersAdi"].ToString();
                        ltrOgretmenGorev.Text = sdr["OgretmenGorev"].ToString();
                        hlOgretmenSinif.Text = sdr["Kademe"] + " " + sdr["Sube"];
                        hlOgretmenSinif.NavigateUrl = "SinifDetay.aspx?ID=" + sdr["SinifID"];
                        hlOgretmenMG.NavigateUrl = "MesajYaz.aspx?ID=" + veriId;
                    }
                    conn.Close();
                    cmd = new SqlCommand("SELECT CASE dp.Gun WHEN 1 THEN 'Pazartesi' WHEN 2 THEN 'Salı' WHEN 3 THEN 'Çarşamba' WHEN 4 THEN 'Perşembe' WHEN 5 THEN 'Cuma' WHEN 6 THEN 'Cumartesi' ELSE 'Pazar' END AS GunAdi, dp.Saat, s.Kademe, s.Sube, s.SinifID FROM DersProgrami dp JOIN Siniflar s ON dp.SinifID=s.SinifID WHERE dp.OgretmenID=@VeriID", conn);
                    cmd.Parameters.AddWithValue("@VeriID", veriId);
                    conn.Open();
                    sdr = cmd.ExecuteReader();
                    while (sdr.Read())
                    {
                        TableRow tr = new TableRow();
                        tr.Cells.Add(new TableCell() { Text = sdr["GunAdi"].ToString() });
                        tr.Cells.Add(new TableCell() { Text = sdr["Saat"] + ". Ders" });
                        tr.Cells.Add(new TableCell() { Text = "<a href=\"SinifDetay.aspx?ID=" + sdr["SinifID"] + "\">" + sdr["Kademe"] + " " + sdr["Sube"] + "</a>" });
                        tblOgretmenDP.Rows.Add(tr);
                    }
                    conn.Close();
                }
                else if (dbIslem.aynisiVarmi("Veliler", "VeliID", veriId))
                {
                    divVeli.Style.Add("Display", "");
                    SqlCommand cmd = new SqlCommand("SELECT * FROM Veliler WHERE VeliID = @VeliID", conn);
                    cmd.Parameters.AddWithValue("@VeliID", veriId);
                    conn.Open();
                    SqlDataReader sdr = cmd.ExecuteReader();
                    if (sdr.HasRows)
                    {
                        sdr.Read();
                        ltrVeliAdi.Text = sdr["VeliAdi"] + " " + sdr["VeliSoyadi"];
                    }
                    conn.Close();
                    SqlDataAdapter sda = new SqlDataAdapter("SELECT o.OgrenciID, o.OkulNo, o.OgrenciAdi + ' ' + o.OgrenciSoyadi AS Ogrenci, CONVERT(NVARCHAR(2), s.Kademe) + ' ' + s.Sube AS Sinif, CASE o.Cinsiyet WHEN 1 THEN 'Erkek' ELSE 'Bayan' END AS Cins FROM Ogrenciler o JOIN Siniflar s ON o.SinifID=s.SinifID WHERE o.VeliID = @VeliID ORDER BY o.OgrenciAdi, o.OgrenciSoyadi", conn);
                    sda.SelectCommand.Parameters.AddWithValue("@VeliID", veriId);
                    DataTable dt = new DataTable();
                    sda.Fill(dt);
                    GridView1.DataSource = dt;
                    GridView1.DataBind();
                }
                else if (dbIslem.aynisiVarmi("Mufettisler", "MufettisID", veriId))
                {
                    divMuffetis.Style.Add("Display", "");
                    SqlCommand cmd = new SqlCommand("SELECT * FROM Mufettisler WHERE MufettisID = @MufettisID", conn);
                    cmd.Parameters.AddWithValue("@MufettisID", veriId);
                    conn.Open();
                    SqlDataReader sdr = cmd.ExecuteReader();
                    if (sdr.HasRows)
                    {
                        sdr.Read();
                        ltrMufettisAdi.Text = sdr["MufettisAdi"] + " " + sdr["MufettisSoyadi"];
                    }
                    conn.Close();
                }
            }
        }
    }
}