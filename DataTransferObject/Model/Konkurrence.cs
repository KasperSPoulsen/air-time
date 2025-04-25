using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataTransferObject.Model
{
    public class Konkurrence
    {
        public string Adresse { get; set; }
        public string Navn { get; set; }
        public List<Springer> Springere { get; set; }
        public List<Bil> Biler { get; set; }

        public Konkurrence()
        {
        }

        public Konkurrence(string adresse, string navn, List<Springer> springere, List<Bil> biler)
        {
            Adresse = adresse;
            Navn = navn;
            Springere = springere;
            Biler = biler;
        }
    }
}
