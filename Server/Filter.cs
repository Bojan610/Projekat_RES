using Server.Klase;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server
{
    public class Filter
    {
        public Filter()
        {

        }

        public BindingList<TabelaPodaci> FiltriranjePodataka(IDrzava d, DateTime pocetni, DateTime krajnji)
        {
            BindingList<TabelaPodaci> ret = new BindingList<TabelaPodaci>();
            Data data = new Data();
            List<TabelaPodaci> pom = data.UcitavanjeTabele("C:\\Users\\PC\\Desktop\\resProjekat\\Projekat_RES-master\\Server\\ulazni_podaci\\tabela.csv");

            if (d == null || pocetni == new DateTime() || krajnji == new DateTime())
                throw new ArgumentNullException("Argumenti ne smeju biti null");
            
            foreach (var item in pom)
            {
                if (d.NazivDrzave == item.NazivDrzave && item.UctVreme >= pocetni && item.UctVreme <= krajnji)
                {
                    ret.Add(item);
                }
            }

            return ret;
        }
        
    }
}
