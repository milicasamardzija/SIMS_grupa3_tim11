using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hospital.DTO;
using Hospital.FileStorage.Interfaces;
using Hospital.Model;
using Hospital.Prikaz;
using Microsoft.Win32;

namespace Hospital.Service
{
    public class MedicineReviewService
    {
        private MedicineReviewIFileStorage storageMedicineReview;
        private MedicineIFileStorage storageMedicine;
        private DoctorFileStorage storageDoctor;

        public MedicineReviewService()
        {
            storageMedicineReview = new MedicineReviewFileStorage("./../../../../Hospital/files/storageMedicineReview.json");
            storageMedicine = new MedicineFileStorage("./../../../../Hospital/files/storageMedicine.json");
            storageDoctor = new DoctorFileStorage(@"./../../../../Hospital/files/storageDoctor.json");
        }

        public void save(MedicineReview review)
        {
            storageMedicineReview.Save(review);
        }

        public List<MedicineReview> getAll()
        {
            return storageMedicineReview.GetAll();
        }
        public String getDoctor(Review revision)
        {
            Doctor doctor = storageDoctor.FindById(getIdDoctor(revision));
            return doctor.Name + " " + doctor.Surname;
        }

        private int getIdDoctor(Review revision)
        {
            MedicineReview review = storageMedicineReview.FindById(revision.IdMedicineReview);
            return review.IdDoctor;
        }

        public void deleteByIdMedicine(int idMedicine)
        {
            storageMedicineReview.DeleteByIdMedicine(idMedicine);
        }

        public String getRezension(Review revision)
        {
            MedicineReview review = storageMedicineReview.FindById(revision.IdMedicineReview);
            return review.Review;
        }

        public void sendBackToRevision(Review review)
        {
            List<MedicineReview> reviews = storageMedicineReview.GetAll();
            foreach (MedicineReview medicineReview in reviews)
            {
                if (medicineReview.IdMedicine == review.IdMedicine)
                {
                    medicineReview.Done = false;
                    break;
                }
            }
            storageMedicineReview.SaveAll(reviews);
        }

        public Medicine getMedicineByReview(Review review)
        {
            Medicine medicine = new Medicine();
            foreach (MedicineReview medicineReview in storageMedicineReview.GetAll())
            {
                if (medicineReview.Id == review.IdMedicineReview)
                {
                    medicine = storageMedicine.FindById(medicineReview.IdMedicine);
                }
            }
            return medicine;
        }
    }
}
