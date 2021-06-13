using Hospital.Model;
using Hospital.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.Controller
{
    public class AnamnesisController
    {
        private AnamnesisService service = new AnamnesisService();

        public AnamnesisController()
        {
           
          
        }

        public List<Note> NotesForAnamnesis(Anamnesis anamnesis)
        {
            return service.NotesForAnamnesis(anamnesis);
        }

        public List<Anamnesis> getAll()
        {
            return service.getAll();
        }


    }

}
