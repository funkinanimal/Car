using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.OracleClient;

namespace CarPark
{
    public partial class timearr : System.Web.UI.Page
    {
        OracleConnection Oconnect;
        string conSt = "DATA SOURCE=localhost:1521/xe;PASSWORD=u1361;PERSIST SECURITY INFO=True;USER ID=slava";

        protected void Page_Load(object sender, EventArgs e)
        {
            Oconnect = new OracleConnection(conSt);
            Oconnect.Open();
        }

        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Object returnaValue;
            int id = int.Parse(DropDownList1.SelectedValue);
            OracleCommand cmd = new OracleCommand();
            var sql = "select car_park.arr_time(" + id + ") from dual";
            cmd.CommandText = sql;
            cmd.Connection = Oconnect;
            returnaValue = cmd.ExecuteScalar();
            string res = returnaValue.ToString();
            Label1.Text = "Время прибытия:\n" + res;
        }
    }
}