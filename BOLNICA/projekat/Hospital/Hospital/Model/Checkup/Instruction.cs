using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.Model
{
    public class Instruction : Entity
    {
        private int idCheckup;
        private String instructionType;
        private Boolean given;
        private String jmbg;
        private String lbo;
        private String interval;
        private String commentInstruction; 

        public Instruction(int id, int checkupId, String typeOfInstruction, Boolean givenInstruction, String jmbgPatient, String lboPatient,
            String intervalInstruction, String comment) : base(id)
        {
            this.idCheckup = checkupId;
            this.instructionType = typeOfInstruction;
            this.given = givenInstruction;
            this.jmbg = jmbgPatient;
            this.lbo = lboPatient;
            this.interval = intervalInstruction;
            this.commentInstruction = comment;
        }

        public Instruction()
        {
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string name)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(name));
            }
        }

        public int IdCheckup
        {
            get
            {
                return idCheckup;
            }
            set
            {
                if(value != idCheckup)
                {
                    idCheckup = value;
                    OnPropertyChanged("IdCheckup");
                }
            }
        }
        public String InstructionType
        {
            get
            {
                return instructionType;
            }
            set
            {
                if (value != instructionType)
                {
                    instructionType = value;
                    OnPropertyChanged("InstructionType");
                }
            }
        }
        public Boolean Given
        {
            get
            {
                return given;
            }
            set
            {
                if (value != given)
                {
                    given = value;
                    OnPropertyChanged("Given");
                }
            }
        }
        public String Jmbg
        {
            get
            {
                return jmbg;
            }
            set
            {
                if (value != jmbg)
                {
                    jmbg = value;
                    OnPropertyChanged("Jmbg");
                }
            }
        }
        public String Lbo
        {
            get
            {
                return lbo;
            }
            set
            {
                if (value != lbo)
                {
                    lbo = value;
                    OnPropertyChanged("Lbo");
                }
            }
        }
        public String Interval
        {
            get
            {
                return interval;
            }
            set
            {
                if (value != interval)
                {
                    interval = value;
                    OnPropertyChanged("Interval");
                }
            }
        }
        public String CommentInstruction
        {
            get
            {
                return commentInstruction;
            }
            set
            {
                if (value != commentInstruction)
                {
                    commentInstruction = value;
                    OnPropertyChanged("CommentInstruction");
                }
            }
        }

    }
}
