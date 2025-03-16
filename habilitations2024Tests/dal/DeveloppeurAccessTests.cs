using Microsoft.VisualStudio.TestTools.UnitTesting;
using habilitations2024.dal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using habilitations2024.model;

namespace habilitations2024.dal.Tests
{
    [TestClass()]
    public class DeveloppeurAccessTests
    {
        [TestMethod()]
        public void DeveloppeurAccessTest()
        {

        }

        [TestMethod()]
        public void ControleAuthentificationTest()
        {

        }

        [TestMethod()]
        public void GetLesDeveloppeursTest()
        {
            //choix du profil à tester
            int idProfilSelectionne = 2;

            DeveloppeurAccess developpeurAccess = new DeveloppeurAccess();

            //Récupérer la liste de développeurs avec un idprofil de 2
            List<Developpeur>result = developpeurAccess.GetLesDeveloppeurs(idProfilSelectionne);

            // Nombre de développeurs avec ce profil dans la bdd
            int nbAttendu = 3;

            // Assert : Vérifier que le nombre de développeurs retourné est correct
            Assert.AreEqual(nbAttendu, result.Count, "Le nombre de développeurs retourné est incorrect.");

        }

        [TestMethod()]
        public void GetLesDeveloppeursTestAucunProfil()
        {
            //choix de 0 qui correspond à aucun profil donc tous les développeurs
            int idProfilSelectionne = 0;

            DeveloppeurAccess developpeurAccess = new DeveloppeurAccess();

            //Récupérer la liste de développeurs
            List<Developpeur> result = developpeurAccess.GetLesDeveloppeurs(idProfilSelectionne);

            //Nombre de développeurs dans la base de données
            int nbrDevTotal = 20;

            Assert.AreEqual(nbrDevTotal, result.Count, "Le nombre de développeurs retourné ne correspond pas à celui de la base de données."); ;
        }

        [TestMethod()]
        public void SuppDeveloppeurTest()
        {

        }

        [TestMethod()]
        public void AjoutDeveloppeurTest()
        {

        }

        [TestMethod()]
        public void ModifDeveloppeurTest()
        {

        }

        [TestMethod()]
        public void ModifPwdTest()
        {

        }
    }
}