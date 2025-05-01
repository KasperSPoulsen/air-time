using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Model
{
    public class Hold
    {
        public int Id { get; set; }
        public string HoldNavn { get; set; }
        public virtual List<Springer> Springere { get; set; } =  new List<Springer>();
        public virtual List<Traening> Traeninger { get; set; } = new List<Traening>();
        public Hold()
        {
        }
        public Hold(string holdNavn)
        {
            
            HoldNavn = holdNavn;
        }
    }
}
