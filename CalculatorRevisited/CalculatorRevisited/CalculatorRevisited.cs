using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.XPath;

/*
 * Dnes bude vasim ukolem vytvorit formularovou reprezentaci kalkulacky. Priblizny vzhled si nakreslime na tabuli
 * (Pokud jsem to nenakreslil, pripomente mi to prosim!)
 * Inspirujte se kalkulackou ve Windows.
 * Pozadovane prvky/funkcionality:
 * - Tlacitka pro kazde z cisel 0-9
 * - Tlacitka pro operace +, -, *, a /
 * - Tlacitko pro = (vypsani vysledku)
 * - Textbox, do ktereho se propisou cisla/operace pri stisku jejich tlacitek
 * - Textbox s vysledkem operace (mozne sloucit s predeslym, nechavam na vas)
 * - Tlacitko pro vymazani textu v textboxu s cisly a operaci
 * 
 * Volitelne prvky/funkcionality:
 * - Tlacitko pro mazani cisel a operaci v textboxu zprava vzdy po jednom znaku
 * - Pokud mam vypsany vysledek a hned po tom stisknu tlacitko nejake operace, vysledek se vezme jako prvni cislo a
 *   rovnou mohu po zadani operace zadat druhe cislo
 * - Moznost ulozeni vysledku do nekolika preddefinovanych labelu/neinteraktivnich textboxu (treba kombinaci comboboxu a tlacitka, kde
 *   v comboboxu vyberu do ktereho labelu/textboxu se mi to ulozi a tlacitkem provedu ulozeni)
 *   + pridat tlacitko pro kazdy label/neint. textbox, kterym ulozeny vysledek pouziju jako cislo do vypoctu
 * - Pridani mocnin/odmocnin atd. (napr. pomoci dalsich tlacitek, ktere rovnou misto daneho cisla daji jeho (popr. zaokrouhlenou) odmocninu apod.)
 * - Cokoliv dalsiho vas napadne! :)
 * 
 * Snazte se o to, aby byla kalkulacka v ramci moznosti hezka, a aby bylo jeji ovladani intuitivni a aby mel kazdy prvek v okne dobre vyuziti
 */

namespace CalculatorRevisited
{
    public partial class CalculatorRevisited : Form
    {
        public CalculatorRevisited()
        {
            InitializeComponent();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button10_Click(object sender, EventArgs e)
        {
            textBox1.Text += "0";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            textBox1.Text += "1";
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            char[] nums = textBox1.Text.ToCharArray();
            List<string> strings = new List<string>();
            List<string> ops = new List<string>();
            string currentString = "";

            foreach (char c in nums)
            {
                if (int.TryParse(c.ToString(), out int a))
                {
                    currentString += c;
                }
                else
                {
                    ops.Add(c.ToString());
                    strings.Add(currentString);
                    currentString = "";
                }
            }
            
            if (!string.IsNullOrEmpty(currentString))
            {
                strings.Add(currentString);
            }

            int sum = int.Parse(strings[0]);
            string operation = "";
            foreach(string op in ops)
            {
                if(op == "+")
                {
                    operation = "+";
                }
                else if(op == "-")
                {
                    operation = "-";
                }
                else if(op == "*")
                {
                    operation = "*";
                }
                else if (op == "/")
                {
                    operation = "/";
                }
            }
            for (int i = 1; i < strings.Count(); i++)
            {
                string numString = strings[i];
                if(operation == "+")
                {
                    sum += int.Parse(numString);
                }
                else if (operation == "-")
                {
                    sum -= int.Parse(numString);
                }
                else if (operation == "*")
                {
                    sum *= int.Parse(numString);
                }
                else if (operation == "/")
                {
                    sum /= int.Parse(numString);
                }
            }

            textBox2.Text = sum.ToString();
        }

        private void button11_Click(object sender, EventArgs e)
        {
            textBox1.Text += "+";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Text += "2";
        }

        private void button12_Click(object sender, EventArgs e)
        {
            textBox1.Text += "-";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            textBox1.Text += "3";
        }

        private void button4_Click(object sender, EventArgs e)
        {
            textBox1.Text += "4";
        }

        private void button5_Click(object sender, EventArgs e)
        {
            textBox1.Text += "5";
        }

        private void button6_Click(object sender, EventArgs e)
        {
            textBox1.Text += "6";
        }

        private void button7_Click(object sender, EventArgs e)
        {
            textBox1.Text += "7";
        }

        private void button8_Click(object sender, EventArgs e)
        {
            textBox1.Text += "8";
        }

        private void button9_Click(object sender, EventArgs e)
        {
            textBox1.Text += "9";
        }

        private void button13_Click(object sender, EventArgs e)
        {
            textBox1.Text += "*";
        }

        private void button14_Click(object sender, EventArgs e)
        {
            textBox1.Text += "/";
        }
    }
}
