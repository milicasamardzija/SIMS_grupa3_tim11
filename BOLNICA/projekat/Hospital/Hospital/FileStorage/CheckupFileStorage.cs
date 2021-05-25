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
using Hospital.FileStorage;
using Hospital.FileStorage.Interfaces;

public class CheckupFileStorage : GenericFileStorage<Checkup>, ICheckFileStorage
{
    public CheckupFileStorage(string filePath) : base(filePath)
    {
    }

}