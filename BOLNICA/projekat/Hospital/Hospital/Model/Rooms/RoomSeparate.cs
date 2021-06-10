using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.Model.Rooms
{
    public class RoomSeparate : RoomRenovation
    {
        private Purpose purpose;

        public RoomSeparate(int id, int idRoom, Purpose purpose, DateTime dateBegin, DateTime dateEnd, String description) : base(id,idRoom,dateBegin,dateEnd,description)
        {
            this.purpose = purpose;
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
                }
            }
        }
    }
}
