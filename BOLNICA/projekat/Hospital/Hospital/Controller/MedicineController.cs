using Hospital.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.Controller
{
    class MedicineController
    {
        private MedicineService service;
        MedicineController()
        {
            service = new MedicineService();
        }
    }
}
