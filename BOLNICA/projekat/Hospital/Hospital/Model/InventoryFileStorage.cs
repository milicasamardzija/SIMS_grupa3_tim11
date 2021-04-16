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
    public ObservableCollection<Inventory> GetAll()
    {
        ObservableCollection<Inventory> allInventory = new ObservableCollection<Inventory>();

        allInventory = JsonConvert.DeserializeObject<ObservableCollection<Inventory>>(File.ReadAllText(@"./../../../../Hospital/files/storageInventory.json"));

        return allInventory;
    }

    public void Save(Inventory newInventory)
    {
        ObservableCollection<Inventory> allInventories = GetAll();

         allInventories.Add(newInventory);

        SaveAll(allInventories);
    }

    public void SaveAll(ObservableCollection<Inventory> inventories)
    {
        using (StreamWriter file = File.CreateText(@"./../../../../Hospital/files/storageInventory.json"))
        {
            JsonSerializer serializer = new JsonSerializer();
            serializer.Serialize(file, inventories);
        }
    }

    public void Delete(Inventory inventory)
    {
        ObservableCollection<Inventory> allInventories = GetAll();

        foreach (Inventory temp in allInventories)
        {
            if (temp.InventoryId == inventory.InventoryId)
            {
                allInventories.Remove(temp);
                break;
            }
        }
        SaveAll(allInventories);
    }

    public void DeleteById(int id)
    {
        ObservableCollection<Inventory> allInventories = GetAll();

        foreach (Inventory inventory in allInventories)
        {
            if (inventory.InventoryId == id)
            {
                allInventories.Remove(inventory);
                break;
            }
        }
        SaveAll(allInventories);
    }

    public Inventory FindById(int id)
    {
        ObservableCollection<Inventory> allInventories = GetAll();
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
        ObservableCollection<Inventory> allInventories = GetAll();
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