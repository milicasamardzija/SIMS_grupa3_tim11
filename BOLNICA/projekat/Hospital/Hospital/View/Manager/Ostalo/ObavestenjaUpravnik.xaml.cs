using Hospital.Model;
using Hospital.MVVM.ModelView;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Hospital
{
    public partial class ObavestenjaUpravnik : UserControl
    {
        public ObavestenjaUpravnik(ModelViewObavestenja obavestenja)
        {
            InitializeComponent();
            this.DataContext = obavestenja;
        }
    }
}
