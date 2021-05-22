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
    public partial class BransEkle : Form
    {
        public BransEkle()
        {
            InitializeComponent();
        }

        BilgeKolejiEntities1 db = new BilgeKolejiEntities1();

        private void btnlistele_Click(object sender, EventArgs e)
        {
            var query = from b in db.Brans
                        select new { b.Id, b.BransAdi, b.DersSaati };
            var brans = db.Brans.ToList();
            dataGridView1.DataSource = query.ToList();
        }

        private void btnekle_Click(object sender, EventArgs e)
        {
            Brans b = new Brans();
            b.BransAdi = txtbransadi.Text;
            b.DersSaati = byte.Parse(txtderssaati.Text);
            db.Brans.Add(b);
            db.SaveChanges();
            MessageBox.Show("Branş Eklendi");
        }

        private void btnsil_Click(object sender, EventArgs e)
        {
            int x = Convert.ToInt32(txtid.Text);
            var b = db.Brans.Find(x);
            db.Brans.Remove(b);
            db.SaveChanges();
            MessageBox.Show("Branş Silindi");

        }
    }
}
