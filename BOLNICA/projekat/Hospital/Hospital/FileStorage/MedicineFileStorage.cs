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
    public class MedicineFileStorage : GenericFileStorage<Medicine>, MedicineIFileStorage
    {
        public MedicineFileStorage(String filePath) : base(filePath) { }
    }
}
