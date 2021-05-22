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
}