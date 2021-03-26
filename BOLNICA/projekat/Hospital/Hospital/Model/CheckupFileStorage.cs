// File:    CheckupFileStorage.cs
// Author:  Milica
// Created: Friday, March 26, 2021 12:08:18 PM
// Purpose: Definition of Class CheckupFileStorage

using System;
using System.Collections.Generic;

public class CheckupFileStorage
{
   public List<Checkup> GetAll()
   {
      throw new NotImplementedException();
   }
   
   public void Save(Checkup newCheckup)
   {
      throw new NotImplementedException();
   }
   
   public void SaveAll(List<Checkup> checkups)
   {
      throw new NotImplementedException();
   }
   
   public void Delete(Checkup checkup)
   {
      throw new NotImplementedException();
   }
   
   public void DeleteById(int id)
   {
      throw new NotImplementedException();
   }
   
   public Checkup FindById(int id)
   {
      throw new NotImplementedException();
   }
   
   public Boolean ExistsById(int id)
   {
      throw new NotImplementedException();
   }
   
   public String fileLocation;

}