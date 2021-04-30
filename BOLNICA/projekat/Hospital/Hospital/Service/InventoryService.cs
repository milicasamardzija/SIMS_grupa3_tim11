using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.Service
{
    class InventoryService
    {
        public void moveInventory()
        {
          /*  InventoryFileStorage inventoryStorage = new InventoryFileStorage();
            RoomFileStorage roomStorage = new RoomFileStorage();
            RoomInventoryFileStorage roomInventoryStorage = new RoomInventoryFileStorage();

            //ako ne postoji inventar u toj sobi, odnosno pravi se novi RoomInventory objekat
            Boolean nadjen = true;

            //liste
            List<RoomInventory> all = roomInventoryStorage.GetAll();
            List<Inventory> inventories = inventoryStorage.GetAll();

            foreach (RoomInventory roomInv in all)
            {
                //ako vec postoji zeljeni inventar u unetoj sobi
                if (roomInv.idInventory == inventory.InventoryId && roomInv.idRoom == idRoom)
                {
                    roomInv.Quantity += quantity;   //povecava se kolicina inventara u sobi
                    nadjen = false;
                    roomInventoryStorage.SaveAll(all);           //kompletna izmenja lista se serijalizuje
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
                    if (r.RoomId == idRoom)
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

                RoomInventory newInventory = new RoomInventory(room.RoomId, room, invent.InventoryId, invent, quantity);
                roomInventoryStorage.Save(newInventory);

            }

            foreach (Inventory i in inventories)
            {
                if (i.InventoryId == inventory.InventoryId)
                {
                    i.Quantity -= quantity;
                    inventoryStorage.SaveAll(inventories);
                    //                       listInventory[index] = new Inventory(inventory.InventoryId, inventory.Name, i.Quantity, inventory.Type);
                    break;
                }
            }

            StaticInvnetoryMovementFileStorage storage = new StaticInvnetoryMovementFileStorage();
            storage.DeleteByIds(idRoom, -1, inventory.InventoryId);*/
        }
    }
}
