using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.DTO
{
    public class InventoryDTO : INotifyPropertyChanged
    {
        private int id;
        private String name;
        private int quantity;
        private InventoryType type;

        public InventoryDTO() { }

        public InventoryDTO(int id, String name, int quantity, InventoryType type)
        {
            this.id = id;
            this.name = name;
            this.quantity = quantity;
            this.type = type;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnProperychanged(string name)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(name));
            }
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

        public int Quantity
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

        public InventoryType Type
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
    }
}
