using Hospital.FileStorage;
using Hospital.FileStorage.Interfaces;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


    public class AlergensFileStorage : GenericFileStorage<Alergens>, IAlergensFileStorage
    {
    public AlergensFileStorage(String filePath) : base(filePath) { }
   
}

