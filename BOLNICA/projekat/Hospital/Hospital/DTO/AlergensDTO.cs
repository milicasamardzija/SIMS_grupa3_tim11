using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.DTO
{
    public class AlergensDTO
    {
        private String name;
        private String code;
        private int id;

        public event PropertyChangedEventHandler PropertyChanged;

        public AlergensDTO() { }

        public AlergensDTO(String name, String code)
        {
            this.name = name;
            this.code = code;
            this.id= 0;
        }

        protected virtual void OnPropertyChanged(string name)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(name));
            }
        }

        public String Name
        {
            get
            {
                return name;
            }
            set
            {
                if (value != name)
                {
                    name = value;
                    OnPropertyChanged("Name");
                }
            }
        }

        public String Code
        {
            get
            {
                return code;
            }
            set
            {
                if (value != code)
                {
                    code = value;
                    OnPropertyChanged("Code");
                }
            }
        }
        public int Id
        {
            get
            {
                return id;
            }
            set
            {
                if (value != id)
                {
                    id = value;
                    OnPropertyChanged("Id");
                }
            }
        }
    }
}
