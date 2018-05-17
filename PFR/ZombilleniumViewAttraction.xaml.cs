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

namespace PFR
{
    /// <summary>
    /// Logique d'interaction pour ZombilleniumViewAttraction.xaml
    /// </summary>
    public partial class ZombilleniumViewAttraction : Page
    {
        private List<Attraction> attractions;
        private List<Boutique> boutiques;
        private List<DarkRide> darkRides;
        private List<RollerCoaster> rollerCoasters;
        private List<Spectacle> spectacles;

        public ZombilleniumViewAttraction()
        {
            InitializeComponent();
            typeCB.SelectedIndex = 0;
            attractions = new List<Attraction>();
            boutiques = new List<Boutique>();
            darkRides = new List<DarkRide>();
            rollerCoasters = new List<RollerCoaster>();
            spectacles = new List<Spectacle>();
           

            attractions = ZombilleniumMenu.Administration.Attractions;

            foreach (Attraction attraction in attractions)
            {
                if (attraction is Boutique)
                {
                    boutiques.Add(attraction as Boutique);
                }
                if (attraction is DarkRide)
                {
                    darkRides.Add(attraction as DarkRide);
                }
                if (attraction is RollerCoaster)
                {
                    rollerCoasters.Add(attraction as RollerCoaster);
                }
                if (attraction is Spectacle)
                {
                    spectacles.Add(attraction as Spectacle);
                }
                
            }
        }

        
        private void ToutAttractionDG_Loaded(object sender, RoutedEventArgs e)
        {
            var grid = sender as DataGrid;
            grid.ItemsSource = attractions;
        }

        private void BoutiqueDG_Loaded(object sender, RoutedEventArgs e)
        {
            var grid = sender as DataGrid;
            grid.ItemsSource = boutiques;
        }

        private void DarkRideDG_Loaded(object sender, RoutedEventArgs e)
        {
            var grid = sender as DataGrid;
            grid.ItemsSource = darkRides;
        }

        private void RollerCoasterDG_Loaded(object sender, RoutedEventArgs e)
        {
            var grid = sender as DataGrid;
            grid.ItemsSource = rollerCoasters;
        }

        private void SpectacleDG_Loaded(object sender, RoutedEventArgs e)
        {
            var grid = sender as DataGrid;
            grid.ItemsSource = spectacles;
        }

        private void TypeCB_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var comboBox = sender as ComboBox;
            AllHidden();
            switch (comboBox.SelectedIndex)
            {
                case 0:
                    AllHidden(); ToutAttractionDG.Visibility = Visibility.Visible;
                    break;
                case 1:
                    AllHidden(); BoutiqueDG.Visibility = Visibility.Visible;
                    break;
                case 2:
                    AllHidden(); DarkRideDG.Visibility = Visibility.Visible;
                    break;
                case 3:
                    AllHidden(); RollerCoasterDG.Visibility = Visibility.Visible;
                    break;
                case 4:
                    AllHidden(); SpectacleDG.Visibility = Visibility.Visible;
                    break;
            }
        }

        private void AllHidden()
        {
            
            ToutAttractionDG.Visibility = Visibility.Hidden;
            BoutiqueDG.Visibility = Visibility.Hidden;
            DarkRideDG.Visibility = Visibility.Hidden;
            RollerCoasterDG.Visibility = Visibility.Hidden;
            SpectacleDG.Visibility = Visibility.Hidden;
        }

        private void ValidationButton_Click(object sender, RoutedEventArgs e)
        {
            //ZombilleniumMenu.Administration.Attractions[ToutAttractionDG.SelectedIndex].Maintenance = ToutAttractionDG.SelectedItems.

            ZombilleniumViewAttraction zombilleniumViewAttraction = new ZombilleniumViewAttraction();
            this.NavigationService.Navigate(zombilleniumViewAttraction);
        }

        private void Accueil_Click(object sender, RoutedEventArgs e)
        {
            ZombilleniumMenu zombilleniumMenu = new ZombilleniumMenu();
            this.NavigationService.Navigate(zombilleniumMenu);
        }
    }
}
