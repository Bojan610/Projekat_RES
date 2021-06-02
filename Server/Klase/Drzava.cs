using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.Klase
{
    public class Drzava
    {
        string nazivDrzave;
        string sifraDrzave;
        string nazivMernogMesta;

        public static List<Drzava> drzave = new List<Drzava>();

        public string NazivDrzave { get => nazivDrzave; set => nazivDrzave = value; }
        public string SifraDrzave { get => sifraDrzave; set => sifraDrzave = value; }
        public string NazivMernogMesta { get => nazivMernogMesta; set => nazivMernogMesta = value; }

        public Drzava()
        {
            NazivDrzave = "";
            SifraDrzave = "";
            NazivMernogMesta = "";
        }

        public Drzava(string nazivDrzave, string sifraDrzave, string nazivMernogMesta)
        {
            this.NazivDrzave = nazivDrzave;
            this.SifraDrzave = sifraDrzave;
            this.NazivMernogMesta = nazivMernogMesta;
        }
    }
}
