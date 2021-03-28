// File:    PatientFileStorage.cs
// Author:  Milica
// Created: Friday, March 26, 2021 12:08:18 PM
// Purpose: Definition of Class PatientFileStorage

using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;

public class PatientFileStorage
{
   public List<Patient> GetAll()
   {
      List<Patient> sviPacijenti= new List<Patient>();

        sviPacijenti = JsonConvert.DeserializeObject<List<Patient>>(File.ReadAllText(@"storagePatient.json"));
        return sviPacijenti;
   }
   
   public void Save(Patient newPatient)
   {
        List<Patient> sviPacijenti = GetAll();
        sviPacijenti.Add(newPatient);
        SaveAll(sviPacijenti);
      
   }
   
   public void SaveAll(List<Patient> patients)
   {
        using (StreamWriter file = File.CreateText(@"storagePatient.json"))
        {
            JsonSerializer serializer = new JsonSerializer();
            serializer.Serialize(file, patients);

        }
    }
   
   public void Delete(Patient patient)
   {
      throw new NotImplementedException();
   }
   
   public void DeleteById(int id)
   {
      throw new NotImplementedException();
   }
   
   public Patient FindById(int id)
   {
      throw new NotImplementedException();
   }
   
   public Boolean ExistsById(int id)
   {
      throw new NotImplementedException();
   }
   
   public String fileLocation;

}