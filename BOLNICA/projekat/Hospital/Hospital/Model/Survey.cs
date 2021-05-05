using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.Model
{
    class Survey: INotifyPropertyChanged
    {
        public int idSurvey;
        public string comment;
        public int mark;
        public string drname;




        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string name)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(name));
            }
        }

        public Survey() { }

        public Survey(int id, string komentarisano, int ocenjeno, string lekar)
        {
            this.idSurvey = id;
            this.comment = komentarisano;
            this.mark = ocenjeno;
            this.drname = lekar;
        }

        public int IdSurvey
        {
            get
            {
                return idSurvey;
            }
            set
            {
                if (value != idSurvey)
                {
                    idSurvey = value;
                    OnPropertyChanged("IdAnketa");
                }
            }
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
