using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace zadanieForm
{
    public partial class Form1 : Form
    {
        static string OutputNumber(string text)
        {
            var result =
                from c in text
                where char.IsDigit(c)
                select c;

            int count = 0;
            foreach (var c in result)
            {
                count++;
            }
            return $"{count} чисел в строке";
        }
        //B
        static string OutputTo(string text)
        {
            IEnumerable<char> str = text.TakeWhile(c => c != '/');

            string outtext = "";

            foreach (char c in str)
            {
                outtext += c;
            }

            return outtext;
        }
        //C
        static string OutputAfter(string text)
        {
            IEnumerable<char> str = text.SkipWhile(c => c != '/');

            string outtext = "";

            foreach (char c in str)
            {
                if (c == '/')
                    continue;
                else
                {
                    if (char.IsDigit(c))
                        outtext += c;
                    else if (c >= 'а' && c <= 'я' || c >= 'a' && c <= 'z')
                        outtext += c.ToString().ToUpper();
                    else
                        if (c >= 'А' && c <= 'Я' || c >= 'A' && c <= 'Z')
                        outtext += c.ToString().ToLower();
                }
            }

            return outtext;
        }
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string text = textBox1.Text;
            listBox1.Items.Add(OutputNumber(text));
            listBox1.Items.Add("Все элементы массива,пока не встретится символ “/”");
            listBox1.Items.Add(OutputTo(text));
            listBox1.Items.Add("Все элементы массива,после символ “/”");
            listBox1.Items.Add(OutputAfter(text));

        }
    }
}
