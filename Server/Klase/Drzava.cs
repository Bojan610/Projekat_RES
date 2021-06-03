using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.Klase
{
    public class Drzava : IDrzava
    {
        public string NazivDrzave { get; set; }
        public string SifraDrzave { get; set; }
        public string NazivMernogMesta { get; set; }

        public static List<Drzava> drzave = new List<Drzava>();

        public Drzava()
        {
            NazivDrzave = "";
            SifraDrzave = "";
            NazivMernogMesta = "";
        }

        public Drzava(string nazivDrzave, string sifraDrzave, string nazivMernogMesta)
        {
            if (nazivDrzave == null || sifraDrzave == null || nazivMernogMesta == null)
                throw new ArgumentNullException("Argumenti ne smeju biti null");

            if (nazivDrzave.Trim() == "")
                throw new ArgumentException("Naziv drzave mora da sadrzi karaktere");

            if (sifraDrzave.Trim() == "")
                throw new ArgumentException("Sifra drzave mora da sadrzi karaktere");

            if (nazivMernogMesta.Trim() == "")
                throw new ArgumentException("Naziv mernog mesta mora da sadrzi karaktere");

            if (Char.IsLower(char.Parse(nazivDrzave.Substring(0, 1))))
                throw new ArgumentException("Naziv drzave mora poceti velikim slovom");

            if (Char.IsLower(char.Parse(nazivMernogMesta.Substring(0, 1))))
                throw new ArgumentException("Naziv mernog mesta mora poceti velikim slovom");

            if (Char.IsLower(char.Parse(sifraDrzave.Substring(0, 1))) || Char.IsLower(char.Parse(sifraDrzave.Substring(1, 1))))
                throw new ArgumentException("Sifra drzave sadrzi samo velika slova");

            if (sifraDrzave.Count() != 2)
                throw new ArgumentException("Sifra drzave mora imati tacno 2 znaka");

            this.NazivDrzave = nazivDrzave;
            this.SifraDrzave = sifraDrzave;
            this.NazivMernogMesta = nazivMernogMesta;
        }

    }
}
