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
            if (nazivDrzave == null || sifraDrzave == null || mernoMesto == null || uctVreme == new DateTime())
                throw new ArgumentNullException("Argumenti ne smeju biti null");

            if (nazivDrzave.Trim() == "")
                throw new ArgumentException("Naziv drzave mora da sadrzi karaktere");

            if (sifraDrzave.Trim() == "")
                throw new ArgumentException("Sifra drzave mora da sadrzi karaktere");

            if (mernoMesto.Trim() == "")
                throw new ArgumentException("Naziv mernog mesta mora da sadrzi karaktere");

            if (kolicinaEnergije < 0)
                throw new ArgumentException("Kolicina potrosene energije mora biti pozitivna");

            if (atmPritisak < 0)
                throw new ArgumentException("Atmosferski pritisak mora biti pozitivan");

            if (vlazVazduha < 0)
                throw new ArgumentException("Vlaznost vazduha mora biti pozitivna");

            if (brzinaVetra < 0)
                throw new ArgumentException("Brzina vetra mora biti pozitivna");

            if (Char.IsLower(char.Parse(nazivDrzave.Substring(0, 1))))
                throw new ArgumentException("Naziv drzave mora poceti velikim slovom");

            if (Char.IsLower(char.Parse(mernoMesto.Substring(0, 1))))
                throw new ArgumentException("Naziv mernog mesta mora poceti velikim slovom");

            if (Char.IsLower(char.Parse(sifraDrzave.Substring(0, 1))) || Char.IsLower(char.Parse(sifraDrzave.Substring(1, 1))))
                throw new ArgumentException("Sifra drzave sadrzi samo velika slova");

            if (sifraDrzave.Count() != 2)
                throw new ArgumentException("Sifra drzave mora imati tacno 2 znaka");


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
