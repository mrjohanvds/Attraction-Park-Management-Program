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
    /// Logique d'interaction pour ZombilleniumMenu.xaml
    /// </summary>
    public partial class ZombilleniumMenu : Page
    {
        static private Administration administration;
        public ZombilleniumMenu()
        {
            InitializeComponent();
            administration = new Administration();
        }

        public static Administration Administration { get => administration; set => administration = value; }

        private void Button_Click_Afficher_Personnel(object sender, RoutedEventArgs e)
        {
            ZombilleniumViewPersonnel zombilleniumViewPersonnel = new ZombilleniumViewPersonnel();
            this.NavigationService.Navigate(zombilleniumViewPersonnel);
        }
        private void Button_Click_Ajouter_Personnel(object sender, RoutedEventArgs e)
        {
            ZombilleniumAddPersonnel zombilleniumAddPersonnel = new ZombilleniumAddPersonnel();
            this.NavigationService.Navigate(zombilleniumAddPersonnel);
        }

        private void Button_Click_Afficher_Attraction(object sender, RoutedEventArgs e)
        {
            ZombilleniumViewAttraction zombilleniumViewAttraction = new ZombilleniumViewAttraction();
            this.NavigationService.Navigate(zombilleniumViewAttraction);
        }
    }
}
