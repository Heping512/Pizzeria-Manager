using System;
using System.Collections.Generic;
using System.Text;

namespace ProjetPOO
{
    class Pizza
    {
        string taille;
        string type;
        int quantite;
        double prix;

        #region Constructeurs 
        public Pizza(int quantite, double prix, string taille, string type)
        {
            this.taille = taille;
            this.type = type;
            this.quantite = quantite;
            this.prix = prix;
        }
        #endregion

        #region Propriété
        public string Type
        {
            get { return this.type; }
        }
        public string Taille
        {
            get { return this.taille; }
        }
        public int Quantite
        {
            get { return this.quantite; }
        }
        public double Prix
        {
            get { return this.prix; }
        }
        #endregion

        public override string ToString()
        {
            return this.type + " " + this.quantite +" " + this.taille + " " + this.prix;
        }
    }
}
