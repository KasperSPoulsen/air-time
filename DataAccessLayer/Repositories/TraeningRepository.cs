using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer.Context;
using DataAccessLayer.Mappers;
using DataTransferObject.Model;

namespace DataAccessLayer.Repositories
{
    public class TraeningRepository
    {
        // Så vi kan få en træning
        public static Traening GetTraening(int id)
        {
            using (AirTimeContext context = new AirTimeContext())
            {
                return TraeningMapper.Map(context.Traeninger.Find(id));
            }
        }
        // Liste af alle træninger
        public static List<Traening> GetAlleTraeninger()
        {
            using(AirTimeContext context = new AirTimeContext())
            {
                return context.Traeninger.ToList().Select(TraeningMapper.Map).ToList();
            }
        }

        public static void AddTraening(Traening traening)
        {
            using (AirTimeContext context = new AirTimeContext())
            {
                context.Traeninger.Add(TraeningMapper.Map(traening));
                context.SaveChanges();
            }
        }
    }
}
