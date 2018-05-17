 using System;
using System.Collections.Generic;
using System.Text;

namespace PFR
{
    public class Attraction
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
        private string listEquipe;

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
            listEquipe = ListToString();
        }

        #region Accesseurs

        public bool BesoinSpecifique
        {
            get { return besoinSpecifique; }
            set { besoinSpecifique = value; }
        }
        public TimeSpan DureeMaintenance
        {
            get { return dureeMaintenance; }
            set { dureeMaintenance = value; }
        }
        public int Identifiant
        {
            get { return identifiant; }
            set { identifiant = value; }
        }
        public bool Maintenance
        {
            get { return maintenance; }
            set { StatusMaintenance(value); }
        }
        public string NatureMaintenance
        {
            get { return natureMaintenance; }
            set { natureMaintenance = value; }
        }
        public int NbMinMonstre
        {
            get { return nbMinMonstre; }
            set { nbMinMonstre = value; }
        }
        public string Nom
        {
            get { return nom; }
            set { nom = value; }
        }
        public bool Ouvert
        {
            get { return ouvert; }
            set { ouvert = value; }
        }
        public string TypeDeBesoin
        {
            get { return typeDeBesoin; }
            set { typeDeBesoin = value; }
        }
        public List<Monstre> Equipe
        {
            get { return equipe; }
            set { equipe = value; }
        }
        public string ListEquipe
        {
            get { return listEquipe; }
            set { listEquipe = value; }
        }

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

        public void ChangementMaintenance(bool uneMaitenance, string uneNatureMaintenance, TimeSpan uneDuree)
        {
                maintenance = uneMaitenance;
                natureMaintenance = uneNatureMaintenance;
                ouvert = !uneMaitenance;
                dureeMaintenance = uneDuree;
        }

        public void StatusMaintenance(bool uneMaintenance)
        {
            maintenance = uneMaintenance;
            ouvert = !maintenance;
        }

        private string ListToString()
        {
            string str = "";
            int nb = equipe.Count;
            if (nb == 0)
                return "vide";
            foreach(Monstre personnel in equipe)
            {
                str += personnel.Prenom + " " + personnel.Nom;
                if (equipe.IndexOf(personnel) != nb - 1)
                    str += ",\n";
            }
            return str;
        }

    }
}
