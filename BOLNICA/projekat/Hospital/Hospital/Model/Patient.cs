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

    public Patient(String i, String p, String br, String jmbgG, Gender pol, String datR, int idP) 
    {
        this.name = i;
        this.surname = p;
        this.telephoneNumber = br;
        this.jmbg = jmbgG;
        this.gender = pol;
        this.birthdate = datR;
        this.patientId = idP;

        this.guest = true;

    }

    /* public Patient(string name, string surname, string telephoneNumber, string jmbg, Gender gender, string birthdate, short v1, HealthCareCategory healthCareCategory, int idHealthCard, string occupation, string insurence, string street, short v2, int city, int country)
     {
         this.name = name;
         this.surname = surname;
         this.telephoneNumber = telephoneNumber;
         this.jmbg = jmbg;
         this.gender = gender;
         this.birthdate = birthdate;
         V1 = v1;
         this.healthCareCategory = healthCareCategory;
         this.idHealthCard = idHealthCard;
         this.occupation = occupation;
         this.insurence = insurence;
         Street = street;
         V2 = v2;
         City = city;
         Country = country;
     } */
    // public MedicalRecord medicalRecord;

}