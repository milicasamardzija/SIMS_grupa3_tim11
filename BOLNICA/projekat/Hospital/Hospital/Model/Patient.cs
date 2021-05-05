// File:    Patient.cs
// Author:  Nevena
// Created: Monday, March 22, 2021 3:21:08 PM
// Purpose: Definition of Class Patient

using System;
using System.ComponentModel;

public class Patient : User
{

   private int patientId;
   private HealthCareCategory healthCareCategory;
   private int idHealthCard;
   private String occupation;
   private String insurence;
   public Boolean guest = false;

   


   public Patient(String n, String s, String tel, String jmb, Gender g, DateTime b, int pId, HealthCareCategory hcc, int idhc, String oc, String ins, Adress adr) 
    { 
        this.name=n;
        this.surname=s;
        this.TelephoneNumber=tel;
        this.Jmbg=jmb;
        this.Gender=g;
        this.BirthdayDate=b;
        this.PatientId = pId; //id pacijenta je meni isto sto i broj kartona 
        this.HealthCareCategory = hcc;
        this.IdHealthCard = idhc; //broj zdrav knjizice
        this.Occupation = oc;
        this.Insurence = ins;
        this.adress = adr;
        

    }

    public Patient()
    {
    }

    public Patient(String i, String p, String br, String jmbgG, Gender pol, DateTime datR, int idP) 
    {
        this.Name = i;
        this.Surname = p;
        this.TelephoneNumber = br;
        this.Jmbg = jmbgG;
        this.Gender = pol;
        this.BirthdayDate = datR;
        this.PatientId = idP;

        this.guest = true;

    }


    public int PatientId
    {
        get
        {
            return patientId;
        }
        set
        {
            if (value != patientId)
            {
                patientId = value;
                OnProperychanged("PatientId");
            }
        }
    }

    public int IdHealthCard
    {
        get
        {
            return idHealthCard;
        }
        set
        {
            if (value != idHealthCard)
            {
                idHealthCard = value;
                OnProperychanged("IdHealthCard");
            }
        }
    }

    public HealthCareCategory HealthCareCategory
    {
        get
        {
            return healthCareCategory;
        }
        set
        {
            if (value != healthCareCategory)
            {
                healthCareCategory = value;
                OnProperychanged("HealthCareCategory");
            }
        }
    }

    public String Occupation
    {
        get
        {
            return occupation;
        }
        set
        {
            if (value != occupation)
            {
                occupation = value;
                OnProperychanged("Occupation");
            }
        }
    }

    public String Insurence
    {
        get
        {
            return insurence;
        }
        set
        {
            if (value != insurence)
            {
                insurence = value;
                OnProperychanged("Insurence");
            }
        }
    }
}