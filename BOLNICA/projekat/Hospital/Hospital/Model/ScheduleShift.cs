using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.Model
{
  public  class ScheduleShift
    {

        private DateTime date;
        private ShiftType type;
        private Boolean change;


        public ScheduleShift() { }

        public ScheduleShift(DateTime date, ShiftType type, bool change)
        {
            this.date = date;
            this.type = type;
            this.change = change;

        }

        public ScheduleShift(ShiftType type, DateTime date, bool change)
        {
            this.type = type;
            this.date = date;
            this.change = change;
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

        public Boolean Change
        {
            get
            {
                return change;
            }
            set
            {
                if (value != change)
                {
                    change = value;
                   
                }
            }
        }
        public ShiftType Type
        {
            get
            {
                return type;
            }
            set
            {
                if (value != type)
                {
                    type = value;
                   
                }
            }
        }

       
      
    }
}
