using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.DTO
{
    public class RoomSeparateDTO : RoomRenovationDTO, INotifyPropertyChanged
    {
        private Purpose purpose;
        public RoomSeparateDTO() { }
        public RoomSeparateDTO(int id, int idRoom, Purpose purpose, DateTime dateBegin, DateTime dateEnd, String description) : base(id,idRoom,dateBegin,dateEnd,description)
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
                    OnProperychanged("Purpose");
                }
            }
        }
    }
}
