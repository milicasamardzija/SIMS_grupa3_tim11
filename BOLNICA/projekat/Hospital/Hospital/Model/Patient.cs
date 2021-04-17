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

   public Patient(String n, String s, String tel, String jmb, Gender g, DateTime b, int pId, HealthCareCategory hcc, int idhc, String oc, String ins, Adress adr) 
    { 
        this.name=n;
        this.surname=s;
        this.telephoneNumber=tel;
        this.jmbg=jmb;
        this.gender=g;
        this.birthdayDate=b;
        this.patientId = pId; //id pacijenta je meni isto sto i broj kartona 
        this.healthCareCategory = hcc;
        this.idHealthCard = idhc; //broj zdrav knjizice
        this.occupation = oc;
        this.insurence = ins;
        this.adress = adr;
        

}

    public Patient()
    {
    }

    public Patient(String i, String p, String br, String jmbgG, Gender pol, DateTime datR, int idP) 
    {
        this.name = i;
        this.surname = p;
        this.telephoneNumber = br;
        this.jmbg = jmbgG;
        this.gender = pol;
        this.birthdayDate = datR;
        this.patientId = idP;

        this.guest = true;

    }

    

}