using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.Model
{
    class FunctionalityDTO :  INotifyPropertyChanged
    {
        public DateTime datumIzvrsavanja;
        public int idPacijenta;
        public string vrstaFunkcionalnosti;
        public int id;



        public FunctionalityDTO(int idF,DateTime date, string vrsta)
        {
            this.datumIzvrsavanja = date;
            this.idPacijenta = id;
            this.vrstaFunkcionalnosti = vrsta;


        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
