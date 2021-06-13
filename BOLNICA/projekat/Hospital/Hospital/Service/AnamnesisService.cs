using Hospital.FileStorage.Interfaces;
using Hospital.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hospital.FileStorage;

namespace Hospital.Service
{
    public class AnamnesisService
    {
        private IAnamnesisFileStorage storageAnamnesis;
        
        public AnamnesisService()
        {
            storageAnamnesis = new AnamnesisFileStorage("./../../../../Hospital/files/anamnesis.json");
        }

        public List<Anamnesis> getAll()
        {
            return storageAnamnesis.GetAll();
        }

        public void deleteById(int id)
        {
           
            storageAnamnesis.DeleteById(id);
        }

        public List<Note> NotesForAnamnesis(Anamnesis anamnesis)
        {
            List<Note> notes = new List<Note>();
            foreach (Anamnesis a in storageAnamnesis.GetAll())
            {
                if (a.DatePlace.Equals(anamnesis.DatePlace))
                {
                    foreach (Note n in a.NotesForAnamnesis1)
                    {
                        notes.Add(n);
                    }
                }
            }
            return notes;
        }

        public List<Anamnesis> getbyId(int id)
        {
            List<Anamnesis> anamneses = storageAnamnesis.GetAll();
            List<Anamnesis> patientanamnesis = new List<Anamnesis>();
            foreach (Anamnesis anamnese in anamneses)
            {

                if (anamnese.IdPatient == id)
                {

                    patientanamnesis.Add(anamnese);
                }
            }
            return patientanamnesis;
        }



        public void save(Anamnesis anamnesis)
        {
            storageAnamnesis.Save(anamnesis);
        }
    }
}
