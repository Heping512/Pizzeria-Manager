using System;
using System.Collections.Generic;
using System.Text;

namespace ProjetPOO
{
    class Cuisinier : Personne
    {
        List<Pizza> pizzas;

        #region Constructeurs
        public Cuisinier(string nom, string prenom, string adresse, int numTel,string ville,List<Pizza> pizzas) : base(nom,prenom,adresse,numTel,ville)
        {
            this.pizzas = new List<Pizza>();
        }
        #endregion

        #region Propriété 
        public List<Pizza> Pizza
        {
            get { return this.pizzas; }
        }
        #endregion

        public Pizza CreationPizza()
        {
            Console.WriteLine("Quelle est la pizza ?");
            string type = Console.ReadLine();
            Console.WriteLine("Quelle taille ?");
            string taille = Console.ReadLine();
            Console.WriteLine("Combien de pizza " + type +" ?");
            int quat = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Quel est son prix ?");
            double prix = Convert.ToDouble(Console.ReadLine());
            Pizza p = new Pizza(quat,prix,taille, type);
            return p;
        }

    }
}
