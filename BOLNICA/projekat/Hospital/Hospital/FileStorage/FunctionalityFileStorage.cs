using Hospital.FileStorage;
using Hospital.FileStorage.Interfaces;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.Model
{
    // @"./../../../../Hospital/files/count.json"
    class FunctionalityFileStorage : GenericFileStorage<Functionality>, FunctionalityIFileStorage
    {
        public FunctionalityFileStorage(String filePath) : base(filePath) { }
    }
}