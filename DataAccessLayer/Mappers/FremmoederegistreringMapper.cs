using DataAccessLayer.Model;
using DataTransferObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Mappers
{
    internal class FremmoederegistreringMapper
    {
        public static DataTransferObject.Model.Fremmoederegistrering Map(DataAccessLayer.Model.Fremmoederegistrering fremmoederegistrering)
        {
            return new DataTransferObject.Model.Fremmoederegistrering(
                fremmoederegistrering.Dato,
                            StatusMapper.Map(fremmoederegistrering.MoedeStatus),
                            HoldMapper.Map(fremmoederegistrering.Hold)

            );
        }

        public static DataAccessLayer.Model.Fremmoederegistrering Map(DataTransferObject.Model.Fremmoederegistrering fremmoederegistrering)
        {
            return new DataAccessLayer.Model.Fremmoederegistrering(
                fremmoederegistrering.Dato,
                            StatusMapper.Map(fremmoederegistrering.Status),
                            HoldMapper.Map(fremmoederegistrering.Hold)

            );
        }
    }
}
