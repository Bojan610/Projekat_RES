using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.Klase
{
    public interface IDrzava
    {
        string NazivDrzave { get; set; }
        string SifraDrzave { get; set; }
        string NazivMernogMesta { get; set; }
    }
}
