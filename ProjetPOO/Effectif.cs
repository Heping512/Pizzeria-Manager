using System;
using System.Collections.Generic;
using System.Text;

namespace ProjetPOO
{
    abstract class Effectif : Personne
    {
        string etat;

        #region Constructeurs
        public Effectif(string nom, string prenom, string adresse, int numTel,string ville ,string etat) : base(nom,prenom,adresse,numTel,ville)
        {
            this.etat = etat;
        }
        #endregion

        #region Propriété
        public string Etat
        {
            get { return this.etat; }
            set { this.etat = value; }
        }
        #endregion

        public override string ToString()
        {
            return base.ToString() + " " +this.etat;
        }

        public void ChangerEtat(string a)
        {
            this.etat = a;
        }


    }
}
