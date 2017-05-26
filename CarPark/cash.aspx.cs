using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.OracleClient;

namespace CarPark
{
    public partial class cash : System.Web.UI.Page
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
            
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Object returnValue;
            string ch = "sold_adult";
            OracleCommand cmd = new OracleCommand();
            int id = int.Parse(DropDownList1.SelectedValue);
            if (CheckBox1.Checked)
                ch = "sold_child";
            var sql = "update sold set " + ch + "=" + ch + " + 1 where t_id = " + id;
            cmd.CommandText = sql;
            cmd.Connection = Oconnect;
            cmd.ExecuteNonQuery();     
        }
    }
}