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
    class StaticInvnetoryMovementFileStorage
    {

        public StaticInvnetoryMovementFileStorage()
        {
     
        }

        public List<StaticInventoryMovement> GetAll()
        {
            List<StaticInventoryMovement> allInventory = new List<StaticInventoryMovement>();

            allInventory = JsonConvert.DeserializeObject<List<StaticInventoryMovement>>(File.ReadAllText(@"./../../../../Hospital/files/storageStaticInventory.json"));

            return allInventory;
        }

        public void Save(StaticInventoryMovement newInventory)
        {
            List<StaticInventoryMovement> allInventories = GetAll();

            allInventories.Add(newInventory);

            SaveAll(allInventories);
        }

        public void SaveAll(List<StaticInventoryMovement> inventories)
        {
            using (StreamWriter file = File.CreateText(@"./../../../../Hospital/files/storageStaticInventory.json"))
            {
                JsonSerializer serializer = new JsonSerializer();
                serializer.Serialize(file, inventories);
            }
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
