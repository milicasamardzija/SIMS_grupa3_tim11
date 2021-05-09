// File:    CheckupFileStorage.cs
// Author:  Milica
// Created: Friday, March 26, 2021 12:08:18 PM
// Purpose: Definition of Class CheckupFileStorage

using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using System.IO;
using Hospital.Model;
using System.Collections.ObjectModel;

public class CheckupFileStorage
{
   public List<Checkup> GetAll()
   {
        List<Checkup> allCheckups = new List<Checkup>();
        allCheckups = JsonConvert.DeserializeObject<List<Checkup>>(File.ReadAllText(@"./../../../../Hospital/files/storageCheckup.json"));
        return allCheckups;
   }
   
   public void Save(Checkup newCheckup)
   {
        List<Checkup> allCheckups = GetAll();
        allCheckups.Add(newCheckup);
        SaveAll(allCheckups);
   }
   
   public void SaveAll(List<Checkup> checkups)
   {
        using (StreamWriter file = File.CreateText(@"./../../../../Hospital/files/storageCheckup.json"))
        {
            JsonSerializer ser = new JsonSerializer();
            ser.Serialize(file, checkups);
        }
   }
   
   public void Delete(Checkup checkup)
   {
        List<Checkup> allCheckups = GetAll();
        foreach(Checkup ch in allCheckups)
        {
            if(ch.IdCh == checkup.IdCh)
            {
                allCheckups.Remove(ch);
                break;
            }
        }
        SaveAll(allCheckups);
   }
   
   public void DeleteById(int id)
   {
        List<Checkup> allCheckups = GetAll();
        foreach(Checkup ch in allCheckups)
        {
            if(ch.IdCh == id)
            {
                allCheckups.Remove(ch);
                break;
            }
        }
        SaveAll(allCheckups);
   }
   
   public Checkup FindById(int id)
   {
        List<Checkup> allCheckups = GetAll();
        Checkup ret = null;
        foreach(Checkup ch in allCheckups)
        {
            if(ch.IdCh == id)
            {
                ret = ch;
                break;
            }
        }
        return ret;
   }
   
   public Boolean ExistsById(int id)
   {
        List<Checkup> allCheckups = GetAll();
        Boolean ret = false;

        foreach(Checkup ch in allCheckups)
        {
            if(ch.IdCh == id)
            {
                ret = true;
                break;
            }
        }
        return ret;
   }
   
   

}