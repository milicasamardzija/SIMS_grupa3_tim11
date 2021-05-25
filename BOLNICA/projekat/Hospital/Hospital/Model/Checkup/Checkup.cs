// File:    Checkup.cs
// Author:  Nevena
// Created: Monday, March 22, 2021 3:29:16 PM
// Purpose: Definition of Class Checkup

using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace Hospital.Model
{
    public class Checkup : Appointment
    {

        

        private CheckupType type;
        private int idCh;
        private int idDoctor;
        private int idPatient;

        public Checkup() { }
        public Checkup(int idCh, int idD, int idP, DateTime dateAndTime, int idR, CheckupType type)
        {
            this.idCh = idCh;
            this.idDoctor = idD;
            this.idPatient = idP;
            this.Date = dateAndTime;
            this.IdRoom = idR;
            this.Type=type ;//bice default pregled postvljeno pri kreiranju
            this.Duration = 30; //fiksno za pregled!

        }

        public Checkup(int ida,int ch, DateTime dateTime1, String ti, double v2, CheckupType selectedIndex, Patient patient, Doctor doctor) 
        {
          
            this.Date = dateTime1;
            this.Time = ti;
            this.Duration = v2;
            this.Doctor = doctor;
            this.Patient = patient;
            this.IdCh = ch;
            this.Type = selectedIndex;

            this.IdDoctor = doctor.Id;
            this.IdPatient = patient.Id;    


        }

        public Checkup(int ida, int ch, DateTime dateTime1, String ti, double v2, CheckupType selectedIndex, Patient patient, Doctor doctor, int roomId)  
        {
            
            this.Date = dateTime1;
            this.Time = ti;
            this.Duration = v2;
            this.Doctor = doctor;
            this.Patient = patient;
            this.idCh = ch;
            this.type = selectedIndex;
            this.IdRoom = roomId;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string name)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(name));
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