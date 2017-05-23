using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.OracleClient;

namespace CarPark
{
    public partial class adddriver : System.Web.UI.Page
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
            ////////////////
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            OracleCommand cmd = new OracleCommand();
            string fam = TextBox1.Text;
            string nam = TextBox2.Text;
            string pat = TextBox3.Text;
            int idd = int.Parse(DropDownList1.SelectedValue.ToString());
            if(fam != "" && nam != "" && pat != "")
            {
                var sql = "insert into DRIVERS(LASTNAME, NAME, PATRON, VEHICLE_ID) values (:LASTNAME, :NAME, :PATRON, :VEHICLE_ID)";
                cmd.Parameters.Clear();
                cmd.CommandText = sql;
                cmd.Connection = Oconnect;
                cmd.Parameters.Add(new OracleParameter(":LASTNAME", fam));
                cmd.Parameters.Add(new OracleParameter(":NAME", nam));
                cmd.Parameters.Add(new OracleParameter(":PATRON", pat));
                cmd.Parameters.Add(new OracleParameter(":VEHICLE_ID", idd));
                cmd.ExecuteNonQuery();
                TextBox1.Text = "";
                TextBox2.Text = "";
                TextBox3.Text = "";
                Oconnect.Close();
            }
        }
    }
}