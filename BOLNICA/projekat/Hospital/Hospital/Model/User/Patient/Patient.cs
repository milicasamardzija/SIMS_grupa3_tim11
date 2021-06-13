// File:    Patient.cs
// Author:  Nevena
// Created: Monday, March 22, 2021 3:21:08 PM
// Purpose: Definition of Class Patient

using System;
using System.ComponentModel;

public class Patient : User
{

  // private int patientId;
   private HealthCareCategory healthCareCategory;
   private int idHealthCard;
   private String occupation;
   private String insurence;
   public Boolean guest = false;

    public Boolean banovan = false;
    public DateTime datumBanovanja;



    public Patient(String n, String s, String tel, String jmb, Gender g, DateTime b, int pId, HealthCareCategory hcc, int idhc, String oc, String ins, Adress adr) : base()
    { 
        this.Name=n;
        this.Surname=s;
        this.TelephoneNumber=tel;
        this.Jmbg=jmb;
        this.Gender=g;
        this.BirthdayDate=b;
        //  this.patientId = pId; //id pacijenta je meni isto sto i broj kartona 
        this.Id = pId;
        this.healthCareCategory = hcc;
        this.idHealthCard = idhc; //broj zdrav knjizice
        this.occupation = oc;
        this.insurence = ins;
        this.Adress = adr;
        this.guest = false;
       

    }

    public Patient()
    {
    }

    public Patient(String i, String p, String br, String jmbgG, Gender pol, DateTime datR, int id) 
    {
        this.Name = i;
        this.Surname = p;
        this.TelephoneNumber = br;
        this.Jmbg = jmbgG;
        this.Gender = pol;
        this.BirthdayDate = datR;
        //   this.patientId = idP;
        this.Id = id;


        this.guest = true;

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
             
            }
        }
    }
}