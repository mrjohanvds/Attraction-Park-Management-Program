using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PFR
{
    class Monstre : Personnel
    {
        private Attraction affectation;
        private int cagnotte;

        public Monstre (Attraction uneAffectation, int uneCagnotte, string uneFonction, int unMatricule, string unNom, string unPrenom, TypeSexe unSexe) : base(uneFonction, unMatricule, unNom, unPrenom, unSexe)
        {
            affectation = uneAffectation;
            cagnotte = uneCagnotte;
        }

        #region Accesseur

        public int Cagnotte
        {
            get { return cagnotte; }
        }

        public Attraction Affectation
        {
            set { affectation = value; }
        }

        #endregion

        /*-----------------------------------------------------------METHODES---------------------------------------------------------------*/

        public override string EcrireFichiercsv()
        {
            string m = "";
            if (affectation != null)
            {
                m += affectation.Identifiant;
            }
            return base.EcrireFichiercsv() + ";" + cagnotte + ";" + m; 
        }

        public override string ToString()
        {
            if (affectation == null)
                return base.ToString() + "Ce monstre n'est affecte a aucune attraction. Sa cagnotte est de " + cagnotte + ". \n";
            return base.ToString() + "Ce monstre est affecte a l'attraction " + affectation.Nom + ". Sa cagnotte est de " + cagnotte + ". \n";
        }

        public void ChangementAffectation(Attraction uneAttraction)
        {
            affectation = uneAttraction;
        }

        public void ChangementCagnotte(int ajoutOuRetrait)//ajoutOuRetrait peut être positif ou négatif (trouver un meilleur nom de variable ?)
        {
            cagnotte += ajoutOuRetrait;

        }


    }
}
