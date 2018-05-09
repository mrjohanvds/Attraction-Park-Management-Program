using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace PFR
{
    public class Administration
    {
        private List<Attraction> attractions;
        private List<Personnel> toutLePersonnel;

        public List<Personnel> ToutLePersonnel { get => toutLePersonnel; set => toutLePersonnel = value; }

        public Administration ()
        {
            attractions = new List<Attraction>();
            toutLePersonnel = new List<Personnel>();

            LireFichier("Listing.csv");
        }


        /*-----------------------------------------------------------METHODES---------------------------------------------------------------*/


        public void LireFichier(string fichier)
        {
            StreamReader monStreamReader = new StreamReader(fichier);
            string ligne = monStreamReader.ReadLine();

            while (ligne != null)
            {
                string[] tab = ligne.Split(';');
                
                switch (tab[0])
                {
                    
                    case "Boutique":
                        Boutique boutique = new Boutique((TypeBoutique)Enum.Parse(typeof(TypeBoutique), tab[6]), Convert.ToBoolean(tab[4]), new TimeSpan(), new List<Monstre>(), Convert.ToInt32(tab[1]), false, null, Convert.ToInt32(tab[3]), tab[2], true, tab[5]);
                        attractions.Add(boutique);
                        break;
                    case "DarkRide":
                        DarkRide dark = new DarkRide(TimeSpan.Parse(tab[6]), Convert.ToBoolean(tab[7]),Convert.ToBoolean(tab[4]),new TimeSpan(),new List<Monstre>(),Convert.ToInt32(tab[1]),false,null,Convert.ToInt32(tab[3]),tab[2],true,tab[5]);
                        attractions.Add(dark);
                        break;
                    case "RollerCoaster":
                        RollerCoaster rollerCoaster = new RollerCoaster(Convert.ToInt32(tab[7]),(TypeCategorie)Enum.Parse(typeof(TypeCategorie),tab[6]),double.Parse(tab[8]),Convert.ToBoolean(tab[4]),new TimeSpan(),new List<Monstre>(),Convert.ToInt32(tab[1]),false,null,Convert.ToInt32(tab[3]),tab[2],true,tab[5]);
                        attractions.Add(rollerCoaster);
                        break;
                    case "Spectacle":
                        string[] h = tab[8].Split(' ');//tableau des horaire
                        List<DateTime> times = new List<DateTime>();
                        for (int i = 0; i< h .Length;i++ )
                        {
                            times.Add(DateTime.Parse(h[i]));
                        }
                        Spectacle spectacles = new Spectacle(times,Convert.ToInt32(tab[7]),tab[6],Convert.ToBoolean(tab[4]),new TimeSpan(),new List<Monstre> (),Convert.ToInt32(tab[1]),false,null,Convert.ToInt32(tab[3]),tab[2],true,tab[5]);
                        attractions.Add(spectacles);
                        break;
                }
                
                
                ligne = monStreamReader.ReadLine();
            }
            monStreamReader = new StreamReader(fichier);
            ligne = monStreamReader.ReadLine();

            while (ligne != null)
            {
                string[] tab = ligne.Split(';');

                Personnel personnel = null;
                Attraction attraction = null;
                int idAttraction = -1;
                try
                {
                    switch (tab[0])
                    {
                        case "Monstre":
                            if (Int32.TryParse(tab[7], out idAttraction) && ChercherAttraction(idAttraction) != -1) attraction = attractions[ChercherAttraction(Convert.ToInt32(tab[7]))];
                            personnel = new Monstre(attraction, Convert.ToInt32(tab[6]), tab[5], Convert.ToInt32(tab[1]), tab[2], tab[3], (TypeSexe)Enum.Parse(typeof(TypeSexe), tab[4]));
                            break;
                        case "Sorcier":
                            List<string> sep = tab[7].Split('-').ToList<string>();
                            personnel = new Sorcier(sep, (Grade)Enum.Parse(typeof(Grade), tab[6]), tab[5], Convert.ToInt32(tab[1]), tab[2], tab[3], (TypeSexe)Enum.Parse(typeof(TypeSexe), tab[4]));

                            break;
                        case "Demon":
                            if (Int32.TryParse(tab[7], out idAttraction) && ChercherAttraction(idAttraction) != -1) attraction = attractions[ChercherAttraction(Convert.ToInt32(tab[7]))];
                            personnel = new Demon(Convert.ToInt32(tab[8]), attraction, Convert.ToInt32(tab[6]), tab[5], Convert.ToInt32(tab[1]), tab[2], tab[3], (TypeSexe)Enum.Parse(typeof(TypeSexe), tab[4]));

                            break;
                        case "Fantome":
                            if (Int32.TryParse(tab[7], out idAttraction) && ChercherAttraction(idAttraction) != -1) attraction = attractions[ChercherAttraction(Convert.ToInt32(tab[7]))];
                            personnel = new Fantome(attraction, Convert.ToInt32(tab[6]), tab[5], Convert.ToInt32(tab[1]), tab[2], tab[3], (TypeSexe)Enum.Parse(typeof(TypeSexe), tab[4]));

                            break;
                        case "LoupGarou":
                            if (Int32.TryParse(tab[7], out idAttraction) && ChercherAttraction(idAttraction) != -1) attraction = attractions[ChercherAttraction(Convert.ToInt32(tab[7]))];
                            personnel = new LoupGarou(Convert.ToDouble(tab[8]), attraction, Convert.ToInt32(tab[6]), tab[5], Convert.ToInt32(tab[1]), tab[2], tab[3], (TypeSexe)Enum.Parse(typeof(TypeSexe), tab[4]));
                            
                            break;
                        case "Vampire":
                            if (Int32.TryParse(tab[7], out idAttraction) && ChercherAttraction(idAttraction) != -1) attraction = attractions[ChercherAttraction(Convert.ToInt32(tab[7]))];
                            personnel = new Vampire(Convert.ToDouble(tab[8]), attraction, Convert.ToInt32(tab[6]), tab[5], Convert.ToInt32(tab[1]), tab[2], tab[3], (TypeSexe)Enum.Parse(typeof(TypeSexe), tab[4]));
                            
                            break;
                        case "Zombie":
                            if (Int32.TryParse(tab[7], out idAttraction) && ChercherAttraction(idAttraction) != -1) attraction = attractions[ChercherAttraction(Convert.ToInt32(tab[7]))];
                            personnel = new Zombie(Convert.ToInt32(tab[9]), (CouleurZ)Enum.Parse(typeof(CouleurZ), tab[8]), attraction, Convert.ToInt32(tab[6]), tab[5], Convert.ToInt32(tab[1]), tab[2], tab[3], (TypeSexe)Enum.Parse(typeof(TypeSexe), tab[4]));
                            break;
                    }
                    if(personnel != null)
                        toutLePersonnel.Add(personnel);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
                ligne = monStreamReader.ReadLine();
            }
            monStreamReader.Close(); 

        }

        public void Zombillenium()
        {
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine(
                                    "    )    )     *           (    (     (             )  (             *    \n"
                                   + " ( /( ( /(   (  `      (   )\\ ) )\\ )  )\\ )       ( /(  )\\ )        (  `   \n"
                                   + " )\\()))\\())  )\\))(   ( )\\ (()/((()/( (()/(  (    )\\())(()/(    (   )\\))(  \n"
                                   + "((_)\\((_)\\  ((_)()\\  )((_) /(_))/(_)) /(_)) )\\  ((_)\\  /(_))   )\\ ((_)()\\ \n"
                                   + " _((_) ((_) (_()((_)((_)_ (_)) (_))  (_))  ((_)  _((_)(_))  _ ((_)(_()((_)\n"
                                   + "|_  / / _ \\ |  \\/  | | _ )|_ _|| |   | |   | __|| \\| ||_ _|| | | ||  \\/  |\n"
                                   + " / / | (_) || |\\/| | | _ \\ | | | |__ | |__ | _| | .` | | | | |_| || |\\/| |\n"
                                   + "/___| \\___/ |_|  |_| |___/|___||____||____||___||_|\\_||___| \\___/ |_|  |_|\n");
            Console.ForegroundColor = ConsoleColor.White;
        }

        public void EcritureFichier(string nomFichier, string texte)
        {
            StreamWriter fichEcr = new StreamWriter(nomFichier, true);
            fichEcr.Write(texte);
            fichEcr.Close();
        }

        public int ChercherAttraction(int id) 
        {
            int compteur = 0;
            foreach ( Attraction a in attractions)
            {
                if (id == a.Identifiant)
                {
                    return compteur; //On renvoie l'index de l'attraction dans la liste
                }
                compteur++;
            }
            return -1;
        }

        public int ChercherPersonnel(int id)
        {
            int compteur = 0;
            foreach ( Personnel element in toutLePersonnel)
            {
                if(id == element.Matricule)
                {
                    return compteur; //On renvoie l'index du membre dans la liste
                }
                compteur++;
            }
            return -1;
        }

        public int ChercherIdTypeBoutique(TypeBoutique type)
        {
            foreach (Attraction element in attractions)
                if (element is Boutique && ((Boutique)element).Type == type)
                    return element.Identifiant;
            return -1;
        }

        public void StatusCagnotte(int id)
        {
            if (toutLePersonnel[ChercherPersonnel(id)] is Monstre && ((Monstre)toutLePersonnel[ChercherPersonnel(id)]).Cagnotte < 50)
                ((Monstre)toutLePersonnel[ChercherPersonnel(id)]).Affectation = attractions[ChercherAttraction(ChercherIdTypeBoutique(TypeBoutique.barbeAPapa))];
            if (toutLePersonnel[ChercherPersonnel(id)] is Zombie && ((Zombie)toutLePersonnel[ChercherPersonnel(id)]).Cagnotte > 500)
                ((Zombie)toutLePersonnel[ChercherPersonnel(id)]).Affectation = null;
            if (toutLePersonnel[ChercherPersonnel(id)] is Demon && ((Demon)toutLePersonnel[ChercherPersonnel(id)]).Cagnotte > 500)
                ((Demon)toutLePersonnel[ChercherPersonnel(id)]).Affectation = null;

        }

        public override string ToString()
        {
            string texte = "";
            foreach (Attraction a in attractions)
            {
                texte += a.ToString();
            }

                return texte;
        }

        public void AfficherPersonnel()
        {
            string texte = "";
            foreach (Personnel element in toutLePersonnel)
            {
                Console.WriteLine(element.ToString());
                texte += element.EcrireFichiercsv() + '\n';
            }
            texte += '\n';
            EcritureFichier("csv2.csv", texte);
        }

        public void AfficherAttraction()
        {
            string texte = "";
            foreach (Attraction element in attractions)
            {
                Console.WriteLine(element.ToString());
                texte += element.EcrireFichiercsv() + '\n';
            }
            texte += '\n';
            EcritureFichier("csv2.csv", texte);
        }

        public void AfficherZombie()
        {
            string texte = "";
            foreach (Personnel element in toutLePersonnel)
            {
                if (element is Zombie)
                { 
                Console.WriteLine(element.Prenom + " " + element.Nom);
                texte += element.EcrireFichiercsv() + '\n';
                }
            }
            texte += '\n';
            EcritureFichier("csv2.csv", texte);
        }

        public void AjouterPersonnel(Personnel monPersonnel)
        {
            toutLePersonnel.Add(monPersonnel);
        }

        public void AjouterAttraction(Attraction monAttraction)
        {
            attractions.Add(monAttraction);
        }

        public void TrierMonstreCagnotte()
        {
            toutLePersonnel.Sort(delegate (Personnel m1, Personnel m2)
            {
                int val = m1.CompareTo(m2);
                if ((m1 is Zombie)&(m2 is Zombie))
                {
                    val = (m1 as Zombie).Cagnotte.CompareTo((m2 as Zombie).Cagnotte);
                }
                return val;
            });
            string texte = "";
            foreach (Personnel element in toutLePersonnel)
            {
                if (element is Zombie)
                {
                    Console.WriteLine(element);
                    texte += element.EcrireFichiercsv() + '\n';
                }
            }
            texte += '\n';
            EcritureFichier("csv2.csv", texte);
        }

        public void TrierForce()
        {
            toutLePersonnel.Sort(delegate (Personnel m1, Personnel m2)
            {
                int val = m1.CompareTo(m2);
                if ((m1 is Demon) & (m2 is Demon))
                {
                    val = (m1 as Demon).Force.CompareTo((m2 as Demon).Force);
                }
                return val;
            });
            string texte = "";
            foreach (Personnel element in toutLePersonnel)
            {
                if (element is Demon)
                {
                    Console.WriteLine(element);
                    texte += element.EcrireFichiercsv() + '\n';
                }
            }
            texte += '\n';
            EcritureFichier("csv2.csv", texte);
        }

        public void AfficherTitre(string titre)
        {
            Console.WriteLine();
            for (int i = 0; i < titre.Length + 2; i++)
                Console.Write("-");
            Console.Write("\n|");
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.Write(titre);
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("|");
            for (int i = 0; i < titre.Length + 2; i++)
                Console.Write("-");
            Console.WriteLine("\n");

        }

        public void ProgramDemo()
        {
            Zombillenium();

            AfficherTitre("PROGRAMME DE DEMO DU LOGICIEL DE GESTION DU PARC ZOMBILLENIUM");
            Console.WriteLine("Demo créée par Jerry TELLE et Johan VAN DER SLOOTEN");
            AfficherTitre("Affichage du personnel");
            AfficherPersonnel();

            AfficherTitre("Affichage des attractions");
            AfficherAttraction();

            AfficherTitre("Creation d'une attraction (Zombarracuda)");
            AjouterAttraction(new RollerCoaster(12, TypeCategorie.assise, 1.20, false, TimeSpan.Parse("0"), new List<Monstre>(), 489, false, "", 2, "Zombarracuda", true, ""));
            AfficherAttraction();


            AfficherTitre("Creation d'un membre du personnel (Martin Dutrou)");
            AjouterPersonnel(new Demon(4, attractions[0], 250, "mécanicien", 6590, "Dutrou", "Martin", TypeSexe.male));
            AfficherPersonnel();

            AfficherTitre("Changement de fonction de Martin Dutrou");
            toutLePersonnel[ChercherPersonnel(6590)].ChangementFonction("agent de maintenance");
            Console.WriteLine(toutLePersonnel[ChercherPersonnel(6590)].ToString());
            Console.WriteLine("\nPour cet exercice, nous pouvons faire énormement de variantes, comme par exemple :\n   -Changement de status de maintenance d'une attraction\n   -Evolution du degré de décomposition des zombies"
                + "\n   -Ajout d'un pouvoir pour un sorcier\n   -Changement de l'âge minimum d'un RollerCoaster\n   -Changement d'horaires d'un spectacle\n   -etc...");

            AfficherTitre("Affichage de l'ensemble des zombies");
            AfficherZombie();
            Console.WriteLine("\nPour cet exercice, nous pouvons faire énormement de variantes, comme par exemple :\n   -Affichage de toutes les attractions en maintenance\n   -Affichage des différents types de personnel/attractions"
                + "\n   -Affichage du personnel sans fonction");

            AfficherTitre("Affichage des zombies triés en fonction de leur cagnotte");
            TrierMonstreCagnotte();

            AfficherTitre("Affichage des démons triés en fonction de leur force  ");
            TrierForce();

            AfficherTitre("Incrémentation de 300 de la cagnotte de Martin Dutrou");
            ((Monstre)toutLePersonnel[ChercherPersonnel(6590)]).ChangementCagnotte(300);
            StatusCagnotte(6590);
            Console.WriteLine(toutLePersonnel[ChercherPersonnel(6590)].ToString());
        }

        #region Menu

        public void Menu()
        {
            int choix = -1;
            
            while (choix != 0)
            {
                string menu = "1/ Afficher le personnel\n2/ Afficher les attractions et leur état\n3/ Ajouter membre du personnel\n3/ Ajouter attraction\n4/ Affichage console avancé\n0/ Quitter";
                Console.Clear();
                Console.WriteLine(menu);
                choix = int.Parse(Console.ReadLine());
                switch (choix)
                {
                    case 0: break;
                    case 1: AfficherPersonnel();
                        break;
                    case 2: AfficherAttraction();
                        break;
                    case 3:break;//A Ajouter
                    case 4:SortirConsoleElement();
                        break;
                    
                }
            }
        }

        public int RevenirMenuPrincipal()
        {
            string menu = "Voulez vous revenir au menu principal ?\n\n1/ Oui\n0/ Non";
            Console.Clear();
            Console.WriteLine(menu);
            int choix = int.Parse(Console.ReadLine());

            while(choix != 1 && choix != 0)
            {
                string menuErreur = "Veuillez insérer le numéro correspondant à votre choix :\n\nVoulez vous revenir au menu principal ?\n\n1/Oui\n0/Non";
                Console.Clear();
                Console.WriteLine(menuErreur);
                choix = int.Parse(Console.ReadLine());
            }

            return choix;
        }

        public int SortirConsoleElement()
        {

            int choix = -1;
            while(choix != 0)
            {
                string menu = "1/ Gestion des attractions\n2/ Gestion du personnel\n0/ Revenir au menu principal";
                Console.Clear();
                Console.WriteLine(menu);
                choix = int.Parse(Console.ReadLine());

                switch (choix)
                {
                    case 0: break;
                    case 1:
                        {
                            a:
                            string menuBis = "1/ Afficher attractions en maintenance\n2/ Affichage suivant le type d'attraction\n0/ Retour";
                            Console.Clear();
                            Console.WriteLine(menuBis);
                            choix = int.Parse(Console.ReadLine());

                            switch (choix)
                            {
                                case 0: choix = -1;
                                    break;
                                case 1:
                                    foreach(Attraction element in attractions)
                                        if (element.Maintenance)
                                            Console.WriteLine(element.Nom);
                                    break;
                                case 2:
                                    {
                                        string menuTer = "1/ Afficher les boutiques\n2/ Afficher les DarkRides\n3/ Afficher les RollerCoasters\n4/ Afficher les spectacles\n0/ Retour";
                                        Console.Clear();
                                        Console.WriteLine(menuTer);
                                        choix = int.Parse(Console.ReadLine());
                                        switch (choix)
                                        {
                                            case 0: goto a;
                                            case 1:
                                                foreach (Attraction element in attractions)
                                                    if (element is Boutique)
                                                        Console.WriteLine(element.Nom);
                                                break;
                                            case 2:
                                                foreach (Attraction element in attractions)
                                                    if (element is DarkRide)
                                                        Console.WriteLine(element.Nom);
                                                break;
                                            case 3:
                                                foreach (Attraction element in attractions)
                                                    if (element is RollerCoaster)
                                                        Console.WriteLine(element.Nom);
                                                break;
                                            case 4:
                                                foreach (Attraction element in attractions)
                                                    if (element is Spectacle)
                                                        Console.WriteLine(element.Nom);
                                                break;
                                        }
                                    }break;
                            }
                        }
                        break;
                    case 2:
                        {
                            a:
                            string menuBis = "1/ Afficher tous les males\n2/ Afficher toutes les femelles\n3/ Affichage suivant le type de personnel\n0/ Retour";
                            Console.Clear();
                            Console.WriteLine(menuBis);
                            choix = int.Parse(Console.ReadLine());

                            switch (choix)
                            {
                                case 0: choix = -1;
                                    break;
                                case 1:
                                    foreach (Personnel element in toutLePersonnel)
                                        if (element.Sexe == TypeSexe.male)
                                            Console.WriteLine(element.Prenom + " " + element.Nom);
                                    break;
                                case 2:
                                    foreach (Personnel element in toutLePersonnel)
                                        if (element.Sexe == TypeSexe.femelle)
                                            Console.WriteLine(element.Prenom + " " + element.Nom);
                                    break;
                                case 3:
                                    {
                                        string menuTer = "1/ Afficher les monstres\n2/ Afficher les sorciers\n3/ Afficher les demons\n4/ Afficher les fantomes\n5/ Afficher les Loups Garous\n6/ Afficher les vampires\n7/ Afficher les zombies\n0/ Retour";
                                        Console.Clear();
                                        Console.WriteLine(menuTer);
                                        choix = int.Parse(Console.ReadLine());
                                        switch (choix)
                                        {
                                            case 0: goto a;
                                            case 1:
                                                foreach (Personnel element in toutLePersonnel)
                                                    if (element is Monstre)
                                                        Console.WriteLine(element.Prenom + " " + element.Nom);
                                                break;
                                            case 2:
                                                foreach (Personnel element in toutLePersonnel)
                                                    if (element is Sorcier)
                                                        Console.WriteLine(element.Prenom + " " + element.Nom);
                                                break;
                                            case 3:
                                                foreach (Personnel element in toutLePersonnel)
                                                    if (element is Demon)
                                                        Console.WriteLine(element.Prenom + " " + element.Nom);
                                                break;
                                            case 4:
                                                foreach (Personnel element in toutLePersonnel)
                                                    if (element is Fantome)
                                                        Console.WriteLine(element.Prenom + " " + element.Nom);
                                                break;
                                            case 5:
                                                foreach (Personnel element in toutLePersonnel)
                                                    if (element is LoupGarou)
                                                        Console.WriteLine(element.Prenom + " " + element.Nom);
                                                break;
                                            case 6:
                                                foreach (Personnel element in toutLePersonnel)
                                                    if (element is Vampire)
                                                        Console.WriteLine(element.Prenom + " " + element.Nom);
                                                break;
                                            case 7:
                                                foreach (Personnel element in toutLePersonnel)
                                                    if (element is Zombie)
                                                        Console.WriteLine(element.Prenom + " " + element.Nom);
                                                break;
                                        }
                                    }
                                    break;
                            }
                            break;
                        }
                }

            }
            
            return RevenirMenuPrincipal();
        }

        #endregion
    }
}
