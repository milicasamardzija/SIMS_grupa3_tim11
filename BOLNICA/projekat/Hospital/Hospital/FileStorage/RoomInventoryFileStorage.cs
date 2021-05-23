// File:    RoomInventoryFileStorage.cs
// Author:  Milica
// Created: Wednesday, April 14, 2021 6:35:22 PM
// Purpose: Definition of Class RoomInventoryFileStorage

using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;

public class RoomInventoryFileStorage
{
   public List<RoomInventory> GetAll()
   {
        List<RoomInventory> all = new List<RoomInventory>();

        all = JsonConvert.DeserializeObject<List<RoomInventory>>(File.ReadAllText(@"./../../../../Hospital/files/storageRoomInventory.json"));

        return all;
    }
   
   public void Save(RoomInventory newRoomInventory)
   {
        List<RoomInventory> allInventories = GetAll();

        allInventories.Add(newRoomInventory);

        serialize(allInventories);
    }
   
   public void serialize(List<RoomInventory> all)
   {
        using (StreamWriter file = File.CreateText(@"./../../../../Hospital/files/storageRoomInventory.json"))
        {
            JsonSerializer serializer = new JsonSerializer();
            serializer.Serialize(file, all);
        }
    }
   
   public void Delete(RoomInventory roomInventory)
   {
        List<RoomInventory> allInventories = GetAll();

        foreach (RoomInventory temp in allInventories)
        {
            if (temp.IdInventory == roomInventory.IdInventory && temp.IdRoom == roomInventory.IdRoom)
            {
                allInventories.Remove(temp);
                break;
            }
        }
        serialize(allInventories);
    }
   
   public void DeleteByIdInventory(int id)
   {
        List<RoomInventory> allInventories = GetAll();

        foreach (RoomInventory inventory in allInventories)
        {
            if (inventory.Inventory.Id == id)
            {
                allInventories.Remove(inventory);
                break;
            }
        }
        serialize(allInventories);
   }

    public void DeleteByIdRoom(int id)
    {
        List<RoomInventory> allInventories = GetAll();

        foreach (RoomInventory inventory in allInventories)
        {
            if (inventory.IdRoom == id)
            {
                allInventories.Remove(inventory);
                break;
            }
        }
        serialize(allInventories);
    }

    public RoomInventory FindByRoomId(int id)
   {
        List<RoomInventory> allInventories = GetAll();
        RoomInventory ret = null;

        foreach (RoomInventory inventory in allInventories)
        {
            if (inventory.Room.Id == id)
            {
                ret = inventory;
                break;
            }
        }

        return ret;
    }
   
   public Boolean ExistsById(int id)
   {
        List<RoomInventory> allInventories = GetAll();
        Boolean ret = false;

        foreach (RoomInventory inventory in allInventories)
        {
            if (inventory.Inventory.Id == id)
            {
                ret = true;
                break;
            }
        }
        return ret;
    }

}