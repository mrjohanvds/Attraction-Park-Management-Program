using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PFR
{
    class Sorcier : Personnel
    {
        private List<string> pouvoirs;
        private Grade tatouage;

        public Sorcier(List<string> desPouvoirs, Grade unTatouage, string uneFonction, int unMatricule, string unNom, string unPrenom, TypeSexe unSexe) : base(uneFonction, unMatricule, unNom, unPrenom, unSexe)
        {
            pouvoirs = desPouvoirs;
            tatouage = unTatouage;
        }

        /*-----------------------------------------------------------METHODES---------------------------------------------------------------*/

        public override string EcrireFichiercsv()
        {
            string pouvoir = "";
            for (int i = 0; i < pouvoirs.Count; i++)
            {
                pouvoir += pouvoirs[i];
                if (i != pouvoirs.Count - 1) pouvoir += "-";
            }
            return base.EcrireFichiercsv() + ";" + tatouage + ";" + pouvoir;
        }

        public override string ToString()
        {
            string phrase = base.ToString() + "C'est un sorcier de grade " + tatouage + ". Ses pouvoirs sont :";

            foreach (string element in pouvoirs)
                phrase += " / " + element;
            return phrase + ". \n";
        }
    }
}
