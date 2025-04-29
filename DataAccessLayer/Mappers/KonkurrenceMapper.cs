using DataAccessLayer.Model;
using DataTransferObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Mappers
{
    public class KonkurrenceMapper
    {
        public static DataTransferObject.Model.Konkurrence Map(DataAccessLayer.Model.Konkurrence konkurrence)
        {
            return new DataTransferObject.Model.Konkurrence(
                konkurrence.Id,
                konkurrence.Adresse,
                konkurrence.Navn,
                konkurrence.Dato
            );
        }

        public static DataAccessLayer.Model.Konkurrence Map(DataTransferObject.Model.Konkurrence konkurrence)
        {
            return new DataAccessLayer.Model.Konkurrence(
                konkurrence.Id,
                konkurrence.Adresse,
                konkurrence.Navn,
                konkurrence.Dato
            );
        }
        
    }
}
