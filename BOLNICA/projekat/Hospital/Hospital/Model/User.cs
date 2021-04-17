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
   
   public String name { get; set; }
   public String surname { get; set; }
    public String telephoneNumber { get; set; }
    public String jmbg { get; set; }
    public Gender gender { get; set; }

    public DateTime birthdayDate;
    //public String birthdate { get; set; }
    public String username { get; set; }
    public String password { get; set; }

    public Adress adress { get; set; }

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