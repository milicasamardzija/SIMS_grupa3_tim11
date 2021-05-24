using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.Prikaz
{
    public class ZauzetiTermini : INotifyPropertyChanged
    {
        private DateTime day;
        private String time;
        private double duration;

        public event PropertyChangedEventHandler PropertyChanged;
        public ZauzetiTermini() { }
        public ZauzetiTermini(DateTime date, String t, double d) {
            this.day = date;
            this.time = t;
            this.duration=d;
        }

        protected virtual void OnProperychanged(string name)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(name));
            }
        }
        public DateTime Day
        {
            get
            {
                return day;
            }
            set
            {
                if (value != day)
                {
                     day= value;
                    OnProperychanged("Day");
                }
            }
        }
        public String Time     
        {
            get
            {
                return time;
            }
            set
            {
                if (value != time)
                {
                    time = value;
                    OnProperychanged("Time");
                }
            }
        }

        public double Duration
        {
            get
            {
                return duration;
            }
            set
            {
                if (value != duration)
                {
                    duration = value;
                    OnProperychanged("Duration");
                }
            }
        }

    }

   
}
