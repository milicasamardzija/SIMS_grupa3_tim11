using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Collections.ObjectModel;

namespace Hospital
{
    /// <summary>
    /// Interaction logic for IzmeniNalogPacijenta.xaml
    /// </summary>
    public partial class IzmeniNalogPacijenta : Window { 

       public ObservableCollection<Patient> listPatient;

        public IzmeniNalogPacijenta(ObservableCollection<Patient> list, Patient selectedPatient)
        {
          /*  InitializeComponent();
            listPatient = list;
            imeText.SelectedText = selectedPatient.name;
            prezimeText.SelectedText = selectedPatient.surname;
            jmbgText.SelectedText = selectedPatient.jmbg;
            osiguraniktText.SelectedText=selectedPatient.


            */
      
        } 
    }
}
