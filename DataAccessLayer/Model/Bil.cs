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
        public int Id { get; set; }
        public KontaktPerson KontaktPerson { get; set; }
        public List<Springer> Springere { get; set; }
        public Konkurrence Konkurrence { get; set; }

        public Bil() { }

        public Bil(int id, KontaktPerson kontaktPerson, List<Springer> springere, Konkurrence konkurrence)
        {
            Id = id;
            KontaktPerson = kontaktPerson;
            Springere = springere;
            Konkurrence = konkurrence;
        }
    }
}
