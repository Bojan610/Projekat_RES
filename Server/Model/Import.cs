using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.Model
{
    public class Import : ValidationBase
    {
        private string drzava { get; set; }
        private DateTime pocetniDatum { get; set; }
        private DateTime krajnjiDatum { get; set; }
        private string fajlPotrosnja { get; set; }
        private string fajlVreme { get; set; }

        public string Drzava
        {
            get { return drzava; }
            set
            {
                if (drzava != value)
                {
                    drzava = value;
                    OnPropertyChanged("Drzava");
                }
            }
        }

        public DateTime PocetniDatum
        {
            get { return pocetniDatum; }
            set
            {
                if (pocetniDatum != value)
                {
                    pocetniDatum = value;
                    OnPropertyChanged("PocetniDatum");
                }
            }
        }

        public DateTime KrajnjiDatum
        {
            get { return krajnjiDatum; }
            set
            {
                if (krajnjiDatum != value)
                {
                    krajnjiDatum = value;
                    OnPropertyChanged("KrajnjiDatum");
                }
            }
        }

        public string FajlPotrosnja
        {
            get { return fajlPotrosnja; }
            set
            {
                if (fajlPotrosnja != value)
                {
                    fajlPotrosnja = value;
                    OnPropertyChanged("FajlPotrosnja");
                }
            }
        }

        public string FajlVreme
        {
            get { return fajlVreme; }
            set
            {
                if (fajlVreme != value)
                {
                    fajlVreme = value;
                    OnPropertyChanged("FajlVreme");
                }
            }
        }

        protected override void ValidateSelf()
        {
            if (string.IsNullOrWhiteSpace(this.drzava))
            {
                this.ValidationErrors["Drzava"] = "Nije izabrana drzava!";
            }
            if (this.pocetniDatum == null)
            {
                this.ValidationErrors["PocetniDatum"] = "Pocetni datum nije izabran!";
            }
            if (this.krajnjiDatum == null)
            {
                this.ValidationErrors["KrajnjiDatum"] = "Krajnji datum nije izabran!";
            }
            if (string.IsNullOrWhiteSpace(this.fajlPotrosnja))
            {
                this.ValidationErrors["FajlPotrosnja"] = "Nije ucitan file o potrosnji!";
            }
            if (string.IsNullOrWhiteSpace(this.fajlVreme))
            {
                this.ValidationErrors["FajlVreme"] = "Nije ucitan file o vremenskim prilikama!";
            }
        }
    }
}
