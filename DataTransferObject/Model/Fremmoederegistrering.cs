using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataTransferObject.Model
{
    public class Fremmoederegistrering
    {
        public int Id { get; set; }
        public Status MoedeStatus { get; set; }
        public Springer Springer { get; set; }

        public Fremmoederegistrering()
        {
        }
        public Fremmoederegistrering(Status MoedeStatus, Springer springer)
        {
            
            this.MoedeStatus = MoedeStatus;
            this.Springer = springer;
        }
    }
}
