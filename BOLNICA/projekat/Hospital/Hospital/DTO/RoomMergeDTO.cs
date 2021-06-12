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

        public RoomMergeDTO(int id, int idRoomFirst, int idRoomSecond, DateTime dateBegin, DateTime dateEnd, Purpose purpose, String description) : base(id, idRoomFirst, dateBegin, dateEnd, description)
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
                    OnProperychanged("IdRoomSecond");
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
