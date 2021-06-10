using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hospital.DTO;
using Hospital.Model;
using Hospital.Prikaz;
using Hospital.Service;

namespace Hospital.Controller
{
    public class MedicineReviewController
    {
        private MedicineReviewService serviceReview;
        private MedicineService serviceMedicine;
        public MedicineReviewController()
        {
            serviceReview = new MedicineReviewService();
            serviceMedicine = new MedicineService();
        }
        public List<ReviewDTO> getAll()
        {
            List<ReviewDTO> ret = new List<ReviewDTO>();
            getNotApprovedMedicines(ret);
            getDeleteMedicine(ret);
            return ret;
        }

        private void getNotApprovedMedicines(List<ReviewDTO> ret)
        {
            foreach (Medicine medicine in serviceMedicine.getAllNotApprovedMedicines())
            {
                foreach (MedicineReview medicineRewiev in serviceReview.getAll())
                {
                    if (medicineRewiev.IdMedicine == medicine.Id)
                    {
                        ret.Add(new ReviewDTO(medicine.Name, medicine.Type, medicineRewiev.TypeReview, medicineRewiev.Done, 
                                medicine.Id, medicineRewiev.Id));
                        break;
                    }
                }
            }
        }

        public void deleteByIdMedicine(int idMedicine)
        {
            serviceReview.deleteByIdMedicine(idMedicine);
        }

        public string getRezension(ReviewDTO revision)
        {
            return serviceReview.getRezension(new Review(revision.Name, revision.MedicineType, revision.ReviewType,
                revision.Done, revision.IdMedicine, revision.IdMedicineReview));
        }

        public string makeRecension(ReviewDTO revision)
        {
            revision.Done = true;
            return serviceReview.getRezension(new Review(revision.Name, revision.MedicineType, revision.ReviewType,
                revision.Done, revision.IdMedicine, revision.IdMedicineReview));
        }

        public string getDoctor(ReviewDTO revision)
        {
            return serviceReview.getDoctor(new Review(revision.Name, revision.MedicineType, revision.ReviewType, revision.Done,
                revision.IdMedicine, revision.IdMedicineReview));
        }

        private void getDeleteMedicine(List<ReviewDTO> ret)
        {
            foreach (Medicine medicine in serviceMedicine.getAll())
            {
                if (medicine.Delete)
                {
                    foreach (MedicineReview medicineRewiev in serviceReview.getAll())
                    {
                        if (medicineRewiev.IdMedicine == medicine.Id)
                        {
                            ret.Add(new ReviewDTO(medicine.Name, medicine.Type, medicineRewiev.TypeReview, medicineRewiev.Done, medicine.Id, medicineRewiev.Id));
                            break;
                        }
                    }
                }
            }
        }

        public MedicineDTO getMedicineByReview(ReviewDTO review)
        {
            Medicine medicine = serviceReview.getMedicineByReview(new Review(review.Name, review.MedicineType,review.ReviewType,review.Done, review.IdMedicine, review.IdMedicineReview));
            return new MedicineDTO(medicine.Id, medicine.Name, medicine.Quantity, medicine.Type,
                medicine.IdsIngredients, medicine.IdsMedicines, medicine.Approved);
        }

        public void sendBackToRevision(ReviewDTO review)
        {
            serviceReview.sendBackToRevision(new Review(review.Name, review.MedicineType,review.ReviewType, review.Done,review.IdMedicine, review.IdMedicineReview));
        }
    }
}
