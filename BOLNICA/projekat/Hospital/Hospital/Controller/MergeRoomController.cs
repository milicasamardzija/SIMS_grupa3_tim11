using Hospital.DTO;
using Hospital.Model.Rooms;
using Hospital.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.Controller
{
    public class MergeRoomController
    {
        private RoomMergeService service = new RoomMergeService();
        public void mergeRoomsSchedule(RoomMergeDTO renovation)
        {
            service.mergeRoomsSchedule(new RoomMerge(service.generateIdMerge(),renovation.IdRoom,renovation.IdRoomSecond,renovation.DateBegin,renovation.DateEnd,renovation.Purpose,renovation.Description));
        }
        public List<RoomMergeDTO> getAllMergeRenovations()
        {
            List<RoomMergeDTO> renovations = new List<RoomMergeDTO>();
            foreach (RoomMerge renovation in service.getAllMergeRenovations())
            {
                renovations.Add(new RoomMergeDTO(renovation.Id,renovation.IdRoom,renovation.IdRoomSecond,renovation.DateBegin,renovation.DateEnd,renovation.Purpose,renovation.Description));
            }
            return renovations;
        }

        public void mergeRooms(RoomMerge renovation)
        {
            service.mergeRooms(renovation);
        }
    }
}
