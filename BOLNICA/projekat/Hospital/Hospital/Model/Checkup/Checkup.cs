// File:    Checkup.cs
// Author:  Nevena
// Created: Monday, March 22, 2021 3:29:16 PM
// Purpose: Definition of Class Checkup

using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace Hospital.Model
{
    public class Checkup : Entity
    {

       
        private DateTime date;
      
        private double duration;

        private Patient patient;
        private int idPatient;
        private Doctor doctor;
        private int idDoctor;
        private Room room;
        private int idRoom;

       
        private CheckupType type;
       
       

        public Checkup() { }
        public Checkup(int idCh, int idD, int idP, DateTime dateAndTime, int idR, CheckupType type) : base(idCh)
        {
           
            this.idDoctor = idD;
            this.idPatient = idP;
            this.Date = dateAndTime;
            this.IdRoom = idR;
            this.Type=type ;//bice default pregled postvljeno pri kreiranju
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
                if(value != type)
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