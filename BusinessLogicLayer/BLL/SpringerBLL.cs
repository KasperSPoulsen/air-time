using DataTransferObject.Model;
using DataAccessLayer.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.BLL
{
    public class SpringerBLL
    {
        public Springer getSpringer(int id)
        {
            if (id < 0) throw new IndexOutOfRangeException();
            return SpringerRepository.GetSpringer(id);
        }

        public List<Springer> GetAllSpringere()
        {
            return SpringerRepository.GetAllSpringere();
        }


        public void AddSpringer(Springer springer)
        {
            //valider employee
            SpringerRepository.AddSpringer(springer);
        }

       
    }
}