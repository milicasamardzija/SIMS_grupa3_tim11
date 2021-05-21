// File:    SecretaryFileStorage.cs
// Author:  Milica
// Created: Sunday, April 4, 2021 7:04:22 PM
// Purpose: Definition of Class SecretaryFileStorage

using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;

public class SecretaryFileStorage
{
   public List<Secretary> GetAll()
   {
        List<Secretary> allSecretaries = new List<Secretary>();

        allSecretaries = JsonConvert.DeserializeObject<List<Secretary>>(File.ReadAllText(@"./../../../../Hospital/files/storageSecretaries.json"));

        return allSecretaries;
    }
   
   public void SaveAll(List<Secretary> secteraties)
   {
        using (StreamWriter file = File.CreateText(@"./../../../../Hospital/files/storageSecretaries.json"))
        {
            JsonSerializer serializer = new JsonSerializer();
            serializer.Serialize(file, secteraties);
        }
    }
   
   public void Save(Secretary newSecretary)
   {
      throw new NotImplementedException();
   }
   
   public void Delete(Secretary secretary)
   {
      throw new NotImplementedException();
   }
   
   public void DeleteById(int id)
   {
      throw new NotImplementedException();
   }
   
   public Secretary FindById(int id)
   {
      throw new NotImplementedException();
   }
   
   public Boolean ExistsById(int id)
   {
      throw new NotImplementedException();
   }

}