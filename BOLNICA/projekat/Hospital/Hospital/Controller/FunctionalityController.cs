using Hospital.Model;
using Hospital.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.Controller
{
    class FunctionalityController
    {


        private FunctionalityService service = new FunctionalityService();

        public void save(FunctionalityDTO functionality)
        {
            service.save(new Functionality( functionality.datumIzvrsavanja, functionality.idPacijenta, functionality.vrstaFunkcionalnosti));
        }

       


        public List<FunctionalityDTO> getAll()
        {
            List<FunctionalityDTO> rooms = new List<FunctionalityDTO>();
            foreach (Functionality functionality in service.getAll())
            {
                rooms.Add(new FunctionalityDTO(functionality.Id, functionality.datumIzvrsavanja, functionality.idPacijenta, functionality.vrstaFunkcionalnosti));
            }
            return rooms;
        }
    }

}