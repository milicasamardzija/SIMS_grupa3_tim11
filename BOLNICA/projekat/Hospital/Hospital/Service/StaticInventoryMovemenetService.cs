using Hospital.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.Service
{
    public class StaticInventoryMovemenetService
    {
        private StaticInvnetoryMovementFileStorage storage;
        public StaticInventoryMovemenetService()
        {
            storage = new StaticInvnetoryMovementFileStorage();
        }
        public void DeleteByRoomsAndDate(int idRoomIn, int idRoomOut, DateTime date)
        {
            List<StaticInventoryMovement> all = storage.GetAll();
            foreach (StaticInventoryMovement task in all)
            {
                if (task.RoomInId == idRoomIn && task.RoomOutId == idRoomOut && task.Date == date)
                {
                    all.Remove(task);
                    break;
                }
            }
            storage.SaveAll(all);
        }
        public List<StaticInventoryMovement> getAll()
        {
            return storage.GetAll();
        }
        public void saveAll(List<StaticInventoryMovement> inventories)
        {
            storage.SaveAll(inventories);
        }
    }
}
