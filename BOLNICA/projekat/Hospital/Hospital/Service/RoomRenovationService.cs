using Hospital.FileStorage.Interfaces;
using Hospital.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.Service
{
    public class RoomRenovationService
    {
        RenovationFileStorage storage;
        StaticInventoryMovemenetService movementService;
        public RoomRenovationService()
        {
            storage = new RenovationFileStorage("./../../../../Hospital/files/storageRenovationRooms.json");
            movementService = new StaticInventoryMovemenetService();
        }
        public void deleteRenovation(RoomRenovation renovation)
        {
            foreach (StaticInventoryMovement inventory in movementService.getAll())
            {
                if (inventory.RoomInId == renovation.Id && inventory.RoomOutId == -1 && inventory.Date == renovation.DateEnd)
                {
                    movementService.DeleteByRoomsAndDate(renovation.Id, -1, renovation.DateEnd);
                }
            }
            foreach (StaticInventoryMovement inventory in movementService.getAll())
            {
                if (inventory.RoomInId == -1 && inventory.RoomOutId == renovation.Id && inventory.Date == renovation.DateBegin)
                {
                    movementService.DeleteByRoomsAndDate(-1, renovation.Id, renovation.DateBegin);
                }
            }
            storage.DeleteById(renovation.IdRenovation);
        }
        public List<RoomRenovation> getAll()
        {
            return storage.GetAll();
        }
    }
}
