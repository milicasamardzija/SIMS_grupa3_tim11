using Hospital.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.Controller
{
    public class InventoryController
    {
        private InventoryService service = new InventoryService();
        public void moveInventory(RoomInventory roomInventory, int idRoomOut)
        {
            service.moveInventory(roomInventory, idRoomOut);
        }
    }
}
