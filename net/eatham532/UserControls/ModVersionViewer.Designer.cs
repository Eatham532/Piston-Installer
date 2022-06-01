namespace Piston_Installer.UserControls
{
    partial class ModVersionViewer
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
            this.MainLabel = new System.Windows.Forms.Label();
            this.VersionLabel = new System.Windows.Forms.Label();
            this.StateLabel = new System.Windows.Forms.Label();
            this.DateUpdatedLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // MainLabel
            // 
            this.MainLabel.AutoSize = true;
            this.MainLabel.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.MainLabel.Location = new System.Drawing.Point(3, 12);
            this.MainLabel.Name = "MainLabel";
            this.MainLabel.Size = new System.Drawing.Size(97, 41);
            this.MainLabel.TabIndex = 0;
            this.MainLabel.Text = "Name";
            this.MainLabel.Click += new System.EventHandler(this.MainLabel_Click);
            // 
            // VersionLabel
            // 
            this.VersionLabel.AutoSize = true;
            this.VersionLabel.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.VersionLabel.Location = new System.Drawing.Point(3, 53);
            this.VersionLabel.Name = "VersionLabel";
            this.VersionLabel.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.VersionLabel.Size = new System.Drawing.Size(92, 32);
            this.VersionLabel.TabIndex = 1;
            this.VersionLabel.Text = "Version";
            this.VersionLabel.Click += new System.EventHandler(this.SubLabel_Click);
            // 
            // StateLabel
            // 
            this.StateLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.StateLabel.AutoSize = true;
            this.StateLabel.ForeColor = System.Drawing.SystemColors.ControlText;
            this.StateLabel.Location = new System.Drawing.Point(477, 97);
            this.StateLabel.Name = "StateLabel";
            this.StateLabel.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.StateLabel.Size = new System.Drawing.Size(67, 32);
            this.StateLabel.TabIndex = 2;
            this.StateLabel.Text = "State";
            this.StateLabel.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            this.StateLabel.Click += new System.EventHandler(this.StateLabel_Click);
            // 
            // DateUpdatedLabel
            // 
            this.DateUpdatedLabel.AutoSize = true;
            this.DateUpdatedLabel.Location = new System.Drawing.Point(3, 97);
            this.DateUpdatedLabel.Name = "DateUpdatedLabel";
            this.DateUpdatedLabel.Size = new System.Drawing.Size(64, 32);
            this.DateUpdatedLabel.TabIndex = 4;
            this.DateUpdatedLabel.Text = "Date";
            this.DateUpdatedLabel.Click += new System.EventHandler(this.DateUpdatedLabel_Click);
            // 
            // ModVersionViewer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(13F, 32F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.Controls.Add(this.DateUpdatedLabel);
            this.Controls.Add(this.StateLabel);
            this.Controls.Add(this.VersionLabel);
            this.Controls.Add(this.MainLabel);
            this.Name = "ModVersionViewer";
            this.Size = new System.Drawing.Size(556, 138);
            this.Click += new System.EventHandler(this.ModVersionViewer_Click);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label MainLabel;
        private Label VersionLabel;
        private Label StateLabel;
        private Label DateUpdatedLabel;
    }
}
