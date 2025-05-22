using System;
using System.Collections.Generic;
using System.Text;

namespace ProjetPOO
{
    class Livreur : Effectif
    {
        double porteFeuille;
        int numero;
        string transport; 
        List<Pizza> pizzas;
        List<Boisson> boissons;
        string facture;
        int nbrDeLivraisonEffec;

        #region Constructeurs 
        public Livreur(string nom, string prenom, string adresse, int numTel,string ville,string etat,int numero,string transport):base(nom,prenom,adresse,numTel,ville,etat)
        {
            this.numero = numero;
            this.transport = transport;
            this.porteFeuille = 0;
            this.pizzas = new List<Pizza>();
            this.boissons = new List<Boisson>();
            this.facture = "";
        }
        #endregion 

        #region Propriétés
        public double PorteFeuille
        {
            get { return this.porteFeuille; }
            set { this.porteFeuille = value; }
        }
        public int Numero
        {
            get { return this.numero; }
        }
        public string Transport
        {
            get { return this.transport; }
            set { this.transport = value; }
        }
        public List<Pizza> Pizzas
        {
            get { return this.pizzas; }
            set { this.pizzas = value; }
        }
        public List<Boisson> Boissone
        {
            get { return this.boissons; }
            set { this.boissons = value; }
        }
        public string Facture
        {
            get { return this.facture; }
        }
        public int NbrDeLivraisonEffec
        {
            get { return this.nbrDeLivraisonEffec; }
            set { this.nbrDeLivraisonEffec = value; }
        }
        #endregion 

        public override string ToString()
        {
            return base.ToString() + " " + this.numero + " " + this.transport + " " + this.porteFeuille + "\n" + this.facture;
        }


        public void RecupererLaCommande(Commande c)
        {
            if(c.Pizzas.Count != 0)
            {
                this.nbrDeLivraisonEffec = this.nbrDeLivraisonEffec + 1;
                c.Pizzas.ForEach(x => this.pizzas.Add(x));
                c.Boissons.ForEach(x => this.boissons.Add(x));
            }
            else
            {
                Console.WriteLine("La commande est vide");
            }
        }

        public string FaireFacture()
        {
            string a = "";
            for (int i = 0; i < pizzas.Count; i++)
            {
                a += pizzas[i].ToString() + " ";

            }
            a += "\n";
            for (int i = 0; i < boissons.Count; i++)
            {
                a += boissons[i].ToString() +" ";
            }
            return a;
        }

        public void LivraisonCommande(Commande c)
        {
            if((this.pizzas == c.Pizzas)&&(this.boissons==c.Boissons))
            {
                c.ChangementStatut(c.EnLivraison);
            }            
        }

        public void Livrer(Commande c,string adresse,Client client)
        {
            if (client.Adresse == adresse)
            {                
                if (client.PayerLaCommande(c))
                {
                    c.ChangementStatut(c.Livree);
                    this.pizzas = new List<Pizza>();
                    this.boissons = new List<Boisson>();
                    client.VeutPasserCommande = false;
                }
                else
                {
                    c.ChangementStatut(c.Rate);
                }
            }
        }

        public int CompareToNum(Livreur l,Livreur ll)
        {
            
            return l.Numero.CompareTo(ll.Numero);
        }
        
    }
}
