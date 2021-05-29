using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hospital.Service;

namespace Hospital.Controller
{
    public class MedicineReviewController
    {
        private MedicineReviewService service;
        public MedicineReviewController()
        {
            service = new MedicineReviewService();
        }
    }
}
