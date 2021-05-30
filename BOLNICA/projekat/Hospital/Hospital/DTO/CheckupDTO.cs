using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.DTO
{
    public class CheckupDTO : INotifyPropertyChanged
    {
        private int idCh;
        private DateTime date;
        private double duration;
        private Patient patient;
        private int idPatient;
        private Doctor doctor;
        private int idDoctor;
        private Room room;
        private int idRoom;
        private CheckupType type;

        public CheckupDTO() { }
        public CheckupDTO(int idCh, int idD, int idP, DateTime dateAndTime, int idR, CheckupType type) 
        {
            this.idCh = idCh;
            this.idDoctor = idD;
            this.idPatient = idP;
            this.Date = dateAndTime;
            this.IdRoom = idR;
            this.Type = type;//bice default pregled postvljeno pri kreiranju
            this.Duration = 30; //fiksno za pregled!
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string name)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(name));
            }
        }

        [JsonIgnore]
        public Room Room
        {
            get
            {
                return room;
            }
            set
            {
                if (value != room)
                {
                    room = value;
                    OnPropertyChanged("Date");
                }
            }
        }

        public double Duration
        {
            get
            {
                return duration;
            }
            set
            {
                if (value != duration)
                {
                    duration = value;
                    OnPropertyChanged("Duration");
                }
            }
        }
        public int IdCh
        {
            get
            {
                return idCh;
            }
            set
            {
                if (value != idCh)
                {
                    idCh = value;
                    OnPropertyChanged("IdCh");
                }
            }
        }


        [JsonIgnore]
        public Patient Patient
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

        [JsonIgnore]
        public Doctor Doctor
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


        public int IdRoom
        {
            get
            {
                return idRoom;
            }
            set
            {
                if (value != idRoom)
                {
                    idRoom = value;
                    OnPropertyChanged("Date");
                }
            }
        }
        public DateTime Date
        {
            get
            {
                return date;
            }
            set
            {
                if (value != date)
                {
                    date = value;
                    OnPropertyChanged("Date");
                }
            }
        }


        public CheckupType Type
        {
            get
            {
                return type;
            }
            set
            {
                if (value != type)
                {
                    type = value;
                    OnPropertyChanged("Type");
                }
            }
        }


        public int IdDoctor
        {
            get
            {
                return idDoctor;
            }
            set
            {
                if (value != idDoctor)
                {
                    idDoctor = value;
                    OnPropertyChanged("IdDoctor");
                }
            }
        }
        public int IdPatient
        {
            get
            {
                return idPatient;
            }
            set
            {
                if (value != idPatient)
                {
                    idPatient = value;
                    OnPropertyChanged("IdPatient");
                }
            }
        }
    }
}
