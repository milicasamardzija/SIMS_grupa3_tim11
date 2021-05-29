using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.FileStorage.Interfaces
{
    public interface InventoryIFileStorage : GenericRepository<Inventory>
    {
        List<Inventory> inventoryByName(string name);
        List<Inventory> inventoryByType(string type);
        List<Inventory> inventoryByQuantity(int quantity);
    }
}
