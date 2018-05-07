using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PFR
{
    class Fantome : Monstre
    {
        public Fantome(Attraction uneAffectation, int uneCagnotte, string uneFonction, int unMatricule, string unNom, string unPrenom, TypeSexe unSexe) : base(uneAffectation, uneCagnotte, uneFonction, unMatricule, unNom, unPrenom, unSexe)
        {
        }

        /*-----------------------------------------------------------METHODES---------------------------------------------------------------*/

        public override string ToString()
        {
            return base.ToString() + "Ce monstre est un fantome. \n";
        }
    }

}
