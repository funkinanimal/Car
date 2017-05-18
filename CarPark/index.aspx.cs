using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.OracleClient;



namespace CarPark
{
    public partial class index : System.Web.UI.Page
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
            Object returnValue;
            string username = TextBox1.Text;
            string password = TextBox2.Text;

            cmd.CommandText = "select ISADMIN from PROFILES where LOGIN = '" + username + "' and PASS = '" + password + "' ";
            cmd.Connection = Oconnect;

            returnValue = cmd.ExecuteScalar();
            int ad = Convert.ToInt32(returnValue);
            if (ad == 0)
                Response.Redirect("admin.aspx");
            if (ad == 1)
                Response.Redirect("user.aspx");
        }
    }
}