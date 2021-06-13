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

       

        public List<AnamnesisDTO> getAll()
        {
            List<AnamnesisDTO> anamnesis = new List<AnamnesisDTO>();
            foreach (Anamnesis anamnesa in service.getAll())
            {
               
                    anamnesis.Add(new AnamnesisDTO(anamnesa.Id, anamnesa.DatePlace, anamnesa.NotesForAnamnesis1, anamnesa.NameS,anamnesa.Gender,anamnesa.IdPatient,anamnesa.Adress,anamnesa.Status,anamnesa.Job,anamnesa.Summary));
                
            }
            return anamnesis;
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

