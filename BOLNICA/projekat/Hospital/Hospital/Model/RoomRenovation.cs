using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.Model
{
    public class RoomRenovation : INotifyPropertyChanged
    {
        private int idRoom;
        private DateTime dateBegin;
        private DateTime dateEnd;
        private String description;

        public RoomRenovation(int id, DateTime begin, DateTime end, String descript)
        {
            idRoom = id;
            dateBegin = begin;
            dateEnd = end.AddHours(23);
            dateEnd.AddMinutes(59);
            description = descript;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnProperychanged(string name)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(name));
            }
        }

        public int IdRoom
        {
            get
            {
                return idRoom;
            }
            set
            {
                if (value != idRoom)
                {
                    idRoom = value;
                    OnProperychanged("IdRoom");
                }
            }
        }
        public DateTime DateBegin
        {
            get
            {
                return dateBegin;
            }
            set
            {
                if (value != dateBegin)
                {
                    dateBegin = value;
                    OnProperychanged("DateBegin");
                }
            }
        }

        public DateTime DateEnd
        {
            get
            {
                return dateEnd;
            }
            set
            {
                if (value != dateEnd)
                {
                    dateEnd = value;
                    OnProperychanged("DateEnd");
                }
            }
        }

        public String Description
        {
            get
            {
                return description;
            }
            set
            {
                if (value != description)
                {
                    description = value;
                    OnProperychanged("Description");
                }
            }
        }

    }
}
