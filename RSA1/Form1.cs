using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RSA1
{
    public partial class Form1 : Form
    {
        private List<int> ascii;
        private List<BigInteger> dText;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
        //chypher
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                BigInteger p = Convert.ToInt32(textBox2.Text);
                BigInteger q = Convert.ToInt32(textBox3.Text);
                //Encoding ascii = Encoding.ASCII;
                ascii = new List<int>();
                foreach (char letter in textBox1.Text)
                {
                    ascii.Add(Convert.ToInt32(letter));
                    //byte[] Eletter = ascii.GetBytes(letter);
                }
                ascii.ForEach(Console.WriteLine);

                textBox4.Text = Cypher.Enxryption(p,q,ascii);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }
        //dechypher
        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                string decryprt = textBox4.Text;
                BigInteger n = Convert.ToInt32(textBox5.Text);
                BigInteger e1 = Convert.ToInt32(textBox6.Text);
                Console.WriteLine(n + " n " + e1 +" e");
                //BigInteger Dtext[];
                string[] DeText = (textBox4.Text).Split(' ');
                Console.WriteLine("decrypt");
                BigInteger[] eText = new BigInteger[DeText.Length];
                for (int i =0; i < DeText.Length; i++)
                {
                    BigInteger a = 0;
                    if (BigInteger.TryParse(DeText[i],out a))
                    {
                        if (a != 0)
                        {
                            eText[i] = BigInteger.Parse(DeText[i]);
                        }
                    }
                }
                Console.WriteLine(Convert.ToString(eText));
                /*for(int i=0; i>= eText.Length ; i++)
                {
                    Console.WriteLine(eText[i]);
                }*/
                //textBox1.Clear();
                textBox7.Text = Cypher.Decryption(eText, n, e1);
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex);
            }
        }
    }
}
