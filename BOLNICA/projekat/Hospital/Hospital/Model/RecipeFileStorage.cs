// File:    RecipeFileStorage.cs
// Author:  Ivana
// Created: četvrtak, 08. april 2021. 19:53:09
// Purpose: Definition of Class RecipeFileStorage

using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;

public class RecipeFileStorage
{
    public List<Recipe> GetAll()
    {
        List<Recipe> allRecipes = new List<Recipe>();
        allRecipes = JsonConvert.DeserializeObject<List<Recipe>>(File.ReadAllText(@"./../../../../Hospital/files/recepti.json"));
        return allRecipes;
    }

    public void SaveAll(List<Recipe> recipes)
    {
        using (StreamWriter file = File.CreateText(@"./../../../../Hospital/files/recepti.json"))
        {
            JsonSerializer ser = new JsonSerializer();
            ser.Serialize(file, recipes);
        }
    }

    public void Save(Recipe newRecipe)
    {
        List<Recipe> allRecipes = GetAll();
        allRecipes.Add(newRecipe);
        SaveAll(allRecipes);
    }

    public void Delete(Recipe recipe)
    {
        List<Recipe> allRecipes = GetAll();
        foreach (Recipe r in allRecipes)
        {
            if (r.idRecipe == recipe.idRecipe)
            {
                allRecipes.Remove(r);
                break;
            }
        }
        SaveAll(allRecipes);
    }

    public void DeleteById(int id)
    {
        List<Recipe> allRecipes = GetAll();
        foreach (Recipe r in allRecipes)
        {
            if (r.idRecipe == id)
            {
                allRecipes.Remove(r);
                break;
            }
        }
        SaveAll(allRecipes);
    }

    public Recipe FindById(int id)
    {
        List<Recipe> allRecipes = GetAll();
        Recipe ret = null;
        foreach (Recipe r in allRecipes)
        {
            if (r.idRecipe == id)
            {
                ret = r;
                break;
            }
        }
        return ret;
    }

    public Boolean ExistsById(int id)
    {
        List<Recipe> allRecipes = GetAll();
        Boolean ret = false;

        foreach (Recipe r in allRecipes)
        {
            if (r.idRecipe == id)
            {
                ret = true;
                break;
            }
        }
        return ret;
    }

}