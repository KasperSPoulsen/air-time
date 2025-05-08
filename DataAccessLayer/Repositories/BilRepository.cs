using DataAccessLayer.Context;
using DataAccessLayer.Mappers;
using DataAccessLayer.Model;
using DataTransferObject.Model;


using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace DataAccessLayer.Repositories
{
    public class BilRepository
    {
        public static DataTransferObject.Model.Bil getBil(int id)
        {
            using (AirTimeContext context = new AirTimeContext())
            {
                return BilMapper.Map(context.Biler.Find(id));
            }
        }

        public static List<DataTransferObject.Model.Bil> GetAllBiler()
        {
            using (AirTimeContext context = new AirTimeContext())
            {
                return context.Biler.Select(BilMapper.Map).ToList();
            }
        }


        public static void SletBil(int id)
        {
            using (AirTimeContext context = new AirTimeContext())
            {
                var bil = context.Biler.Find(id);
                if (bil != null)
                {
                    context.Biler.Remove(bil);
                    context.SaveChanges();
                }
            }
        }

        public static void OpdatereSpringerIBil(List<DataTransferObject.Model.Springer> springereIBil, List<DataTransferObject.Model.Springer> springereIkIBil, int bilId, int konkurrenceId, AirTimeContext context)
        {

                // Hent bilen med dens tilknyttede springere
                var bil = context.Biler
                    .Include(b => b.Springere)
                    .FirstOrDefault(b => b.Id == bilId);

                if (bil == null) return;

                // Fjern alle springere fra bilen
                bil.Springere.Clear();
                context.SaveChanges();

                // Uddrag kun Id'er fra DTO-listen
                var springerIds = springereIBil.Select(sp => sp.Id).ToList();

                // Hent de rigtige springer-entiteter fra databasen og tilføj dem til bilen
                var springereTilBil = context.Springere
                    .Where(s => springerIds.Contains(s.Id))
                    .ToList();

                foreach (var springer in springereTilBil)
                {
                    bil.Springere.Add(springer);
                }

                // Hent springere der skal fjernes fra denne bil (hvis de stadig er tilknyttet)
                var springerIkIds = springereIkIBil.Select(sp => sp.Id).ToList();

                var springereFraBil = context.Springere
                    .Include(s => s.Biler)
                    .Where(s => springerIkIds.Contains(s.Id))
                    .ToList();

                foreach (var springer in springereFraBil)
                {
                    var bilToRemove = springer.Biler.FirstOrDefault(b => b.Id == bilId);
                    if (bilToRemove != null)
                    {
                        springer.Biler.Remove(bilToRemove);
                    }
                

                
            }
        }



        public static void TilfoejSpringerTilBil(int bilId, List<DataTransferObject.Model.Springer> valgteSpringere, AirTimeContext context)
        {
            var bil = context.Biler.Find(bilId);
            if (bil != null)
            {
                foreach (var springer in valgteSpringere)
                {
                    var dalSpringer = context.Springere.Find(springer.Id);
                    bil.Springere.Add(dalSpringer);
                }
                
            }
        }
    }
}
