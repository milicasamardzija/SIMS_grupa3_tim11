using Hospital.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.Controller
{
    class MedicalRecordController
    {
        private MedicalRecordService service = new MedicalRecordService();
        public List<MedicalRecord> getAll()
        {
           return  service.getAll();

        }
    }

}