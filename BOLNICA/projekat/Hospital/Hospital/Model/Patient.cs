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
   private Boolean guest = false;

// public MedicalRecord medicalRecord;

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
}