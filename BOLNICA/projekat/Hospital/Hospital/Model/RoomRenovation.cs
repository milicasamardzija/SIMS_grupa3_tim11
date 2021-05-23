﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.Model
{
    public class RoomRenovation : Entity, INotifyPropertyChanged
    {
        private DateTime dateBegin;
        private DateTime dateEnd;
        private String description;
        private int idRenovation;
        public RoomRenovation(int idR,int id, DateTime begin, DateTime end, String descript) : base(id)
        {
            dateBegin = begin;
            dateEnd = end.AddHours(23);
            dateEnd.AddMinutes(59);
            description = descript;
            idRenovation = idR;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnProperychanged(string name)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(name));
            }
        }

        public int IdRenovation
        {
            get
            {
                return idRenovation;
            }
            set
            {
                if (value != idRenovation)
                {
                    idRenovation = value;
                    OnProperychanged("IdRenovation");
                }
            }
        }
        public DateTime DateBegin
        {
            get
            {
                return dateBegin;
            }
            set
            {
                if (value != dateBegin)
                {
                    dateBegin = value;
                    OnProperychanged("DateBegin");
                }
            }
        }

        public DateTime DateEnd
        {
            get
            {
                return dateEnd;
            }
            set
            {
                if (value != dateEnd)
                {
                    dateEnd = value;
                    OnProperychanged("DateEnd");
                }
            }
        }

        public String Description
        {
            get
            {
                return description;
            }
            set
            {
                if (value != description)
                {
                    description = value;
                    OnProperychanged("Description");
                }
            }
        }

    }
}
