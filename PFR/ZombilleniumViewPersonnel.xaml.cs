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

        public ZombilleniumViewPersonnel()
        {
            InitializeComponent();

        }

        private void DataGrid_Loaded(object sender, RoutedEventArgs e)
        {
            List<Monstre> monstres = new List<Monstre> ();
            foreach (Personnel lambda in ZombilleniumMenu.Administration.ToutLePersonnel)
            {
                if (lambda is Monstre)
                    {
                     monstres.Add (lambda as Monstre);
                    }

            }
            var grid = sender as DataGrid;
            grid.ItemsSource = monstres;
        }
    }
}
