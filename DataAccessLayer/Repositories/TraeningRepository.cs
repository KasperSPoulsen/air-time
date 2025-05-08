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

        public static void AddTraening(DateTime dato, int holdId, List<DataTransferObject.Model.Fremmoederegistrering> fremmoederegistreringer)
        {
            using (AirTimeContext context = new AirTimeContext())
            {
                var dalFremmoedeRegistreringer = new List<DataAccessLayer.Model.Fremmoederegistrering>();

                foreach (var dtoReg in fremmoederegistreringer)
                {
                    var springer = context.Springere.Find(dtoReg.Springer.Id); // brug eksisterende
                    if (springer == null) continue;

                    var dalReg = new DataAccessLayer.Model.Fremmoederegistrering
                    {
                        Springer = springer,
                        MoedeStatus = StatusMapper.Map(dtoReg.MoedeStatus)
                    };

                    dalFremmoedeRegistreringer.Add(dalReg);
                }

                var traening = new DataAccessLayer.Model.Traening
                {
                    Dato = dato,
                    Hold = context.Hold.Find(holdId), // brug eksisterende fra DB
                    Fremmoederegistreringer = dalFremmoedeRegistreringer
                };

                context.Traeninger.Add(traening);
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
