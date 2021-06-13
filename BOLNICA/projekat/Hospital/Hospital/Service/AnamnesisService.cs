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

    
    }
}
