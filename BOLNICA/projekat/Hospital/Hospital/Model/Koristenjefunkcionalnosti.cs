using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.Model
{
    class Koristenjefunkcionalnosti
    {
        public DateTime datumIzvrsavanja;
        public int idPacijenta;
        public string vrstaFunkcionalnosti;



        public Koristenjefunkcionalnosti(DateTime date, int id, string vrsta)
        {

            this.datumIzvrsavanja = date;
            this.idPacijenta = id;
            this.vrstaFunkcionalnosti = vrsta;


        }
    }
}
