using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.Klase
{
    public class VremenskiPodaci
    {
        string mernoMesto;
        double temperatura;
        double atmPritisak;
        double vlaznostVazduha;
        double brzinaVetra;
        DateTime datum;


        public double Temperatura { get => temperatura; set => temperatura = value; }
        public double AtmPritisak { get => atmPritisak; set => atmPritisak = value; }
        public double VlaznostVazduha { get => vlaznostVazduha; set => vlaznostVazduha = value; }
        public double BrzinaVetra { get => brzinaVetra; set => brzinaVetra = value; }
        public string MernoMesto { get => mernoMesto; set => mernoMesto = value; }
        public DateTime Datum { get => datum; set => datum = value; }

        public VremenskiPodaci()
        {
            MernoMesto = "";
            Temperatura = 0;
            AtmPritisak = 0;
            VlaznostVazduha = 0;
            BrzinaVetra = 0;
            Datum = DateTime.Now;
        }

        public VremenskiPodaci(string mernoMesto, double temperatura, double atmPritisak, double vlaznostVazduha, double brzinaVetra, DateTime datum)
        {
            if (mernoMesto == null || datum == new DateTime())
                throw new ArgumentNullException("Argumenti ne smeju biti null");

            if (mernoMesto.Trim() == "")
                throw new ArgumentException("Merno mesto mora imati naziv");

            if (atmPritisak < 0)
                throw new ArgumentException("Atmosferski pritisak mora biti pozitivan");

            if (vlaznostVazduha < 0)
                throw new ArgumentException("Vlaznost vazduha mora biti pozitivna");

            if (brzinaVetra < 0)
                throw new ArgumentException("Brzina vetra mora biti pozitivna");

            if (Char.IsLower(char.Parse(mernoMesto.Substring(0, 1))))
                throw new ArgumentException("Naziv mernog mesta mora poceti velikim slovom");

            MernoMesto = mernoMesto;
            Temperatura = temperatura;
            AtmPritisak = atmPritisak;
            VlaznostVazduha = vlaznostVazduha;
            BrzinaVetra = brzinaVetra;
            Datum = datum;
        }

    }
}
