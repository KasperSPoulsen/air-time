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
        public static List<Springer> GetAllSpringere(AirTimeContext context)
        {
            
                return SpringerMapper.Map(context.Springere.ToList());
            
        }
        public static void AddSpringer(Springer springer, AirTimeContext context)
        {
            
                context.Springere.Add(SpringerMapper.Map(springer));
                
            
        }
    }
}
