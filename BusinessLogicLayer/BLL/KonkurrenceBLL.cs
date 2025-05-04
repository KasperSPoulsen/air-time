using DataAccessLayer.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataTransferObject.Model;
using DataAccessLayer.Mappers;

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

        public void TilfoejSpringerTilKonkurrence(int konkurrenceId, Springer springer)
        {
            if (springer == null) throw new ArgumentNullException();
            if (konkurrenceId < 0) throw new IndexOutOfRangeException();
            KonkurrenceRepository.TilfoejSpringerTilKonkurrence(konkurrenceId, springer);
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
    }
}