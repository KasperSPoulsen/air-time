using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Model
{
    public class KontaktPerson
    {
        public int Id { get; set; }
        public string Navn { get; set; }
        public string TlfNr { get; set; }
        public string Mail { get; set; }

        public KontaktPerson()
        {
        }
        public KontaktPerson(int id, string navn, string tlfNr, string mail)
        {
            Id = id;
            Navn = navn;
            TlfNr = tlfNr;
            Mail = mail;
        }

    }
}
