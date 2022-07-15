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
    public partial class uyelistelemefrm : Form
    {
        public uyelistelemefrm()
        {
            InitializeComponent();
        }

        SqlConnection baglanti = new SqlConnection("Data Source=DESKTOP-8E8HBS2\\SQLEXPRESS;Initial Catalog=KütüphaneOtomasyonu;Integrated Security=True");
        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox1.Text = dataGridView1.CurrentRow.Cells["tc"].Value.ToString();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("select * from kutuphaneverigiris where tc like '"+textBox1.Text+ "' ", baglanti);
            SqlDataReader read = komut.ExecuteReader();

            while (read.Read()) 
            {
                textBox2.Text = read["ad_soyad"].ToString();
                textBox3.Text = read["yas"].ToString();
                comboBox1.Text = read["cinsiyet"].ToString();
                textBox5.Text = read["telefon"].ToString();
                textBox6.Text = read["adres"].ToString();
                textBox7.Text = read["email"].ToString();
                textBox8.Text = read["okuma_kitap_sayısı"].ToString();
            }
            read.Close();
            komut.ExecuteNonQuery();
            baglanti.Close();
            
        }

        DataSet daset = new DataSet();
        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            daset.Tables["kutuphaneverigiris"].Clear();
            baglanti.Open();
            SqlDataAdapter adtr = new SqlDataAdapter("select * from kutuphaneverigiris where tc like'%"+textBox4.Text+ "%'",baglanti);

            adtr.Fill(daset, "kutuphaneverigiris");
            dataGridView1.DataSource = daset.Tables["kutuphaneverigiris"];
            baglanti.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("delete from kutuphaneverigiris where tc=@tc", baglanti);
            komut.Parameters.AddWithValue("@tc", dataGridView1.CurrentRow.Cells["tc"].Value.ToString());
            komut.ExecuteNonQuery();
            baglanti.Close();

            MessageBox.Show("Silme İşlemi Gerçekleşti");

            daset.Tables["kutuphaneverigiris"].Clear();
            uyelistele();

             foreach (Control item in Controls)
            {
                if (item is TextBox)
                {
                    if (item != textBox8)
                    {
                        item.Text = " ";
                        comboBox1.Text = "";
                    }

                }
            }

            uyelistele();
        }


        private void uyelistele()
        {
            baglanti.Open();
            SqlDataAdapter adtr = new SqlDataAdapter("select * from kutuphaneverigiris", baglanti);

            adtr.Fill(daset, "kutuphaneverigiris");
            dataGridView1.DataSource = daset.Tables["kutuphaneverigiris"];
            baglanti.Close();
        }

        private void uyelistelemefrm_Load(object sender, EventArgs e)
        {
            uyelistele();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("update kutuphaneverigiris set ad_soyad=@ad_soyad,yas=@yas,cinsiyet=@cinsiyet,telefon=@telefon,adres=@adres,email=@email,okuma_kitap_sayısı=@okuma_kitap_sayısı where tc=@tc", baglanti);
            
            komut.Parameters.AddWithValue("@tc",textBox1.Text);
            komut.Parameters.AddWithValue("@ad_soyad", textBox2.Text);
            komut.Parameters.AddWithValue("@yas", textBox3.Text);
            komut.Parameters.AddWithValue("@cinsiyet", comboBox1.Text);
            komut.Parameters.AddWithValue("@telefon", textBox5.Text);
            komut.Parameters.AddWithValue("@adres", textBox6.Text);
            komut.Parameters.AddWithValue("@email", textBox7.Text);
            komut.Parameters.AddWithValue("@okuma_kitap_sayısı",int.Parse(textBox8.Text));

            komut.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Kayıt Güncellendi");

            daset.Tables["kutuphaneverigiris"].Clear();
            uyelistele();

            foreach (Control item in Controls)
            {
                if (item is TextBox)
                {
                    if (item != textBox8)
                    {
                        item.Text = " ";
                        comboBox1.Text = "";
                    }

                }
            }
           daset.Tables["kutuphaneverigiris"].Clear();
           uyelistele();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
          
        }

        private void label8_Click(object sender, EventArgs e)
        {

        }
    }
}
