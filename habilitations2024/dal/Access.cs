using System;
using habilitations2024.bddmanager;
using Serilog;
using System.Configuration;

namespace habilitations2024.dal
{
    /// <summary>
    /// Classe sollicitée par ProfilAccess et DeveloppeurAccess pour récupérer toujours la même connexion unique ) la BDD
    /// </summary>
    public class Access
    {
        //Nom de connexion à la bdd
        private static readonly string connectionName = "habilitations2024.Properties.Settings.habilitationsConnectionString";
        //Propriété qui contiendra l'unique instance de la classe
        private static Access instance = null;
        //Getter sur l'objet d'accès aux données
        public BddManager Manager { get; }

        /// <summary>
        /// Création unique de l'objet unique de type BddManager en récupérer instance de getInstance dans Manager, arrête le programme si pas possible d'accéder à la bdd
        /// Constructeur privé de la classe Access, créer le logger Serilog et tente d'obtenir une instance unique de BddManager
        /// Si la connexion échoue, logue une erreur fatale et arrête l'application
        /// </summary>
        private Access()
        {
            string connectionString = null;
            try
            {
                //Configuration du Logger Serilog
                Log.Logger = new LoggerConfiguration()
                    .MinimumLevel.Verbose() //Enregistrer tous les niveaux de logs
                    .WriteTo.Console() //Afficher les logs dans la console
                    .WriteTo.File("logs/log.txt") //Enregistrer les logs dans un fichier texte
                    .CreateLogger(); //Créer le logger et assignation à Log.Logger (logger global)
                connectionString = GetConnectionStringByName(connectionName);
                //Tentative de connexion à la bdd
                Manager = BddManager.GetInstance(connectionString);
            }
            catch(Exception ex)
            {
                //En cas d'échec, on enregistre un log de niveau "Fatal" (le plus critique) avec exception complète et un message formaté contenant la chaîne de connexion et le message d'erreur
                Log.Fatal(ex, "Access.Access catch connectionString={0} erreur={1}", connectionString, ex.Message);
                //Arrêt de l'application en cas d'erreur fatale de connexion à la bdd car connexion indispensable
                Environment.Exit(0);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        static string GetConnectionStringByName(string name)
        {
            string returnValue = null;
            ConnectionStringSettings settings = ConfigurationManager.ConnectionStrings[name];
            if (settings != null)
                returnValue = settings.ConnectionString;
            return returnValue;
        }

        /// <summary>
        /// Creation d'une seule instance de la classe
        /// </summary>
        /// <returns></returns>
        public static Access GetInstance()
        {
            if (instance == null)
            {
                instance = new Access();
            }
            return instance;
        }
    }
}
