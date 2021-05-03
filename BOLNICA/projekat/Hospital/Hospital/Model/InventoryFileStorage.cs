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
    private RoomFileStorage roomStorage { get; set; }
    private RoomInventoryFileStorage roomInventoryStorage { get; set; }
    public InventoryFileStorage()
    {
        roomStorage = new RoomFileStorage();
        roomInventoryStorage = new RoomInventoryFileStorage();
    }
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
        List<Inventory> allInventories = GetAll();

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

    public void moveInventory(Inventory inventory, int idRoomIn, int idRoomOut, int quantity)
    {
        //ako ne postoji inventar u toj sobi, odnosno pravi se novi RoomInventory objekat
        Boolean nadjen = true;

        //liste
        List<RoomInventory> all = roomInventoryStorage.GetAll();
        List<Inventory> inventories = this.GetAll();

        if (idRoomIn != -1)
        {
            foreach (RoomInventory roomInv in all)
            {
                //ako vec postoji zeljeni inventar u unetoj sobi
                if (roomInv.idInventory == inventory.InventoryId && roomInv.idRoom == idRoomIn)
                {
                    roomInv.Quantity += quantity;     //povecava se kolicina inventara u sobi
                    nadjen = false;
                    roomInventoryStorage.SaveAll(all);//kompletna izmenja lista se serijalizuje
                    break;
                }

            }

            //ako ne postoji izabrani inventar u unetoj sobi
            if (nadjen)
            {
                Room room = new Room();
                Inventory invent = new Inventory();

                foreach (Room r in roomStorage.GetAll())
                {
                    if (r.RoomId == idRoomIn)
                    {
                        room.RoomId = r.RoomId;
                        room.Floor = r.Floor;
                        room.Occupancy = r.Occupancy;
                        room.Purpose = r.Purpose;
                        break;
                    }
                }

                foreach (Inventory i in this.GetAll())
                {
                    if (i.InventoryId == inventory.InventoryId)
                    {
                        invent.InventoryId = i.InventoryId;
                        invent.Name = i.Name;
                        invent.Quantity = i.Quantity;
                        invent.Type = i.Type;
                        break;
                    }
                }
                RoomInventory newInventory = new RoomInventory(idRoomIn, room, invent.InventoryId, invent, quantity);
                all.Add(newInventory);
            }
        }
        else //ako se prebacuje u magacin
        {
            foreach (Inventory invent in inventories)
            {
                if (invent.InventoryId == inventory.InventoryId)
                {
                    invent.Quantity += quantity;
                    this.SaveAll(inventories);
                    break;
                }
            }
        }

        if (idRoomOut == -1)
        {
            foreach (Inventory i in inventories)
            {
                if (i.InventoryId == inventory.InventoryId)
                {
                    i.Quantity -= quantity;

                    if (i.Quantity == 0)
                    {
                        inventories.Remove(i);
                    }

                    this.SaveAll(inventories);
                    roomInventoryStorage.SaveAll(all);
                    break;
                }
            }
        }
        else
        {
            foreach (RoomInventory ri in all)
            {
                if (ri.idRoom == idRoomOut && ri.idInventory == inventory.InventoryId)
                {
                    ri.Quantity -= quantity;

                    if (ri.Quantity == 0)
                    {
                        all.Remove(ri);
                    }

                    roomInventoryStorage.SaveAll(all);
                    break;
                }
            }
        }
    }
}
