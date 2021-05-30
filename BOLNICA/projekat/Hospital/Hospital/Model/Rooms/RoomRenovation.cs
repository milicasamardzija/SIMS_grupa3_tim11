using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.Model
{
    public class RoomRenovation : Entity
    {
        private DateTime dateBegin;
        private DateTime dateEnd;
        private String description;
        private int idRoom;
        public RoomRenovation(int id, int idRoom, DateTime dateBegin, DateTime dateEnd, String description) : base(id)
        {
            this.dateBegin = dateBegin;
            this.dateEnd = dateEnd.AddHours(23);
            this.dateEnd.AddMinutes(59);
            this.description = description;
            this.idRoom = idRoom;
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
                    description = value;;
                }
            }
        }

    }
}
