using DataAccessLayer.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataTransferObject.Model;

namespace BusinessLogicLayer.BLL
{
    public class HoldBLL
    {
        public Hold getHold(int id)
        {
            if (id < 0) throw new IndexOutOfRangeException();
            return HoldRepository.GetHold(id);
        }

        public List<Hold> GetAllHold()
        {
            return HoldRepository.GetAllHold();
        }


        public void AddHold(Hold hold)
        {
            //valider employee
            HoldRepository.AddHold(hold);
        }
    }
}