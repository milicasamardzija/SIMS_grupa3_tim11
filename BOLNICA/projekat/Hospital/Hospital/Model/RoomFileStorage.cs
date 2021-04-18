// File:    RoomFileStorage.cs
// Author:  Milica
// Created: Friday, March 26, 2021 12:08:17 PM
// Purpose: Definition of Class RoomFileStorage

using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;

public class RoomFileStorage
{
    public List<Room> GetAll()
    {
        List<Room> allRooms = new List<Room>();

        allRooms = JsonConvert.DeserializeObject<List<Room>>(File.ReadAllText(@"./../../../../Hospital/files/storageRooms.json"));

        return allRooms;
    }

    public void SaveAll(List<Room> rooms)
    {
        using (StreamWriter file = File.CreateText(@"./../../../../Hospital/files/storageRooms.json"))
        {
            JsonSerializer serializer = new JsonSerializer();
            serializer.Serialize(file, rooms);
        }
    }

    public void Save(Room newRoom)
    {
        List<Room> allRooms = GetAll();

        allRooms.Add(newRoom);

        SaveAll(allRooms);

    }

    public void Delete(Room room)
    {
        List<Room> allRooms = GetAll();

        foreach (Room temp in allRooms)
        {
            if (temp.RoomId == room.RoomId)
            {
                allRooms.Remove(temp);
                break;
            }
        }
        SaveAll(allRooms);
    }

    public Room FindById(int id)
    {
        List<Room> allRooms = GetAll();
        Room ret = null;

        foreach (Room room in allRooms)
        {
            if (room.RoomId == id)
            {
                ret = room;
                break;
            }
        }

        return ret;
    }

    public void DeleteById(int id)
    {
        List<Room> allRooms = GetAll();

        foreach (Room room in allRooms)
        {
            if (room.RoomId == id)
            {
                allRooms.Remove(room);
                break;
            }
        }
        SaveAll(allRooms);
    }

    public Boolean ExistsById(int id)
    {
        List<Room> allRooms = GetAll();
        Boolean ret = false;

        foreach (Room room in allRooms)
        {
            if (room.RoomId == id)
            {
                ret = true;
                break;
            }
        }
        return ret;
    }

    // public String fileLocation;

}