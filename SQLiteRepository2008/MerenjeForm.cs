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
using System.Globalization;

namespace SQLiteRepository2008
{
    public partial class MerenjeForm : Form
    {
        Izmeni izmeni;
        ISession session;
        Merenje merenje;

        public MerenjeForm()
        {
            InitializeComponent();
        }
        public MerenjeForm(Merenje m, Izmeni i, ISession s)
        {
            InitializeComponent();
            merenje = m;
            izmeni = i;
            session = s;
            prikaziMerenja();
        }
        public void prikaziMerenja()
        {
            try
            { 
                textBox1.Text = merenje.visina.ToString();
                textBox2.Text = merenje.tezina.ToString();
                textBox3.Text = merenje.brojGodina.ToString();
                textBox4.Text = merenje.masti.ToString();
                textBox5.Text = merenje.misici.ToString();
                textBox6.Text = merenje.BMI.ToString();
                textBox7.Text = merenje.visceralne.ToString();
                textBox8.Text = merenje.obim.ToString();
                textBox9.Text = merenje.brzinaMetabolizma.ToString();
                dateTimePicker1.Value = merenje.datumMerenja;
            }
            catch { }   
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                merenje.visina = float.Parse(textBox1.Text, CultureInfo.InvariantCulture.NumberFormat);
                merenje.tezina = float.Parse(textBox2.Text, CultureInfo.InvariantCulture.NumberFormat);
                merenje.brojGodina = float.Parse(textBox3.Text, CultureInfo.InvariantCulture.NumberFormat);
                merenje.masti = float.Parse(textBox4.Text, CultureInfo.InvariantCulture.NumberFormat);
                merenje.misici = float.Parse(textBox5.Text, CultureInfo.InvariantCulture.NumberFormat);
                merenje.BMI = float.Parse(textBox6.Text, CultureInfo.InvariantCulture.NumberFormat);
                merenje.visceralne = float.Parse(textBox7.Text, CultureInfo.InvariantCulture.NumberFormat);
                merenje.obim = float.Parse(textBox8.Text, CultureInfo.InvariantCulture.NumberFormat);
                merenje.brzinaMetabolizma = float.Parse(textBox9.Text, CultureInfo.InvariantCulture.NumberFormat);
                merenje.datumMerenja = dateTimePicker1.Value;

                if (merenje.clan == null)
                {
                    izmeni.clan.dodajMerenje(merenje);
                }
                session.SaveOrUpdate(merenje);
                izmeni.sacuvajClana();
                session.Flush();
                izmeni.popuniMerenja();
                this.Close();
            }
            catch
            {
                MessageBox.Show("Proverite da li ste uneli sva obavezna polja pravilno.");
            }
            
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
