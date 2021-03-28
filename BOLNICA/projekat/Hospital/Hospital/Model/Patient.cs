// File:    Patient.cs
// Author:  Nevena
// Created: Monday, March 22, 2021 3:21:08 PM
// Purpose: Definition of Class Patient

using System;

public class Patient : RegisterUser
{
   public int patientId;
   public HealthCareCategory healthCareCategory;
   public int idHealthCard;
   public Boolean guest = false;

}