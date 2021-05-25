using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.DTO
{
    public class RoomDTO : INotifyPropertyChanged
    {
        private int id;
        private int floor;
        private Boolean occupancy;
        private Purpose purpose;
        private int capacity;

        public RoomDTO() { }

        public RoomDTO(int id, int floor, bool occupancy, Purpose purpose, int capacity)
        {
            this.id = id;
            this.floor = floor;
            this.occupancy = occupancy;
            this.purpose = purpose;
            this.capacity = capacity;
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

        public int Floor
        {
            get
            {
                return floor;
            }
            set
            {
                if (value != floor)
                {
                    floor = value;
                    OnProperychanged("Floor");
                }
            }
        }

        public bool Occupancy
        {
            get
            {
                return occupancy;
            }
            set
            {
                if (value != occupancy)
                {
                    occupancy = value;
                    OnProperychanged("Occupancy");
                }
            }
        }

        public Purpose Purpose
        {
            get
            {
                return purpose;
            }
            set
            {
                if (value != purpose)
                {
                    purpose = value;
                    OnProperychanged("Purpose");
                }
            }
        }

        public int Capacity
        {
            get
            {
                return capacity;
            }
            set
            {
                if (value != capacity)
                {
                    capacity = value;
                    OnProperychanged("Capacity");
                }
            }
        }
    }
}
