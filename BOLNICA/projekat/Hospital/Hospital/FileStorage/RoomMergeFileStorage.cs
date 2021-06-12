using Hospital.FileStorage.Interfaces;
using Hospital.Model.Rooms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.FileStorage
{
    public class RoomMergeFileStorage:GenericFileStorage<RoomMerge>, IRoomMergeFileStorage
    {
        public RoomMergeFileStorage(String filePath) : base(filePath) { }
    }
}
