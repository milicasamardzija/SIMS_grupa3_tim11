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
            AnamnesisFileStorage ast = new AnamnesisFileStorage(@"./../../../../Hospital/files/anamnesis.json");
            ObservableCollection<Anamnesis> aa = new ObservableCollection<Anamnesis>(ast.GetAll());
            ObservableCollection<Anamnesis> ret = new ObservableCollection<Anamnesis>();
            foreach(Anamnesis a in aa)
            {
                ret.Add(a);
            }
            return ret;
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
