using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using habilitations2024.model;

namespace habilitations2024.dal.Tests
{
    [TestClass()]
    public class DeveloppeurAccessTests
    {
        private static readonly Access access = Access.GetInstance();
        private static readonly DeveloppeurAccess developpeurAccess = new DeveloppeurAccess();

        private static void BeginTransaction()
        {
            access.Manager.ReqSelect("SET AUTOCOMMIT=0");
            access.Manager.ReqControle("START TRANSACTION");
            access.Manager.ReqControle("SET FOREIGN_KEY_CHECKS=0");
        }

        private static void EndTransaction() {
            access.Manager.ReqControle("ROLLBACK");
            access.Manager.ReqControle("SET FOREIGN_KEY_CHECKS=1");
        }

        [TestMethod()]
        public void DeveloppeurAccessTest()
        {
            Assert.IsNotNull(access, "Devrait réussir si la connexion à la bdd est correcte");
        }

        [TestMethod()]
        public void ControleAuthentificationTest()
        {
            string nom = "Nolan";
            string prenom = "Rooney";
            string pwd = "Nolan";

            Assert.IsTrue(developpeurAccess.ControleAuthentification(new Admin(nom, prenom, pwd)), "Devrait réussir : données utilisateur correctes");

            string erreurNom = "No";
            string erreurPrenom = "Ro";
            string erreurPwd = "No";
            Assert.IsFalse(developpeurAccess.ControleAuthentification(new Admin(erreurNom, prenom, pwd)), "Devrait échouer : nom incorrect");
            Assert.IsFalse(developpeurAccess.ControleAuthentification(new Admin(nom, erreurPrenom, pwd)), "Devrait échouer : prénom incorrect");
            Assert.IsFalse(developpeurAccess.ControleAuthentification(new Admin(nom, prenom, erreurPwd)), "Devrait échouer : mot de passe incorrect");
        }

        [TestMethod()]
        public void GetLesDeveloppeursTest()
        {
            List<Developpeur> lesDeveloppeurs = developpeurAccess.GetLesDeveloppeurs(0);
            Assert.AreNotEqual(0, lesDeveloppeurs.Count, "Devrait réussir si la requête de récupération des développeurs est correcte et que la bdd contient au moins un développeur");
        }



        [TestMethod()]
        public void SuppDeveloppeurTest()
        {
            BeginTransaction();
            List<Developpeur> lesDeveloppeurs = developpeurAccess.GetLesDeveloppeurs(0);
            int nbDeveloppeursAvant = lesDeveloppeurs.Count;
            if(nbDeveloppeursAvant > 0)
            {
                Developpeur dev = lesDeveloppeurs[0];
                developpeurAccess.SuppDeveloppeur(dev);
                lesDeveloppeurs = developpeurAccess.GetLesDeveloppeurs(0);
                Developpeur devSupp = lesDeveloppeurs.Find(obj => obj.Iddeveloppeur.Equals(dev.Iddeveloppeur));
                Assert.IsNull(devSupp, "Devrait réussir si la requête de suppression est correcte et que le développeur a été supprimé de la bdd");
                int nbDeveloppeursApres = lesDeveloppeurs.Count;
                Assert.AreEqual(nbDeveloppeursAvant - 1, nbDeveloppeursApres, "Devrait réussir si la requête de suppression est correcte et que le nombre de développeurs a diminué de 1");
            }
            EndTransaction();
        }

        [TestMethod()]
        public void AjoutDeveloppeurTest()
        {
            BeginTransaction();
            List<Developpeur> lesDeveloppeurs = developpeurAccess.GetLesDeveloppeurs(0);
            int nbDeveloppeursAvant = lesDeveloppeurs.Count;
            string nom = "Dupont";
            string prenom = "Jean";
            string tel = "0600000000";
            string mail = "jean@dupont.fr";
            string pwd = "Dupont";
            Profil profil = new Profil(1, "stagiaire");
            Developpeur dev = new Developpeur(0, nom, prenom, tel, mail, pwd, profil);
            developpeurAccess.AjoutDeveloppeur(dev);
            lesDeveloppeurs = developpeurAccess.GetLesDeveloppeurs(0);
            int nbDeveloppeurApresAjout = lesDeveloppeurs.Count;
            Developpeur devAdd = lesDeveloppeurs.Find(obj =>
            obj.Nom.Equals(nom)
            && obj.Prenom.Equals(prenom)
            && obj.Tel.Equals(tel)
            && obj.Mail.Equals(mail)
            && obj.Profil.Idprofil.Equals(profil.Idprofil)
            && obj.Profil.Nom.Equals(profil.Nom));
            Assert.IsNotNull(devAdd, "Devrait réussir si la requête d'ajout est correcte et que le développeur a été ajouté à la bdd");
            Assert.AreEqual(nbDeveloppeursAvant + 1, nbDeveloppeurApresAjout, "Devrait réussir si la requête d'ajout est correcte et que le nombre de développeurs a augmenté de 1");
            EndTransaction();
        }

        [TestMethod()]
        public void ModifDeveloppeurTest()
        {
            BeginTransaction();
            List<Developpeur> lesDeveloppeurs = developpeurAccess.GetLesDeveloppeurs(0);
            int nbDeveloppeursAvant = lesDeveloppeurs.Count;
            if (lesDeveloppeurs.Count > 0)
            {
                Developpeur dev = lesDeveloppeurs[0];
                string nom = "Dupont";
                string prenom = "Jean";
                string tel = "0600000000";
                string mail = "jean@dupont.com";
                string pwd = "Dupont";
                Profil profil = new Profil(1, "stagiaire");
                Developpeur nouveauDev = new Developpeur(dev.Iddeveloppeur, nom, prenom, tel, mail, pwd, profil);
                developpeurAccess.ModifDeveloppeur(nouveauDev);
                lesDeveloppeurs = developpeurAccess.GetLesDeveloppeurs(0);
                int nbAfterModif = lesDeveloppeurs.Count;
                Developpeur devModif = lesDeveloppeurs.Find(obj => obj.Iddeveloppeur == dev.Iddeveloppeur);
                if (devModif != null) 
                {
                    bool identique = devModif.Nom.Equals(nom)
                        && devModif.Prenom.Equals(prenom)
                        && devModif.Tel.Equals(tel)
                        && devModif.Mail.Equals(mail)
                        && (devModif.Profil.Idprofil == profil.Idprofil)
                        && (devModif.Profil.Nom == profil.Nom);
                    Assert.AreEqual(true, identique, "Devrait réussir si la requête de modification est correcte et que le développeur a été modifié dans la bdd");
                }
                else
                {
                    Assert.Fail("Développeur perdu suite aux modifications");
                }
                Assert.AreEqual(nbDeveloppeursAvant, nbAfterModif, "Devrait réussir si la requête de modification est correcte et que le nombre de développeurs n'a pas changé");
            }
            EndTransaction();
        }

        [TestMethod()]
        public void ModifPwdTest()
        {
            BeginTransaction();
            List<Developpeur> lesDeveloppeurs = developpeurAccess.GetLesDeveloppeurs(0);
            if (lesDeveloppeurs.Count > 0) {
                Developpeur dev = lesDeveloppeurs[0];
                dev.Pwd = "000";
                string hashPwd = GetStringSha256Hash(dev.Pwd);
                developpeurAccess.ModifPwd(dev);
                string req = "SELECT pwd FROM developpeur WHERE iddeveloppeur = " + dev.Iddeveloppeur;
                try
                {
                    List<Object[]> records = access.Manager.ReqSelect(req);
                    if (records != null && records.Count > 0)
                    {
                        string pwdInBdd = records[0][0].ToString();
                        Assert.AreEqual(hashPwd, pwdInBdd, "Devrait réussir si la requête de modification du mot de passe est correcte et que le mot de passe a été modifié dans la bdd");
                    }
                    else
                    {
                        Assert.Fail("Aucun résultat retourné par la requête de vérification du mot de passe en bdd");
                    }
                }
                catch (Exception ex)
                {
                    Assert.Fail("Exception levée lors de la vérification du mot de passe en bdd : " + ex.Message);
                }
            }
            EndTransaction();
        }


        private static string GetStringSha256Hash(string text)
        {
            Encoding enc = Encoding.UTF8;
            var hashBuilder = new StringBuilder();
            var hash = System.Security.Cryptography.SHA256.Create();
            byte[] result = hash.ComputeHash(enc.GetBytes(text));
            foreach (var b in result)
                hashBuilder.Append(b.ToString("x2"));
            return hashBuilder.ToString();
        }
    }
}