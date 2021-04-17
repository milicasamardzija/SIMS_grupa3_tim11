// File:    Recipe.cs
// Author:  Milica
// Created: četvrtak, 25. mart 2021. 17:11:24
// Purpose: Definition of Class Recipe

using System;
using System.ComponentModel;

public class Recipe
{
    // public String name;
    // public String idRecepie;
    // public DateTime date;
    public int idRecipe;
    public String name;
    public String nameSurname;
    public String dateBirthPatient;
    public String idHealthCard;
    public DateTime date;
    public String medicalRecordId;
    public int idDoc;
    public int idMedicine;
    public String quantity;
    public String diagnosis;
    public String opis;
    public DateTime beginning;
    public DateTime end;
    public int number;

    public Recipe(int id, String n, String s, String dateB, String idH, DateTime d, String mr, int idd, int idm, String q, String di, String op, DateTime b, DateTime e, int num)
    {
        idRecipe = id;
        name = n;
        nameSurname = s;
        dateBirthPatient = dateB;
        idHealthCard = idH;
        date = d;
        medicalRecordId = mr;
        idDoc = idd;
        idMedicine = idm;
        quantity = q;
        diagnosis = di;
        opis = op;
        beginning = b;
        end = e;
        number = num;
    }

    public event PropertyChangedEventHandler PropertyChanged;

    protected virtual void OnPropertyChanged(string name)
    {
        if (PropertyChanged != null)
        {
            PropertyChanged(this, new PropertyChangedEventArgs(name));
        }
    }

    public int IdRecipe
    {
        get
        {
            return idRecipe;
        }
        set
        {
            if(value != idRecipe)
            {
                idRecipe = value;
                OnPropertyChanged("IdRecipe");
            }
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
                OnPropertyChanged("Name");
            }
        }
    }
    public String NameSurname
    {
        get
        {
            return nameSurname;
        }
        set
        {
            if (value != nameSurname)
            {
                nameSurname = value;
                OnPropertyChanged("NameSurname");
            }
        }
    }
    public String DateBirthPatient
    {
        get
        {
            return dateBirthPatient;
        }
        set
        {
            if (value != dateBirthPatient)
            {
                dateBirthPatient = value;
                OnPropertyChanged("DateBirthPatient");
            }
        }
    }
    public String IdHealthCard
    {
        get
        {
            return idHealthCard;
        }
        set
        {
            if (value != idHealthCard)
            {
                idHealthCard = value;
                OnPropertyChanged("IdHealthCard");
            }
        }
    }
    public DateTime Date
    {
        get
        {
            return date;
        }
        set
        {
            if (value != date)
            {
                date = value;
                OnPropertyChanged("Date");
            }
        }
    }
    public String MedicalRecordId
    {
        get
        {
            return medicalRecordId;
        }
        set
        {
            if (value != medicalRecordId)
            {
                medicalRecordId = value;
                OnPropertyChanged("MedicalRecordId");
            }
        }
    }
    public int IdDoc
    {
        get
        {
            return idDoc;
        }
        set
        {
            if (value != idDoc)
            {
                idDoc = value;
                OnPropertyChanged("IdDoc");
            }
        }
    }
    public int IdMedicine
    {
        get
        {
            return idMedicine;
        }
        set
        {
            if (value != idMedicine)
            {
                idMedicine = value;
                OnPropertyChanged("IdMedicine");
            }
        }
    }
    public String Quantity
    {
        get
        {
            return quantity;
        }
        set
        {
            if (value != quantity)
            {
                quantity = value;
                OnPropertyChanged("Quantity");
            }
        }
    }
    public String Diagnosis
    {
        get
        {
            return diagnosis;
        }
        set
        {
            if (value != diagnosis)
            {
                diagnosis = value;
                OnPropertyChanged("Diagnosis");
            }
        }
    }
    public String Opis
    {
        get
        {
            return opis;
        }
        set
        {
            if (value != opis)
            {
                opis = value;
                OnPropertyChanged("Opis");
            }
        }
    }
    public DateTime Beginning
    {
        get
        {
            return beginning;
        }
        set
        {
            if (value != beginning)
            {
                beginning = value;
                OnPropertyChanged("Beginning");
            }
        }
    }
    public DateTime End
    {
        get
        {
            return end;
        }
        set
        {
            if (value != end)
            {
                end = value;
                OnPropertyChanged("End");
            }
        }
    }
    public int Number
    {
        get
        {
            return number;
        }
        set
        {
            if (value != number)
            {
                number = value;
                OnPropertyChanged("Number");
            }
        }
    }
}