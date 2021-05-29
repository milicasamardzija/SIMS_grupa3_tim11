// File:    RoomFileStorage.cs
// Author:  Milica
// Created: Friday, March 26, 2021 12:08:17 PM
// Purpose: Definition of Class RoomFileStorage

using System;
using System.Collections.Generic;
using System.IO;
using Hospital.FileStorage;
using Hospital.FileStorage.Interfaces;
using Newtonsoft.Json;

public class RoomFileStorage : GenericFileStorage<Room>, RoomIFileStorage
{
    public RoomFileStorage(String filePath) : base(filePath) { }
    public List<Room> roomsByType(String type)
    {
        List<Room> filtratedRooms = new List<Room>();
        foreach (Room room in GetAll())
        {
            if (type.ToUpper().Contains("soba".ToUpper()))
            {
                if (room.Purpose == Purpose.soba)
                {
                    filtratedRooms.Add(room);
                }
            }
            else if (type.ToUpper().Contains("ordinacija".ToUpper()))
            {
                if (room.Purpose == Purpose.ordinacija)
                {
                    filtratedRooms.Add(room);
                }
            }
            else if (type.ToUpper().Contains("sala".ToUpper()))
            {
                if (room.Purpose == Purpose.sala)
                {
                    filtratedRooms.Add(room);
                }
            }
            else if (type.Equals(""))
            {
                filtratedRooms = GetAll();
            }
        }
        return filtratedRooms;
    }
    public List<Room> roomByFloor(string floor)
    {
        List<Room> filtratedRooms = new List<Room>();
        foreach (Room room in GetAll())
        {
            if (floor.Contains("0") || floor.Contains("1") || floor.Contains("2") || floor.Contains("3") || floor.Contains("4") || floor.Contains("5") || floor.Contains("6") || floor.Contains("7") || floor.Contains("8") || floor.Contains("9"))
            {
                if (room.Floor == Convert.ToInt32(floor))
                {
                    filtratedRooms.Add(room);
                }
            } else if (floor.Equals(""))
            {
                filtratedRooms = GetAll();
            }
        }
        return filtratedRooms;
    }
}