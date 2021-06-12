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
    public class RoomMergeService
    {
        private IRoomMergeFileStorage mergeStorage;
        private ICheckupFileStorage checkupStorage;
        private InventoryIFileStorage inventoryStorage;
        private StaticInvnetoryMovementFileStorage staticInventoryStorage;
        private RoomIFileStorage roomStorage;
        private IRoomInventoryFileStorage roominventoryStorage;
        private RoomsService roomService;
        public RoomMergeService()
        {
            mergeStorage = new RoomMergeFileStorage("./../../../../Hospital/files/storageRoomMerge.json");
            checkupStorage = new CheckupFileStorage("./../../../../Hospital/files/storageCheckup.json");
            roominventoryStorage = new RoomInventoryFileStorage("./../../../../Hospital/files/storageRoomInventory.json");
            inventoryStorage = new InventoryFileStorage("./../../../../Hospital/files/storageInventory.json");
            roomStorage = new RoomFileStorage("./../../../../Hospital/files/storageRooms.json");
            staticInventoryStorage = new StaticInvnetoryMovementFileStorage();
            roomService = new RoomsService();
        }

        public List<RoomMerge> getAllMergeRenovations()
        {
            return mergeStorage.GetAll();
        }

        public int generateIdMerge()
        {
            int ret = 0;
            foreach (RoomMerge roomBig in mergeStorage.GetAll())
            {
                foreach (RoomMerge room in mergeStorage.GetAll())
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
        public void mergeRoomsSchedule(RoomMerge renovation)
        {
            if (isRoomAvailableRenovation(renovation))
            {
                String description = "Zakazano je spajanje sobe broj " + renovation.IdRoom + " sa sobom broj " + renovation.IdRoomSecond + ".";
                renovation.Description = description;
                renovation.IdNewRoom = roomService.generateId();
                roomStorage.Save(new Room(renovation.IdNewRoom, roomStorage.FindById(renovation.IdRoom).Floor, true, renovation.Purpose, 0));
                mergeStorage.Save(renovation);
                moveInventoryForRenovationFromRoom(renovation);
            }
            else
            {
                RenoviranjeOdbijeno odbijeno = new RenoviranjeOdbijeno();
                odbijeno.Show();
            }
        }
        public void mergeRooms(RoomMerge renovation)
        {
            Room room = roomStorage.FindById(renovation.IdNewRoom);
            room.Occupancy = false;
            roomService.update(room);
            roomStorage.DeleteById(renovation.IdRoom);
            roomStorage.DeleteById(renovation.IdRoomSecond);
        }


        private void moveInventoryForRenovationFromRoom(RoomMerge renovation)
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
                                staticInventoryStorage.Save(new StaticInventoryMovement(-1, renovation.IdRoomSecond, inventory.Id, roomInv.Quantity, renovation.DateEnd));
                            }
                        }
                    }
                }
            }
        }
        private Boolean isRoomAvailableRenovation(RoomRenovation renovation)
        {
            foreach (Checkup checkup in checkupStorage.GetAll())
            {
                if (checkup.IdRoom == renovation.Id)
                {
                    if (checkup.Date.Date == renovation.DateBegin.Date)
                    {
                        return false;
                    }

                    if (checkup.Date.Date > renovation.DateBegin.Date)
                    {
                        return false;
                    }
                }
            }
            return true;
        }
    }
}
