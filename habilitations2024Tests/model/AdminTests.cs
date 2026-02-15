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
    public class AdminTests
    {
        private const string nom = "Dupont";
        private const string prenom = "Jean";
        private const string pwd = "password123";
        private static readonly Admin admin = new Admin(nom, prenom, pwd);

        [TestMethod()]
        public void AdminTest()
        {
            Assert.AreEqual(nom, admin.Nom, "Devrait réussir : nom valorisé");
            Assert.AreEqual(prenom, admin.Prenom, "Devrait réussir : prenom valorisé");
            Assert.AreEqual(pwd, admin.Pwd, "Devrait réussir : pwd valorisé");
        }
    }
}