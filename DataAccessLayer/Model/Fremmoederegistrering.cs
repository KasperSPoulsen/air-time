using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Model
{
    public class Fremmoederegistrering
    {
        public DateTime Dato { get; set; }
        public Status Status { get; set; }
        public Hold Hold { get; set; }

        public Fremmoederegistrering(DateTime dato, Status status, Hold hold)
        {
            Dato = dato;
            Status = status;
            Hold = hold;
        }

    }
}
