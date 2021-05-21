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
            List<RoomInventory> all = roomInventoryStorage.GetAll();
            List<Inventory> inventories = inventoryStorage.GetAll();
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

        public void DeleteByRoomsAndDate(int idRoomIn, int idRoomOut, DateTime date)
        {
            List<StaticInventoryMovement> all = GetAll();

            foreach (StaticInventoryMovement task in all)
            {
                if (task.RoomInId == idRoomIn && task.RoomOutId == idRoomOut && task.Date == date)
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
                    if (roomInv.IdInventory == inventory.InventoryId && roomInv.IdRoom == idRoomIn)
                    {
                        roomInv.Quantity += quantity;     //povecava se kolicina inventara u sobi
                        nadjen = false;
                        roomInventoryStorage.serialize(all);//kompletna izmenja lista se serijalizuje
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
                        inventoryStorage.serialize(inventories);
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

                        inventoryStorage.serialize(inventories);
                        roomInventoryStorage.serialize(all);
                        break;
                    }
                }
            }
            else
            {
                foreach (RoomInventory ri in all)
                {
                    if (ri.IdRoom == idRoomOut && ri.IdInventory == inventory.InventoryId)
                    {
                        if (ri.Quantity < quantity)
                        {
                            int inRoomQuantity = ri.Quantity;
                            ri.Quantity -= inRoomQuantity;
                            int storageQuantity = quantity - inRoomQuantity;
                                foreach (Inventory i in inventories)
                                {
                                    if (i.InventoryId == inventory.InventoryId)
                                    {
                                        if (i.Quantity < storageQuantity)
                                        {
                                            PremestanjeOdbijenoInventar odbijeno = new PremestanjeOdbijenoInventar();
                                            odbijeno.Show();
                                            return;
                                        }

                                        i.Quantity -= storageQuantity;

                                        inventoryStorage.serialize(inventories);
                                        break;
                                    }
                                }

                        } else
                        {
                            ri.Quantity -= quantity;
                        }


                        if (ri.Quantity == 0)
                        {
                            all.Remove(ri);
                        }

                        roomInventoryStorage.serialize(all);
                        break;
                    }
                }
            }
        }
    }
}
