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
    }
}