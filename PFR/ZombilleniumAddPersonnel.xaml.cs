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
        private TypeSexe sexe;
        public ZombilleniumAddPersonnel()
        {
            InitializeComponent();
        }

        public void Click_Button_Validation(object sender, RoutedEventArgs e)
        {
            Personnel personnel = new Personnel(FunctionTextBox.Text, Convert.ToInt32(MatriculeTextBox.Text), NameTextBox.Text, FirstNameTextBox.Text, sexe);
            ZombilleniumMenu.Administration.AjouterPersonnel(personnel);
            ValidationLabel.Content = "Le membre a bien été ajouté à la base de donnée";
        }

        private void Femelle_RadioButton_Checked(object sender, RoutedEventArgs e)
        {
            sexe = TypeSexe.femelle;
        }

        private void Male_RadioButton_Checked(object sender, RoutedEventArgs e)
        {
            sexe = TypeSexe.male;
        }

        private void Autre_RadioButton_Checked(object sender, RoutedEventArgs e)
        {
            sexe = TypeSexe.autre;
        }
    }
}
