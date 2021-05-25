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
using Hospital.FileStorage.Interfaces;
using Hospital.FileStorage;

public class AnamnesisFileStorage : GenericFileStorage<Anamnesis>, IAnamnesisFileStorage
{
    public AnamnesisFileStorage(string filePath) : base(filePath)
    {
    }
}