using DataAccessLayer.Model;
using DataTransferObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Mappers
{
    internal class KonkurrenceMapper
    {
        public static DataTransferObject.Model.Konkurrence Map(DataAccessLayer.Model.Konkurrence konkurrence)
        {
            return new DataTransferObject.Model.Konkurrence(
                konkurrence.Adresse,
                konkurrence.Navn,
                konkurrence.Springere.Select(SpringerMapper.Map).ToList(),
                konkurrence.Biler.Select(BilMapper.Map).ToList()
            );
        }

        public static DataAccessLayer.Model.Konkurrence Map(DataTransferObject.Model.Konkurrence konkurrence)
        {
            return new DataAccessLayer.Model.Konkurrence(
                konkurrence.Adresse,
                konkurrence.Navn,
                konkurrence.Springere.Select(SpringerMapper.Map).ToList(),
                konkurrence.Biler.Select(BilMapper.Map).ToList()
            );
        }
        
    }
}
