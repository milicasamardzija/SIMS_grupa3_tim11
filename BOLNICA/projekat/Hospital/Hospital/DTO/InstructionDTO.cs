using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.DTO
{
    public class InstructionDTO : INotifyPropertyChanged
    {
        private int id;
        private int idCheckup { get; set; }
        private String instructionType { get; set; }
        private Boolean given { get; set; }
        private String jmbg { get; set; }
        private String lbo { get; set; }
        private String interval { get; set; }
        private String commentInstruction { get; set; }

        public InstructionDTO(int id, int checkupId, String typeOfInstruction, Boolean givenInstruction, String jmbgPatient, String lboPatient,
            String intervalInstruction, String comment) 
        {
            this.id = id;
            this.idCheckup = checkupId;
            this.instructionType = typeOfInstruction;
            this.given = givenInstruction;
            this.jmbg = jmbgPatient;
            this.lbo = lboPatient;
            this.interval = intervalInstruction;
            this.commentInstruction = comment;
        }

        public InstructionDTO()
        {
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
