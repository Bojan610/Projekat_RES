using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.Klase
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
            if (uctVreme == new DateTime() || nazivDrzave == null || sifraDrzave == null)
                throw new ArgumentNullException("Argumenti ne smeju biti null");

            if (nazivDrzave.Trim() == "")
                throw new ArgumentException("Naziv drzave mora da sadrzi karaktere");

            if (sifraDrzave.Trim() == "")
                throw new ArgumentException("Sifra drzave mora da sadrzi karaktere");

            if (kolicinaEnergije < 0)
                throw new ArgumentException("Kolicina potrosene energije ne moze biti negativna");

            if (Char.IsLower(char.Parse(nazivDrzave.Substring(0, 1))))
                throw new ArgumentException("Naziv drzave mora poceti velikim slovom");

            if (Char.IsLower(char.Parse(sifraDrzave.Substring(0, 1))) || Char.IsLower(char.Parse(sifraDrzave.Substring(1, 1))))
                throw new ArgumentException("Sifra drzave sadrzi samo velika slova");

            if (sifraDrzave.Count() != 2)
                throw new ArgumentException("Sifra drzave mora imati tacno 2 znaka");


            NazivDrzave = nazivDrzave;
            SifraDrzave = sifraDrzave;
            UctVreme = uctVreme;
            KolicinaEnergije = kolicinaEnergije;
        }

    }
}
