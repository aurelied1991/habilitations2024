using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using habilitations2024.controller;
using habilitations2024.model;

namespace Habilitations2024.view

{   
    /// <summary>
    /// Fenêtre de lancement du programme avec affichage des développeurs
    /// </summary>
    public partial class FrmHabilitations : Form
    {
        /// <summary>
        /// Controleur de la fenêtre de l'application
        /// </summary>
        private FrmHabilitationsController controller;

        /// <summary>
        /// Objet pour gérer liste développeurs
        /// </summary>
        private BindingSource bdgDeveloppeurs = new BindingSource();

        /// <summary>
        /// Objet pour gérer liste profils
        /// </summary>
        private BindingSource bdgProfils = new BindingSource();

        /// <summary>
        /// Booléen pour savoir si une modification est demandée
        /// </summary>
        private Boolean demandeModifDeveloppeur = false;

        /// <summary>
        /// COnstruction des composants graphiques et initialisation
        /// </summary>
        public FrmHabilitations()
        {
            InitializeComponent();
            Init();
        }

        /// <summary>
        /// Creation du contrôleur et remplissage des listes au démarrage de l'application
        /// </summary>
        private void Init()
        {
            controller = new FrmHabilitationsController();
            RemplirListeDeveloppeurs();
            RemplirListeProfils();
            EnCoursdeModifDeveloppeur(false);
            EnCoursModifPwd(false);
        }

        /// <summary>
        /// Permet d'afficher les développeurs
        /// </summary>
        private void RemplirListeDeveloppeurs()
        {
            MessageBox.Show("Méthode appelée");
            List<Developpeur> lesDeveloppeurs = controller.GetLesDeveloppeurs();
            MessageBox.Show("Nombre de dev recup : " + lesDeveloppeurs.Count);
            bdgDeveloppeurs.DataSource = lesDeveloppeurs;
            dgvLesDeveloppeurs.DataSource = bdgDeveloppeurs;
            dgvLesDeveloppeurs.Columns["iddeveloppeur"].Visible = false;
            dgvLesDeveloppeurs.Columns["pwd"].Visible = false;
            dgvLesDeveloppeurs.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
        }

        /// <summary>
        /// Permet d'afficher les profils dans la liste des profils à sélectionner
        /// </summary>
        private void RemplirListeProfils()
        {
            List<Profil> lesProfils = controller.GetLesProfils();
            bdgProfils.DataSource = lesProfils;
            cboProfil.DataSource = bdgProfils;
        }

        /// <summary>
        /// Bouton pour modifier un développeur
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnModifier_Click(object sender, EventArgs e)
        {
            if (dgvLesDeveloppeurs.SelectedRows.Count > 0)
            {
                EnCoursdeModifDeveloppeur(true);
                Developpeur developpeur = (Developpeur)bdgDeveloppeurs.List[bdgDeveloppeurs.Position];
                txtNom.Text = developpeur.Nom;
                txtPrenom.Text = developpeur.Prenom;
                txtTel.Text = developpeur.Tel;
                txtMail.Text = developpeur.Mail;
                cboProfil.SelectedIndex = cboProfil.FindStringExact(developpeur.Profil.Nom);
            }
            else
            {
                MessageBox.Show("Une ligne doit être sélectionnée", "Attention");
            }
        }

        /// <summary>
        /// Bouton pour supprimer un développeur
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSupprimer_Click(object sender, EventArgs e)
        {
            if(dgvLesDeveloppeurs.SelectedRows.Count > 0)
            {
                Developpeur developpeur = (Developpeur)bdgDeveloppeurs.List[bdgDeveloppeurs.Position];
                if(MessageBox.Show("Voulez vous vraiment supprimer " + developpeur.Prenom + " " + developpeur.Nom + " ? ", "Confirmation", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    controller.SuppDeveloppeur(developpeur);
                    RemplirListeDeveloppeurs();
                }
            }
            else
            {
                MessageBox.Show("Vous devez sélectionner une ligne", "Attention");
            }
        }

        /// <summary>
        /// Bouton pour accéder au changement de mdp
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnChangerPwd_Click(object sender, EventArgs e)
        {
            if (dgvLesDeveloppeurs.SelectedRows.Count > 0)
            {
                EnCoursModifPwd(true);
            }
            else
            {
                MessageBox.Show("Une ligne doit être sélectionnée", "Attention");
            }
        }

        /// <summary>
        /// Bouton pour valider l'enregistrement d'un nouveau développeur
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnEnregistrerDeveloppeur_Click(object sender, EventArgs e)
        {
            //Vérifier que tous les champs sont remplis ou sélectionnés
            if(!txtNom.Text.Equals("") && !txtPrenom.Text.Equals("") && !txtTel.Text.Equals("") && !txtMail.Text.Equals("") && cboProfil.SelectedIndex != -1)
            {
                Profil profil = (Profil)bdgProfils.List[bdgProfils.Position];
                //Si un dev est en cours de modification
                if(demandeModifDeveloppeur)
                {
                    Developpeur developpeur = (Developpeur)bdgDeveloppeurs.List[bdgDeveloppeurs.Position];
                    developpeur.Nom = txtNom.Text;
                    developpeur.Prenom = txtPrenom.Text;
                    developpeur.Tel = txtTel.Text;
                    developpeur.Mail = txtMail.Text;
                    developpeur.Profil = profil;
                    controller.ModifDeveloppeur(developpeur);
                }
                //Sinon, un nouveau dev est en train d'être créé
                else
                {
                    Developpeur developpeur = new Developpeur(0, txtNom.Text, txtPrenom.Text, txtTel.Text, txtMail.Text,"", profil);
                    controller.AjoutDeveloppeur(developpeur);
                }
                RemplirListeDeveloppeurs();
                EnCoursdeModifDeveloppeur(false);

            }
            else
            {
                MessageBox.Show("Veuillez remplir tous les champs","Attention");
            }
        }

        /// <summary>
        /// Bouton pour annuler l'ajout d'un nouveau développeur
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAnnulerDeveloppeur_Click(object sender, EventArgs e)
        {
            EnCoursdeModifDeveloppeur(false);
        }

        /// <summary>
        /// Bouton pour enregistrer le nouveau mot de passe
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnEnregistrerPwd_Click(object sender, EventArgs e)
        {
            //Vérifier que les deux champs sont bien remplis et qu'ils sont identiques
            if(!txtPwd.Text.Equals("") && !txtEncorePwd.Text.Equals("") && txtPwd.Text.Equals(txtEncorePwd.Text))
            {
                Developpeur developpeur = (Developpeur)bdgDeveloppeurs.List[bdgDeveloppeurs.Position];
                developpeur.Pwd = txtPwd.Text;
                controller.ModifPwd(developpeur);
                EnCoursModifPwd(false);
            }
            else
            {
                MessageBox.Show("Les deux zones doivent être remplies avec un mot de passe identique","Attention");
            }
        }

        /// <summary>
        /// Bouton qui annule la demande de changement de mot de passe
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAnnulerPwd_Click(object sender, EventArgs e)
        {
            EnCoursModifPwd(false);
        }

        /// <summary>
        /// Gère l'affichage selon si on modifie le mdp ou non
        /// </summary>
        /// <param name="modif"></param>
        private void EnCoursModifPwd(Boolean modif)
        {
            gboModifPwd.Enabled = modif;
            gboLesDeveloppeurs.Enabled = !modif;
            gboAjoutDeveloppeur.Enabled = !modif;
            txtPwd.Text = "";
            txtEncorePwd.Text = "";
        }

        /// <summary>
        /// Modification de l'affichage selon si on modifie un développeur
        /// </summary>
        /// <param name="modif"></param>
        private void EnCoursdeModifDeveloppeur(Boolean modif)
        {
            demandeModifDeveloppeur = modif;
            gboLesDeveloppeurs.Enabled = !modif;
            if (!modif)
            {
                gboAjoutDeveloppeur.Text = "Modifier un développeur";
            }
            else
            {
                gboAjoutDeveloppeur.Text = "Aouter un développeur";
                txtNom.Text = "";
                txtPrenom.Text = "";
                txtTel.Text = "";
                txtMail.Text = "";
            }
        }
    }
}
