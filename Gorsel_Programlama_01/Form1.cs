using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Gorsel_Programlama_01
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        List<Urun> urunListesi = new List<Urun>();
        private void Form1_Load(object sender, EventArgs e)
        {
            StreamReader sr = new StreamReader("urunler.txt", Encoding.UTF8);
            string oku = " ";
            while ((oku = sr.ReadLine()) != null)
            {
                string[] parca = oku.Split('|');
                Urun u = new Urun();
                u.urun_id = Convert.ToInt32(parca[0]);
                u.urun_adi = parca[1];
                u.urun_fiyati = Convert.ToDecimal(parca[2]);
                urunListesi.Add(u);


            }
            sr.Close();
            cbx_urunler.DisplayMember = "urunAd_Fiyat";
            cbx_urunler.ValueMember = "urun_id";
            cbx_urunler.DataSource = urunListesi;
        }
        List<UrunListe> satilanUrunler = new List<UrunListe>();
        public class Urun {
            public int urun_id { get; set; }
            public string urun_adi { get; set; }
            public decimal urun_fiyati { get; set; }
            public string urunAd_Fiyat { get{ return urun_adi + " - " + urun_fiyati + " TL"; } }
            public Urun() { 
            
            }
        }
        public class UrunListe { 
         public Urun urun { get; set; }
         public string urunAd { get; set; }
            public decimal urunFiyat { get; set; }
            public int adet { get; set; }
            public decimal Tutar { get { return urunFiyat * adet; } }

        }

        private void btn_ekle_Click(object sender, EventArgs e)
        {
            UrunListe ul = new UrunListe();
            ul.urun = (Urun)cbx_urunler.SelectedItem;
            ul.urunAd = ul.urun.urun_adi;
            ul.urunFiyat = ul.urun.urun_fiyati;
            ul.adet = (int)(numericUpDown1.Value);
            satilanUrunler.Add(ul);

            dataGridView1.DataSource = null;
            dataGridView1.DataSource = satilanUrunler;
            dataGridView1.Columns[0].Visible = false;

            decimal toplamtutar = 0;
            foreach (var item in satilanUrunler)
            {
                toplamtutar += item.Tutar;
            }
            textBox1.Text = toplamtutar.ToString();
        }

        private void btn_kapat_Click(object sender, EventArgs e)
        {
           
               StreamWriter sw = new StreamWriter("satislar.txt", true, Encoding.UTF8);
               String tarih = DateTime.Now.ToString("dd.MM.yyyy.HH:mm:ss");
            foreach (var item in satilanUrunler)
                {
                    sw.WriteLine(tarih + "|" + item.urun.urun_adi + "|" + item.adet + "|" + item.Tutar);
                }
                sw.Close();
                
                satilanUrunler= null;
                dataGridView1.DataSource = satilanUrunler;
                textBox1.Text = " ";
                cbx_urunler.SelectedIndex = 0;
                numericUpDown1.Value = 0;
                MessageBox.Show("Satışlar kaydedildi");
            
         
        }
    }
}
