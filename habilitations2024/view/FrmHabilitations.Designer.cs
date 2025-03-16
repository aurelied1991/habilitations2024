namespace Habilitations2024.view
{
    partial class FrmHabilitations
    {
        /// <summary>
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Nettoyage des ressources utilisées.
        /// </summary>
        /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Code généré par le Concepteur Windows Form

        /// <summary>
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            this.gboLesDeveloppeurs = new System.Windows.Forms.GroupBox();
            this.CboSelectionProfil = new System.Windows.Forms.ComboBox();
            this.btnChangerPwd = new System.Windows.Forms.Button();
            this.btnSupprimer = new System.Windows.Forms.Button();
            this.btnModifier = new System.Windows.Forms.Button();
            this.dgvLesDeveloppeurs = new System.Windows.Forms.DataGridView();
            this.gboAjoutDeveloppeur = new System.Windows.Forms.GroupBox();
            this.cboProfil = new System.Windows.Forms.ComboBox();
            this.txtTel = new System.Windows.Forms.TextBox();
            this.txtMail = new System.Windows.Forms.TextBox();
            this.txtPrenom = new System.Windows.Forms.TextBox();
            this.txtNom = new System.Windows.Forms.TextBox();
            this.btnAnnulerDeveloppeur = new System.Windows.Forms.Button();
            this.btnEnregistrerDeveloppeur = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.gboModifPwd = new System.Windows.Forms.GroupBox();
            this.btnAnnulerPwd = new System.Windows.Forms.Button();
            this.btnEnregistrerPwd = new System.Windows.Forms.Button();
            this.txtEncorePwd = new System.Windows.Forms.TextBox();
            this.txtPwd = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.gboLesDeveloppeurs.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLesDeveloppeurs)).BeginInit();
            this.gboAjoutDeveloppeur.SuspendLayout();
            this.gboModifPwd.SuspendLayout();
            this.SuspendLayout();
            // 
            // gboLesDeveloppeurs
            // 
            this.gboLesDeveloppeurs.Controls.Add(this.label8);
            this.gboLesDeveloppeurs.Controls.Add(this.CboSelectionProfil);
            this.gboLesDeveloppeurs.Controls.Add(this.btnChangerPwd);
            this.gboLesDeveloppeurs.Controls.Add(this.btnSupprimer);
            this.gboLesDeveloppeurs.Controls.Add(this.btnModifier);
            this.gboLesDeveloppeurs.Controls.Add(this.dgvLesDeveloppeurs);
            this.gboLesDeveloppeurs.Location = new System.Drawing.Point(22, 23);
            this.gboLesDeveloppeurs.Name = "gboLesDeveloppeurs";
            this.gboLesDeveloppeurs.Size = new System.Drawing.Size(650, 257);
            this.gboLesDeveloppeurs.TabIndex = 0;
            this.gboLesDeveloppeurs.TabStop = false;
            this.gboLesDeveloppeurs.Text = "Les développeurs";
            // 
            // CboSelectionProfil
            // 
            this.CboSelectionProfil.FormattingEnabled = true;
            this.CboSelectionProfil.Location = new System.Drawing.Point(488, 228);
            this.CboSelectionProfil.Name = "CboSelectionProfil";
            this.CboSelectionProfil.Size = new System.Drawing.Size(121, 24);
            this.CboSelectionProfil.TabIndex = 3;
            this.CboSelectionProfil.SelectedIndexChanged += new System.EventHandler(this.CboSelectionProfil_SelectedIndexChanged);
            // 
            // btnChangerPwd
            // 
            this.btnChangerPwd.Location = new System.Drawing.Point(293, 225);
            this.btnChangerPwd.Name = "btnChangerPwd";
            this.btnChangerPwd.Size = new System.Drawing.Size(95, 26);
            this.btnChangerPwd.TabIndex = 3;
            this.btnChangerPwd.Text = "Changer pwd";
            this.btnChangerPwd.UseVisualStyleBackColor = true;
            this.btnChangerPwd.Click += new System.EventHandler(this.btnChangerPwd_Click);
            // 
            // btnSupprimer
            // 
            this.btnSupprimer.Location = new System.Drawing.Point(151, 225);
            this.btnSupprimer.Name = "btnSupprimer";
            this.btnSupprimer.Size = new System.Drawing.Size(95, 26);
            this.btnSupprimer.TabIndex = 2;
            this.btnSupprimer.Text = "Supprimer";
            this.btnSupprimer.UseVisualStyleBackColor = true;
            this.btnSupprimer.Click += new System.EventHandler(this.btnSupprimer_Click);
            // 
            // btnModifier
            // 
            this.btnModifier.Location = new System.Drawing.Point(10, 225);
            this.btnModifier.Name = "btnModifier";
            this.btnModifier.Size = new System.Drawing.Size(98, 26);
            this.btnModifier.TabIndex = 1;
            this.btnModifier.Text = "Modifier";
            this.btnModifier.UseVisualStyleBackColor = true;
            this.btnModifier.Click += new System.EventHandler(this.btnModifier_Click);
            // 
            // dgvLesDeveloppeurs
            // 
            this.dgvLesDeveloppeurs.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgvLesDeveloppeurs.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvLesDeveloppeurs.Location = new System.Drawing.Point(10, 21);
            this.dgvLesDeveloppeurs.MultiSelect = false;
            this.dgvLesDeveloppeurs.Name = "dgvLesDeveloppeurs";
            this.dgvLesDeveloppeurs.RowHeadersVisible = false;
            this.dgvLesDeveloppeurs.RowHeadersWidth = 51;
            this.dgvLesDeveloppeurs.RowTemplate.Height = 24;
            this.dgvLesDeveloppeurs.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvLesDeveloppeurs.Size = new System.Drawing.Size(634, 198);
            this.dgvLesDeveloppeurs.TabIndex = 0;
            // 
            // gboAjoutDeveloppeur
            // 
            this.gboAjoutDeveloppeur.Controls.Add(this.cboProfil);
            this.gboAjoutDeveloppeur.Controls.Add(this.txtTel);
            this.gboAjoutDeveloppeur.Controls.Add(this.txtMail);
            this.gboAjoutDeveloppeur.Controls.Add(this.txtPrenom);
            this.gboAjoutDeveloppeur.Controls.Add(this.txtNom);
            this.gboAjoutDeveloppeur.Controls.Add(this.btnAnnulerDeveloppeur);
            this.gboAjoutDeveloppeur.Controls.Add(this.btnEnregistrerDeveloppeur);
            this.gboAjoutDeveloppeur.Controls.Add(this.label7);
            this.gboAjoutDeveloppeur.Controls.Add(this.label6);
            this.gboAjoutDeveloppeur.Controls.Add(this.label3);
            this.gboAjoutDeveloppeur.Controls.Add(this.label5);
            this.gboAjoutDeveloppeur.Controls.Add(this.label4);
            this.gboAjoutDeveloppeur.Location = new System.Drawing.Point(22, 286);
            this.gboAjoutDeveloppeur.Name = "gboAjoutDeveloppeur";
            this.gboAjoutDeveloppeur.Size = new System.Drawing.Size(650, 150);
            this.gboAjoutDeveloppeur.TabIndex = 1;
            this.gboAjoutDeveloppeur.TabStop = false;
            this.gboAjoutDeveloppeur.Text = "Ajouter un développeur";
            // 
            // cboProfil
            // 
            this.cboProfil.FormattingEnabled = true;
            this.cboProfil.Location = new System.Drawing.Point(430, 95);
            this.cboProfil.Name = "cboProfil";
            this.cboProfil.Size = new System.Drawing.Size(179, 24);
            this.cboProfil.TabIndex = 15;
            // 
            // txtTel
            // 
            this.txtTel.Location = new System.Drawing.Point(430, 63);
            this.txtTel.Name = "txtTel";
            this.txtTel.Size = new System.Drawing.Size(179, 22);
            this.txtTel.TabIndex = 14;
            // 
            // txtMail
            // 
            this.txtMail.Location = new System.Drawing.Point(430, 29);
            this.txtMail.Name = "txtMail";
            this.txtMail.Size = new System.Drawing.Size(179, 22);
            this.txtMail.TabIndex = 13;
            // 
            // txtPrenom
            // 
            this.txtPrenom.Location = new System.Drawing.Point(82, 63);
            this.txtPrenom.Name = "txtPrenom";
            this.txtPrenom.Size = new System.Drawing.Size(164, 22);
            this.txtPrenom.TabIndex = 12;
            // 
            // txtNom
            // 
            this.txtNom.Location = new System.Drawing.Point(82, 29);
            this.txtNom.Name = "txtNom";
            this.txtNom.Size = new System.Drawing.Size(164, 22);
            this.txtNom.TabIndex = 11;
            // 
            // btnAnnulerDeveloppeur
            // 
            this.btnAnnulerDeveloppeur.Location = new System.Drawing.Point(151, 115);
            this.btnAnnulerDeveloppeur.Name = "btnAnnulerDeveloppeur";
            this.btnAnnulerDeveloppeur.Size = new System.Drawing.Size(95, 29);
            this.btnAnnulerDeveloppeur.TabIndex = 10;
            this.btnAnnulerDeveloppeur.Text = "Annuler";
            this.btnAnnulerDeveloppeur.UseVisualStyleBackColor = true;
            this.btnAnnulerDeveloppeur.Click += new System.EventHandler(this.btnAnnulerDeveloppeur_Click);
            // 
            // btnEnregistrerDeveloppeur
            // 
            this.btnEnregistrerDeveloppeur.Location = new System.Drawing.Point(10, 115);
            this.btnEnregistrerDeveloppeur.Name = "btnEnregistrerDeveloppeur";
            this.btnEnregistrerDeveloppeur.Size = new System.Drawing.Size(98, 29);
            this.btnEnregistrerDeveloppeur.TabIndex = 9;
            this.btnEnregistrerDeveloppeur.Text = "Enregistrer";
            this.btnEnregistrerDeveloppeur.UseVisualStyleBackColor = true;
            this.btnEnregistrerDeveloppeur.Click += new System.EventHandler(this.btnEnregistrerDeveloppeur_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(356, 98);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(37, 16);
            this.label7.TabIndex = 8;
            this.label7.Text = "Profil";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(356, 66);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(27, 16);
            this.label6.TabIndex = 7;
            this.label6.Text = "Tel";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(356, 32);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(32, 16);
            this.label3.TabIndex = 6;
            this.label3.Text = "Mail";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(10, 66);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(54, 16);
            this.label5.TabIndex = 1;
            this.label5.Text = "Prénom";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(10, 32);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(36, 16);
            this.label4.TabIndex = 0;
            this.label4.Text = "Nom";
            // 
            // gboModifPwd
            // 
            this.gboModifPwd.Controls.Add(this.btnAnnulerPwd);
            this.gboModifPwd.Controls.Add(this.btnEnregistrerPwd);
            this.gboModifPwd.Controls.Add(this.txtEncorePwd);
            this.gboModifPwd.Controls.Add(this.txtPwd);
            this.gboModifPwd.Controls.Add(this.label2);
            this.gboModifPwd.Controls.Add(this.label1);
            this.gboModifPwd.Location = new System.Drawing.Point(22, 442);
            this.gboModifPwd.Name = "gboModifPwd";
            this.gboModifPwd.Size = new System.Drawing.Size(650, 100);
            this.gboModifPwd.TabIndex = 2;
            this.gboModifPwd.TabStop = false;
            this.gboModifPwd.Text = "Changer le mot de passe";
            // 
            // btnAnnulerPwd
            // 
            this.btnAnnulerPwd.Location = new System.Drawing.Point(151, 71);
            this.btnAnnulerPwd.Name = "btnAnnulerPwd";
            this.btnAnnulerPwd.Size = new System.Drawing.Size(98, 23);
            this.btnAnnulerPwd.TabIndex = 5;
            this.btnAnnulerPwd.Text = "Annuler";
            this.btnAnnulerPwd.UseVisualStyleBackColor = true;
            this.btnAnnulerPwd.Click += new System.EventHandler(this.btnAnnulerPwd_Click);
            // 
            // btnEnregistrerPwd
            // 
            this.btnEnregistrerPwd.Location = new System.Drawing.Point(10, 71);
            this.btnEnregistrerPwd.Name = "btnEnregistrerPwd";
            this.btnEnregistrerPwd.Size = new System.Drawing.Size(98, 23);
            this.btnEnregistrerPwd.TabIndex = 4;
            this.btnEnregistrerPwd.Text = "Enregistrer";
            this.btnEnregistrerPwd.UseVisualStyleBackColor = true;
            this.btnEnregistrerPwd.Click += new System.EventHandler(this.btnEnregistrerPwd_Click);
            // 
            // txtEncorePwd
            // 
            this.txtEncorePwd.Location = new System.Drawing.Point(430, 31);
            this.txtEncorePwd.Name = "txtEncorePwd";
            this.txtEncorePwd.PasswordChar = '*';
            this.txtEncorePwd.Size = new System.Drawing.Size(179, 22);
            this.txtEncorePwd.TabIndex = 3;
            // 
            // txtPwd
            // 
            this.txtPwd.Location = new System.Drawing.Point(70, 31);
            this.txtPwd.Name = "txtPwd";
            this.txtPwd.PasswordChar = '*';
            this.txtPwd.Size = new System.Drawing.Size(179, 22);
            this.txtPwd.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(356, 31);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(50, 16);
            this.label2.TabIndex = 1;
            this.label2.Text = "Encore";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(33, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Pwd";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(427, 235);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(43, 16);
            this.label8.TabIndex = 4;
            this.label8.Text = "Profil :";
            // 
            // FrmHabilitations
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(695, 541);
            this.Controls.Add(this.gboModifPwd);
            this.Controls.Add(this.gboAjoutDeveloppeur);
            this.Controls.Add(this.gboLesDeveloppeurs);
            this.Name = "FrmHabilitations";
            this.Text = "Habilitations2024";
            this.gboLesDeveloppeurs.ResumeLayout(false);
            this.gboLesDeveloppeurs.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLesDeveloppeurs)).EndInit();
            this.gboAjoutDeveloppeur.ResumeLayout(false);
            this.gboAjoutDeveloppeur.PerformLayout();
            this.gboModifPwd.ResumeLayout(false);
            this.gboModifPwd.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gboLesDeveloppeurs;
        private System.Windows.Forms.GroupBox gboAjoutDeveloppeur;
        private System.Windows.Forms.GroupBox gboModifPwd;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnAnnulerPwd;
        private System.Windows.Forms.Button btnEnregistrerPwd;
        private System.Windows.Forms.TextBox txtEncorePwd;
        private System.Windows.Forms.TextBox txtPwd;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btnAnnulerDeveloppeur;
        private System.Windows.Forms.Button btnEnregistrerDeveloppeur;
        private System.Windows.Forms.ComboBox cboProfil;
        private System.Windows.Forms.TextBox txtTel;
        private System.Windows.Forms.TextBox txtMail;
        private System.Windows.Forms.TextBox txtPrenom;
        private System.Windows.Forms.TextBox txtNom;
        private System.Windows.Forms.DataGridView dgvLesDeveloppeurs;
        private System.Windows.Forms.Button btnChangerPwd;
        private System.Windows.Forms.Button btnSupprimer;
        private System.Windows.Forms.Button btnModifier;
        private System.Windows.Forms.ComboBox CboSelectionProfil;
        private System.Windows.Forms.Label label8;
    }
}

