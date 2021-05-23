using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

using System.IO;
using Hospital.FileStorage;
using Hospital.FileStorage.Interfaces;

namespace Hospital.Model
{

    // (@"./../../../../Hospital/files/ankete.json"
    class SurveyFileStorage : GenericFileStorage<Survey>, SurveyIFileStorage

    {
        public SurveyFileStorage(String filePath) : base(filePath) { }
    }
}
