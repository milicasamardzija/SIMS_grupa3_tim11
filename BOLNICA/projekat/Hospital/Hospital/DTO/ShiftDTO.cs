using Hospital.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.DTO
{
    public class ShiftDTO : INotifyPropertyChanged
    { 
        private ShiftType typeToday;
        private ShiftType controlType;
        private DateTime lastUpdated;
        private List<ScheduleShift> scheduledShifts;
     

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string name)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(name));
            }
        }
        public ShiftDTO() { }


        public ShiftDTO(ShiftType type, ShiftType control, DateTime lastUpdate, List<ScheduleShift> shift) 
        {
           
            this.typeToday = type;
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
                    OnPropertyChanged("LastUpdate");
                }
            }
        }
        public ShiftType TypeToday
        {
            get
            {
                return typeToday;
            }
            set
            {
                if (value != typeToday)
                {
                    typeToday = value;
                    OnPropertyChanged("TypeToday");
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
                    OnPropertyChanged("ControlType");
                }
            }
        }

        public List<ScheduleShift> ScheduledShifts
        {
            get
            {
                return scheduledShifts;
            }
            set
            {
                if (value != scheduledShifts)
                {
                    scheduledShifts = value;
                    OnPropertyChanged("ScheduledShifts");
                }
            }
        }

 
    }
}
