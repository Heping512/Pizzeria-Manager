using System;
using System.Collections.Generic;
using System.Text;

namespace ProjetPOO
{
    class Client : Personne, IMoyenne,IComparable
    {
        DateTime datePremCommande;
        double porteMonnaie;
        bool veutPasserCommande;
        List<Commande> commandes;

        #region Constructeurs
        public Client(string nom,string prenom,string adresse,int numTel,string ville,double porteMonnaie,DateTime datePremCommande) : base (nom,prenom,adresse,numTel,ville)
        {
            this.datePremCommande = datePremCommande;
            this.porteMonnaie = porteMonnaie;
            this.veutPasserCommande = false;
            this.commandes = new List<Commande>();
        }
        public Client(string nom, string prenom, string adresse, int numTel,string ville, double porteMonnaie):base(nom, prenom, adresse, numTel,ville)
        {            
            this.porteMonnaie = porteMonnaie;
            this.veutPasserCommande = false;
            this.commandes = new List<Commande>();
        }

        #endregion

        #region Propriété
        public DateTime DatePremCommande
        {
            get { return this.datePremCommande; }
        }
        public double PorteMonnaie
        {
            get { return this.porteMonnaie; }
        }
        public bool VeutPasserCommande
        {
            get { return this.veutPasserCommande; }
            set { this.veutPasserCommande = value; }
        }
        public List<Commande> Commandes
        {
            get { return this.commandes; }
            set { this.commandes = value; }
        }
        #endregion              

        public void PasserCommande()
        {
            Console.WriteLine("Voulez vous passer une commande de pizza ? \n0=oui et 1=non");
            int ers = Convert.ToInt32(Console.ReadLine());
            if (ers == 0)
            {
                int a = 0;
                int b = 0;
                string noteCommande = "";
                do
                {
                    Console.WriteLine("Quelle pizza voulez-vous ?");
                    string bb = Console.ReadLine();
                    Console.WriteLine("Quelle taille ? \nL=0 ; M=1 ; S=3");
                    bb += " " + Console.ReadLine() + " ";
                    noteCommande += bb + "\n";
                    Console.WriteLine("Voulez-vous une autre pizza ? \n0=oui ; 1=non");
                    a = Convert.ToInt32(Console.ReadLine());
                } while (a == 0);
                do
                {
                    Console.WriteLine("Que voulez_vous boire ?");
                    string bb = Console.ReadLine();
                    noteCommande += bb + "\n";
                    Console.WriteLine("Voulez-vous une autre boisson ? \n0=oui ; 1=non");
                    b = Convert.ToInt32(Console.ReadLine());
                } while (b == 0);
                Console.WriteLine("Note de la commande");
                Console.WriteLine(noteCommande);
                this.veutPasserCommande = true;
            }           

        }

        public bool PayerLaCommande(Commande com)
        {
            return com.CalculPrix() <= this.porteMonnaie;
        }

        public double Moyenne()
        {
            double somme = 0;
            List<Commande> s = commandes as List<Commande>;
            for (int i = 0; i < s.Count; i++)
            {
                somme = somme + s[i].CalculPrix();
            }
            return (somme / s.Count);
        }

        #region déléguation Comparaison 
        public int CompareMontant(Client a,Client b)
        {
            return a.Moyenne().CompareTo(b.Moyenne());
        }
        #endregion
    }
}
