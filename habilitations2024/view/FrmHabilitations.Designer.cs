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
            this.lstNomDeveloppeur = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // lstNomDeveloppeur
            // 
            this.lstNomDeveloppeur.FormattingEnabled = true;
            this.lstNomDeveloppeur.ItemHeight = 16;
            this.lstNomDeveloppeur.Location = new System.Drawing.Point(97, 165);
            this.lstNomDeveloppeur.Name = "lstNomDeveloppeur";
            this.lstNomDeveloppeur.Size = new System.Drawing.Size(120, 84);
            this.lstNomDeveloppeur.TabIndex = 0;
            this.lstNomDeveloppeur.SelectedIndexChanged += new System.EventHandler(this.nomDeveloppeur_SelectedIndexChanged);
            // 
            // FrmHabilitations
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.lstNomDeveloppeur);
            this.Name = "FrmHabilitations";
            this.Text = "Habilitations2024";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox lstNomDeveloppeur;
    }
}

