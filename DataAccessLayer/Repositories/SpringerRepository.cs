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
        public static List<DataTransferObject.Model.Springer> GetSpringerFromHold(int holdID, AirTimeContext context)
        {
            // Get the springere associated with the holdID
            var springereFromHold = context.Springere
                .Where(springer => springer.Hold.Any(hold => hold.Id == holdID))
                .ToList(); // Now it's a List of DataAccessLayer.Model.Springer

            // Map the DataAccessLayer.Model.Springer to DataTransferObject.Model.Springer
            // and return the mapped list directly
            return springereFromHold.Select(springer => SpringerMapper.Map(springer)).ToList();
        }


    }
}
