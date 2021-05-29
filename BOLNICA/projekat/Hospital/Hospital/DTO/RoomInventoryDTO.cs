using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.DTO
{
    class RoomInventoryDTO
    {
        private int idRoom;
        private int idInventory;
        private int quantity;

        public int IdRoom
        {
            get
            {
                return idRoom;
            }
            set
            {
                idRoom = value;
            }
        }

        public int IdInventory
        {
            get
            {
                return idInventory;
            }
            set
            {
                idInventory = value;
            }
        }

        public int Quantity
        {
            get
            {
                return quantity;
            }
            set
            {
                quantity = value;
            }
        }

        public RoomInventoryDTO() { }

        public RoomInventoryDTO(int idRoomIn, int inventoryId, int quantity)
        {
            this.IdRoom = idRoomIn;
            this.IdInventory = inventoryId;
            this.Quantity = quantity;
        }
    }
}
