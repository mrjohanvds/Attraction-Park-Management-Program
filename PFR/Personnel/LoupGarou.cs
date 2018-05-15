using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PFR
{
    class LoupGarou : Monstre
    {
        private double indiceCruaute;

        public LoupGarou( double unIndiceCruaute, Attraction uneAffectation, int uneCagnotte, string uneFonction, int unMatricule, string unNom, string unPrenom, TypeSexe unSexe) : base(uneAffectation, uneCagnotte, uneFonction, unMatricule, unNom, unPrenom, unSexe)
        {
            indiceCruaute = unIndiceCruaute;
        }

        #region accesseurs

        public double IndiceCruaute
        {
            get { return indiceCruaute; }
            set { indiceCruaute = value; }
        }

        #endregion

        /*-----------------------------------------------------------METHODES---------------------------------------------------------------*/

        public override string EcrireFichiercsv()
        {
            return base.EcrireFichiercsv() + ";" + indiceCruaute;
        }

        public override string ToString()
        {
            return base.ToString() + "Ce LoupGarou a un indice de cruaute de " + indiceCruaute + ". \n";
        }
    }
}
