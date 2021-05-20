using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.Model
{
    public class Medicine : INotifyPropertyChanged
    {
        private int idMedicine;
        private String name;
        private double quantity;
        private String type;
        private List<Ingredient> ingredients;
        private List<Medicine> replacementMedicines;
        private List<int> idsIngredients;
        private List<int> idsMedicines;
        private Boolean approved;
        private Boolean delete;
      /*  private int v1;
        private string v2;
        private double v3;
        private string v4;
        private object selectedItem1;
        private object selectedItem2;*/
       // private bool approvedMedicine;

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnProperychanged(string name)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(name));
            }
        }

        public Medicine(int id, String nameMedicine, double quantityMedicine, String typeMedicine, List<int> ingredientsMedicine, List<int> replacementMedicine, Boolean approvement)
        {
            idMedicine = id;
            name = nameMedicine;
            quantity = quantityMedicine;
            type = typeMedicine;
            idsIngredients = ingredientsMedicine;
            idsMedicines = replacementMedicine;
            approved = approvement;
            delete = false;
        }

        public Medicine()
        {
        }

      /*  public Medicine(int v1, string v2, double v3, string v4, object selectedItem1, object selectedItem2, bool approvedMedicine)
        {
            this.v1 = v1;
            this.v2 = v2;
            this.v3 = v3;
            this.v4 = v4;
            this.selectedItem1 = selectedItem1;
            this.selectedItem2 = selectedItem2;
            this.approvedMedicine = approvedMedicine;
        }*/

        public int IdMedicine
        {
            get
            {
                return idMedicine;
            }
            set
            {
                if (value != idMedicine)
                {
                    idMedicine = value;
                    OnProperychanged("IdMedicine");
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

        [JsonIgnore]
        public List<Ingredient> Ingredients
        {
            get
            {
                return ingredients;
            }
            set
            {
                if (value != ingredients)
                {
                    ingredients = value;
                    OnProperychanged("Ingredients");
                }
            }
        }

        [JsonIgnore]
        public List<Medicine> ReplacementMedicines
        {
            get
            {
                return replacementMedicines;
            }
            set
            {
                if (value != replacementMedicines)
                {
                    replacementMedicines = value;
                    OnProperychanged("ReplacementMedicines");
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
