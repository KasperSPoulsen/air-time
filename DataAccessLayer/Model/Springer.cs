using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Model
{
    public class Springer
    {
        public int ID { get; set; }
        public string Navn { get; set; }
        public List<string> KonkurrenceSerie { get; set; } = new List<string>();
        public DateTime Foedselsdato { get; set; }
        public string TraeningsMaal { get; set; }
        public KontaktPerson KontaktPerson { get; set; }

        public Springer(string navn, DateTime foedselsdato)
        {
            Navn = navn;
            Foedselsdato = foedselsdato;
            
        }

        public Springer()
        {
        }
    }
}
