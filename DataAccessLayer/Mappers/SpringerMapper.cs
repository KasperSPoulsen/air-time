using DataAccessLayer.Model;
using DataTransferObject;
using DataTransferObject.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Mappers
{
    public class SpringerMapper
    {
        public static DataTransferObject.Model.Springer Map(DataAccessLayer.Model.Springer springer)
        {
            return new DataTransferObject.Model.Springer(
                springer.Id,
                springer.Navn,
            springer.Foedselsdato,
            KontaktPersonMapper.Map(springer.KontaktPerson),
                            springer.Hold.Select(HoldMapper.Map).ToList()

            );
        }

        // Mapper fra DTO til DAL
        public static DataAccessLayer.Model.Springer Map(DataTransferObject.Model.Springer springer)
        {
            return new DataAccessLayer.Model.Springer(
                springer.Id,
                   springer.Navn,
            springer.Foedselsdato,
            KontaktPersonMapper.Map(springer.KontaktPerson),
                            springer.Hold.Select(HoldMapper.Map).ToList()
            );

        }
    }
}
