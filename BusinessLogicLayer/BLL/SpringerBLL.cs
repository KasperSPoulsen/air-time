using DataTransferObject.Model;
using DataAccessLayer.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer.Context;
using DataAccessLayer.Mappers;

namespace BusinessLogicLayer.BLL
{
    public class SpringerBLL
    {
        public Springer getSpringer(int id)
        {
            if (id < 0) throw new IndexOutOfRangeException();
            return SpringerRepository.GetSpringer(id);
        }

        public static List<Springer> GetAllSpringere()
        {
            using (var context = new AirTimeContext())
            {
                return SpringerRepository.GetAllSpringere(context);
            }
               
        }

        public List<Springer> GetSpringerFromHold()
        {
            using (var context = new AirTimeContext())
            {
                return SpringerRepository.GetAllSpringere(context);
            }
        }


    

        public static DataTransferObject.Model.Springer CreateSpringer(string navn, DateTime? foedselsdato, string kontaktNavn, string kontaktTelefon, string kontaktEmail, List<string> holdNavne)
        {
            if (string.IsNullOrWhiteSpace(navn) ||
                string.IsNullOrWhiteSpace(kontaktNavn) ||
                string.IsNullOrWhiteSpace(kontaktTelefon) ||
                string.IsNullOrWhiteSpace(kontaktEmail) ||
                foedselsdato == null ||
                holdNavne == null || 
                holdNavne.Count == 0)
            {
                throw new ArgumentException("Ugyldige inputværdier.");
            }

            using (var context = new AirTimeContext())
            {
                var kontaktPerson = KontaktPersonRepository.GetDALKontaktPerson(kontaktNavn, kontaktTelefon, kontaktEmail, context);
                if (kontaktPerson == null)
                {
                    kontaktPerson = new DataAccessLayer.Model.KontaktPerson(kontaktNavn, kontaktTelefon, kontaktEmail);
                }

                List<DataAccessLayer.Model.Hold> efHold = HoldRepository.GetDALHold(holdNavne, context); // EF-entity objekter fra samme context

                var springer = new DataAccessLayer.Model.Springer(navn, foedselsdato, kontaktPerson, efHold);

                context.Springere.Add(springer);
                context.SaveChanges();


                return new DataTransferObject.Model.Springer(navn, foedselsdato, KontaktPersonMapper.Map(kontaktPerson), HoldMapper.Map(efHold));
            }

            
                             
        }

    }
}