using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Model
{
    public class Traening
    {
        public DateTime Dato {  get; set; }
        public int Id { get; set; }
        public Hold Hold { get; set; }
        public List<Fremmoederegistrering> Fremmoederegistreringer { get; set; } = new List<Fremmoederegistrering>();
        public Traening() { }

        public Traening(DateTime dato, int id, Hold hold,List<Fremmoederegistrering> fremmoederegistrering)
        {
            Dato = dato;
            Id = id;
            Hold = hold;
            Fremmoederegistreringer = fremmoederegistrering;
        }
    }
}
