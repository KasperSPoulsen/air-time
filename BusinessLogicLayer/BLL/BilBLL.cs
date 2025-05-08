using DataTransferObject.Model;
using DataAccessLayer.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer.Context;


namespace BusinessLogicLayer.BLL
{
    public class BilBLL
    {
        public Bil getBil(int id)
        {
            if (id < 0) throw new IndexOutOfRangeException();
            return BilRepository.getBil(id);
        }

        public List<Bil> GetAllBiler()
        {
            return BilRepository.GetAllBiler();
        }


        public void CreateBil(KontaktPerson kontaktPerson, Konkurrence konkurrence)
        {
            using (AirTimeContext context = new AirTimeContext())
            {
                if (kontaktPerson == null) throw new ArgumentNullException(nameof(kontaktPerson));

                var DALkontaktPerson = KontaktPersonRepository.GetDALKontaktPerson(kontaktPerson.Navn, kontaktPerson.TlfNr, kontaktPerson.Mail, context);


                DataAccessLayer.Model.Bil bil = new DataAccessLayer.Model.Bil(DALkontaktPerson);
               
                
                KonkurrenceRepository.TilfoejBilTilKonkurrence(konkurrence.Id, bil, context);
                context.SaveChanges();
            }
                
        }

        public void SletBil(int id)
        {
            BilRepository.SletBil(id);
        }

        public static void TilfoejSpringerTilBil(int bilId, List<Springer> valgteSpringere)
        {
            using (AirTimeContext context = new AirTimeContext())
            {
                BilRepository.TilfoejSpringerTilBil(bilId, valgteSpringere, context);
                context.SaveChanges();

            }
        }

        public static void OpdaterSpringerIBil(List<Springer> springereIBil, List<Springer> springereIkIBil, int bilId, int konkurrenceId)
        {
            using (AirTimeContext context = new AirTimeContext())
            {
                
                BilRepository.OpdatereSpringerIBil(springereIBil, springereIkIBil, bilId, konkurrenceId, context);
                context.SaveChanges();
            }
        }

    }
}