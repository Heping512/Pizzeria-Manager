using System;
using System.Collections.Generic;
using System.Text;

namespace ProjetPOO
{
    class Boisson 
    {
        string type;
        int quantite;
        double prix;
        int taille;

        #region Constructeurs
        public Boisson(int quantite , double prix, string type,int taille)
        {
            this.type = type;
            this.quantite = quantite;
            this.prix = prix;
            this.taille = taille;
        }
        #endregion

        #region Propriété
        public string Type
        {
            get { return this.type; }
        }
        public int Quantite
        {
            get { return this.quantite; }
        }
        public double Prix
        {
            get { return this.prix; }
        }
        public int Taille
        {
            get { return this.taille; }
        }
        #endregion

        public override string ToString()
        {
            return this.type + " " + this.quantite +" "+ this.prix;
        }
    }
}
