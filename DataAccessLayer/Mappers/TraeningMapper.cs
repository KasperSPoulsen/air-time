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

        public static List<DataTransferObject.Model.Traening> Map(List<DataAccessLayer.Model.Traening> traeninger)
        {
            List<DataTransferObject.Model.Traening> DTOtraeninger = new List<DataTransferObject.Model.Traening>();
            foreach (var e in traeninger)
            {
                DTOtraeninger.Add(Map(e));
            }
            return DTOtraeninger;
        }

        // Mapper fra DTO til DAL
        public static DataAccessLayer.Model.Traening Map(DataTransferObject.Model.Traening traening)
        {
            return new DataAccessLayer.Model.Traening(traening.Dato, HoldMapper.Map(traening.Hold), FremmoederegistreringMapper.Map(traening.Fremmoederegistreringer));

        }



        public static List<DataAccessLayer.Model.Traening> Map(List<DataTransferObject.Model.Traening> traeninger)
        {
            List<DataAccessLayer.Model.Traening> DALtraeninger = new List<DataAccessLayer.Model.Traening>();
            foreach (var e in traeninger)
            {
                DALtraeninger.Add(Map(e));
            }
            return DALtraeninger;
        }
    }
}
