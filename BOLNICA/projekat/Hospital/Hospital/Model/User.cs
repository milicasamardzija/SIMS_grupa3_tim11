// File:    User.cs
// Author:  Milica
// Created: Wednesday, March 24, 2021 9:17:46 PM
// Purpose: Definition of Class User

using System;

public class User
{
   public void LogIn(String password, String username)
   {
      throw new NotImplementedException();
   }
 
   public void LogOut(String password, String username)
   {
      throw new NotImplementedException();
   }
   
   public String name { get; set; }
   public String surname { get; set; }
    public String telephoneNumber { get; set; }
    public String jmbg { get; set; }
    public Gender gender { get; set; }
    // public DateTime birthdayDate;
    public String birthdate { get; set; }
    public String username { get; set; }
    public String password { get; set; }

    public Adress adress { get; set; }

}