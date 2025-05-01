using DataAccessLayer.Model;
using DataTransferObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Mappers
{
    public class FremmoederegistreringMapper
    {
        public static DataTransferObject.Model.Fremmoederegistrering Map(DataAccessLayer.Model.Fremmoederegistrering fremmoederegistrering)
        {
            return new DataTransferObject.Model.Fremmoederegistrering(
                            StatusMapper.Map(fremmoederegistrering.MoedeStatus),
                SpringerMapper.Map(fremmoederegistrering.Springer)

            );
        }

        public static List<DataTransferObject.Model.Fremmoederegistrering> Map(List<DataAccessLayer.Model.Fremmoederegistrering> fremmoederegistreringer)
        {
            List<DataTransferObject.Model.Fremmoederegistrering> DTOregistreringer = new List<DataTransferObject.Model.Fremmoederegistrering>();
            foreach (var registrering in fremmoederegistreringer)
            {
                DTOregistreringer.Add(Map(registrering));
            }
            return DTOregistreringer;

            
        }

        public static DataAccessLayer.Model.Fremmoederegistrering Map(DataTransferObject.Model.Fremmoederegistrering fremmoederegistrering)
        {
            return new DataAccessLayer.Model.Fremmoederegistrering(
                            StatusMapper.Map(fremmoederegistrering.MoedeStatus),
                SpringerMapper.Map(fremmoederegistrering.Springer)
            );
        }

        public static List<DataAccessLayer.Model.Fremmoederegistrering> Map(List<DataTransferObject.Model.Fremmoederegistrering> fremmoederegistreringer)
        {
            List<DataAccessLayer.Model.Fremmoederegistrering> DALregistreringer = new List<DataAccessLayer.Model.Fremmoederegistrering>();
            foreach (var registrering in fremmoederegistreringer)
            {
                DALregistreringer.Add(Map(registrering));
            }
            return DALregistreringer;


        }
    }
}
