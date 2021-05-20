using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.Model
{
    public class Filter : ValidationBase
    {
        private string drzavaFilter { get; set; }
        private DateTime pocetniDatumFilter { get; set; }
        private DateTime krajnjiDatumFilter { get; set; }

        public string DrzavaFilter
        {
            get { return drzavaFilter; }
            set
            {
                if (drzavaFilter != value)
                {
                    drzavaFilter = value;
                    OnPropertyChanged("DrzavaFilter");
                }
            }
        }

        public DateTime PocetniDatumFilter
        {
            get { return pocetniDatumFilter; }
            set
            {
                if (pocetniDatumFilter != value)
                {
                    pocetniDatumFilter = value;
                    OnPropertyChanged("PocetniDatumFilter");
                }
            }
        }

        public DateTime KrajnjiDatumFilter
        {
            get { return krajnjiDatumFilter; }
            set
            {
                if (krajnjiDatumFilter != value)
                {
                    krajnjiDatumFilter = value;
                    OnPropertyChanged("KrajnjiDatumFilter");
                }
            }
        }

        protected override void ValidateSelf()
        {
            if (string.IsNullOrWhiteSpace(this.drzavaFilter))
            {
                this.ValidationErrors["DrzavaFilter"] = "Nije izabrana drzava!";
            }
            if (this.pocetniDatumFilter == null)
            {
                this.ValidationErrors["PocetniDatumFilter"] = "Pocetni datum nije izabran!";
            }
            if (this.krajnjiDatumFilter == null)
            {
                this.ValidationErrors["KrajnjiDatumFilter"] = "Krajnji datum nije izabran!";
            }
        }
    }
}
