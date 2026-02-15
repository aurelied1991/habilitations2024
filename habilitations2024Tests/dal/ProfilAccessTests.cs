using habilitations2024.dal;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using habilitations2024.model;


namespace habilitations2024.dal.Tests
{
    [TestClass()]
    public class ProfilAccessTests
    {
        private static readonly Access access = Access.GetInstance();
        private static readonly ProfilAccess profilAccess = new ProfilAccess();

        private static void BeginTransaction()
        {
            access.Manager.ReqSelect("SET AUTOCOMMIT=0");
            access.Manager.ReqControle("START TRANSACTION");
            access.Manager.ReqControle("SET FOREIGN_KEY_CHECKS=0");
        }

        private static void EndTransaction()
        {
            access.Manager.ReqControle("ROLLBACK");
            access.Manager.ReqControle("SET FOREIGN_KEY_CHECKS=1");
        }

        [TestMethod()]
        public void ProfilAccessTest()
        {
            Assert.IsNotNull(access, "Devrait réussir si la connexion à la bdd est correcte");
        }

        [TestMethod()]
        public void GetLesProfilsTest()
        {
            List<Profil> lesProfils = profilAccess.GetLesProfils();
            Assert.AreNotEqual(0, lesProfils.Count, "Devrait réussir si la requête de récupération des profils est correcte et que la bdd contient au moins un profil");
        }

        [TestMethod()]
        public void AddProfilTest()
        {
            BeginTransaction();
            List<Profil> lesProfils = profilAccess.GetLesProfils();
            int nbProfilsAvant = lesProfils.Count;
            string nom = "TestProfil";
            Profil profil = new Profil(0, nom);
            profilAccess.AddProfil(profil);
            lesProfils = profilAccess.GetLesProfils();
            int nbProfilsApres = lesProfils.Count;
            Profil profilAdd = lesProfils.Find(obj => obj.Nom.Equals(nom));
            Assert.IsNotNull(profilAdd, "Devrait réussir si la requête d'ajout d'un profil est correcte et que le profil a été ajouté à la bdd");
            Assert.AreEqual(nbProfilsAvant + 1, nbProfilsApres, "Devrait réussir si la requête d'ajout d'un profil est correcte et que le nombre de profils dans la bdd a augmenté de 1");
            EndTransaction();
        }

        [TestMethod()]
        public void DelProfilTest()
        {
            BeginTransaction();
            List<Profil> lesProfils = profilAccess.GetLesProfils();
            int nbProfilsAvant = lesProfils.Count;

            if (nbProfilsAvant > 0)
            {
                Profil profil = lesProfils[2];
                profilAccess.DelProfil(profil);
                lesProfils = profilAccess.GetLesProfils();
                Profil profilDel = lesProfils.Find(obj => obj.Idprofil.Equals(profil.Idprofil));
                Assert.IsNull(profilDel, "Devrait réussir si la requête de suppression d'un profil est correcte et que le profil a été supprimé de la bdd");
                int nbProfilsApres = lesProfils.Count;
                Assert.AreEqual(nbProfilsAvant - 1, nbProfilsApres, "Devrait réussir si la requête de suppression d'un profil est correcte et que le nombre de profils dans la bdd a diminué de 1");
            }
            EndTransaction();
        }
    }
}