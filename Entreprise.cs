using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ProjetPOO
{
    class Entreprise : IMoyenne
    {

        List<Client> clients;
        List<Commis> commis;
        List<Livreur> livreurs;
        List<Commande> commandes;
        double caisse;

        public delegate void SauvegarderFichier(string a);


        public Entreprise()
        {
            this.clients = new List<Client>();
            this.commis = new List<Commis>();
            this.livreurs = new List<Livreur>();
            this.commandes = new List<Commande>();
            this.caisse = 0;
        }

        #region Propriété  
        public List<Client> Clients
        {
            get { return this.clients; }
        }
        public List<Livreur> Livreurs
        {
            get { return this.livreurs; }
        }
        public List<Commis> Commis
        {
            get { return this.commis; }
            set { this.commis = value; }
        }
        public List<Commande> Commandes
        {
            get { return this.commandes; }
            set { this.commandes = value; }
        }
        public double Caisse
        {
            get { return this.caisse; }
            set { this.caisse = value; }
        }
        #endregion

        #region Les Fichiers Déléguation 
        
        public void LectureCleitn(string nomfichier)
        {
            //SortedList<int, Client> Cli = null;
            StreamReader lecture = null;
            try
            {
                lecture = new StreamReader(nomfichier);
                this.clients = new List<Client>();
                string l = "";
                while ((l = lecture.ReadLine()) != null)
                {
                    string[] temp = l.Split(";");
                    string nom = temp[0];
                    string prenom = temp[1];
                    string adresse = temp[2];
                    string ville = temp[3];
                    double porteMonnaie = Convert.ToDouble(temp[5]);
                    DateTime datePremCommande = Convert.ToDateTime(temp[6]);
                    int numTel = Convert.ToInt32(temp[4]);
                    Client ctemp = new Client(nom, prenom, adresse, numTel, ville,porteMonnaie, datePremCommande);
                    this.clients.Add(ctemp);
                }
            }

            catch (FileNotFoundException e)
            {
                Console.WriteLine(e.Message);
            }
            catch (IOException e)
            {
                Console.WriteLine(e.Message);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            { if (lecture != null) lecture.Close(); }
        }
        

        #region Sauvegarde commis
        public void SauvegarderCommis(string nomFichier)
        {
            Console.WriteLine("Sauvegarde Commis");
            Console.WriteLine("Quel mode de tri ? \n0=Par numéro de téléphone \n1=Par nom \n2=ParVille \n3=Par date d'embauche");
            int modeTri = Convert.ToInt32(Console.ReadLine());
            // 0 = numero de telephone 
            // 1 = nom
            //2 = ville
            // 3 = Date 
            if(modeTri == 0)
            {
                SortedList<int, Commis> s = new SortedList<int, Commis>();
                for (int i = 0; i< this.commis.Count; i++)
                {
                    s[i] = this.commis[i];
                }
                StreamWriter Commis = new StreamWriter(nomFichier, true);
                for (int i = 0; i < s.Count; i++)
                {
                    string ligne = Convert.ToString(s.ElementAt(i).Value.Nom) + ";" + s.ElementAt(i).Value.Prenom + ";" + s.ElementAt(i).Value.Adresse + ";" + Convert.ToString(s.ElementAt(i).Value.NumTel) + ";" + s.ElementAt(i).Value.Etat + ";" + Convert.ToString(s.ElementAt(i).Value.DateEmb) + ";" + Convert.ToString(s.ElementAt(i).Value.NbrDeCommandeGerees) +";";
                    Commis.Write(ligne);
                    Commis.WriteLine();
                }
                Commis.Close();
            }
            if(modeTri == 1)
            {
                this.commis.Sort();
                StreamWriter Commis = new StreamWriter(nomFichier, true);
                for (int i = 0; i < this.commis.Count; i++)
                {
                    string ligne = Convert.ToString(commis.ElementAt(i).Nom) + ";" + commis.ElementAt(i).Prenom + ";" + commis.ElementAt(i).Adresse + ";" + Convert.ToString(commis.ElementAt(i).NumTel) + ";" + commis.ElementAt(i).Etat + ";" + Convert.ToString(commis.ElementAt(i).DateEmb) + ";" + commis.ElementAt(i).NbrDeCommandeGerees +";";
                    Commis.Write(ligne);
                    Commis.WriteLine();
                }
                Commis.Close();
            }
            if (modeTri == 2)
            {
                this.commis.Sort(this.commis[0].CompareToVille);
                StreamWriter Commis = new StreamWriter(nomFichier, true);
                for (int i = 0; i < this.commis.Count; i++)
                {
                    string ligne = Convert.ToString(commis.ElementAt(i).Nom) + ";" + commis.ElementAt(i).Prenom + ";" + commis.ElementAt(i).Adresse + ";" + Convert.ToString(commis.ElementAt(i).NumTel) + ";" + commis.ElementAt(i).Etat + ";" + Convert.ToString(commis.ElementAt(i).DateEmb) + ";" + commis.ElementAt(i).NbrDeCommandeGerees + ";";
                    Commis.Write(ligne);
                    Commis.WriteLine();
                }
                Commis.Close();
            }
            if (modeTri ==3)
            {
                this.commis.Sort(this.commis[0].CompareToDate);
                StreamWriter Commis = new StreamWriter(nomFichier, true);
                for (int i = 0; i < this.commis.Count; i++)
                {
                    string ligne = Convert.ToString(commis.ElementAt(i).Nom) + ";" + commis.ElementAt(i).Prenom + ";" + commis.ElementAt(i).Adresse + ";" + Convert.ToString(commis.ElementAt(i).NumTel) + ";" + commis.ElementAt(i).Etat + ";" + Convert.ToString(commis.ElementAt(i).DateEmb) + ";" + commis.ElementAt(i).NbrDeCommandeGerees + ";";
                    Commis.Write(ligne);
                    Commis.WriteLine();
                }
                Commis.Close();
            }
        }

        #endregion

        #region Sauvegarde Client
        public void SauvegarderClient(string nomFichier)
        {
            Console.WriteLine("Sauvegarde Client");
            Console.WriteLine("Quel mode de tri ? \n0=Par numéro de téléphone \n1=Par nom \n2=ParVille \n3=Par date de première commande");
            int modeTri = Convert.ToInt32(Console.ReadLine());
            // 0 = numero de telephone 
            // 1 = nom
            //2 = ville
            // 3 = Moyenne
            if (modeTri == 0)
            {
                this.clients.Sort(this.clients[0].CompareToNumeroTel);
                StreamWriter Clients = new StreamWriter(nomFichier, true);
                for (int i = 0; i < this.clients.Count; i++)
                {
                    string ligne = clients.ElementAt(i).Nom + ";" + clients.ElementAt(i).Prenom + ";" + clients.ElementAt(i).Adresse + ";" + clients.ElementAt(i).Ville + ";" + Convert.ToString(clients.ElementAt(i).NumTel) + ";" + Convert.ToString(clients.ElementAt(i).PorteMonnaie) + ";" + Convert.ToString(clients.ElementAt(i).DatePremCommande) + ";";
                    Clients.Write(ligne);
                    Clients.WriteLine();
                }
                Clients.Close();
            }
            if (modeTri == 1)
            {
                this.clients.Sort();
                StreamWriter Client = new StreamWriter(nomFichier, true);
                for (int i = 0; i < this.clients.Count; i++)
                {
                    string ligne = clients.ElementAt(i).Nom + ";" + clients.ElementAt(i).Prenom + ";" + clients.ElementAt(i).Adresse + ";" + clients.ElementAt(i).Ville + ";" + Convert.ToString(clients.ElementAt(i).NumTel) + ";" + Convert.ToString(clients.ElementAt(i).PorteMonnaie) + ";" + Convert.ToString(clients.ElementAt(i).DatePremCommande) + ";" ;
                    Client.Write(ligne);
                    Client.WriteLine();
                }
                Client.Close();
            }
            if (modeTri == 2)
            {
                this.clients.Sort(this.clients[0].CompareToVille);
                StreamWriter Client = new StreamWriter(nomFichier, true);
                for (int i = 0; i < this.clients.Count; i++)
                {
                    string ligne = clients.ElementAt(i).Nom + ";" + clients.ElementAt(i).Prenom + ";" + clients.ElementAt(i).Adresse + ";" + clients.ElementAt(i).Ville + ";" + Convert.ToString(clients.ElementAt(i).NumTel) + ";" + Convert.ToString(clients.ElementAt(i).PorteMonnaie) + ";" + Convert.ToString(clients.ElementAt(i).DatePremCommande) + ";" ;
                    Client.Write(ligne);
                    Client.WriteLine();
                }
                Client.Close();
            }
            if (modeTri == 3)
            {
                this.clients.Sort(this.clients[0].CompareMontant);
                StreamWriter Client = new StreamWriter(nomFichier, true);
                for (int i = 0; i < this.clients.Count; i++)
                {
                    string ligne = clients.ElementAt(i).Nom + ";" + clients.ElementAt(i).Prenom + ";" + clients.ElementAt(i).Adresse + ";" + clients.ElementAt(i).Ville + ";" + Convert.ToString(clients.ElementAt(i).NumTel) + ";" + Convert.ToString(clients.ElementAt(i).PorteMonnaie) + ";" + Convert.ToString(clients.ElementAt(i).DatePremCommande) + ";";
                    Client.Write(ligne);
                    Client.WriteLine();
                }
                Client.Close();
            }
            
        }

        #endregion

        #region Sauvegarde Livreur 
        public void SauvegarderLivreur(string nomFichier)
        {
            Console.WriteLine("Sauvegarde Livreur");
            Console.WriteLine("Quel mode de tri ? \n0=Par numéro de téléphone \n1=Par nom \n2=ParVille \n3=Par numéro de livreur");
            int modeTri = Convert.ToInt32(Console.ReadLine());
            if (modeTri == 0)
            {
                SortedList<int, Livreur> s = new SortedList<int, Livreur>();
                for (int i = 0; i < this.livreurs.Count; i++)
                {
                    s[i] = this.livreurs[i];
                }
                StreamWriter Livreur = new StreamWriter(nomFichier, true);
                for (int i = 0; i < s.Count; i++)
                {
                    string ligne = s.ElementAt(i).Value.Nom + ";" + s.ElementAt(i).Value.Prenom + ";" + s.ElementAt(i).Value.Adresse + ";" + Convert.ToString(s.ElementAt(i).Value.NumTel) + ";" + s.ElementAt(i).Value.Etat + ";" + Convert.ToString(s.ElementAt(i).Value.Numero) + ";" + s.ElementAt(i).Value.Transport + ";" + Convert.ToString(s.ElementAt(i).Value.NbrDeLivraisonEffec) +";";
                    Livreur.Write(ligne);
                    Livreur.WriteLine();
                }
                Livreur.Close();
            }
            if (modeTri == 1)
            {
                this.livreurs.Sort();
                StreamWriter Livreur = new StreamWriter(nomFichier, true);
                for (int i = 0; i < this.livreurs.Count; i++)
                {
                    string ligne = livreurs.ElementAt(i).Nom + ";" + livreurs.ElementAt(i).Prenom + ";" + livreurs.ElementAt(i).Adresse + ";" + Convert.ToString(livreurs.ElementAt(i).NumTel) + ";" + livreurs.ElementAt(i).Etat + ";" + Convert.ToString(livreurs.ElementAt(i).Numero) + ";" + livreurs.ElementAt(i).Transport + ";" + Convert.ToString(livreurs.ElementAt(i).NbrDeLivraisonEffec)+";" ;
                    Livreur.Write(ligne);
                    Livreur.WriteLine();
                }
                Livreur.Close();
            }
            if(modeTri == 2)
            {
                this.livreurs.Sort(this.livreurs[0].CompareToVille);
                StreamWriter Livreur = new StreamWriter(nomFichier, true);
                for (int i = 0; i < this.livreurs.Count; i++)
                {
                    string ligne = livreurs.ElementAt(i).Nom + ";" + livreurs.ElementAt(i).Prenom + ";" + livreurs.ElementAt(i).Adresse + ";" + Convert.ToString(livreurs.ElementAt(i).NumTel) + ";" + livreurs.ElementAt(i).Etat + ";" + Convert.ToString(livreurs.ElementAt(i).Numero) + ";" + livreurs.ElementAt(i).Transport + ";" + Convert.ToString(livreurs.ElementAt(i).NbrDeLivraisonEffec) + ";";
                    Livreur.Write(ligne);
                    Livreur.WriteLine();
                }
                Livreur.Close();
            }
            if(modeTri == 3)
            {
                this.livreurs.Sort(this.livreurs[0].CompareToNum);
                StreamWriter Livreur = new StreamWriter(nomFichier, true);
                for (int i = 0; i < this.livreurs.Count; i++)
                {
                    string ligne = livreurs.ElementAt(i).Nom + ";" + livreurs.ElementAt(i).Prenom + ";" + livreurs.ElementAt(i).Adresse + ";" + Convert.ToString(livreurs.ElementAt(i).NumTel) + ";" + livreurs.ElementAt(i).Etat + ";" + Convert.ToString(livreurs.ElementAt(i).Numero) + ";" + livreurs.ElementAt(i).Transport + ";" + Convert.ToString(livreurs.ElementAt(i).NbrDeLivraisonEffec) + ";";
                    Livreur.Write(ligne);
                    Livreur.WriteLine();
                }
                Livreur.Close();
            }
            
        }

        #endregion

        #region Sauvegarde Commandes 
        public void SauvegarderCommande(string nomFichier)
        {
            Console.WriteLine("Sauvegarde Commandes");
            Console.WriteLine("Quel mode de tri ? \n0=Par numéro de commande \n1=Par solde \n2=Par statut");
            int modeTri = Convert.ToInt32(Console.ReadLine());
            if(modeTri == 0)
            {
                SortedList<int, Commande> s = new SortedList<int, Commande>();
                for (int i = 0; i < this.commandes.Count; i++)
                {
                    s[i] = this.commandes[i];
                }
                StreamWriter Commande = new StreamWriter(nomFichier, true);
                for (int i = 0; i < this.commandes.Count; i++)
                {
                    string ligne = Convert.ToString(s.ElementAt(i).Value.NumTelClient) + ";" + Convert.ToString(s.ElementAt(i).Value.Date.Hour + ":" + s.ElementAt(i).Value.Date.Second) + ";" + Convert.ToString(s.ElementAt(i).Value.Date.Date) + ";" + Convert.ToString(s.ElementAt(i).Value.NumTelClient) + ";" + s.ElementAt(i).Value.AdresseClient + ";" + s.ElementAt(i).Value.NomCommis + ";" + s.ElementAt(i).Value.NomLivreur + ";" + s.ElementAt(i).Value.Statut + ";" + s.ElementAt(i).Value.Solde + ";";
                    Commande.Write(ligne);
                    Commande.WriteLine();
                }
                Commande.Close();
            }
            if(modeTri == 1)
            {
                this.commandes.Sort(this.commandes[0].CompareToSolde);
                StreamWriter Commande = new StreamWriter(nomFichier, true);
                for (int i = 0; i < this.commandes.Count; i++)
                {
                    string ligne = Convert.ToString(commandes.ElementAt(i).NumTelClient) + ";" + Convert.ToString(commandes.ElementAt(i).Date.Hour + ":" + commandes.ElementAt(i).Date.Second) + ";" + Convert.ToString(commandes.ElementAt(i).Date.Date) + ";" + Convert.ToString(commandes.ElementAt(i).NumTelClient) + ";" + commandes.ElementAt(i).AdresseClient + ";" + commandes.ElementAt(i).NomCommis + ";" + commandes.ElementAt(i).NomLivreur + ";" + commandes.ElementAt(i).Statut + ";" + commandes.ElementAt(i).Solde + ";";
                    Commande.Write(ligne);
                    Commande.WriteLine();
                }
                Commande.Close();
            }
            if(modeTri == 2)
            {
                this.commandes.Sort(this.commandes[0].CompareToStatut);
                StreamWriter Commande = new StreamWriter(nomFichier, true);
                for (int i = 0; i < this.commandes.Count; i++)
                {
                    string ligne = Convert.ToString(commandes.ElementAt(i).NumTelClient) + ";" + Convert.ToString(commandes.ElementAt(i).Date.Hour + ":" + commandes.ElementAt(i).Date.Second) + ";" + Convert.ToString(commandes.ElementAt(i).Date.Date) + ";" + Convert.ToString(commandes.ElementAt(i).NumTelClient) + ";" + commandes.ElementAt(i).AdresseClient + ";" + commandes.ElementAt(i).NomCommis + ";" + commandes.ElementAt(i).NomLivreur + ";" + commandes.ElementAt(i).Statut + ";" + commandes.ElementAt(i).Solde + ";";
                    Commande.Write(ligne);
                    Commande.WriteLine();
                }
                Commande.Close();
            }
            
        }
        #endregion 

        public void SauvFichier(SauvegarderFichier s,string nomFichier)
        {
            s(nomFichier);
        }
        
        #endregion 

        public double Moyenne()
        {
            double somme = 0;
            List<Commande> s = this.commandes as List<Commande>;
            for (int i = 0; i < s.Count; i++)
            {
                somme = somme + s[i].CalculPrix();
            }
            return somme / s.Count;
        }

        public string AffichageCommandeSelonPeriode(DateTime debut, DateTime fin)
        {
            string a = "";
            for (int i = 0; i < this.commandes.Count; i++)
            {
                if (DateTime.Compare(this.commandes[i].Date, debut) > 0)
                {
                    if (DateTime.Compare(this.commandes[i].Date, fin) < 0)
                    {
                        a = a + this.commandes[i].AffichageCommande();
                    }
                }
            }
            return a;            
        }

        #region Déléguation Supprimer 
        public void SupprimerClient(Client client)
        {
            this.clients.Remove(client);
        }

        public void SupprimerCommis(Commis commis)
        {
            this.commis.Remove(commis);
        }

        public void SupprimerLivreur(Livreur livreur)
        {
            this.livreurs.Remove(livreur);
        }

        #endregion

        #region Entreés 
        public Client CreationClient(string nom, string prenom, string adresse, int num,string ville, double porte)
        {
            Client c = new Client(nom, prenom, adresse, num,ville ,porte, DateTime.Today);
            this.clients.Add(c);
            return c;
        }

        public Commis CreationCommis(string nom, string prenom, string adresse, int num,string ville, string etat)
        {
            Commis c = new Commis(nom, prenom, adresse, num,ville, etat, DateTime.Now);
            this.commis.Add(c);
            return c;
        }

        public Livreur CreationLivreur(string nom, string prenom, string adresse, int numTel,string ville, string etat,int num,string transport)
        {
            Livreur l = new Livreur(nom, prenom, adresse, numTel,ville, etat, num,transport);
            this.livreurs.Add(l);
            return l;
        }
        #endregion

        #region Modif

        public void ModificationClient(Client c)
        {
            Console.WriteLine("Que voulez vous modifier ? \n0=adresse \n1=numéro de téléphone ");
            int res = Convert.ToInt32(Console.ReadLine());
            if(res==0)
            {
                Console.WriteLine("Quel est la nouvelle adresse ?");
                c.Adresse = Console.ReadLine();
                Console.WriteLine("Ville ?");
                c.Ville = Console.ReadLine();
            }
            if (res == 1)
            {
                Console.WriteLine("Quel est le nouveau numéro ?");
                c.NumTel = Convert.ToInt32(Console.ReadLine());
            }
        }

        public void ModificationCommis(Commis c)
        {
            Console.WriteLine("Que voulez vous modifier ? \n0=adresse \n1=numéro de téléphone \n2=Etat ");
            int res = Convert.ToInt32(Console.ReadLine());
            if (res == 0)
            {
                Console.WriteLine("Quel est la nouvelle adresse ?");
                c.Adresse = Console.ReadLine();
                Console.WriteLine("Ville ?");
                c.Ville = Console.ReadLine();
            }
            if (res == 1)
            {
                Console.WriteLine("Quel est le nouveau numéro ?");
                c.NumTel = Convert.ToInt32(Console.ReadLine());
            }
            if (res == 2)
            {
                Console.WriteLine("Quel est son nouvaeu statut ?");
                c.Etat = Console.ReadLine();
            }
        }

        public void ModificationLivreur(Livreur c)
        {
            Console.WriteLine("Que voulez vous modifier ? \n0=adresse \n1=numéro de téléphone \n2=Etat \n3=mode de transport");
            int res = Convert.ToInt32(Console.ReadLine());
            if (res == 0)
            {
                Console.WriteLine("Quel est la nouvelle adresse ?");
                c.Adresse = Console.ReadLine();
                Console.WriteLine("Ville ?");
                c.Ville = Console.ReadLine();
            }
            if (res == 1)
            {
                Console.WriteLine("Quel est le nouveau numéro ?");
                c.NumTel = Convert.ToInt32(Console.ReadLine());
            }
            if (res == 2)
            {
                Console.WriteLine("Quel est son nouvaeu statut ?");
                c.Etat = Console.ReadLine();
            }
            if (res == 3)
            {
                Console.WriteLine("Quel est son nouvaeu mode de transport ?");
                c.Transport = Console.ReadLine();
            }
        }

        #endregion
        public string AffichageCommande(int num)
        {
            string a = "";
            foreach(Commande c in this.commandes)
            {
                if(c.NumCommande == num)
                {
                    a += c.AffichageCommande();
                }
            }
            return a;
        }

    }
}
