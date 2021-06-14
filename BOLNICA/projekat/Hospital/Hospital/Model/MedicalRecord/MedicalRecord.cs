

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Controls;

public class MedicalRecord : Patient
{
    private int medicalRecordId;
    private BloodType bloodType;
    private ObservableCollection<Alergens> alergens;


    public MedicalRecord() { }
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
    public MedicalRecord(String ime, String prezime, String jmbgg, Gender pol, DateTime drodj, int id, HealthCareCategory hcc, int idhc, BloodType kg, ObservableCollection<Alergens> alergeni)
    {
        this.Name = ime;
        this.Surname = prezime;
        this.Jmbg = jmbgg;
        this.Gender = pol;
        this.BirthdayDate = drodj;
        this.HealthCareCategory = hcc;
        this.medicalRecordId = id;   //medical record id ce biti isto sto i patientId, pa cu po tome traziti
        this.IdHealthCard = idhc;
        this.bloodType = kg;
        this.alergens = alergeni;


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


