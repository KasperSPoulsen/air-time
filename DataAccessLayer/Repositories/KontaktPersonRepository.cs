using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer.Context;
using DataAccessLayer.Mappers;
using DataTransferObject.Model;
using DataAccessLayer.Model;
namespace DataAccessLayer.Repositories
{
    public class KontaktPersonRepository
    {
        public static DataTransferObject.Model.KontaktPerson GetKontaktPerson(int id)
        {
            using (AirTimeContext context = new AirTimeContext())
            {
                return KontaktPersonMapper.Map(context.KontaktPersoner.Find(id));
            }
        }
        public static List<DataTransferObject.Model.KontaktPerson> GetAllKontaktPersoner()
        {
            using (AirTimeContext context = new AirTimeContext())
            {
                return context.KontaktPersoner.ToList().Select(KontaktPersonMapper.Map).ToList();
            }
        }
        /*public static void AddKontaktPerson(KontaktPerson kontaktPerson)
        {
            using (AirTimeContext context = new AirTimeContext())
            {
                context.KontaktPersoner.Add(KontaktPersonMapper.Map(kontaktPerson));
                context.SaveChanges();
            }
        }*/


        public static DataTransferObject.Model.KontaktPerson GetDTOKontaktPerson(string kontaktNavn, string kontaktTelefon, string kontaktEmail, AirTimeContext context)
        {
            DataAccessLayer.Model.KontaktPerson kontaktperson = context.KontaktPersoner.FirstOrDefault(k =>
            k.Navn == kontaktNavn &&
            k.TlfNr == kontaktTelefon &&
            k.Mail == kontaktEmail);
            if (kontaktperson != null)
            {
                return KontaktPersonMapper.Map(kontaktperson);

            } else
            {
                return null;
            }
            

        }


        public static DataAccessLayer.Model.KontaktPerson GetDALKontaktPerson(string kontaktNavn, string kontaktTelefon, string kontaktEmail, AirTimeContext context)
        {
            DataAccessLayer.Model.KontaktPerson kontaktperson = context.KontaktPersoner.FirstOrDefault(k =>
            k.Navn == kontaktNavn &&
            k.TlfNr == kontaktTelefon &&
            k.Mail == kontaktEmail);
            if (kontaktperson != null)
            {
                return kontaktperson;

            }
            else
            {
                return null;
            }


        }
    }
}
