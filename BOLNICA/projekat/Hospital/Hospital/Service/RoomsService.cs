using Hospital.FileStorage.Interfaces;
using Hospital.Model;
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
        private CheckupFileStorage checkupStorage;
        private StaticInvnetoryMovementFileStorage inventoryMovementStorage;
        private RoomInventoryFileStorage roominventoryStorage;
        private InventoryFileStorage inventoryStorage;
        private StaticInvnetoryMovementFileStorage staticInventoryStorage;
      
        private RoomIFileStorage roomStorage;

        public RoomsService()
        {
            renovationStorage = new RenovationFileStorage("./../../../../Hospital/files/storageRenovationRooms.json");
            checkupStorage = new CheckupFileStorage("./../../../../Hospital/files/storageCheckup.json");
            inventoryMovementStorage = new StaticInvnetoryMovementFileStorage();
            roominventoryStorage = new RoomInventoryFileStorage();
            inventoryStorage = new InventoryFileStorage("./../../../../Hospital/files/storageInventory.json");
            staticInventoryStorage = new StaticInvnetoryMovementFileStorage();
          
            roomStorage = new RoomFileStorage("./../../../../Hospital/files/storageRooms.json");
        }

        public void zakaziRenoviranje(RoomRenovation renovation)
        {

            if (isRoomAvailableRenovation(renovation))
            {
                renovationStorage.Save(renovation);
                moveInventoryForRenovation(renovation);
            } else
            {
                RenoviranjeOdbijeno odbijeno = new RenoviranjeOdbijeno();
                odbijeno.Show();
            }
        }

        /* public Boolean hasNoRenovationScheduled(RoomRenovation renovation)
         {
             foreach (RoomRenovation renov in renovationStorage.GetAll())
             {
                 if (renovation.IdRoom == renov.IdRoom && renovation.DateBegin.Date == renov.DateBegin.Date)
                 {
                     return false;
                 }
                 if (renovation.IdRoom == renov.IdRoom && renovation.DateEnd.Date == renov.DateEnd.Date)
                 {
                     return false;
                 }
                 if (renovation.IdRoom == renov.IdRoom && renovation.DateBegin.Date < renov.DateEnd.Date &&)
                 {
                     return false;
                 }
             }
             return true;
         }*/

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
                       if(checkup.Date!=dateTime.Date) //ovo proverava i datum i vreme
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
    }
}
