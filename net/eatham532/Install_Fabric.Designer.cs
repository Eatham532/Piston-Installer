namespace Piston_Installer
{
    partial class Install_Fabric
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Install_Fabric));
            this.asInstanceCheckBox = new System.Windows.Forms.CheckBox();
            this.minecraftDirectoryTextBox = new System.Windows.Forms.TextBox();
            this.chooseMinecraftDirectoryBtn = new System.Windows.Forms.Button();
            this.installLocationBtn = new System.Windows.Forms.Button();
            this.installLocationTextBox = new System.Windows.Forms.TextBox();
            this.subText1 = new System.Windows.Forms.Label();
            this.GameVersionComboBox = new System.Windows.Forms.ComboBox();
            this.includeSnapshotsCheckBox = new System.Windows.Forms.CheckBox();
            this.minecraftVersionLabel = new System.Windows.Forms.Label();
            this.fabricVersionLabel = new System.Windows.Forms.Label();
            this.LoaderVersionComboBox = new System.Windows.Forms.ComboBox();
            this.installProgressBar = new System.Windows.Forms.ProgressBar();
            this.currentOperationLabel = new System.Windows.Forms.Label();
            this.nameTextBox = new System.Windows.Forms.TextBox();
            this.nameLabel = new System.Windows.Forms.Label();
            this.selectImageButton = new System.Windows.Forms.Button();
            this.selectImageErrorLabel = new System.Windows.Forms.Label();
            this.installBtn = new System.Windows.Forms.Button();
            this.gameIconPictureBox = new System.Windows.Forms.PictureBox();
            this.ImageContextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.changeImageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.TITLE = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.MinecraftLocationLabel = new System.Windows.Forms.Label();
            this.InstallLocationLabel = new System.Windows.Forms.Label();
            this.LOGO = new System.Windows.Forms.PictureBox();
            this.openModsFolderCheckBox = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.gameIconPictureBox)).BeginInit();
            this.ImageContextMenuStrip.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.LOGO)).BeginInit();
            this.SuspendLayout();
            // 
            // asInstanceCheckBox
            // 
            this.asInstanceCheckBox.AutoSize = true;
            this.asInstanceCheckBox.Location = new System.Drawing.Point(769, 213);
            this.asInstanceCheckBox.Name = "asInstanceCheckBox";
            this.asInstanceCheckBox.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.asInstanceCheckBox.Size = new System.Drawing.Size(200, 36);
            this.asInstanceCheckBox.TabIndex = 0;
            this.asInstanceCheckBox.Text = "Make Instance";
            this.asInstanceCheckBox.UseVisualStyleBackColor = true;
            this.asInstanceCheckBox.CheckedChanged += new System.EventHandler(this.asInstanceCheckBox_CheckedChanged);
            // 
            // minecraftDirectoryTextBox
            // 
            this.minecraftDirectoryTextBox.Location = new System.Drawing.Point(391, 252);
            this.minecraftDirectoryTextBox.Name = "minecraftDirectoryTextBox";
            this.minecraftDirectoryTextBox.Size = new System.Drawing.Size(578, 39);
            this.minecraftDirectoryTextBox.TabIndex = 1;
            // 
            // chooseMinecraftDirectoryBtn
            // 
            this.chooseMinecraftDirectoryBtn.Location = new System.Drawing.Point(975, 252);
            this.chooseMinecraftDirectoryBtn.Name = "chooseMinecraftDirectoryBtn";
            this.chooseMinecraftDirectoryBtn.Size = new System.Drawing.Size(40, 39);
            this.chooseMinecraftDirectoryBtn.TabIndex = 2;
            this.chooseMinecraftDirectoryBtn.Text = "...";
            this.chooseMinecraftDirectoryBtn.UseVisualStyleBackColor = true;
            this.chooseMinecraftDirectoryBtn.Click += new System.EventHandler(this.chooseMinecraftDirectoryBtn_Click);
            // 
            // installLocationBtn
            // 
            this.installLocationBtn.Enabled = false;
            this.installLocationBtn.Location = new System.Drawing.Point(975, 384);
            this.installLocationBtn.Name = "installLocationBtn";
            this.installLocationBtn.Size = new System.Drawing.Size(40, 39);
            this.installLocationBtn.TabIndex = 4;
            this.installLocationBtn.Text = "...";
            this.installLocationBtn.UseVisualStyleBackColor = true;
            this.installLocationBtn.Click += new System.EventHandler(this.installLocationBtn_Click);
            // 
            // installLocationTextBox
            // 
            this.installLocationTextBox.Enabled = false;
            this.installLocationTextBox.Location = new System.Drawing.Point(391, 384);
            this.installLocationTextBox.Name = "installLocationTextBox";
            this.installLocationTextBox.Size = new System.Drawing.Size(578, 39);
            this.installLocationTextBox.TabIndex = 3;
            // 
            // subText1
            // 
            this.subText1.AutoSize = true;
            this.subText1.Font = new System.Drawing.Font("Segoe UI", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.subText1.Location = new System.Drawing.Point(391, 294);
            this.subText1.Name = "subText1";
            this.subText1.Size = new System.Drawing.Size(342, 25);
            this.subText1.TabIndex = 7;
            this.subText1.Text = "Default location is .minecraft\\.Instances";
            // 
            // GameVersionComboBox
            // 
            this.GameVersionComboBox.DropDownHeight = 275;
            this.GameVersionComboBox.Enabled = false;
            this.GameVersionComboBox.FormattingEnabled = true;
            this.GameVersionComboBox.IntegralHeight = false;
            this.GameVersionComboBox.Location = new System.Drawing.Point(391, 494);
            this.GameVersionComboBox.Name = "GameVersionComboBox";
            this.GameVersionComboBox.Size = new System.Drawing.Size(578, 40);
            this.GameVersionComboBox.TabIndex = 8;
            // 
            // includeSnapshotsCheckBox
            // 
            this.includeSnapshotsCheckBox.AutoSize = true;
            this.includeSnapshotsCheckBox.Enabled = false;
            this.includeSnapshotsCheckBox.Location = new System.Drawing.Point(749, 458);
            this.includeSnapshotsCheckBox.Name = "includeSnapshotsCheckBox";
            this.includeSnapshotsCheckBox.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.includeSnapshotsCheckBox.Size = new System.Drawing.Size(220, 36);
            this.includeSnapshotsCheckBox.TabIndex = 9;
            this.includeSnapshotsCheckBox.Text = "Show Snapshots";
            this.includeSnapshotsCheckBox.UseVisualStyleBackColor = true;
            this.includeSnapshotsCheckBox.CheckedChanged += new System.EventHandler(this.includeSnapshotsCheckBox_CheckedChanged);
            // 
            // minecraftVersionLabel
            // 
            this.minecraftVersionLabel.AutoSize = true;
            this.minecraftVersionLabel.Location = new System.Drawing.Point(391, 453);
            this.minecraftVersionLabel.Name = "minecraftVersionLabel";
            this.minecraftVersionLabel.Size = new System.Drawing.Size(201, 32);
            this.minecraftVersionLabel.TabIndex = 10;
            this.minecraftVersionLabel.Text = "Minecraft Version";
            // 
            // fabricVersionLabel
            // 
            this.fabricVersionLabel.AutoSize = true;
            this.fabricVersionLabel.Location = new System.Drawing.Point(391, 567);
            this.fabricVersionLabel.Name = "fabricVersionLabel";
            this.fabricVersionLabel.Size = new System.Drawing.Size(171, 32);
            this.fabricVersionLabel.TabIndex = 11;
            this.fabricVersionLabel.Text = "Loader Version";
            // 
            // LoaderVersionComboBox
            // 
            this.LoaderVersionComboBox.DropDownHeight = 275;
            this.LoaderVersionComboBox.Enabled = false;
            this.LoaderVersionComboBox.FormattingEnabled = true;
            this.LoaderVersionComboBox.IntegralHeight = false;
            this.LoaderVersionComboBox.Location = new System.Drawing.Point(391, 602);
            this.LoaderVersionComboBox.Name = "LoaderVersionComboBox";
            this.LoaderVersionComboBox.Size = new System.Drawing.Size(578, 40);
            this.LoaderVersionComboBox.TabIndex = 12;
            // 
            // installProgressBar
            // 
            this.installProgressBar.Enabled = false;
            this.installProgressBar.Location = new System.Drawing.Point(391, 700);
            this.installProgressBar.Name = "installProgressBar";
            this.installProgressBar.Size = new System.Drawing.Size(578, 46);
            this.installProgressBar.TabIndex = 13;
            // 
            // currentOperationLabel
            // 
            this.currentOperationLabel.AutoSize = true;
            this.currentOperationLabel.Location = new System.Drawing.Point(391, 665);
            this.currentOperationLabel.MaximumSize = new System.Drawing.Size(578, 0);
            this.currentOperationLabel.Name = "currentOperationLabel";
            this.currentOperationLabel.Size = new System.Drawing.Size(200, 32);
            this.currentOperationLabel.TabIndex = 15;
            this.currentOperationLabel.Text = "current operation";
            // 
            // nameTextBox
            // 
            this.nameTextBox.Location = new System.Drawing.Point(15, 471);
            this.nameTextBox.Name = "nameTextBox";
            this.nameTextBox.Size = new System.Drawing.Size(300, 39);
            this.nameTextBox.TabIndex = 16;
            // 
            // nameLabel
            // 
            this.nameLabel.AutoSize = true;
            this.nameLabel.Location = new System.Drawing.Point(15, 436);
            this.nameLabel.Name = "nameLabel";
            this.nameLabel.Size = new System.Drawing.Size(153, 32);
            this.nameLabel.TabIndex = 17;
            this.nameLabel.Text = "Profile Name";
            // 
            // selectImageButton
            // 
            this.selectImageButton.Location = new System.Drawing.Point(15, 38);
            this.selectImageButton.Name = "selectImageButton";
            this.selectImageButton.Size = new System.Drawing.Size(300, 45);
            this.selectImageButton.TabIndex = 19;
            this.selectImageButton.Text = "Choose Image";
            this.selectImageButton.UseVisualStyleBackColor = true;
            this.selectImageButton.Click += new System.EventHandler(this.selectImageButton_Click);
            // 
            // selectImageErrorLabel
            // 
            this.selectImageErrorLabel.AutoSize = true;
            this.selectImageErrorLabel.Font = new System.Drawing.Font("Segoe UI", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.selectImageErrorLabel.ForeColor = System.Drawing.Color.Red;
            this.selectImageErrorLabel.Location = new System.Drawing.Point(15, 513);
            this.selectImageErrorLabel.MaximumSize = new System.Drawing.Size(300, 0);
            this.selectImageErrorLabel.Name = "selectImageErrorLabel";
            this.selectImageErrorLabel.Size = new System.Drawing.Size(53, 25);
            this.selectImageErrorLabel.TabIndex = 20;
            this.selectImageErrorLabel.Text = "label";
            // 
            // installBtn
            // 
            this.installBtn.Location = new System.Drawing.Point(6, 758);
            this.installBtn.Name = "installBtn";
            this.installBtn.Size = new System.Drawing.Size(331, 46);
            this.installBtn.TabIndex = 21;
            this.installBtn.Text = "Install";
            this.installBtn.UseVisualStyleBackColor = true;
            this.installBtn.Click += new System.EventHandler(this.installBtn_Click);
            // 
            // gameIconPictureBox
            // 
            this.gameIconPictureBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.gameIconPictureBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.gameIconPictureBox.ContextMenuStrip = this.ImageContextMenuStrip;
            this.gameIconPictureBox.Cursor = System.Windows.Forms.Cursors.Hand;
            this.gameIconPictureBox.Image = global::Piston_Installer.Properties.Resources.FabricIcon;
            this.gameIconPictureBox.InitialImage = null;
            this.gameIconPictureBox.Location = new System.Drawing.Point(15, 109);
            this.gameIconPictureBox.Name = "gameIconPictureBox";
            this.gameIconPictureBox.Size = new System.Drawing.Size(300, 300);
            this.gameIconPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.gameIconPictureBox.TabIndex = 23;
            this.gameIconPictureBox.TabStop = false;
            this.gameIconPictureBox.Click += new System.EventHandler(this.gameIconPictureBox_Click);
            this.gameIconPictureBox.MouseEnter += new System.EventHandler(this.gameIconPictureBox_MouseEnter);
            this.gameIconPictureBox.MouseLeave += new System.EventHandler(this.gameIconPictureBox_MouseLeave);
            // 
            // ImageContextMenuStrip
            // 
            this.ImageContextMenuStrip.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.ImageContextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.changeImageToolStripMenuItem});
            this.ImageContextMenuStrip.Name = "ImageContextMenuStrip";
            this.ImageContextMenuStrip.Size = new System.Drawing.Size(244, 42);
            // 
            // changeImageToolStripMenuItem
            // 
            this.changeImageToolStripMenuItem.Name = "changeImageToolStripMenuItem";
            this.changeImageToolStripMenuItem.Size = new System.Drawing.Size(243, 38);
            this.changeImageToolStripMenuItem.Text = "Change Image";
            this.changeImageToolStripMenuItem.Click += new System.EventHandler(this.changeImageToolStripMenuItem_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.gameIconPictureBox);
            this.groupBox1.Controls.Add(this.nameTextBox);
            this.groupBox1.Controls.Add(this.selectImageErrorLabel);
            this.groupBox1.Controls.Add(this.selectImageButton);
            this.groupBox1.Controls.Add(this.nameLabel);
            this.groupBox1.Location = new System.Drawing.Point(0, 89);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(342, 557);
            this.groupBox1.TabIndex = 24;
            this.groupBox1.TabStop = false;
            // 
            // TITLE
            // 
            this.TITLE.AutoSize = true;
            this.TITLE.Font = new System.Drawing.Font("Impact", 17F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point);
            this.TITLE.Location = new System.Drawing.Point(15, 26);
            this.TITLE.Name = "TITLE";
            this.TITLE.Size = new System.Drawing.Size(312, 57);
            this.TITLE.TabIndex = 24;
            this.TITLE.Text = "Piston Installer";
            // 
            // groupBox3
            // 
            this.groupBox3.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.groupBox3.Controls.Add(this.installBtn);
            this.groupBox3.Controls.Add(this.TITLE);
            this.groupBox3.Controls.Add(this.groupBox1);
            this.groupBox3.Location = new System.Drawing.Point(12, -4);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(343, 819);
            this.groupBox3.TabIndex = 25;
            this.groupBox3.TabStop = false;
            // 
            // MinecraftLocationLabel
            // 
            this.MinecraftLocationLabel.AutoSize = true;
            this.MinecraftLocationLabel.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.MinecraftLocationLabel.Location = new System.Drawing.Point(391, 208);
            this.MinecraftLocationLabel.Name = "MinecraftLocationLabel";
            this.MinecraftLocationLabel.Size = new System.Drawing.Size(264, 41);
            this.MinecraftLocationLabel.TabIndex = 26;
            this.MinecraftLocationLabel.Text = "Minecraft Location";
            // 
            // InstallLocationLabel
            // 
            this.InstallLocationLabel.AutoSize = true;
            this.InstallLocationLabel.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.InstallLocationLabel.Location = new System.Drawing.Point(391, 340);
            this.InstallLocationLabel.Name = "InstallLocationLabel";
            this.InstallLocationLabel.Size = new System.Drawing.Size(216, 41);
            this.InstallLocationLabel.TabIndex = 27;
            this.InstallLocationLabel.Text = "Install Location";
            // 
            // LOGO
            // 
            this.LOGO.Image = global::Piston_Installer.Properties.Resources.FabricLogo;
            this.LOGO.Location = new System.Drawing.Point(733, 12);
            this.LOGO.Name = "LOGO";
            this.LOGO.Size = new System.Drawing.Size(282, 126);
            this.LOGO.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.LOGO.TabIndex = 28;
            this.LOGO.TabStop = false;
            // 
            // openModsFolderCheckBox
            // 
            this.openModsFolderCheckBox.AutoSize = true;
            this.openModsFolderCheckBox.Location = new System.Drawing.Point(538, 760);
            this.openModsFolderCheckBox.Name = "openModsFolderCheckBox";
            this.openModsFolderCheckBox.Size = new System.Drawing.Size(431, 36);
            this.openModsFolderCheckBox.TabIndex = 29;
            this.openModsFolderCheckBox.Text = "Open mods folder after installation?";
            this.openModsFolderCheckBox.UseVisualStyleBackColor = true;
            // 
            // Install_Fabric
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(13F, 32F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1024, 827);
            this.Controls.Add(this.openModsFolderCheckBox);
            this.Controls.Add(this.LOGO);
            this.Controls.Add(this.InstallLocationLabel);
            this.Controls.Add(this.MinecraftLocationLabel);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.currentOperationLabel);
            this.Controls.Add(this.installProgressBar);
            this.Controls.Add(this.LoaderVersionComboBox);
            this.Controls.Add(this.fabricVersionLabel);
            this.Controls.Add(this.minecraftVersionLabel);
            this.Controls.Add(this.includeSnapshotsCheckBox);
            this.Controls.Add(this.GameVersionComboBox);
            this.Controls.Add(this.subText1);
            this.Controls.Add(this.installLocationBtn);
            this.Controls.Add(this.installLocationTextBox);
            this.Controls.Add(this.chooseMinecraftDirectoryBtn);
            this.Controls.Add(this.minecraftDirectoryTextBox);
            this.Controls.Add(this.asInstanceCheckBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Install_Fabric";
            this.Text = "Piston Installer --> Install FabricMC";
            this.Click += new System.EventHandler(this.Install_Fabric_Click);
            ((System.ComponentModel.ISupportInitialize)(this.gameIconPictureBox)).EndInit();
            this.ImageContextMenuStrip.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.LOGO)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private CheckBox asInstanceCheckBox;
        private TextBox minecraftDirectoryTextBox;
        private Button chooseMinecraftDirectoryBtn;
        private Button installLocationBtn;
        private TextBox installLocationTextBox;
        private Label subText1;
        private ComboBox GameVersionComboBox;
        private CheckBox includeSnapshotsCheckBox;
        private Label minecraftVersionLabel;
        private Label fabricVersionLabel;
        private ComboBox LoaderVersionComboBox;
        private ProgressBar installProgressBar;
        private Label currentOperationLabel;
        private TextBox nameTextBox;
        private Label nameLabel;
        private Button selectImageButton;
        private Label selectImageErrorLabel;
        private Button installBtn;
        private PictureBox gameIconPictureBox;
        private ContextMenuStrip ImageContextMenuStrip;
        private ToolStripMenuItem changeImageToolStripMenuItem;
        private GroupBox groupBox1;
        private Label TITLE;
        private GroupBox groupBox3;
        private Label MinecraftLocationLabel;
        private Label InstallLocationLabel;
        private PictureBox LOGO;
        private CheckBox openModsFolderCheckBox;
    }
}