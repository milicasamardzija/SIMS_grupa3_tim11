using Hospital.FileStorage;
using Hospital.FileStorage.Interfaces;
using Hospital.Model;
using Hospital.Model.Rooms;
using Hospital.View.Manager.Prostorije.RenoviranjeProstorije;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.Service
{
    public class RoomSeparateService
    {
        private IRoomSeparateFileStorage separateStorage;
        private IRoomInventoryFileStorage roominventoryStorage;
        private ICheckupFileStorage checkupStorage;
        private InventoryIFileStorage inventoryStorage;
        private StaticInvnetoryMovementFileStorage staticInventoryStorage;
        private RoomIFileStorage roomStorage;
        private RoomsService roomsService;
        public RoomSeparateService()
        {
            separateStorage = new RoomSeparateFileStorage("./../../../../Hospital/files/storageRoomSeparate.json");
            roominventoryStorage = new RoomInventoryFileStorage("./../../../../Hospital/files/storageRoomInventory.json");
            inventoryStorage = new InventoryFileStorage("./../../../../Hospital/files/storageInventory.json");
            staticInventoryStorage = new StaticInvnetoryMovementFileStorage();
            checkupStorage = new CheckupFileStorage("./../../../../Hospital/files/storageCheckup.json");
            roomsService = new RoomsService();
            roomStorage = new RoomFileStorage("./../../../../Hospital/files/storageRooms.json");
        }
        public List<RoomSeparate> getAllSeparateRenovations()
        {
            return separateStorage.GetAll();
        }
        public int generateIdSeparate()
        {
            int ret = 0;
            foreach (RoomSeparate roomBig in separateStorage.GetAll())
            {
                foreach (RoomSeparate room in separateStorage.GetAll())
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
        public void separateRoomsSchedule(RoomSeparate renovation)
        {
            if (isRoomAvailableRenovation(renovation))
            {
                String description = "Zakazano je razdvajanje sobe broj " + renovation.IdRoom + ".";
                renovation.Description = description;
                renovation.IdNewRoom = roomsService.generateId();
                roomStorage.Save(new Room(renovation.IdNewRoom, roomStorage.FindById(renovation.IdRoom).Floor, true, renovation.Purpose, 0));
                separateStorage.Save(renovation);
                moveInventoryForRenovation(renovation);
            }
            else
            {
                RenoviranjeOdbijeno odbijeno = new RenoviranjeOdbijeno();
                odbijeno.Show();
            }
        }
        private void moveInventoryForRenovation(RoomRenovation renovation)
        {
            foreach (RoomInventory roomInv in roominventoryStorage.GetAll())
            {
                if (roomInv.IdRoom == renovation.Id)
                {
                    foreach (Inventory inventory in inventoryStorage.GetAll())
                    {
                        if (roomInv.IdInventory == inventory.Id)
                        {
                            if (inventory.Type == InventoryType.staticki)
                            {
                                staticInventoryStorage.Save(new StaticInventoryMovement(-1, renovation.IdRoom, inventory.Id, roomInv.Quantity, renovation.DateBegin));
                                staticInventoryStorage.Save(new StaticInventoryMovement(renovation.IdRoom, -1, inventory.Id, roomInv.Quantity, renovation.DateEnd));
                            }
                        }
                    }
                }
            }
        }
        private Boolean isRoomAvailableRenovation(RoomSeparate renovation)
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
        public void separateRooms(RoomSeparate renovation)
        {
            Room room = roomStorage.FindById(renovation.IdNewRoom);
            room.Occupancy = false;
            roomsService.update(room);
        }
    }
}
