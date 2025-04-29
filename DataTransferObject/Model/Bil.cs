using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataTransferObject.Model
{
    public class Bil
    {
        public KontaktPerson KontaktPerson { get; set; }
        public List<Springer> Springere { get; set; }
        public Konkurrence Konkurrence { get; set; }
        public int Id { get; set; }
        public Bil() { }

        public Bil(int id, KontaktPerson kontaktPerson, List<Springer> springere, Konkurrence konkurrence)
        {
            KontaktPerson = kontaktPerson;
            Springere = springere;
            Konkurrence = konkurrence;
            Id = id;
        }
    }
}
