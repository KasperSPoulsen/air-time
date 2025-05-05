using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer.Repositories;
using DataTransferObject.Model;

namespace BusinessLogicLayer.BLL
{
    internal class TraeningBLL
    {

        public Traening getTraening(int id)
        {
            if (id < 0) throw new IndexOutOfRangeException("ID findes ikke");
            return TraeningRepository.GetTraening(id);
        }

        public List<Traening> GetAlleTraeninger()
        {
            return TraeningRepository.GetAlleTraeninger();
        }
        public void AddTraening(Traening traening)
        {
            //valider employee
            TraeningRepository.AddTraening(traening);
        }
    }
}
