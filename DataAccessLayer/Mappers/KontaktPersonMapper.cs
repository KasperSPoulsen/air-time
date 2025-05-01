using DataAccessLayer.Model;
using DataTransferObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Mappers
{
    public class KontaktPersonMapper
    {
        public static DataTransferObject.Model.KontaktPerson Map(DataAccessLayer.Model.KontaktPerson kontaktPerson)
        {
            return new DataTransferObject.Model.KontaktPerson(
                kontaktPerson.Navn,
                kontaktPerson.TlfNr,
                kontaktPerson.Mail
                );
        }

        public static DataAccessLayer.Model.KontaktPerson Map(DataTransferObject.Model.KontaktPerson kontaktPerson)
        {
            return new DataAccessLayer.Model.KontaktPerson(
                kontaktPerson.Navn,
                kontaktPerson.TlfNr,
                kontaktPerson.Mail
            );
        }
    }
}
