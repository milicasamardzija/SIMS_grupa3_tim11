// File:    User.cs
// Author:  Milica
// Created: Wednesday, March 24, 2021 9:17:46 PM
// Purpose: Definition of Class User

using System;
using System.ComponentModel;

public class User : INotifyPropertyChanged
{
   public void LogIn(String password, String username)
   {
      throw new NotImplementedException();
   }
   
   public void LogOut(String password, String username)
   {
      throw new NotImplementedException();
   }
   
   public String name;
   public String surname;
   public String telephoneNumber;
   public String jmbg;
   public Gender gender;
    // public DateTime birthdayDate;
   public String birthdate;
   public String username;
   public String password;
   
   public Adress adress;

    public event PropertyChangedEventHandler PropertyChanged;

    protected virtual void OnProperychanged(string name)
    {
        if (PropertyChanged != null)
        {
            PropertyChanged(this, new PropertyChangedEventArgs(name));
        }
    }

    public String Name
    {
        get
        {
            return name;
        }
        set
        {
            if (value != name)
            {
                name = value;
                OnProperychanged("Name");
            }
        }
    }

    public String Surname
    {
        get
        {
            return surname;
        }
        set
        {
            if (value != surname)
            {
                surname = value;
                OnProperychanged("Surname");
            }
        }
    }

    public String Jmbg
    {
        get
        {
            return jmbg;
        }
        set
        {
            if (value != jmbg)
            {
                jmbg = value;
                OnProperychanged("Jmbg");
            }
        }
    }
}