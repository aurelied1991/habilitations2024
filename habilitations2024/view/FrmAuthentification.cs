using habilitations2024.controller;
using habilitations2024.model;
using Habilitations2024.view;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace habilitations2024.view
{
    public partial class FrmAuthentification : Form
    {
        /// <summary>
        /// Controleur de la fenetre
        /// </summary>
        private FrmAuthentificationController controller;

        public FrmAuthentification()
        {
            InitializeComponent();
            Init();
        }

        /// <summary>
        /// Valorisation de la propriété FrmAuthentificationController, création contrôleur
        /// </summary>
        public void Init()
        {
            controller = new FrmAuthentificationController();
        }

        /// <summary>
        /// COntrôler l'authentification grâce au contrôleur
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnConnection_Click(object sender, EventArgs e)
        {
            String nom = TxtNom.Text;
            String prenom = TxtPrenom.Text;
            String pwd = TxtPwd.Text;

            //Vérifier si des champs sont vides et si oui afficher un message
            if(String.IsNullOrEmpty(nom) || String.IsNullOrEmpty(prenom) || String.IsNullOrEmpty(pwd))
            {
                MessageBox.Show("Tous les champs doivent être remplis ", "Attention");
            }
            else
            {
                Admin admin = new Admin(nom, prenom, pwd);
                if (controller.ControleAuthentification(admin))
                {
                    FrmHabilitations frm = new FrmHabilitations();
                    frm.ShowDialog();
                }
                else
                {
                    MessageBox.Show("Authentification incorrecte et il faut être administrateur", "Attention");
                }
            }
        }

        private void FrmAuthentification_Load(object sender, EventArgs e)
        {

        }
    }
}
