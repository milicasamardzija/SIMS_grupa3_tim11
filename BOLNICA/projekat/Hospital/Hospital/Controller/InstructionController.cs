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
        public InstructionService service;

        public InstructionController()
        {
            service = new InstructionService();
        }

        public void newCheckup(CheckupDTO checkup)
        {
            service.newCheckup(new Checkup(checkup.IdCh, checkup.IdDoctor, checkup.IdPatient, checkup.Date, checkup.IdRoom, checkup.Type));
        }

        public void createInstruction(Instruction instruction)
        {
            service.createInstruction(new Instruction(instruction.Id, instruction.IdCheckup, instruction.InstructionType, instruction.Given,
                instruction.Jmbg, instruction.Lbo, instruction.Interval, instruction.CommentInstruction));
        }
        
    }
}
