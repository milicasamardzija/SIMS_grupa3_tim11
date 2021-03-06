using Hospital.FileStorage.Interfaces;
using Hospital.Model;
using Hospital.Model.Rooms;
using Hospital.View.Manager.Prostorije.RenoviranjeProstorije;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Hospital.Service
{
    class RoomsService
    {
        private RenovationIFileStorage renovationStorage;
        private ICheckupFileStorage checkupStorage;
        private IRoomInventoryFileStorage roominventoryStorage;
        private InventoryIFileStorage inventoryStorage;
        private IStaticInventoryMovementFileStorage staticInventoryStorage;
        private RoomIFileStorage roomStorage;

        public RoomsService()
        {
            renovationStorage = new RenovationFileStorage("./../../../../Hospital/files/storageRenovationRooms.json");
            checkupStorage = new CheckupFileStorage("./../../../../Hospital/files/storageCheckup.json");
            roominventoryStorage = new RoomInventoryFileStorage("./../../../../Hospital/files/storageRoomInventory.json");
            inventoryStorage = new InventoryFileStorage("./../../../../Hospital/files/storageInventory.json");
            staticInventoryStorage = new StaticInvnetoryMovementFileStorage("./../../../../Hospital/files/storageStaticInventory.json");
            roomStorage = new RoomFileStorage("./../../../../Hospital/files/storageRooms.json");
        }

        public void scheduleRenovation(RoomRenovation renovation)
        {
            if (isRoomAvailableRenovation(renovation))
            {
                renovation.Id = generateIdRenovation();
                renovationStorage.Save(renovation);
                moveInventoryForRenovation(renovation);
            } else
            {
                RenoviranjeOdbijeno odbijeno = new RenoviranjeOdbijeno();
                odbijeno.Show();
            }
        }

        public void moveInventoryForRenovation(RoomRenovation renovation)
        {
             foreach (RoomInventory roomInv in roominventoryStorage.GetAll())
             {
                 if (roomInv.IdRoom == renovation.Id)
                 {
                     foreach (Inventory inventory in inventoryStorage.GetAll())
                     {
                         if (roomInv.IdInventory == inventory.Id) {
                             if (inventory.Type == InventoryType.staticki)
                             {
                                staticInventoryStorage.Save(new StaticInventoryMovement(-1, renovation.Id, inventory.Id, roomInv.Quantity, renovation.DateBegin));
                                staticInventoryStorage.Save(new StaticInventoryMovement(renovation.Id, -1, inventory.Id, roomInv.Quantity, renovation.DateEnd));
                             }
                         }
                     }
                 }
             } 
        }

        public List<Room> getNewRooms()
        {
            List<Room> rooms = new List<Room>();
            foreach (Room room in roomStorage.GetAll())
            {
                if (room.Occupancy == true)
                {
                    rooms.Add(room);
                }
            }
            return rooms;
        }

        internal void mergeRooms(RoomMerge roomMerge)
        {
            throw new NotImplementedException();
        }

        internal int generateIdMerge()
        {
            throw new NotImplementedException();
        }

        public Boolean isRoomAvailableInventoryMovement(StaticInventoryMovement movement)
        {
            foreach (Checkup checkup in checkupStorage.GetAll())
            {
                if (checkup.IdRoom == movement.RoomInId)
                {
                    if (checkup.Date == movement.Date)
                    {
                        return false;
                    }
                    if (checkup.Date.AddMinutes(checkup.Duration) == movement.Date)
                    {
                        return false;
                    }
                    if ( movement.Date > checkup.Date && movement.Date < checkup.Date.AddMinutes(checkup.Duration))
                    {
                        return false;
                    }
                }
            }
            return true;
        }


        public Boolean isRoomAvailableRenovation(RoomRenovation renovation)
       {
            foreach (Checkup checkup in checkupStorage.GetAll())
            {
                 if (checkup.IdRoom == renovation.Id)
                 {
                     if (checkup.Date.Date == renovation.DateBegin.Date)
                     {
                        return false;
                     }
                     
                     if (checkup.Date.Date == renovation.DateEnd.Date) 
                     {
                        return false;
                     }

                     if (checkup.Date.Date < renovation.DateEnd.Date && checkup.Date.Date > renovation.DateBegin.Date)
                     {
                        return false;
                     }
                 }
            }
            return true;
        }

        public Boolean isRoomTakenByRenovation(Checkup checkup)
        {
            foreach (RoomRenovation renovation in renovationStorage.GetAll())
            {
                if (renovation.Id == checkup.IdRoom)
                {
                    if (checkup.Date == renovation.DateBegin)
                    {
                        return true;
                    }

                    if (checkup.Date == renovation.DateEnd)
                    {
                        return true;
                    }

                    if (checkup.Date < renovation.DateEnd && checkup.Date > renovation.DateBegin)
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        public List<Room> availableRooms(DateTime dateTime)
        {
            List<Room> availableRooms = new List<Room>();

            foreach(Room room in roomStorage.GetAll())
            {
                foreach(Checkup checkup in checkupStorage.GetAll())
                {
                    if(room.Id == checkup.IdRoom) 
                    {
                       if(checkup.Date!=dateTime.Date)
                       {
                            availableRooms.Add(room);
                       }
                       else
                       {
                            break;
                       }
                    }
                }
            }
            return availableRooms;
        }

        public List<Room> getAll()
        {
            return roomStorage.GetAll();
        }

        public void save(Room newRoom)
        {
            roomStorage.Save(newRoom);
        }
        public void deleteById(int id)
        {
            this.deleteRoomInventory(id);
            roomStorage.DeleteById(id);
        }

        private void deleteRoomInventory(int id)
        {
            foreach (RoomInventory inventory in roominventoryStorage.GetAll())
            {
                if (inventory.IdRoom == id)
                {
                    roominventoryStorage.DeleteByIdRoom(id);
                }
            }
        }

        public int generateId()
        {
            int ret = 0;
            foreach (Room roomBig in roomStorage.GetAll())
            {
                foreach (Room room in roomStorage.GetAll())
                {
                    if (ret == room.Id)
                    {
                        ++ret;
                        break;
                    }
                }
            }
            return ret;
        }

        public int generateIdRenovation()
        {
            int ret = 0;
            foreach (RoomRenovation roomBig in renovationStorage.GetAll())
            {
                foreach (RoomRenovation room in renovationStorage.GetAll())
                {
                    if (ret == room.Id)
                    {
                        ++ret;
                        break;
                    }
                }
            }
            return ret;
        }

        public void update(Room updatedRoom)
        {
            List<Room> rooms = roomStorage.GetAll();
            foreach (Room room in rooms)
            {
                if (room.Id == updatedRoom.Id)
                {
                    room.Floor = updatedRoom.Floor;
                    room.Capacity = updatedRoom.Capacity;
                    room.Occupancy = updatedRoom.Occupancy;
                    room.Purpose = updatedRoom.Purpose;
                    break;
                }
            }
            roomStorage.SaveAll(rooms);
        }

        public List<Room> roomByFloor(string floor)
        {
            return roomStorage.roomByFloor(floor);
        }
        public List<Room> roomsByType(String type)
        {
            return roomStorage.roomsByType(type);
        }

        public List<Room> roomByInventory(int idInventory, int quantity){
            List<Room> filtratedRooms = new List<Room>();
            foreach (Room room in roomStorage.GetAll())
            {
                foreach (RoomInventory ri in roominventoryStorage.GetAll())
                {
                    if (room.Id == ri.IdRoom && ri.IdInventory == idInventory && ri.Quantity == quantity)
                    {
                        filtratedRooms.Add(room);
                    }
                }
            }
            return filtratedRooms;
        }
    }
}
