using Hospital.FileStorage.Interfaces;
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
        private IAnamnesisFileStorage storage;
        
        public AnamnesisService()
        {
            storage = new AnamnesisFileStorage("./../../../../Hospital/files/anamnesis.json");
        }

        public List<Anamnesis> getAll()
        {
            return storage.GetAll();
        }
    }
}
