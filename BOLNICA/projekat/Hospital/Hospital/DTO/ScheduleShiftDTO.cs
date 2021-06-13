using Hospital.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.DTO
{
   public class ScheduleShiftDTO : INotifyPropertyChanged
    {

        private DateTime date;
        private ShiftType type;
        private Boolean change;


        public ScheduleShiftDTO() { }

        public ScheduleShiftDTO(DateTime date, ShiftType type, bool change)
        {
            this.date = date;
            this.type = type;
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
                    OnPropertyChanged("Date");
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
                    OnPropertyChanged("Change");
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
                    OnPropertyChanged("Type");
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string name)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(name));
            }
        }
    }
}
