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
        public int Id { get; set; }
        public string Adresse { get; set; }
        public string Navn { get; set; }
        public List<Springer> Springere { get; set; }
        public List<Bil> Biler { get; set; }
        public Konkurrence()
        {
        }
        public Konkurrence(int id, string adresse, string navn, List<Springer> springere, List<Bil> biler)
        {
            Id = id;
            Adresse = adresse;
            Navn = navn;
            Springere = springere;
            Biler = biler;
        }

    }
}
