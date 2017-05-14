using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab4CS
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        class Student
        {
            public string fio;
            public int grname;
            public int scholarship;
        }

        List<Student> Students = new List<Student> {
            new Student {fio = "Афанасьев", grname = 1, scholarship = 1230},
            new Student {fio = "Голубков", grname = 2, scholarship = 1260},
            new Student {fio = "Климаков", grname = 1, scholarship = 1530},
            new Student {fio = "Меретин", grname = 2, scholarship = 1530}
        };

        class Employee
        {
            public int id;
            public string fam;
            public float salary;
            public int department;
        }

        class Department
        {
            public int id;
            public string name;
        }

        List<Department> departments = new List<Department>
        {
            new Department {id = 1, name = "Дирекция"},
            new Department {id =2, name = "Отдел Кадров"},
            new Department {id = 3, name = "Бухгалтерия"}
        };

        List<Employee> employees = new List<Employee>
        {
            new Employee {id = 1, fam = "Лебедев", salary = 17523, department = 1},
            new Employee {id = 2, fam = "Петров", salary = 1573, department = 1},
            new Employee {id = 3, fam = "Кшиштовский", salary = 15423, department = 1},
            new Employee {id = 4, fam = "Воронцов", salary = 18523, department = 2},
            new Employee {id = 5, fam = "Королев", salary = 15293, department = 2},
            new Employee {id = 6, fam = "Марченко", salary = 15023, department = 2},
            new Employee {id = 7, fam = "Бульба", salary = 15623, department = 3},
            new Employee {id = 8, fam = "Френкель", salary = 15239, department = 3},
            new Employee {id = 9, fam = "Камышан", salary = 15234, department = 3}
        };

        class strin
        {
            public int id;
            public string str;
        }
        List<strin> A = new List<strin>
        {
            new strin {id = 1, str = "gfsf"},
            new strin {id = 1, str = "fsdg"},
            new strin {id = 1, str = "afa"},
            new strin {id = 1, str = "bv"}
        };
        List<strin> B = new List<strin>
        {
            new strin {id = 1, str = "asdf"},
            new strin {id = 1, str = "we"},
            new strin {id = 1, str = "gfty"},
            new strin {id = 1, str = "ghjk"},
            new strin {id = 1, str = "ftr"},
            new strin {id = 1, str = "afdf"}
        };


        int[] a1 = new int[10] { 11, 30, 21, 116, 89, 79, 100, 22, 57, 20 };

        List<strin> qwe = new List<strin>
        {
            new strin {id = 1, str = "DAAA"},
            new strin {id = 1, str = "BBB"},
            new strin {id = 1, str = "CCC"},
            new strin {id = 1, str = "DDD"},
            new strin {id = 1, str = "EEE"},
            new strin {id = 1, str = "FFF"},
            new strin {id = 1, str = "FFF"},
            new strin {id = 1, str = "AFFF"},
            new strin {id = 1, str = "BFFC"},
            new strin {id = 1, str = "CCFFF"}
        };

        private void button1_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            /////////11111///////////////////
            var zap3 = from l in Students
                       group l by l.grname into g
                       select new
                       {
                           grpng1 = g.Key,
                           AverageScholarshipInGroup = g.Average(s => s.scholarship),
                           list = (from s1 in Students select s1)
                       };

            foreach (var stud in zap3)
            {


                textBox1.Text += String.Format("\r\n Группа {0} Средняя стипендия {1}", stud.grpng1, stud.AverageScholarshipInGroup);

                foreach (var studs in stud.list)
                {
                    if (studs.grname == stud.grpng1)
                        textBox1.Text += "\r\n " + studs.fio;
                }
            }

            textBox1.Text += "\r\n";
            textBox1.Text += "\r\n";
            /////////////222222//////////////
            var zap4 = from d in employees
                       group d by d.department into g
                       select new
                       {
                           grpng2 = g.Key,
                           AverageSalary = g.Average(d => d.salary),
                           list = (from d1 in employees select d1)

                       };

            float salaryDep = 0;
            float totalSalary = 0;
            foreach (var emp in zap4)
            {
                var naz_dep = from pa in departments
                              where emp.grpng2 == pa.id
                              select pa.name;
                textBox1.Text += String.Format("\r\n Отдел = {0}, Средняя зарплата {1}", naz_dep.First(), emp.AverageSalary);

                foreach (var emp2 in emp.list)
                {
                    if (emp2.department == emp.grpng2)
                    {
                        textBox1.Text += "\r\n " + emp2.fam + emp2.salary;
                        salaryDep += emp2.salary;
                    }
                    totalSalary += emp2.salary;
                }

                textBox1.Text += String.Format("\r\n Зарплата в отделе {0} %", (salaryDep * 100) / totalSalary);
                salaryDep = 0;
                totalSalary = 0;
            }
            textBox1.Text += "\r\n";
            textBox1.Text += "\r\n";
            /////////////333333333////////////
            var query5 = A.GroupJoin(B, q => q.id, o => o.id, (q, os) => new
            {
                str = q.str,
                count = (os.Where(n => n.str.StartsWith(q.str.Substring(0, 1))).Count())
            });

            foreach (var s in query5)
            {
                textBox1.Text += "\r\n " + s.str + " : " + s.count;
            }


            textBox1.Text += "\r\n";
            textBox1.Text += "\r\n";
            ///////////44444444444/////////////////


            var query6 = a1.GroupBy(n => n % 10).Select(g => new
            {
                d = g.Key,
                sum = (from s in g select s).Sum()
            }).OrderByDescending(g => g.d);

            foreach (var s in query6)
            {
                textBox1.Text += String.Format("\r\n {0}: {1} \n", s.d, s.sum);
            }

            textBox1.Text += "\r\n";
            textBox1.Text += "\r\n";
            ///////////5555555555555///////////
            var query7 = qwe.GroupJoin(qwe, q => q.id, o => o.id, (q, os) => new
            {
                sum = (os.Where(n => n.str.StartsWith(q.str.Substring(0, 1))).Sum(n => n.str.Length)),
                str = q.str.Substring(0, 1)
            }).Distinct().OrderByDescending(n => n.sum).ThenBy(n => n.str);

            foreach (var s in query7)
            {
                textBox1.Text += "\r\n" + s.sum + " - " + s.str;
            }
        }
    }
}
