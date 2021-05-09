using Hospital.Model;
using Hospital.Sekretar;
using Hospital.Service;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Hospital.Controller
{
   public  class CheckupController
    {
        private CheckupService service =new CheckupService();

        public  CheckupController()
        {
           
        }

        public List<Checkup> getCheckupDoctors(int idD) 
        {
            List<Checkup> checkups = new List<Checkup>();
            checkups = service.getCheckupDoctors(idD);
            Checkup prikaz = new Checkup();
            prikaz = checkups[0];
            int id = prikaz.IdA;
           // MessageBox.Show(id.ToString());
            //MessageBox.Show(checkups[0].IdCh.ToString());
            return checkups;
            
        }

        public void createCheckup(Checkup c)
        {
            service.createCheckup(c);
        }
    }
}
