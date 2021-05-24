using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.Model
{
    public class Instruction
    {
        public int idInstruction { get; set; }
        public int idCheckup { get; set; }
        public String instructionType { get; set; }
        public Boolean given { get; set; }
        public String jmbg { get; set; }
        public String lbo { get; set; }
        public String interval { get; set; }
        public String commentInstruction { get; set; }

        public Instruction(int instructionId, int checkupId, String typeOfInstruction, Boolean givenInstruction, String jmbgPatient, String lboPatient,
            String intervalInstruction, String comment)
        {
            idInstruction = instructionId;
            idCheckup = checkupId;
            instructionType = typeOfInstruction;
            given = givenInstruction;
            jmbg = jmbgPatient;
            lbo = lboPatient;
            interval = intervalInstruction;
            commentInstruction = comment;
        }


    }
}
