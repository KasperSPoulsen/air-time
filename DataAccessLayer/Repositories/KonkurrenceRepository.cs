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
            // Find bilen via konkurrence (da bil ikke kender konkurrence)
            var bil = context.Konkurrencer
                .Where(k => k.Id == konkurrenceId)
                .SelectMany(k => k.Biler)
                .FirstOrDefault(b => b.Id == bilId);

            if (bil == null) return new List<DataTransferObject.Model.Springer>();

            // Find springere, som har samme kontaktperson og deltager i samme konkurrence
            var springere = context.Konkurrencer
                .Where(k => k.Id == konkurrenceId)
                .SelectMany(k => k.Springere)
                .Where(s => s.KontaktPerson.Id == bil.KontaktPerson.Id)
                .ToList();

            return springere.Select(SpringerMapper.Map).ToList();
        }


        public static List<DataTransferObject.Model.Springer> GetSpringerePaaKonkSomIkErIBil(int konkId, AirTimeContext context)
        {
            var springere = context.Konkurrencer
                .Where(k => k.Id == konkId)
                .SelectMany(k => k.Springere)
                .ToList();
            // Find biler, som har samme kontaktperson og deltager i samme konkurrence
            var biler = context.Konkurrencer
                .Where(k => k.Id == konkId)
                .SelectMany(k => k.Biler)
                .ToList();
            var springereIkkeIBil = springere.Where(s => !biler.Any(b => b.KontaktPerson.Id == s.KontaktPerson.Id)).ToList();
            return springereIkkeIBil.Select(SpringerMapper.Map).ToList();
        }
    }
}
