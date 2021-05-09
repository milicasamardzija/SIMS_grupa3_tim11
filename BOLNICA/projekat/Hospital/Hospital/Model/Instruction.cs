using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Hospital.Model
{
    public class Instruction : INotifyPropertyChanged
    {
        public int idInstruction;
        private String patient;
        public Doctor doctors;
        public List<Doctor> doctor;
        private String jmbg;
        private String lbo;
        private int number;
        private String interval;
        private String commentInstruction;

        public Instruction(int id, String patientInstructions, Doctor doctorInstructions, List<Doctor> doc,
            String jmbgInstructions, String lboInstructions, int numberInstructions, String intervalInstructions, String commentInstructions)
        {
            idInstruction = id;
            this.patient = patientInstructions;
            this.doctors = doctorInstructions;
            this.doctor = doc;
            this.jmbg = jmbgInstructions;
            this.lbo = lboInstructions;
            this.number = numberInstructions;
            this.interval = intervalInstructions;
            this.commentInstruction = commentInstructions;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string name)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(name));
            }
        }

        public int IdInstruction
        {
            get
            {
                return idInstruction;
            }
            set
            {
                if(value != idInstruction)
                {
                    idInstruction = value;
                    OnPropertyChanged("IdInstruction");
                }
            }
        }

        private String Patient
        {
            get
            {
                return patient;
            }
            set
            {
                if (value != patient)
                {
                    patient = value;
                    OnPropertyChanged("Patient");
                }
            }
        }
        [Json Ignore]
        public Doctor Doctors
        {
            get
            {
                return doctors;
            }
            set
            {
                if (value != doctors)
                {
                    doctors = value;
                    OnPropertyChanged("Doctors");
                }
            }
        }

        public List<Doctor> Doctor
        {
            get
            {
                return doctor;
            }
            set
            {
                if (value != doctor)
                {
                    doctor = value;
                    OnPropertyChanged("Doctor");
                }
            }
        }

        private String Jmbg
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

        private String Lbo
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

        private int Number
        {
            get
            {
                return number;
            }
            set
            {
                if (value != number)
                {
                    number = value;
                    OnPropertyChanged("Number");
                }
            }
        }

        private String Interval
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

        private String CommentInstruction
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
