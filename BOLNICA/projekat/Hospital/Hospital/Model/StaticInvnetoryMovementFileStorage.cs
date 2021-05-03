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
        private InventoryFileStorage inventoryStorage { get; set; }
        private RoomFileStorage roomStorage { get; set; }
        private RoomInventoryFileStorage roomInventoryStorage { get; set; }

        public StaticInvnetoryMovementFileStorage()
        {
            inventoryStorage = new InventoryFileStorage();
            roomStorage = new RoomFileStorage();
            roomInventoryStorage = new RoomInventoryFileStorage();
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

        public void moveInventoryStatic(Inventory inventory, int idRoomIn, int idRoomOut, int quantity)
        {
            moveInventory(inventory,idRoomIn,idRoomOut,quantity);
            this.DeleteByIds(idRoomIn, idRoomOut, inventory.InventoryId);
        }

        public void moveInventory(Inventory inventory, int idRoomIn, int idRoomOut, int quantity)
        {
            //ako ne postoji inventar u toj sobi, odnosno pravi se novi RoomInventory objekat
            Boolean nadjen = true;

            //liste
            List<RoomInventory> all = roomInventoryStorage.GetAll();
            List<Inventory> inventories = inventoryStorage.GetAll();

            if (idRoomIn != -1) {
                foreach (RoomInventory roomInv in all)
                {
                    //ako vec postoji zeljeni inventar u unetoj sobi
                    if (roomInv.idInventory == inventory.InventoryId && roomInv.idRoom == idRoomIn)
                    {
                        roomInv.Quantity += quantity;     //povecava se kolicina inventara u sobi
                        nadjen = false;
                        roomInventoryStorage.SaveAll(all);//kompletna izmenja lista se serijalizuje
                        break;
                    }

                }

                //ako ne postoji izabrani inventar u unetoj sobi
                if (nadjen)
                {
                    Room room = new Room();
                    Inventory invent = new Inventory();

                    foreach (Room r in roomStorage.GetAll())
                    {
                        if (r.RoomId == idRoomIn)
                        {
                            room.RoomId = r.RoomId;
                            room.Floor = r.Floor;
                            room.Occupancy = r.Occupancy;
                            room.Purpose = r.Purpose;
                            break;
                        }
                    }

                    foreach (Inventory i in inventoryStorage.GetAll())
                    {
                        if (i.InventoryId == inventory.InventoryId)
                        {
                            invent.InventoryId = i.InventoryId;
                            invent.Name = i.Name;
                            invent.Quantity = i.Quantity;
                            invent.Type = i.Type;
                            break;
                        }
                    }
                    RoomInventory newInventory = new RoomInventory(idRoomIn, room, invent.InventoryId, invent, quantity);
                    MessageBox.Show(Convert.ToString(newInventory.idRoom));
                    all.Add(newInventory);
                }
            }
            else //ako se prebacuje u magacin
            {
                foreach (Inventory invent in inventories)
                {
                    if (invent.InventoryId == inventory.InventoryId)
                    {
                        invent.Quantity += quantity;
                        inventoryStorage.SaveAll(inventories);
                        break;
                    }
                }
            }

            if (idRoomOut == -1)
            {
                foreach (Inventory i in inventories)
                {
                    if (i.InventoryId == inventory.InventoryId)
                    {
                        i.Quantity -= quantity;

                        if (i.Quantity == 0)
                        {
                            inventories.Remove(i);
                        }

                        inventoryStorage.SaveAll(inventories);
                        roomInventoryStorage.SaveAll(all);
                        break;
                    }
                }
            }
            else
            {
                foreach (RoomInventory ri in all)
                {
                    if (ri.idRoom == idRoomOut && ri.idInventory == inventory.InventoryId)
                    {
                        ri.Quantity -= quantity;

                        if (ri.Quantity == 0)
                        {
                            all.Remove(ri);
                        }

                        roomInventoryStorage.SaveAll(all);
                        break;
                    }
                }
            }
        }
    }
}
