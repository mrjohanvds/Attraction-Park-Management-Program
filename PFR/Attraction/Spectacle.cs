using System;
using System.Collections.Generic;
using System.Text;

namespace PFR
{
    public class Spectacle :Attraction
    {
        private List<DateTime> horaire;
        private int nombrePlace;
        private string nomSalle;
        private string horaires;

        public Spectacle(List<DateTime> horaire, int nombrePlace, string nomSalle, bool besoinSpecifique, TimeSpan dureeMaintenance, List<Monstre> equipe, int identifiant, bool maintenance, string natureMaintenance, int nbMinMonstre, string nom, bool ouvert, string typeDeBesoin) : base(besoinSpecifique, dureeMaintenance, equipe, identifiant, maintenance, natureMaintenance, nbMinMonstre, nom, ouvert, typeDeBesoin)
        {
            this.horaire = horaire;
            this.nombrePlace = nombrePlace;
            this.nomSalle = nomSalle;
            horaires = HorairesToString();
        }

        #region accesseurs

        public string NomSalle
        {
            get { return nomSalle;}
            set { NomSalle = value; }
        }
        public int NombrePlace
        {
            get { return nombrePlace; }
            set { nombrePlace = value; }
        }
        public List<DateTime> Horaire
        {
            get { return horaire; }
            set { horaire = value; }
        }
        public string Horaires
        {
            get { return horaires; }
            set { horaires = value; }
        }

        #endregion

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

        private string HorairesToString()
        {
            string str = "";
            foreach(DateTime element in horaire)
            {
                str += element.Hour + "h" + element.Minute;
                if (horaire.IndexOf(element) != horaire.Count - 1)
                    str += ",\n";
            }
            return str;
        }
    }
}
