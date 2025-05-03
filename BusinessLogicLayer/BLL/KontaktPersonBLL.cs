using DataTransferObject.Model;
using DataAccessLayer.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.BLL
{
    public class KontaktPersonBLL
    {
        /*public KontaktPerson getKontaktPerson(int id)
        {
            if (id < 0) throw new IndexOutOfRangeException();
            return KontaktPersonRepository.GetKontaktPerson(id);
        }*/

        public List<KontaktPerson> GetAllKontaktPersoner()
        {
            return KontaktPersonRepository.GetAllKontaktPersoner();
        }


        /*public void AddKontaktPerson(KontaktPerson kontaktPerson)
        {
            //valider employee
            KontaktPersonRepository.AddKontaktPerson(kontaktPerson);
        }*/
    }
}