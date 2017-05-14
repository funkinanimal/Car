using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab7CS
{
    class Program
    {
        static void Main(string[] args)
        {
            XDocument XMLdoc = new XDocument(
                    new XElement("Employees",
                        new XElement("id", ""),
                        new XElement("fio", ""),
                        new XElement("post", ""),
                        new XElement("serial", ""),
                        new XElement("number", ""),
                        new XElement("date", ""),
                        new XElement("email", ""),
                        new XElement("right", ""),
                        new XElement("depid", ""),

                        new XElement("id", ""),
                        new XElement("fio", ""),
                        new XElement("post", ""),
                        new XElement("serial", ""),
                        new XElement("number", ""),
                        new XElement("date", ""),
                        new XElement("email", ""),
                        new XElement("right", ""),
                        new XElement("depid", ""),

                        new XElement("id", ""),
                        new XElement("fio", ""),
                        new XElement("post", ""),
                        new XElement("serial", ""),
                        new XElement("number", ""),
                        new XElement("date", ""),
                        new XElement("email", ""),
                        new XElement("right", ""),
                        new XElement("depid", ""),

                        new XElement("id", ""),
                        new XElement("fio", ""),
                        new XElement("post", ""),
                        new XElement("serial", ""),
                        new XElement("number", ""),
                        new XElement("date", ""),
                        new XElement("email", ""),
                        new XElement("right", ""),
                        new XElement("depid", "")

                    )
                );
        }
    }
}
