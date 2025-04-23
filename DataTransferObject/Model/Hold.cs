using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataTransferObject.Model
{
    public class Hold
    {
        public int ID { get; set; }
        public string HoldNavn { get; set; }

        public List<Springer> Springere { get; set; } = new List<Springer>();
        public List<Fremmoederegistrering> Fremmoederegistreringer { get; set; } = new List<Fremmoederegistrering>();

        public Hold()
        {

        }

        public Hold(string holdNavn)
        {
            HoldNavn = holdNavn;
            Fremmoederegistreringer = new List<Fremmoederegistrering>();
        }
    }
}
