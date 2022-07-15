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
    public partial class Emanetkitapvermeislemifrm : Form
    {
        public Emanetkitapvermeislemifrm()
        {
            InitializeComponent();
        }

        SqlConnection baglanti = new SqlConnection("Data Source=DESKTOP-8E8HBS2\\SQLEXPRESS;Initial Catalog=KütüphaneOtomasyonu;Integrated Security=True");
        DataSet dataSet = new DataSet();
        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }
      
        private void kitapsayisi()
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("select sum(kitapsayisi) from sepet", baglanti);
            label16.Text = komut.ExecuteScalar().ToString();
            baglanti.Close();
        }
        private void sepetlistele()
        {
            baglanti.Open();
            SqlDataAdapter adtr = new SqlDataAdapter("select * from sepet", baglanti);
            adtr.Fill(dataSet,"sepet");
            dataGridView1.DataSource = dataSet.Tables["sepet"];

            baglanti.Close();
        }
        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Emanetkitapvermeislemifrm_Load(object sender, EventArgs e)
        {
            sepetlistele();
            kitapsayisi();
            //kitaplistele();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("insert into sepet (barkodno,kitapadi,yazari,yayınevi,sayfasayisi,kitapsayisi,teslimtarihi,iadetarihi) values(@barkodno,@kitapadi,@yazari,@yayınevi,@sayfasayisi,@kitapsayisi,@teslimtarihi,@iadetarihi)", baglanti);

            komut.Parameters.AddWithValue("@barkodno",textBox5.Text);
            komut.Parameters.AddWithValue("@kitapadi",textBox6.Text);
            komut.Parameters.AddWithValue("@yazari",textBox7.Text);
            komut.Parameters.AddWithValue("@yayınevi",textBox8.Text);
            komut.Parameters.AddWithValue("@sayfasayisi",textBox9.Text);
            komut.Parameters.AddWithValue("@kitapsayisi",textBox10.Text);
            komut.Parameters.AddWithValue("@teslimtarihi",dateTimePicker1.Text);
            komut.Parameters.AddWithValue("@iadetarihi",dateTimePicker2.Text);

            komut.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Kitaplar Sepete Eklendi");

            dataSet.Tables["sepet"].Clear();
            sepetlistele();

            label16.Text = "";
            kitapsayisi();

            foreach (Control item in groupBox2.Controls)
            {
                if (item is TextBox)
                {
                    if (item!=textBox10)
                    {
                        item.Text = " ";
                    }
                }
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            baglanti.Open();

            SqlCommand komut = new SqlCommand("select * from kutuphaneverigiris where tc like'"+textBox1.Text+"'", baglanti);
            SqlDataReader read = komut.ExecuteReader();

            while (read.Read())
            {

                textBox2.Text = read["ad_soyad"].ToString();
                textBox3.Text = read["yas"].ToString();
                textBox4.Text = read["telefon"].ToString();             
            }
            baglanti.Close();

            baglanti.Open();
            SqlCommand komut2 = new SqlCommand("select sum(kitapsayisi) from emanetkitaplar where tc='"+textBox1.Text+"'", baglanti);
            label14.Text = komut2.ExecuteScalar().ToString();
            baglanti.Close();

            if (textBox1.Text == "") 
            {
                foreach (Control item in groupBox1.Controls)
                {

                    if (item is TextBox)
                    {
                        item.Text = " ";
                        label14.Text = "";
                    }
                   
                }
                label14.Text = "";
            }
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("select * from kitap where barkodno like'" + textBox5.Text + "'", baglanti);
            SqlDataReader read = komut.ExecuteReader();

            
            while (read.Read())
            {

                textBox6.Text = read["kitapadı"].ToString();
                textBox7.Text = read["yazari"].ToString();
                textBox8.Text = read["yayınevi"].ToString();
                textBox9.Text = read["sayfasayisi"].ToString();                             
            }
            baglanti.Close();

            if (textBox5.Text=="")
            { 
                foreach (Control item in groupBox2.Controls)
                {
                    if(item is TextBox)
                    {
                         if (item!=label16)
                            {
                                item.Text = "";
                            }
                    }
                }
        }
    }

        private void button4_Click(object sender, EventArgs e)
        {
            DialogResult dialog;
            dialog = MessageBox.Show("Kayıt Silinsin mi?","Uyarı",MessageBoxButtons.YesNo,MessageBoxIcon.Information);
            if (dialog==DialogResult.Yes)
            {
                baglanti.Open();
                SqlCommand komut = new SqlCommand("delete from sepet where barkodno='" + dataGridView1.CurrentRow.Cells["barkodno"].Value.ToString() + "'", baglanti);
                komut.ExecuteNonQuery();
                baglanti.Close();

                MessageBox.Show("silme işlemi yapıldı","Silme İşlemi");
                dataSet.Tables["sepet"].Clear();
                sepetlistele();

                label16.Text = "";
                kitapsayisi();
            }
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (label16.Text!="")
            {
                if (label14.Text=="" && int.Parse(label16.Text) <= 3 || label14.Text!="" && int.Parse(label14.Text)+int.Parse(label16.Text)<=3)
                {
                    if (textBox1.Text!=""&& textBox2.Text!="" && textBox3.Text != "" && textBox4.Text != "")
                    {

                        for (int i=0;i<dataGridView1.Rows.Count-1;i++)
                        {
                            baglanti.Open();
                            SqlCommand komut = new SqlCommand("insert into emanetkitaplar(tc,adsoyad,yas,telefon,barkodno,kitapadi,yazari,yayınevi,sayfasayisi,kitapsayisi,teslimtarihi,iadetarihi) values(@tc,@adsoyad,@yas,@telefon,@barkodno,@kitapadi,@yazari,@yayınevi,@sayfasayisi,@kitapsayisi,@teslimtarihi,@iadetarihi)", baglanti);

                            komut.Parameters.AddWithValue("@tc",textBox1.Text);
                            komut.Parameters.AddWithValue("@adsoyad", textBox2.Text);
                            komut.Parameters.AddWithValue("@yas", textBox3.Text);
                            komut.Parameters.AddWithValue("@telefon", textBox4.Text);
                            komut.Parameters.AddWithValue("@barkodno",dataGridView1.Rows[i].Cells["barkodno"].Value.ToString());
                            komut.Parameters.AddWithValue("@kitapadi", dataGridView1.Rows[i].Cells["kitapadi"].Value.ToString());
                            komut.Parameters.AddWithValue("@yazari", dataGridView1.Rows[i].Cells["yazari"].Value.ToString());
                            komut.Parameters.AddWithValue("@yayınevi", dataGridView1.Rows[i].Cells["yayınevi"].Value.ToString());
                            komut.Parameters.AddWithValue("@sayfasayisi", dataGridView1.Rows[i].Cells["sayfasayisi"].Value.ToString());
                            komut.Parameters.AddWithValue("@kitapsayisi", int.Parse(dataGridView1.Rows[i].Cells["kitapsayisi"].Value.ToString()));
                            komut.Parameters.AddWithValue("@teslimtarihi", dataGridView1.Rows[i].Cells["teslimtarihi"].Value.ToString());
                            komut.Parameters.AddWithValue("@iadetarihi", dataGridView1.Rows[i].Cells["iadetarihi"].Value.ToString());

                            komut.ExecuteNonQuery();
                            
                            SqlCommand komut2 = new SqlCommand("update kutuphaneverigiris set okuma_kitap_sayısı=okuma_kitap_sayısı+'" + int.Parse(dataGridView1.Rows[i].Cells["kitapsayisi"].Value.ToString()) +"' where tc= '" +textBox1.Text+"'", baglanti);
                            komut2.ExecuteNonQuery();

                            SqlCommand komut3 = new SqlCommand("update kitap set stoksayisi=stoksayisi-'" + int.Parse(dataGridView1.Rows[i].Cells["kitapsayisi"].Value.ToString()) + "' where barkodno= '" +dataGridView1.Rows[i].Cells["barkodno"].Value.ToString()+ "'", baglanti);
                            komut3.ExecuteNonQuery();

                            baglanti.Close();

                        }

                        baglanti.Open();
                        SqlCommand komut4 = new SqlCommand("delete from sepet ", baglanti);
                        komut4.ExecuteNonQuery();
                        baglanti.Close();
                        MessageBox.Show("kitap(lar) emanet edildi");

                        dataSet.Tables["sepet"].Clear();
                        sepetlistele();

                        textBox1.Text = "";
                       

                        label16.Text = "";
                        kitapsayisi();
                        label14.Text = "";

                    }
                    else
                    {
                        MessageBox.Show("Önce Üye İsmi Secmeniz Gerekir");
                    }
                }
                else
                {
                    MessageBox.Show("Emanet Kitap Sayısı 3 ten fazla olamaz");
                }
            }
            else 
            {
                MessageBox.Show("Önce Sepete Kitap Ekle","Uyarı");
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
