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
using EvidencijaClanova;

namespace SQLiteRepository2008
{
    public partial class Izmeni : Form
    {
        ISession session;
        public Clan clan;
        public IList<Merenje> merenja;
        public IList<Clanarina> clanarine;
        public Form1 form1;
        public Izmeni()
        {
            InitializeComponent();
        }
        public Izmeni(Clan c,Form1 f, ISession s)
        {
            InitializeComponent();
            clan = c;
            session = s;
            form1 = f;
            popuniInfo();
            popuniMerenja();
            popuniClanarine();
        }

        private void Izmeni_Load(object sender, EventArgs e)
        {

        }

        public void popuniMerenja()
        {
            this.dataGridView1.Rows.Clear();
            foreach (Merenje m in clan.svaMerenja)
            {
                try
                {
                    this.dataGridView1.Rows.Add(m.datumMerenja,m.visina.ToString(),m.tezina.ToString(),m.brojGodina.ToString(),m.masti.ToString(),m.misici.ToString(),m.BMI.ToString(),m.visceralne.ToString(),m.obim.ToString(),m.brzinaMetabolizma.ToString());
                }
                catch
                {
                    
                }
                int b = dataGridView1.Rows.Count;
                dataGridView1.Rows[b - 1].Tag = m;

            }
        }
        public void popuniClanarine()
        {
            this.dataGridView2.Rows.Clear();
            foreach (Clanarina c in clan.sveClanarine)
            {
                try
                {
                    this.dataGridView2.Rows.Add(c.pocetak,c.kraj,c.clanarina.ToString(),c.placena,c.dug.ToString());
                }
                catch
                {

                }
                int b = dataGridView2.Rows.Count;
                dataGridView2.Rows[b - 1].Tag = c;
            }
        }
        public void popuniInfo()
        {
            labId.Text = clan.sifraKartice.ToString();
            texIme.Text = clan.ime;
            texPrezime.Text = clan.prezime;
            dateRodjenja.Value = clan.datumRodjenja.Date;
            texBrTel.Text = clan.brojTelefona;

            IQuery q = session.CreateQuery("FROM Trening");

            IList<Trening> sviTreninzi = q.List<Trening>();
            int indexOfTrening = 0;
            foreach (Trening c in sviTreninzi)
            {
                this.combTrening.Items.Add(c.imeGrupe);
                if (clan.trening.imeGrupe.Equals(c.imeGrupe))
                    indexOfTrening = combTrening.Items.Count - 1;
            }
            combTrening.SelectedIndex = indexOfTrening;
            session.Flush();
            //textCena.Text = clan.clanarina.ToString();
            //checkPlaceno.Checked = clan.placena;
            //texDug.Text = clan.dug.ToString();
            texNapomena.Text = clan.napomena;
            texIshrana.Text = clan.preporucenaIshrana;
        }

        private void button8_Click(object sender, EventArgs e)
        {
            //dodavanje nove clanarine
            Clanarina c = new Clanarina();
            ClanarinaForm cf = new ClanarinaForm(c, this, session);
            cf.Show();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            //izmena clanarine
            if (dataGridView2.SelectedRows.Count == 0)
            {
                MessageBox.Show("Molimo Vas selektujte neku clanarinu (kliknite skroz levo na strelicu zeljene clanarine)");
                return;
            }
            Clanarina c = (Clanarina)dataGridView2.SelectedRows[0].Tag;
            ClanarinaForm cf = new ClanarinaForm(c, this, session);
            cf.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //Dodavanje novih merenja
            Merenje m = new Merenje();
            MerenjeForm mf = new MerenjeForm(m, this, session);
            mf.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            //izmena merenja
            if (dataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show("Molimo Vas selektujte neko merenje (kliknite skroz levo na strelicu zeljenog merenja)");
                return;
            }
            Merenje m = (Merenje)dataGridView1.SelectedRows[0].Tag;
            MerenjeForm mf = new MerenjeForm(m, this, session);
            mf.Show();
        }
        public bool sacuvajClana()
        {
            try
            {
                session.SaveOrUpdate(clan);
                session.Flush();
                return true;
            }
            catch
            { return false; }
            
        }

        private void button5_Click(object sender, EventArgs e)
        {
            //Brisanje merenja
            if (dataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show("Molimo Vas selektujte neko merenje (kliknite skroz levo na strelicu zeljenog merenja)");
                return;
            }
            DialogResult dialogResult = MessageBox.Show("Jeste li sigurni da izbrisete merenje ?", "", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                Merenje m = (Merenje)dataGridView1.SelectedRows[0].Tag;
                m.clan.svaMerenja.Remove(m);
                session.SaveOrUpdate(clan);
                session.Delete(m);
                session.Flush();
                popuniMerenja();
            }
            else if (dialogResult == DialogResult.No)
            {
                //do something else
            }
           
        }

        private void button6_Click(object sender, EventArgs e)
        {
            //Brisanje clanarine
            if (dataGridView2.SelectedRows.Count == 0)
            {
                MessageBox.Show("Molimo Vas selektujte neku clanarinu (kliknite skroz levo na strelicu zeljene clanarine)");
                return;
            }
            DialogResult dialogResult = MessageBox.Show("Jeste li sigurni da zelite da obrisete CLanarinu ?", "", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                Clanarina c = (Clanarina)dataGridView2.SelectedRows[0].Tag;
                c.clan.sveClanarine.Remove(c);
                session.SaveOrUpdate(clan);
                session.Delete(c);
                session.Flush();
                popuniClanarine();
                form1.refreshPrikazClanova();
            }
            else if (dialogResult == DialogResult.No)
            {
                //do something else
            }
           
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(texIme.Text.Equals("")||texPrezime.Text.Equals("")||texBrTel.Text.Equals(""))
            {
                MessageBox.Show("Molim vas popunite obavezna polja!");
                return;
            }
            clan.sifraKartice=Convert.ToInt32(labId.Text);
            clan.ime = texIme.Text;
            clan.prezime = texPrezime.Text;
            clan.datumRodjenja = dateRodjenja.Value.Date;
            clan.brojTelefona = texBrTel.Text;
            //Dodaj za trening
            IQuery q = session.CreateQuery("FROM Trening");

            IList<Trening> sviTreninzi = q.List<Trening>();
            foreach (Trening c in sviTreninzi)
            {
                if (combTrening.SelectedItem.ToString().Equals(c.imeGrupe))
                {
                    clan.trening = c;
                    break;
                }
                    
            }
            //clan.clanarina = Convert.ToInt32(textCena.Text);
            //clan.placena = checkPlaceno.Checked;
            //clan.dug = Convert.ToInt32(texDug.Text);
            clan.napomena = texNapomena.Text;
            clan.preporucenaIshrana = texIshrana.Text;

            session.SaveOrUpdate(clan.trening);
            session.SaveOrUpdate(clan);
            session.Flush();
            MessageBox.Show("Clan " +clan.ime + " "+clan.prezime+" je uspesno izmenjen ");
            form1.refreshPrikazClanova();
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Jeste li sigurni da izlazite bez izmena ?", "", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                this.Close();
            }
            else if (dialogResult == DialogResult.No)
            {
                //do something else
            }
        }

    }
}
