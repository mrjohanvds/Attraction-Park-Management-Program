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
            var radios = durée.Children.OfType<RadioButton>();
            RadioButton checkedRadio = radios.FirstOrDefault(rb => rb.GroupName == "GradeRadioButton" && rb.IsChecked == true);
            var radios1 = voiture.Children.OfType<RadioButton>(); 
            RadioButton checkedRadio1 = radios1.FirstOrDefault(rb => rb.GroupName == "GradeRadioButton" && rb.IsChecked == true);
           bool  Vehicule = bool.Parse(checkedRadio1.Content.ToString());

            ZombilleniumMenu.Administration.AjouterAttraction(new DarkRide(dureeMaintenance,Vehicule,besoinSpecifique,dureeMaintenance,equipe,identifiant,maintenance,natureMaintenance,nbMinMonstre,nom,ouvert,typeDeBesoin));
        }
        public void AjoutRollerCoaster()
        {
            int ageMinimum = Convert.ToInt32(AgeMin.Text);
            var radios = RollerCoasterSP.Children.OfType<RadioButton>();
            RadioButton checkedRadio = radios.FirstOrDefault(rb => rb.GroupName == "GradeRadioButton" && rb.IsChecked == true);
            TypeCategorie categorie = (TypeCategorie)Enum.Parse(typeof(TypeCategorie), Convert.ToString(checkedRadio.Content).ToLower());
            int tailleMinimum = Convert.ToInt32(taillemin.Text);
            ZombilleniumMenu.Administration.AjouterAttraction(new RollerCoaster(ageMinimum, categorie, tailleMinimum, besoinSpecifique, dureeMaintenance, equipe, identifiant, maintenance, natureMaintenance, nbMinMonstre, nom, ouvert, typeDeBesoin));
    }
        public void AjoutBoutique()
        {
            var radios = BoutiqueSP.Children.OfType<RadioButton>();
            RadioButton checkedRadio = radios.FirstOrDefault(rb => rb.GroupName == "GradeRadioButton" && rb.IsChecked == true);
            Type boutique = (Type)Enum.Parse(typeof(Type), Convert.ToString(checkedRadio.Content).ToLower());
            ZombilleniumMenu.Administration.AjouterAttraction(new Boutique(boutique, besoinSpecifique, dureeMaintenance, equipe, identifiant, maintenance, natureMaintenance, nbMinMonstre, nom, ouvert, typeDeBesoin));
        }
        public void AjoutSpectacle()
        {
            int nombredePlace = Convert.ToInt32(Nombredeplace.Text);
            string nomsalle = NomSalle.Text;
            string horaire = Horaire.Text;
            ZombilleniumMenu.Administration.AjouterAttraction(new Spectacle(horaire, nombredePlace, nomsalle, besoinSpecifique, dureeMaintenance, equipe, identifiant, maintenance, natureMaintenance, nbMinMonstre, nom, ouvert, typeDeBesoin));
        }

        private void Accueil_Click(object sender, RoutedEventArgs e)
        {
            ZombilleniumMenu zombilleniumMenu = new ZombilleniumMenu();
            this.NavigationService.Navigate(zombilleniumMenu);
        }

    }
}
