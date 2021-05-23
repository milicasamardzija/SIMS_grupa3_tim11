// File:    AppointmentFileStorage.cs
// Author:  Milica
// Created: Friday, March 26, 2021 12:08:19 PM
// Purpose: Definition of Class AppointmentFileStorage

using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using System.IO;
using Hospital.FileStorage.Interfaces;
using Hospital.FileStorage;

public class AppointmentFileStorage : GenericFileStorage<Appointment>, AppointmentIFileStorage

{
    public AppointmentFileStorage(String filePath) : base(filePath) { }
}