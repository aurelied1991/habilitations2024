using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace habilitations2024.model
{

    /// <summary>
    /// Permet de mémoriser en interne les informations de connexion
    /// </summary>
    public class Admin
    {
        public string Nom { get; }
        public string Prenom { get; }
        public string Pwd {  get; }

        /// <summary>
        /// Constructeur pour valoriser les propriétés
        /// </summary>
        /// <param name="nom"></param>
        /// <param name="prenom"></param>
        /// <param name="pwd"></param>
        public Admin(string nom, string prenom, string pwd)
        {
            this.Nom = nom;
            this.Prenom = prenom;
            this.Pwd = pwd;
        }
    }
}
