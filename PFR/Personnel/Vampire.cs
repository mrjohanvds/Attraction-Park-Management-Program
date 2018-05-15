using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PFR
{
    class Vampire : Monstre
    {
        private double indiceLuminosite;

        public Vampire( double unIndiceLuminosite, Attraction uneAffectation, int uneCagnotte, string uneFonction, int unMatricule, string unNom, string unPrenom, TypeSexe unSexe) : base(uneAffectation, uneCagnotte, uneFonction, unMatricule, unNom, unPrenom, unSexe)
        {
            indiceLuminosite = unIndiceLuminosite;
        }

        #region accessseurs

        public double IndiceLuminosite
        {
            get { return indiceLuminosite; }
            set { indiceLuminosite = value; }
        }

        #endregion

        /*-----------------------------------------------------------METHODES---------------------------------------------------------------*/

        public override string EcrireFichiercsv()
        {
            return base.EcrireFichiercsv() + ";" + indiceLuminosite;
        }
        public override string ToString()
        {
            return base.ToString() + "L'indice de luminosite de ce vampire est de " + indiceLuminosite + ". \n";
        }
    }
}
