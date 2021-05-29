using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.Service
{
    public class RoomInventoryService
    {
        private RoomInventoryFileStorage storage;
        public RoomInventoryService()
        {
            storage = new RoomInventoryFileStorage();
        }
        public List<RoomInventory> getAll()
        {
            return storage.GetAll(); 
        }
    }
}
