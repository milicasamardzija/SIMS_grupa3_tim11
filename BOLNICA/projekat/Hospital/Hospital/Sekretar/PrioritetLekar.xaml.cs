using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace Hospital.Sekretar
{
   
    public partial class PrioritetLekar : Window
    {
       public  ObservableCollection<Patient> listPatient
        {
            get; set;
        }
       public  ObservableCollection<Doctor> listDoctors
        {
            get; set;
        }
        public PrioritetLekar(ObservableCollection<Patient> list)
        {
            InitializeComponent();
            this.DataContext = this;
            listPatient = list;
            listDoctors = loadJson();

        }

        private ObservableCollection<Doctor> loadJson()
        {
            DoctorFileStorage dfs = new DoctorFileStorage();
             ObservableCollection<Doctor> doctors = new ObservableCollection<Doctor>(dfs.GetAll());
            return doctors;

        }
    }
}
