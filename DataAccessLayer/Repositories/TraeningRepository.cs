using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer.Context;
using DataAccessLayer.Mappers;
using DataAccessLayer.Model;
using DataTransferObject.Model;

namespace DataAccessLayer.Repositories
{
    public class TraeningRepository
    {
        // Så vi kan få en træning
        public static  DataTransferObject.Model.Traening GetTraening(int id)
        {
            using (AirTimeContext context = new AirTimeContext())
            {
                return TraeningMapper.Map(context.Traeninger.Find(id));
            }
        }
        // Liste af alle træninger
        public static List<DataTransferObject.Model.Traening> GetAlleTraeninger()
        {
            using(AirTimeContext context = new AirTimeContext())
            {
                return context.Traeninger.ToList().Select(TraeningMapper.Map).ToList();
            }
        }

        public static void AddTraening(DateTime dato, DataTransferObject.Model.Hold valgthold, List<DataTransferObject.Model.Fremmoederegistrering> fremmoederegistreringer)
        {
            using (AirTimeContext context = new AirTimeContext())
            {
                DataTransferObject.Model.Traening traening = new DataTransferObject.Model.Traening(dato, valgthold, fremmoederegistreringer);
                context.Traeninger.Add(TraeningMapper.Map(traening));
                context.SaveChanges();
            }
        }


        public static DataTransferObject.Model.Traening GetSenesteTraening()
        {
            using (AirTimeContext context = new AirTimeContext())
            {
                var seneste = context.Traeninger
                    .OrderByDescending(t => t.Dato) // får nyeste træning på dato
                    .FirstOrDefault(); // null check

                return TraeningMapper.Map(seneste);
            }
        }

        public static DataTransferObject.Model.Traening GetTilmeldte()
        {
            using (AirTimeContext context = new AirTimeContext())
            {
                var seneste = context.Traeninger
                    .OrderByDescending (t => t.Dato)
                    .OrderByDescending(t => t.Fremmoederegistreringer) // får antal fremmødte
                    .FirstOrDefault(); 

                return TraeningMapper.Map(seneste);
            }
        }
    }
}
