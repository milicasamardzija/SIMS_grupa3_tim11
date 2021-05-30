using Hospital.FileStorage.Interfaces;
using Hospital.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Hospital.Service
{
    public class InstructionService
    {
        public CheckupFileStorage checkupStoorage;
        IInstructionFileStorage storageInstruction = new InstructionFileStorage("./../../../../Hospital/files/instructions.json");
        List<Instruction> instructionList = new List<Instruction>();

        public InstructionService()
        {
            checkupStoorage = new CheckupFileStorage("./../../../../Hospital/files/storageCheckup.json");
        }

        public int generateInstructionId()
        {
            int retInstructionId = 0;
            IInstructionFileStorage storageInstruction = new InstructionFileStorage("./../../../../Hospital/files/instructions.json");
            List<Instruction> allInstructions = storageInstruction.GetAll();
            foreach (Instruction instruction in allInstructions)
            {
                foreach (Instruction instructions in allInstructions)
                {
                    if (retInstructionId == instructions.Id)
                    {
                        ++retInstructionId;
                        break;
                    }
                }
            }
            return retInstructionId;
        }

        public int generateIdCheckup()
        {
            int returnCheckupId = 0;
            ICheckFileStorage storageCheckup = new CheckupFileStorage("./../../../../Hospital/files/storageCheckup.json");
            List<Checkup> allCheckups = storageCheckup.GetAll();
            foreach (Checkup checkups in allCheckups)
            {
                foreach (Checkup checkup in allCheckups)
                {
                    if (returnCheckupId == checkup.Id)
                    {
                        ++returnCheckupId;
                        break;
                    }
                }
            }
            return returnCheckupId;
        }

        private void DatePicker_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            DateTime newdate = (DateTime)(((DatePicker)sender).SelectedDate);
        }

        public void newCheckup(Checkup checkup)
        {
            Checkup newCheckups = new Checkup(generateIdCheckup(), checkup.IdDoctor, checkup.IdPatient, checkup.Date, 0, CheckupType.pregled);
            checkupStoorage.Save(newCheckups);
        }

        public void createInstruction(Instruction instruction)
        {
            Instruction newInstruction = new Instruction(generateInstructionId(), generateIdCheckup(), "ambulantno-specijalisticki pregled", true,
                instruction.jmbg, instruction.lbo, instruction.interval, instruction.commentInstruction);

            storageInstruction.Save(newInstruction);
            instructionList.Add(newInstruction);
        }
    }
}
