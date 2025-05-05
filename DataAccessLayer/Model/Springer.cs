using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Model
{
    public class Springer
    {
        public int Id { get; set; }
        public string Navn { get; set; }
        public virtual List<string> KonkurrenceSerie { get; set; } = new List<string>();
        public DateTime? Foedselsdato { get; set; }
        public string TraeningsMaal { get; set; }
        public virtual KontaktPerson KontaktPerson { get; set; }
        public virtual List<Hold> Hold { get; set; } = new List<Hold>();
        public Springer()
        {
        }
        public Springer(string navn, DateTime? foedselsdato, KontaktPerson kontaktPerson, List<Hold> hold)
        {
            Navn = navn;
            Foedselsdato = foedselsdato;
            KontaktPerson = kontaktPerson;
            Hold = hold;

        }

        public Springer(string navn, DateTime? foedselsdato, KontaktPerson kontaktPerson)
        {

            Navn = navn;
            Foedselsdato = foedselsdato;
            KontaktPerson = kontaktPerson;

        }
    }
}
