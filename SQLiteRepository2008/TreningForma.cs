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
    public partial class TreningForma : Form
    {
        Form1 form;
        private ISession session;
        Trening trening;
        ListaTreninga listaTreninga;
        public TreningForma()
        {
            session = DataLayer.GetSession();
            InitializeComponent();
        }
        public TreningForma(Form1 form,ISession s,Trening t)
        {
            InitializeComponent();
            this.form = form;
            session = s;
            trening = t;
        }
        public TreningForma(Form1 form, ISession s, Trening t,ListaTreninga lt)
        {
            InitializeComponent();
            this.form = form;
            session = s;
            trening = t;
            listaTreninga = lt;
            dodajInformacije();
        }

        public void dodajInformacije()
        {
            try 
            {
                texImeGrupe.Text = trening.imeGrupe;
                texImeGrupe.Enabled = false;
                texTermin.Text = trening.termin;
            }
            catch { }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                trening.imeGrupe = texImeGrupe.Text;
                trening.termin = texTermin.Text;
                session.SaveOrUpdate(trening);
                session.Flush();
                string s = texImeGrupe.Text;
                form.prikaziTreninge();
                this.Close();
                MessageBox.Show("Trening " + s + " je uspesno obradjen.");
                listaTreninga.prikaziTreninge();
            }
            catch { }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

      
    }
}
