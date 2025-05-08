using DataAccessLayer.Context;
using DataAccessLayer.Mappers;
using DataTransferObject.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repositories
{
    public class KonkurrenceRepository
    {
        public static Konkurrence GetKonkurrence(int id)
        {
            using (AirTimeContext context = new AirTimeContext())
            {
                return KonkurrenceMapper.Map(context.Konkurrencer.Find(id));
            }
        }
        public static List<Konkurrence> GetAllKonkurrencer()
        {
            using (AirTimeContext context = new AirTimeContext())
            {
                return context.Konkurrencer.ToList().Select(KonkurrenceMapper.Map).ToList();
            }
        }
        public static void AddKonkurrence(Konkurrence konkurrence)
        {
            using (AirTimeContext context = new AirTimeContext())
            {
                context.Konkurrencer.Add(KonkurrenceMapper.Map(konkurrence));
                context.SaveChanges();
            }
        }

        public static void TilfoejBilTilKonkurrence(int konkurrenceId, DataAccessLayer.Model.Bil bil, AirTimeContext context)
        {
            
                var konkurrence = context.Konkurrencer.Find(konkurrenceId);
                if (konkurrence != null)
                {
                    konkurrence.Biler.Add(bil);
                    context.SaveChanges();
                }
            
        }

        public static void TilfoejSpringerTilKonkurrence(int konkurrenceId, Springer springer, AirTimeContext context)
        {
            
            
                var konkurrence = context.Konkurrencer.Find(konkurrenceId);
                if (konkurrence != null)
                {
                    var dalSpringer = context.Springere.Find(springer.Id);
                    konkurrence.Springere.Add(dalSpringer);

                }
            

        }

        public static List<DataTransferObject.Model.Bil> GetAllBilerTilKonkurrence(int konkurrenceId)
        {
            using (AirTimeContext context = new AirTimeContext())
            {
                var biler = context.Konkurrencer
                            .Where(k => k.Id == konkurrenceId)
                            .SelectMany(k => k.Biler)
                            .ToList();
                return biler.Select(BilMapper.Map).ToList();
            }
        }
        public static List<DataTransferObject.Model.Springer> GetAlleSpringerTilKonkurrence(int konkurrenceId)
        {
            using (AirTimeContext context = new AirTimeContext())
            {
                var springere = context.Konkurrencer
                            .Where(k => k.Id == konkurrenceId)
                            .SelectMany(k => k.Springere)
                            .ToList();
                return springere.Select(SpringerMapper.Map).ToList();
            }
        }

        public static List<DataTransferObject.Model.Springer> GetSpringerePaaBil(int bilId, int konkurrenceId, AirTimeContext context)
        {
            // Hent alle springer-ids som deltager i konkurrencen
            var konkurrenceSpringerIds = context.Konkurrencer
                .Where(k => k.Id == konkurrenceId)
                .SelectMany(k => k.Springere.Select(s => s.Id))
                .ToHashSet();

            // Find springere som både er i bilen og deltager i konkurrencen
            var springere = context.Springere
                .Where(s => s.Biler.Any(b => b.Id == bilId))
                .Where(s => konkurrenceSpringerIds.Contains(s.Id))
                .ToList();

            return springere.Select(SpringerMapper.Map).ToList();
        }


        public static List<DataTransferObject.Model.Springer> GetSpringerePaaKonkSomIkErIBil(int konkurrenceId, AirTimeContext context)
        {
            var springereUdenBil = context.Konkurrencer
                .Where(k => k.Id == konkurrenceId)
                .SelectMany(k => k.Springere)
                .Where(s => !s.Biler.Any()) // Ingen tilknyttede biler
                .ToList();

            return springereUdenBil.Select(SpringerMapper.Map).ToList();
        }
    }
}
