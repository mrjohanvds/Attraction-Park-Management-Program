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
    /// Logique d'interaction pour ZombilleniumAddAttraction.xaml
    /// </summary>
    public partial class ZombilleniumAddAttraction : Page
    {
        private bool besoinSpecifique;
        private TimeSpan dureeMaintenance;
        private List<Monstre> equipe;
        private int identifiant;
        private bool maintenance;
        private string natureMaintenance;
        private int nbMinMonstre;
        private string nom;
        private bool ouvert;
        private string typeDeBesoin;

        public ZombilleniumAddAttraction()
        {
            InitializeComponent();

        }
        private void DarkRide_RadioButton_Checked(object sender, RoutedEventArgs e)
        {


        }
        private void DarkRide_RadioButton_Unchecked(object sender, RoutedEventArgs e)
        {
           
        }
        private void Boutique_RadioButton_Checked(object sender, RoutedEventArgs e)
        {

        }
        private void Boutique_RadioButton_Unchecked(object sender, RoutedEventArgs e)
        {

        }
        private void RollerCoaster_RadioButton_Checked(object sender, RoutedEventArgs e)
        {

        }
        private void RollerCoaster_RadioButton_Unchecked(object sender, RoutedEventArgs e)
        {

        }
        private void Spectacle_RadioButton_Checked(object sender, RoutedEventArgs e)
        {

        }
        private void Spectacle_RadioButton_Unchecked(object sender, RoutedEventArgs e)
        {

        }

    }
}
