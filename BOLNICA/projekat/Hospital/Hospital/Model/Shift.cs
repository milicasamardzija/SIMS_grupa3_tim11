﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.Model
{
    public class Shift 
    {
      
        private ShiftType type;
        private ShiftType controlType;
        private DateTime lastUpdated;
        private List<ScheduleShift> scheduledShifts;


        public Shift() { }


        public Shift(ShiftType type, ShiftType control, DateTime lastUpdate, List<ScheduleShift> shift ) {
         
            this.type = type;
            this.lastUpdated = lastUpdate;
            this.scheduledShifts = shift;
            
        }

        public DateTime LastUpdated
        {
            get
            {
                return lastUpdated;
            }
            set
            {
                if (value != lastUpdated)
                {
                    lastUpdated = value;
                   
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
        public ShiftType ControlType
        {
            get
            {
                return controlType;
            }
            set
            {
                if (value != controlType)
                {
                    controlType = value;

                }
            }
        }

        public List<ScheduleShift> ScheduledShifts {
            get
            {
                return scheduledShifts;
            }
            set
            {
                if (value != scheduledShifts)
                {
                    scheduledShifts = value;

                }
            }
        }

       
    }
}
