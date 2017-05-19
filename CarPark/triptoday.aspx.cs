using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.OracleClient;

namespace CarPark
{
    

    public partial class triptoday : System.Web.UI.Page
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
            Object returnValue;
            int id = int.Parse(DropDownList1.SelectedValue);
            var sql = "select car_park.today_trip(" + id + ") from dual";
            cmd.CommandText = sql;
            cmd.Connection = Oconnect;
            returnValue = cmd.ExecuteScalar();
            string res = returnValue.ToString();
            Label1.Text = "Свободных мест:\n" + res;
        }
    }
}