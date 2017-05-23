using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.OracleClient;
using System.Data;

namespace CarPark
{
    
    public partial class schedule : System.Web.UI.Page
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
            int id = int.Parse(DropDownList1.SelectedValue);
            OracleCommand cmd = new OracleCommand("car_park.schedule", Oconnect);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("drvr_id", OracleType.Number).Value = id;
            cmd.Parameters.Add("res", OracleType.VarChar, 1000).Direction = ParameterDirection.Output;
            cmd.ExecuteNonQuery();
            string res = Convert.ToString(cmd.Parameters["res"].Value);
            Label1.Text = res;
            Oconnect.Close();
        }
    }
}