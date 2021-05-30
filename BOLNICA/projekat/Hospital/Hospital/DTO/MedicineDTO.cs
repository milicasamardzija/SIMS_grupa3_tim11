using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.DTO
{
    public class MedicineDTO : INotifyPropertyChanged
    {
        private int id;
        private String name;
        private double quantity;
        private String type;
        private List<int> idsIngredients;
        private List<int> idsMedicines;
        private Boolean approved;
        private Boolean delete;

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnProperychanged(string name)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(name));
            }
        }

        public MedicineDTO(int id, String nameMedicine, double quantityMedicine, String typeMedicine, List<int> ingredientsMedicine, List<int> replacementMedicine, Boolean approvement)
        {
            this.id = id;
            name = nameMedicine;
            quantity = quantityMedicine;
            type = typeMedicine;
            idsIngredients = ingredientsMedicine;
            idsMedicines = replacementMedicine;
            approved = approvement;
            delete = false;
        }

        public MedicineDTO()
        {
        }

        public int Id
        {
            get
            {
                return id;
            }
            set
            {
                if (value != id)
                {
                    id = value;
                    OnProperychanged("Id");
                }
            }
        }

        public String Name
        {
            get
            {
                return name;
            }
            set
            {
                if (value != name)
                {
                    name = value;
                    OnProperychanged("Name");
                }
            }
        }

        public String Type
        {
            get
            {
                return type;
            }
            set
            {
                if (value != type)
                {
                    type = value;
                    OnProperychanged("Type");
                }
            }
        }

        public double Quantity
        {
            get
            {
                return quantity;
            }
            set
            {
                if (value != quantity)
                {
                    quantity = value;
                    OnProperychanged("Quantity");
                }
            }
        }
        public List<int> IdsIngredients
        {
            get
            {
                return idsIngredients;
            }
            set
            {
                if (value != idsIngredients)
                {
                    idsIngredients = value;
                    OnProperychanged("IdsIngredients");
                }
            }
        }

        public List<int> IdsMedicines
        {
            get
            {
                return idsMedicines;
            }
            set
            {
                if (value != idsMedicines)
                {
                    idsMedicines = value;
                    OnProperychanged("IdsMedicines");
                }
            }
        }

        public Boolean Approved
        {
            get
            {
                return approved;
            }
            set
            {
                if (value != approved)
                {
                    approved = value;
                    OnProperychanged("Approved");
                }
            }
        }

        public Boolean Delete
        {
            get
            {
                return delete;
            }
            set
            {
                if (value != delete)
                {
                    delete = value;
                    OnProperychanged("Delete");
                }
            }
        }
    }
}
