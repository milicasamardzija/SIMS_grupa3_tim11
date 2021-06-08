using Hospital.FileStorage.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.Service
{
    public class AnamnesisService
    {
        public AnamnesisFileStorage storageAnamnesis;

        public AnamnesisService()
        {
            storageAnamnesis = new AnamnesisFileStorage("./../../../../Hospital/files/anamnesis.json");
        }
        
    }
}
