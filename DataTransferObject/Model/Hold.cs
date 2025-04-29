using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataTransferObject.Model
{
    public class Hold
    {
        public int Id { get; set; }
        public string HoldNavn { get; set; }
        public Hold()
        {
        }

        public Hold(int id ,string holdNavn)
        {
            Id = id;
            HoldNavn = holdNavn;
        }
    }
}
