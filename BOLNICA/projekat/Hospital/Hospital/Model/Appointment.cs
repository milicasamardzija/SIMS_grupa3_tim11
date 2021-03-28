// File:    Appointment.cs
// Author:  Nevena
// Created: Monday, March 22, 2021 3:25:31 PM
// Purpose: Definition of Class Appointment

using System;

public class Appointment
{

    //public DateTime date;
    //public DateTime time;
  // public string date { get; set; }
  // public string time { get; set; }
 //  public double duration { get; set; }
  // public Room room;
   
  
   
   /// <summary>
   /// Property for Doctor
   /// </summary>
   /// <pdGenerated>Default opposite class property</pdGenerated>
  

   public int idA { get; set; }
   public string date { get; set; }
   public string time { get; set; }
   public double duration { get; set; }
  // public Room room { get; set; }
   
   public string doctor { get; set; }

  

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

   }*/
  // public Patient patient;
   
   /// <summary>
   /// Property for Patient
   /// </summary>
   /// <pdGenerated>Default opposite class property</pdGenerated>
   /*public Patient Patient

   }
   */ public string patient { get; set; }

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


    public Appointment(int idA,string date, string time, double duration, string doctor, string patient)
    {
        this.idA = idA;
        this.date = date;
        this.time = time;
        this.duration = duration;
        this.doctor = doctor;
        this.patient = patient;
    }


    public Appointment(int idA, string date, string time, double duration, string doctor)
    {
        this.idA = idA;
        this.date = date;
        this.time = time;
        this.duration = duration;
        this.doctor = doctor;
    }
}