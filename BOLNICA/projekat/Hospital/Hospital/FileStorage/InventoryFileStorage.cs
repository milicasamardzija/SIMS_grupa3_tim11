// File:    InventoryFileStorage.cs
// Author:  Milica
// Created: Tuesday, April 13, 2021 3:55:30 PM
// Purpose: Definition of Class InventoryFileStorage

using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;

public class InventoryFileStorage
{
    public InventoryFileStorage() { }
    public List<Inventory> GetAll()
    {
        List<Inventory> allInventory = new List<Inventory>();

        allInventory = JsonConvert.DeserializeObject<List<Inventory>>(File.ReadAllText(@"./../../../../Hospital/files/storageInventory.json"));

        return allInventory;
    }

    public void Save(Inventory newInventory)
    {
        List<Inventory> allInventories = GetAll();

         allInventories.Add(newInventory);

        serialize(allInventories);
    }

    public void serialize(List<Inventory> inventories)
    {
        using (StreamWriter file = File.CreateText(@"./../../../../Hospital/files/storageInventory.json"))
        {
            JsonSerializer serializer = new JsonSerializer();
            serializer.Serialize(file, inventories);
        }
    }

    public void Delete(Inventory inventory)
    {
        List<Inventory> allInventories = GetAll();

        foreach (Inventory temp in allInventories)
        {
            if (temp.InventoryId == inventory.InventoryId)
            {
                allInventories.Remove(temp);
                break;
            }
        }
        serialize(allInventories);
    }

    public void DeleteById(int id)
    {
        List<Inventory> allInventories = GetAll();

        foreach (Inventory inventory in allInventories)
        {
            if (inventory.InventoryId == id)
            {
                allInventories.Remove(inventory);
                break;
            }
        }
        serialize(allInventories);
    }

    public Inventory FindById(int id)
    {
        List<Inventory> allInventories = GetAll();
        Inventory ret = null;

        foreach (Inventory inventory in allInventories)
        {
            if (inventory.InventoryId == id)
            {
                ret = inventory;
                break;
            }
        }

        return ret;
    }

    public Boolean ExistsById(int id)
    {
        List<Inventory> allInventories = GetAll();
        Boolean ret = false;

        foreach (Inventory inventory in allInventories)
        {
            if (inventory.InventoryId == id)
            {
                ret = true;
                break;
            }
        }
        return ret;
    }
}
