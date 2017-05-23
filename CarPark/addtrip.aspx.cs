using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.OracleClient;

namespace CarPark
{
    public partial class addtrip : System.Web.UI.Page
    {

        OracleConnection Oconnect;
        string conSt = "DATA SOURCE=localhost:1521/xe;PASSWORD=u1361;PERSIST SECURITY INFO=True;USER ID=slava";

        protected void Page_Load(object sender, EventArgs e)
        {
            Oconnect = new OracleConnection(conSt);
            Oconnect.Open();
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            OracleCommand cmd = new OracleCommand();
            int di = int.Parse(DropDownList1.SelectedValue.ToString());
            int ri = int.Parse(DropDownList2.SelectedValue.ToString());
            //DateTime da = DateTime.Parse(TextBox1.Text.ToString());
            string da = TextBox1.Text.ToString();
            int ca = int.Parse(TextBox2.Text.ToString());
            int cc = int.Parse(TextBox3.Text.ToString());
            var sql = "INSERT INTO TRIPS(DRIVER_ID, ROUTE_ID, TRIP_DATE, ADULT_TICKET, CHILD_TICKET) VALUES(:DRIVER_ID, :ROUTE_ID, to_date(:TRIP_DATE, 'DD.MM.YYYY HH24:MI'), :ADULT_TICKET, :CHILD_TICKET)";
            cmd.Parameters.Clear();
            cmd.CommandText = sql;
            cmd.Connection = Oconnect;
            cmd.Parameters.Add(new OracleParameter(":DRIVER_ID", di));
            cmd.Parameters.Add(new OracleParameter(":ROUTE_ID", ri));
            cmd.Parameters.Add(new OracleParameter(":TRIP_DATE", da));
            cmd.Parameters.Add(new OracleParameter(":ADULT_TICKET", ca));
            cmd.Parameters.Add(new OracleParameter(":CHILD_TICKET", cc));
            cmd.ExecuteNonQuery();
            TextBox1.Text = "";
            TextBox2.Text = "";
            TextBox3.Text = "";
            Oconnect.Close();
        }
    }
}