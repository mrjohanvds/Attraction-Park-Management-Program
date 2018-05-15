using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PFR
{
    class Zombie : Monstre
    {
        private int degreDecomposition;
        private CouleurZ teint;

        public Zombie (int unDegreDecomposition, CouleurZ unTeint, Attraction uneAffectation, int uneCagnotte, string uneFonction, int unMatricule, string unNom, string unPrenom, TypeSexe unSexe) : base(uneAffectation, uneCagnotte, uneFonction, unMatricule, unNom, unPrenom, unSexe)
        {
            degreDecomposition = unDegreDecomposition;
            teint = unTeint;
        }

        #region accesseurs

        public int DegreDecomposition
        {
            get { return degreDecomposition; }
            set { degreDecomposition = value; }
        }

        #endregion

        /*-----------------------------------------------------------METHODES---------------------------------------------------------------*/

        public override string EcrireFichiercsv()
        {
            return base.EcrireFichiercsv() + ";" + teint + ";" + degreDecomposition;
        }

        public override string ToString()
        {
            return base.ToString() + "Le degre de decomposition de ce zombie est de " + degreDecomposition + ". Le teint de ce zombie est " + teint + ". \n";
        }
    }
}
