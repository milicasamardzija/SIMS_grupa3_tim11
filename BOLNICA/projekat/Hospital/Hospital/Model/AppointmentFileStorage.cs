// File:    AppointmentFileStorage.cs
// Author:  Milica
// Created: Friday, March 26, 2021 12:08:19 PM
// Purpose: Definition of Class AppointmentFileStorage

using System;
using System.Collections.Generic;

public class AppointmentFileStorage
{
   public List<Appointment> GetAll()
   {
      throw new NotImplementedException();
   }
   
   public void Save(Appointment newAppointment)
   {
      throw new NotImplementedException();
   }
   
   public void SaveAll(List<Appointment> appointments)
   {
      throw new NotImplementedException();
   }
   
   public void Delete(Appointment appointment)
   {
      throw new NotImplementedException();
   }
   
   public void DeleteById(int id)
   {
      throw new NotImplementedException();
   }
   
   public Appointment FindById(int id)
   {
      throw new NotImplementedException();
   }
   
   public Boolean ExistsById(int id)
   {
      throw new NotImplementedException();
   }
   
   public String fileLocation;

}