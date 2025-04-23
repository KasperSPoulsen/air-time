using DataAccessLayer.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repositories
{
    public class SpringerRepository
    {
        public static void OpretSpringer(string navn, DateTime foedselsdato, List<int> holdId)
        {
            using (Context context = new Context())
            {
                //Maybe throw exception if not found
                return EntityMapper.Map(context.Cars.Find(id));
            }
        }
    }
}
