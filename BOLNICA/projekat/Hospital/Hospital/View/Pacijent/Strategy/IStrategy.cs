using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hospital.Controller;
using Hospital.DTO;
using Hospital.Model;

namespace Hospital.View.Pacijent.Strategy
{
    interface IStrategy
    {
        CheckupController checkupController { get; }
        PatientController patientController { get; }

        List<CheckupDTO> availableTimes(object firstObject, object scondObject);

    }
}
