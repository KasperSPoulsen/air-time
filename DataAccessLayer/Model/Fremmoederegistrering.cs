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
        public DateTime Dato { get; set; }
        public Status Status { get; set; }
        public Hold Hold { get; set; }
        public Fremmoederegistrering()
        {
        }
        public Fremmoederegistrering(int id, DateTime dato, Status status, Hold hold)
        {
            Id = id;
            Dato = dato;
            Status = status;
            Hold = hold;
        }

    }
}
