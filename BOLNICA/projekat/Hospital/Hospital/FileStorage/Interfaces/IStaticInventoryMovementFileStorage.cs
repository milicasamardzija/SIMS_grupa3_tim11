using Hospital.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.FileStorage.Interfaces
{
    public interface IStaticInventoryMovementFileStorage : GenericRepository<StaticInventoryMovement>
    {
        void DeleteByIds(int idRoomIn, int idRoomOut, int idInvetory);
    }
}
