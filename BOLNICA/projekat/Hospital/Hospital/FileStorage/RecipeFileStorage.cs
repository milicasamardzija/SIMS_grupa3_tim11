// File:    RecipeFileStorage.cs
// Author:  Ivana
// Created: četvrtak, 08. april 2021. 19:53:09
// Purpose: Definition of Class RecipeFileStorage

using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using Hospital.FileStorage.Interfaces;
using Hospital.FileStorage;

public class RecipeFileStorage : GenericFileStorage<Recipe>, IRecipeFileStorage
{
    public RecipeFileStorage(string filePath) : base(filePath)
    {
    }
}