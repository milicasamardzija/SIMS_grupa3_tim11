// File:    Adress.cs
// Author:  Milica
// Created: Sunday, April 4, 2021 7:22:55 PM
// Purpose: Definition of Class Adress

using System;

public class Adress
{
    public Adress(string street, int streetNumber, City city, Country country)
    {
        this.street = street;
        this.streetNumber = streetNumber;
        this.city = city;
        this.country = country;
    }

    public String street{ get; set; }
   public int streetNumber { get; set; }
    public City city { get; set; }
    public Country country { get; set; }


}