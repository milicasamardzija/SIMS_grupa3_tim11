// File:    Patient.cs
// Author:  Nevena
// Created: Monday, March 22, 2021 3:21:08 PM
// Purpose: Definition of Class Patient

using System;

public class Patient : User
{
   public int patientId { get; set; }
   public HealthCareCategory healthCareCategory { get; set; }
    public int idHealthCard { get; set; }
    public String occupation { get; set; }
    public String insurence { get; set; }
    public Boolean guest = false;

   public Patient(String n, String s, String tel, String jmb, Gender g, String b, int pId, HealthCareCategory hcc, int idhc, String oc, String ins, Adress adr) 
    { 
        this.name=n;
        this.surname=s;
        this.telephoneNumber=tel;
        this.jmbg=jmb;
        this.gender=g;
        this.birthdate=b;
        this.patientId = pId;
        this.healthCareCategory = hcc;
        this.idHealthCard = idhc;
        this.occupation = oc;
        this.insurence = ins;
        this.adress = adr;

}

    public Patient()
    {
    }
    // public MedicalRecord medicalRecord;

}