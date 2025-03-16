using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using habilitations2024.model;

namespace habilitations2024.dal
{
    /// <summary>
    /// Cette classe a pour rôle de construire les requêtes en lien avec la table Developpeur, donc en exploitant la classe Développeur
    /// </summary>
    public class DeveloppeurAccess
    {
        //Instance unique de l'accès aux données
        private readonly Access access = null;
        //Constructeur pour créer l'accès aux données
        public DeveloppeurAccess()
        {
            access = Access.GetInstance();
        }

        /// <summary>
        /// Construit une requête pour chercher un développeur correspondant aux critères (meme nom, prenom, pwd et de profil admin) pour se connecter
        /// </summary>
        /// <param name="admin">Recoit en paramètre un objet de type admin</param>
        /// <returns>Vrai si l'utilisateur a le profil admin</returns>
        public Boolean ControleAuthentification(Admin admin)
        {
            if(access.Manager != null)
            {
                string req = "SELECT * FROM developpeur d JOIN profil p ON d.idprofil=p.idprofil ";
                req += "WHERE d.nom=@nom AND d.prenom=@prenom AND d.pwd AND p.nom='admin';";
                Dictionary<string,object> parameters = new Dictionary<string,object>();
                parameters.Add("@nom", admin.Nom);
                parameters.Add("@prenom", admin.Prenom);
                parameters.Add("@pwd", admin.Pwd);

                try
                {
                    List<Object[]> records = access.Manager.ReqSelect(req, parameters);
                    if(records != null)
                    {
                        return(records.Count > 0);
                    }
                }
                catch(Exception e)
                {
                    Console.WriteLine(e.Message);
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
                        //boucle sur chaque enregistrement retourné par la bdd tant qu'il y a un résultat
                        foreach (Object[] record in records)
                        {
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
                Dictionary<string, object> parameters = new Dictionary<string, object>();
                parameters.Add("@iddeveloppeur", developpeur.Iddeveloppeur);
                try
                {
                    access.Manager.ReqUpdate(req, parameters);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
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
                Dictionary<string, object> parameters = new Dictionary<string, object>();
                parameters.Add("@nom", developpeur.Nom);
                parameters.Add("@prenom", developpeur.Prenom);
                parameters.Add("@tel", developpeur.Tel);
                parameters.Add("@mail", developpeur.Mail);
                parameters.Add("@pwd", developpeur.Pwd);
                parameters.Add("@idprofil", developpeur.Profil.Idprofil);

                try
                {
                    access.Manager.ReqUpdate(req,parameters);
                }
                catch (Exception e)
                {
                    MessageBox.Show("Une erreur est survenue : " + e.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    //Console.WriteLine(e.Message);
                    //Environment.Exit(0);
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
                Dictionary<string, object> parameters = new Dictionary<string, object>();
                parameters.Add("@iddeveloppeur", developpeur.Iddeveloppeur);
                parameters.Add("@nom", developpeur.Nom);
                parameters.Add("@prenom", developpeur.Prenom);
                parameters.Add("@tel", developpeur.Tel);
                parameters.Add("@mail", developpeur.Mail);
                parameters.Add("@idprofil", developpeur.Profil.Idprofil);

                try
                {
                    access.Manager.ReqUpdate(req, parameters);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
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
                Dictionary<string, object> parameters = new Dictionary<string, object>();
                parameters.Add("@idDeveloppeur", developpeur.Iddeveloppeur);
                parameters.Add("@pwd", developpeur.Pwd);

                try
                {
                    access.Manager.ReqUpdate(req, parameters);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    Environment.Exit(0);
                }
            }
        }
    }
}
