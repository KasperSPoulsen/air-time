using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using DataAccessLayer.Context;
using DataAccessLayer.Mappers;
using DataTransferObject.Model;
using System.Data.Entity;
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
                var mapped = FremmoederegistreringMapper.Map(fremmoederegistrering);

                // Try to find existing Springer
                var existingSpringer = context.Springere
                    .Include(s => s.KontaktPerson)
                    .FirstOrDefault(s => s.Id == mapped.Springer.Id);

                if (existingSpringer != null)
                {
                    mapped.Springer = existingSpringer;
                }

                context.Fremmoederegistreringer.Add(mapped);
                context.SaveChanges();
            }
        }

    }
}
