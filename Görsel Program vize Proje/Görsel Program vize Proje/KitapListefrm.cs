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
    public partial class KitapListefrm : Form
    {
        public KitapListefrm()
        {
            InitializeComponent();
        }

        SqlConnection baglanti = new SqlConnection("Data Source=DESKTOP-8E8HBS2\\SQLEXPRESS;Initial Catalog=KütüphaneOtomasyonu;Integrated Security=True");
        DataSet daset = new DataSet();
        private void KitapListefrm_Load(object sender, EventArgs e)
        {
            kitaplistele();
        }
        private void kitaplistele()
        {
            baglanti.Open();
            SqlDataAdapter adtr = new SqlDataAdapter("select * from kitap", baglanti);
                
            adtr.Fill(daset, "kitap");
            dataGridView1.DataSource = daset.Tables["kitap"];
            baglanti.Close();
        }

       
        private void button1_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("update kitap set kitapadı=@kitapadı,yazari=@yazari,yayınevi=@yayınevi,sayfasayisi=@sayfasayisi,turu=@turu,stoksayisi=@stoksayisi,rafno=@rafno,acıklama=@acıklama where barkodno=@barkodno", baglanti);

            komut.Parameters.AddWithValue("@barkodno", textBox1.Text);
            komut.Parameters.AddWithValue("@kitapadı", textBox2.Text);
            komut.Parameters.AddWithValue("@yazari", textBox3.Text);
            komut.Parameters.AddWithValue("@yayınevi", comboBox1.Text);
            komut.Parameters.AddWithValue("@sayfasayisi", textBox5.Text);
            komut.Parameters.AddWithValue("@turu", comboBox1.Text);
            komut.Parameters.AddWithValue("@stoksayisi", textBox7.Text);
            komut.Parameters.AddWithValue("@rafno", textBox8.Text);
            komut.Parameters.AddWithValue("@acıklama", textBox9.Text);           

            komut.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Kayıt Güncellendi");

            daset.Tables["kitap"].Clear();
            kitaplistele();

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
            kitaplistele();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("delete from kitap where barkodno=@barkodno", baglanti);
            komut.Parameters.AddWithValue("@barkodno", dataGridView1.CurrentRow.Cells["barkodno"].Value.ToString());
            komut.ExecuteNonQuery();
            baglanti.Close();

            MessageBox.Show("Silme İşlemi Gerçekleşti");

            daset.Tables["kitap"].Clear();
            kitaplistele();

            foreach (Control item in Controls)
            {
                if (item is TextBox)
                {                  
                        item.Text = " ";
                        comboBox1.Text = "";   
                }
            }

            kitaplistele();
        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {
            daset.Tables["kitap"].Clear();
            baglanti.Open();
            SqlDataAdapter adtr = new SqlDataAdapter("select * from kitap where barkodno like'%" + textBox6.Text + "%'", baglanti);

            adtr.Fill(daset, "kitap");
            dataGridView1.DataSource = daset.Tables["kitap"];
            baglanti.Close();

           
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox1.Text = dataGridView1.CurrentRow.Cells["barkodno"].Value.ToString();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("select * from kitap where barkodno like '" + textBox1.Text + "' ", baglanti);
            SqlDataReader read = komut.ExecuteReader();

            while (read.Read())
            {
                textBox2.Text = read["kitapadı"].ToString();
                textBox3.Text = read["yazari"].ToString();
                textBox4.Text = read["yayınevi"].ToString();
                textBox5.Text = read["sayfasayisi"].ToString();
                comboBox1.Text = read["turu"].ToString();
                textBox7.Text = read["stoksayisi"].ToString();
                textBox8.Text = read["rafno"].ToString();
                textBox9.Text = read["acıklama"].ToString();
            }
            read.Close();
            komut.ExecuteNonQuery();
            
            baglanti.Close();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
    //        baglanti.Open();
    //        SqlCommand komut = new SqlCommand("select * from kitap where kitapadı like '" + textBox2.Text + "' ", baglanti);
    //        SqlDataReader read = komut.ExecuteReader();

    //        while (read.Read())
    //        {
               
    //            textBox3.Text = read["yazari"].ToString();
    //            textBox4.Text = read["yayınevi"].ToString();
    //            textBox5.Text = read["sayfasayisi"].ToString();
    //            comboBox1.Text = read["turu"].ToString();
    //            textBox7.Text = read["stoksayisi"].ToString();
    //            textBox8.Text = read["rafno"].ToString();
    //            textBox9.Text = read["acıklama"].ToString();
    //        }
         
    //        komut.ExecuteNonQuery();
    //        read.Close();
    //        baglanti.Close();
       }

        private void textBox10_TextChanged(object sender, EventArgs e)
        {
            daset.Tables["kitap"].Clear();
            baglanti.Open();
            SqlDataAdapter adtr = new SqlDataAdapter("select * from kitap where kitapadı like'%" + textBox10.Text + "%'", baglanti);

            adtr.Fill(daset, "kitap");
            dataGridView1.DataSource = daset.Tables["kitap"];
            baglanti.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void textBox11_TextChanged(object sender, EventArgs e)
        {
            daset.Tables["kitap"].Clear();
            baglanti.Open();
            SqlDataAdapter adtr = new SqlDataAdapter("select * from kitap where yazari like'%" + textBox11.Text + "%'", baglanti);

            adtr.Fill(daset, "kitap");
            dataGridView1.DataSource = daset.Tables["kitap"];
            baglanti.Close();

        }
    }
}
