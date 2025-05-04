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
            DataTransferObject.Model.Bil DTOBil = new DataTransferObject.Model.Bil(KontaktPersonMapper.Map(bil.KontaktPerson));

            if (bil.Springere != null)
            {
                foreach (var springer in bil.Springere)
                {
                    DTOBil.Springere.Add(SpringerMapper.Map(springer));
                }
            }
            if (bil.Id != 0)
            {
                DTOBil.Id = bil.Id;
            }
            return DTOBil;
        }

        // Mapper fra DTO til DAL
        public static DataAccessLayer.Model.Bil Map(DataTransferObject.Model.Bil bil)
        {
            Bil DALBil = new Bil(KontaktPersonMapper.Map(bil.KontaktPerson));
            if (bil.Springere != null)
            {
                foreach (var springer in bil.Springere)
                {
                    DALBil.Springere.Add(SpringerMapper.Map(springer));
                }
            }
            if (bil.Id != 0)
            {
                DALBil.Id = bil.Id;
            }
            return DALBil;
        }

    }
}
