using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Model
{
    public class Fremmoederegistrering
    {
        public int Id { get; set; }
        public Status MoedeStatus { get; set; }
        public Springer Springer { get; set; }
        public Fremmoederegistrering() {}
        public Fremmoederegistrering(int id, Status MoedeStatus, Springer springer)
        {
            Id = id;
            this.MoedeStatus = MoedeStatus;
            this.Springer = springer;
        }

    }
}
