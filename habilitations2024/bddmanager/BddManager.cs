using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace habilitations2024.bddmanager
{
    public class BddManager
    {
        //propriete qui contient l'unique instance de la classe BddManager
        private static BddManager instance = null;
        //propriete qui permet de gerer une connexion MySql
        private readonly MySqlConnection connection;

        //constructeur de la classe qui recoit en paramètre une chaîne de connexion
        private BddManager(string StringConnect)
        {
            //affecte une instance de la classe à la propriété privée connection puis connexion à la bdd
            connection = new MySqlConnection(StringConnect);
            connection.Open();
        }

        //Méthode GetInstance qui permet de créer une instance de la classe uniquement si la classe n'a pas encore d'instance
        public static BddManager GetInstance(string StringConnect)
        {
            if (instance == null)
            {
                instance = new BddManager(StringConnect);
            }
            //retourne soit l'instance créée, soit l'instance déjà existante
            return instance;
        }

        /// <summary>
        /// Méthode qui exécute une requête autre que select
        /// </summary>
        /// <param name="StringQuery"> Requête SQL </param>
        /// <param name="parameters"> Dictionnaire avec les évenuels paramètres de la requête</param>
        public void reqUpdate(string StringQuery, Dictionary<string, object> parameters = null)
        {
            MySqlCommand command = new MySqlCommand(StringQuery, connection);
            if (!(parameters is null))
            {
                foreach (KeyValuePair<string, object> parameter in parameters)
                {
                    command.Parameters.Add(new MySqlParameter(parameter.Key, parameter.Value));
                }
            }
            command.Prepare();
            command.ExecuteNonQuery();
        }
    }
}   
