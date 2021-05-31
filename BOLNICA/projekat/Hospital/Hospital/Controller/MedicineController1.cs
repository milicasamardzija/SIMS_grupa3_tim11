using Hospital.DTO;
using Hospital.FileStorage.Interfaces;
using Hospital.Model;
using Hospital.Service;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.Controller
{
    public class MedicineController1
    {
        private MedicineService1 service;

        public MedicineController1()
        {
            service = new MedicineService1();
        }

        public List<MedicineDTO> getAll()
        {
            List<MedicineDTO> medicines = new List<MedicineDTO>();
            foreach(Medicine medicine in service.getAll())
            {
                medicines.Add(new MedicineDTO(medicine.Id, medicine.Name, medicine.Quantity, medicine.Type, medicine.IdsIngredients,
                    medicine.IdsMedicines, medicine.Approved));
            }
            return medicines;
        }
       
    }
}
