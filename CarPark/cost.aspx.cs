using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.OracleClient;

namespace CarPark
{
    public partial class cost : System.Web.UI.Page
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
            Object returnaValue;
            int tr_id = int.Parse(DropDownList1.SelectedValue);
            OracleCommand cmd = new OracleCommand();
            var sql = "select (sold.sold_adult * trips.adult_ticket + sold.sold_child * trips.child_ticket)" +
                "from trips, sold where trips.id = '" + tr_id + "' and sold.t_id = trips.id";
            cmd.CommandText = sql;
            cmd.Connection = Oconnect;
            returnaValue = cmd.ExecuteScalar();
            string res = returnaValue.ToString();
            Label1.Text = "На эту дату было продано билетов на " + res + " руб.";
        }
    }
}