// File:    Checkup.cs
// Author:  Nevena
// Created: Monday, March 22, 2021 3:29:16 PM
// Purpose: Definition of Class Checkup

using System;

namespace Hospital.Model
{
    public class Checkup : Appointment
    {

        public Checkup(int ida,int ch, DateTime dateTime1, DateTime dateTime2, double v2, CheckupType selectedIndex, Patient patient, Doctor doctor)
        {
            this.idA = ida;
            this.dateTime = dateTime1;
       
            this.duration = v2;
            this.doctor = doctor;
            this.patient = patient;
            this.idCh = ch;
            this.type = selectedIndex;
        }

        public CheckupType type { get; set; }
        public int idCh { get; set; }

    }
}