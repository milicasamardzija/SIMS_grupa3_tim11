
using Hospital.DTO;
using Hospital.Model;
using Hospital.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.Controller
{
    class RoomsController
    {
        private RoomsService service = new RoomsService();
        public void zakaziRenoviranje(RoomRenovation renovation)
        {
            service.zakaziRenoviranje(renovation);
        }

        public List<RoomDTO> getAll()
        {
            List<RoomDTO> rooms = new List<RoomDTO>();
            foreach (Room room in service.getAll())
            {
                rooms.Add(new RoomDTO(room.Id, room.Floor, room.Occupancy, room.Purpose, room.Capacity));
            }
            return rooms;
        }
        public void save(RoomDTO newRoom)
        {
            service.save(new Room(service.generateId(),newRoom.Floor,newRoom.Occupancy,newRoom.Purpose,newRoom.Capacity));
        }

        public void deleteById(int id)
        {
            service.deleteById(id);
        }

        internal void update(RoomDTO room)
        {
            service.update(new Room(room.Id,room.Floor,room.Occupancy,room.Purpose,room.Capacity));
        }
    }
}
