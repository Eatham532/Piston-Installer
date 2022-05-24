namespace Piston_Installer
{
    partial class Main
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
            this.Modpack = new System.Windows.Forms.Button();
            this.Install_Fabric = new System.Windows.Forms.Button();
            this.Install_Forge = new System.Windows.Forms.Button();
            this.Title = new System.Windows.Forms.Label();
            this.AddModsBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // Modpack
            // 
            resources.ApplyResources(this.Modpack, "Modpack");
            this.Modpack.Name = "Modpack";
            this.Modpack.UseVisualStyleBackColor = true;
            this.Modpack.Click += new System.EventHandler(this.Modpack_Click);
            // 
            // Install_Fabric
            // 
            resources.ApplyResources(this.Install_Fabric, "Install_Fabric");
            this.Install_Fabric.Name = "Install_Fabric";
            this.Install_Fabric.UseVisualStyleBackColor = true;
            this.Install_Fabric.Click += new System.EventHandler(this.Install_Fabric_Click);
            // 
            // Install_Forge
            // 
            resources.ApplyResources(this.Install_Forge, "Install_Forge");
            this.Install_Forge.Name = "Install_Forge";
            this.Install_Forge.UseVisualStyleBackColor = true;
            this.Install_Forge.Click += new System.EventHandler(this.Install_Forge_Click);
            // 
            // Title
            // 
            resources.ApplyResources(this.Title, "Title");
            this.Title.Name = "Title";
            // 
            // AddModsBtn
            // 
            resources.ApplyResources(this.AddModsBtn, "AddModsBtn");
            this.AddModsBtn.Name = "AddModsBtn";
            this.AddModsBtn.UseVisualStyleBackColor = true;
            this.AddModsBtn.Click += new System.EventHandler(this.AddModsBtn_Click);
            // 
            // Main
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.AddModsBtn);
            this.Controls.Add(this.Title);
            this.Controls.Add(this.Install_Forge);
            this.Controls.Add(this.Install_Fabric);
            this.Controls.Add(this.Modpack);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.Name = "Main";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Button Modpack;
        private Button Install_Fabric;
        private Button Install_Forge;
        private Label Title;
        private Button AddModsBtn;
    }
}