using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfProjekat.Klase
{
    public class VremenskiPodaci
    {
        public DateTime lokalnoVreme { get; set; }
        public double temperatura { get; set; }
        public double vlaznVazduha { get; set; }
        public double atmPritisak { get; set; }
        public double brzinaVetra { get; set; }
    }

    public class ExcelDataService
    {
        OleDbConnection Conn;
        OleDbCommand Cmd;

        public ExcelDataService()
        {
            string ExcelFilePath = @"C:\Users\PC\Desktop\projekat_res\zadatak_6\ulazni_podaci\vremenskiPodaci.xls";
            string excelConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + ExcelFilePath + ";Extended Properties=Excel 12.0;Persist Security Info=True";
            Conn = new OleDbConnection(excelConnectionString);
        }

        public async Task<ObservableCollection<VremenskiPodaci>> ReadRecordFromEXCELAsync()
        {
            ObservableCollection<VremenskiPodaci> vremePodaci = new ObservableCollection<VremenskiPodaci>();
            await Conn.OpenAsync();
            Cmd = new OleDbCommand();
            Cmd.Connection = Conn;
            Cmd.CommandText = "Select * from [Sheet1$]";
            var Reader = await Cmd.ExecuteReaderAsync();
            while (Reader.Read())
            {
                vremePodaci.Add(new VremenskiPodaci()
                {
                    //StudentID = Convert.ToInt32(Reader["StudentID"]),
                    //Name = Reader["Name"].ToString(),
                    //Email = Reader["Email"].ToString(),
                    //Class = Reader["Class"].ToString(),
                    //Address = Reader["Address"].ToString()
                    lokalnoVreme = Convert.ToDateTime(Reader["Local time in Belgrade / Nicola Tesla (airport)"]),
                    temperatura = Convert.ToDouble(Reader["T"]),
                    vlaznVazduha = Convert.ToDouble(Reader["P0"]),
                    atmPritisak = Convert.ToDouble(Reader["P"]),
                    brzinaVetra = Convert.ToDouble(Reader["U"])
                });
            }
            Reader.Close();
            Conn.Close();
            return vremePodaci;
        }
    }
}
