using habilitations2024.dal;
using habilitations2024.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace habilitations2024.controller
{
    public class FrmAuthentificationController
    {
        //object d'accès aux opérations possibles sur Developpeur
        private readonly DeveloppeurAccess developpeurAccess;

        /// <summary>
        /// Récupérer les accès aux données
        /// </summary>
        public FrmAuthentificationController()
        {
            developpeurAccess = new DeveloppeurAccess();
        }

        /// <summary>
        /// Vérifie l'authentification
        /// </summary>
        /// <param name="admin">contient les infos de connexion</param>
        /// <returns> retourne vrai si les infos de connexions sont bonnes</returns>
        public Boolean ControleAuthentification(Admin admin)
        {
            return developpeurAccess.ControleAuthentification(admin);
        }
    }
}
