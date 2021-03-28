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
  // public Room room { get; set; }
   
   public string doctor;

  

   /* public Doctor Doctor
   {
      get
      {
         return doctor;
      }
      set
      {
         this.doctor = value;
      }
   }
   */public string patient;

    public Appointment()
    {
    }


    /*
    public Patient Patient
   {
      get
      {
         return patient;
      }
      set
      {
         this.patient = value;
      }
   }*/
    public Appointment(DateTime date, DateTime time, double duration, string doctor, string patient)
    {
        this.date = date;
        this.time = time;
        this.duration = duration;
        this.doctor = doctor;
        this.patient = patient;
    }

    public Appointment(DateTime date, DateTime time, double duration, string doctor)
    {
        this.date = date;
        this.time = time;
        this.duration = duration;
        this.doctor = doctor;
    }
}