using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using EvidencijaClanova.Entiteti;
using NHibernate;
using SQLiteRepository2008;
using System.Net.Mail;
using System.Net;
using System.IO;
using System.Net.Mime;
using System.Xml;
using System.Security.Cryptography;
using EvidencijaClanova;

namespace SQLiteRepository2008
{
    public partial class ListaTreninga : Form
    {
        Form1 otac;
        ISession session;
        public IList<Trening> sviTreninzi;

        public ListaTreninga()
        {
            InitializeComponent();
        }
        public ListaTreninga(Form1 f, ISession s)
        {
            InitializeComponent();
            otac = f;
            session = s;
            prikaziTreninge();
        }

        private void ListaTreninga_Load(object sender, EventArgs e)
        {

        }
        public void prikaziTreninge()
        {
            try
            {
                dataGridView1.Rows.Clear();
                IQuery q = session.CreateQuery("FROM Trening");

                sviTreninzi = q.List<Trening>();
                foreach (Trening t in sviTreninzi)
                {
                    this.dataGridView1.Rows.Add(t.imeGrupe, t.termin);
                    int b = dataGridView1.Rows.Count;
                    dataGridView1.Rows[b - 1].Tag = t;
                }
            }
            catch 
            {
                MessageBox.Show("Neuspeli prikaz treninga");
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show("Molimo Vas selektujte nekog clana (kliknite skroz levo na strelicu zeljenog clana)");
                return;
            }
            try
            {
                TreningForma tf = new TreningForma(otac, session, (Trening)dataGridView1.SelectedRows[0].Tag, this);
                tf.Show();
            }
            catch { MessageBox.Show("Neuspesno citanje podataka o izabranom treningu"); }
           
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show("Molimo Vas selektujte nekog clana (kliknite skroz levo na strelicu zeljenog clana)");
                return;
            }
            DialogResult dialogResult = MessageBox.Show("Jeste li sigurni da obrisete ovog clana ?", "", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                try
                {
                    Trening brisi = (Trening)dataGridView1.SelectedRows[0].Tag;
                    IQuery q = session.CreateQuery("FROM Clan where trening_id='" + brisi.imeGrupe + "'");

                    IList<Clan> clanovi = q.List<Clan>();
                    foreach (Clan c in clanovi)
                    {
                        foreach (Merenje m in c.svaMerenja)
                            session.Delete(m);
                        c.svaMerenja.Clear();
                        foreach (Clanarina cl in c.sveClanarine)
                            session.Delete(cl);
                        c.sveClanarine.Clear();
                        session.Delete(c);

                    }
                    session.Delete(brisi); //Odkaci ili obrisi 

                    session.Flush();
                    prikaziTreninge();
                    otac.prikaziTreninge();
                    otac.prikaziClanoveIzabranihTreninga();
                }
                catch { MessageBox.Show("Iz nekog razloga brisanje treninga nije uspesno"); }
                
            }
            else if (dialogResult == DialogResult.No)
            {
                //do something else
            }
        }

    }
}
