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
    public class RoomSeparateController
    {
        private RoomSeparateService service;
        public RoomSeparateController()
        {
            service = new RoomSeparateService();
        }
        public void separateRoomsSchedule(RoomRenovationDTO renovation)
        {
            service.separateRoomsSchedule(new RoomSeparate(service.generateIdSeparate(), renovation.IdRoom, renovation.Purpose, renovation.DateBegin, renovation.DateEnd, renovation.Description));
        }
        public List<RoomSeparateDTO> getAllSeparateRenovations()
        {
            List<RoomSeparateDTO> renovations = new List<RoomSeparateDTO>();
            foreach (RoomSeparate renovation in service.getAllSeparateRenovations())
            {
                renovations.Add(new RoomSeparateDTO(renovation.Id,renovation.IdRoom,renovation.Purpose,renovation.DateBegin,renovation.DateEnd,renovation.Description));
            }
            return renovations;
        }
        public List<RoomSeparate> getAll()
        {
            return service.getAllSeparateRenovations();
        }

        public void separateRooms(RoomSeparate renovation)
        {
            service.separateRooms(renovation);
        }
    }
}
