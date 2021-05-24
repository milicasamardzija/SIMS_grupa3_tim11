// File:    RecipeFileStorage.cs
// Author:  Ivana
// Created: četvrtak, 08. april 2021. 19:53:09
// Purpose: Definition of Class RecipeFileStorage

using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using Hospital.FileStorage;
using Hospital.FileStorage.Interfaces;

public class RecipeFileStorage : GenericFileStorage<Recipe>, RecipeIFileStorage
{
    public RecipeFileStorage(string filePath) : base(filePath)
    {
    }
}