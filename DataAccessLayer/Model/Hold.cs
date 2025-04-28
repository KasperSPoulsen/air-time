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
        public Hold()
        {
        }
        public Hold(int id, string holdNavn)
        {
            Id = id;
            this.HoldNavn = holdNavn;
        }
    }
}
