using DataTransferObject.Model;
using DataAccessLayer.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.BLL
{
    public class FremmoederegistreringBLL
    {
        public Fremmoederegistrering getFremmoederegistrering(int id)
        {
            if (id < 0) throw new IndexOutOfRangeException();
            return FremmoederegisteringRepository.GetFremmoederegistering(id);
        }

        public List<Fremmoederegistrering> GetAllFremmoederegistreringer()
        {
            return FremmoederegisteringRepository.GetAllFremmoederegisteringer();
        }


        public void AddFremmoederegistrering(Fremmoederegistrering fremmoederegistrering)
        {
            FremmoederegisteringRepository.AddFremmoederegistrering(fremmoederegistrering);
        }
    }
}