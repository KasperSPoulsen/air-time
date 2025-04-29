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
    public class FremmoederegisteringRepository
    {
        public static Fremmoederegistrering GetFremmoederegistering(int id)
        {
            using (AirTimeContext context = new AirTimeContext())
            {
                return FremmoederegistreringMapper.Map(context.Fremmoederegistreringer.Find(id));
            }
        }
        public static List<Fremmoederegistrering> GetAllFremmoederegisteringer()
        {
            using (AirTimeContext context = new AirTimeContext())
            {
                return context.Fremmoederegistreringer.ToList().Select(FremmoederegistreringMapper.Map).ToList();
            }
        }
        public static void AddFremmoederegistrering(Fremmoederegistrering fremmoederegistrering)
        {
            using (AirTimeContext context = new AirTimeContext())
            {
                context.Fremmoederegistreringer.Add(FremmoederegistreringMapper.Map(fremmoederegistrering));
                context.SaveChanges();
            }
        }
        
    }
}
