using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvidencijaPotrosnjeIVremenskihParametara.Klase
{
    public class Potrosnja
    {
        string nazivDrzave;
        string sifraDrzave;
        DateTime uctVreme;
        double kolicinaEnergije;


        public DateTime UctVreme { get => uctVreme; set => uctVreme = value; }
        public double KolicinaEnergije { get => kolicinaEnergije; set => kolicinaEnergije = value; }
        public string NazivDrzave { get => nazivDrzave; set => nazivDrzave = value; }
        public string SifraDrzave { get => sifraDrzave; set => sifraDrzave = value; }

        public Potrosnja()
        {
            NazivDrzave = "";
            SifraDrzave = "";
            UctVreme = DateTime.Now;
            KolicinaEnergije = 0;
        }

        public Potrosnja(string nazivDrzave, string sifraDrzave, DateTime uctVreme, double kolicinaEnergije)
        {
            NazivDrzave = nazivDrzave;
            SifraDrzave = sifraDrzave;
            UctVreme = uctVreme;
            KolicinaEnergije = kolicinaEnergije;
        }
    }
}
