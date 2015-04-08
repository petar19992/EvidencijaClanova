using EvidencijaClanova;
using NHibernate;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using EvidencijaClanova.Entiteti;

namespace SQLiteRepository2008
{
    public partial class Finansije : Form
    {
        public IList<Clanarina> nizClanarina = new List<Clanarina>();
        private ISession session;
        double prihod;
        double dugovanje;
        public Finansije()
        {
            InitializeComponent();
            session = DataLayer.GetSession();
            prihod = 0;
            dugovanje = 0;
            prikaziTreninge();
        }

        //private void dgmPrikazi_Click(object sender, EventArgs e)
        //{
        //    double prihod = 0;
        //    double dug = 0;
        //    gridFinansije.Rows.Clear();
        //    IQuery q = session.CreateQuery("FROM Clanarina");
        //    IList<Clanarina> sveClanarine = q.List<Clanarina>();
        //    foreach (Clanarina c in sveClanarine)
        //    {
        //        DateTime poc = c.pocetak;
        //        DateTime kraj = c.kraj;
        //        if (poc >= datePocetak.Value && kraj <= dateKraj.Value)
        //        {
        //            String ime = " ";
        //            String prezime = " ";
        //            String trening = " ";
        //            ime = c.clan.ime;
        //            prezime = c.clan.prezime;
        //            trening = c.clan.trening.imeGrupe;
        //            prihod += c.clanarina;
        //            dug += c.dug;
        //            gridFinansije.Rows.Add(c.clan.sifraKartice, ime, prezime, trening, c.clanarina, c.dug);
        //            session.Flush();
        //        }
        //    }

        //    textBox1.Text = prihod.ToString();
        //    textBox2.Text = dug.ToString();
        //    //gridFinansije.Rows.Add("", "", "",  "Prihod:", prihod);
        //    //int count = gridFinansije.RowCount;
        //    //gridFinansije.Rows[count - 2].Cells["Trening"].Style.BackColor = Color.Green;
        //    //gridFinansije.Rows[count - 2].Cells["Cena"].Style.BackColor = Color.Green;
        //}
        public void prikaziTreninge()
        {
            //this.groupBox1.ch
            treninziToolStripMenuItem.DropDownItems.Clear();
            var PrikazisviTreninzi = new System.Windows.Forms.ToolStripMenuItem()
            {
                Name = "Prikazi sve",
                Text = "Prikaži sve"
            };
            treninziToolStripMenuItem.DropDownItems.Add(PrikazisviTreninzi);
            PrikazisviTreninzi.Click += new System.EventHandler(this.prikaziSveTreninge);
            //treninziToolStripMenuItem.DropDownItems.Add(new ToolStripSeparator());
            IQuery q = session.CreateQuery("FROM Trening");
            IList<Trening> sviTreninzi = q.List<Trening>();
            foreach (Trening t in sviTreninzi)
            {
                var item = new System.Windows.Forms.ToolStripMenuItem()
                {
                    Name = t.imeGrupe,
                    Text = t.imeGrupe
                };
                //item.Checked = true;
                item.Tag = t;
                treninziToolStripMenuItem.DropDownItems.Add(item);
                item.Click += new System.EventHandler(this.kliknutTrening);
            }
            session.Flush();
        }
        public void kliknutTrening(object sender, EventArgs e)
        {

            gridFinansije.Rows.Clear();
            prihod = 0;
            dugovanje = 0;
            ToolStripMenuItem i = (ToolStripMenuItem)sender;
            if (i.Checked == true)
                i.Checked = false;
            else
                i.Checked = true;
            foreach (ToolStripMenuItem item in treninziToolStripMenuItem.DropDownItems)
            {
                if (item.Checked == true && item.Tag != null)
                {
                    prikaziClanarineZaKliknutTrening((Trening)item.Tag);
                }
            }
            textBox1.Text = prihod.ToString();
            textBox2.Text = dugovanje.ToString();
        }

        public void prikaziSveTreninge(object sender, EventArgs e)
        {
            ToolStripMenuItem prvi = (ToolStripMenuItem)sender;
            prvi.Checked = !prvi.Checked;
            bool prikaz = prvi.Checked;
            foreach (ToolStripMenuItem i in treninziToolStripMenuItem.DropDownItems)
            {
                i.Checked = prikaz;
            }
            if (prikaz)
            {
                prikaziSveClanove();
            }
            else
            {
                gridFinansije.Rows.Clear();
                prihod = 0;
                dugovanje = 0;
                textBox1.Text = prihod.ToString();
                textBox2.Text = dugovanje.ToString();
            }

        }

        public void prikaziSveClanove()
        {
            prihod = 0;
            dugovanje = 0;
            gridFinansije.Rows.Clear();
            IQuery q = session.CreateQuery("FROM Clanarina");
            IList<Clanarina> sveClanarine = q.List<Clanarina>();
            foreach (Clanarina c in sveClanarine)
            {

                DateTime poc = c.pocetak.Date;
                DateTime kraj = c.kraj.Date;
                if (poc >= datePocetak.Value.Date && poc <= dateKraj.Value.Date)
                {
                    String ime = " ";
                    String prezime = " ";
                    String trening = " ";
                    ime = c.clan.ime;
                    prezime = c.clan.prezime;
                    trening = c.clan.trening.imeGrupe;
                    prihod += c.clanarina;
                    dugovanje += c.dug;
                    gridFinansije.Rows.Add(c.clan.sifraKartice, ime, prezime, trening, c.clanarina, c.dug);
                    session.Flush();
                }
            }

            textBox1.Text = prihod.ToString();
            textBox2.Text = dugovanje.ToString();
        }
        public void prikaziClanarineZaKliknutTrening(Trening t)
        {
            //gridFinansije.Rows.Clear();
            IQuery q = session.CreateQuery("FROM Clan where trening_id='" + t.imeGrupe + "'");
            IList<Clan> sviClanovi = q.List<Clan>();
            foreach (Clan clan in sviClanovi)
            {
                foreach (Clanarina c in clan.sveClanarine)
                {
                    DateTime poc = c.pocetak.Date;
                    DateTime kraj = c.kraj.Date;
                    if (poc >= datePocetak.Value.Date && poc <= dateKraj.Value.Date)
                    {
                        String ime = " ";
                        String prezime = " ";
                        String trening = " ";
                        ime = c.clan.ime;
                        prezime = c.clan.prezime;
                        trening = c.clan.trening.imeGrupe;
                        prihod += c.clanarina;
                        dugovanje += c.dug;
                        gridFinansije.Rows.Add(c.clan.sifraKartice, ime, prezime, trening, c.clanarina, c.dug);
                        //session.Flush();
                    }
                }

            }
            //    IQuery q = session.CreateQuery("FROM Clanarina");
            //    IList<Clanarina> sveClanarine = q.List<Clanarina>();
            //    foreach (Clanarina c in sveClanarine)
            //    {
            //        DateTime poc = c.pocetak;
            //        DateTime kraj = c.kraj;
            //        if (poc >= datePocetak.Value && kraj <= dateKraj.Value)
            //        {
            //            String ime = " ";
            //            String prezime = " ";
            //            String trening = " ";
            //                ime = c.clan.ime;
            //                prezime = c.clan.prezime;
            //                trening = c.clan.trening.imeGrupe;
            //            prihod += c.clanarina;
            //            dug += c.dug;
            //            gridFinansije.Rows.Add(c.clan.sifraKartice, ime, prezime, trening, c.clanarina,c.dug);
            //            session.Flush();
            //        }
            //}
        }

        private void dateKraj_ValueChanged(object sender, EventArgs e)
        {
            gridFinansije.Rows.Clear();
            prihod = 0;
            dugovanje = 0;
            //ToolStripMenuItem i = (ToolStripMenuItem)sender;
            //if (i.Checked == true)
            //    i.Checked = false;
            //else
            //    i.Checked = true;
            foreach (ToolStripMenuItem item in treninziToolStripMenuItem.DropDownItems)
            {
                if (item.Checked == true && item.Tag != null)
                {
                    prikaziClanarineZaKliknutTrening((Trening)item.Tag);
                }
            }
            textBox1.Text = prihod.ToString();
            textBox2.Text = dugovanje.ToString();
        }
    }
}
