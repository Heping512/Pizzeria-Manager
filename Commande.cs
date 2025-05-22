using System;
using System.Collections.Generic;
using System.Text;

namespace ProjetPOO
{
    class Commande
    {
        int numCommande; //Apparaitre 
        DateTime date; //Apparaitre 
        List<Pizza> pizzas;
        List<Boisson> boissons;
        string statut; //apparaitre
        string solde; // apparaitre
        string nomCommis; //apparaitre
        string nomLivreur; //apparaitre
        string adresseClient; //aparaitre 
        int numTelClient;

        

        #region Constructeurs
        public Commande(int num, DateTime date, string statut, string solde, string nomCommis,string nomLivreur, string adresseClient,int numTelClient)
        {
            this.numCommande = num;
            this.date = date;
            this.statut = statut;
            this.solde = solde;
            this.pizzas = new List<Pizza>();
            this.boissons = new List<Boisson>();
            this.nomCommis = nomCommis;
            this.nomLivreur = nomLivreur;
            this.adresseClient = adresseClient;
            this.numTelClient = numTelClient;
        }

        #endregion

        #region Propriété
        public int NumCommande
        {
            get { return this.numCommande; }
        }
        public DateTime Date
        {
            get { return this.date; }
        }
        public List<Pizza> Pizzas
        {
            get { return this.pizzas; }
        }
        public List<Boisson> Boissons
        {
            get { return this.boissons; }
        }
        public string Statut
        {
            get { return this.statut; }
            set { this.statut = value; }
        }
        public string Solde
        {
            get { return this.solde; }
            set { this.solde = value; }
        }
        public string NomCommis
        {
            get { return this.nomCommis; }
        }
        public string AdresseClient
        {
            get { return this.adresseClient; }
        }
        public string NomLivreur
        {
            get { return this.nomLivreur; }
        }
        public int NumTelClient
        {
            get { return this.numTelClient; }
            set { this.numTelClient = value; }
        }
        #endregion

        #region DélégationStatut    

        public string EnPreparation()
        {
            return "En prépation";
        }

        public string EnLivraison()
        {
            return "En Livraison";
        }

        public string Livree()
        {
            return "Commande Livrée";
        }

        public string Fermee()
        {
            return "Commande fermée";
        }

        public string Rate()
        {
            return "Commande échouée";
        }

        public void ChangementStatut(Statut s)
        {
            this.statut = s();
        }
        #endregion

        public double CalculPrix()
        {
            double res = 0;
            this.pizzas.ForEach(x => res += x.Prix*x.Quantite); 
            this.boissons.ForEach(x => res += x.Prix * x.Quantite);
            return res;
        }
        
        public string AffichageCommande()
        {
            string a =  this.numCommande + " : " + CalculPrix() +"\n";
            foreach (Pizza p in this.pizzas)
            {
                a += p.ToString();
            }
            foreach(Boisson b in this.boissons)
            {
                a += b.ToString();
            }
            return a;
        }

        #region déléguation Comparaison 
        public int CompareToStatut(Commande a, Commande b)
        {
            return a.Statut.CompareTo(b.Statut);
        }
        public int CompareToSolde(Commande a, Commande b)
        {
            return a.Solde.CompareTo(b.Solde);
        }
        #endregion 

        public override string ToString()
        {
            string a = "";
            this.pizzas.ForEach(x => a += "\n" + x.ToString());
            this.boissons.ForEach(x => a += x.Prix * x.Quantite);
            return this.numCommande + " " + this.date.ToShortDateString() + " " + this.statut + " " + this.solde + " " + this.adresseClient + " " + this.nomCommis + " " + this.nomLivreur;
        }

    }
}
