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
    /// <summary>
    /// Interaction logic for ObrisiObavestenjeBlog.xaml
    /// </summary>
    public partial class ObrisiObavestenjeBlog : Window
    {
        public int index;
        public Notice notice;
        public ObservableCollection<Notice> listNotice { get; set; }
        public ObrisiObavestenjeBlog(ObservableCollection<Notice> list, Notice selected, int i)
        {
            InitializeComponent();
            listNotice = list;
            notice = selected;
            index = i;
        }

        private void da(object sender, RoutedEventArgs e)
        {
            NoticeFileStorage nfs = new NoticeFileStorage(@"./../../../../Hospital/files/notices.json");
            nfs.Delete(notice);
            listNotice.RemoveAt(index);
            this.Close();
        }
        private void ne(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
