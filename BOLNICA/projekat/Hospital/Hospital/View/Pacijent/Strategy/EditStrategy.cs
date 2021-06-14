using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hospital.Controller;
using Hospital.DTO;

namespace Hospital.View.Pacijent.Strategy
{
    class EditStrategy : IStrategy
    {
        public CheckupController checkupController => new CheckupController();

        public PatientController patientController => new PatientController();

        public List<CheckupDTO> availableTimes(object firstObject, object scondObject)
        {
            Doctor doctor = (Doctor)scondObject;
            DateTime date = (DateTime)firstObject;
            List<CheckupDTO> checkups = new List<CheckupDTO>();

            foreach (PatientDTO patient in patientController.getAll())
            {
                foreach (CheckupDTO checkup in checkupController.getAll())
                {
                    if (doctor.Id == checkup.IdDoctor)
                    {
                        if (checkup.Date.Date.Equals(date))
                        {
                            checkups.Add(checkup);
                        }
                    }

                    if (patient.Id == checkup.Patient.Id)
                    {
                        if (checkup.Date.Date.Equals(date))
                        {
                            checkups.Add(checkup);
                        }
                    }
                }

            }
            return checkups;
        }
    }



}