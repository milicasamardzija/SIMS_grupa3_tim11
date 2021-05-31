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
    }
}
