// File:    Doctor.cs
// Author:  Nevena
// Created: Monday, March 22, 2021 3:21:07 PM
// Purpose: Definition of Class Doctor

using Hospital.Model;
using System;

public class Doctor : User
{
   public int doctorId { get; set; }
  // public String specialization;
   public int freeDays = 25;
   public SpecializationType specializationType { get; set; }

}