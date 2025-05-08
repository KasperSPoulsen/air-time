using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace DataTransferObject.Model
{
    public class Springer
    {
        public int Id { get; set; }
        public string Navn { get; set; }
        public string KonkurrenceSerie { get; set; } 

        [NotMapped]
        public List<string> KonkurrenceSerier { get; set; } = new List<string>();

        public DateTime? Foedselsdato { get; set; }
        public string TraeningsMaal { get; set; }
        public KontaktPerson KontaktPerson { get; set; }
        public List<Hold> Hold { get; set; } = new List<Hold>();
        


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
