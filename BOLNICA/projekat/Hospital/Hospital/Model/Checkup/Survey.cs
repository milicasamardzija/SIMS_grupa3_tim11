using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.Model
{
    class Survey : Entity,INotifyPropertyChanged
    {
       
        public string comment;
        public int mark;
        public string drname;
        public int idApp;




        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string name)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(name));
            }
        }

        public Survey() { }

        public Survey(int id, string komentarisano, int ocenjeno, string lekar, int idA) : base(id)
        {
           
            this.comment = komentarisano;
            this.mark = ocenjeno;
            this.drname = lekar;
            this.idApp = idA;
        }

        public Survey(int id, string komentarisano, int ocenjeno, string lekar) : base(id)
        {
           
            this.comment = komentarisano;
            this.mark = ocenjeno;
            this.drname = lekar;

        }



        public string Comment
        {
            get
            {
                return comment;
            }
            set
            {
                if (value != comment)
                {
                    comment = value;
                    OnPropertyChanged("Komentar");
                }
            }
        }

        public int Mark
        {
            get
            {
                return mark;
            }
            set
            {
                if (value != mark)
                {
                    mark = value;
                    OnPropertyChanged("Ocena");
                }
            }
        }

        public int IdApp
        {
            get
            {
                return idApp;
            }
            set
            {
                if (value != idApp)
                {
                    idApp = value;
                    OnPropertyChanged("Ocena");
                }
            }
        }






        public String Drname
        {
            get
            {
                return drname;
            }
            set
            {
                if (value != drname)
                {
                    drname = value;
                    OnPropertyChanged("Doktor");
                }
            }
        }
    }
}
