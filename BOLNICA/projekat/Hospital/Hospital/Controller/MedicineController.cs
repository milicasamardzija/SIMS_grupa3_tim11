using Hospital.DTO;
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

        public void sendMedicineToRevision(MedicineDTO newMedicine, int idDoctor)
        {
            service.sendMediciToRevision(new Medicine(newMedicine.Id,newMedicine.Name,newMedicine.Quantity,newMedicine.Type,newMedicine.IdsIngredients,newMedicine.IdsMedicines,newMedicine.Approved), idDoctor);
        }

        internal void approveMedicine(ReviewDTO revision)
        {
            service.approvedMedicine(new Review(revision.Name,revision.MedicineType,revision.ReviewType,revision.Done,revision.IdMedicine,revision.IdMedicineReview));
        }

        internal void deleteMedicine(MedicineDTO medicine, int tag)
        {
            service.deleteMedicine(new Medicine(medicine.Id,medicine.Name,medicine.Quantity,medicine.Type,medicine.IdsIngredients,medicine.IdsMedicines,medicine.Approved),tag);
        }

        internal List<MedicineDTO> getAll()
        {
            List<MedicineDTO> medicines = new List<MedicineDTO>();
            foreach (Medicine medicine in service.getAll())
            {
                medicines.Add(new MedicineDTO(medicine.Id,medicine.Name,medicine.Quantity,medicine.Type,medicine.IdsIngredients,medicine.IdsMedicines,medicine.Approved));
            }
            return medicines;
        }

        internal void deleteMedicine(int idMedicine)
        {
            service.deleteMedicineReview(idMedicine);
        }

        public List<MedicineDTO> loadApprovedMedicines()
        {
            List<MedicineDTO> medicines = new List<MedicineDTO>();
            foreach (Medicine medicine in service.loadApprovedMedicines())
            {
                medicines.Add(new MedicineDTO(medicine.Id, medicine.Name, medicine.Quantity, medicine.Type, medicine.IdsIngredients, medicine.IdsMedicines, medicine.Approved));
            }
            return medicines;
        }

        public List<MedicineDTO> loadReplacementMedicines(MedicineDTO medicine)
        {
            List<MedicineDTO> medicines = new List<MedicineDTO>();
            List<Medicine> replacementMedicines = service.loadReplacementMedicines(new Medicine(medicine.Id,
                medicine.Name, medicine.Quantity, medicine.Type, medicine.IdsIngredients, medicine.IdsMedicines,
                medicine.Approved));
            foreach (Medicine medic in replacementMedicines)
            {
                medicines.Add(new MedicineDTO(medic.Id, medic.Name, medic.Quantity, medic.Type, medic.IdsIngredients, medic.IdsMedicines, medic.Approved));
            }
            return medicines;
        }

        public List<int> convertReplacementMedicinesIntoIds(List<MedicineDTO> replacementMedicine)
        {
            List<Medicine> replacementMedicines = new List<Medicine>();
            foreach (MedicineDTO medicine in replacementMedicine)
            {
                replacementMedicines.Add(new Medicine(medicine.Id, medicine.Name, medicine.Quantity, medicine.Type, medicine.IdsIngredients, medicine.IdsMedicines, medicine.Approved));
            }
            return service.convertReplacementMedicinesIntoIds(replacementMedicines);
        }

        public List<Medicine> getAllNotApprovedMedicines()
        {
            return service.getAllNotApprovedMedicines();
        }

        public void update(MedicineDTO medicine)
        {
            service.update(new Medicine(medicine.Id, medicine.Name, medicine.Quantity, medicine.Type, medicine.IdsIngredients, medicine.IdsMedicines, medicine.Approved));
        }
    }
}
