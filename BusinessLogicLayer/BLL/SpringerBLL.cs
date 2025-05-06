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
                return SpringerRepository.GetAllSpringere(context).ToList();
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

        public static void UpdateSpringer(DataTransferObject.Model.Springer updatedSpringer)
        {
            if (updatedSpringer == null || updatedSpringer.Id <= 0)
                throw new ArgumentException("Invalid springer.");

            using (var context = new AirTimeContext())
            {
                var existingSpringer = context.Springere.FirstOrDefault(s => s.Id == updatedSpringer.Id);

                if (existingSpringer == null)
                    throw new InvalidOperationException("Springer not found.");

                existingSpringer.Navn = updatedSpringer.Navn;
                existingSpringer.Foedselsdato = updatedSpringer.Foedselsdato;
                existingSpringer.TraeningsMaal = updatedSpringer.TraeningsMaal;

                if (existingSpringer.KontaktPerson != null && updatedSpringer.KontaktPerson != null)
                {
                    existingSpringer.KontaktPerson.Navn = updatedSpringer.KontaktPerson.Navn;
                    existingSpringer.KontaktPerson.TlfNr = updatedSpringer.KontaktPerson.TlfNr;
                    existingSpringer.KontaktPerson.Mail = updatedSpringer.KontaktPerson.Mail;
                }

                existingSpringer.KonkurrenceSerie = string.Join(", ", updatedSpringer.KonkurrenceSerieList);

                existingSpringer.Hold.Clear();
                var newHolds = HoldRepository.GetDALHold(updatedSpringer.Hold.Select(h => h.HoldNavn).ToList(), context);
                foreach (var hold in newHolds)
                {
                    context.Entry(hold).State = System.Data.Entity.EntityState.Unchanged; // tell EF not to re-insert
                    existingSpringer.Hold.Add(hold);
                }

                context.SaveChanges();
            }
        }


    }
}