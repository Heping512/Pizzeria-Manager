using System;
using System.Collections.Generic;
using System.Text;

namespace ProjetPOO
{
    class Commis : Effectif
    {
        DateTime dateEmb;
        int nbrDeCommandeGerees;

        #region Constructeurs
        public Commis(string nom, string prenom, string adresse, int numTel,string ville,string etat,DateTime dateEmb):base(nom,prenom,adresse,numTel,ville,etat)
        {
            this.dateEmb = dateEmb;
        }
        #endregion

        #region Propriété
        public DateTime DateEmb
        {
            get { return this.dateEmb; }
        }
        public int NbrDeCommandeGerees
        {
            get { return this.nbrDeCommandeGerees; }
            set { this.nbrDeCommandeGerees = value; }
        }
        #endregion

        public override string ToString()
        {
            return base.Etat + " " + this.dateEmb.ToShortDateString();
        }

        public Commande CreactionCommande(Client client, Livreur livreur)
        {
            Console.WriteLine("Quel est le numéro de commande ?");
            int num = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Quel est la date et l'heure de la commande ?");
            DateTime dt = Convert.ToDateTime(Console.ReadLine());
            string statut = "En préparation";
            Commande c = new Commande(num, dt, statut," ",this.Nom,livreur.Nom,client.Adresse,client.NumTel);
            return c;
        }


        public string DemandeStatutCommande(Commande c)
        {
            return c.Statut;
        }

        public void FermerCommande(Commande c,Livreur l,Entreprise e)
        {
            if(c.Statut=="Commande Livrée")
            {
                c.Solde = "ok";
                e.Caisse = e.Caisse + l.PorteFeuille;
                l.PorteFeuille = 0;
                c.ChangementStatut(c.Fermee);

            }
            else
            {
                c.Solde = "perdu";
                e.Caisse = e.Caisse - c.CalculPrix();
                c.ChangementStatut(c.Rate);
            }
            
        }

        public Commande LancerCommande(Client c,Entreprise e,Livreur livreur)
        {
            this.nbrDeCommandeGerees = this.nbrDeCommandeGerees + 1;
            Commande a = null;
            if (c.VeutPasserCommande)
            {
                if (e.Clients.Contains(c)) 
                {                                    
                    int tel = 0;
                    do
                    {
                        Console.WriteLine("Quel est votre numéro de téléphone ?");
                        tel = Convert.ToInt32(Console.ReadLine());
                    } while (!e.Clients.Exists(x=> x.NumTel == tel));
                    a = CreactionCommande(c, livreur);
                    c.Commandes.Add(a);
                    e.Commandes.Add(a);
                    a.ChangementStatut(a.EnPreparation);
                }
                else
                {
                    e.CreationClient(c.Nom, c.Prenom, c.Adresse, c.NumTel,c.Ville, c.PorteMonnaie);
                    a = CreactionCommande(c, livreur);
                    c.Commandes.Add(a);
                    e.Commandes.Add(a);
                    a.ChangementStatut(a.EnPreparation);
                }
            }
            return a;
        }

        #region déléguation Comparaison 
        public int CompareToDate(Commis a, Commis b)
        {
            return a.dateEmb.CompareTo(b.DateEmb);
        }
        #endregion
    }
}
