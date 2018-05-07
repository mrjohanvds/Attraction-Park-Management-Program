 using System;
using System.Collections.Generic;
using System.Text;

namespace PFR
{
    class Attraction
    {
        private bool besoinSpecifique;
        private TimeSpan dureeMaintenance;
        private List<Monstre> equipe;
        private int identifiant;
        private bool maintenance;
        private string natureMaintenance;
        private int nbMinMonstre;
        private string nom;
        private bool ouvert;
        private string typeDeBesoin;

        public Attraction(bool besoinSpecifique, TimeSpan dureeMaintenance, List<Monstre> equipe, int identifiant, bool maintenance, string natureMaintenance, int nbMinMonstre, string nom, bool ouvert, string typeDeBesoin)
        {
            this.besoinSpecifique = besoinSpecifique;
            this.dureeMaintenance = dureeMaintenance;
            this.equipe = equipe;
            this.identifiant = identifiant;
            this.maintenance = maintenance;
            this.natureMaintenance = natureMaintenance;
            this.nbMinMonstre = nbMinMonstre;
            this.nom = nom;
            this.ouvert = ouvert;
            this.typeDeBesoin = typeDeBesoin;
        }

        #region Accesseurs

        public bool BesoinSpecifique { get => besoinSpecifique; set => besoinSpecifique = value; }
        public TimeSpan DureeMaintenance { get => dureeMaintenance; set => dureeMaintenance = value; }
        public int Identifiant { get => identifiant; set => identifiant = value; }
        public bool Maintenance { get => maintenance; set => maintenance = value; }
        public string NatureMaintenance { get => natureMaintenance; set => natureMaintenance = value; }
        public int NbMinMonstre { get => nbMinMonstre; set => nbMinMonstre = value; }
        public string Nom { get => nom; set => nom = value; }
        public bool Ouvert { get => ouvert; set => ouvert = value; }
        public string TypeDeBesoin { get => typeDeBesoin; set => typeDeBesoin = value; }
        internal List<Monstre> Equipe { get => equipe; set => equipe = value; }

        #endregion

        /*-----------------------------------------------------------METHODES---------------------------------------------------------------*/

        public override string ToString()
        {
            string phrase = "L'attraction " + nom + ", ID : " + identifiant + " ";
            if (ouvert)
                phrase += "est ouverte. \n";
            else
            {
                if (maintenance)
                    phrase += "est fermée à cause d'une maintenance du type : " + natureMaintenance + ", d'une durée de " + dureeMaintenance.ToString("c") + ".\n";
                else
                    phrase += "est fermée. \n";
            }

            return phrase;
        }

        public virtual string EcrireFichiercsv()
        {
            return base.ToString().Split('.')[1] + ';' + identifiant + ';' + nom + ';' + nbMinMonstre + ';' + besoinSpecifique + ';' + typeDeBesoin;
        }

        public void changementMaintenance(bool uneMaitenance, string uneNatureMaintenance, TimeSpan uneDuree)
        {
                maintenance = uneMaitenance;
                natureMaintenance = uneNatureMaintenance;
                ouvert = !uneMaitenance;
                dureeMaintenance = uneDuree;
        }

    }
}
