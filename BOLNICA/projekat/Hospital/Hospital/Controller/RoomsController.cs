
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
    public class RoomsController
    {
        private RoomsService service;
        public RoomsController()
        {
            service = new RoomsService();
        }
        public void scheduleRenovation(RoomRenovationDTO renovation)
        {
            service.scheduleRenovation(new RoomRenovation(renovation.IdRenovation,renovation.IdRoom,renovation.DateBegin,renovation.DateEnd,renovation.Description));
        }
        public List<RoomDTO> getAll()
        {
            List<RoomDTO> rooms = new List<RoomDTO>();
            foreach (Room room in service.getAll())
            {
                if(room.Occupancy == false)
                {
                rooms.Add(new RoomDTO(room.Id, room.Floor, room.Occupancy, room.Purpose, room.Capacity));
                }
            }
            return rooms;
        }
        public void save(RoomDTO newRoom)
        {
            service.save(new Room(service.generateId(), newRoom.Floor, newRoom.Occupancy, newRoom.Purpose, newRoom.Capacity));
        }

        public void deleteById(int id)
        {
            service.deleteById(id);
        }

        internal void update(RoomDTO room)
        {
            service.update(new Room(room.Id, room.Floor, room.Occupancy, room.Purpose, room.Capacity));
        }

        public List<Room> roomByFloor(string floor)
        {
            return service.roomByFloor(floor);
        }
        public List<Room> roomsByType(String type)
        {
            return service.roomsByType(type);
        }

        public List<Room> roomByInventory(int idInventory, int quantity)
        {
            return service.roomByInventory(idInventory, quantity);
        }

        public List<RoomDTO> getNewRooms()
        {
            List<RoomDTO> rooms = new List<RoomDTO>();
            foreach (Room room in service.getNewRooms())
            {
                rooms.Add(new RoomDTO(room.Id, room.Floor, room.Occupancy, room.Purpose, room.Capacity));
            }
            return rooms;
        }

        internal bool isRoomAvailableInventoryMovement(StaticInventoryMovement newMovement)
        {
            return service.isRoomAvailableInventoryMovement(newMovement);
        }
    }
}
