using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Model
{
    public class Springer
    {
        public string Navn { get; set; }
        public List<string> KonkurrenceSerie { get; set; } 
        public DateTime Foedselsdato { get; set; }
        public string TraeningsMaal { get; set; }
        public KontaktPerson KontaktPerson { get; set; }

        public Springer(string navn, List<string> konkurrenceSerie, DateTime foedselsdato, string traeningsMaal, KontaktPerson kontaktPerson)
        {
            Navn = navn;
            KonkurrenceSerie = konkurrenceSerie;
            Foedselsdato = foedselsdato;
            TraeningsMaal = traeningsMaal;
            KontaktPerson = kontaktPerson;
        }
    }
}
