using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataTransferObject.Model
{
    public class Springer
    {
        public string Navn { get; set; }
        public List<string> KonkurrenceSerie { get; set; } 
        public DateTime Foedselsdato { get; set; }
        public string TraeningsMaal { get; set; }
    }
}
