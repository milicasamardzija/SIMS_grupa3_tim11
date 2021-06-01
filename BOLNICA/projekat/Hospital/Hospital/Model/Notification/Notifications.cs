using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.Model
{
    public class Notifications : Entity
    {

        private String title;
        private String content;
        private DateTime date;
        private int idPatient;
        private String person;

        public Notifications() { }

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

                }
            }
        }
    }
 
}
