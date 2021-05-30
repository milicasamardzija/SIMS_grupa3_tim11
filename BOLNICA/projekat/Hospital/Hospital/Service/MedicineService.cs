using Hospital.FileStorage.Interfaces;
using Hospital.Model;
using Hospital.Prikaz;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Hospital.Service
{
    class MedicineService
    {
        private MedicineIFileStorage storageMedicine;
        private MedicineReviewIFileStorage storageReview;
        public MedicineService()
        {
            storageMedicine = new MedicineFileStorage("./../../../../Hospital/files/storageMedicine.json");
            storageReview = new MedicineReviewFileStorage("./../../../../Hospital/files/storageMedicineReview.json");
        }

        public int generateIdMedicineReview()
        {
            int ret = 0;
            foreach (MedicineReview medicineBig in storageReview.GetAll())
            {
                foreach (MedicineReview medicine in storageReview.GetAll())
                {
                    if (ret == medicine.Id)
                    {
                        ++ret;
                        break;
                    }
                }
            }
            return ret;
        }

        public List<Medicine> getAll()
        {
            return storageMedicine.GetAll();
        }

        internal void deleteMedicineReview(int idMedicine)
        {
            storageMedicine.DeleteById(idMedicine); 
            storageReview.DeleteByIdMedicine(idMedicine);
        }

        public void deleteMedicine(Medicine medicine, int idDoctor)
        {
            storageReview.Save(new MedicineReview(generateIdMedicineReview(), medicine.Id, idDoctor, ReviewType.brisanje, "", false));
            deleteFleg(medicine);
        }

        public void deleteFleg(Medicine medicine)
        {
            List<Medicine> all = storageMedicine.GetAll();
            foreach (Medicine medic in all)
            {
                if (medic.Id == medicine.Id)
                {
                    medic.Delete = true;
                    storageMedicine.SaveAll(all);
                    break;
                }
            }
        }

        internal void approvedMedicine(Review revision)
        {
            List<Medicine> all = storageMedicine.GetAll();
            foreach (Medicine medicine in all)
            {
                if (medicine.Id == revision.IdMedicine)
                {
                    medicine.Approved = true;
                    storageMedicine.SaveAll(all);
                    storageReview.DeleteById(revision.IdMedicineReview);
                    break;
                }
            }
        }

        public void sendMediciToRevision(Medicine newMedicine, int idDoctor)
        {
            storageMedicine.Save(newMedicine);
            storageReview.Save(new MedicineReview(generateIdMedicineReview(),newMedicine.Id,idDoctor,ReviewType.dodavanje,"",false));
        }

        public List<Medicine> loadApprovedMedicines()
        {
            return storageMedicine.loadApprovedMedicines();
        }

        public List<Medicine> loadReplacementMedicines(Medicine medicine)
        {
            List<Medicine> medicines = new List<Medicine>();
            foreach (int idMedicine in medicine.IdsMedicines)
            {
                foreach (Medicine medicineReplacement in getAll())
                {
                    if (idMedicine == medicineReplacement.Id)
                    {
                        medicines.Add(medicineReplacement);
                        break;
                    }
                }
                break;
            }
            return medicines;
        }

        public void update(Medicine updatedMedicine)
        {
            List<Medicine> medicines = storageMedicine.GetAll();
            foreach (Medicine medicine in medicines)
            {
                if (medicine.Id == updatedMedicine.Id)
                {
                    medicine.Name = updatedMedicine.Name;
                    medicine.Type = updatedMedicine.Type;
                    medicine.Quantity = updatedMedicine.Quantity;
                    medicine.Approved = updatedMedicine.Approved;
                    medicine.Delete = updatedMedicine.Delete;
                    medicine.IdsMedicines = updatedMedicine.IdsMedicines;
                    medicine.IdsIngredients = updatedMedicine.IdsIngredients;
                    break;
                }
            }
            storageMedicine.SaveAll(medicines);
        }

        public List<int> convertReplacementMedicinesIntoIds(List<Medicine> replacementMedicine)
        {
            List<int> medicineIds = new List<int>();
            foreach (Medicine medicine in replacementMedicine)
            {
                medicineIds.Add(medicine.Id);
            }
            return medicineIds;
        }
    }
}
