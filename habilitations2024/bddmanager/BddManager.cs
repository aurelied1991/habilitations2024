using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Windows.Input;

namespace habilitations2024.bddmanager
{
    /// <summary>
    /// Singleton pour se connecter à la base de données et exécuter requêtes
    /// </summary>
    public class BddManager
    {
        //propriete qui contient l'unique instance de la classe BddManager
        private static BddManager instance = null;
        //propriete qui permet de gerer une connexion MySql
        private readonly MySqlConnection connection;

        //constructeur de la classe qui recoit en paramètre une chaîne de connexion
        private BddManager(string stringConnect)
        {
            //affecte une instance de la classe à la propriété privée connection puis connexion à la bdd
            connection = new MySqlConnection(stringConnect);
            connection.Open();
        }

        //Méthode GetInstance qui permet de créer une instance de la classe uniquement si la classe n'a pas encore d'instance
        public static BddManager GetInstance(string stringConnect)
        {
            if (instance == null)
            {
                instance = new BddManager(stringConnect);
            }
            //retourne soit l'instance créée, soit l'instance déjà existante
            return instance;
        }

        /// <summary>
        /// Méthode qui exécute une requête autre que select
        /// </summary>
        /// <param name="StringQuery"> Requête SQL </param>
        /// <param name="parameters"> Dictionnaire avec les évenuels paramètres de la requête</param>
        public void ReqUpdate(string stringQuery, Dictionary<string, object> parameters = null)
        {
            MySqlCommand command = new MySqlCommand(stringQuery, connection);
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

        /// <summary>
        /// Méthode pour exécuter requête select
        /// </summary>
        /// <param name="stringQuery"> Requête select</param>
        /// <param name="parameters"> Dictionnaire des paramètres de la requête</param>
        /// <returns> Tableaux contenants les valeurs des colonnes sélectionnées </returns>
        public List<Object[]> ReqSelect(string stringQuery, Dictionary<string, object> parameters = null)
        {
            //Exécution de la requête sur l'objet command
            MySqlCommand command = new MySqlCommand(stringQuery, connection);
            if (!(parameters is null))
            {
                foreach (KeyValuePair<string, object> parameter in parameters)
                {
                    command.Parameters.Add(new MySqlParameter(parameter.Key, parameter.Value));
                }
            }
            //Creation du curseur pour récupérer les résultats de la requête (exécute requête avec la méthode executereader sur l'objet command et retourne un curseur de type MySqlDataReader
            command.Prepare();
            MySqlDataReader reader = command.ExecuteReader();
            //Déclaration variable avec FieldCount appliqué au curseur pour récupérer le nombre de colonnes concernées
            int nbColonnes = reader.FieldCount;
            //Creation du tableau pour récupérer les valeurs
            List<Object[]> records = new List<object[]>();
            //boucle sur le curseur tant que la ligne lue contient qqch
            while (reader.Read())
            {
                //A chaque boucle, création d'un nouveau tableau d'objets
                Object[] attributs = new object [nbColonnes];
                //Remplir le tableau en une seule fois en récupérant toutes les valeurs des champs de la ligne du curseur avec l'instruction ci dessous
                reader.GetValues(attributs);
                //ajout du tableau d'objets dans la liste
                records.Add(attributs);
            }
            //fermeture du curseur
            reader.Close();
            //retourner liste de tableaux contenant les valeurs des colonnes
            return records;
        }
    }
}
