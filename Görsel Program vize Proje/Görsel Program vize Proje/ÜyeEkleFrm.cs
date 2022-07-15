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

namespace Görsel_Program_vize_Proje
{
    public partial class ÜyeEkleFrm : Form
    {
        public ÜyeEkleFrm()
        {
            InitializeComponent();
        }

        SqlConnection baglanti = new SqlConnection("Data Source=DESKTOP-8E8HBS2\\SQLEXPRESS;Initial Catalog=KütüphaneOtomasyonu;Integrated Security=True");
        private void ÜyeEkleFrm_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("insert into kutuphaneverigiris(tc,ad_soyad,yas,cinsiyet,telefon,adres,email,okuma_kitap_sayısı)values(@tc,@ad_soyad,@yas,@cinsiyet,@telefon,@adres,@email,@okuma_kitap_sayısı)", baglanti);

            komut.Parameters.AddWithValue("@tc", textBox1.Text);
            komut.Parameters.AddWithValue("@ad_soyad", textBox2.Text);
            komut.Parameters.AddWithValue("@yas", textBox3.Text);
            komut.Parameters.AddWithValue("@cinsiyet", comboBox1.Text);
            komut.Parameters.AddWithValue("@telefon", textBox5.Text);
            komut.Parameters.AddWithValue("@adres", textBox6.Text);
            komut.Parameters.AddWithValue("@email", textBox7.Text);
            komut.Parameters.AddWithValue("@okuma_kitap_sayısı", textBox8.Text);

            komut.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Üye Kaydı Yapıldı");

            foreach(Control item in Controls)
            {
                if(item is TextBox)
                {
                    if (item!=textBox8)
                    {
                        item.Text = " ";
                        comboBox1.Text = "";
                    }
                    
                }
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
