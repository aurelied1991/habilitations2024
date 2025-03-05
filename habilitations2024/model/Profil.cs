using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace habilitations2024.model
{
    public class Profil
    {
        //getter pour toutes les propriétés
        public int Idprofil { get; }
        public string Nom { get; }

        /// <summary>
        /// Constructeur pour valoriser les propriétés
        /// </summary>
        /// <param name="idProfil"></param>
        /// <param name="nom"></param>
        public Profil(int idprofil, string nom) 
        {
            this.Idprofil = idprofil;
            this.Nom = nom;
        }
        

        /// <summary>
        /// Redéfinition de la méthode ToString, utile quand l'objet est sollicité pour l'affichage du profil dans le DataGridView et le ComboBox
        /// </summary>
        /// <returns>Le nom du profil</returns>
        public override string ToString()
        {
            return this.Nom;
        }
    }
}
