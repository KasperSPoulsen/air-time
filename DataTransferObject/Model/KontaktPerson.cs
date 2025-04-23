using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataTransferObject.Model
{
    public class KontaktPerson
    {
        public int ID { get; set; }
        public string Navn { get; set; }
        public string TlfNr { get; set; }
        public string Mail { get; set; }


        public KontaktPerson(string navn, string tlfNr, string mail)
        {
            Navn = navn;
            TlfNr = tlfNr;
            Mail = mail;
        }

        public KontaktPerson()
        {
        }

    }
}
