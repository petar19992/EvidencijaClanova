using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Security.Cryptography;

namespace SQLiteRepository2008
{
    public partial class Sifra : Form
    {
        public Sifra()
        {
            InitializeComponent();
            button1.DialogResult = System.Windows.Forms.DialogResult.OK;
            //button2.DialogResult = System.Windows.Forms.DialogResult.Cancel;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            String sifra = textBox1.Text;
            proveriSifru(sifra);
        }

        public void proveriSifru(String sifra)
        {
            HashAlgorithm sha = new SHA1CryptoServiceProvider();
            byte[] result = sha.ComputeHash(GetBytes(sifra));
            //ByteArrayToFile("pass.txt", result);
            //MessageBox.Show(GetString(result));
            byte[] bytes = File.ReadAllBytes("pass.txt");
            if (result.SequenceEqual(bytes))
            {
                textBox1.Visible = false;
                button2.Visible = false;
                label2.Visible = true;
                label1.Visible = false;
                button1.Visible = true;
            }
            else
            {
                MessageBox.Show("Pogresna sifra, pokusajte ponovo");
            }
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

        public bool ByteArrayToFile(string _FileName, byte[] _ByteArray)
        {
            try
            {
                System.IO.FileStream _FileStream =
                   new System.IO.FileStream(_FileName, System.IO.FileMode.Create,
                                            System.IO.FileAccess.Write);
                _FileStream.Write(_ByteArray, 0, _ByteArray.Length);
                _FileStream.Close();

                return true;
            }
            catch (Exception _Exception)
            {
                Console.WriteLine("Exception caught in process: {0}",
                                  _Exception.ToString());
            }
            return false;
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                proveriSifru(textBox1.Text);
            }
        }
    }
}
