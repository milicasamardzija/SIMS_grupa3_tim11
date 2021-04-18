// File:    MedicalRecord.cs
// Author:  Milica
// Created: Wednesday, March 24, 2021 9:12:35 PM
// Purpose: Definition of Class MedicalRecord

using System;
using System.Windows.Controls;

public class MedicalRecord : Patient
{
    public int medicalRecordId;
    public BloodType bloodType;
    public String alergens;

    public MedicalRecord(String n, String s, String j, Gender g, DateTime dr, int mid, HealthCareCategory hcc, int idhc, BloodType bt, String a)
    {
        this.name = n;
        this.surname = s;
        this.jmbg = j;
        this.gender = g;
        this.birthdayDate = dr;
        this.medicalRecordId=mid;   //medical record id ce biti isto sto i patientId, pa cu po tome traziti
        this.HealthCareCategory = hcc;
        this.IdHealthCard = idhc;
        this.bloodType = bt;
        this.alergens = a;


    }

    public int MedicalRecordId
    {
        get
        {
            return medicalRecordId;
        }
        set
        {
            if(value != medicalRecordId)
            {
                medicalRecordId = value;
                OnProperychanged("MedicalRecordId");
            }
        }
    }

    public BloodType BloodType
    {
        get
        {
            return bloodType;
        }
        set
        {
            if (value != bloodType)
            {
                bloodType = value;
                OnProperychanged("BloodType");
            }
        }
    }
    public String Alergens
    {
        get
        {
            return alergens;
        }
        set
        {
            if (value != alergens)
            {
                alergens = value;
                OnProperychanged("Alergens");
            }
        }
    }
}


