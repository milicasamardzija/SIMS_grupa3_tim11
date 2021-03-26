// File:    Appointment.cs
// Author:  Nevena
// Created: Monday, March 22, 2021 3:25:31 PM
// Purpose: Definition of Class Appointment

using System;

public class Appointment
{
   public DateTime date;
   public DateTime time;
   public float duration;
   public Room room;
   
   public Doctor doctor;
   
   /// <summary>
   /// Property for Doctor
   /// </summary>
   /// <pdGenerated>Default opposite class property</pdGenerated>
   public Doctor Doctor
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
   public Patient patient;
   
   /// <summary>
   /// Property for Patient
   /// </summary>
   /// <pdGenerated>Default opposite class property</pdGenerated>
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
   }

}