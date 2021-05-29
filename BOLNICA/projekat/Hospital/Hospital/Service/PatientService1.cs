using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.Service
{
    class PatientService1
    {
        private PatientFileStorage patientFileStorage;

        public PatientService1()
        {

            patientFileStorage = new PatientFileStorage("./../../../../Hospital/files/storagePatient.json");
        }
        public void save(Patient patient)
        {
            patientFileStorage.Save(patient);
        }

        public List<Patient> getAll()
        {
            return patientFileStorage.GetAll();
        }
    }
}

