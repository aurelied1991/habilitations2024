using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using habilitations2024.bddmanager;

namespace habilitations2024.dal
{
    /// <summary>
    /// Classe sollicitée par ProfilAccess et DeveloppeurAccess pour récupérer toujours la même connexion unique ) la BDD
    /// </summary>
    public class Access
    {
        //Chaîne de connexion à la bdd
        private static readonly string connectionString = "server=localhost; user id=habilitations; password=motdepasseuser; database=habilitations;";
        //Propriété qui contiendra l'unique instance de la classe
        private static Access instance = null;
        //Getter sur l'objet d'accès aux données
        public BddManager Manager { get; }

        /// <summary>
        /// Création unique de l'objet unique de type BddManager en récupérer instance de getInstance dans Manager, arrête le programme si pas possible d'accéder à la bdd
        /// </summary>
        private Access()
        {
            try
            {
                Manager = BddManager.GetInstance(connectionString);
            }
            catch(Exception)
            {
                //Environment.Exit(0);
            }
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
