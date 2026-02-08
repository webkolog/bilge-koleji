using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Web.Security;

namespace Windows_Uygulamasi
{
    public partial class frmAltSifreDegistir : Form
    {
        string UyeID;
        public frmAltSifreDegistir(string _uyeID)
        {
            InitializeComponent();
            UyeID = _uyeID;
        }

        private void frmAltSifreDegistir_Load(object sender, EventArgs e)
        {
            
        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            HataTutucu ht = new HataTutucu();
            if (txtSifre.Text.Length < 6)
                ht.hataEkle("Şifreniz 6 karakterden az olamaz");
            if (txtSifre.Text != txtReSifre.Text)
                ht.hataEkle("Şifre ve şifre tekrarı birbirleriyle aynı değil");
            if (ht.HataVarMi)
            {
                ht.HatalariGoster();
            }
            else
            {
                GuidConverter gc = new GuidConverter();
                object oUyeID = gc.ConvertFromString(UyeID);
                MembershipUser mUye = Membership.GetUser(oUyeID);
                string rstSifre = mUye.ResetPassword();
                if (mUye.ChangePassword(rstSifre, txtSifre.Text))
                    this.Close();
                else
                    MessageBox.Show("Bir hata oluştu!");
            }
        }
    }
}
