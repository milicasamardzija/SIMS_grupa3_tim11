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
    public class RoomRenovationService
    {
        private RenovationIFileStorage renovationStorage;
        private IRoomMergeFileStorage mergeStorage;
        private IRoomSeparateFileStorage separateStorage;
        private IRoomInventoryFileStorage roominventoryStorage;
        private StaticInventoryMovemenetService movementService;
        private ICheckupFileStorage checkupStorage;
        private InventoryIFileStorage inventoryStorage;
        private StaticInvnetoryMovementFileStorage staticInventoryStorage;
        private RoomIFileStorage roomStorage;
        public RoomRenovationService()
        {
            renovationStorage = new RenovationFileStorage("./../../../../Hospital/files/storageRenovationRooms.json");
            mergeStorage = new RoomMergeFileStorage("./../../../../Hospital/files/storageMerge.json");
            separateStorage = new RoomSeparateFileStorage("./../../../../Hospital/files/storageSeparate.json");
            movementService = new StaticInventoryMovemenetService();
            roominventoryStorage = new RoomInventoryFileStorage("./../../../../Hospital/files/storageRoomInventory.json");
            inventoryStorage = new InventoryFileStorage("./../../../../Hospital/files/storageInventory.json");
            staticInventoryStorage = new StaticInvnetoryMovementFileStorage();
            checkupStorage = new CheckupFileStorage("./../../../../Hospital/files/storageCheckup.json");
        }
        public void deleteRenovation(RoomRenovation renovation)
        {
            foreach (StaticInventoryMovement inventory in movementService.getAll())
            {
                if (inventory.RoomInId == renovation.Id && inventory.RoomOutId == -1 && inventory.Date == renovation.DateEnd)
                {
                    movementService.DeleteByRoomsAndDate(renovation.Id, -1, renovation.DateEnd);
                }
            }
            foreach (StaticInventoryMovement inventory in movementService.getAll())
            {
                if (inventory.RoomInId == -1 && inventory.RoomOutId == renovation.Id && inventory.Date == renovation.DateBegin)
                {
                    movementService.DeleteByRoomsAndDate(-1, renovation.Id, renovation.DateBegin);
                }
            }
            renovationStorage.DeleteById(renovation.Id);
        }

        public List<RoomMerge> getAllMergeRenovations()
        {
            return mergeStorage.GetAll();
        }

        public List<RoomSeparate> getAllSeparateRenovations()
        {
            return separateStorage.GetAll();
        }

        public void separateRoomsSchedule(RoomSeparate renovation)
        {
            if (isRoomAvailableRenovation(renovation))
            {
                separateStorage.Save(renovation);
                moveInventoryForRenovation(renovation);
            }
            else
            {
                 RenoviranjeOdbijeno odbijeno = new RenoviranjeOdbijeno();
                 odbijeno.Show();
            }
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

        public void mergeRoomsSchedule(RoomMerge renovation)
        {
            if (isRoomAvailableRenovation(renovation))
            {
                mergeStorage.Save(renovation);
                moveInventoryForRenovation(renovation);
            }
            else
            {
                 RenoviranjeOdbijeno odbijeno = new RenoviranjeOdbijeno();
                 odbijeno.Show();
            }
        }

        public void mergeRooms(int idRoomFirst, int idRoomSecond)
        {
            roomStorage.Save(roomStorage.FindById(idRoomFirst));
            roomStorage.DeleteById(idRoomFirst);
            roomStorage.DeleteById(idRoomSecond);
        }

        public void separateRooms(int idRoom)
        {
            roomStorage.Save(roomStorage.FindById(idRoom)); //treba i namena i da se napravi nova prostorija
        }

        public List<RoomRenovation> getAll()
        {
            return renovationStorage.GetAll();
        }
    }
}
