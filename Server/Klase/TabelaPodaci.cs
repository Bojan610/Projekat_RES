using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.Klase
{
    public class TabelaPodaci
    {
        string nazivDrzave;
        string sifraDrzave;
        string mernoMesto;
        DateTime uctVreme;
        double kolicinaEnergije;
        double temperatura;
        double atmPritisak;
        double vlazVazduha;
        double brzinaVetra;

        public string NazivDrzave { get => nazivDrzave; set => nazivDrzave = value; }
        public string SifraDrzave { get => sifraDrzave; set => sifraDrzave = value; }
        public string MernoMesto { get => mernoMesto; set => mernoMesto = value; }
        public DateTime UctVreme { get => uctVreme; set => uctVreme = value; }
        public double KolicinaEnergije { get => kolicinaEnergije; set => kolicinaEnergije = value; }
        public double Temperatura { get => temperatura; set => temperatura = value; }
        public double AtmPritisak { get => atmPritisak; set => atmPritisak = value; }
        public double VlazVazduha { get => vlazVazduha; set => vlazVazduha = value; }
        public double BrzinaVetra { get => brzinaVetra; set => brzinaVetra = value; }

        public TabelaPodaci()
        {

        }

        public TabelaPodaci(string nazivDrzave, string sifraDrzave, string mernoMesto, DateTime uctVreme, double kolicinaEnergije, double temperatura, double atmPritisak, double vlazVazduha, double brzinaVetra)
        {
            NazivDrzave = nazivDrzave;
            SifraDrzave = sifraDrzave;
            MernoMesto = mernoMesto;
            UctVreme = uctVreme;
            KolicinaEnergije = kolicinaEnergije;
            Temperatura = temperatura;
            AtmPritisak = atmPritisak;
            VlazVazduha = vlazVazduha;
            BrzinaVetra = brzinaVetra;
        }
    }
}
