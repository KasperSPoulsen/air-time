using DataAccessLayer.Model;
using DataTransferObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Mappers
{
    internal class HoldMapper
    {
        public static DataTransferObject.Model.Hold Map(DataAccessLayer.Model.Hold hold)
        {
            return new DataTransferObject.Model.Hold(
                hold.HoldNavn
            );
        }

        public static DataAccessLayer.Model.Hold Map(DataTransferObject.Model.Hold hold)
        {
            return new DataAccessLayer.Model.Hold(
                hold.HoldNavn
            );
        }
    }
}
