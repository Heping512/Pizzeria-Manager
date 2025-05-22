using System;
using System.Collections.Generic;
using System.Text;

namespace ProjetPOO
{
    abstract class Personne: IComparable
    {
        
        //Tous les attributs doivent apparaître 
        string nom; 
        string prenom;
        string adresse;
        int numTel;
        string ville;

        #region Constructeur
        public Personne(string nom,string prenom,string adresse, int numTel,string ville)
        {
            this.nom = nom;
            this.prenom = prenom;
            this.adresse = adresse;
            this.numTel = numTel;
            this.ville = ville;
        }
        #endregion

        #region Propriété
        public string Nom
        {
            get { return this.nom; }
        }
        public string Prenom
        {
            get { return this.prenom; }
        }
        public string Adresse
        {
            get { return this.adresse; }
            set { this.adresse = value; }
        }
        public int NumTel
        {
            get { return this.numTel; }
            set { this.numTel = value; }
        }
        public string Ville
        {
            get { return this.ville; }
            set { this.ville = value; }
        }
        #endregion

        public override string ToString()
        {
            return this.nom + " " + this.prenom + " " + this.adresse + " " + this.numTel;
        }

        #region déléguation Comparaison 
        public int CompareTo(object obj)
        {
            Personne c = obj as Personne;
            return this.Nom.CompareTo(c.Nom);
        }

        public int CompareToVille(Personne a,Personne b)
        {
            return a.Ville.CompareTo(b.Ville);
        }

        public int CompareToNumeroTel(Personne a,Personne b)
        {
            return a.NumTel.CompareTo(b.NumTel);
        }
        #endregion

    }
}
