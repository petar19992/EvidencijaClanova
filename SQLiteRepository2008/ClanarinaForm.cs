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
    public partial class ClanarinaForm : Form
    {
        Clanarina clanarina;
        Izmeni izmeni;
        ISession session;
        public ClanarinaForm()
        {
            InitializeComponent();
        }
        public ClanarinaForm(Clanarina c,Izmeni i,ISession s)
        {
            InitializeComponent();
            clanarina = c;
            izmeni = i;
            session = s;
            popuniPolja();
        }
        public void popuniPolja()
        {
            try 
            {
                dateTimePicker1.Value=clanarina.pocetak.Date;
                dateTimePicker2.Value=clanarina.kraj.Date;
                textBox1.Text = clanarina.clanarina.ToString();
                textBox2.Text = clanarina.dug.ToString();
                checkBox1.Checked = clanarina.placena;
            }
            catch
            {
                
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {

            try
            {
                clanarina.pocetak = dateTimePicker1.Value.Date;
                clanarina.kraj = dateTimePicker2.Value.Date;
                if (clanarina.clanarina.Equals(""))
                    clanarina.clanarina = 0;
                else
                clanarina.clanarina = Convert.ToInt32(textBox1.Text);

                if (clanarina.dug.Equals(""))
                    clanarina.dug = 0;
                else
                    clanarina.dug = Convert.ToInt32(textBox2.Text);
                clanarina.placena = checkBox1.Checked;


                if (clanarina.clan == null)
                {
                    izmeni.clan.dodajClanarinu(clanarina);
                    izmeni.clan.clanarina = clanarina.clanarina;
                    izmeni.clan.placena = clanarina.placena;
                    izmeni.clan.dug = clanarina.dug;
                }

                session.SaveOrUpdate(clanarina);
                izmeni.sacuvajClana();
                session.Flush();
                izmeni.popuniClanarine();
                izmeni.form1.refreshPrikazClanova();
                this.Close();
            }
            catch
            {
                MessageBox.Show("Proverite da li ste uneli sva obavezna polja korektno");
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
