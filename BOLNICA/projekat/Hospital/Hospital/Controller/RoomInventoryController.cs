using Hospital.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.Controller
{
    public class RoomInventoryController
    {
        private RoomInventoryService service = new RoomInventoryService();
        public List<RoomInventory> getAll()
        {
            return service.getAll(); 
        }
    }
}
