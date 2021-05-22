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
    public partial class OgretmenIslem : Form
    {
        public OgretmenIslem()
        {
            InitializeComponent();
        }

        BilgeKolejiEntities1 db = new BilgeKolejiEntities1();

        private void btnlistele_Click(object sender, EventArgs e)
        {
            var query = from ogretmen in db.Ogretmenler
                        join brans in db.Brans on ogretmen.BransId equals brans.Id
                        select new { ogretmen.Id ,ogretmen.Ad, ogretmen.Soyad, ogretmen.Gorev, ogretmen.Sifre, brans.BransAdi };
            var ogretmenlerr = db.Ogretmenler.ToList();
            dataGridView1.DataSource = query.ToList();
        }

        private void btnekle_Click(object sender, EventArgs e)
        {
            Ogretmenler ogt = new Ogretmenler();
            ogt.Ad = txtad.Text;
            ogt.Soyad = txtsoyad.Text;
            ogt.Gorev = txtgorev.Text;
            ogt.BransId = int.Parse(txtbransıd.Text);
            ogt.Sifre = txtsifre.Text;
            db.Ogretmenler.Add(ogt);
            db.SaveChanges();
            MessageBox.Show("Öğretmen Eklendi");
        }

        private void btnguncelle_Click(object sender, EventArgs e)
        {
            int x = Convert.ToInt32(txtid.Text);
            var ogt = db.Ogretmenler.Find(x);
            ogt.Ad = txtad.Text;
            ogt.Soyad = txtsoyad.Text;
            ogt.Gorev = txtgorev.Text;
            ogt.BransId = int.Parse(txtbransıd.Text);
            ogt.Sifre = txtsifre.Text;
            db.SaveChanges();
            MessageBox.Show("Güncelleme Yapıldı");
        }

        private void btnsil_Click(object sender, EventArgs e)
        {
            int x = Convert.ToInt32(txtid.Text);
            var ogt = db.Ogretmenler.Find(x);
            db.Ogretmenler.Remove(ogt);
            db.SaveChanges();
            MessageBox.Show("Öğretmen Silindi");
        }
    }
}
