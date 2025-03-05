using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using habilitations2024.model;

namespace habilitations2024.dal
{
    /// <summary>
    /// Classe qui a pour rôle de construire les requêtes en lien avec la table Profil, donc en exploitant la classe Profil
    /// </summary>
    public class ProfilAccess
    {
        //Instance unique de l'accès aux données
        private readonly Access access = null;
        //Constructeur pour créer l'accès aux données en valorisant la propriété access en lui affectant l'instance (unique) de la classe Access
        public ProfilAccess()
        {
            access = Access.GetInstance();
        }

        /// <summary>
        /// Récupère et retourne les profils
        /// </summary>
        /// <returns></returns>
        public List<Profil> GetLesProfils()
        {
            //Création en local d'une liste d'objets de type Profil pour la remplir à partir de la bdd et la retourner
            List<Profil> lesProfils = new List<Profil> ();
            //
            if (access.Manager != null)
            {
                //enregistrement de la requête paramétrée
                string req = "SELECT * FROM profil ORDER BY nom;";
                //try/catch (de type exception) car une demande d'exécution d'une requête peut provoquer une erreur
                try
                {
                    //Demande à BddManager (via l'objet Manager de la classe Access) d'exécuter une requête qui récupère tous les profils
                    List<Object[]> records = access.Manager.ReqSelect(req);
                    //Vérifier que la liste n'est pas null puis boucler sur les objets de cette liste
                    if(records != null)
                    {
                        //A chaque tour de boucle, un objet de type Profil doit être crée en mettant les paramètres du constructeurs, les 2 cases du tableau récupéré (contenant idprofil et nom) apres les avoir correctement transtypés (car les cases sont de type object)
                        foreach(Object[] record in records)
                        {
                            Profil profil = new Profil((int)record[0], (string)record[1]);
                            //Une fois l'objet profil crée, il suffit de l'ajouter à la liste des profils 
                            lesProfils.Add(profil);
                        }
                    }
                }
                catch(Exception e)
                {
                    //affichage d'un message + arrêt de l'application en car d'erreur
                    Console.WriteLine(e.Message);
                    Environment.Exit(0);
                }
            }
            return lesProfils;
        }
    }
}
