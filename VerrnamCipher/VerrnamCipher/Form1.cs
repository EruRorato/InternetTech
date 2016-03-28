using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VerrnamCipher
{
    public partial class Form1 : Form
    {
        Cipher cip;
        public Form1()
        {
            InitializeComponent();
            cip = new Cipher();
        }


        private class Cipher
        {
            Dictionary<char, int> alphabet = new Dictionary<char, int>();
            Dictionary<int, char> alphabet_r = new Dictionary<int, char>();
            public Cipher()
            {
                int idx = 0;
                //Add dictionary symbols
                for(int i = 0; i < 2000; i++)
                {
                    alphabet.Add((char)i, idx);
                    alphabet_r.Add(idx, (char)i);
                    idx++;
                }
                
            }

            public string MakeKey(int Len)
            {
                var sb = new StringBuilder();
                Random rand = new Random();
                for (int i = 0; i < Len; i++)
                {
                    int rd = rand.Next(alphabet.Count());
                    string str = alphabet.ElementAt(rd).ToString();
                    sb.Append(str[1]);
                }
                return sb.ToString();
            }
            public string Crypt(string key,string text)
            {
                char[] CryptKey = key.ToCharArray();
                char[] txt = text.ToCharArray();
                var sb = new StringBuilder();
                for(int j=0;j<txt.Length;j++)
                {
                    sb.Append((char)((uint)txt[j] ^ (uint)key[j % key.Length]));
                }
                return sb.ToString(); 
            }
          
        }

        
        private void button3_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Length > 0 )
            {
                textBox1.Text = cip.Crypt(textBox3.Text.ToString(), textBox1.Text.ToString());
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox3.Text.Length > 0 && textBox3.Text.Length == textBox1.Text.Length)
            {
                textBox1.Text = cip.Crypt(textBox3.Text.ToString(), textBox1.Text.ToString());
            }
            else
            {
                if (textBox3.Text.Length == 0) { MessageBox.Show("Generate key first!"); }
                else { /*invalid key*/ }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //get key
            string inp = textBox1.Text.ToString();
            string key = cip.MakeKey(inp.Length);
            textBox3.Text = key;
        }


    }
}
