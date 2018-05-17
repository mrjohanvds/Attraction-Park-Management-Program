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
using System.IO;

namespace PFR
{
    /// <summary>
    /// Logique d'interaction pour ZombilleniumSaveFile.xaml
    /// </summary>
    public partial class ZombilleniumSaveFile : Page
    {
        public ZombilleniumSaveFile()
        {
            InitializeComponent();
        }

        private void PersonnelButton_Click(object sender, RoutedEventArgs e)
        {
            ZombilleniumMenu.Administration.AfficherPersonnel(Convert.ToString(NomFichierTB.Text) + ".csv");
        }

        private void Accueil_Click(object sender, RoutedEventArgs e)
        {
            ZombilleniumMenu zombilleniumMenu = new ZombilleniumMenu();
            this.NavigationService.Navigate(zombilleniumMenu);
        }

    }
}
