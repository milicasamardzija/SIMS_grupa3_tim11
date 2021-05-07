using Hospital.Model;
using Hospital.Sekretar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.Controller
{
   public  class CheckupController
    {
        private CheckupService service =new CheckupService();

        public  CheckupController()
        {
           
        }

        public void getCheckupDoctors(int idD) 
        {
            List<Checkup> checkups = new List<Checkup>();
            checkups = service.getCheckupDoctors(idD); 


         //   return checkups;
        }

        public void createCheckup(int idD, int idP, DateTime date)
        { }
    }
}
