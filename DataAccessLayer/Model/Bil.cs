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
        public virtual KontaktPerson KontaktPerson { get; set; }
        public virtual List<Springer> Springere { get; set; } = new List<Springer>();

        public Bil() { }

        public Bil(KontaktPerson kontaktPerson)
        {
            
            KontaktPerson = kontaktPerson;
        }


    }
}
