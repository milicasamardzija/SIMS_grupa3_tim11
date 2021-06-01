using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hospital.FileStorage.Interfaces;

namespace Hospital.Service
{
    public class RoomInventoryService
    {
        private IRoomInventoryFileStorage storage;
        public RoomInventoryService()
        {
            storage = new RoomInventoryFileStorage("./../../../../Hospital/files/storageRoomInventory.json");
        }
        public List<RoomInventory> getAll()
        {
            return storage.GetAll(); 
        }
    }
}
