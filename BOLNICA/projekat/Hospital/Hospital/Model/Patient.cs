// File:    Patient.cs
// Author:  Nevena
// Created: Monday, March 22, 2021 3:21:08 PM
// Purpose: Definition of Class Patient

using System;

public class Patient : User
{
   public int patientId;
   public HealthCareCategory healthCareCategory;
   public int idHealthCard;
   public String occupation;
   public String insurence;
   public Boolean guest = false;
   
  // public MedicalRecord medicalRecord;

}