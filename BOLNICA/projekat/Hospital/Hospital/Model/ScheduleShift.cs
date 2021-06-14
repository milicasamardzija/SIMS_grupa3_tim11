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
      


        public ScheduleShift() { }

        public ScheduleShift(DateTime date, ShiftType type)
        {
            this.date = date;
            this.type = type;
            

        }

        public ScheduleShift(ShiftType type, DateTime date)
        {
            this.type = type;
            this.date = date;
           
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
