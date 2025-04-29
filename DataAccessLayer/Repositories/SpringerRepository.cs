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
    public class SpringerRepository
    {
        public static Springer GetSpringer(int id)
        {
            using (AirTimeContext context = new AirTimeContext())
            {
                return SpringerMapper.Map(context.Springere.Find(id));
            }
        }
        public static List<Springer> GetAllSpringere()
        {
            using (AirTimeContext context = new AirTimeContext())
            {
                return context.Springere.ToList().Select(SpringerMapper.Map).ToList();
            }
        }
        public static void AddSpringer(Springer springer)
        {
            using (AirTimeContext context = new AirTimeContext())
            {
                context.Springere.Add(SpringerMapper.Map(springer));
                context.SaveChanges();
            }
        }
    }
}
