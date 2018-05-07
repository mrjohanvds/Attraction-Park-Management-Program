using System;
using System.Collections.Generic;
using System.Text;

namespace PFR
{
    class Spectacle :Attraction
    {
        private List<DateTime> horaire;
        private int nombrePlace;
        private string nomSalle;

        public Spectacle(List<DateTime> horaire, int nombrePlace, string nomSalle, bool besoinSpecifique, TimeSpan dureeMaintenance, List<Monstre> equipe, int identifiant, bool maintenance, string natureMaintenance, int nbMinMonstre, string nom, bool ouvert, string typeDeBesoin) : base(besoinSpecifique, dureeMaintenance, equipe, identifiant, maintenance, natureMaintenance, nbMinMonstre, nom, ouvert, typeDeBesoin)
        {
            this.horaire = horaire;
            this.nombrePlace = nombrePlace;
            this.nomSalle = nomSalle;
        }

        /*-----------------------------------------------------------METHODES---------------------------------------------------------------*/

        public override string EcrireFichiercsv()
        {
            string horaires = "";
            for (int i = 0; i < horaire.Count; i++)
            {
                horaires += horaire[i].TimeOfDay;
                if (i != horaire.Count - 1) horaires += " ";
            }
            return base.EcrireFichiercsv() + ";" + nomSalle + ";" + nombrePlace + ";" + horaires ;
        }

        public override string ToString()
        {
            string phrase = base.ToString() + "Ce spectacle se déroule dans la salle " + nomSalle + ", il y a " + nombrePlace + " places. Les horaires sont :";
            foreach(DateTime element in horaire)
            {
                phrase += " / " + element.ToString("t");
            }
            phrase += "\n";
            return phrase;
        }
    }
}
