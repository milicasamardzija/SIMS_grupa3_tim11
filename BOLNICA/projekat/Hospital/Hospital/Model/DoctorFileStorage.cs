// File:    DoctorFileStorage.cs
// Author:  Milica
// Created: Sunday, April 4, 2021 7:04:20 PM
// Purpose: Definition of Class DoctorFileStorage

using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;

public class DoctorFileStorage
{
   public List<Doctor> GetAll()
   {
        List<Doctor> allDoctors = new List<Doctor>();

        allDoctors = JsonConvert.DeserializeObject<List<Doctor>>(File.ReadAllText(@"./../../../../Hospital/files/storageDoctor.json"));

        return allDoctors;
    }
   
   public void SaveAll(List<Doctor> doctors)
   {
        using (StreamWriter file = File.CreateText(@"./../../../../Hospital/files/storageDoctor.json"))
        {
            JsonSerializer serializer = new JsonSerializer();
            serializer.Serialize(file, doctors);
        }
    }
   
   public void Save(Doctor newDoctor)
   {
        List<Doctor> allDoctors = GetAll();
        allDoctors.Add(newDoctor);
        SaveAll(allDoctors);
   }
   
   public void Delete(Doctor doctor)
   {
        List<Doctor> allDoctors = GetAll();

        foreach (Doctor temp in allDoctors)
        {
            if (temp.doctorId == doctor.doctorId)
            {
                allDoctors.Remove(temp);
                break;
            }
        }
        SaveAll(allDoctors);
    }
   
   public void DeleteById(int id)
   {
        List<Doctor> allDoctors = GetAll();

        foreach (Doctor doctor in allDoctors)
        {
            if (doctor.doctorId == id)
            {
                allDoctors.Remove(doctor);
                break;
            }
        }
        SaveAll(allDoctors);
    }
   
   public Doctor FindById(int id)
   {
        List<Doctor> allDoctors = GetAll();
        Doctor ret = null;

        foreach (Doctor doctor in allDoctors)
        {
            if (doctor.doctorId == id)
            {
                ret = doctor;
                break;
            }
        }
        return ret;
    }
   
   public Boolean ExistsById(int id)
   {
        List<Doctor> allDoctors = GetAll();
        Boolean ret = false;

        foreach (Doctor doctor in allDoctors)
        {
            if (doctor.doctorId == id)
            {
                ret = true;
                break;
            }
        }
        return ret;
    }

}