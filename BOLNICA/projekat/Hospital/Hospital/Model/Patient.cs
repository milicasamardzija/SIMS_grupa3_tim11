// File:    Patient.cs
// Author:  Nevena
// Created: Monday, March 22, 2021 3:21:08 PM
// Purpose: Definition of Class Patient

using System;

public class Patient : RegisterUser
{
   public int patientId { get; set; }
    public HealthCareCategory healthCareCategory { get; set; }
   public int idHealthCard { get; set; }
    // public Boolean guest = false;

    public Patient(String name1, String surname1, String jmbg1, String bdate1, String adress1, String telephoneNumber1,  int pId1, HealthCareCategory hcc,int iHc) {
        name = name1;
        surname = surname1;
        adress = adress1;
        telephoneNumber = telephoneNumber1;
        jmbg = jmbg1;
        birthdate = bdate1;
        patientId = pId1;
        healthCareCategory = hcc;
        idHealthCard = iHc;
    }
  
}