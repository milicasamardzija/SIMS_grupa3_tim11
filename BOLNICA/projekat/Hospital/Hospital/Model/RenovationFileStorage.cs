using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.Model
{
    class RenovationFileStorage
    {
        public List<RoomRenovation> GetAll()
        {
            List<RoomRenovation> all = new List<RoomRenovation>();

            all = JsonConvert.DeserializeObject<List<RoomRenovation>>(File.ReadAllText(@"./../../../../Hospital/files/storageRenovationRooms.json"));

            return all;
        }

        public void Save(RoomRenovation newInventory)
        {
            List<RoomRenovation> all = GetAll();

            all.Add(newInventory);

            SaveAll(all);
        }

        public void SaveAll(List<RoomRenovation> rooms)
        {
            using (StreamWriter file = File.CreateText(@"./../../../../Hospital/files/storageRenovationRooms.json"))
            {
                JsonSerializer serializer = new JsonSerializer();
                serializer.Serialize(file, rooms);
            }
        }

        public void DeleteById(int id)
        {
            List<RoomRenovation> all = GetAll();

            foreach (RoomRenovation room in all)
            {
                if (room.idRoom == id)
                {
                    all.Remove(room);
                    break;
                }
            }
            SaveAll(all);
        }

        public RoomRenovation FindById(int id)
        {
            List<RoomRenovation> all = GetAll();
            RoomRenovation ret = null;

            foreach (RoomRenovation room in all)
            {
                if (room.idRoom == id)
                {
                    ret = room;
                    break;
                }
            }

            return ret;
        }
    }
}
