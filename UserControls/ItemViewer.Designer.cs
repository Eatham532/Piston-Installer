namespace Piston_Installer.UserControls
{
    partial class ItemViewer
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ItemViewer));
            this.GrandChildButton = new System.Windows.Forms.Button();
            this.GrandChildSubtitleLabel = new System.Windows.Forms.Label();
            this.GrandChildTitleLabel = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.InfoSymbolLabel = new System.Windows.Forms.Label();
            this.EnviromentsLabel = new System.Windows.Forms.Label();
            this.HiddenData = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // GrandChildButton
            // 
            resources.ApplyResources(this.GrandChildButton, "GrandChildButton");
            this.GrandChildButton.Name = "GrandChildButton";
            this.GrandChildButton.UseVisualStyleBackColor = false;
            this.GrandChildButton.Click += new System.EventHandler(this.GrandChildButton_Click);
            // 
            // GrandChildSubtitleLabel
            // 
            resources.ApplyResources(this.GrandChildSubtitleLabel, "GrandChildSubtitleLabel");
            this.GrandChildSubtitleLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.GrandChildSubtitleLabel.Name = "GrandChildSubtitleLabel";
            // 
            // GrandChildTitleLabel
            // 
            resources.ApplyResources(this.GrandChildTitleLabel, "GrandChildTitleLabel");
            this.GrandChildTitleLabel.Name = "GrandChildTitleLabel";
            // 
            // pictureBox1
            // 
            resources.ApplyResources(this.pictureBox1, "pictureBox1");
            this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.TabStop = false;
            // 
            // InfoSymbolLabel
            // 
            resources.ApplyResources(this.InfoSymbolLabel, "InfoSymbolLabel");
            this.InfoSymbolLabel.ForeColor = System.Drawing.SystemColors.InfoText;
            this.InfoSymbolLabel.Name = "InfoSymbolLabel";
            // 
            // EnviromentsLabel
            // 
            resources.ApplyResources(this.EnviromentsLabel, "EnviromentsLabel");
            this.EnviromentsLabel.ForeColor = System.Drawing.SystemColors.InfoText;
            this.EnviromentsLabel.Name = "EnviromentsLabel";
            this.EnviromentsLabel.TextChanged += new System.EventHandler(this.EnviromentsLabel_TextChanged);
            // 
            // HiddenData
            // 
            resources.ApplyResources(this.HiddenData, "HiddenData");
            this.HiddenData.Name = "HiddenData";
            // 
            // ItemViewer
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.Controls.Add(this.HiddenData);
            this.Controls.Add(this.EnviromentsLabel);
            this.Controls.Add(this.InfoSymbolLabel);
            this.Controls.Add(this.GrandChildButton);
            this.Controls.Add(this.GrandChildSubtitleLabel);
            this.Controls.Add(this.GrandChildTitleLabel);
            this.Controls.Add(this.pictureBox1);
            resources.ApplyResources(this, "$this");
            this.Name = "ItemViewer";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Button GrandChildButton;
        private Label GrandChildSubtitleLabel;
        private Label GrandChildTitleLabel;
        private PictureBox pictureBox1;
        private Label InfoSymbolLabel;
        private Label EnviromentsLabel;
        private Label HiddenData;
    }
}
