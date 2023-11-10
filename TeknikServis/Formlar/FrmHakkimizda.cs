using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TeknikServis.Formlar
{
    public partial class FrmHakkimizda : Form
    {
        public FrmHakkimizda()
        {
            InitializeComponent();
        }
        DbTeknikServisEntities1 db = new DbTeknikServisEntities1();
        private void FrmHakkimizda_Load(object sender, EventArgs e)
        {
            int sayac = db.TBLILETISIM.Count();
            string konu, ad, mesaj, tarih;
            listView1.Columns.Add("Ad-Soyad", 100);
            listView1.Columns.Add("Konu", 100);
            listView1.Columns.Add("Mesaj", 200);
            listView1.Columns.Add("Tarih", 100);
            int i = 1;
            while (sayac>0)
            {
                konu = db.TBLILETISIM.First(x => x.ID == sayac).KONU;
                ad = db.TBLILETISIM.First(x => x.ID == sayac).ADSOYAD;
                mesaj = db.TBLILETISIM.First(x => x.ID == sayac).MESAJ;
                tarih = Convert.ToString(db.TBLILETISIM.First(x => x.ID == sayac).TARIH);

                listBox1.Items.Add(ad + " - " + konu + " - " + mesaj + " - " + tarih);
                string[] liste = {"a","b","c","d" };
                liste.SetValue(ad,0);
                liste.SetValue(konu,1);
                liste.SetValue(mesaj,2);
                liste.SetValue(tarih,3);

                ListViewItem lst = new ListViewItem(liste);
                listView1.Items.Add(lst);

                Label lbl = new Label();
                lbl.Name = "label" + i;
                lbl.ForeColor = Color.Red;
                lbl.Width = 150;
                lbl.Text = "Gönderen: "+ad;
                lbl.Location = new Point(10,20);
               

                Label lbl2 = new Label();
                lbl2.Name = "labell" + i;
                lbl2.ForeColor = Color.Green;
                lbl2.Width = 200;
                lbl2.Text = "Konu: "+konu;
                lbl2.Location = new Point(180,20);

                Label lbl3 = new Label();
                lbl3.Name = "labelll" + i;
                lbl3.ForeColor = Color.Black;
                lbl3.Width = 150;
                lbl3.Height = 100;
                
                lbl3.Text = "Mesaj: "+mesaj;
                lbl3.Location = new Point(10,45);

                Label lbl4 = new Label();
                lbl4.Name = "labellll" + i;
                lbl4.ForeColor = Color.Gray;
                lbl4.Width = 100;
                lbl4.Text = "Tarih: " + tarih;
                lbl4.Location = new Point(395, 20);

                Panel p = new Panel();
                p.Name = "panell" + i;
                p.Width = 640;
                p.Height = 80;
                p.BackColor = Color.Yellow;
                p.Controls.Add(lbl);
                p.Controls.Add(lbl2);
                p.Controls.Add(lbl3);
                p.Controls.Add(lbl4);
                flowLayoutPanel1.Controls.Add(p);


                i++;
                sayac--;
            }


        }
    }
}
