using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.Model.Rooms
{
    public class RoomMerge : RoomRenovation
    {
        private int idRoomSecond;
        private Purpose purpose;
        private int idNewRoom;

        public RoomMerge(int id, int idRoomFirst,int idRoomSecond, DateTime dateBegin, DateTime dateEnd, Purpose purpose, String description) : base(id, idRoomFirst,dateBegin,dateEnd,description)
        {
            this.idRoomSecond = idRoomSecond;
            this.purpose = purpose;
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
                }
            }
        }
        public int IdNewRoom
        {
            get
            {
                return idNewRoom;
            }
            set
            {
                if (value != idNewRoom)
                {
                    idNewRoom = value;
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
                }
            }
        }
    }
}
