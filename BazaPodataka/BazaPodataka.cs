using Server.Klase;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BazaPodataka
{
    public class BazaPodataka
    {
        public static void UpisUBazu(List<Potrosnja> potrosnja, List<VremenskiPodaci> vremenskiPodaci, List<Drzava> drzave)
        {
            SqlConnection thisConnection = new SqlConnection(@"Data Source=LAPTOP-L3HCB0JI\SQLEXPRESS;Initial Catalog=RES_Projakat;Integrated Security=True");
            thisConnection.Open();

            string dataRemove = "DELETE FROM VremeTabela";

            SqlCommand cmdRemove = thisConnection.CreateCommand();
            cmdRemove.CommandText = dataRemove;

            cmdRemove.ExecuteNonQuery();

            dataRemove = "DELETE FROM PotrosnjaTabela";

            cmdRemove = thisConnection.CreateCommand();
            cmdRemove.CommandText = dataRemove;

            cmdRemove.ExecuteNonQuery();

            dataRemove = "DELETE FROM DrzaveTabela";

            cmdRemove = thisConnection.CreateCommand();
            cmdRemove.CommandText = dataRemove;

            cmdRemove.ExecuteNonQuery();

            foreach (Potrosnja item in potrosnja)
            {
                string data = "INSERT INTO PotrosnjaTabela VALUES (@NazivDrzave, @SifraDrzave, @UCTVreme, @KolicinaEnergije)";

                SqlCommand cmd = thisConnection.CreateCommand();
                cmd.CommandText = data;

                cmd.Parameters.AddWithValue("@NazivDrzave", item.NazivDrzave);
                cmd.Parameters.AddWithValue("@SifraDrzave", item.SifraDrzave);
                cmd.Parameters.AddWithValue("@UCTVreme", item.UctVreme);
                cmd.Parameters.AddWithValue("@KolicinaEnergije", item.KolicinaEnergije);

                cmd.ExecuteNonQuery();
            }

            foreach (VremenskiPodaci item in vremenskiPodaci)
            {
                foreach (Drzava dr in drzave)
                {
                    if (item.MernoMesto == dr.NazivMernogMesta)
                    {
                        string data = "INSERT INTO VremeTabela VALUES (@MernoMesto, @Temperatura, @AtmPritisak, @VlazVazduha, @BrzinaVetra, @Datum)";

                        SqlCommand cmd = thisConnection.CreateCommand();
                        cmd.CommandText = data;

                        cmd.Parameters.AddWithValue("@MernoMesto", item.MernoMesto);
                        cmd.Parameters.AddWithValue("@Temperatura", item.Temperatura);
                        cmd.Parameters.AddWithValue("@AtmPritisak", item.AtmPritisak);
                        cmd.Parameters.AddWithValue("@VlazVazduha", item.VlaznostVazduha);
                        cmd.Parameters.AddWithValue("@BrzinaVetra", item.BrzinaVetra);
                        cmd.Parameters.AddWithValue("@Datum", item.Datum);


                        cmd.ExecuteNonQuery();
                    }
                }
            }

            foreach (Drzava dr in drzave)
            {
                string data = "INSERT INTO DrzaveTabela VALUES (@NazivDrzave, @SifraDrzave, @NazivMernogMesta)";

                SqlCommand cmd = thisConnection.CreateCommand();
                cmd.CommandText = data;

                cmd.Parameters.AddWithValue("@NazivDrzave", dr.NazivDrzave);
                cmd.Parameters.AddWithValue("@SifraDrzave", dr.SifraDrzave);
                cmd.Parameters.AddWithValue("@NazivMernogMesta", dr.NazivMernogMesta);

                cmd.ExecuteNonQuery();
            }


            thisConnection.Close();
        }
    }
}
