using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using habilitations2024.model;
using Serilog;

namespace habilitations2024.dal
{
    /// <summary>
    /// Cette classe a pour rôle de construire les requêtes en lien avec la table Developpeur, donc en exploitant la classe Développeur
    /// </summary>
    public class DeveloppeurAccess
    {
        //Instance unique de l'accès aux données
        private readonly Access access = null;

        /// <summary>
        /// Constructeur pour créer l'accès aux données
        /// </summary>
        public DeveloppeurAccess()
        {
            access = Access.GetInstance();
        }

        /// <summary>
        /// Construit une requête pour chercher un développeur correspondant aux critères (meme nom, prenom, pwd et de profil admin) pour se connecter
        /// </summary>
        /// <param name="admin">Recoit en paramètre un objet de type Admin contenant nom, prenom, mot de passe </param>
        /// <returns>Vrai si l'utilisateur a le profil admin</returns>
        public Boolean ControleAuthentification(Admin admin)
        {
            //Vérification que la connexion à la base de données est bien établie
            if (access.Manager != null)
            {
                //Construction de la requête SQL
                string req = "SELECT * FROM developpeur d JOIN profil p ON d.idprofil=p.idprofil ";
                req += "WHERE d.nom=@nom AND d.prenom=@prenom AND d.pwd AND p.nom='admin';";
                //Création d'un dictionnaire pour stocker les paramètres de la requête SQL pour éviter injections SQL
                Dictionary<string,object> parameters = new Dictionary<string, object> {
                    { "@nom", admin.Nom },
                    { "@prenom", admin.Prenom },
                    { "@pwd", admin.Pwd }
                };

                try
                { 
                    //Tentative d'exécution  de la requête SQL et retourne une liste de tableaux d'objets
                    List<Object[]> records = access.Manager.ReqSelect(req, parameters);
                    //Vérification que la requête retourne un résultat
                    if (records != null)
                    {
                        //Si la liste contient au moins un enregistrement, c'est que l'authentification est correcte et que l'utilisateur est admin
                        return (records.Count > 0);
                    }
                }
                catch(Exception e)
                {
                    //En cas d'erreur pendant la rrquête, affiche message d'erreur dans la console
                    Console.WriteLine(e.Message);
                    //Log l'erreur avec Serilog, niveau "Error", on note la requête utilisé et le message d'erreur
                    Log.Error("DeveloppeurAccess.ControleAuthentification catch req={0} erreur={1}", req, e.Message);
                    //Termine le programme
                    Environment.Exit(0);
                }
            }
            return false;
        }

        /// <summary>
        /// Récupère et retourne les développeurs
        /// </summary>
        /// <returns></returns>
        public List<Developpeur> GetLesDeveloppeurs(int idProfilSelectionne)
        {
            //Initialisation d'une liste d'objets vide, de type developpeur, pour la remplir par la suite à partir de requête sur la bdd
            List<Developpeur> lesDeveloppeurs = new List<Developpeur>();
            //Vérification que la connexion à la base de données est bien établie
            if (access.Manager != null)
            {
                //Construction de la requête SQL
                string req = "SELECT d.iddeveloppeur AS iddeveloppeur, d.nom AS nom, d.prenom AS prenom, d.tel AS tel, d.mail AS mail, p.idprofil AS idprofil, p.nom AS profil ";
                req += "FROM developpeur d JOIN profil p ON (d.idprofil = p.idprofil) ";
                
                //Si un profil est sélectionné, on ajoute une condition pour récupérer seulement les développeurs correspondant au profil
                //Si aucun profil n'est sélectionné, tous les développeurs seront affichés
                if (idProfilSelectionne!=0)
                {
                    req += "WHERE d.idprofil = @profilId ";
                }

                //Trié par nom puis par prénom
                req += "ORDER BY nom, prenom;";

                //Création d'un dictionnaire pour stocker les paramètres de la requête SQL
                Dictionary<string, object> typeProfil = new Dictionary<string, object>();
                //Si un profil est sélectionné, on ajoute le paramètre correspondant à la requête
                if (idProfilSelectionne != 0)
                {
                    typeProfil.Add("@profilId", idProfilSelectionne);
                }

                //Tentative d'exécution  de la requête SQL
                try
                {
                    //Exécution requête via la ReqSelect et récupération des résultats dans une liste d'objets
                    List<Object[]> records = access.Manager.ReqSelect(req, typeProfil);
                    //Vérification que la requête retourne un résultat
                    if (records != null)
                    {
                        Log.Debug("DeveloppeurAccess.GetLesDeveloppeurs nombre enregistrements={0}", records.Count);
                        //boucle sur chaque enregistrement retourné par la bdd tant qu'il y a un résultat
                        foreach (Object[] record in records)
                        {
                            Log.Debug("DeveloppeurAccess.GetLesDeveloppeurs Profi id={0} nom={1}", record[5], record[6]);
                            Log.Debug("DeveloppeurAccess.GetLesDeveloppeurs Developpeur : id={0} nom={1} prenom={2} tel={3} mail={4}", record[0], record[1], record[2], record[3], record[4]);
                            //Création d'un objet profil à partir des informations récupérées
                            Profil profil = new Profil((int)record[5], (string)record[6]);
                            //Création d'un objet developpeur à partir des informations récupérées
                            Developpeur developpeur = new Developpeur((int)record[0], (string)record[1], (string)record[2], (string)record[3], (string)record[4], "",profil);
                            //Ajout du développeur à la liste lesDeveloppeurs
                            lesDeveloppeurs.Add(developpeur);
                        }
                    }
                }
                //Gestion des erreurs
                catch (Exception e)
                {
                    Log.Error("DeveloppeurAccess.GetLesDeveloppeurs catch req={0} erreur={1}", req, e.Message);
                    Console.WriteLine(e.Message);
                    Environment.Exit(0);
                }
            }
            //Retourne la liste des développeurs récupérés
            return lesDeveloppeurs;
        }

        /// <summary>
        /// Demande de suppression d'un développeur
        /// </summary>
        /// <param name="developpeur"></param>
        public void SuppDeveloppeur(Developpeur developpeur)
        {
            if (access.Manager != null)
            {
                string req = "delete from developpeur where iddeveloppeur = @iddeveloppeur;";
                Dictionary<string, object> parameters = new Dictionary<string, object>()
                {
                    { "@iddeveloppeur", developpeur.Iddeveloppeur }
                };
                try
                {
                    access.Manager.ReqUpdate(req, parameters);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    Log.Error("DeveloppeurAccess.SuppDeveloppeur catch req={0} erreur={1}", req, e.Message);
                    Environment.Exit(0);
                }
            }
        }

        /// <summary>
        /// Demande d'ajout d'un développeur
        /// </summary>
        /// <param name="developpeur"></param>
        public void AjoutDeveloppeur(Developpeur developpeur)
        {
            if (access.Manager != null)
            {
                string req = "INSERT INTO developpeur(nom, prenom, tel, mail, pwd, idprofil)";
                req += " VALUES (@nom, @prenom, @tel, @mail, SHA2(@pwd, 256), @idprofil);";
                Dictionary<string, object> parameters = new Dictionary<string, object> {
                    { "@nom", developpeur.Nom },
                    { "@prenom", developpeur.Prenom },
                    { "@tel", developpeur.Tel },
                    { "@mail", developpeur.Mail },
                    { "@pwd", developpeur.Pwd },
                    { "@idprofil", developpeur.Profil.Idprofil }
                };
                try
                {
                    access.Manager.ReqUpdate(req,parameters);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    Log.Error("DeveloppeurAccess.AjoutDeveloppeur catch req={0} erreur={1}", req, e.Message);
                    Environment.Exit(0);
                }
            }

        }

        /// <summary>
        /// Demande de modification d'un développeur
        /// </summary>
        /// <param name="developpeur"></param>
        public void ModifDeveloppeur(Developpeur developpeur)
        {
            if(access.Manager != null)
            {
                string req = "UPDATE developpeur SET nom = @nom, prenom = @prenom, tel = @tel, mail = @mail, idprofil = @idprofil WHERE iddeveloppeur = @iddeveloppeur;";
                Dictionary<string, object> parameters = new Dictionary<string, object> {
                    { "@iddeveloppeur", developpeur.Iddeveloppeur },
                    { "@nom", developpeur.Nom},
                    { "@prenom", developpeur.Prenom},
                    { "@tel", developpeur.Tel},
                    { "@mail", developpeur.Mail},
                    { "@idprofil", developpeur.Profil.Idprofil}
                };
                try
                {
                    access.Manager.ReqUpdate(req, parameters);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    Log.Error("DeveloppeurAccess.ModifDeveloppeur catch req={0} erreur={1}", req, e.Message);
                    Environment.Exit(0);
                }
            }
        }

        /// <summary>
        /// Demande de modification du pwd
        /// </summary>
        /// <param name="developpeur"></param>
        public void ModifPwd(Developpeur developpeur)
        {
            if (access.Manager != null)
            {
                string req = "update developpeur set pwd = SHA2(@pwd,256) ";
                req += "where iddeveloppeur = @iddeveloppeur;";
                Dictionary<string, object> parameters = new Dictionary<string, object> {
                    { "@idDeveloppeur", developpeur.Iddeveloppeur },
                    { "@pwd", developpeur.Pwd}
                };

                try
                {
                    access.Manager.ReqUpdate(req, parameters);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    Log.Error("DeveloppeurAccess.ModifPwd catch req={0} erreur={1}", req, e.Message);
                    Environment.Exit(0);
                }
            }
        }
    }
}
