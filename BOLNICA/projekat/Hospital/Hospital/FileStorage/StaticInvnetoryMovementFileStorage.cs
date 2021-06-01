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
        private InventoryIFileStorage inventoryStorage { get; set; }
        private RoomIFileStorage roomStorage { get; set; }
        private IRoomInventoryFileStorage roomInventoryStorage { get; set; }

        public StaticInvnetoryMovementFileStorage()
        {
            inventoryStorage = new InventoryFileStorage("./../../../../Hospital/files/storageInventory.json");
            roomStorage = new RoomFileStorage("./../../../../Hospital/files/storageRooms.json");
            roomInventoryStorage = new RoomInventoryFileStorage("./../../../../Hospital/files/storageRoomInventory.json");
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

        public void moveInventoryStatic(Inventory inventory, int idRoomIn, int idRoomOut, int quantity)
        {
            moveInventory(inventory,idRoomIn,idRoomOut,quantity);
            this.DeleteByIds(idRoomIn, idRoomOut, inventory.Id);
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
                    if (roomInv.IdInventory == inventory.Id && roomInv.IdRoom == idRoomIn)
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
                        if (r.Id == idRoomIn)
                        {
                            room.Id = r.Id;
                            room.Floor = r.Floor;
                            room.Occupancy = r.Occupancy;
                            room.Purpose = r.Purpose;
                            break;
                        }
                    }

                    foreach (Inventory i in inventoryStorage.GetAll())
                    {
                        if (i.Id == inventory.Id)
                        {
                            invent.Id = i.Id;
                            invent.Name = i.Name;
                            invent.Quantity = i.Quantity;
                            invent.Type = i.Type;
                            break;
                        }
                    }
                    RoomInventory newInventory = new RoomInventory(-1,-idRoomIn, room, invent.Id, invent, quantity);
                    all.Add(newInventory);
                }
            }
            else //ako se prebacuje u magacin
            {
                foreach (Inventory invent in inventories)
                {
                    if (invent.Id == inventory.Id)
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
                    if (i.Id == inventory.Id)
                    {
                        i.Quantity -= quantity;

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
                    if (ri.IdRoom == idRoomOut && ri.IdInventory == inventory.Id)
                    {
                        if (ri.Quantity < quantity)
                        {
                            int inRoomQuantity = ri.Quantity;
                            ri.Quantity -= inRoomQuantity;
                            int storageQuantity = quantity - inRoomQuantity;
                                foreach (Inventory i in inventories)
                                {
                                    if (i.Id == inventory.Id)
                                    {
                                        if (i.Quantity < storageQuantity)
                                        {
                                            PremestanjeOdbijenoInventar odbijeno = new PremestanjeOdbijenoInventar();
                                            odbijeno.Show();
                                            return;
                                        }

                                        i.Quantity -= storageQuantity;

                                        inventoryStorage.SaveAll(inventories);
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

                        roomInventoryStorage.SaveAll(all);
                        break;
                    }
                }
            }
        }
    }
}
