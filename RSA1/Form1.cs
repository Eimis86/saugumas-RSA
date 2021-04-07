using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RSA1
{
    public partial class Form1 : Form
    {
        private List<int> ascii;
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
                int p = Convert.ToInt32(textBox2.Text);
                int q = Convert.ToInt32(textBox3.Text);
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
                int n = Convert.ToInt32(textBox5.Text);
                int d = Convert.ToInt32(textBox6.Text);
                //Console.WriteLine(decryprt);
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex);
            }
        }
    }
}
