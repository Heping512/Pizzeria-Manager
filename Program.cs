using System;
using System.Collections.Generic;

namespace ProjetPOO
{

    delegate string Statut();
    class Program
    {        
        static void DeroulerCommande(Client c,Livreur l,Commis cmis,Entreprise p,Cuisinier cui)
        {           

            ///Un client passe une commande + le commis a devant lui les notes qu'il a prise sur la commande
            Console.WriteLine("*********************************Un client passe une commande************************************");
            c.PasserCommande();
            Console.WriteLine();

            if (c.VeutPasserCommande)
            {
                ///Le commis lance la commande
                Console.WriteLine("*********************************Le commis lance une commande ************************************");
                Commande com1 = cmis.LancerCommande(c, p, l);
                

                ///Le cuisinier prépare les pizzas 
                Console.WriteLine("****************************Le cuisinier prépare les pizzas************************************");
                Console.WriteLine("Combien de pizza à préparer ?");
                int nbrPizza = Convert.ToInt32(Console.ReadLine());
                for (int i = 0; i < nbrPizza; i++)
                {
                    cui.Pizza.Add(cui.CreationPizza());
                }
                Console.WriteLine();

                ///Le commis demande où se trouve la commande 
                Console.WriteLine("************************Le commis demande le statut de la commande *******************");
                Console.WriteLine(cmis.DemandeStatutCommande(com1));
                Console.WriteLine();

                Console.WriteLine("*********************************Les pizzas sont prêtes************************************");
                ///Une fois les pizzas prêtes
                Console.WriteLine("*********************Ajout des pizzas et boissons à la commande par le commis *******************");
                ///Le commis : 
                ///Ajouter les pizzas à la commande 
                cui.Pizza.ForEach(x => com1.Pizzas.Add(x));
                ///Ajouter les boissons 
                Console.WriteLine("Combien de boissons ? ");
                int nbrBoisson = Convert.ToInt32(Console.ReadLine());
                for (int i = 0; i < nbrBoisson; i++)
                {
                    Console.WriteLine("Type de boisson ?");
                    string a = Console.ReadLine();
                    Console.WriteLine("La taille");
                    int t = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("Quantité ?");
                    int b = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("Le prix ?");
                    double d = Convert.ToDouble(Console.ReadLine());
                    Boisson boisson = new Boisson(b, d, a, t);
                    com1.Boissons.Add(boisson);
                }
                Console.WriteLine();

                Console.WriteLine("********************************Affiche le pirx de la commande ********************************");
                Console.WriteLine("Prix à payer :" + com1.CalculPrix());
                Console.WriteLine("********************************Affiche le panier moyen du client********************************");
                Console.WriteLine();
                Console.WriteLine(c.Moyenne());

                Console.WriteLine("****************************Le livreur récupère la commande ***************************");
                ///Le livreur récupère la commande 
                l.RecupererLaCommande(com1);
                Console.WriteLine();

                Console.WriteLine("************************Le livreur fait une facture ******************************");
                ///Le livreur fait une facture de la commande 
                Console.WriteLine(l.FaireFacture());
                ///Modifier le statut de la commande : En cours de livraison 
                Console.WriteLine();
                Console.WriteLine("***************************Le livreur part en livraison ****************************");
                l.LivraisonCommande(com1);
                Console.WriteLine();


                ///Le commis demande où se trouve la commande 
                Console.WriteLine("************************Le commis demande le statut de la commande *******************");
                Console.WriteLine(cmis.DemandeStatutCommande(com1));
                Console.WriteLine();

                ///Le livreur est arrivé , il livre sa commande 
                Console.WriteLine("**************************Le Livreur livre les pizzas et rentre à la pizerria *********************");
                l.Livrer(com1, c.Adresse, c);
                Console.WriteLine();

                ///Le livreur retourne à la pizzeria et le commis ferme la commande 
                ///Le commis demande où se trouve la commande 
                Console.WriteLine("****************************Le commis ferme la commande ********************************");
                cmis.FermerCommande(com1, l, p);
                ///afficher commande ok ou perte 
                Console.WriteLine("**************************La commande a été livré ou perdu ? **************************************");
                Console.WriteLine(com1.Solde);
                Console.WriteLine();
            }
        }
        static void Main(string[] args)
        {

            #region Entrerprise Pizzaria 
            Entreprise pizerria = new Entreprise();
            #endregion

            #region Création des clients
            Client c1 = new Client("Lacroix", "Thierry", "Rue de la Paix", 0612345678,"Paris",3456,new DateTime(2020,12,05));
            Client c2 = new Client("Destin", "Joshua", "Rue des Haudriette", 0619283745, "Paris", 4);
            Client c3 = new Client("Ye", "Justine", "Avenue de Jean Jaurès", 0624738316, "Paris", 765);
            Client c4 = new Client("Fernandez", "Hugo", "Place de Clichy", 066263363, "Paris", 46);
            Client c5 = new Client("Reiss", "David", "Rue de 8 mai 1945", 0699732684, "Paris", 976);
            #endregion

            #region Creation Commis 
            Commis cmis1 = new Commis("Lefèvre","Elliot","Rue des Archives",0651096754, "Paris", "En congé", new DateTime(2020, 04, 01));
            Commis cmis2 = new Commis("Ranty", "James", "Place de la République", 0651096753, "Paris", "En congé", new DateTime(2018, 09, 09));
            Commis cmis3 = new Commis("Cohen", "Rose", "Rue Michel le Compte", 0651034754, "Paris", "En congé", new DateTime(2008, 07, 02));
            pizerria.Commis.Add(cmis1);
            pizerria.Commis.Add(cmis2);
            pizerria.Commis.Add(cmis3);
            #endregion

            #region Création Livreur
            Livreur l1 = new Livreur("Wu", "Antoine", "Place Macéna", 0651736754, "Paris", "En congé", 001, "Vélo");
            Livreur l2 = new Livreur("Pré", "Thomas", "Rue des BlancsManteaux", 0651876754, "Paris", "En congé", 002, "Métro");
            Livreur l3 = new Livreur("Herm", "Franck", "Rue des Archives", 0651094754, "Paris", "En congé", 003, "Moto");
            pizerria.Livreurs.Add(l1) ;
            pizerria.Livreurs.Add(l2);
            pizerria.Livreurs.Add(l3);
            #endregion


            #region Création Cuisinier 
            Cuisinier cui1 = new Cuisinier("Cana", "Lucy", "Rue des Lilas", 0651096754, "Paris", new List<Pizza>());
            Cuisinier cui2 = new Cuisinier("Skarlette", "Erza", "Rue des Gravilliers", 0651096754, "Paris", new List<Pizza>());
            #endregion

            #region Commande 
            Console.WriteLine("***************************Ouverture Pizzeria*****************************************");
            ///Pour l'instant tous les commis et les livreurs sont en congés 
            ///Un commis et un livreur retournent au travail
            Console.WriteLine("****************************Retour au travail d'un commis et d'un livreur************************************");
            cmis1.ChangerEtat("Sur place");
            l1.ChangerEtat("Sur place");
            Console.WriteLine();

            Console.WriteLine("*************************Synchronisation FIchiers*******************************************");
            ///Lecture des fichiers enregistrées pour les mettres dans les listes 
            pizerria.LectureCleitn("Client.csv");

            #region Jour1 

            DeroulerCommande(c1, l1, cmis1, pizerria, cui1);
            DeroulerCommande(c2, l1, cmis1, pizerria, cui1);
            DeroulerCommande(c3, l1, cmis1, pizerria, cui1);

            Console.WriteLine("*********************************Afficher commande selon Numéro********************************************");
            Console.WriteLine("Quel est le numéro ?");
            int num = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine(pizerria.AffichageCommande(num));

            #endregion

            #region Jour2 
            Console.WriteLine("****************************Retour au travail d'un commis et d'un livreur************************************");
            cmis2.ChangerEtat("Sur place");
            l2.ChangerEtat("Sur place");
            Console.WriteLine();

            //DeroulerCommande(c1, l2, cmis1, pizerria, cui1);
            //DeroulerCommande(c2, l2, cmis2, pizerria, cui1);
            //DeroulerCommande(c3, l2, cmis2, pizerria, cui1);
            

            Console.WriteLine("*************************Afficher la moyenne des commandes de l'entrerprise*******************************************");
            Console.WriteLine(pizerria.Moyenne());

            Console.WriteLine("*************************Supprimer un client*******************************************");
            pizerria.SupprimerClient(c1);

            Console.WriteLine("***********************Afficher les commandes selon une période ******************************");
            Console.WriteLine(pizerria.AffichageCommandeSelonPeriode(new DateTime(2019,12,05),new DateTime(2020,12,05)));

            Console.WriteLine("***********************Modifier un commis ******************************");
            pizerria.ModificationCommis(cmis1);

            #endregion


            ///Cloture de la caisse
            Console.WriteLine("**************************Cloture de la caisse*****************************************");
            pizerria.SauvFichier(pizerria.SauvegarderClient, "ClientFin.csv");
            pizerria.SauvFichier(pizerria.SauvegarderCommis, "Commis.csv");
            pizerria.SauvFichier(pizerria.SauvegarderLivreur, "Livreur.csv");
            pizerria.SauvFichier(pizerria.SauvegarderCommande, "Commandes.csv");
            #endregion


            

        }
    }
}
