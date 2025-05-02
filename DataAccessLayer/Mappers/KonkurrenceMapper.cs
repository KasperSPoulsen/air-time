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

            DataTransferObject.Model.Konkurrence DTOKonkurrence = new DataTransferObject.Model.Konkurrence(konkurrence.Adresse,konkurrence.Navn,konkurrence.Dato);
            if (konkurrence.Springere != null)
            {
                foreach (var springer in konkurrence.Springere)
                {
                    DTOKonkurrence.Springere.Add(SpringerMapper.Map(springer));
                }
            }
            if (konkurrence.Biler != null)
            {
                foreach (var bil in konkurrence.Biler)
                {
                    DTOKonkurrence.Biler.Add(BilMapper.Map(bil));
                }
            }
            if (konkurrence.Id != 0)
            {
                DTOKonkurrence.Id = konkurrence.Id;
            }
            return DTOKonkurrence;
        }

        public static DataAccessLayer.Model.Konkurrence Map(DataTransferObject.Model.Konkurrence konkurrence)
        {
            DataAccessLayer.Model.Konkurrence DALKonkurrence =  new DataAccessLayer.Model.Konkurrence(konkurrence.Adresse,konkurrence.Navn,konkurrence.Dato);

            if (konkurrence.Springere != null)
            {
                foreach (var springer in konkurrence.Springere)
                {
                    DALKonkurrence.Springere.Add(SpringerMapper.Map(springer));
                }
            }

            if (konkurrence.Biler != null)
            {
                foreach (var bil in konkurrence.Biler)
                {
                    DALKonkurrence.Biler.Add(BilMapper.Map(bil));
                }
            }
            if (konkurrence.Id != 0)
            {
                DALKonkurrence.Id = konkurrence.Id;
            }
            return DALKonkurrence;
        }
    }
}
