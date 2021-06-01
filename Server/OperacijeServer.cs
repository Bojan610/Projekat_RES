using Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using DBA;

namespace Server
{
    public class OperacijeServer : IOperacije
    {
        IBazaOperacije bazaOperacije;

        public void Export()
        {
            throw new NotImplementedException();
        }

        public void Filter()
        {
            throw new NotImplementedException();
        }

        public void Import()
        {
            Konekcija.OpenConnection();
            Konekcija.sql = "INSERT INTO Potrosnja VALUES (3, 500, @UCTVreme)";
            Konekcija.cmd.CommandType = CommandType.Text;
            Konekcija.cmd.CommandText = Konekcija.sql;


            Konekcija.cmd.Parameters.AddWithValue("@UCTVreme", DateTime.Now);
            Konekcija.cmd.ExecuteNonQuery();

           

        }
    }
}
