using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.Model
{
    class Ingredient : INotifyPropertyChanged
    {
        private int idIngredient;
        private String name;
        private double quantity;

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnProperychanged(string name)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(name));
            }
        }

        public Ingredient(int id, String nameIngerdient, double quantityIngredient)
        {
            idIngredient = id;
            name = nameIngerdient;
            quantity = quantityIngredient;
        }

        public int IdIngredient
        {
            get
            {
                return idIngredient;
            }
            set
            {
                if (value != idIngredient)
                {
                    idIngredient = value;
                    OnProperychanged("IdIngerdient");
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

    }
}
