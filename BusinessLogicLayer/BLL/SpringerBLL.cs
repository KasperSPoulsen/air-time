using DataTransferObject.Model;
using DataAccessLayer.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.BLL
{
    public class SpringerBLL
    {
        public Springer getSpringer(int id)
        {
            if (id < 0) throw new IndexOutOfRangeException();
            return SpringerRepository.GetSpringer(id);
        }

        public List<Springer> GetAllSpringere()
        {
            return SpringerRepository.GetAllSpringere();
        }


    

        public static void CreateSpringer(string navn, DateTime foedselsdato, string kontaktNavn, string kontaktTelefon, string kontaktEmail, List<string> holdnavne)
        {
            if (string.IsNullOrWhiteSpace(navn) || string.IsNullOrWhiteSpace(kontaktNavn) || string.IsNullOrWhiteSpace(kontaktTelefon) || string.IsNullOrWhiteSpace(kontaktEmail) || foedselsdato == null || hold.Count == 0)
            {
                throw new ArgumentException();
            } else
            {
                KontaktPerson kontaktPerson = new KontaktPerson(kontaktNavn, kontaktTelefon, kontaktEmail);
                List<Hold> DTOhold = HoldRepository.GetHold(holdnavne);
                
                Springer springer = new Springer(navn, foedselsdato, kontaktPerson, null /*her skal istedet være en liste af DTO hold*/);
                SpringerRepository.AddSpringer(springer);
            }
               
        }

    }
}