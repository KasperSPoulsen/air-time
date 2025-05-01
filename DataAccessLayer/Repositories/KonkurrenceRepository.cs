using DataAccessLayer.Context;
using DataAccessLayer.Mappers;
using DataTransferObject.Model;
using System;
using System.Collections.Generic;
using System.Linq;
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


        public static void TilfoejSpringerTilKonkurrence(int konkurrenceId, Springer springer)
        {
            using (AirTimeContext context = new AirTimeContext())
            {
                var konkurrence = context.Konkurrencer.Find(konkurrenceId);
                if (konkurrence != null)
                {
                    DataAccessLayer.Model.Springer DALSpringer = SpringerMapper.Map(springer);
                    konkurrence.Springere.Add(DALSpringer);
                    context.SaveChanges();
                }
            }

        }
    }
}
