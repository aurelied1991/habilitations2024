using Microsoft.VisualStudio.TestTools.UnitTesting;
using habilitations2024.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace habilitations2024.model.Tests
{
    [TestClass()]
    public class DeveloppeurTests
    {
        private const int iddeveloppeur = 1;
        private const string nom = "Dupont";
        private const string prenom = "Jean";
        private const string tel = "0123456789";
        private const string mail = "jean.dupont@habilitations.fr";
        private const string pwd = "password123";
        private static readonly Profil profil = new Profil(5, "admin");
        private static readonly Developpeur developpeur = new Developpeur(iddeveloppeur, nom, prenom, tel, mail, pwd, profil);

        [TestMethod()]
        public void DeveloppeurTest()
        {
            Assert.AreEqual(iddeveloppeur, developpeur.Iddeveloppeur, "Devrait réussir : id valorisé");
            Assert.AreEqual(nom, developpeur.Nom, "Devrait réussir : nom valorisé");
            Assert.AreEqual(prenom, developpeur.Prenom, "Devrait réussir : prenom valorisé");
            Assert.AreEqual(tel, developpeur.Tel, "Devrait réussir : tel valorisé");
            Assert.AreEqual(mail, developpeur.Mail, "Devrait réussir : mail valorisé");
            Assert.AreEqual(pwd, developpeur.Pwd, "Devrait réussir : pwd valorisé");
            Assert.AreEqual(profil, developpeur.Profil, "Devrait réussir : profil valorisé");
        }
    }
}