using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfProjekat.Klase
{
    public class Drzava
    {
        private string ime;
        private string sifraDrzave;
        private string mernoMesto;

        public Drzava(string ime, string sifraDrzave, string mernoMesto)
        {
            this.Ime = ime;
            this.SifraDrzave = sifraDrzave;
            this.MernoMesto = mernoMesto;
        }

        public string Ime { get => ime; set => ime = value; }
        public string SifraDrzave { get => sifraDrzave; set => sifraDrzave = value; }
        public string MernoMesto { get => mernoMesto; set => mernoMesto = value; }
    }
}
