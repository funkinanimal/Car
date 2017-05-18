using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.OracleClient;

namespace CarPark
{
    public partial class addprofile : System.Web.UI.Page
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
            if(TextBox2.Text.Equals(TextBox3.Text))
            {
                int isadmin;
                string login = TextBox1.Text;
                string pass = TextBox2.Text;
                if (CheckBox1.Checked)
                    isadmin = 0;
                else
                    isadmin = 1;
                OracleCommand cmd = new OracleCommand();
                var sql = "insert into profiles(login, pass, isadmin) values (:login, :pass, :isadmin)";
                cmd.CommandText = sql;
                cmd.Connection = Oconnect;
                cmd.Parameters.Add(new OracleParameter(":login", login));
                cmd.Parameters.Add(new OracleParameter(":pass", pass));
                cmd.Parameters.Add(new OracleParameter(":isadmin", isadmin));
                cmd.ExecuteNonQuery();
            }
            else
            {
                Label1.ForeColor = System.Drawing.Color.Red;
                Label1.Text = "Пароли не совпадают!";
            }
        }

        protected void TextBox3_TextChanged(object sender, EventArgs e)
        {
            
        }
    }
}