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
            DataTransferObject.Model.Springer DTOSpringer = new DataTransferObject.Model.Springer(
                springer.Navn,
            springer.Foedselsdato,
            KontaktPersonMapper.Map(springer.KontaktPerson),
                            springer.Hold.Select(HoldMapper.Map).ToList()

            );

            if (springer.TraeningsMaal != null)
            {
                DTOSpringer.TraeningsMaal = springer.TraeningsMaal;
            }
            if (springer.KonkurrenceSerie != null)
            {
                DTOSpringer.KonkurrenceSerie = springer.KonkurrenceSerie;
            }
            return DTOSpringer;
        }
        // Mapper fra DTO til DAL
        public static DataAccessLayer.Model.Springer Map(DataTransferObject.Model.Springer springer)
        {
            DataAccessLayer.Model.Springer DALSpringer = new DataAccessLayer.Model.Springer(
                   springer.Navn,
            springer.Foedselsdato,
            KontaktPersonMapper.Map(springer.KontaktPerson),
                            springer.Hold.Select(HoldMapper.Map).ToList()
            );

            if (springer.TraeningsMaal != null)
            {
                DALSpringer.TraeningsMaal = springer.TraeningsMaal;
            }
            if (springer.KonkurrenceSerie != null)
            {
                DALSpringer.KonkurrenceSerie = springer.KonkurrenceSerie;
            }
            return DALSpringer;

        }
    }
}
