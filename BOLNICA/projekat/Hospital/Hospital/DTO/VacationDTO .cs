using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.DTO
{
    public class VacationDTO : INotifyPropertyChanged
    {

        private int freeDays;
        private DateTime startDay;
        private DateTime endDay;


        public VacationDTO() { }

        public VacationDTO(DateTime start, DateTime end)
        {

            this.startDay = start;
            this.endDay = end;

        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string name)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(name));
            }
        }

        public DateTime StartDay
        {
            get
            {
                return startDay;
            }
            set
            {
                if (value != startDay)
                {
                    startDay = value;
                    OnPropertyChanged("StartDay");
                }
            }
        }
        public DateTime EndDay
        {
            get
            {
                return endDay;
            }
            set
            {
                if (value != endDay)
                {
                    endDay = value;
                    OnPropertyChanged("EndDay");
                }
            }
        }
    }
}

