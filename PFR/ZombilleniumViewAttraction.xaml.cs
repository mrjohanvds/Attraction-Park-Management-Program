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
                if (attraction is Attraction)
                {
                    attractions.Add(attraction as Attraction);
                }
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
    }
}
