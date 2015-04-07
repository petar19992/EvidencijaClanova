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
    public partial class PromenaSifre : Form
    {
        public PromenaSifre()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!proveriSifru(textBox1.Text))
            {
                MessageBox.Show("Stara sifra nevalidna");
                return;
            }
            if (!textBox3.Text.Equals(textBox4.Text))
            {
                MessageBox.Show("Nove sifre se ne poklapaju");
                return;
            }
            System.IO.File.WriteAllBytes("pass.txt", sifrirajSifru(textBox3.Text));
            MessageBox.Show("Sifra promenjena");
            this.Close();
        }
        public byte[] sifrirajSifru(String sifra)
        {
            HashAlgorithm sha = new SHA1CryptoServiceProvider();
            return sha.ComputeHash(GetBytes(sifra));
        }
        public bool proveriSifru(String sifra)
        {
            HashAlgorithm sha = new SHA1CryptoServiceProvider();
            byte[] result = sha.ComputeHash(GetBytes(sifra));
            //ByteArrayToFile("pass.txt", result);
            //MessageBox.Show(GetString(result));
            byte[] bytes = File.ReadAllBytes("pass.txt");
            if (result.SequenceEqual(bytes))
            {
                return true;
            }
            else
            {
                MessageBox.Show("Pogresna stara sifra, pokusajte ponovo");
                return false;
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
    }
}
