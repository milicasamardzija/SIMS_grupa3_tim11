// File:    DoctorFileStorage.cs
// Author:  Milica
// Created: Sunday, April 4, 2021 7:04:20 PM
// Purpose: Definition of Class DoctorFileStorage

using Hospital.FileStorage;
using Hospital.FileStorage.Interfaces;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;

public class DoctorFileStorage : GenericFileStorage<Doctor>, IDoctorFileStorage
{
    public DoctorFileStorage(string filePath) : base(filePath)
    {
    }
}