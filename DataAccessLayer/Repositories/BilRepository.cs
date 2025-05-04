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
    public class BilRepository
    {
        public static Bil getBil(int id)
        {
            using (AirTimeContext context = new AirTimeContext())
            {
                return BilMapper.Map(context.Biler.Find(id));
            }
        }

        public static List<Bil> GetAllBiler()
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
    }
}
