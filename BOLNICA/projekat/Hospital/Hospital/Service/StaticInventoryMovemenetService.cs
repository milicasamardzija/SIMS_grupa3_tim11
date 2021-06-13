using Hospital.FileStorage.Interfaces;
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
        private IStaticInventoryMovementFileStorage storage;
        private InventoryIFileStorage inventoryStorage { get; set; }
        private IRoomInventoryFileStorage roomInventoryStorage { get; set; }
        public StaticInventoryMovemenetService()
        {
            storage = new StaticInvnetoryMovementFileStorage("./../../../../Hospital/files/storageStaticInventory.json");
            inventoryStorage = new InventoryFileStorage("./../../../../Hospital/files/storageInventory.json");
            roomInventoryStorage = new RoomInventoryFileStorage("./../../../../Hospital/files/storageRoomInventory.json");
        }
        public void moveInventoryStatic(StaticInventoryMovement movement)
        {
            moveInventory(movement);
            storage.DeleteByIds(movement.RoomInId, movement.RoomOutId, movement.InventoryId);
        }
        public void saveNewMovement(StaticInventoryMovement movement)
        {
            storage.Save(movement);
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

        public void moveInventory(StaticInventoryMovement movement)
        {
            Boolean nadjen = true;
            List<RoomInventory> all = roomInventoryStorage.GetAll();
            List<Inventory> inventories = inventoryStorage.GetAll();

            nadjen = moveInto(movement, nadjen, all, inventories);

            moveOut(movement, all, inventories);
        }

        private void moveOut(StaticInventoryMovement movement, List<RoomInventory> all, List<Inventory> inventories)
        {
            if (movement.RoomOutId == -1)
            {
                moveFromStorage(movement, all, inventories);
            }
            else
            {
                moveFromRoom(movement, all, inventories);
            }
        }

        private void moveFromRoom(StaticInventoryMovement movement, List<RoomInventory> all, List<Inventory> inventories)
        {
            foreach (RoomInventory roomInv in all)
            {
                if (roomInv.IdRoom == movement.RoomOutId && roomInv.IdInventory == movement.InventoryId)
                {
                    minusInventory(movement, inventories, roomInv);

                    ZeroQuantityInventory(all, roomInv);

                    roomInventoryStorage.SaveAll(all);
                    break;
                }
            }
        }

        private void minusInventory(StaticInventoryMovement movement, List<Inventory> inventories, RoomInventory roomInv)
        {
            if (roomInv.Quantity < movement.Quantity)
            {
                int inRoomQuantity = roomInv.Quantity;
                roomInv.Quantity -= inRoomQuantity;
                int storageQuantity = movement.Quantity - inRoomQuantity;
                foreach (Inventory inventory in inventories)
                {
                    if (movement.InventoryId == inventory.Id)
                    {
                        if (inventory.Quantity < storageQuantity)
                        {
                            PremestanjeOdbijenoInventar odbijeno = new PremestanjeOdbijenoInventar();
                            odbijeno.Show();
                            break;
                        }

                        inventory.Quantity -= storageQuantity;
                        inventoryStorage.SaveAll(inventories);
                        break;
                    }
                }

            }
            else
            {
                roomInv.Quantity -= movement.Quantity;
            }
        }

        private static void ZeroQuantityInventory(List<RoomInventory> all, RoomInventory roomInv)
        {
            if (roomInv.Quantity == 0)
            {
                all.Remove(roomInv);
            }
        }

        private void moveFromStorage(StaticInventoryMovement movement, List<RoomInventory> all, List<Inventory> inventories)
        {
            foreach (Inventory inventory in inventories)
            {
                if (inventory.Id == movement.InventoryId)
                {
                    inventory.Quantity -= movement.Quantity;

                    inventoryStorage.SaveAll(inventories);
                    roomInventoryStorage.SaveAll(all);
                    break;
                }
            }
        }

        private bool moveInto(StaticInventoryMovement movement, bool nadjen, List<RoomInventory> all, List<Inventory> inventories)
        {
            if (movement.RoomInId != -1)
            {
                nadjen = moveIntoRoom(movement, nadjen, all);
            }
            else
            {
                moveIntoStorage(movement, inventories);
            }

            return nadjen;
        }

        private void moveIntoStorage(StaticInventoryMovement movement, List<Inventory> inventories)
        {
            foreach (Inventory invent in inventories)
            {
                if (invent.Id == movement.InventoryId)
                {
                    invent.Quantity += movement.Quantity;
                    inventoryStorage.SaveAll(inventories);
                    break;
                }
            }
        }

        private bool moveIntoRoom(StaticInventoryMovement movement, bool nadjen, List<RoomInventory> all)
        {
            foreach (RoomInventory roomInv in all)
            {
                if (roomInv.IdInventory == movement.InventoryId && roomInv.IdRoom == movement.RoomInId)
                {
                    roomInv.Quantity += movement.Quantity;
                    nadjen = false;
                    roomInventoryStorage.SaveAll(all);
                    break;
                }

            }

            newRoomInventory(movement, nadjen, all);

            return nadjen;
        }

        private static void newRoomInventory(StaticInventoryMovement movement, bool nadjen, List<RoomInventory> all)
        {
            if (nadjen)
            {
                all.Add(new RoomInventory(-1, movement.RoomInId, movement.InventoryId, movement.Quantity));
            }
        }

        public void saveAll(List<StaticInventoryMovement> inventories)
        {
            storage.SaveAll(inventories);
        }
        
    }
}
