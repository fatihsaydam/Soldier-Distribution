using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _131227Win_AskerDagitim
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnKisiEkle_Click(object sender, EventArgs e)
        {
            listKisiler.Items.Add(txtKisiEkle.Text.ToUpper());
            txtKisiEkle.Clear();
            txtKisiEkle.Focus();
        }

        private void btnBolgeEkle_Click(object sender, EventArgs e)
        {
            listBolgeler.Items.Add(txtBolgeEkle.Text.ToUpper());
            txtBolgeEkle.Clear();
            txtBolgeEkle.Focus();
        }


        private void btnDagitim_Click(object sender, EventArgs e)
        {
            listEslesmeler.Items.Clear();
            Random rnd = new Random();
            ArrayList askerler = new ArrayList();
            ArrayList iller = new ArrayList();

            askerler.AddRange(listKisiler.Items);
            iller.AddRange(listBolgeler.Items);

            int askerSayisi = askerler.Count;
            if (askerler.Count == iller.Count)
            {

                for (int i = 0; i < askerSayisi; i++)
                {
                    Dagitim(rnd, askerler, iller);
                }
            }
            else if (askerler.Count > iller.Count)
            {
                ArrayList YedekIller = new ArrayList();
                YedekIller.AddRange(listBolgeler.Items);

                do
                {
                    Dagitim(rnd, askerler, iller);
                } while (iller.Count != 0);

                for (int i = 0; i < askerSayisi; i++)
                {
                    if (askerler.Count == 0) return;
                    int asker = rnd.Next(0, askerler.Count);
                    int il = rnd.Next(0, YedekIller.Count);
                    listEslesmeler.Items.Add(askerler[asker].ToString() + "--->" + YedekIller[il].ToString());
                    askerler.RemoveAt(asker);
                    YedekIller.RemoveAt(il);
                }
            }
            else if (askerler.Count < iller.Count)
            {
                do
                {
                    Dagitim(rnd, askerler, iller);
                } while (askerler.Count != 0);
            }
        }

        private void Dagitim(Random rnd, ArrayList askerler, ArrayList iller)
        {
            int asker = rnd.Next(0, askerler.Count);
            int il = rnd.Next(0, iller.Count);
            listEslesmeler.Items.Add(askerler[asker].ToString() + "--->" + iller[il].ToString());
            askerler.RemoveAt(asker);
            iller.RemoveAt(il);
        }

        private void btnAskerTemizle_Click(object sender, EventArgs e)
        {
            listKisiler.Items.Clear();
            txtKisiEkle.Focus();
        }

        private void btnBolgeTemizle_Click(object sender, EventArgs e)
        {
            listBolgeler.Items.Clear();
            txtBolgeEkle.Focus();
        }

        private void btnEslesmeTemizle_Click(object sender, EventArgs e)
        {
            listEslesmeler.Items.Clear();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

    }
}
