using System;
using System.Collections.Generic;
using System.Text;

namespace PFR
{
    public class Boutique : Attraction
    {
        private TypeBoutique type;

        public Boutique(TypeBoutique type, bool besoinSpecifique, TimeSpan dureeMaintenance, List<Monstre> equipe, int identifiant, bool maintenance, string natureMaintenance, int nbMinMonstre, string nom, bool ouvert, string typeDeBesoin) : base(besoinSpecifique, dureeMaintenance, equipe, identifiant, maintenance, natureMaintenance, nbMinMonstre, nom, ouvert, typeDeBesoin)
        {
            this.type = type;
        }

        #region Accesseurs

        public TypeBoutique Type
        {
            get { return type; }
            set { type = value; }
        }

        #endregion

        /*-----------------------------------------------------------METHODES---------------------------------------------------------------*/

        public override string EcrireFichiercsv()
        {
            return base.EcrireFichiercsv() + ';' + type;
        }

        public override string ToString()
        {
            return base.ToString() + "Cette boutique est de type " + type + ".\n";
        }
    }
}
