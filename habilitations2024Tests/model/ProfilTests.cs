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
    
    public class ProfilTests
    {
        private const int idprofil = 1;
        private const string nom = "Dupont";
        private static readonly Profil profil = new Profil(idprofil, nom);

        [TestMethod()]
        public void ProfilTest()
        {
            Assert.AreEqual(idprofil, profil.Idprofil, "Devrait réussir : idprofil valorisé");
            Assert.AreEqual(nom, profil.Nom, "Devrait réussir : nom valorisé");
        }

        [TestMethod()]
        public void ToStringTest()
        {
            Assert.AreEqual(nom, profil.ToString(), "Devrait réussir : ToString retourne le nom du profil");
        }
    }
}