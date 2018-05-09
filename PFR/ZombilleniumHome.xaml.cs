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

namespace PFR
{
    /// <summary>
    /// Logique d'interaction pour ZombilleniumHome.xaml
    /// </summary>
    public partial class ZombilleniumHome : Page
    {

        public ZombilleniumHome()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            ZombilleniumMenu zombilleniumMenu = new ZombilleniumMenu();
            NavigationService.Navigate(zombilleniumMenu);
        }
    }
}
