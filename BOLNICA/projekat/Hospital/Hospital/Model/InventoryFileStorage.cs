// File:    InventoryFileStorage.cs
// Author:  Milica
// Created: Tuesday, April 13, 2021 3:55:30 PM
// Purpose: Definition of Class InventoryFileStorage

using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;

public class InventoryFileStorage
{
    public List<Inventory> GetAll()
    {
        List<Inventory> allInventory = new List<Inventory>();

        allInventory = JsonConvert.DeserializeObject<List<Inventory>>(File.ReadAllText(@"./../../../../Hospital/files/storageInventory.json"));

        return allInventory;
    }

    public void Save(Inventory newInventory)
    {
        List<Inventory> allInventories = GetAll();
        int br = 0;

        /* foreach (Inventory inventory in allInventories)
         {
             if (ExistsById(inventory.inventoryId))
             {
                 allInventories[br] = newInventory;
             } else
             {
                 allInventories.Add(newInventory);
             }
             br++;*/

        allInventories.Add(newInventory);
        SaveAll(allInventories);
    }

    public void SaveAll(List<Inventory> inventories)
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
            if (temp.inventoryId == inventory.inventoryId)
            {
                allInventories.Remove(temp);
                break;
            }
        }
        SaveAll(allInventories);
    }

    public void DeleteById(int id)
    {
        List<Inventory> allInventories = GetAll();

        foreach (Inventory inventory in allInventories)
        {
            if (inventory.inventoryId == id)
            {
                allInventories.Remove(inventory);
                break;
            }
        }
        SaveAll(allInventories);
    }

    public Inventory FindById(int id)
    {
        List<Inventory> allInventories = GetAll();
        Inventory ret = null;

        foreach (Inventory inventory in allInventories)
        {
            if (inventory.inventoryId == id)
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
            if (inventory.inventoryId == id)
            {
                ret = true;
                break;
            }
        }
        return ret;
    }

}