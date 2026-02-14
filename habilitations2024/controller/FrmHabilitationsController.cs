using habilitations2024.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using habilitations2024.dal;
using System.Text.RegularExpressions;

namespace habilitations2024.controller
{
    public class FrmHabilitationsController
    {
        //object d'accès aux opérations possibles sur Developpeur
        private readonly DeveloppeurAccess developpeurAccess;
        //objet d'accès aux opérations possibles sur Profil
        private readonly ProfilAccess profilAccess;

        //Récupère les accès aux données
        public FrmHabilitationsController()
        {
            developpeurAccess = new DeveloppeurAccess();
            profilAccess = new ProfilAccess();
        }

        //Récupère et retourne la liste des développeurs en fonction d'un profil sélectionné, ce qui permet de filtrer les développeurs selon leur profil
        public List<Developpeur> GetLesDeveloppeurs(int idProfilSelectionne)
        {
            return developpeurAccess.GetLesDeveloppeurs(idProfilSelectionne);
        }

        //Récupère et retourne la liste des des profils
        public List<Profil> GetLesProfils()
        {
            return profilAccess.GetLesProfils();
        }

        //Demande de suppression d'un développeur
        public void SuppDeveloppeur(Developpeur developpeur)
        {
            developpeurAccess.SuppDeveloppeur(developpeur);
        }

        //Demande d'ajout d'un développeur
        public void AjoutDeveloppeur(Developpeur developpeur)
        {
            developpeurAccess.AjoutDeveloppeur(developpeur);
        }

        //Demande de modification d'un développeur
        public void ModifDeveloppeur(Developpeur developpeur)
        {
            developpeurAccess.ModifDeveloppeur(developpeur);
        }

        //Demande d'un changement de mdp
        public void ModifPwd(Developpeur developpeur)
        {
            developpeurAccess.ModifPwd(developpeur);
        }

        /// <summary>
        /// Conrtôle si le pwd respecte les règles :
        /// au moins une minuscule, une majuscule, un chiffre, un caractère spécial, pas d'espace
        /// et longueur entre 8 et 30 caractères
        /// </summary>
        /// <param name="pwd"></param>
        /// <returns></returns>
        public bool PwdFort(string pwd)
        {
            //initialisation d'une variable de type TimeSpan pour définir un délai d'attente raisonnable
            TimeSpan timeout = TimeSpan.FromMilliseconds(100);
            try
            {
                if (pwd.Length < 8 && pwd.Length > 30)
                    return false;
                if (!Regex.IsMatch(pwd, @"[a-z]", RegexOptions.None, timeout))
                    return false;
                if (!Regex.IsMatch(pwd, @"[A-Z]", RegexOptions.None, timeout))
                    return false;
                if (!Regex.IsMatch(pwd, @"[0-9]", RegexOptions.None, timeout))
                    return false;
                if (!Regex.IsMatch(pwd, @"\W", RegexOptions.None, timeout))
                    return false;
                if (Regex.IsMatch(pwd, @"\s", RegexOptions.None, timeout))
                    return false;
                return true;
            }
            catch (RegexMatchTimeoutException)
            {
                return false;
            }
        }
    }
}
