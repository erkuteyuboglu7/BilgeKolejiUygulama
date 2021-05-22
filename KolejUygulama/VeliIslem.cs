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
    public partial class VeliIslem : Form
    {
        public VeliIslem()
        {
            InitializeComponent();
        }

        BilgeKolejiEntities1 db = new BilgeKolejiEntities1();

        private void btnlistele_Click(object sender, EventArgs e)
        {
            var query = from v in db.Veliler
                        join o in db.Ogrenciler on v.OgrenciId equals o.Id
                        select new { v.Ad, v.Soyad, v.Gsm, v.EvAdres, v.OgrenciId};
            var veli = db.Veliler.ToList();
            dataGridView1.DataSource = query.ToList();

        }

        private void btnekle_Click(object sender, EventArgs e)
        {
            Veliler v = new Veliler();
            v.Ad = txtad.Text;
            v.Soyad = txtsoyad.Text;
            v.Gsm = txtgsm.Text;
            v.EvAdres = txtadres.Text;
            v.OgrenciId = int.Parse(txtogrid.Text);
            db.Veliler.Add(v);
            db.SaveChanges();
            MessageBox.Show("Veli Eklendi");
        }

        private void btnguncelle_Click(object sender, EventArgs e)
        {
            int x = Convert.ToInt32(txtid.Text);
            var v = db.Veliler.Find(x);
            v.Ad = txtad.Text;
            v.Soyad = txtsoyad.Text;
            v.Gsm = txtgsm.Text;
            v.EvAdres = txtadres.Text;
            v.OgrenciId = int.Parse(txtogrid.Text);
            db.SaveChanges();
            MessageBox.Show("Güncelleme Yapıldı");
        }

        private void btnsil_Click(object sender, EventArgs e)
        {
            int x = Convert.ToInt32(txtid.Text);
            var v = db.Veliler.Find(x);
            db.Veliler.Remove(v);
            db.SaveChanges();
            MessageBox.Show("Veli Silindi");
        }
    }
}
