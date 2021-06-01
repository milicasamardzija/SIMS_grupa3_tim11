using Hospital.FileStorage.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.Service
{
    public class InventoryService
    {
        private InventoryIFileStorage inventoryStorage;
        private IRoomInventoryFileStorage roomInventoryStorage;
        private List<RoomInventory> allRoomInventory;
        private List<Inventory> inventories;
        private RoomInventoryService roomInventoryService;
        public InventoryService()
        {
            inventoryStorage = new InventoryFileStorage("./../../../../Hospital/files/storageInventory.json");
            roomInventoryStorage = new RoomInventoryFileStorage("./../../../../Hospital/files/storageRoomInventory.json");
            allRoomInventory = roomInventoryStorage.GetAll();
            inventories = inventoryStorage.GetAll();
            roomInventoryService = new RoomInventoryService();
        }

        public List<Inventory> getInventoryForRoom(int idRoom)
        {
            List<Inventory> ret = new List<Inventory>();
            foreach (RoomInventory roomInventory in roomInventoryService.getAll())
            {
                if (roomInventory.IdRoom.Equals(idRoom))
                {
                    Inventory inventory = inventoryStorage.FindById(roomInventory.IdInventory);
                    if (inventory != null)
                        ret.Add(new Inventory(inventory.Id, inventory.Name, roomInventory.Quantity, inventory.Type));
                    else
                        break;
                }

            }
            return ret;
        }
        public Inventory FindById(int id)
        {
            return inventoryStorage.FindById(id);
        }
        public List<Inventory> getAll()
        {
            return inventoryStorage.GetAll();
        }

        public void delete(int id)
        {
            inventoryStorage.DeleteById(id);
        }

        public void update(Inventory updatedInventory)
        {
            List<Inventory> inventories = inventoryStorage.GetAll();
            foreach (Inventory inventory in inventories)
            { 
                if (inventory.Id == updatedInventory.Id)
                {
                    inventory.Name = updatedInventory.Name;
                    inventory.Quantity = updatedInventory.Quantity;
                    inventory.Type = updatedInventory.Type;
                    break;
                }
            }
            inventoryStorage.SaveAll(inventories);
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
                if (inventory.Id == roomInventory.IdInventory)
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
                if (inventory.Id == roomInventory.IdInventory)
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
            inventoryStorage.SaveAll(inventories);
            roomInventoryStorage.SaveAll(allRoomInventory);
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
        public List<Inventory> inventoryByName(string name)
        {
            return inventoryStorage.inventoryByName(name);
        }
        public List<Inventory> inventoryByType(string type)
        {
            return inventoryStorage.inventoryByType(type);
        }
        public List<Inventory> inventoryByQuantity(int quantity)
        {
            return inventoryStorage.inventoryByQuantity(quantity);
        }
        public int generateId()
        {
            int ret = 0;
            foreach (Inventory inventoryBig in inventoryStorage.GetAll())
            {
                foreach (Inventory inventory in inventoryStorage.GetAll())
                {
                    if (ret == inventory.Id)
                    {
                        ++ret;
                        break;
                    }
                }
            }
            return ret;
        }

        public void save(Inventory inventory)
        {
            inventory.Id = generateId();
            inventoryStorage.Save(inventory);
        }
    }
}
