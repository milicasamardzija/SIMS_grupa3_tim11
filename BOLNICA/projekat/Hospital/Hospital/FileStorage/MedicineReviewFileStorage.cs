using Hospital.FileStorage;
using Hospital.FileStorage.Interfaces;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.Model
{
    class MedicineReviewFileStorage : GenericFileStorage<MedicineReview>, MedicineReviewIFileStorage
    {
        public MedicineReviewFileStorage(String filePath) : base(filePath) { }

        public void DeleteByIdMedicine(int idMedicine)
        {
            foreach (MedicineReview review in GetAll())
            {
                if (review.IdMedicine == idMedicine)
                {
                    Delete(review);
                }
            }
        }
    }
}
