// File:    InventoryFileStorage.cs
// Author:  Milica
// Created: Tuesday, April 13, 2021 3:55:30 PM
// Purpose: Definition of Class InventoryFileStorage

using Hospital.FileStorage;
using Hospital.FileStorage.Interfaces;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;

public class InventoryFileStorage : GenericFileStorage<Inventory>,InventoryIFileStorage
{
    public InventoryFileStorage(String filePath) : base(filePath) { }
    public List<Inventory> inventoryByName(string name)
    {
        List<Inventory> filtratedInventory = new List<Inventory>();
        foreach(Inventory inventory in GetAll())
        {
            if (inventory.Name.Equals(name))
            {
                filtratedInventory.Add(inventory);
            }
        }
        return filtratedInventory;
    }

    public List<Inventory> inventoryByQuantity(int quantty)
    {
        List<Inventory> filtratedInventory = new List<Inventory>();
        foreach (Inventory inventory in GetAll())
        {
            if (inventory.Quantity.Equals(quantty))
            {
                filtratedInventory.Add(inventory);
            }
        }
        return filtratedInventory;
    }

    public List<Inventory> inventoryByType(string type)
    {
        List<Inventory> filtratedInventory = new List<Inventory>();
        foreach (Inventory inventory in GetAll())
        {
            if (Convert.ToString(inventory.Type).Equals(type))
            {
                filtratedInventory.Add(inventory);
            }
        }
        return filtratedInventory;
    }
}
