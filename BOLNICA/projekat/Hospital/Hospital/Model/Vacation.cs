using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital
{
    public class Vacation
    {

        private int freeDays;
        private DateTime startDay;
        private DateTime endDay;


         public Vacation() { }

        public Vacation(DateTime start, DateTime end)
        {

            this.startDay = start;
            this.endDay = end;

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

                }
            }
        }
        public int FreeDays
        {
            get
            {
                return freeDays;
            }
            set
            {
                if (value != freeDays)
                {
                    freeDays = value;

                }
            }
        }
    }
}
