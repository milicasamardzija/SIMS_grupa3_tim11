// File:    PatientFileStorage.cs
// Author:  Milica
// Created: Friday, March 26, 2021 12:08:18 PM
// Purpose: Definition of Class PatientFileStorage

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using Hospital.FileStorage;
using Hospital.FileStorage.Interfaces;
using Newtonsoft.Json;

public class PatientFileStorage : GenericFileStorage<Patient>, IPatientFileStorage 
{
    public PatientFileStorage(String filePath) : base(filePath) { }
   
    public List<Patient> patientBySurname(String valueS)
    {
        List<Patient> filtratedPatients = new List<Patient>();

        foreach(Patient p in GetAll())
        {
            if (p.Surname.ToUpper().Contains(valueS.ToUpper()))
            {
                filtratedPatients.Add(p);
            }
        }
        return filtratedPatients;
    }

}