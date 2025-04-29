using DataAccessLayer.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.BLL
{
    public class KonkurrenceBLL
    {
        public Konkurrence getKonkurrence(int id)
        {
            if (id < 0) throw new IndexOutOfRangeException();
            return KonkurrenceRepository.getKonkurrence(id);
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
    }
}