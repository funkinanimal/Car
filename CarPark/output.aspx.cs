using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.OracleClient;
using System.IO;
using iTextSharp.text;
using iTextSharp.text.pdf;

namespace CarPark
{
    public partial class output : System.Web.UI.Page
    {
        string res = "";

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
            cmd.Connection = Oconnect;
            var sql = "select distinct lastname, route_name, trip_date, (sold_adult + sold_child) as sld"
               + " from drivers, trips, sold, routes where trips.driver_id = drivers.id and trips.id = sold.t_id"
               + " and trunc(sysdate, 'WW') = trunc(trip_date, 'WW') and(sold.sold_adult + sold.sold_child) > trips.av_seats / 2";
            cmd.CommandText = sql;
            OracleDataReader reader = cmd.ExecuteReader();
            if(reader.HasRows)
            {
                res = "На этой неделе\n\n";
                while(reader.Read())
                {
                    res += "Водитель " + reader.GetString(0) 
                        + " совершает рейс по направлению " + reader.GetString(1) 
                        + " " +reader.GetOracleDateTime(2)
                        + " на который было продано " + reader.GetOracleNumber(3) + " билетов \n\n";
                }
                reader.NextResult();
            }
            else
            {
                res = "Данных нет";
            }

            outfile(res);
            
        }
        

        public void outfile(string input)
        {
            var stream = new FileStream("C:\\Users\\Слава\\Desktop\\Универ\\3 курс\\NET\\CarPark\\output.pdf", FileMode.Create);
            var doc = new Document(PageSize.A4, 50, 50, 50, 50);

            var fg = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Fonts), "ARIALUNI.TTF");
            var fgBaseFont = BaseFont.CreateFont(fg, BaseFont.IDENTITY_H, BaseFont.NOT_EMBEDDED);
            var font = new Font(fgBaseFont, 12, Font.NORMAL, BaseColor.BLACK);

            PdfWriter writer = PdfWriter.GetInstance(doc, stream);
            doc.Open();

            var p = new Phrase(input, font);

            doc.Add(p);

            doc.Close();

            writer.Close();
        }
    }
}