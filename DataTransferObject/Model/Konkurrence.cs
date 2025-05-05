using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataTransferObject.Model
{
    public class Konkurrence
    {
        public int Id { get; set; }
        public string Adresse { get; set; }
        public string Navn { get; set; }
        public DateTime Dato { get; set; }

        public List<Springer> Springere { get; set; } = new List<Springer>();
        public List<Bil> Biler { get; set; } = new List<Bil>();


        public Konkurrence()
        {
        }

        public Konkurrence(string adresse, string navn, DateTime dato)
        {
            
            Adresse = adresse;
            Navn = navn;
            Dato = dato;
        }
    }
}
