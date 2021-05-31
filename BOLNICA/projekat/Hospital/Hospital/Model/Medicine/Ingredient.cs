using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.Model
{
    public class Ingredient : Entity
    {
        private String name;
        private double quantity;

        public Ingredient(int id, String nameIngerdient, double quantityIngredient) : base(id)
        {
            name = nameIngerdient;
            quantity = quantityIngredient;
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
                }
            }
        }

    }
}
