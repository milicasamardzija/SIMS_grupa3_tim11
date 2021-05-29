using Hospital.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.Controller
{
    class PatientController1
    {
        PatientService1 patientService = new PatientService1();

        public List<Patient> getAll()
        {
            List<Patient> patients = new List<Patient>();
            foreach (Patient patient in patientService.getAll())
            {
                patients.Add(new Patient(patient.name, patient.surname, patient.telephoneNumber, patient.jmbg,patient.gender,patient.birthdayDate,patient.Id,patient.HealthCareCategory,patient.IdHealthCard,patient.Occupation,patient.Insurence,patient.adress));
            }
            return patients;
        }

    }
}

