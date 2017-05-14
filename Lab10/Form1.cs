using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab10
{
    public partial class Form1 : Form
    {
        private sooshDataContext DB = new sooshDataContext();

        public Form1()
        {
            InitializeComponent();
            var query = from show in DB.Employees
                        select show;
            dataGridView1.DataSource = query;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var query = from ub in DB.Employees
                        where (DateTime.Now.Year - ub.birth.Year) % 10 == 0 || (DateTime.Now.Year - ub.birth.Year) % 10 == 5
                        select ub;
            dataGridView1.DataSource = query;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var query = from tw in DB.Employees
                        where (tw.hire.Year - tw.birth.Year) < 20
                        select tw;
            dataGridView1.DataSource = query;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            var query = from th in DB.Employees
                        where th.birth.Month == 07 || th.birth.Month == 08 || th.birth.Month == 09
                        select new { th.lastname, th.name, th.patron};
            dataGridView1.DataSource = query;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
                string sr = textBox1.Text;
               var query = from s in DB.Employees
                            where s.Id.ToString().Contains(sr) ||
                            s.lastname.ToString().Contains(sr) ||
                            s.name.ToString().Contains(sr) ||
                            s.patron.ToString().Contains(sr) ||
                            s.birth.ToString().Contains(sr) ||
                            s.education.ToString().Contains(sr) ||
                            s.hire.ToString().Contains(sr) ||
                            s.post.ToString().Contains(sr) ||
                            s.spec.ToString().Contains(sr)
                            select s;

            dataGridView1.DataSource = query;
        }
    }
}
