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
    /// Logique d'interaction pour ZombilleniumViewPersonnel.xaml
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
            toutLePersonnel = new List<Personnel>();
            sorciers = new List<Sorcier>();
            demons = new List<Demon>();
            zombies = new List<Zombie>();
            monstres = new List<Monstre>();
            vampires = new List<Vampire>();
            fantomes = new List<Fantome>();
            loupGarous = new List<LoupGarou>();

            List<Personnel> listtemp = ZombilleniumMenu.Administration.ToutLePersonnel;

            for (int i = 0; i< ZombilleniumMenu.Administration.ToutLePersonnel.Count; i++)
            {
                try
                {
                    foreach (Sorcier element in listtemp)
                    {
                        toutLePersonnel.Add(element);
                        sorciers.Add(element);
                        listtemp.Remove(element);
                    }
                }
                catch { }

                try
                {
                    foreach (Demon element in listtemp)
                    {
                        toutLePersonnel.Add(element);
                        monstres.Add(element);
                        demons.Add(element);
                        listtemp.Remove(element);
                    }
                }
                catch { }

                try
                {
                    foreach (Fantome element in listtemp)
                    {
                        toutLePersonnel.Add(element);
                        monstres.Add(element);
                        fantomes.Add(element);
                        listtemp.Remove(element);
                    }
                }
                catch { }

                try
                {
                    foreach (LoupGarou element in listtemp)
                    {
                        toutLePersonnel.Add(element);
                        monstres.Add(element);
                        loupGarous.Add(element);
                        listtemp.Remove(element);
                    }
                }
                catch { }

                try
                {
                    foreach (Vampire element in listtemp)
                    {
                        toutLePersonnel.Add(element);
                        monstres.Add(element);
                        vampires.Add(element);
                        listtemp.Remove(element);
                    }
                }
                catch { }

                try
                {
                    foreach (Zombie element in listtemp)
                    {
                        toutLePersonnel.Add(element);
                        monstres.Add(element);
                        zombies.Add(element);
                        listtemp.Remove(element);
                    }
                }
                catch { }
            }
        }

        private void ToutPersoDG_Loaded(object sender, RoutedEventArgs e)
        {
            //var toutLePersonnel = ZombilleniumMenu.Administration.ToutLePersonnel;
            var grid = sender as DataGrid;
            grid.ItemsSource = toutLePersonnel;
        }

        private void MonstreDG_Loaded(object sender, RoutedEventArgs e)
        {
            //var monstres = ZombilleniumMenu.Administration.ToutLePersonnel.Cast<Monstre>();
            var grid = sender as DataGrid;
            grid.ItemsSource = monstres;
        }

        private void SorcierDG_Loaded(object sender, RoutedEventArgs e)
        { 
            //var sorciers = ZombilleniumMenu.Administration.ToutLePersonnel.Cast<Sorcier>();
            var grid = sender as DataGrid;
            grid.ItemsSource = sorciers;
        }

        private void VampireDG_Loaded(object sender, RoutedEventArgs e)
        {
            //var vampires = ZombilleniumMenu.Administration.ToutLePersonnel.Cast<Vampire>();
            var grid = sender as DataGrid;
            grid.ItemsSource = vampires;
        }

        private void ZombieDG_Loaded(object sender, RoutedEventArgs e)
        {
            //var zombies = ZombilleniumMenu.Administration.ToutLePersonnel.Cast<Zombie>();
            var grid = sender as DataGrid;
            grid.ItemsSource = zombies;
        }

        private void DemonDG_Loaded(object sender, RoutedEventArgs e)
        {
            //var demons = ZombilleniumMenu.Administration.ToutLePersonnel.Cast<Demon>();
            var grid = sender as DataGrid;
            grid.ItemsSource = demons;
        }

        private void FantomeDG_Loaded(object sender, RoutedEventArgs e)
        {
            //var fantomes = ZombilleniumMenu.Administration.ToutLePersonnel.Cast<Fantome>();
            var grid = sender as DataGrid;
            grid.ItemsSource = fantomes;
        }

        private void LoupGarouDG_Loaded(object sender, RoutedEventArgs e)
        {
            var grid = sender as DataGrid;
            grid.ItemsSource = loupGarous;
        }


        private void typeCB_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var comboBox = sender as ComboBox;
            AllHidden();
            switch (comboBox.SelectedIndex)
            {
                case 0: AllHidden(); ToutPersoDG.Visibility = Visibility.Visible;
                    break;
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
    }
}
