using KolejUygulama.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Windows.Forms;
namespace KolejUygulama
{
    public partial class OgreciIslem : Form
    {
        public OgreciIslem()
        {
            InitializeComponent();
        }

        BilgeKolejiEntities1 db = new BilgeKolejiEntities1(); 

        private void btnogr_Click(object sender, EventArgs e)
        {
            dataGridView1.Show();
            dataGridView2.Visible = false;

            var query = from ogr in db.Ogrenciler
                        join s in db.Sube on ogr.SubeId equals s.Id
                        join sf in db.Sinif on s.SinifId equals sf.Id
                        select new { no= ogr.OkulNo,  Sınıf= sf.Sinif1, s.Sube1, ogr.Ad, ogr.Soyad, ogr.Cinsiyet, ogr.DevamDurumu };
            var ogrenci = db.Ogrenciler.ToList();
            dataGridView1.DataSource = query.ToList();

            
        }

        private void btnogrkaydet_Click(object sender, EventArgs e)
        {
            Ogrenciler o = new Ogrenciler();
            o.Ad = txtad.Text;
            o.Soyad = txtsoyad.Text;
            o.Cinsiyet = txtcinsiyet.Text;
            o.TCNo = txttc.Text;
            o.Gsm = txtgsm.Text;
            o.OkulNo = int.Parse(txtno.Text);
            o.SubeId = Convert.ToInt32(txtsubeid.Text);
            o.BitirdigiOkul = txtgeldigi.Text;
            o.NotOrt = decimal.Parse(txtnotort.Text);
            db.Ogrenciler.Add(o);
            db.SaveChanges();
            MessageBox.Show("Öğrenci Eklendi");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int x = Convert.ToInt32(txtid.Text);
            var o = db.Ogrenciler.Find(x);
            db.Ogrenciler.Remove(o);
            db.SaveChanges();
            MessageBox.Show("Öğrenci Silindi");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int x = Convert.ToInt32(txtid.Text);
            var o = db.Ogrenciler.Find(x);
            o.Ad = txtad.Text;
            o.Soyad = txtsoyad.Text;
            o.Cinsiyet = txtcinsiyet.Text;
            o.TCNo = txttc.Text;
            o.Gsm = txtgsm.Text;
            o.OkulNo = int.Parse(txtno.Text);
            o.SubeId = Convert.ToInt32(txtsubeid.Text);
            o.BitirdigiOkul = txtgeldigi.Text;
            o.NotOrt = decimal.Parse(txtnotort.Text);
            db.SaveChanges();
            MessageBox.Show("Güncelleme Yapıldı");
        }

        private void btnsınav_Click(object sender, EventArgs e)
        {
            dataGridView2.Show();
            dataGridView1.Visible = false;

            var query = from s in db.Sinavlar
                        join o in db.Ogrenciler on s.OgrenciId equals o.Id
                        join b in db.Brans on s.SınavId equals b.Id
                        select new { o.OkulNo, o.Ad, o.Soyad, b.BransAdi, s.Sınav1, s.Sınav2, s.Proje };
            var sinav = db.Sinavlar.ToList();
            dataGridView2.DataSource = query.ToList();
        }

        private void btnguncelle_Click(object sender, EventArgs e)
        {
            int x = Convert.ToInt32(textBox1.Text);
            var ogr = db.Sinavlar.Find(x);
            ogr.Sınav1 = Convert.ToByte(txtsınav1.Text);
            ogr.Sınav2 = Convert.ToByte(txtsınav2.Text);
            ogr.Proje = Convert.ToByte(txtproje.Text);
            db.SaveChanges();
            MessageBox.Show("Güncelleme Yapıldı");
        }
    }
}
