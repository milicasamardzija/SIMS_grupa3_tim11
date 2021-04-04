// File:    Appointment.cs
// Author:  Nevena
// Created: Monday, March 22, 2021 3:25:31 PM
// Purpose: Definition of Class Appointment

using System;

public class Appointment
{
   public DateTime date { get; set; }   
   public DateTime time { get; set; }
    public double duration { get; set; }
    public int idA { get; set; }

    public Patient patient { get; set; }
    public Doctor doctor { get; set; }

    public Appointment() { }

    public Appointment(int v, DateTime dateTime1, DateTime dateTime2, double v2, Doctor doctor, Patient patient)
    {
        this.idA = v;
        this.date = dateTime1;
        this.time = dateTime2;
        this.duration = v2;
        this.doctor = doctor;
        this.patient = patient;
    }
}