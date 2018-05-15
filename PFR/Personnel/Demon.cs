using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PFR
{
    class Demon : Monstre
    {
        private int force;

        public Demon( int uneForce, Attraction uneAffectation, int uneCagnotte, string uneFonction, int unMatricule, string unNom, string unPrenom, TypeSexe unSexe) : base(uneAffectation, uneCagnotte, uneFonction, unMatricule, unNom, unPrenom, unSexe)
        {
            Force = uneForce;
        }

        #region accesseurs

        public int Force { get => force; set => force = value; }

        #endregion

        /*-----------------------------------------------------------METHODES---------------------------------------------------------------*/

        public override string EcrireFichiercsv()
        {
            return base.EcrireFichiercsv() + ";" + force;

        }

        public override string ToString()
        {
            return base.ToString() + "Ce monstre est un démon avec une force de " + Force + ". \n";
        }
    }
}
