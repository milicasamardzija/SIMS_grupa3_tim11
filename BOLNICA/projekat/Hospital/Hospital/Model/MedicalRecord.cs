

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Controls;

public class MedicalRecord : Patient
{
    public int medicalRecordId;
    public BloodType bloodType;
    public ObservableCollection<Alergens> alergens;
    public MedicalRecord(String n, String s, String j, Gender g, DateTime dr, int mid, HealthCareCategory hcc, int idhc, BloodType bt)
    {
        this.Name = n;
        this.Surname = s;
        this.Jmbg = j;
        this.Gender = g;
        this.BirthdayDate = dr;
        this.MedicalRecordId=mid;   //medical record id ce biti isto sto i patientId, pa cu po tome traziti
        this.HealthCareCategory = hcc;
        this.IdHealthCard = idhc;
        this.BloodType = bt;

        //this.Alergens = null;


    }
  /*  public MedicalRecord(String ime, String prezime, String jmbgg, Gender pol, DateTime drodj, int id, BloodType kg, String alergeni)
    {
        this.name = ime;
        this.surname = prezime;
        this.jmbg = jmbgg;
        this.gender = pol;
        this.birthdayDate = drodj;
        this.medicalRecordId = id;   //medical record id ce biti isto sto i patientId, pa cu po tome traziti

        this.bloodType = kg;
        this.alergens = alergeni;


    }   */
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
    public ObservableCollection<Alergens> Alergens
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


