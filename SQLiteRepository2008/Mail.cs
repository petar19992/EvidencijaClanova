using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SQLiteRepository2008
{
    public partial class Mail : Form
    {
        public Mail()
        {
            InitializeComponent();
            button1.DialogResult = System.Windows.Forms.DialogResult.OK;
        }

        public String email
        {
            get { return textBox1.Text; }
            set
            {
                textBox1.Text = value;
            }
        }

    }
}
