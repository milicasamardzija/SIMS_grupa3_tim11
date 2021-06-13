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
        private AnamnesisService service;

        public AnamnesisController()
        {

        }

        public List<Note> NotesForAnamnesis(Anamnesis anamnesis)
        {
            return service.NotesForAnamnesis(anamnesis);
        }

        public List<Anamnesis> getAll()
        {
            List<Anamnesis> allAnamnesis = new List<Anamnesis>(service.getAll());
            List<Anamnesis> anamnesis = new List<Anamnesis>();
            foreach(Anamnesis a in allAnamnesis)
            {
                Anamnesis newAnamnesis = new Anamnesis(a.Id, a.NameS, a.Gender, a.DatePlace, a.IdPatient, a.Adress,
                    a.Status, a.Job, a.Summary);
            }
            return anamnesis;
        }
    }

}
