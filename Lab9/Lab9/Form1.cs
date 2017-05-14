using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace Lab9
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string fam = textBox1.Text;
            string lastname = @"[А-Я][а-я]{1,}$";
            Regex regex = new Regex(lastname, RegexOptions.Singleline);
            if (regex.IsMatch(fam))
            {
                textBox2.Text = "это фамилия!";
            }
            else
            {
                textBox2.Text = "Это не фамилия!";
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            richTextBox1.Text = " ";
            string ip = @"\b((12[0-7]|1[0-1]\d|[0]?\d\d?))(\.(25[0-5]|2[0-4]\d|[01]?\d\d?)){3}$\b";
            string ip2 = @"\b([a-zA-Z0-9]([a-zA-Z0-9\-]{0,61}[a-zA-Z0-9])?\.)+[a-zA-Z]{2,6}$\b";
            Regex regex = new Regex(ip2, RegexOptions.Singleline);
            Regex regax2 = new Regex(ip, RegexOptions.Singleline);
            richTextBox1.SelectionColor = Color.Blue;
            string fam = textBox3.Text;
            string[] Words = fam.Split(new char[] { ' ' });

            foreach (var variants in Words)
            {
                if (regex.IsMatch(variants))
                {
                    richTextBox1.Text += variants + "\r\n";
                }
                if (regax2.IsMatch(variants))
                {
                    richTextBox1.Text += variants + "\r\n";
                }

            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            richTextBox1.Text = " ";


            string education = @"\b\S*образова\S*\b";
            Regex regex = new Regex(education, RegexOptions.Singleline);
            string fam = textBox4.Text;
            string[] Words = fam.Split(new char[] { ' ' });

            foreach (var variants in Words)
            {
                if (regex.IsMatch(variants))
                {
                    richTextBox1.Text += variants + "\r\n";
                }
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            richTextBox1.Text = " ";


            string date1 = @"\b(0[1-9]|[12][0-9]|3[01])[-/.](0[1-9]|1[012])[-/.](19|20)\d\d\b";
            string date2 = @"\b(19|20)\d\d[-/.](0[1-9]|1[012])[-/.](0[1-9]|[12][0-9]|3[01])\b";
            Regex regex2 = new Regex(date2, RegexOptions.Singleline);
            Regex regex = new Regex(date1, RegexOptions.Singleline);
            richTextBox1.SelectionColor = Color.Blue;
            string fam = textBox4.Text;
            string[] Words = fam.Split(new char[] { ' ' });

            foreach (var variants in Words)
            {
                if (regex.IsMatch(variants))
                {
                    richTextBox1.Text += variants + "\r\n";
                }
                else if (regex2.IsMatch(variants))
                {
                    richTextBox1.Text += variants + "\r\n";
                }
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            richTextBox1.Text = " ";
            string address = @"\b(\d{6}\,(\s)?[г]\.[А-Я]\S*\,(\s)?[у][л]\.\S*\,(\s)?[д]\.\d*(\,(\s)?[к][в]\.\d*)?)\b";
            Regex regex = new Regex(address, RegexOptions.Singleline);
            richTextBox1.SelectionColor = Color.Blue;
            string fam = textBox4.Text;
            MatchCollection matches = regex.Matches(fam);
            string[] Words = fam.Split(new char[] { ' ' });

            foreach (Match mat in matches)
            {
                richTextBox1.Text += mat.Value + "\r\n";
            }
        }
    }
}
