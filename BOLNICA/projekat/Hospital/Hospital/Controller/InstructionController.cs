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

        public void newCheckup(Checkup checkup)
        {
            service.newCheckup(checkup);
        }

        public void createInstruction(Instruction instruction)
        {
            service.createInstruction(instruction);
        }

    }
}
