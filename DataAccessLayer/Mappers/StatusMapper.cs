using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Mappers
{
    internal static class StatusMapper
    {
        public static DataTransferObject.Model.Status Map(DataAccessLayer.Model.Status status)
        {
            return (DataTransferObject.Model.Status)status;
        }

        public static DataAccessLayer.Model.Status Map(DataTransferObject.Model.Status status)
        {
            return (DataAccessLayer.Model.Status)status;
        }
    }

}
