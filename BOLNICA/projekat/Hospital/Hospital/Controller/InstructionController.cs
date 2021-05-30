using Hospital.DTO;
using Hospital.Model;
using Hospital.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.Controller
{
    public class InstructionController
    {
        public InstructionService service = new InstructionService();

        public InstructionController()
        {
        }

        public void newCheckup(CheckupDTO checkup)
        {
            service.newCheckup(new Checkup(checkup.IdCh, checkup.IdDoctor, checkup.IdPatient, checkup.Date, checkup.IdRoom, checkup.Type));
        }
        
    }
}
