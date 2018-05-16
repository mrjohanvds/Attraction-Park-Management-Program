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
    /// Logique d'interaction pour ZombilleniumAddPersonnel.xaml
    /// </summary>
    public partial class ZombilleniumAddPersonnel : Page
    {
        private List<string> nomAttraction;
        private List<string> pouvoirs;
        private TypeSexe sexe;
        private string fonction;
        private int matricule;
        private string nom;
        private string prenom;
        private int indexAttraction;

        public ZombilleniumAddPersonnel()
        {
            InitializeComponent();
            pouvoirs = new List<string>();
            nomAttraction = new List<string>();
            foreach (Attraction element in ZombilleniumMenu.Administration.Attractions)
                nomAttraction.Add(element.Nom);
            AttractionCB.ItemsSource = nomAttraction;
        }

        public void Click_Button_Validation(object sender, RoutedEventArgs e)
        {
            var radios = SexeSP.Children.OfType<RadioButton>();
            RadioButton checkedRadio = radios.FirstOrDefault(rb => rb.GroupName == "SexeRadioButton" && rb.IsChecked == true);
            sexe = (TypeSexe)Enum.Parse(typeof(TypeSexe), Convert.ToString(checkedRadio.Content).ToLower());
            fonction = FunctionTextBox.Text;
            matricule = Convert.ToInt32(MatriculeTextBox.Text);
            nom = NameTextBox.Text;
            prenom = FirstNameTextBox.Text;

            var radios1 = TypeSP.Children.OfType<RadioButton>();
            RadioButton checkedRadio1 = radios1.FirstOrDefault(rb => rb.GroupName == "TypeRadioButton" && rb.IsChecked == true);
            switch (checkedRadio1.Content)
            {
                case "Monstre": AjoutMonstre();
                    break;
                case "Demon": AjoutDemon();
                    break;
                case "Fantome": AjoutFantome();
                    break;
                case "Loup Garou": AjoutLoupGarou();
                    break;
                case "Sorcier": AjoutSorcier();
                    break;
                case "Vampire": AjoutVampire();
                    break;
                case "Zombie": AjoutZombie();
                    break;
            }
            
            ValidationLabel.Content = "Le membre a bien été ajouté à la base de donnée";
        }

        private void AjoutPouvoir_Button_Click(object sender, RoutedEventArgs e)
        {
            pouvoirs.Add(PouvoirsTB.Text);
            PouvoirsTB.Clear();
            string pouvoirsList = "La liste des pouvoirs : ";
            foreach (string element in pouvoirs)
            {
                pouvoirsList += element + ", ";
            }
            ListPouvoirLabel.Content = pouvoirsList;
        }

        #region Type Radio Button Event
        
        private void Sorcier_RadioButton_Checked(object sender, RoutedEventArgs e)
        {
            PouvoirsGrid.Visibility = Visibility.Visible;
            GradeGrid.Visibility = Visibility.Visible;
            ListPouvoirLabel.Visibility = Visibility.Visible;
        }
        private void Sorcier_RadioButton_Unchecked(object sender, RoutedEventArgs e)
        {
            PouvoirsGrid.Visibility = Visibility.Collapsed;
            GradeGrid.Visibility = Visibility.Collapsed;
            ListPouvoirLabel.Visibility = Visibility.Collapsed;
        }

        private void Demon_RadioButton_Checked(object sender, RoutedEventArgs e)
        {
            CagnotteGrid.Visibility = Visibility.Visible;
            AttractionGrid.Visibility = Visibility.Visible;
            ForceGrid.Visibility = Visibility.Visible;
        }
        private void Demon_RadioButton_Unchecked(object sender, RoutedEventArgs e)
        {
            CagnotteGrid.Visibility = Visibility.Collapsed;
            AttractionGrid.Visibility = Visibility.Collapsed;
            ForceGrid.Visibility = Visibility.Collapsed;
        }

        private void Monstre_RadioButton_Checked(object sender, RoutedEventArgs e)
        {
            CagnotteGrid.Visibility = Visibility.Visible;
            AttractionGrid.Visibility = Visibility.Visible;
        }
        private void Monstre_RadioButton_Unchecked(object sender, RoutedEventArgs e)
        {
            CagnotteGrid.Visibility = Visibility.Collapsed;
            AttractionGrid.Visibility = Visibility.Collapsed;
        }

        private void LoupGarou_RadioButton_Checked(object sender, RoutedEventArgs e)
        {
            CagnotteGrid.Visibility = Visibility.Visible;
            AttractionGrid.Visibility = Visibility.Visible;
            CruauteGrid.Visibility = Visibility.Visible;
        }
        private void LoupGarou_RadioButton_Unchecked(object sender, RoutedEventArgs e)
        {
            CagnotteGrid.Visibility = Visibility.Collapsed;
            AttractionGrid.Visibility = Visibility.Collapsed;
            CruauteGrid.Visibility = Visibility.Collapsed;
        }

        private void Vampire_RadioButton_Checked(object sender, RoutedEventArgs e)
        {
            CagnotteGrid.Visibility = Visibility.Visible;
            AttractionGrid.Visibility = Visibility.Visible;
            LuminositeGrid.Visibility = Visibility.Visible;
        }
        private void Vampire_RadioButton_Unchecked(object sender, RoutedEventArgs e)
        {
            CagnotteGrid.Visibility = Visibility.Collapsed;
            AttractionGrid.Visibility = Visibility.Collapsed;
            LuminositeGrid.Visibility = Visibility.Collapsed;
        }

        private void Zombie_RadioButton_Checked(object sender, RoutedEventArgs e)
        {
            CagnotteGrid.Visibility = Visibility.Visible;
            AttractionGrid.Visibility = Visibility.Visible;
            DecompositionGrid.Visibility = Visibility.Visible;
            TeintGrid.Visibility = Visibility.Visible;
        }
        private void Zombie_RadioButton_Unchecked(object sender, RoutedEventArgs e)
        {
            CagnotteGrid.Visibility = Visibility.Collapsed;
            AttractionGrid.Visibility = Visibility.Collapsed;
            DecompositionGrid.Visibility = Visibility.Collapsed;
            TeintGrid.Visibility = Visibility.Collapsed;
        }

        #endregion

        #region Methode D'ajout

        public void AjoutSorcier()
        {
            var radios = GradeSP.Children.OfType<RadioButton>();
            RadioButton checkedRadio = radios.FirstOrDefault(rb => rb.GroupName == "GradeRadioButton" && rb.IsChecked == true);
            Grade grade = (Grade)Enum.Parse(typeof(Grade), Convert.ToString(checkedRadio.Content).ToLower());
            ZombilleniumMenu.Administration.AjouterPersonnel(new Sorcier(pouvoirs, grade, fonction, matricule, nom, prenom, sexe));
        }

        public void AjoutDemon()
        {
            int cagnotte = Convert.ToInt32(CagnotteTB.Text);
            int force = Convert.ToInt32(ForceSlider.Value);
            ZombilleniumMenu.Administration.AjouterPersonnel(new Demon(force, ZombilleniumMenu.Administration.Attractions[indexAttraction], cagnotte, fonction, matricule, nom, prenom, sexe));
        }

        public void AjoutFantome()
        {
            int cagnotte = Convert.ToInt32(CagnotteTB.Text);
            ZombilleniumMenu.Administration.AjouterPersonnel(new Fantome(ZombilleniumMenu.Administration.Attractions[indexAttraction], cagnotte, fonction, matricule, nom, prenom, sexe));
        }

        public void AjoutLoupGarou()
        {
            int cagnotte = Convert.ToInt32(CagnotteTB.Text);
            double cruaute = Convert.ToDouble(CruauteSlider.Value);
            ZombilleniumMenu.Administration.AjouterPersonnel(new LoupGarou(cruaute, ZombilleniumMenu.Administration.Attractions[indexAttraction], cagnotte, fonction, matricule, nom, prenom, sexe));
        }

        public void AjoutVampire()
        {
            int cagnotte = Convert.ToInt32(CagnotteTB.Text);
            double luminosite = Convert.ToDouble(LuminositeSlider.Value);
            ZombilleniumMenu.Administration.AjouterPersonnel(new Vampire(luminosite, ZombilleniumMenu.Administration.Attractions[indexAttraction], cagnotte, fonction, matricule, nom, prenom, sexe));
        }

        public void AjoutZombie()
        {
            int cagnotte = Convert.ToInt32(CagnotteTB.Text);
            var radios = GradeSP.Children.OfType<RadioButton>();
            RadioButton checkedRadio = radios.FirstOrDefault(rb => rb.GroupName == "GradeRadioButton" && rb.IsChecked == true);
            CouleurZ teint = (CouleurZ)Enum.Parse(typeof(CouleurZ), Convert.ToString(checkedRadio.Content).ToLower());
            int decompostion = Convert.ToInt32(DecompositionSlider.Value);
            ZombilleniumMenu.Administration.AjouterPersonnel(new Zombie(decompostion, teint, ZombilleniumMenu.Administration.Attractions[indexAttraction], cagnotte, fonction, matricule, nom, prenom, sexe));
        }

        public void AjoutMonstre()
        {
            int cagnotte = Convert.ToInt32(CagnotteTB.Text);
            ZombilleniumMenu.Administration.AjouterPersonnel(new Monstre(ZombilleniumMenu.Administration.Attractions[indexAttraction], cagnotte, fonction, matricule, nom, prenom, sexe));
        }

        #endregion

        private void AttractionCB_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var comboBox = sender as ComboBox;
            string value = comboBox.SelectedItem as string;
            this.Title = value;
            indexAttraction = ZombilleniumMenu.Administration.ChercherIndexNomAttraction(value);
        }
    }
}
