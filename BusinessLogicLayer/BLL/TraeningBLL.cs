using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using DataAccessLayer.Repositories;
using DataTransferObject.Model;

namespace BusinessLogicLayer.BLL
{
    public class TraeningBLL
    {

        public DataTransferObject.Model.Traening getTraening(int id)
        {
            if (id < 0) throw new IndexOutOfRangeException("ID findes ikke");
            return TraeningRepository.GetTraening(id);
        }

        public List<Traening> GetAlleTraeninger()
        {
            return TraeningRepository.GetAlleTraeninger();
        }
        public void AddTraening(DateTime dato, DataTransferObject.Model.Hold valgthold, List<DataTransferObject.Model.Fremmoederegistrering> fremmoederegistreringer )
        {
            //valider employee
            TraeningRepository.AddTraening(dato, valgthold, fremmoederegistreringer);
        }

        public Traening GetSenesteTraening()
        {
            return TraeningRepository.GetSenesteTraening();
        }

        public Traening GetTilmeldte()
        {
            return TraeningRepository.GetTilmeldte();
        }
    }
}
