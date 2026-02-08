using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Security.Cryptography;
using System.Data.SqlClient;

namespace Windows_Uygulamasi
{
    public partial class frmGiris : Form
    {
        private string uyeID;
        public frmGiris()
        {
            InitializeComponent();
        }

        private void btnGirisYap_Click(object sender, EventArgs e)
        {
            if (dbIslem.aynisiVarmi("aspnet_Membership", "Email", txtMail.Text))
            {
                SqlConnection conn = dbIslem.baglantiOlustur();
                SqlCommand cmd = new SqlCommand("SELECT * FROM aspnet_Membership WHERE Email=@Email", conn);
                cmd.Parameters.AddWithValue("@Email", txtMail.Text);
                conn.Open();
                SqlDataReader sdr = cmd.ExecuteReader();
                sdr.Read();
                if (sdr["Password"].ToString() == GenerateHash(txtSifre.Text, sdr["PasswordSalt"].ToString()))
                {
                    //görev kontrol
                    if (dbIslem.aynisiVarmi("Ogretmenler", "OgretmenID", "Gorev", sdr["UserID"].ToString(), "1") | dbIslem.aynisiVarmi("Ogretmenler", "OgretmenID", "Gorev", sdr["UserID"].ToString(), "2"))
                    {
                        if (cBoxBeniHatirla.Checked)
                        {
                            Ayarlar.Default.BeniHatirla = true;
                            Ayarlar.Default.Email = txtMail.Text;
                            Ayarlar.Default.Sifre = txtSifre.Text;
                            Ayarlar.Default.Save();
                        }
                        else
                        {
                            Ayarlar.Default.BeniHatirla = false;
                            Ayarlar.Default.Email = "";
                            Ayarlar.Default.Sifre = "";
                        }
                        Ayarlar.Default.Save();
                        uyeID = sdr["UserID"].ToString();
                        System.Threading.Thread Thr = new System.Threading.Thread(new System.Threading.ThreadStart(programiAc));
                        Thr.Start();
                        conn.Close();
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Sadece Müdür veya Müdür Yardımcısı Giriş Yapabilir!");
                    }
                }
                else
                {
                    MessageBox.Show("Şifremiz Yanlış!");
                }
                conn.Close();
            }
            else
            {
                MessageBox.Show("Yazdığınız Email Adresi Hiç Bir Kullanıcıya Ait Değil!");
            }
        }

        private void frmGiris_Load(object sender, EventArgs e)
        {
            if (Ayarlar.Default.BeniHatirla)
            {
                txtMail.Text = Ayarlar.Default.Email;
                txtSifre.Text = Ayarlar.Default.Sifre;
                cBoxBeniHatirla.Checked = Ayarlar.Default.BeniHatirla;
            }
        }

        //şifreleri hash yapmak için metodlar stackoverflow.com sitesinden aldım
        public static string GenerateHash(string pwd, string saltAsBase64)
        {
            byte[] p1 = Convert.FromBase64String(saltAsBase64);
            return GenerateHash(pwd, p1);
        }

        public static string GenerateHash(string pwd, byte[] saltAsByteArray)
        {
            System.Security.Cryptography.SHA1 sha = new System.Security.Cryptography.SHA1CryptoServiceProvider();
            byte[] p1 = saltAsByteArray;
            byte[] p2 = System.Text.Encoding.Unicode.GetBytes(pwd);
            byte[] data = new byte[p1.Length + p2.Length];
            p1.CopyTo(data, 0);
            p2.CopyTo(data, p1.Length);
            byte[] result = sha.ComputeHash(data);
            string res = Convert.ToBase64String(result);
            return res;
        }

        public void programiAc()
        {
            frm_AnaForm frm = new frm_AnaForm();
            frm.uyeID = uyeID;
            Application.Run(frm);
        }
    }
}
