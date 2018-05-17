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
        private List<Attraction> attractions;
        private List<Boutique> boutiques;
        private List<DarkRide> darkRides;
        private List<RollerCoaster> rollerCoasters;
        private List<Spectacle> spectacles;

        private List<Personnel> toutLePersonnel;
        private List<Sorcier> sorciers;
        private List<Demon> demons;
        private List<Zombie> zombies;
        private List<Monstre> monstres;
        private List<Vampire> vampires;
        private List<Fantome> fantomes;
        private List<LoupGarou> loupGarous;

        public ZombilleniumSaveFile()
        {
            InitializeComponent();

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

            sorciers = new List<Sorcier>();
            demons = new List<Demon>();
            zombies = new List<Zombie>();
            monstres = new List<Monstre>();
            vampires = new List<Vampire>();
            fantomes = new List<Fantome>();
            loupGarous = new List<LoupGarou>();

            toutLePersonnel = ZombilleniumMenu.Administration.ToutLePersonnel;

            foreach (Personnel personnel in toutLePersonnel)
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

            ToutAttractionsCB.IsChecked = true;
            ToutPersoCB.IsChecked = true;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string texte = "";

            if (Convert.ToBoolean(ToutPersoCB.IsChecked))
                foreach (Personnel element in toutLePersonnel)
                    texte += element.EcrireFichiercsv() + '\n';
            else
            {

                if (Convert.ToBoolean(SorcierCB.IsChecked))
                    foreach (Sorcier element in sorciers)
                        texte += element.EcrireFichiercsv() + '\n';
                if (Convert.ToBoolean(TousMonstresCB.IsChecked))
                    foreach(Monstre element in monstres)
                        texte += element.EcrireFichiercsv() + '\n';
                else
                {
                    if (Convert.ToBoolean(MonstreCB.IsChecked))
                    {
                        foreach (Monstre element in monstres)
                        {
                            if (element is Demon || element is Fantome || element is LoupGarou || element is Vampire || element is Zombie) ;
                            else
                                texte += element.EcrireFichiercsv() + '\n';
                        }
                    }
                    if (Convert.ToBoolean(DemonCB.IsChecked))
                        foreach (Demon element in demons)
                            texte += element.EcrireFichiercsv() + '\n';
                    if (Convert.ToBoolean(FantomeCB.IsChecked))
                        foreach (Fantome element in fantomes)
                            texte += element.EcrireFichiercsv() + '\n';
                    if (Convert.ToBoolean(LoupGarouCB.IsChecked))
                        foreach (LoupGarou element in loupGarous)
                            texte += element.EcrireFichiercsv() + '\n';
                    if (Convert.ToBoolean(VampireCB.IsChecked))
                        foreach (Vampire element in vampires)
                            texte += element.EcrireFichiercsv() + '\n';
                    if (Convert.ToBoolean(ZombieCB.IsChecked))
                        foreach (Zombie element in zombies)
                            texte += element.EcrireFichiercsv() + '\n';
                }
            }
            
            if (Convert.ToBoolean(ToutAttractionsCB.IsChecked))
                foreach (Attraction element in attractions)
                    texte += element.EcrireFichiercsv() + '\n';
            else
            {
                if (Convert.ToBoolean(BoutiqueCB.IsChecked))
                    foreach (Boutique element in boutiques)
                        texte += element.EcrireFichiercsv() + '\n';
                if (Convert.ToBoolean(DarkRideCB.IsChecked))
                    foreach (DarkRide element in darkRides)
                        texte += element.EcrireFichiercsv() + '\n';
                if (Convert.ToBoolean(RollerCoasterCB.IsChecked))
                    foreach (RollerCoaster element in rollerCoasters)
                        texte += element.EcrireFichiercsv() + '\n';
                if (Convert.ToBoolean(SpectacleCB.IsChecked))
                    foreach (Spectacle element in spectacles)
                        texte += element.EcrireFichiercsv() + '\n';
            }

            ZombilleniumMenu.Administration.EcritureFichier(NomFichierTB.Text + ".csv", texte);

            ValidationLabel.Content = NomFichierTB.Text + ".csv a bien été créé dans le dossier debug !";
        }
        
        private void Accueil_Click(object sender, RoutedEventArgs e)
        {
            ZombilleniumMenu zombilleniumMenu = new ZombilleniumMenu();
            this.NavigationService.Navigate(zombilleniumMenu);
        }

        #region Check/Unchecked Events

        private void ToutPersoCB_Checked(object sender, RoutedEventArgs e)
        {
            SorcierCB.IsChecked = true;
            TousMonstresCB.IsChecked = true;
        }

        private void SorcierCB_Unchecked(object sender, RoutedEventArgs e)
        {
            ToutPersoCB.IsChecked = false;
        }

        private void TousMonstresCB_Unchecked(object sender, RoutedEventArgs e)
        {
            ToutPersoCB.IsChecked = false;
        }

        private void TousMonstresCB_Checked(object sender, RoutedEventArgs e)
        {
            MonstreCB.IsChecked = true;
            DemonCB.IsChecked = true;
            FantomeCB.IsChecked = true;
            LoupGarouCB.IsChecked = true;
            VampireCB.IsChecked = true;
            ZombieCB.IsChecked = true;
        }

        private void MonstreCB_Unchecked(object sender, RoutedEventArgs e)
        {
            TousMonstresCB.IsChecked = false;
        }

        private void DemonCB_Unchecked(object sender, RoutedEventArgs e)
        {
            TousMonstresCB.IsChecked = false;
        }

        private void FantomeCB_Unchecked(object sender, RoutedEventArgs e)
        {
            TousMonstresCB.IsChecked = false;
        }

        private void LoupGarouCB_Unchecked(object sender, RoutedEventArgs e)
        {
            TousMonstresCB.IsChecked = false;
        }

        private void VampireCB_Unchecked(object sender, RoutedEventArgs e)
        {
            TousMonstresCB.IsChecked = false;
        }

        private void ZombieCB_Unchecked(object sender, RoutedEventArgs e)
        {
            TousMonstresCB.IsChecked = false;
        }

        private void ToutAttractionsCB_Checked(object sender, RoutedEventArgs e)
        {
            BoutiqueCB.IsChecked = true;
            DarkRideCB.IsChecked = true;
            RollerCoasterCB.IsChecked = true;
            SpectacleCB.IsChecked = true;
        }

        private void BoutiqueCB_Unchecked(object sender, RoutedEventArgs e)
        {
            ToutAttractionsCB.IsChecked = false;
        }

        private void DarkRideCB_Unchecked(object sender, RoutedEventArgs e)
        {
            ToutAttractionsCB.IsChecked = false;
        }

        private void RollerCoasterCB_Unchecked(object sender, RoutedEventArgs e)
        {
            ToutAttractionsCB.IsChecked = false;
        }

        private void SpectacleCB_Unchecked(object sender, RoutedEventArgs e)
        {
            ToutAttractionsCB.IsChecked = false;
        }

        private void ToutUncheckCB_Checked(object sender, RoutedEventArgs e)
        {
            SorcierCB.IsChecked = false;
            MonstreCB.IsChecked = false;
            DemonCB.IsChecked = false;
            FantomeCB.IsChecked = false;
            LoupGarouCB.IsChecked = false;
            VampireCB.IsChecked = false;
            ZombieCB.IsChecked = false;
            BoutiqueCB.IsChecked = false;
            DarkRideCB.IsChecked = false;
            RollerCoasterCB.IsChecked = false;
            SpectacleCB.IsChecked = false;
        }

        #endregion

    }
}
