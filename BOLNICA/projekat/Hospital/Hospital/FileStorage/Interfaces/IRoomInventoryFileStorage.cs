using Hospital.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.FileStorage.Interfaces
{
    public interface IRoomInventoryFileStorage : GenericRepository<RoomInventory>
    {
        void DeleteByIdInventory(int id);
        void DeleteByIdRoom(int id);
    }
}
