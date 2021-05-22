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
    public partial class SubeEkle : Form
    {
        public SubeEkle()
        {
            InitializeComponent();
        }

        BilgeKolejiEntities1 db = new BilgeKolejiEntities1();

        private void btnlistele_Click(object sender, EventArgs e)
        {
            var query = from sube in db.Sube
                        join sinif in db.Sinif on sube.SinifId equals sinif.Id
                        select new { sube.Id, sinif.Sinif1, sube.Sube1 };
            var subee = db.Sube.ToList();
            dataGridView1.DataSource = query.ToList();
        }

        private void btnekle_Click(object sender, EventArgs e)
        {
            Sube s = new Sube();
            s.Sube1 = txtsube.Text;
            s.SinifId = int.Parse(txtsinifid.Text);
            db.Sube.Add(s);
            db.SaveChanges();
            MessageBox.Show("Şube Eklendi");
        }

        private void btnsil_Click(object sender, EventArgs e)
        {
            int x = Convert.ToInt32(txtid.Text);
            var s = db.Sube.Find(x);
            db.Sube.Remove(s);
            db.SaveChanges();
            MessageBox.Show("Şube Silindi");

        }
    }
}
