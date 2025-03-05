using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace habilitations2024.model
{
    public class Developpeur
    {
        public Developpeur(int iddeveloppeur, string nom, string prenom, string tel, string mail, string pwd, Profil profil)
        { 
            //Declaration de toutes les propriétés privées qui correspondent aux champs de la table Developpeur
            this.Iddeveloppeur = iddeveloppeur;
            this.Nom = nom;
            this.Prenom = prenom;
            this.Tel = tel;
            this.Mail = mail;
            this.Pwd = pwd;
            this.Profil = profil;
        }

        //Getter et Setter pour chaque propriété sauf IdDeveloppeur qu'il ne faut surtout pas modifier
        //Utilisation de la méthode d'encapsulation sur les champs pour rapport à l'affichage avec un DataGridVie
        public int Iddeveloppeur { get; }
        public string Nom { get; set; }
        public string Prenom { get; set; }
        public string Tel { get; set; }
        public string Mail { get; set; }
        public string Pwd { get; set; }
        public Profil Profil { get; set; }
    }
}
