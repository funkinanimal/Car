using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace lab6
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        class Customer
        {
            public int code;
            public int year;
            public string street;
        }

        class Discount
        {
            public int code;
            public int discount;
            public string shop;
        }

        List<Customer> customers = new List<Customer>
        {
            new Customer{code = 1, year = 2001, street = "Боевая"},
            new Customer{code = 3, year = 2000, street = "Куликова"},
            new Customer{code = 2, year = 1999, street = "Ленина"},
            new Customer{code = 4, year = 1997, street = "Шаумяна"},
            new Customer{code = 6, year = 1995, street = "Первая улица"}
        };

        List<Discount> discounts = new List<Discount>
        {
            new Discount{code = 1, discount = 10, shop = "DNS"},
            new Discount{code = 2, discount = 15, shop = "Эльдорадо"},
            new Discount{code = 1, discount = 5, shop = "Фамилия"},
            new Discount{code = 6, discount = 10, shop = "Фамилия"},
            new Discount{code = 4, discount = 10, shop = "Фамилия"},
            new Discount{code = 3, discount = 15, shop = "Ситилинк"},
            new Discount{code = 2, discount = 10, shop = "Ситилинк"}
        };


        class B
        {
            public string category;
            public int id_tovara;
            public string country;

            public B(string a, int b, string c)
            {
                this.category = a;
                this.id_tovara = b;
                this.country = c;
            }
        }

        class D
        {
            public int id_tovara;
            public int price;
            public string shop;

            public D(int a, int b, string c)
            {
                this.id_tovara = a;
                this.price = b;
                this.shop = c;
            }
        }

        List<B> b = new List<B>
        {
            new B("a", 1, "Россия"),
            new B("b", 2, "Россия"),
            new B("d", 3, "КНР"),
            new B("c", 1, "Россия"),
            new B("a", 2, "Россия"),
            new B("b", 3, "США"),
            new B("c", 1, "Португалия"),
            new B("d", 2, "Румыния"),
        };

        List<D> d = new List<D>
        {
            new D(1, 100, "Базар"),
            new D(2, 200, "Лента"),
            new D(2, 200, "Покупочка"),
            new D(3, 150, "Малинка"),
        };


        class Buy
        {
            public int id;
            public int year;
            public string street;

            public Buy(int i, int y, string s)
            {
                this.id = i;
                this.year = y;
                this.street = s;
            }
        }

        class Manufacturer
        {
            public int artikul;
            public int category;
            public string country;

            public Manufacturer(int a, int c, string c1)
            {
                this.artikul = a;
                this.category = c;
                this.country = c1;
            }
        }

        class Shop
        {
            public int artikul;
            public int id;
            public string shop;

            public Shop(int a, int i, string s)
            {
                this.artikul = a;
                this.id = i;
                this.shop = s;
            }
        }

        List<Buy> p = new List<Buy>
        {
            new Buy(1, 2005, "Шаумяна"),
            new Buy(2, 2006, "Ленина"),

        };

        List<Manufacturer> pr = new List<Manufacturer>
        {
            new Manufacturer(4212, 1, "США"),
            new Manufacturer(2345, 2, "США"),
            new Manufacturer(2457, 3, "Россия"),
            new Manufacturer(9476, 4, "США"),
            new Manufacturer(4987, 5, "Россия"),
            new Manufacturer(9735, 10, "Китай"),
            new Manufacturer(9735, 62, "Китай"),
            new Manufacturer(4212, 11, "Россия"),
            new Manufacturer(9735, 6, "Китай"),
            new Manufacturer(4212, 13, "Россия"),
        };

        List<Shop> m = new List<Shop>
        {
            new Shop(4212, 1, "Магазин1"),
            new Shop(2457, 1, "Магазин1"),
            new Shop(9476, 1, "Магазин2"),
            new Shop(9735, 2, "Магазин3"),

        };


        private void button1_Click_1(object sender, EventArgs e)
        {
            textBox1.Text = "";
            var query = discounts.GroupBy(n => n.shop).Select(g => new
            {
                market = g.Key,
                delivery = (from m in g select m.discount).Max(),
                year = from m in customers where m.code == (from c in g where c.discount == (from k in g select k.discount).Max() select c.code).Min() select m.year,
                client = (from c in g
                          where c.discount == (from m in g select m.discount).Max()
                          select c.code).Min(),
            }).OrderBy(g => g.market);



            foreach (var d in query)
            {
                textBox1.Text += string.Format("{0} - {1} - ", d.market, d.client);

                foreach (var t in d.year)
                    textBox1.Text += t;
                textBox1.Text += string.Format(" - {0} \r\n", d.delivery);
            }
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            textBox1.Text = "";
            var query1 = b.GroupBy(n => n.category).Select(g => new
            {
                cat = g.Key,
                kolvostran = (from kolvostran in g select kolvostran.country).Distinct().Count(),
                kolvoshop = (from c in d
                             where (from cc in g select cc.id_tovara).Contains(c.id_tovara)
                             select c).Distinct().Count()
            }).OrderBy(s => s.cat).OrderByDescending(s => s.kolvoshop);

            foreach (var q in query1)
            {

                if (q.kolvoshop != 0)
                    textBox1.Text += string.Format("Количество магазинов: {0}, имеющих товары с категорией: {1}, количество стран производителей данного товара: {2} \r\n", q.kolvoshop, q.cat, q.kolvostran);
            }
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            textBox1.Text = "";
            var query = p.GroupBy(n => n.year).Select(g => new
            {
                yer = g.Key,
                svyaz1 = (from st in m where (from s in g select s.id).Contains(st.id) select st),
            }).OrderByDescending(g => g.yer);


            foreach (var q in query)
            {
                var countries = from c in pr where (from cc in q.svyaz1 select cc.artikul).Contains(c.artikul) select c.country;
                var count = (from s in q.svyaz1 select s.artikul).Count();
                if (count != 0)
                {
                    var most = countries.GroupBy(m => m).OrderByDescending(m => m.Count()).First();

                    textBox1.Text += string.Format("Год - {0}, Страна - {1}, количество покупок - {2} \r\n", q.yer, most.Key, count);
                }
            }
        }
    }
}
