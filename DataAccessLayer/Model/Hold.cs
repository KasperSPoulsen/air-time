using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Model
{
    public class Hold
    {
        public string HoldNavn { get; set; }

        public Hold(string holdNavn)
        {
            this.HoldNavn = holdNavn;
        }
    }
}
