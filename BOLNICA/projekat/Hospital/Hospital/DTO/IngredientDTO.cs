using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.DTO
{
    public class IngredientDTO : INotifyPropertyChanged
    {
        private int id;
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

        public IngredientDTO(int id, String name, double quantity)
        {
            this.id = id;
            this.name = name;
            this.quantity = quantity;
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
