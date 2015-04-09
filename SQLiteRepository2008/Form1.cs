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

namespace EvidencijaClanova
{
    public partial class Form1 : Form
    {
        private ISession session;
        public Form1()
        {
            InitializeComponent();
            
                
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            session = DataLayer.GetSession();
            prikaziTreninge();
            comboSearch.DropDownStyle = ComboBoxStyle.DropDownList;
            comboSearch.SelectedIndex = 0;


            Sifra dlg = new Sifra();
            DialogResult dlgresult = dlg.ShowDialog();

            if (DialogResult.OK == dlgresult)
            {

            }
            else
                if (DialogResult.Abort == dlgresult || DialogResult.Cancel == dlgresult)
                    this.Close();

            //sifrirajSifru("1");
            
        }

        public void sifrirajSifru(String sifra)
        {
            HashAlgorithm sha = new SHA1CryptoServiceProvider();
            byte[] result = sha.ComputeHash(GetBytes(sifra));
            System.IO.File.WriteAllBytes("pass.txt", result);
        }
        private void dgmDodaj_Click(object sender, EventArgs e)
        {
            Dodaj Dodaj = new Dodaj(this);
            try { Dodaj.Show(); }
            catch { }
            
        }
        public void prikaziSveClanove()
        {
            this.dataGridView1.Rows.Clear();
            IQuery q = session.CreateQuery("FROM Clan");
            IList<Clan> sviClanovi = q.List<Clan>();
            foreach (Clan c in sviClanovi)
            {
                prikaziPodatkeZaClana(c);
            }
            session.Flush();
        }

        public void prikaziPodatkeZaClana(Clan c)
        {
            DateTime maxDate = new DateTime(2000, 1, 1);
            Clanarina najnovija = new Clanarina();
            foreach (Clanarina d in c.sveClanarine)
            {
                if (maxDate < d.kraj)
                {
                    maxDate = d.kraj.Date;
                    najnovija = d;
                }
            }
            String dat = "";
            if (maxDate == new DateTime(2000, 1, 1))
            {
                dat = "Nema podatka";
                this.dataGridView1.Rows.Add(c.sifraKartice.ToString(), c.ime, c.prezime, c.brojTelefona, c.datumRodjenja.Date.ToShortDateString(), c.trening.imeGrupe, najnovija.clanarina, najnovija.placena, najnovija.dug, dat);
                int b = dataGridView1.Rows.Count;
                dataGridView1.Rows[b - 1].Tag = c;
                if (Convert.ToInt32(c.dug) > 0)
                    dataGridView1.Rows[b - 1].Cells["dug"].Style.BackColor = Color.Red;
            }
            else
            {
                this.dataGridView1.Rows.Add(c.sifraKartice.ToString(), c.ime, c.prezime, c.brojTelefona, c.datumRodjenja.Date.ToShortDateString(), c.trening.imeGrupe, najnovija.clanarina, najnovija.placena, najnovija.dug, maxDate);
                int b = dataGridView1.Rows.Count;
                dataGridView1.Rows[b - 1].Tag = c;
                if (Convert.ToInt32(najnovija.dug) > 0)
                    dataGridView1.Rows[b - 1].Cells["dug"].Style.BackColor = Color.Red;
                if (maxDate < DateTime.Today)
                {
                    dataGridView1.Rows[b - 1].Cells["Vazi_do"].Style.BackColor = Color.Blue;
                }
            }   
        }

        public void refreshPrikazClanova()
        {
            IList<Clan> clanovi = new List<Clan>();
            foreach(DataGridViewRow r in dataGridView1.Rows)
            {
                clanovi.Add((Clan)r.Tag);
            }
            dataGridView1.Rows.Clear();
            foreach (Clan c in clanovi)
            {
                prikaziPodatkeZaClana(c);
            }
        }
        public void pretraga()
        {
            dataGridView1.Rows.Clear();

            if (comboSearch.SelectedIndex == 0) // search po Id-u
            {
                Boolean ispravno = true;
                String text = texSearch.Text;
                char[] tekstNiz = text.ToCharArray(0, text.Length);
                for (int i = 0; i < text.Length; i++)
                {
                    if (tekstNiz[i] < 48 || tekstNiz[i] > 57)
                        ispravno = false;
                }
                if (!ispravno)//mora da bude broj
                {
                    MessageBox.Show("Broj clanske kartice mora da bude izrazen numericki.", "Greska pri pretrazi.");
                }
                else
                {
                    IQuery q = session.CreateQuery("FROM Clan WHERE sifraKartice = " + texSearch.Text);
                    IList<Clan> sviClanovi = q.List<Clan>();
                    foreach (Clan c in sviClanovi)
                    {
                        ///////////////////////////////////// 9.4
                        DateTime maxDate = new DateTime(2000, 1, 1);
                        Clanarina najnovija = new Clanarina();
                        foreach (Clanarina d in c.sveClanarine)
                        {
                            if (maxDate < d.kraj)
                            {
                                maxDate = d.kraj.Date;
                                najnovija = d;
                            }
                        }
                        String dat = "";
                        if (maxDate == new DateTime(2000, 1, 1))
                        {
                            dat = "Nema podatka";
                            this.dataGridView1.Rows.Add(c.sifraKartice.ToString(), c.ime, c.prezime, c.brojTelefona, c.datumRodjenja.Date.ToShortDateString(), c.trening.imeGrupe, najnovija.clanarina, najnovija.placena, najnovija.dug, dat);
                            int b = dataGridView1.Rows.Count;
                            dataGridView1.Rows[b - 1].Tag = c;
                            if (Convert.ToInt32(c.dug) > 0)
                                dataGridView1.Rows[b - 1].Cells["dug"].Style.BackColor = Color.Red;
                        }
                        else
                        {
                            this.dataGridView1.Rows.Add(c.sifraKartice.ToString(), c.ime, c.prezime, c.brojTelefona, c.datumRodjenja.Date.ToShortDateString(), c.trening.imeGrupe, najnovija.clanarina, najnovija.placena, najnovija.dug, maxDate);
                            int b = dataGridView1.Rows.Count;
                            dataGridView1.Rows[b - 1].Tag = c;
                            if (Convert.ToInt32(najnovija.dug) > 0)
                                dataGridView1.Rows[b - 1].Cells["dug"].Style.BackColor = Color.Red;
                            if (maxDate < DateTime.Today)
                            {
                                dataGridView1.Rows[b - 1].Cells["Vazi_do"].Style.BackColor = Color.Blue;
                            }
                        }   
                        //////////////////////////////
                       /* this.dataGridView1.Rows.Add(c.sifraKartice.ToString(), c.ime, c.prezime, c.brojTelefona, c.datumRodjenja.Date.ToShortDateString(), c.trening.imeGrupe, c.clanarina, c.placena);
                        int b = dataGridView1.Rows.Count;
                        dataGridView1.Rows[b - 1].Tag = c;*/
                    }
                    //session.Flush();
                }
            }
            else if (comboSearch.SelectedIndex == 1)//search po Imenu i Prezimenu
            {
                string[] odvojeno = new String[3];


                string imePrezime = texSearch.Text;
                odvojeno = imePrezime.Split(' ');
                if (odvojeno.Count() == 1) /// ovde probas i ime i prezime
                {
                    IQuery v = session.CreateQuery("FROM Clan WHERE ime like '%" + texSearch.Text + "%' OR prezime like '%" + texSearch.Text + "%'");
                    IList<Clan> sviClanovi = v.List<Clan>();
                    foreach (Clan c in sviClanovi)
                    {

                        ///////////////////////////////9.4
                        DateTime maxDate = new DateTime(2000, 1, 1);
                        Clanarina najnovija = new Clanarina();
                        foreach (Clanarina d in c.sveClanarine)
                        {
                            if (maxDate < d.kraj)
                            {
                                maxDate = d.kraj.Date;
                                najnovija = d;
                            }
                        }
                        String dat = "";
                        if (maxDate == new DateTime(2000, 1, 1))
                        {
                            dat = "Nema podatka";
                            this.dataGridView1.Rows.Add(c.sifraKartice.ToString(), c.ime, c.prezime, c.brojTelefona, c.datumRodjenja.Date.ToShortDateString(), c.trening.imeGrupe, najnovija.clanarina, najnovija.placena, najnovija.dug, dat);
                            int b = dataGridView1.Rows.Count;
                            dataGridView1.Rows[b - 1].Tag = c;
                            if (Convert.ToInt32(c.dug) > 0)
                                dataGridView1.Rows[b - 1].Cells["dug"].Style.BackColor = Color.Red;
                        }
                        else
                        {
                            this.dataGridView1.Rows.Add(c.sifraKartice.ToString(), c.ime, c.prezime, c.brojTelefona, c.datumRodjenja.Date.ToShortDateString(), c.trening.imeGrupe, najnovija.clanarina, najnovija.placena, najnovija.dug, maxDate);
                            int b = dataGridView1.Rows.Count;
                            dataGridView1.Rows[b - 1].Tag = c;
                            if (Convert.ToInt32(najnovija.dug) > 0)
                                dataGridView1.Rows[b - 1].Cells["dug"].Style.BackColor = Color.Red;
                            if (maxDate < DateTime.Today)
                            {
                                dataGridView1.Rows[b - 1].Cells["Vazi_do"].Style.BackColor = Color.Blue;
                            }
                        }   
                        ///////////////////////////////////////////////////////


                       /* this.dataGridView1.Rows.Add(c.sifraKartice.ToString(), c.ime, c.prezime, c.brojTelefona, c.datumRodjenja.Date.ToShortDateString(), c.trening.imeGrupe, c.clanarina, c.placena);
                        int b = dataGridView1.Rows.Count;
                        dataGridView1.Rows[b - 1].Tag = c;*/
                    }
                    //session.Flush();
                }
                else if (odvojeno.Count() == 2) // ovde odvojeno ime i prezime ali duplo
                {
                    IQuery v = session.CreateQuery("FROM Clan WHERE ( ime like '%" + odvojeno[0] + "%' OR ime like '%" + odvojeno[1] + "%')" + "AND ( prezime like '%" + odvojeno[0] + "%' OR prezime like '%" + odvojeno[1] + "%')");
                    IList<Clan> sviClanovi = v.List<Clan>();
                    foreach (Clan c in sviClanovi)
                    {
                        DateTime maxDate = new DateTime(2000, 1, 1);
                        Clanarina najnovija = new Clanarina();
                        foreach (Clanarina d in c.sveClanarine)
                        {
                            if (maxDate < d.kraj)
                            {
                                maxDate = d.kraj.Date;
                                najnovija = d;
                            }
                        }
                        String dat = "";
                        if (maxDate == new DateTime(2000, 1, 1))
                        {
                            dat = "Nema podatka";
                            this.dataGridView1.Rows.Add(c.sifraKartice.ToString(), c.ime, c.prezime, c.brojTelefona, c.datumRodjenja.Date.ToShortDateString(), c.trening.imeGrupe, najnovija.clanarina, najnovija.placena, najnovija.dug, dat);
                            int b = dataGridView1.Rows.Count;
                            dataGridView1.Rows[b - 1].Tag = c;
                            if (Convert.ToInt32(c.dug) > 0)
                                dataGridView1.Rows[b - 1].Cells["dug"].Style.BackColor = Color.Red;
                        }
                        else
                        {
                            this.dataGridView1.Rows.Add(c.sifraKartice.ToString(), c.ime, c.prezime, c.brojTelefona, c.datumRodjenja.Date.ToShortDateString(), c.trening.imeGrupe, najnovija.clanarina, najnovija.placena, najnovija.dug, maxDate);
                            int b = dataGridView1.Rows.Count;
                            dataGridView1.Rows[b - 1].Tag = c;
                            if (Convert.ToInt32(najnovija.dug) > 0)
                                dataGridView1.Rows[b - 1].Cells["dug"].Style.BackColor = Color.Red;
                            if (maxDate < DateTime.Today)
                            {
                                dataGridView1.Rows[b - 1].Cells["Vazi_do"].Style.BackColor = Color.Blue;
                            }
                        }   



                        /*
                        this.dataGridView1.Rows.Add(c.sifraKartice.ToString(), c.ime, c.prezime, c.brojTelefona, c.datumRodjenja.Date.ToShortDateString(), c.trening.imeGrupe, c.clanarina, c.placena);
                        int b = dataGridView1.Rows.Count;
                        dataGridView1.Rows[b - 1].Tag = c;*/
                    }
                    //session.Flush();
                }
                else // greska
                {
                    MessageBox.Show("Pogrešan unos imena i prezimena", "Greška u pretrazi.");
                }

            }
        }
        public void dodajClana()
        {
            Clan clan = new Clan();
            //clan.sifraKartice = 1;
            clan.ime = "Petar";
            clan.prezime = "Ljubic";
            clan.datumRodjenja = DateTime.Today;
            clan.datumUpisa = DateTime.Today;
            clan.brojTelefona = "+123456";
            clan.preporucenaIshrana = "Jedi sve";
            clan.clanarina = 1400;
            clan.placena = true;
            clan.dug = 0;
            clan.napomena = "nema";
            Merenje merenje = new Merenje();
            merenje.visceralne = 7;
            clan.dodajMerenje(merenje);
            Clanarina clanarina = new Clanarina();
            clanarina.clanarina = 1400;
            clan.dodajClanarinu(clanarina);
            Trening trening = new Trening();
            trening.imeGrupe = "RushFit";
            trening.termin = "uvece neki";
            trening.clanovi.Add(clan);
            clan.trening = trening;
            //session.Save(clan.trening);
            session.Save(clanarina);
            session.Save(merenje);
            session.Save(clan);
            session.Save(trening);
            session.Flush();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show("Molimo Vas selektujte nekog člana (kliknite skroz levo na strelicu željenog člana)");
                return;
            }
            Clan c = (Clan)dataGridView1.SelectedRows[0].Tag;
            Izmeni izmeni = new Izmeni(c,this, session);
            izmeni.Show();
        }

        private void buttonSearch_Click(object sender, EventArgs e)
        {

            if (texSearch.Text.Equals(""))
            {
                prikaziClanoveIzabranihTreninga();
            }
            else
            {
                pretraga();
            }
        }

        private void texSearch_KeyPress(object sender, KeyPressEventArgs e)
        {
            
            if(!texSearch.Text.Equals(""))
            {
                if(e.KeyChar == (char)13)
                    pretraga();
                else 
                    if(e.KeyChar == (char)8 && texSearch.Text.Length==1 )
                        prikaziClanoveIzabranihTreninga();
            }
           
            else
            {
                prikaziClanoveIzabranihTreninga();
            }
           // pretraga();
           
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show("Molimo Vas selektujte nekog clana (kliknite skroz levo na strelicu zeljenog clana)");
                return;
            }
            DialogResult dialogResult = MessageBox.Show("Jeste li sigurni da obrisete ovog clana ?", "", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                Clan c = (Clan)dataGridView1.SelectedRows[0].Tag;
                foreach (Clanarina cl in c.sveClanarine)
                {

                    session.Delete(cl);
                }
                //c.sveClanarine.Remove(cl);
                //session.SaveOrUpdate(c);
                foreach (Merenje m in c.svaMerenja)
                {
                    //m.clan.svaMerenja.Remove(m);
                    //session.SaveOrUpdate(c);
                    session.Delete(m);
                }
                c.trening.clanovi.Remove(c);
                session.SaveOrUpdate(c.trening);
                session.Delete(c);
                session.Flush();
                prikaziClanoveIzabranihTreninga();
            }
            else if (dialogResult == DialogResult.No)
            {
                //do something else
            }
            
        }
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

            dataGridView1.Rows.Clear();
            ToolStripMenuItem i = (ToolStripMenuItem)sender;
            if (i.Checked == true)
                i.Checked = false;
            else
                i.Checked = true;
            foreach (ToolStripMenuItem item in treninziToolStripMenuItem.DropDownItems)
            {
                if (item.Checked == true && item.Tag!=null)
                {
                    prikaziCLanoveZaTrening((Trening)item.Tag);
                }
            }
        }

        public void prikaziClanoveIzabranihTreninga()
        {
            dataGridView1.Rows.Clear();
            foreach (ToolStripMenuItem item in treninziToolStripMenuItem.DropDownItems)
            {
                if (item.Checked == true && item.Tag != null)
                {
                    prikaziCLanoveZaTrening((Trening)item.Tag);
                }
            }
        }
        public void prikaziSveTreninge(object sender, EventArgs e)
        {
            ToolStripMenuItem prvi = (ToolStripMenuItem)sender;
            prvi.Checked = !prvi.Checked;
            bool prikaz=prvi.Checked;
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
                dataGridView1.Rows.Clear();
            }
            
        }
        public void prikaziCLanoveZaTrening(Trening t)
        {
            IQuery q = session.CreateQuery("FROM Clan where trening_id='"+t.imeGrupe+"'");
            IList<Clan> sviClanovi = q.List<Clan>();
            foreach (Clan c in sviClanovi)
            {
                prikaziPodatkeZaClana(c);
                //this.dataGridView1.Rows.Add(c.sifraKartice.ToString(), c.ime, c.prezime, c.brojTelefona, c.datumRodjenja.Date.ToShortDateString(), c.trening.imeGrupe, c.clanarina, c.placena, c.dug);

                //int b = dataGridView1.Rows.Count;
                //dataGridView1.Rows[b - 1].Tag = c;
                //if (Convert.ToInt32(c.dug) > 0)
                //    dataGridView1.Rows[b - 1].Cells["dug"].Style.BackColor = Color.Red;
            }
        }

        private void dodajToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Trening t = new Trening();
            TreningForma trening = new TreningForma(this,session,t);
            trening.Show();
        }

        

        private void finansijeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Finansije finansije = new Finansije();
            finansije.Show();
        }

        private void posaljiPutemMailaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Mail m = new Mail();
            if (DialogResult.OK == m.ShowDialog())
            {
                MailMessage mail = new MailMessage();
                SmtpClient SmtpServer = new SmtpClient("smtp.gmail.com");
                mail.From = new MailAddress("petarprokiller@gmail.com");
                mail.To.Add(m.email);
                mail.Subject = "Baza podataka za evidenciju clanova dana: " + DateTime.Today.ToShortDateString();
                mail.Body = "";

                System.Net.Mail.Attachment attachment;
                attachment = new System.Net.Mail.Attachment("EvidencijaClanova.db");
                mail.Attachments.Add(attachment);

                SmtpServer.Port = 587;
                SmtpServer.Credentials = new System.Net.NetworkCredential("petarprokiller@gmail.com", "fulcrummig");
                SmtpServer.EnableSsl = true;
                try
                {
                    SmtpServer.Send(mail);
                    MessageBox.Show("Mail je poslat !");
                }
                catch
                {
                    MessageBox.Show("Mail nije poslat, proverite konekciju, odredisni mail, ili kontaktirajte servisera programa.");
                }
            }

           
        }

        private void izveziNaDiskToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();

            saveFileDialog1.FileName = "EvidecnijaClanova.db";
            // set filters - this can be done in properties as well
            saveFileDialog1.Filter = "DataBase file (*.db)|*.db";
            //saveFileDialog1.InitialDirectory = "D:\\";
            //saveFileDialog1.ShowDialog();
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                File.Copy("EvidencijaClanova.db", saveFileDialog1.FileName);
            }
        }

        private void aboutUsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AboutBox1 ab = new AboutBox1();
            ab.Show();
        }

        private void promeniSifruToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PromenaSifre ps = new PromenaSifre();
            ps.Show();
        }

        static byte[] GetBytes(string str)
        {
            byte[] bytes = new byte[str.Length * sizeof(char)];
            System.Buffer.BlockCopy(str.ToCharArray(), 0, bytes, 0, bytes.Length);
            return bytes;
        }
        static string GetString(byte[] bytes)
        {
            char[] chars = new char[bytes.Length / sizeof(char)];
            System.Buffer.BlockCopy(bytes, 0, chars, 0, bytes.Length);
            return new string(chars);
        }

        private void izmeniIliObrisiTreningToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ListaTreninga lt = new ListaTreninga(this, session);
            lt.Show();
        }
    }
}
