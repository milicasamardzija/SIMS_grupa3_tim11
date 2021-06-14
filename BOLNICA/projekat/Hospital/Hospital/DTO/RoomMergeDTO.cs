using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.DTO
{
    public class RoomMergeDTO : RoomRenovationDTO, INotifyPropertyChanged
    {
        private int idRoomSecond;
        private Purpose purpose;
        private int idNewRoom;

        public RoomMergeDTO() { }
        public RoomMergeDTO(int id, int idRoomFirst, int idRoomSecond, DateTime dateBegin, DateTime dateEnd, Purpose purpose, String description, int idNewRoom) : base(id, idRoomFirst, dateBegin, dateEnd, description)
        {
            this.idRoomSecond = idRoomSecond;
            this.purpose = purpose;
            this.IdNewRoom = idNewRoom;
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
                    OnProperychanged("IdNewRoom");
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
