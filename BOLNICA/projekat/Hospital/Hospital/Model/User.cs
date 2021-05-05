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

    public DateTime birthdayDate;

    public String username;
    public String password;

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

    public String TelephoneNumber
    {
        get
        {
            return telephoneNumber;
        }
        set
        {
            if (value != telephoneNumber)
            {
                telephoneNumber = value;
                OnProperychanged("TelephoneNumber");
            }
        }
    }

    public Gender Gender
    {
        get
        {
            return gender;
        }
        set
        {
            if (value != gender)
            {
                gender = value;
                OnProperychanged("Gender");
            }
        }
    }

    public DateTime BirthdayDate
    {
        get
        {
            return birthdayDate;
        }
        set
        {
            if (value != birthdayDate)
            {
                birthdayDate = value;
                OnProperychanged("BirthdayDate");
            }
        }
    }

    public String Username
    {
        get
        {
            return username;
        }
        set
        {
            if (value != username)
            {
                username = value;
                OnProperychanged("Username");
            }
        }
    }

    public String Password
    {
        get
        {
            return password;
        }
        set
        {
            if (value != password)
            {
                password = value;
                OnProperychanged("Password");
            }
        }
    }
}