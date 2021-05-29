using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hospital.FileStorage.Interfaces;
using Hospital.Model;
using Microsoft.Win32;

namespace Hospital.Service
{
    public class MedicineReviewService
    {
        private MedicineReviewIFileStorage storage;

        public MedicineReviewService()
        {
            storage = new MedicineReviewFileStorage("./../../../../Hospital/files/storageMedicineReview.json");
        }

        public void save(MedicineReview review)
        {
            storage.Save(review);
        }

        public void delete(MedicineReview review)
        {
            
        }
    }
}
