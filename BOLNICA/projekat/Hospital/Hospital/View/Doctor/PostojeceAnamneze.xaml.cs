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
using System.IO;

namespace Hospital
{
    /// <summary>
    /// Interaction logic for PostojeceAnamneze.xaml
    /// </summary>
    public partial class PostojeceAnamneze : Window
    {
        public ObservableCollection<Anamnesis> AnamnesisList
        {
            get;
            set;
        }

        public PostojeceAnamneze()
        {
            InitializeComponent();
            this.DataContext = this;
            AnamnesisList = loadJ();
        }

        public ObservableCollection<Anamnesis> loadJ()
        {
            AnamnesisFileStorage storageAnamnesis = new AnamnesisFileStorage(@"./../../../../Hospital/files/anamnesis.json");
            ObservableCollection<Anamnesis> allAnamnesis = new ObservableCollection<Anamnesis>(storageAnamnesis.GetAll());
            ObservableCollection<Anamnesis> returnAnamnesis = new ObservableCollection<Anamnesis>();
            foreach(Anamnesis anamnesis in allAnamnesis)
            {
                returnAnamnesis.Add(anamnesis);
            }
            return returnAnamnesis;
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
