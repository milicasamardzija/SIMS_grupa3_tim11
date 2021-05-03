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
    }
}
