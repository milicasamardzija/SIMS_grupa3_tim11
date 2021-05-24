// File:    MedicalRecordsFileStorage.cs
// Author:  Nevena
// Created: subota, 17. april 2021. 19:32:15
// Purpose: Definition of Class MedicalRecordsFileStorage

using System;
using System.Collections.Generic;
using System.IO;
using Hospital.FileStorage;
using Hospital.FileStorage.Interfaces;
using Newtonsoft.Json;

public class MedicalRecordsFileStorage : GenericFileStorage<MedicalRecord>, IMedicalRecordFileStorage
{
    public MedicalRecordsFileStorage(String filePath) : base(filePath) { }
   /* public List<MedicalRecord> GetAll()
   {
        List<MedicalRecord> sviKartoni = new List<MedicalRecord>();

        sviKartoni = JsonConvert.DeserializeObject<List<MedicalRecord>>(File.ReadAllText(@"./../../../../Hospital/files/storageMRecords.json"));
        return sviKartoni;
   }

   
   public void Save(MedicalRecord newMedicalRecord)
   {
        List<MedicalRecord> sviKartoni = GetAll();
        sviKartoni.Add(newMedicalRecord);
        SaveAll(sviKartoni);

   }
   
   public void SaveAll(List<MedicalRecord> medicalRecords)
   {
      using (StreamWriter file = File.CreateText(@"./../../../../Hospital/files/storageMRecords.json"))

        {
            JsonSerializer serializer = new JsonSerializer();
            serializer.Serialize(file, medicalRecords);

        }
   }
   
   public void Delete(MedicalRecord medicalRecord)
   {
        List<MedicalRecord> allRecords = GetAll();

        foreach(MedicalRecord mr in allRecords)
        {
            if(mr.medicalRecordId==medicalRecord.medicalRecordId)
            {
                allRecords.Remove(mr);
                break;
            }
        }
        SaveAll(allRecords);
   }
   
   public void DeleteById(int mId)
   {
        List<MedicalRecord> allRecords = GetAll();

        foreach(MedicalRecord mr in allRecords)
        {
            if(mr.medicalRecordId==mId)
            {
                allRecords.Remove(mr);
                break;
            }
        }
        SaveAll(allRecords);
   }
   
   public MedicalRecord FindById(int mId)
   {
        List<MedicalRecord> allRecords = GetAll();
        MedicalRecord ret = null;

        foreach(MedicalRecord mr in allRecords)
        {
            if(mr.medicalRecordId==mId)
            {
                ret = mr;
                break;

            }
        }
        return ret;
   }
   
   public Boolean ExistsById(int mId)
   {
        List<MedicalRecord> allRecords = GetAll();

        Boolean ret = false;

        foreach (MedicalRecord mr in allRecords)
        {
            if (mr.medicalRecordId == mId)
            {
                ret = true;
                break;
            }
        }
        return ret;
    } */

}