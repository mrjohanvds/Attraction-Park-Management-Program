using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace PFR
{
    class RollerCoaster : Attraction
    {
        private int ageMinimum;
        private TypeCategorie categorie;
        private double tailleMinimum;

        public RollerCoaster(int ageMinimum, TypeCategorie categorie, double tailleMinimum, bool besoinSpecifique, TimeSpan dureeMaintenance, List<Monstre> equipe, int identifiant, bool maintenance, string natureMaintenance, int nbMinMonstre, string nom, bool ouvert, string typeDeBesoin):base ( besoinSpecifique,  dureeMaintenance,  equipe,  identifiant,  maintenance,  natureMaintenance,  nbMinMonstre,  nom,  ouvert,  typeDeBesoin)
        {
            this.ageMinimum = ageMinimum;
            this.categorie = categorie;
            this.tailleMinimum = tailleMinimum;
        }

        public int AgeMinimum { get => ageMinimum; set => ageMinimum = value; }
        public double TailleMinimum { get => tailleMinimum; set => tailleMinimum = value; }
        public TypeCategorie Categorie { get => categorie; set => categorie = value; }

        /*-----------------------------------------------------------METHODES---------------------------------------------------------------*/

        public override string EcrireFichiercsv()
        {
            return base.EcrireFichiercsv() + ";" + categorie + ";" + ageMinimum + ";" + tailleMinimum ;
        }

        public override string ToString()
        {
            return base.ToString() + "Ce RollerCoaster est de type " + categorie + ". L'age minimum requis est " + ageMinimum + " ans. La taille minimum requise est " + tailleMinimum + "m.\n"; 
        }
    }
}
