using DataAccessLayer.Model;
using DataTransferObject;
using DataTransferObject.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Mappers
{
    public class HoldMapper
    {
        public static DataTransferObject.Model.Hold Map(DataAccessLayer.Model.Hold hold)
        {
            DataTransferObject.Model.Hold DTOHold = new DataTransferObject.Model.Hold(
                hold.HoldNavn
            );
            if (hold.Id != 0)
            {
                DTOHold.Id = hold.Id;
            }
            if (hold.Traeninger != null)
            {
                DTOHold.Traeninger = TraeningMapper.Map(hold.Traeninger);
            }else
            {
                DTOHold.Traeninger = null;
            }
            if (hold.Springere != null)
            {
                DTOHold.Springere = SpringerMapper.Map(hold.Springere);
            }
            return DTOHold;
        }

        


        public static DataAccessLayer.Model.Hold Map(DataTransferObject.Model.Hold hold)
        {
            DataAccessLayer.Model.Hold DALHold = new DataAccessLayer.Model.Hold(
                hold.HoldNavn
            );
            if (hold.Id != 0)
            {
                DALHold.Id = hold.Id;
            }
            if (hold.Springere != null)
            {
                DALHold.Springere = SpringerMapper.Map(hold.Springere);
            }
            return DALHold;
        }

        public static List<DataAccessLayer.Model.Hold> Map(List<DataTransferObject.Model.Hold> hold)
        {
            List<DataAccessLayer.Model.Hold> DALHold = new List<DataAccessLayer.Model.Hold>();
            foreach (var e in hold)
            {
                DALHold.Add(Map(e));
            }
            return DALHold;
        }

        public static List<DataTransferObject.Model.Hold> Map(List<DataAccessLayer.Model.Hold> hold)
        {
            List<DataTransferObject.Model.Hold> DTOHold = new List<DataTransferObject.Model.Hold>();
            foreach (var e in hold)
            {
                DTOHold.Add(Map(e));
            }
            return DTOHold;
        }

        internal static List<DataTransferObject.Model.Hold> MapWithoutSpringereAndTraeninger(List<DataAccessLayer.Model.Hold> hold)
        {
            List<DataTransferObject.Model.Hold> DTOHold = new List<DataTransferObject.Model.Hold>();
            foreach (var e in hold)
            {
                DTOHold.Add(MapWithoutSpringereAndTraeninger(e));
            }
            return DTOHold;
        }


        internal static DataTransferObject.Model.Hold MapWithoutSpringereAndTraeninger(DataAccessLayer.Model.Hold hold)
        {
            DataTransferObject.Model.Hold DTOHold = new DataTransferObject.Model.Hold(
                hold.HoldNavn
            );
            if (hold.Id != 0)
            {
                DTOHold.Id = hold.Id;
            }
            
            
            return DTOHold;
        }


        internal static DataAccessLayer.Model.Hold MapWithoutSpringereAndTraeninger(DataTransferObject.Model.Hold hold)
        {
            DataAccessLayer.Model.Hold DALHold = new DataAccessLayer.Model.Hold(
                hold.HoldNavn
            );
            if (hold.Id != 0)
            {
                DALHold.Id = hold.Id;
            }
            

            return DALHold;
        }

        internal static List<DataAccessLayer.Model.Hold> MapWithoutSpringereAndTraeninger(List<DataTransferObject.Model.Hold> hold)
        {
            List<DataAccessLayer.Model.Hold> DALHold = new List<DataAccessLayer.Model.Hold>();
            foreach (var e in hold)
            {
                DALHold.Add(MapWithoutSpringereAndTraeninger(e));
            }
            return DALHold;
        }
    }
}
