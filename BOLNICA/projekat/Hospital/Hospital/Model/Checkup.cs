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

        public Checkup(int ida, int ch, DateTime dateTime1, String ti, double v2, CheckupType selectedIndex, Patient patient, Doctor doctor)
        {
            this.idA = ida;
            this.date = dateTime1;
            this.time = ti;
            this.duration = v2;
            this.doctor = doctor;
            this.patient = patient;
            this.idCh = ch;
            this.type = selectedIndex;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string name)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(name));
            }
        }

        public CheckupType type;
        public int idCh;

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


    }
}