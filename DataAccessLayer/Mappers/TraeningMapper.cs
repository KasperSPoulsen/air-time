using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Mappers
{
    public class TraeningMapper
    {
        // Mapper fra DAL til DTO
        public static DataTransferObject.Model.Traening Map(DataAccessLayer.Model.Traening traening)
        {
            return new DataTransferObject.Model.Traening(traening.Dato, HoldMapper.Map(traening.Hold), FremmoederegistreringMapper.Map(traening.Fremmoederegistreringer));
        }

        // Mapper fra DTO til DAL
        public static DataAccessLayer.Model.Traening Map(DataTransferObject.Model.Traening traening)
        {
            return new DataAccessLayer.Model.Traening(traening.Dato, HoldMapper.Map(traening.Hold), FremmoederegistreringMapper.Map(traening.Fremmoederegistreringer));

        }
    }
}
