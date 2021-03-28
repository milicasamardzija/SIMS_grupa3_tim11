// File:    AppointmentFileStorage.cs
// Author:  Milica
// Created: Friday, March 26, 2021 12:08:19 PM
// Purpose: Definition of Class AppointmentFileStorage

using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using System.IO;

public class AppointmentFileStorage
{
   public List<Appointment> GetAll()
   {
        List<Appointment> appointments = new List<Appointment>();
        appointments = JsonConvert.DeserializeObject<List<Appointment>>(File.ReadAllText(@"termini.json"));
        return appointments;
   }
   
   public void Save(Appointment newAppointment)
   {
        List<Appointment> app = GetAll();
        app.Add(newAppointment);
        SaveAll(app);
    }
   
   public void SaveAll(List<Appointment> appointments)
   {
        using (StreamWriter file = File.CreateText(@"termini.json"))
        {
            JsonSerializer serializer = new JsonSerializer();
            serializer.Serialize(file, appointments);
        }
    }
   
   public void Delete(Appointment appointment)
   {
      throw new NotImplementedException();
   }
   
   public void DeleteById(int id)
   {
      throw new NotImplementedException();
   }
   
   public Appointment FindById(int id)
   {
      throw new NotImplementedException();
   }
   
   public Boolean ExistsById(int id)
   {
      throw new NotImplementedException();
   }
   
   public String fileLocation;

}