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
    /// <summary>
    /// Interaction logic for BlogGlavni.xaml
    /// </summary>
    public partial class BlogGlavni : Page
    {

        private String ob;

       public String Ob
        {
            get
            {
                return ob;
            }
            set
            {
                ob = obavestenjaText.Text;
            }

        }
        public BlogGlavni()
        {
            InitializeComponent();
            ob = obavestenjaText.Text;
        }



    }
}
