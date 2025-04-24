using DataAccessLayer.Model;
using DataTransferObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Mappers
{
    internal class SpringerMapper
    {
        public static DataTransferObject.Model.Springer Map(DataAccessLayer.Model.Springer springer)
        {
            return new DataTransferObject.Model.Springer(
                springer.Navn,
            springer.KonkurrenceSerie,
            springer.Foedselsdato,
            springer.TraeningsMaal,
            KontaktPersonMapper.Map(springer.KontaktPerson));
        }

        // Mapper fra DTO til DAL
        public static DataAccessLayer.Model.Springer Map(DataTransferObject.Model.Springer springer)
        {
            return new DataAccessLayer.Model.Springer(
                   springer.Navn,
            springer.KonkurrenceSerie,
            springer.Foedselsdato,
            springer.TraeningsMaal,
            KontaktPersonMapper.Map(springer.KontaktPerson));
        }
    }
}
