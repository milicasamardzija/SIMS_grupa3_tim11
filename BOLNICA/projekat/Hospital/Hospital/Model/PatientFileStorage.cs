// File:    PatientFileStorage.cs
// Author:  Milica
// Created: Friday, March 26, 2021 12:08:18 PM
// Purpose: Definition of Class PatientFileStorage

using System;
using System.Collections.Generic;

public class PatientFileStorage
{
   public List<Patient> GetAll()
   {
      throw new NotImplementedException();
   }
   
   public void Save(Patient newPatient)
   {
      throw new NotImplementedException();
   }
   
   public void SaveAll(List<Patient> patients)
   {
      throw new NotImplementedException();
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