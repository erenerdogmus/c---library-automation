using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Görsel_Program_vize_Proje
{
    public partial class Grafik : Form
    {
        public Grafik()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection("Data Source=DESKTOP-8E8HBS2\\SQLEXPRESS;Initial Catalog=KütüphaneOtomasyonu;Integrated Security=True");
        DataSet daset = new DataSet();
        private void Grafik_Load(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("select ad_soyad,okuma_kitap_sayısı from kutuphaneverigiris ",baglanti);
            SqlDataReader read = komut.ExecuteReader();

            while (read.Read())
            {
                chart1.Series["Okunan Kitap Sayısı"].Points.AddXY(read["ad_soyad"].ToString(),read["okuma_kitap_sayısı"]);
            }
            baglanti.Close();
            chart1.Series["Okunan Kitap Sayısı"].Color= Color.Orange;
        }

        private void chart1_Click(object sender, EventArgs e)
        {

        }
    }
}
