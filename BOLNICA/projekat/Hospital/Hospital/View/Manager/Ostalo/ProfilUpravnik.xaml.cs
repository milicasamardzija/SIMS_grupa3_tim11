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
using System.Windows.Navigation;
using System.Windows.Shapes;
using Hospital.Model;
using Hospital.View.Manager.FeedbackM;
using Hospital.View.Manager.WIzard;

namespace Hospital.View.Manager.Ostalo
{
    public partial class ProfilUpravnik : UserControl
    {
        public static Boolean isToolTipVisible = true;
        private ManagerView view;
        private ManagerNote notes = new ManagerNote();
        private List<ManagerNote> note = new List<ManagerNote>();
        private Frame managerFrame = new Frame();
        public ProfilUpravnik(ManagerView managerView,Frame managerFrame)
        {
            InitializeComponent();
            view = managerView;
            Frame.NavigationService.Navigate(new Informacije());
            this.managerFrame = managerFrame;
        }

        private void ukljuci(object sender, RoutedEventArgs e)
        {
            isToolTipVisible = true;
        }

        private void iskljuci(object sender, RoutedEventArgs e)
        {
            MessageBoxResult rsltMessageBox = MessageBox.Show("Da li ste sigurni da zelite da iskljucite tooltip-ove?", "Tooltips",
                MessageBoxButton.YesNoCancel, MessageBoxImage.Warning);
            switch (rsltMessageBox)
            {
                case MessageBoxResult.Yes:
                    isToolTipVisible = false;
                    break;
                case MessageBoxResult.No:
                    break;
                case MessageBoxResult.Cancel:
                    break;
            }
        }

        private void odjava(object sender, RoutedEventArgs e)
        {
            view.Close();
        }

        private void wizard(object sender, RoutedEventArgs e)
        {
            Wizard w = new Wizard();
            w.Show();
        }

        private void feedback(object sender, RoutedEventArgs e)
        {
            managerFrame.NavigationService.Navigate(new FeedbackGood());
        }
    }
}
