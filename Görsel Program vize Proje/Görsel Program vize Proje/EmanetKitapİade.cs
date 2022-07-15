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
    public partial class EmanetKitapİade : Form
    {
        public EmanetKitapİade()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection("Data Source=DESKTOP-8E8HBS2\\SQLEXPRESS;Initial Catalog=KütüphaneOtomasyonu;Integrated Security=True");
        DataSet daset = new DataSet();

        private void EmanetListele()
        {
            baglanti.Open();
            SqlDataAdapter adtr = new SqlDataAdapter("select * from emanetkitaplar", baglanti);
            adtr.Fill(daset, "emanetkitaplar");
            dataGridView1.DataSource = daset.Tables["emanetkitaplar"];
            baglanti.Close();
        }
        private void EmanetKitapİade_Load(object sender, EventArgs e)
        {
            EmanetListele();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            daset.Tables["emanetkitaplar"].Clear();
            baglanti.Open();
            SqlDataAdapter adtr = new SqlDataAdapter("select * from emanetkitaplar where tc like '%"+textBox1.Text+"%'", baglanti);
            adtr.Fill(daset, "emanetkitaplar");
            baglanti.Close();
            if (textBox1.Text=="")
            {
                daset.Tables["emanetkitaplar"].Clear();
                EmanetListele();

            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            daset.Tables["emanetkitaplar"].Clear();
            baglanti.Open();
            SqlDataAdapter adtr = new SqlDataAdapter("select * from emanetkitaplar where barkodno like '%" + textBox2.Text + "%'", baglanti);
            adtr.Fill(daset, "emanetkitaplar");
            baglanti.Close();
            if (textBox2.Text == "")
            {
                daset.Tables["emanetkitaplar"].Clear();
                EmanetListele();

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("select * from emanetkitaplar where tc=@tc and barkodno=@barkodno", baglanti);

            komut.Parameters.AddWithValue("@tc",dataGridView1.CurrentRow.Cells["tc"].Value.ToString());
            komut.Parameters.AddWithValue("@barkodno", dataGridView1.CurrentRow.Cells["barkodno"].Value.ToString());
            komut.ExecuteNonQuery();

            SqlCommand komut2 = new SqlCommand("update kitap set stoksayisi=@stoksayisi+'" +dataGridView1.CurrentRow.Cells["kitapsayisi"].Value.ToString()+"' where barkodno=@barkodno" ,baglanti);
            komut2.Parameters.AddWithValue("@barkodno", dataGridView1.CurrentRow.Cells["barkodno"].Value.ToString());
            komut2.ExecuteNonQuery();

            baglanti.Close();
            MessageBox.Show("Kitap/lar İade Edildi");
                

            daset.Tables["emanetkitaplar"].Clear();
            EmanetListele();

        }
    }
}
