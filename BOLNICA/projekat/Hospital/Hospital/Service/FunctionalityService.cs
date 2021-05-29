using Hospital.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.Service
{

 
    class FunctionalityService
    {
        private FunctionalityFileStorage functionalitystorage;

        public FunctionalityService()
        {

          functionalitystorage = new FunctionalityFileStorage("./../../../../Hospital/files/count.json");
        }
        public void save(Functionality functionality)
        {
            functionalitystorage.Save(functionality);
        }
    }
}
