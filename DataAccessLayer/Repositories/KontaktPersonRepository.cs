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
    public class KontaktPersonRepository
    {
        public static KontaktPerson GetKontaktPerson(int id)
        {
            using (AirTimeContext context = new AirTimeContext())
            {
                return KontaktPersonMapper.Map(context.KontaktPersoner.Find(id));
            }
        }
        public static List<KontaktPerson> GetAllKontaktPersoner()
        {
            using (AirTimeContext context = new AirTimeContext())
            {
                return context.KontaktPersoner.ToList().Select(KontaktPersonMapper.Map).ToList();
            }
        }
        public static void AddKontaktPerson(KontaktPerson kontaktPerson)
        {
            using (AirTimeContext context = new AirTimeContext())
            {
                context.KontaktPersoner.Add(KontaktPersonMapper.Map(kontaktPerson));
                context.SaveChanges();
            }
        }
    }
}
