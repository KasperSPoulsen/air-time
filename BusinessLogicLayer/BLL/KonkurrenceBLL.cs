using DataAccessLayer.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataTransferObject.Model;
using DataAccessLayer.Mappers;
using DataAccessLayer.Context;

namespace BusinessLogicLayer.BLL
{
    public class KonkurrenceBLL
    {
        public Konkurrence getKonkurrence(int id)
        {
            if (id < 0) throw new IndexOutOfRangeException();
            return KonkurrenceRepository.GetKonkurrence(id);
        }

        public List<Konkurrence> GetAllKonkurrencer()
        {
            return KonkurrenceRepository.GetAllKonkurrencer();
        }


        public void CreateKonkurrence(string adresse, string navn, DateTime? dato)
        {
            if (adresse == null || navn == null) throw new ArgumentNullException();
            if (dato == null) throw new ArgumentNullException();
            Konkurrence newKonk = new Konkurrence(adresse, navn, dato.Value);
            KonkurrenceRepository.AddKonkurrence(newKonk);
        }

        public static void TilfoejSpringereTilKonkurrence(int konkurrenceId, List<Springer> springere)
        {
            using (AirTimeContext context = new AirTimeContext())
            {
                if (springere == null) throw new ArgumentNullException();
                if (konkurrenceId < 0) throw new IndexOutOfRangeException();
                foreach (var item in springere)
                {
                    KonkurrenceRepository.TilfoejSpringerTilKonkurrence(konkurrenceId, item, context);
                }
                context.SaveChanges();
            }   
            
        }


        



        //Skal lave en metode hvor man kan få alle biler og springere til en konkurrence

        public static List<Bil> GetAlleBilerTilKonkurrence(int konkurrenceId)
        {
            if (konkurrenceId < 0) throw new IndexOutOfRangeException();

            var bilerDTO = KonkurrenceRepository.GetAllBilerTilKonkurrence(konkurrenceId);
            return bilerDTO;
        }

        public static List<Springer> GetAlleSpringerTilKonkurrence(int konkurrenceId)
        {
            if (konkurrenceId < 0) throw new IndexOutOfRangeException();
            var springereDTO = KonkurrenceRepository.GetAlleSpringerTilKonkurrence(konkurrenceId);
            return springereDTO;
        }

        public static List<DataTransferObject.Model.Springer> GetSpringerePaaBil(int bilId, int konkurrenceId)
        {
            using (AirTimeContext context = new AirTimeContext())
            {
                return KonkurrenceRepository.GetSpringerePaaBil(bilId, konkurrenceId, context);
            }
        }


        public static List<DataTransferObject.Model.Springer> GetSpringerePaaKonkSomIkErIBil(int konkId)
        {
            using (AirTimeContext context = new AirTimeContext())
            {
                return KonkurrenceRepository.GetSpringerePaaKonkSomIkErIBil(konkId, context);
            }
        }
    }
}