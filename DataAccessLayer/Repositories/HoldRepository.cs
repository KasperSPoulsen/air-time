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
    public class HoldRepository
    {
        public static Hold GetHold(int id)
        {
            using (AirTimeContext context = new AirTimeContext())
            {
                return HoldMapper.Map(context.Hold.Find(id));
            }
        }
        public static List<Hold> GetAllHold()
        {
            using (AirTimeContext context = new AirTimeContext())
            {
                return context.Hold.Select(HoldMapper.Map).ToList();
            }
        }
        public static void AddHold(Hold hold)
        {
            using (AirTimeContext context = new AirTimeContext())
            {
                context.Hold.Add(HoldMapper.Map(hold));
                context.SaveChanges();
            }
        }
    }
}
