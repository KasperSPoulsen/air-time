using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer.Repositories;

namespace BusinessLogicLayer.BLL
{
    public class SpringerBLL
    {
        public void OpretSpringer(string navn, DateTime foedselsdato, List<int> holdId)
        {
            SpringerRepository.OpretSpringer(navn, foedselsdato, holdId);
            
        }
    }
}
