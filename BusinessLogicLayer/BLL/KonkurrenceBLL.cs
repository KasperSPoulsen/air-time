using DataAccessLayer.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataTransferObject.Model;

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


        public void AddKonkurrence(Konkurrence konkurrence)
        {
            //valider employee
            KonkurrenceRepository.AddKonkurrence(konkurrence);
        }

        public void TilfoejSpringerTilKonkurrence(int konkurrenceId, Springer springer)
        {
            if (springer == null) throw new ArgumentNullException();
            if (konkurrenceId < 0) throw new IndexOutOfRangeException();
            KonkurrenceRepository.TilfoejSpringerTilKonkurrence(konkurrenceId, springer);
        }


        public void test()
        {
            Konkurrence konkurrence = new Konkurrence("Testvej 1", "Testkonkurrence", DateTime.Now);
            List<Hold> holds = new List<Hold>();
            KontaktPerson k = new KontaktPerson("Hej", "91", "asd");
            Springer springer = new Springer("Test", DateTime.Now, k, holds);


            Console.WriteLine(konkurrence.ToString());
        }
    }
}