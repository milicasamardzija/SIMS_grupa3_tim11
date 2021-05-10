using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.Service
{
    public class InventoryService
    {
        private RoomFileStorage roomStorage;
        private InventoryFileStorage inventoryStorage;
        private RoomInventoryFileStorage roomInventoryStorage;
        private List<RoomInventory> allRoomInventory;
        private List<Inventory> inventories;

        public InventoryService()
        {
            roomStorage = new RoomFileStorage();
            inventoryStorage = new InventoryFileStorage();
            roomInventoryStorage = new RoomInventoryFileStorage();
            allRoomInventory = roomInventoryStorage.GetAll();
            inventories = inventoryStorage.GetAll();
        }
        public void moveInventory(RoomInventory roomInventory, int idRoomOut)
        {
            if (moveStorage(roomInventory, idRoomOut))
            {
                moveInventoryStorage(roomInventory, idRoomOut);
            }
            else
            {
                moveInventoryRooms(roomInventory, idRoomOut);
            }
        }

        private Boolean moveStorage(RoomInventory roomInventory, int idRoomOut)
        {
            return (roomInventory.IdRoom == -1 || idRoomOut == -1);
        }

        private Boolean inventoryExistsInRoom(RoomInventory roomInventory, List<RoomInventory> roomInventories)
        {
            foreach (RoomInventory roomInv in roomInventories)
            {
                if (roomInv.IdRoom == roomInventory.IdRoom && roomInv.IdInventory == roomInventory.IdInventory)
                {
                    return true;
                }
            }
            return false;
        }

        private void minusQuantityStorage(RoomInventory roomInventory)
        {
            foreach (Inventory inventory in inventories)
            {
                if (inventory.InventoryId == roomInventory.IdInventory)
                {
                    inventory.Quantity -= roomInventory.Quantity;
                }
            }
        }

        private void minusQuantityRoom(RoomInventory roomInventory, int idRoomOut)
        {
            foreach (RoomInventory roomInv in allRoomInventory)
            {
                if (roomInv.IdRoom == idRoomOut && roomInv.IdInventory == roomInventory.IdInventory)
                {
                    roomInv.Quantity -= roomInventory.Quantity;
                    inventoryInRoomEqualsZero(roomInv);
                }
            }
        }

        private void inventoryInRoomEqualsZero(RoomInventory roomInventory)
        {
            if (roomInventory.Quantity == 0)
            {
                allRoomInventory.Remove(roomInventory);
            }
        }

        private void addQunatityStorage(RoomInventory roomInventory)
        {
            foreach (Inventory inventory in inventories)
            {
                if (inventory.InventoryId == roomInventory.IdInventory)
                {
                    inventory.Quantity += roomInventory.Quantity;
                }
            }
        }

        private void addQuantityRoom(RoomInventory roomInventory)
        {
            if (inventoryExistsInRoom(roomInventory, allRoomInventory))
            {
                addQuantityRoom(roomInventory, allRoomInventory);
            }
            else
            {
                addNewInventoryInRoom(roomInventory);
            }
        }

        private void addNewInventoryInRoom(RoomInventory roomInventory)
        {
            allRoomInventory.Add(roomInventory);
        }

        private static void addQuantityRoom(RoomInventory roomInventory, List<RoomInventory> roomInventories)
        {
            foreach (RoomInventory roomInv in roomInventories)
            {
                if (roomInv.IdInventory == roomInventory.IdInventory && roomInv.IdRoom == roomInventory.IdRoom)
                {
                    roomInv.Quantity += roomInventory.Quantity;
                }
            }
        }

        private void saveChangeOfInventoryState()
        {
            inventoryStorage.serialize(inventories);
            roomInventoryStorage.serialize(allRoomInventory);
        }

        private void moveInventoryRooms(RoomInventory roomInventory, int idRoomOut)
        {
            addQuantityRoom(roomInventory);
            minusQuantityRoom(roomInventory, idRoomOut);
            saveChangeOfInventoryState();
        }

        private void moveInventoryStorage(RoomInventory roomInventory, int idRoomOut)
        {
            if (moveInventoryFromStorage(idRoomOut))
            {
                moveInventoryFromStorage(roomInventory);
            }
            else
            {
                moveInventoryIntoStorage(roomInventory, idRoomOut);
            }
            saveChangeOfInventoryState();
        }

        private void moveInventoryIntoStorage(RoomInventory roomInventory, int idRoomOut)
        {
            addQunatityStorage(roomInventory);
            minusQuantityRoom(roomInventory, idRoomOut);
        }

        private void moveInventoryFromStorage(RoomInventory roomInventory)
        {
            addQuantityRoom(roomInventory);
            minusQuantityStorage(roomInventory);
        }

        private Boolean moveInventoryFromStorage(int idRoomOut)
        {
            if (idRoomOut == -1)
            {
                return true;
            }
            return false;
        }
    }
}
