using Hospital.Model;
using Hospital.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.Controller
{
    public class StaticInventoryMovementController
    {
        private StaticInventoryMovemenetService service;
        public StaticInventoryMovementController()
        {
            service = new StaticInventoryMovemenetService();
        }
        public void saveNewMovement(StaticInventoryMovement movement)
        {
            service.saveNewMovement(movement);
        }
        public void DeleteByRoomsAndDate(int idRoomIn, int idRoomOut, DateTime date)
        {
            service.DeleteByRoomsAndDate(idRoomIn,idRoomOut,date);
        }
        public void saveAll(List<StaticInventoryMovement> inventories)
        {
            service.saveAll(inventories);
        }
        public List<StaticInventoryMovement> getAll()
        {
            return service.getAll();
        }

        internal void moveInventoryStatic(StaticInventoryMovement movement)
        {
            service.moveInventoryStatic(movement);
        }
    }
}
