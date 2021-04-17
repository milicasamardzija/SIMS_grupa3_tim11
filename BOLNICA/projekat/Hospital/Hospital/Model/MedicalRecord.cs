// File:    MedicalRecord.cs
// Author:  Milica
// Created: Wednesday, March 24, 2021 9:12:35 PM
// Purpose: Definition of Class MedicalRecord

using System;
using System.Windows.Controls;

public class MedicalRecord : Patient
{
   public int medicalRecordId { get; set; }
   public BloodType bloodType { get; set; }
    public String alergens { get; set; }

    public MedicalRecord(String n, String s, String j, Gender g, DateTime dr, int mid, HealthCareCategory hcc, int idhc, BloodType bt, String a)
    {
        this.name = n;
        this.surname = s;
        this.jmbg = j;
        this.gender = g;
        this.birthdayDate = dr;
        this.medicalRecordId=mid;   //medical record id ce biti isto sto i patientId, pa cu po tome traziti
        this.healthCareCategory = hcc;
        this.idHealthCard = idhc;
        this.bloodType = bt;
        this.alergens = a;


    }
}

