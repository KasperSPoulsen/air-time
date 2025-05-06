using DataAccessLayer.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataTransferObject.Model;
using DataAccessLayer.Context;

namespace BusinessLogicLayer.BLL
{
    public class HoldBLL
    {
        /*public Hold getHold(int id)
        {
            using (var context = new AirTimeContext())
            {
                if (id < 0) throw new IndexOutOfRangeException();
                return HoldRepository.GetHold(id, context);

            }

                
        }*/

        

        public List<Hold> GetAllHold()
        {
            return HoldRepository.GetAllHold();
        }


        public void AddHold(Hold hold)
        {
            //valider employee
            HoldRepository.AddHold(hold);
        }

        public static List<Springer> GetSpringerePaaHold(string holdnavn)
        {
            using (var context = new AirTimeContext())
            {
                return SpringerRepository.GetAllSpringere(context)  
                .Where(s => s.Hold.Any(h => h.HoldNavn == holdnavn))
                .ToList();
            }
                
        }




    }
}