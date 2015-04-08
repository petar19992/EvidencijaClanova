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
using EvidencijaClanova;

namespace SQLiteRepository2008
{
    public partial class Dodaj : Form
    {
        Form1 otac;
        private ISession session;
        IList<Trening> sviTreninzi;
        public Dodaj()
        {
            InitializeComponent();
            session = DataLayer.GetSession();
            IQuery q = session.CreateQuery("FROM Trening");

            sviTreninzi = q.List<Trening>();
            foreach (Trening c in sviTreninzi)
            {
                this.combTrening.Items.Add(c.imeGrupe);
            }
            combTrening.SelectedIndex = 0;
            IQuery v = session.CreateQuery("SELECT max(sifraKartice) FROM Clan");
            int max = v.List<Int32>()[0] + 1;
            labId.Text = max.ToString();
            session.Flush();
        }

        public Dodaj(Form1 forma)
        {
            otac = forma;
            InitializeComponent();
            session = DataLayer.GetSession();

            dateClanarina.Value = DateTime.Today.AddMonths(1);

            IQuery q = session.CreateQuery("FROM Trening");

            sviTreninzi = q.List<Trening>();
            foreach (Trening c in sviTreninzi)
            {
                this.combTrening.Items.Add(c.imeGrupe);
            }
            int[] prvihDeset = nadjiDesetSlobodnih();
            for (int i=0;i<10;i++)
            {
                label15.Text += " " + prvihDeset[i]+ ", ";
            }
            label15.Text += " a najveca vrednost dodate sifre korisnika je " + prvihDeset[10];
            try
            {
                combTrening.SelectedIndex = 0;
            }
                catch
            {
                MessageBox.Show("Trenutno nemate ni jedan trening u bazi, molimo vas da prvo dodate barem jedan trening");
                this.Close();
            }

            session.Flush();
        }

        public int[] nadjiDesetSlobodnih()
        {
            IQuery v = session.CreateQuery("SELECT sifraKartice FROM Clan");
            IList<int> sifre;
            try
            {
                sifre = v.List<int>();
            }
            catch 
            {
                sifre = new List<Int32>();
            }
            int poc = 1;
            int[] deset=new int[11];
            int counter = 0;
            while (counter < 10)
            {
                if (sifre.IndexOf(poc) == -1)
                {
                    deset[counter++] = poc;
                }
                poc++;
            }
            try { deset[10] = sifre.Max(); }
            catch { deset[10] = 0; }
            
            return deset;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (texIme.Text.Equals("") || texPrezime.Text.Equals("") || texBrTel.Text.Equals("") || texCena.Text.Equals("") || texDug.Text.Equals("")||labId.Text.Equals(""))
            {
                MessageBox.Show("Morate uneti obavezna polja.", "Greska pri unosu podataka");
                labBrTelG.Visible = true;
                LabImeG.Visible = true;
                labPrezimeG.Visible = true;
                labBrTelG.Visible = true;
                labCenaG.Visible = true;
                labDugG.Visible = true;

            }

            else
            {

                Clan clan = new Clan();
                clan.sifraKartice = Convert.ToInt32(labId.Text);

                //Deo provere da li sifra postoji
                IQuery v = session.CreateQuery("SELECT sifraKartice FROM Clan");
                IList<int> sifre;
                try
                {
                    sifre = v.List<int>();
                }
                catch
                {
                    sifre = new List<Int32>();
                }
                if (sifre.IndexOf(clan.sifraKartice) != -1)
                {
                     DialogResult dialogResult = MessageBox.Show("Clan sa ovom sifrom kartice vec postoji, jeste li sigurni da zelite da ga dodate ?", "", MessageBoxButtons.YesNo);
                     if (dialogResult == DialogResult.Yes)
                     {
                         
                     }
                     else
                         if (dialogResult == DialogResult.No)
                             return;
                }
                ///////////////////////////////

                clan.ime = texIme.Text;
                clan.prezime = texPrezime.Text;
                clan.datumRodjenja = dateRodjenja.Value;
                clan.datumUpisa = datePocetak.Value;
                clan.brojTelefona = texBrTel.Text;
                if (texNapomena.Text.Equals(""))
                {
                    clan.napomena = " / ";
                }
                else
                    clan.napomena = texNapomena.Text;
                if (texIshrana.Text.Equals(""))
                {
                    clan.preporucenaIshrana = " / ";
                }
                else
                    clan.preporucenaIshrana = texIshrana.Text;
                clan.clanarina = Convert.ToInt32(texCena.Text);    
                clan.placena = checkPlaceno.Checked;
                Clanarina clanarina = new Clanarina();

                clanarina.clanarina = Convert.ToInt32(texCena.Text);
                clanarina.pocetak = datePocetak.Value;
                clanarina.kraj = dateClanarina.Value;
                clanarina.placena = checkPlaceno.Checked;
                clanarina.dug = Convert.ToInt32(texDug.Text);
                clan.dodajClanarinu(clanarina);
                clan.dug = Convert.ToInt32(texDug.Text);
                //session.SaveOrUpdate(clanarina);
                foreach (Trening c in sviTreninzi)
                {
                    if (c.imeGrupe.Equals(combTrening.SelectedItem))
                    {
                        c.dodajClana(clan);
                        session.SaveOrUpdate(c);
                    }
                }
                try 
                {
                    session.Save(clan);
                    session.Flush();
                    string s = texIme.Text + " " + texPrezime.Text;
                    this.Close();
                    MessageBox.Show("Clan " + s + " je uspesno dodat." + " Sifra clana je: " + clan.sifraKartice);
                }
                catch 
                {
                    MessageBox.Show("Greska prilikom unosa ( da li ste sigurni da clan sa tom sifrom kartice vec nije u bazi ?)");
                }
                
            }
            //otac.prikaziSveClanove();
            otac.prikaziClanoveIzabranihTreninga();
        }

        private void texCena_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
        (e.KeyChar != '.'))
            {
                e.Handled = true;
                MessageBox.Show("Cena mora biti irazena numericki.", "Greska pri unosu podataka");
            }


        }

        private void label17_Click(object sender, EventArgs e)
        {

        }

        private void label18_Click(object sender, EventArgs e)
        {

        }

        private void label16_Click(object sender, EventArgs e)
        {

        }

        private void label15_Click(object sender, EventArgs e)
        {

        }

        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void texDug_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
        (e.KeyChar != '.'))
            {
                e.Handled = true;
                MessageBox.Show("Dug mora biti irazen numericki.", "Greska pri unosu podataka");
            }
        }
    }
}
