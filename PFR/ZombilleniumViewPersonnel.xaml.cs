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
    /// Logique d'interactions pour ZombilleniumViewPersonnel.xaml
    /// </summary>
    public partial class ZombilleniumViewPersonnel : Page
    {
        private List<Personnel> toutLePersonnel;
        private List<Sorcier> sorciers;
        private List<Demon> demons;
        private List<Zombie> zombies;
        private List<Monstre> monstres;
        private List<Vampire> vampires;
        private List<Fantome> fantomes;
        private List<LoupGarou> loupGarous;

        public ZombilleniumViewPersonnel()
        {
            InitializeComponent();
            typeCB.SelectedIndex = 0;
            sorciers = new List<Sorcier>();
            demons = new List<Demon>();
            zombies = new List<Zombie>();
            monstres = new List<Monstre>();
            vampires = new List<Vampire>();
            fantomes = new List<Fantome>();
            loupGarous = new List<LoupGarou>();

            toutLePersonnel = ZombilleniumMenu.Administration.ToutLePersonnel;

            foreach(Personnel personnel in toutLePersonnel)
            {
                if (personnel is Sorcier)
                {
                    sorciers.Add(personnel as Sorcier);
                }
                if (personnel is Demon)
                {
                    demons.Add(personnel as Demon);
                }
                if (personnel is Zombie)
                {
                    zombies.Add(personnel as Zombie);
                }
                if (personnel is Monstre)
                {
                    monstres.Add(personnel as Monstre);
                }
                if (personnel is Vampire)
                {
                    vampires.Add(personnel as Vampire);
                }
                if (personnel is Fantome)
                {
                    fantomes.Add(personnel as Fantome);
                }
                if (personnel is LoupGarou)
                {
                    loupGarous.Add(personnel as LoupGarou);
                }
            }
        }
        
        #region Loaded Events

        private void ToutPersoDG_Loaded(object sender, RoutedEventArgs e)
        {
            var grid = sender as DataGrid;
            grid.ItemsSource = toutLePersonnel;
        }

        private void MonstreDG_Loaded(object sender, RoutedEventArgs e)
        {
            var grid = sender as DataGrid;
            grid.ItemsSource = monstres;
        }

        private void SorcierDG_Loaded(object sender, RoutedEventArgs e)
        { 
            var grid = sender as DataGrid;
            grid.ItemsSource = sorciers;
        }

        private void VampireDG_Loaded(object sender, RoutedEventArgs e)
        {
            var grid = sender as DataGrid;
            grid.ItemsSource = vampires;
        }

        private void ZombieDG_Loaded(object sender, RoutedEventArgs e)
        {
            var grid = sender as DataGrid;
            grid.ItemsSource = zombies;
        }

        private void DemonDG_Loaded(object sender, RoutedEventArgs e)
        {
            var grid = sender as DataGrid;
            grid.ItemsSource = demons;
        }

        private void FantomeDG_Loaded(object sender, RoutedEventArgs e)
        {
            var grid = sender as DataGrid;
            grid.ItemsSource = fantomes;
        }

        private void LoupGarouDG_Loaded(object sender, RoutedEventArgs e)
        {
            var grid = sender as DataGrid;
            grid.ItemsSource = loupGarous;
        }

        #endregion

        private void TypeCB_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var comboBox = sender as ComboBox;
            ChangeDisplay(comboBox.SelectedIndex);
        }

        private void AllHidden()
        {
            ToutPersoDG.Visibility = Visibility.Hidden;
            MonstreDG.Visibility = Visibility.Hidden;
            SorcierDG.Visibility = Visibility.Hidden;
            DemonDG.Visibility = Visibility.Hidden;
            FantomeDG.Visibility = Visibility.Hidden;
            LoupGarouDG.Visibility = Visibility.Hidden;
            VampireDG.Visibility = Visibility.Hidden;
            ZombieDG.Visibility = Visibility.Hidden;
        }

        private void ChangeDisplay(int selection)
        {

            AllHidden();
            switch (selection)
            {
                case 0:
                    {
                        AllHidden(); ToutPersoDG.Visibility = Visibility.Visible;
                    }break;
                case 1:
                    AllHidden(); SorcierDG.Visibility = Visibility.Visible;
                    break;
                case 2:
                    AllHidden(); MonstreDG.Visibility = Visibility.Visible;
                    break;
                case 3:
                    AllHidden(); DemonDG.Visibility = Visibility.Visible;
                    break;
                case 4:
                    AllHidden(); FantomeDG.Visibility = Visibility.Visible;
                    break;
                case 5:
                    AllHidden(); LoupGarouDG.Visibility = Visibility.Visible;
                    break;
                case 6:
                    AllHidden(); VampireDG.Visibility = Visibility.Visible;
                    break;
                case 7:
                    AllHidden(); ZombieDG.Visibility = Visibility.Visible;
                    break;
            }
        }

        private void ValidationButton_Click(object sender, RoutedEventArgs e)
        {
            ZombilleniumViewPersonnel zombilleniumViewPersonnel = new ZombilleniumViewPersonnel();
            this.NavigationService.Navigate(zombilleniumViewPersonnel);
        }

        private void Accueil_Click(object sender, RoutedEventArgs e)
        {
            ZombilleniumMenu zombilleniumMenu = new ZombilleniumMenu();
            this.NavigationService.Navigate(zombilleniumMenu);
        }
    }
}
