using Hospital.FileStorage.Interfaces;
using Hospital.Model.Rooms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.FileStorage
{
    public class RoomSeparateFileStorage : GenericFileStorage<RoomSeparate>, IRoomSeparateFileStorage
    {
        public RoomSeparateFileStorage(String filePath) : base(filePath) { }
    }
}
