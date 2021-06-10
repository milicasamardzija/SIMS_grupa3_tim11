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

        public RoomMerge(int id, int idRoomFirst,int idRoomSecond, DateTime dateBegin, DateTime dateEnd, String description) : base(id, idRoomFirst,dateBegin,dateEnd,description)
        {
            this.idRoomSecond = idRoomSecond;
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
    }
}
