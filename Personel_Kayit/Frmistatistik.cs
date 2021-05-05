using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Personel_Kayit
{
    public partial class Frmistatistik : Form
    {
        SqlConnection baglanti = new SqlConnection("Data Source=DESKTOP-UO7SCE6;Initial Catalog=PersonelVeriTabani;Integrated Security=True");
        public Frmistatistik()
        {
            InitializeComponent();
        }

        private void Frmistatistik_Load(object sender, EventArgs e)
        {
            
            //Toplam Personel Sayısı
            baglanti.Open();
            SqlCommand komut1 = new SqlCommand("Select Count(*) From Tbl_Personel",baglanti);
            SqlDataReader dr1 = komut1.ExecuteReader();
            while(dr1.Read())
            {
                Lbltplmprsnl.Text = dr1[0].ToString();
            }

            baglanti.Close();

            //Evli Personel Sayısı
            baglanti.Open();
            SqlCommand komut2 = new SqlCommand("select count (*) From Tbl_Personel where PerDurum=1",baglanti);
            SqlDataReader dr2 = komut2.ExecuteReader();
            while(dr2.Read())
            {

                LblEvliprsnl.Text = dr2[0].ToString();
            }
            baglanti.Close();

            //Bekar Personel Sayısı

            baglanti.Open();
            SqlCommand komut3 = new SqlCommand("select count (*) From Tbl_Personel where PerDurum=0",baglanti);
            SqlDataReader dr3 = komut3.ExecuteReader();
            while (dr3.Read())
            {
                LblBekarprsnl.Text = dr3[0].ToString();
            }
            baglanti.Close();
            //Şehir Sayisi (Farklı)
            baglanti.Open();
            SqlCommand komut4 = new SqlCommand("Select count(distinct(PerSehir))from Tbl_Personel",baglanti);
            SqlDataReader dr4 = komut4.ExecuteReader();
            while (dr4.Read())
            {
                LblSehir.Text = dr4[0].ToString();
            }

            baglanti.Close();

            //Toplam Maaş 
            baglanti.Open();

            SqlCommand komut5 = new SqlCommand("Select sum(permaas) From Tbl_Personel", baglanti);
            SqlDataReader dr5 = komut5.ExecuteReader();
            while (dr5.Read())
            {
                LblTplmaas.Text = dr5[0].ToString();
            }

            baglanti.Close();

            //Ortalama Maaş
            baglanti.Open();
            SqlCommand komut6 = new SqlCommand("Select avg(PerMaas) From Tbl_Personel",baglanti);
            SqlDataReader dr6 = komut6.ExecuteReader();
            while (dr6.Read())
            {
                LblOrtMaas.Text = dr6[0].ToString();
            }

      



        }
    }
}
