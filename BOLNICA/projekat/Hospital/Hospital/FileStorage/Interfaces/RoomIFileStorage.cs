using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.FileStorage.Interfaces
{
    public interface RoomIFileStorage : GenericRepository<Room>
    {
        List<Room> roomByFloor(string floor);
        List<Room> roomsByType(String type);
    }
}
