using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Görsel_Program_vize_Proje
{
    public partial class AnaSayfafrm : Form
    {
        public AnaSayfafrm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ÜyeEkleFrm uyeekle = new ÜyeEkleFrm();
            uyeekle.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            uyelistelemefrm uyelisteleme = new uyelistelemefrm();
            uyelisteleme.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            kitapEklefrm kitapekle = new kitapEklefrm();
            kitapekle.ShowDialog();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            KitapListefrm kitapekle = new KitapListefrm();
            kitapekle.ShowDialog();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Emanetkitapvermeislemifrm emanetverme = new Emanetkitapvermeislemifrm();
            emanetverme.ShowDialog();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            EmanetKitapListele emanetlistele = new EmanetKitapListele();
            emanetlistele.ShowDialog();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            EmanetKitapİade emanetkitapiade = new EmanetKitapİade();
            emanetkitapiade.ShowDialog();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            Sıralama Sırala = new Sıralama();
            Sırala.ShowDialog();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            Grafik Grafik = new Grafik();
            Grafik.ShowDialog();
        }

        private void AnaSayfafrm_Load(object sender, EventArgs e)
        {

        }
    }
}
