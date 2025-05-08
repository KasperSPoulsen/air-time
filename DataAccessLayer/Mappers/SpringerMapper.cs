using DataAccessLayer.Model;
using DataTransferObject;
using DataTransferObject.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Metadata.Edm;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Mappers
{
    public class SpringerMapper
    {
        

        public static DataTransferObject.Model.Springer Map(DataAccessLayer.Model.Springer springer)
        {
            DataTransferObject.Model.Springer DTOSpringer = new DataTransferObject.Model.Springer(
                springer.Navn,
                springer.Foedselsdato,
                KontaktPersonMapper.Map(springer.KontaktPerson),
                HoldMapper.MapWithoutSpringereAndTraeninger(springer.Hold)
            );

            if (springer.TraeningsMaal != null)
            {
                DTOSpringer.TraeningsMaal = springer.TraeningsMaal;
            }
            if (springer.KonkurrenceSerie != null)
            {
                DTOSpringer.KonkurrenceSerie = springer.KonkurrenceSerie;
            }
            return DTOSpringer;
        }


        public static List<DataTransferObject.Model.Springer> Map(List<DataAccessLayer.Model.Springer> springere)
        {
            List<DataTransferObject.Model.Springer> DTOSpringere = new List<DataTransferObject.Model.Springer>();
            foreach (var e in springere)
            {
                DTOSpringere.Add(Map(e));
            }
            return DTOSpringere;
        }
        // Mapper fra DTO til DAL
        public static DataAccessLayer.Model.Springer Map(DataTransferObject.Model.Springer springer)
        {
            DataAccessLayer.Model.Springer DALSpringer = new DataAccessLayer.Model.Springer(
                    springer.Navn,
                    springer.Foedselsdato,
                    KontaktPersonMapper.Map(springer.KontaktPerson),
                    HoldMapper.MapWithoutSpringereAndTraeninger(springer.Hold)
            );

            if (springer.TraeningsMaal != null)
            {
                DALSpringer.TraeningsMaal = springer.TraeningsMaal;
            }
            if (springer.KonkurrenceSerie != null)
            {
                DALSpringer.KonkurrenceSerie = springer.KonkurrenceSerie;
            }
            return DALSpringer;

        }


        public static List<DataAccessLayer.Model.Springer> Map(List<DataTransferObject.Model.Springer> springere)
        {
            List<DataAccessLayer.Model.Springer> DALSpringere = new List<DataAccessLayer.Model.Springer>();
            foreach (var e in springere)
            {
                DALSpringere.Add(Map(e));
            }
            return DALSpringere;
        }

        internal static DataTransferObject.Model.Springer MapWithoutHold(DataAccessLayer.Model.Springer springer)
        {
            DataTransferObject.Model.Springer DTOSpringer = new DataTransferObject.Model.Springer(
                springer.Navn,
                springer.Foedselsdato,
                KontaktPersonMapper.Map(springer.KontaktPerson)
                
            );

            if (springer.TraeningsMaal != null)
            {
                DTOSpringer.TraeningsMaal = springer.TraeningsMaal;
            }
            if (springer.KonkurrenceSerie != null)
            {
                DTOSpringer.KonkurrenceSerie = springer.KonkurrenceSerie;
            }
            return DTOSpringer;
        }


        internal static DataAccessLayer.Model.Springer MapWithoutHold(DataTransferObject.Model.Springer springer)
        {
            DataAccessLayer.Model.Springer DALSpringer = new DataAccessLayer.Model.Springer(
                            springer.Navn,
                            springer.Foedselsdato,
                            KontaktPersonMapper.Map(springer.KontaktPerson)

                        );

            if (springer.TraeningsMaal != null)
            {
                DALSpringer.TraeningsMaal = springer.TraeningsMaal;
            }
            if (springer.KonkurrenceSerie != null)
            {
                DALSpringer.KonkurrenceSerie = springer.KonkurrenceSerie;
            }
            return DALSpringer;
        }

        internal static List<DataAccessLayer.Model.Springer> MapListWithoutHold(List<DataTransferObject.Model.Springer> springere)
        {
            List<DataAccessLayer.Model.Springer> DALSpringere = new List<DataAccessLayer.Model.Springer>();

            foreach (var springer in springere)
            {
                DataAccessLayer.Model.Springer DALSpringer = new DataAccessLayer.Model.Springer(
                    springer.Navn,
                    springer.Foedselsdato,
                    KontaktPersonMapper.Map(springer.KontaktPerson)
                );

                if (springer.TraeningsMaal != null)
                {
                    DALSpringer.TraeningsMaal = springer.TraeningsMaal;
                }
                if (springer.KonkurrenceSerie != null)
                {
                    DALSpringer.KonkurrenceSerie = springer.KonkurrenceSerie;
                }

                DALSpringere.Add(DALSpringer);
            }

            return DALSpringere;
        }

        /*public static DataAccessLayer.Model.Springer MapForAddingSpringer(DataTransferObject.Model.Springer springer)
        {
            DataAccessLayer.Model.Springer DALSpringer = new DataAccessLayer.Model.Springer(
                    springer.Navn,
                    springer.Foedselsdato,
                    KontaktPersonMapper.Map(springer.KontaktPerson),
                    HoldMapper.MapWithoutHold(springer.Hold)
            );

            if (springer.TraeningsMaal != null)
            {
                DALSpringer.TraeningsMaal = springer.TraeningsMaal;
            }
            if (springer.KonkurrenceSerie != null)
            {
                DALSpringer.KonkurrenceSerie = springer.KonkurrenceSerie;
            }
            return DALSpringer;

        }*/
    }
}
