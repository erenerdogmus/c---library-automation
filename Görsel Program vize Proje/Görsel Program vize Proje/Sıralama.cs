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
    public partial class Sıralama : Form
    {
        public Sıralama()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection("Data Source=DESKTOP-8E8HBS2\\SQLEXPRESS;Initial Catalog=KütüphaneOtomasyonu;Integrated Security=True");
        DataSet daset = new DataSet();

        private void Sıralama_Load(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlDataAdapter adtr = new SqlDataAdapter("select * from kutuphaneverigiris order by okuma_kitap_sayısı desc", baglanti);
            adtr.Fill(daset, "kutuphaneverigiris");
            dataGridView1.DataSource = daset.Tables["kutuphaneverigiris"];
            baglanti.Close();

            label2.Text = "";
            label4.Text = "";

            label2.Text = daset.Tables["kutuphaneverigiris"].Rows[0]["ad_soyad"].ToString()+"=";
            label2.Text += daset.Tables["kutuphaneverigiris"].Rows[0]["okuma_kitap_sayısı"].ToString();

            label4.Text = daset.Tables["kutuphaneverigiris"].Rows[dataGridView1.Rows.Count-2]["ad_soyad"].ToString() + "=";
            label4.Text += daset.Tables["kutuphaneverigiris"].Rows[dataGridView1.Rows.Count-2]["okuma_kitap_sayısı"].ToString();
        }
    }
}
