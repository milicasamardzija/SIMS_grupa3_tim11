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
        appointments = JsonConvert.DeserializeObject<List<Appointment>>(File.ReadAllText(@"./../../../../Hospital/files/termini.json"));
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
        using (StreamWriter file = File.CreateText(@"./../../../../Hospital/files/termini.json"))
        {
            JsonSerializer serializer = new JsonSerializer();
            serializer.Serialize(file, appointments);
        }
    }
   
   public void Delete(Appointment appointment)
   {
        List<Appointment> termini = GetAll();

        foreach (Appointment termin in termini)
        {
            if (termin.idA == appointment.idA)
            {
                termini.Remove(appointment);
                break;
            }
        }
        SaveAll(termini);
    }
   
   public void DeleteById(int id)
   {
        List<Appointment> termini = GetAll();

        foreach (Appointment termin in termini)
        {
            if (termin.idA == id)
            {
                termini.Remove(termin);
                break;
            }
        }
        SaveAll(termini);
    }
   
   public Appointment FindById(int id)
   {

        List<Appointment> termini = GetAll();
        Appointment app = null;

        foreach (Appointment termin in termini)
        {
            if (termin.idA == id)
            {
                app = termin;
                break;
            }
        }

        return app;
    }

    public Boolean ExistsById(int id)
    {
        List<Appointment> termini = GetAll();
        Boolean app = false;

        foreach (Appointment termin in termini)
        {
            if (termin.idA == id)
            {
                app = true;
                break;
            }
        }
        return app;

    }
   public String fileLocation;

}