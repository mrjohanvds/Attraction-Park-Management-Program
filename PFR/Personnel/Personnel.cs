using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PFR
{
    public class Personnel : IComparable<Personnel> 
    {
        private string fonction;
        private int matricule;
        private string nom;
        private string prenom;
        private TypeSexe sexe;

        public Personnel (string uneFonction, int unMatricule, string unNom, string unPrenom, TypeSexe unSexe)
        {
            fonction = uneFonction;
            matricule = unMatricule;
            nom = unNom;
            prenom = unPrenom;
            sexe = unSexe;
        }

        #region Accesseur
        
        public string Nom
        {
            get { return nom; }
        }
        public string Prenom
        {
            get { return prenom; }
        }
        public int Matricule
        {
            get { return matricule; }
        }
        public TypeSexe Sexe
        {
            get { return sexe; }
        }
        public string Fonction
        {
            get { return fonction; }
            set { fonction = value; }
        }

        #endregion

        /*-----------------------------------------------------------METHODES---------------------------------------------------------------*/

        public virtual string EcrireFichiercsv()
        {
            return base.ToString().Split('.')[1] + ';' + matricule + ';' + nom + ';' + prenom + ';' + sexe + ';' + fonction;
        }

        public override string ToString()
        {
            return "Ce membre du personnel est " + fonction + " posséde le matricule : " + matricule + " et s'appelle " + prenom + " " + nom + ". C'est un " + sexe + ". \n";
        }

        public void ChangementFonction(string uneFonction)
        {
            fonction = uneFonction;
        }

        public int CompareTo(Personnel other)
        {
            return matricule.CompareTo(other.Matricule);
        }
    }
}
