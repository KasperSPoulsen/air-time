using DataTransferObject.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Model
{
    public class Konkurrence
    {
        public int ID { get; set; }
        public string Adresse { get; set; }
        public string Navn { get; set; }
        public List<Springer> Springere { get; set; } = new List<Springer>();
        public List<Bil> Biler { get; set; } = new List<Bil>();



        public Konkurrence(string adresse, string navn, List<Springer> springere, List<Bil> biler)
        {
            Adresse = adresse;
            Navn = navn;
            Springere = springere;
            Biler = biler;
        }

        public Konkurrence()
        {
        }
    }
}
