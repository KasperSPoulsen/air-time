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
        public List<string> KonkurrenceSerie { get; set; } = new List<string>();
        public DateTime Foedselsdato { get; set; }
        public string TraeningsMaal { get; set; }
        public KontaktPerson KontaktPerson { get; set; }
        public List<Hold> Hold { get; set; } = new List<Hold>();
        public Springer()
        {
        }
        public Springer(int id, string navn, DateTime foedselsdato, KontaktPerson kontaktPerson, List<Hold> hold)
        {
            Id = id;
            Navn = navn;
            Foedselsdato = foedselsdato;
            KontaktPerson = kontaktPerson;
            Hold = hold;

        }
    }
}
