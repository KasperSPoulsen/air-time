using DataTransferObject.Model;
using DataAccessLayer.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.BLL
{
    public class BilBLL
    {
        public Bil getBil(int id)
        {
            if (id < 0) throw new IndexOutOfRangeException();
            return BilRepository.getBil(id);
        }

        public List<Bil> GetAllBiler()
        {
            return BilRepository.GetAllBiler();
        }


        public void AddBil(Bil bil)
        {
            //valider employee
            BilRepository.AddBil(bil);
        }
    }
}