using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.DTO
{
    public class RoomRenovationDTO : INotifyPropertyChanged
    {
        private DateTime dateBegin;
        private DateTime dateEnd;
        private String description;
        private int idRenovation;
        private int idRoom;
        private int idRoomSecond;
        private Purpose purpose;
        public RoomRenovationDTO() {}
        public RoomRenovationDTO(int id, int idRoom, DateTime dateBegin, DateTime dateEnd, String description)
        {
            this.dateBegin = dateBegin;
            this.dateEnd = dateEnd.AddHours(23);
            this.dateEnd.AddMinutes(59);
            this.description = description;
            this.idRoom = idRoom;
            this.idRenovation = id;
        }
        public RoomRenovationDTO(int id, int idRoom,int idRoomSecond, DateTime dateBegin, DateTime dateEnd, String description)
        {
            this.dateBegin = dateBegin;
            this.dateEnd = dateEnd.AddHours(23);
            this.dateEnd.AddMinutes(59);
            this.description = description;
            this.idRoom = idRoom;
            this.idRenovation = id;
            this.idRoomSecond = idRoomSecond;
        }

        public RoomRenovationDTO(int id, int idRoom, Purpose purpose, DateTime dateBegin, DateTime dateEnd, String description)
        {
            this.dateBegin = dateBegin;
            this.dateEnd = dateEnd.AddHours(23);
            this.dateEnd.AddMinutes(59);
            this.description = description;
            this.idRoom = idRoom;
            this.idRenovation = id;
            this.purpose = purpose;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnProperychanged(string name)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(name));
            }
        }

        public int IdRenovation
        {
            get
            {
                return idRenovation;
            }
            set
            {
                if (value != idRenovation)
                {
                    idRenovation = value;
                    OnProperychanged("IdRenovation");
                }
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
        public int IdRoomSecond
        {
            get
            {
                return idRoomSecond;
            }
            set
            {
                if (value != idRoomSecond)
                {
                    idRoomSecond = value;
                    OnProperychanged("IdRoomSecond");
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
    }
}
