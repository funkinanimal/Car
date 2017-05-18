using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.OracleClient;

namespace CarPark
{
    public partial class addvehicle : System.Web.UI.Page
    {
        OracleConnection Oconnect;
        string conSt = "DATA SOURCE=localhost:1521/xe;PASSWORD=u1361;PERSIST SECURITY INFO=True;USER ID=slava";

        protected void Page_Load(object sender, EventArgs e)
        {
            Oconnect = new OracleConnection(conSt);
            Oconnect.Open();
        }

        protected void TextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            OracleCommand cmd = new OracleCommand();
            string plate = TextBox1.Text;
            string model = TextBox2.Text;
            int seats = Convert.ToInt32(TextBox3.Text);
            if (plate != "" && model != "" && seats != 0)
            {
                var sql = "INSERT INTO VEHICLES (PLATE, MODEL, SEATS) VALUES (:PLATE, :MODEL, :SEATS)";
                cmd.CommandText = sql;
                cmd.Connection = Oconnect;
                cmd.Parameters.Add(new OracleParameter(":PLATE", plate));
                cmd.Parameters.Add(new OracleParameter(":MODEL", model));
                cmd.Parameters.Add(new OracleParameter(":SEATS", seats));
                cmd.ExecuteNonQuery();
                TextBox1.Text = "";
                TextBox2.Text = "";
                TextBox3.Text = "";
            }
        }
    }
}