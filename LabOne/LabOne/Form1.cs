using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LabOne
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        
        private void dataGridView1_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            if (dataGridView1.Rows[e.RowIndex].IsNewRow)
                return;
            string err = "";
            string ok = e.FormattedValue.ToString();

            int x;

            switch(e.ColumnIndex)
            {
                case 0:
                    if (int.Parse(ok) <= 0)
                        //e.Cancel = err != "";
                        err = "wrong id";
                    break;
                case 1:
                    if (String.IsNullOrEmpty(ok))
                        err = "wrong name";
                    break;
                case 2:
                    if (ok != "М" && ok != "Ж")
                        err = "wrong gender";
                    break;
                case 3:
                    if ((DateTime.Now.Year - DateTime.Parse(ok).Year) < 15 || (DateTime.Now.Year - DateTime.Parse(ok).Year) > 25)
                        err = "wrong date";
                    int age = DateTime.Now.Year - DateTime.Parse(ok).Year;
                    string postfix = "";
                    if (age % 10 == 1)
                        postfix = " год";
                    if (age % 10 >= 5 && age % 10 <= 9 || age % 10 == 0)
                        postfix = " лет";
                    if (age % 10 >= 2 && age % 10 <= 4)
                        postfix = " года";
                    dataGridView1.Rows[e.RowIndex].Cells[3].ToolTipText = age.ToString() + postfix;
                    break;
                case 4:
                    if (int.Parse(ok) <= 0 || int.Parse(ok) > 4)
                        err = "wrong course";
                    break;
                case 5:
                    if (int.TryParse(ok, out x))
                    {
                        if (x <= 0)
                            err = "wrong group";
                    }
                    else
                        err = "not a number";
                    break;
                case 7:
                    if (int.TryParse(ok, out x))
                    {
                        if (x < 0)
                            err = "wrong number";
                    }
                    else
                        err = "not a number";
                    break;
                default:
                    break;
            }
            e.Cancel = err != "";
            dataGridView1.Rows[e.RowIndex].ErrorText = err;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void bindingNavigator1_RefreshItems(object sender, EventArgs e)
        {

        }

        private void bindingNavigatorAddNewItem_Click(object sender, EventArgs e)
        {

        }

        private void bindingNavigatorPositionItem_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            bindingNavigatorDeleteItem.Enabled = !dataGridView1.Rows[e.RowIndex].IsNewRow;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
        }

        private List<Student> CollectStudent()
        {
            List<Student> br = new List<Student>();
            Student st;
            bindingSource1.EndEdit();
            for (int i = 0; i < dataGridView1.RowCount; i++)
            {
                if (dataGridView1.Rows[i].Cells[0].Value == null)
                    break;
                else
                {
                    st = new Student();
                    st.Id = (int)dataGridView1.Rows[i].Cells[0].Value;
                    st.Surname = dataGridView1.Rows[i].Cells[1].Value.ToString();
                    st.Gender = dataGridView1.Rows[i].Cells[2].Value.ToString();
                    st.Birth = (DateTime)dataGridView1.Rows[i].Cells[3].Value;
                    st.Course = (int)dataGridView1.Rows[i].Cells[4].Value;
                    st.Group = (int)dataGridView1.Rows[i].Cells[5].Value;
                    st.Scholarship = (bool)dataGridView1.Rows[i].Cells[6].Value;
                    st.ScholarshipSize = (float)dataGridView1.Rows[i].Cells[7].Value;
                    br.Add(st);
                }
            }
            return br;
        }


        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            string sn = toolStripTextBox1.Text;
            var fnQuery = from sname in CollectStudent()
                          where sname.Surname.Equals(sn)
                          select sname;
            BindingSource bs = new BindingSource();
            bs.DataSource = fnQuery;
            dataGridView1.DataSource = bs;
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            double scQuery = CollectStudent().Where(c => c.ScholarshipSize > 0).Average(c=>c.ScholarshipSize);
            toolStripLabel2.Text = scQuery.ToString();
            for(int i = 0; i < dataGridView1.RowCount - 1; i++)
            {
                if (Convert.ToDouble(dataGridView1.Rows[i].Cells[7].Value) < scQuery)
                    dataGridView1.Rows[i].Cells[1].Style.BackColor = Color.Red;
                else
                    dataGridView1.Rows[i].Cells[1].Style.BackColor = Color.Green;
            }
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            string sn = toolStripTextBox1.Text;
            var fnQuery = from sname in CollectStudent()
                          where sname.Surname.Contains(sn)
                          select sname;
            BindingSource bs = new BindingSource();
            bs.DataSource = fnQuery;
            dataGridView1.DataSource = bs;
        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = bindingSource1;
        }
    }
}
