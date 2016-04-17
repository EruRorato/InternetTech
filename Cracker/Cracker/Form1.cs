using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cracker
{
    public partial class Form1 : Form
    {
        public string w1, w2, w3;
        public Form1()
        {
            w1 = w2 = w3 = "";
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //part 1. найти все слова по маске "цтц"
            int counter = 0;
            string line="";
            string tmp="";
            System.IO.StringReader file = new System.IO.StringReader(Properties.Resources.Dictionary);
            List<string> strList = new List<string>();
            while ((line = file.ReadLine()) != null)
            {
                tmp =  line.Trim();
                bool isOk = false;
                if (tmp.Length == 3)
                {
                    if (tmp[0] == tmp[2])
                    {
                        isOk = true;
                    }
                }
                if (isOk)
                {
                    textBox1.AppendText(tmp + "\r\n");
                    strList.Add(tmp);
                    counter++;
                }
            }
            file.Close();
            label1.Text = "найдено: " + counter;

            //part 2 поиск по маске фблржтьц  "-----т-ц". проверить regexp чтобы не было символов повторных
            foreach (var str in strList)
            {
                string tmp2 = "";
                string toTxt = str+" - ";
                string toTxt2 = str + " - ";
                
                int countr = 0;
                file = new System.IO.StringReader(Properties.Resources.Dictionary);
                while ((line = file.ReadLine()) != null)
                {
                    tmp2 = line.Trim();
                    if (tmp2.Length == 8)
                    {
                        if (tmp2[7] == str[0] && tmp2[5] == str[1]) //маска цтц
                        {
                            bool isNotRepeat = true;
                            for (int j = 0; j<tmp2.Length; j++)
                            {
                                for(int jj=j+1;jj<tmp2.Length;jj++)
                                {
                                    if (tmp2[j] == tmp2[jj]) { isNotRepeat = false; break; }
                                }
                                if (!isNotRepeat) { break; };
                            }
                            if(isNotRepeat){
                                toTxt = toTxt + tmp2 + ", ";
                                toTxt2 = toTxt2 + part3(tmp2,str,textBox4);
                                countr++;
                            }
                        }
                    }    
                }
                if (countr > 0) { 
                    textBox2.AppendText(toTxt + "\r\n");
                    if (toTxt2 != str + " - ")
                    {
                        textBox3.AppendText(toTxt2 + "\r\n");
                    }
                }
            }

            

        }
        
        //part3 поиск по маске рлецб  p2[3] + p2[2] + * + p2[7] + p2[1]
        public string part3(string str3,string strch,TextBox txtbox){ //должна вернуть слово(список слов) 
            System.IO.StringReader file = new System.IO.StringReader(Properties.Resources.Dictionary);
            string line="";
            string tmp3="";
            string res = str3+"(";
            int ctr = 0;

            string toTxt3 = strch + " - ";
            while ((line = file.ReadLine()) != null)
            {
                tmp3 = line.Trim();
                if(tmp3.Length == 5)
                {
                    if (tmp3[0] == str3[3] && tmp3[1] == str3[2] && tmp3[3] == str3[7] && tmp3[4] == str3[1])
                    {
                        res = res + tmp3 + ", ";
                        toTxt3 = toTxt3 + part4(tmp3);//+
                        ctr++;
                    }
                }
            }
            
            if (toTxt3 != strch + " - ")
            {
                txtbox.AppendText(toTxt3 + "\r\n");
            }
            
            if (ctr == 0) { res = ""; }
            else { 
                res = res.Substring(0, res.Length - 2) + "),"; 
            }
            return res;
        }

        public string part4(string str3) //ищет по маске "рца ыци"  рлецб  p[0]+p[3]+ * + * + * + p[3] + *
        {
            System.IO.StringReader file = new System.IO.StringReader(Properties.Resources.Dictionary);
            string line = "";
            string tmp3 = "";
            string res = str3 + "(";
            int ctr = 0;
            while ((line = file.ReadLine()) != null)
            {
                tmp3 = line.Trim();
                if (tmp3.Length == 7)
                {
                    if (tmp3[0]==str3[0] && tmp3[1]==str3[3] && tmp3[5]==str3[3])
                    {
                        bool chk = true;
                        for (int i = 0; i < tmp3.Length; i++)
                        {
                            for(int j=0;j<str3.Length;j++)
                            {
                                if (tmp3[i] == str3[j] && j!=0 && j!=3) { chk = false;break; }
                            }
                            if(!chk){break;}
                        }
                        if (chk)
                        {
                            res = res + tmp3 + ", ";
                            ctr++;
                        }
                    }
                }
            }

            if (ctr == 0) { res = ""; }
            else
            {
                res = res.Substring(0, res.Length - 2) + "),";
            }
            return res;
        }
    }
}
