using DataTransferObject.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Model
{
    public class Bil
    {
        public KontaktPerson KontaktPerson { get; set; }
        public List<Springer> Springere { get; set; }
        public Konkurrence Konkurrence { get; set; }

        public Bil(KontaktPerson kontaktPerson, List<Springer> springere, Konkurrence konkurrence)
        {
            KontaktPerson = kontaktPerson;
            Springere = springere;
            Konkurrence = konkurrence;
        }
    }
}
