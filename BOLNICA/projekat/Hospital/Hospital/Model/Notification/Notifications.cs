﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.Model
{
   public class Notifications  : Entity, INotifyPropertyChanged
    {
    
        private String title;
        private String content;
        private DateTime date;
        private int idPatient;
        private String person;

        public Notifications() {}

        public Notifications(String t, String c, DateTime d, int id, String p) : base(id)
        {
            this.title = t;
            this.content = c;
            this.date = d;
            this.Id = id;
            this.person = p;
            this.idPatient = -1;
        }
        public Notifications(String t, String c, DateTime d, int id, String p, int idPatient) : base(id)
        {
            this.title = t;
            this.content = c;
            this.date = d;
            this.idPatient = idPatient;
            this.person = p;
            this.Id = id;
        }
         public int IdPatient
          {
              get
              {
                  return idPatient;
              }
              set
              {
                  if (value != idPatient)
                  {
                    idPatient = value;
                      OnPropertyChanged("IdPatient");
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


        public String Content
        {
            get
            {
                return content;
            }
            set
            {
                if (value != content)
                {
                    content = value;
                    OnPropertyChanged("Content");
                }
            }
        }
        public String Person
        {
            get
            {
                return person;
            }
            set
            {
                if (value != person)
                {
                    person = value;
                    OnPropertyChanged("Person");
                }
            }
        }
        public String Title
        {
            get
            {
                return title;
            }
            set
            {
                if (value != title)
                {
                    title = value;
                    OnPropertyChanged("Title");
                }
            }
        }

        private void OnPropertyChanged(string v)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(v));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
