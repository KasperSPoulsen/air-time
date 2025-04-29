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
        public List<Springer> Springere { get; set; } = new List<Springer>();

        public Bil() { }

        public Bil(int id, KontaktPerson kontaktPerson)
        {
            Id = id;
            KontaktPerson = kontaktPerson;
        }


    }
}
