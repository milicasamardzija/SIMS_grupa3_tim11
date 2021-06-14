using Hospital.DTO;
using Hospital.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.Controller
{
    public class InventoryController
    {
        private InventoryService service = new InventoryService();
        public void moveInventory(RoomInventory roomInventory, int idRoomOut)
        {
            service.moveInventory(roomInventory, idRoomOut);
        }
        public List<InventoryDTO> getAll()
        {
            List<InventoryDTO> inventories = new List<InventoryDTO>();
            if(service.getAll() != null)
                foreach (Inventory inventory in service.getAll())
                {
                    inventories.Add(new InventoryDTO(inventory.Id,inventory.Name,inventory.Quantity,inventory.Type));
                }
            return inventories;
        }
        public List<Inventory> getInventory()
        {
            return service.getAll();
        }
        public List<InventoryDTO> loadJasonInventory(int roomOutId)
        {
            List<InventoryDTO> inventories = new List<InventoryDTO>();
            foreach (Inventory inventory in service.loadJasonInventory(roomOutId))
            {
                inventories.Add(new InventoryDTO(inventory.Id, inventory.Name, inventory.Quantity, inventory.Type));
            }
            return inventories;
        }

        public List<InventoryDTO> getInventoryForRoom(int id)
        {
            List<InventoryDTO> inventories = new List<InventoryDTO>();
            foreach (Inventory inventory in service.getInventoryForRoom(id))
            {
                inventories.Add(new InventoryDTO(inventory.Id, inventory.Name, inventory.Quantity, inventory.Type));
            }
            return inventories;
        }
        public List<Inventory> inventoryByName(string name)
        {
            return service.inventoryByName(name);
        }
        public List<Inventory> inventoryByType(string type)
        {
            return service.inventoryByType(type);
        }
        public List<Inventory> inventoryByQuantity(int quantity)
        {
            return service.inventoryByQuantity(quantity);
        }

        public void save(InventoryDTO inventory)
        {
            service.save(new Inventory(inventory.Id,inventory.Name,inventory.Quantity,inventory.Type));
        }

        public void delete(int idInventory)
        {
            service.delete(idInventory);
        }

        public void update(InventoryDTO inventory)
        {
            service.update(new Inventory(inventory.Id, inventory.Name, inventory.Quantity, inventory.Type));
        }
    }
}
