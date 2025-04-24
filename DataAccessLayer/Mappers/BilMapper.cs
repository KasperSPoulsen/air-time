using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Mappers
{
    internal class BilMapper
    {
        // Mapper fra DAL til DTO
        public static DTO.Model.Bil Map(DAL.Model.Bil bil)
        {
            return new DTO.Model.Bil(
                
            );
        }

        // Mapper fra DTO til DAL
        public static DAL.Model.Bil Map(DTO.Model.Bil bil)
        {
            return new DAL.Model.Bil(
                
            );
        }
    }
}
