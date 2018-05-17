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
            equipe = new List<Monstre>();


        }
        public void Click_Button_Validation(object sender, RoutedEventArgs e)
        {
            var radios = BesoinSpécifique.Children.OfType<RadioButton>();
            RadioButton checkedRadio = radios.FirstOrDefault(rb => rb.GroupName == "BesoinSpécifiqueButton" && rb.IsChecked == true);
            besoinSpecifique = bool.Parse(checkedRadio.Content.ToString());

            var radios1 = Maintenance.Children.OfType<RadioButton>();
            RadioButton checkedRadio1 = radios.FirstOrDefault(rb => rb.GroupName == "Maintenance" && rb.IsChecked == true);
            maintenance = bool.Parse(checkedRadio.Content.ToString());

            var radios2 = Ouvert.Children.OfType<RadioButton>();
            RadioButton checkedRadio2 = radios.FirstOrDefault(rb => rb.GroupName == "Ouvert" && rb.IsChecked == true);
            ouvert = bool.Parse(checkedRadio.Content.ToString());

            identifiant = Convert.ToInt32(indentifianttextbox.Text);
            nbMinMonstre = Convert.ToInt32(nombredemontre.Text);

            typeDeBesoin = Typedebesoin.Text;
            nom = Nom.Text;
            natureMaintenance = NatureDeMaintenance.Text;

            var radios4 = TypeSP.Children.OfType<RadioButton>();
            RadioButton checkedRadio4 = radios4.FirstOrDefault(rb => rb.GroupName == "TypeRadioButton" && rb.IsChecked == true);
            switch (checkedRadio4.Content)
            {

                case "DarkRide":
                    AjoutDarkRide();
                    break;
                case "RollerCoaster":
                    AjoutRollerCoaster();
                    break;
                case "Boutique":
                    AjoutBoutique();
                    break;
                case "Spectacle":
                    AjoutSpectacle();
                    break;

            }

        }
        private void DarkRide_RadioButton_Checked(object sender, RoutedEventArgs e)
        {
            DarkrideSP.Visibility = Visibility.Visible;

        }
        private void DarkRide_RadioButton_Unchecked(object sender, RoutedEventArgs e)
        {
            DarkrideSP.Visibility = Visibility.Collapsed;
        }
        private void Boutique_RadioButton_Checked(object sender, RoutedEventArgs e)
        {
            BoutiqueSP.Visibility = Visibility.Visible;
        }
        private void Boutique_RadioButton_Unchecked(object sender, RoutedEventArgs e)
        {
            BoutiqueSP.Visibility = Visibility.Collapsed;
        }
        private void RollerCoaster_RadioButton_Checked(object sender, RoutedEventArgs e)
        {
            RollerCoasterSP.Visibility = Visibility.Visible;
        }
        private void RollerCoaster_RadioButton_Unchecked(object sender, RoutedEventArgs e)
        {
            RollerCoasterSP.Visibility = Visibility.Collapsed;
        }
        private void Spectacle_RadioButton_Checked(object sender, RoutedEventArgs e)
        {
            SpectacleSP.Visibility = Visibility.Visible;
        }
        private void Spectacle_RadioButton_Unchecked(object sender, RoutedEventArgs e)
        {
            SpectacleSP.Visibility = Visibility.Collapsed;
        }

        public void AjoutDarkRide ()
        {

        }
        public void AjoutRollerCoaster()
        {

        }
        public void AjoutBoutique()
        {

        }
        public void AjoutSpectacle()
        {

        }

        private void Accueil_Click(object sender, RoutedEventArgs e)
        {
            ZombilleniumMenu zombilleniumMenu = new ZombilleniumMenu();
            this.NavigationService.Navigate(zombilleniumMenu);
        }

    }
}
