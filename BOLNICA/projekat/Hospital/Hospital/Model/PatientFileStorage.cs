// File:    PatientFileStorage.cs
// Author:  Milica
// Created: Friday, March 26, 2021 12:08:18 PM
// Purpose: Definition of Class PatientFileStorage

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using Newtonsoft.Json;

public class PatientFileStorage
{
   public ObservableCollection<Patient> GetAll()
   {
      ObservableCollection<Patient> sviPacijenti= new ObservableCollection<Patient>();

        sviPacijenti = JsonConvert.DeserializeObject<ObservableCollection<Patient>>(File.ReadAllText(@"./../../../../Hospital/files/storagePatient.json"));
        return sviPacijenti;
   }
   
   public void Save(Patient newPatient)
   {
        ObservableCollection<Patient> sviPacijenti = GetAll();
        sviPacijenti.Add(newPatient);
        SaveAll(sviPacijenti);
      
   }
   
   public void SaveAll(ObservableCollection<Patient> patients)
   {
        using (StreamWriter file = File.CreateText(@"./../../../../Hospital/files/storagePatient.json"))
        {
            JsonSerializer serializer = new JsonSerializer();
            serializer.Serialize(file, patients);

        }
    }
   
   public void Delete(Patient patient)
   {
        ObservableCollection<Patient> allPatients = GetAll();

        foreach (Patient p in allPatients)
        {
            if (p.patientId == patient.patientId)
            {
                allPatients.Remove(p);
                break;
            }
        }
        SaveAll(allPatients);
    }

    public void DeleteById(int id)


    {
        ObservableCollection<Patient> allPatients = GetAll();

        foreach (Patient patient in allPatients) {

            if (patient.patientId == id) {

                allPatients.Remove(patient);
                break;
            }
        }
        SaveAll(allPatients);
   }
   
   public Patient FindById(int id)
   {
        ObservableCollection<Patient> allPatients = GetAll();
        Patient ret = null;

        foreach (Patient patient in allPatients)
        {
            if (patient.patientId == id)
            {
                ret = patient;
                break;
            }
        }

        return ret;
    }
   
   public Boolean ExistsById(int id)
   {
        ObservableCollection<Patient> allPatients = GetAll();
        Boolean ret = false;

        foreach (Patient patient in allPatients)
        {
            if (patient.patientId == id)
            {
                ret = true;
                break;
            }
        }
        return ret;
   }
   


}