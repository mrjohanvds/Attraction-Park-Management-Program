using System;
using System.Collections.Generic;
using System.Text;

namespace PFR
{
    public class DarkRide : Attraction
    {
        private TimeSpan duree;
        private bool vehicule;

        public DarkRide(TimeSpan duree, bool vehicule, bool besoinSpecifique, TimeSpan dureeMaintenance, List<Monstre> equipe, int identifiant, bool maintenance, string natureMaintenance, int nbMinMonstre, string nom, bool ouvert, string typeDeBesoin): base(besoinSpecifique, dureeMaintenance, equipe, identifiant, maintenance, natureMaintenance, nbMinMonstre, nom, ouvert, typeDeBesoin)
        {
            this.duree = duree;
            this.vehicule = vehicule;
        }

        /*-----------------------------------------------------------METHODES---------------------------------------------------------------*/

        public override string EcrireFichiercsv()
        {
            return base.EcrireFichiercsv() + ";" + duree + ";" + vehicule ;
        }        

        public override string ToString()
        {
            string phrase = base.ToString() + "Ce DarkRide est d'une durée de " + duree.Days + " minutes.";
            if (vehicule)
                return phrase + " et fonctionne avec des véhicules.\n";
            else
                return phrase + " et n'a pas besoin de véhicule.\n";
        }
    }
}
