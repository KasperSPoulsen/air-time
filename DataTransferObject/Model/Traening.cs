using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataTransferObject.Model
{
    public class Traening : INotifyPropertyChanged
    {
        public DateTime Dato { get; set; }
        public int Id { get; set; }
        public Hold Hold { get; set; }
        public List<Fremmoederegistrering> Fremmoederegistreringer { get; set; } = new List<Fremmoederegistrering>();
        public Traening() { }

        public Traening(DateTime dato, Hold hold, List<Fremmoederegistrering> fremmoederegistrering)
        {
            Dato = dato;
            
            Hold = hold;
            Fremmoederegistreringer = fremmoederegistrering;
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
