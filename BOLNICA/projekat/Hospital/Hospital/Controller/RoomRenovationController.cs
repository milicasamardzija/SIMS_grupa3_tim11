using Hospital.DTO;
using Hospital.Model;
using Hospital.Model.Rooms;
using Hospital.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.Controller
{
    public class RoomRenovationController
    {
        private RoomRenovationService service;
        public RoomRenovationController()
        {
            service = new RoomRenovationService();
        }
        public void deleteRenovation(RoomRenovationDTO renovation)
        {
            service.deleteRenovation(new RoomRenovation(renovation.IdRenovation,renovation.IdRoom,renovation.DateBegin,renovation.DateEnd,renovation.Description));
        }
        public List<RoomRenovationDTO> getAll()
        {
            List<RoomRenovationDTO> renovations = new List<RoomRenovationDTO>();
            foreach (RoomRenovation renovation in service.getAll())
            {
                renovations.Add(new RoomRenovationDTO(renovation.Id, renovation.IdRoom, renovation.DateBegin, renovation.DateEnd, renovation.Description));
            }
            return renovations;
        }
        public void mergeRoomsSchedule(RoomRenovationDTO renovation)
        {
            String description = "Spajanje prostorije broj " + renovation.IdRoom + " sa prostorijom broj " + renovation.IdRoomSecond + ".";
            service.mergeRoomsSchedule(new RoomMerge(service.generateIdMerge(), renovation.IdRoom, renovation.IdRoomSecond, renovation.DateBegin, renovation.DateEnd, description));
        }

        public void separateRoomsSchedule(RoomRenovationDTO renovation)
        {
            String description = "Razdvajanje prostorije broj " + renovation.IdRoom + ".";
            service.separateRoomsSchedule(new RoomSeparate(service.generateIdSeparate(), renovation.IdRoom, renovation.Purpose, renovation.DateBegin, renovation.DateEnd, description));
        }
        public List<RoomRenovationDTO> getAllMergeRenovations()
        {
            List<RoomRenovationDTO> renovations = new List<RoomRenovationDTO>();
            foreach(RoomMerge renovation in service.getAllMergeRenovations())
            {
                renovations.Add(new RoomRenovationDTO());
            }
            return renovations;
        }

        public List<RoomRenovationDTO> getAllMSeparateRenovations()
        {
            List<RoomRenovationDTO> renovations = new List<RoomRenovationDTO>();
            foreach (RoomSeparate renovation in service.getAllSeparateRenovations())
            {
                renovations.Add(new RoomRenovationDTO());
            }
            return renovations;
        }
    }
}
