using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Lab11
{
    public partial class Lab : System.Web.UI.Page
    {

        private sooshDataContext DB = new sooshDataContext();

        protected void Page_Load(object sender, EventArgs e)
        {
            GridView1.DataSource = DB.Employees;
            GridView1.DataBind();
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            int D = 0;
            int a = Int32.Parse(TextBox1.Text);
            int b = Int32.Parse(TextBox2.Text);
            int c = Int32.Parse(TextBox3.Text);
            double x1 = 0;
            double x2 = 0;
            while (true)
            {
                if (a == 0)
                { 
                    Label1.Text = "a = 0";
                    break;
                }

                D = (b * b) - (4 * (a * c));

                if (D < 0)
                {
                    Label1.Text =  D + "нет корней";
                    break;
                }

                if (D == 0)
                {
                    x1 = (-b + (int)Math.Sqrt(D)) / (2 * a);
                    Label1.Text = "Дискриминант" + D + ", x = " + x1.ToString();
                    break;
                }

                if (D > 0)
                {
                    x1 = (-b + Math.Sqrt(D)) / (2 * a);
                    x2 = (-b - Math.Sqrt(D)) / (2 * a);
                    Label1.Text = "Дискриминант" + D + "x1 = " + x1.ToString() + ", x2 = " + x2.ToString();
                    break;
                }
            }
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            int a = int.Parse(TextBox4.Text);
            int b = int.Parse(TextBox5.Text);
            int c = 0;
            for (int i = a + 1; i < b - 1; i++)
            {
                if (i % 2 == 0)
                    c++;
            }
            Label2.Text = "Между " + a + " и " + b + " " + c + " четных чисел";
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            string[] set = { "Оля", "Олег", "Андрей", "Антон"};
            string result = "";
            string text = TextBox6.Text;

            if(RadioButton1.Checked)
            {
                foreach(string a in set)
                {
                    if (a.Contains(text))
                        result += a + " ";
                }
            }

            else if(RadioButton2.Checked)
            {
                foreach(string a in set)
                {
                    if (a.Equals(text))
                        result += a + " ";
                }
            }

            Label3.Text = result;
        }

        protected void RadioButton1_CheckedChanged(object sender, EventArgs e)
        {
        }

        protected void RadioButton2_CheckedChanged(object sender, EventArgs e)
        {
        }

        protected void Button4_Click(object sender, EventArgs e)
        {
            string sr = TextBox7.Text;
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

            GridView1.DataSource = query;
            GridView1.DataBind();
        }
    }
}