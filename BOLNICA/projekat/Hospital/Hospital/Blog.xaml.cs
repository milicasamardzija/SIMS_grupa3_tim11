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

namespace Hospital
{
  
    public partial class Blog : Page
    {
        public Blog()
        {
            InitializeComponent();
            textBlog.SelectedText = loadJason();
        }
  
    public String loadJason()
    {
        NoticeFileStorage pfs = new NoticeFileStorage();
        List<Notice> rs = new List<Notice>(pfs.GetAll());
        String ret = rs[0].notice;
        return ret;

    }
    private void sacuvajIzmene(object sender, RoutedEventArgs e)
    {

        NoticeFileStorage nfs = new NoticeFileStorage();
        List<Notice> rs = new List<Notice>(nfs.GetAll());

        Notice stara = rs[0];
        String novi = textBlog.Text;
        Notice nova = new Notice(novi);


        nfs.save(nova);
        rs.Remove(stara);

    
    }
        private void odustani(object sender, RoutedEventArgs e)
        {
            
        }
    }
}
