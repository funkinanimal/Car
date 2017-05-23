using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.OracleClient;

namespace CarPark
{
    public partial class addrout : System.Web.UI.Page
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
            string dep = TextBox1.Text;
            string arr = TextBox2.Text;
            int time = int.Parse(TextBox3.Text.ToString());
            int pd = int.Parse(DropDownList1.SelectedValue.ToString());
            OracleCommand cmd = new OracleCommand();
            if(dep != "" && arr != "" && time != 0)
            {
                var sql = "INSERT INTO ROUTES(DEP_PLACE, ARR_PLACE, TRIP_TIME, PERIOD_ID) VALUES(:DEP_PLACE, :ARR_PLACE, :TRIP_TIME, :PERIOD_ID)";
                cmd.Parameters.Clear();
                cmd.CommandText = sql;
                cmd.Connection = Oconnect;
                cmd.Parameters.Add(new OracleParameter(":DEP_PLACE", dep));
                cmd.Parameters.Add(new OracleParameter(":ARR_PLACE", arr));
                cmd.Parameters.Add(new OracleParameter(":TRIP_TIME", time));
                cmd.Parameters.Add(new OracleParameter(":PERIOD_ID", pd));
                cmd.ExecuteNonQuery();
                TextBox1.Text = "";
                TextBox2.Text = "";
                TextBox3.Text = "";
                Oconnect.Close();
            }
        }
    }
}