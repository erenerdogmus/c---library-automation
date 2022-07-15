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
    public partial class kitapEklefrm : Form
    {
        public kitapEklefrm()
        {
            InitializeComponent();
        }

        SqlConnection baglanti = new SqlConnection("Data Source=DESKTOP-8E8HBS2\\SQLEXPRESS;Initial Catalog=KütüphaneOtomasyonu;Integrated Security=True");
        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void kitapEklefrm_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("insert into kitap (barkodno,kitapadı,yazari,yayınevi,sayfasayisi,turu,stoksayisi,rafno,acıklama,kayıttarihi)values(@barkodno,@kitapadı,@yazari,@yayınevi,@sayfasayisi,@turu,@stoksayisi,@rafno,@acıklama,@kayıttarihi)", baglanti);

            komut.Parameters.AddWithValue("@barkodno", textBox1.Text);
            komut.Parameters.AddWithValue("@kitapadı", textBox2.Text);
            komut.Parameters.AddWithValue("@yazari", textBox3.Text);
            komut.Parameters.AddWithValue("@yayınevi", textBox4.Text);
            komut.Parameters.AddWithValue("@sayfasayisi", textBox5.Text);
            komut.Parameters.AddWithValue("@turu", comboBox1.Text);
            komut.Parameters.AddWithValue("@stoksayisi", textBox7.Text);
            komut.Parameters.AddWithValue("@rafno", textBox8.Text);
            komut.Parameters.AddWithValue("@acıklama", textBox9.Text);
            komut.Parameters.AddWithValue("@kayıttarihi", DateTime.Now.ToShortDateString());

            komut.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("kitap Kaydı Yapıldı");

            foreach (Control item in Controls)
            {
                if (item is TextBox)
                {                  
                        item.Text = " ";
                        comboBox1.Text = "";                 
                }
            }
        }
    }
}
