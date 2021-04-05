// File:    ManagerFileStorage.cs
// Author:  Milica
// Created: Sunday, April 4, 2021 7:04:24 PM
// Purpose: Definition of Class ManagerFileStorage

using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;

public class ManagerFileStorage
{
   public List<Manager> GetAll()
   {
        List<Manager> allManagers = new List<Manager>();

        allManagers = JsonConvert.DeserializeObject<List<Manager>>(File.ReadAllText(@"./../../../../Hospital/files/storageManager.json"));

        return allManagers;
   }
   
   public void SaveAll(List<Manager> managers)
   {
        using (StreamWriter file = File.CreateText(@"./../../../../Hospital/files/storageManager.json"))
        {
            JsonSerializer serializer = new JsonSerializer();
            serializer.Serialize(file, managers);
        }
    }
   
   public void Save(Manager newManager)
   {
        List<Manager> allManagers = GetAll();
        allManagers.Add(newManager);
        SaveAll(allManagers);
    }
   
   public void Delete(Manager manager)
   {
      throw new NotImplementedException();
   }
   
   public void DeleteById(int id)
   {
      throw new NotImplementedException();
   }
   
   public Manager FindById(int id)
   {
      throw new NotImplementedException();
   }
   
   public Boolean ExistsById(int id)
   {
      throw new NotImplementedException();
   }

}