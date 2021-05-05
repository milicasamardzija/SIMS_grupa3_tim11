using Hospital.Model;
using Hospital.Prikaz;
using Hospital.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.Controller
{
    public class MedicineController
    {
        private MedicineService service;
        public MedicineController()
        {
            service = new MedicineService();
        }

        public void sendMedicineToRevision(Medicine newMedicine, int idDoctor)
        {
            service.sendMediciToRevision(newMedicine, idDoctor);
        }

        internal void approveMedicine(LekRevizija revision)
        {
            service.approvedMedicine(revision);
        }

        internal void deleteMedicine(Medicine medicine, int tag)
        {
            service.deleteMedicine(medicine,tag);
        }
    }
}
