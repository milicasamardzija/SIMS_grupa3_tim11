using Hospital.FileStorage;
using Hospital.FileStorage.Interfaces;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Hospital.Model
{
    class StaticInvnetoryMovementFileStorage : GenericFileStorage<StaticInventoryMovement>, IStaticInventoryMovementFileStorage
    {

        public StaticInvnetoryMovementFileStorage(string filePath) : base(filePath)
        {
        }

        public void DeleteByIds(int idRoomIn, int idRoomOut, int idInvetory)
        {
            List<StaticInventoryMovement> all = GetAll();

            foreach (StaticInventoryMovement task in all)
            {
                if (task.RoomInId == idRoomIn && task.RoomOutId == idRoomOut && task.InventoryId == idInvetory)
                {
                    all.Remove(task);
                    break;
                }
            }
            SaveAll(all);
        }
    }
}
