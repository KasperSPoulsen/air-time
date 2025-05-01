using DataAccessLayer.Model;
using DataTransferObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Mappers
{
    public class BilMapper
    {
        // Mapper fra DAL til DTO
        public static DataTransferObject.Model.Bil Map(DataAccessLayer.Model.Bil bil)
        {
            return new DataTransferObject.Model.Bil(
                KontaktPersonMapper.Map(bil.KontaktPerson)
            );
        }

        // Mapper fra DTO til DAL
        public static DataAccessLayer.Model.Bil Map(DataTransferObject.Model.Bil bil)
        {
            return new DataAccessLayer.Model.Bil(
                KontaktPersonMapper.Map(bil.KontaktPerson)
            );
        }
    }
}
