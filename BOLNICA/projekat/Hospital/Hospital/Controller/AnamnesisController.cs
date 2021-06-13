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
    public class AnamnesisController
    {
        private AnamnesisService service;

        public AnamnesisController()
        {
            service = new AnamnesisService();
        }

        public List<Note> NotesForAnamnesis(Anamnesis anamnesis)
        {
            return service.NotesForAnamnesis(anamnesis);
        }

       

        public List<Anamnesis> getAll()
        {
            return service.getAll();
        }

          
    public List<Anamnesis> getbyId(int id)
        {
            return service.getbyId(id);
        }
        public void deleteById(int id)
        {
            service.deleteById(id);
        }

          public void save(Anamnesis anamnesis)
          {
              service.save(new Anamnesis(anamnesis.Id,anamnesis.DatePlace, anamnesis.NotesForAnamnesis1,anamnesis.NameS,anamnesis.Gender, anamnesis.IdPatient,anamnesis.Adress,anamnesis.Status,anamnesis.Job,anamnesis.Summary));
          }
        
    }

}

