// File:    AnamnesisFileStorage.cs
// Author:  Ivana
// Created: četvrtak, 08. april 2021. 20:01:14
// Purpose: Definition of Class AnamnesisFileStorage

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hospital;
using Newtonsoft.Json;
using System.IO;

public class AnamnesisFileStorage
{
    public List<Anamnesis> GetAll()
    {
        List<Anamnesis> allAn = new List<Anamnesis>();
        allAn = JsonConvert.DeserializeObject<List<Anamnesis>>(File.ReadAllText(@"./../../../../Hospital/files/anamnesis.json"));
        return allAn;
    }

    public void Save(Anamnesis newAnamnesis)
    {
        List<Anamnesis> allAn = GetAll();
        allAn.Add(newAnamnesis);
        SaveAll(allAn);
    }

    public void SaveAll(List<Anamnesis> anam)
    {
        using (StreamWriter file = File.CreateText(@"./../../../../Hospital/files/anamnesis.json"))
        {
            JsonSerializer ser = new JsonSerializer();
            ser.Serialize(file, anam);
        }
    }

    public void Delete(Anamnesis ana)
    {
        List<Anamnesis> allAn = GetAll();
        foreach (Anamnesis a in allAn)
        {
            if (a.idAnam == ana.idAnam)
            {
                allAn.Remove(a);
                break;
            }
        }
        SaveAll(allAn);
    }

    public void DeleteById(int id)
    {
        List<Anamnesis> allAn = GetAll();
        foreach (Anamnesis a in allAn)
        {
            if (a.idAnam == id)
            {
                allAn.Remove(a);
                break;
            }
        }
        SaveAll(allAn);
    }

    public Anamnesis FindById(int id)
    {
        List<Anamnesis> allAn = GetAll();
        Anamnesis ret = null;
        foreach (Anamnesis a in allAn)
        {
            if (a.idAnam == id)
            {
                ret = a;
                break;
            }
        }
        return ret;
    }

    public Boolean ExistsById(int id)
    {
        List<Anamnesis> allAn = GetAll();
        Boolean ret = false;

        foreach (Anamnesis a in allAn)
        {
            if (a.idAnam == id)
            {
                ret = true;
                break;
            }
        }
        return ret;
    }

}