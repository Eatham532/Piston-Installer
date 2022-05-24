namespace Piston_Installer
{
    partial class Install_Modpack
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Install_Modpack));
            this.openModpackBtn = new System.Windows.Forms.Button();
            this.MinecraftDirectoryTxtBox = new System.Windows.Forms.TextBox();
            this.chooseMinecraftDirectoryBtn = new System.Windows.Forms.Button();
            this.InstallDirectoryBtn = new System.Windows.Forms.Button();
            this.InstallDirectoryTxtBox = new System.Windows.Forms.TextBox();
            this.DownloadProgressBar = new System.Windows.Forms.ProgressBar();
            this.subText1 = new System.Windows.Forms.Label();
            this.ModpackNameTxtBox = new System.Windows.Forms.TextBox();
            this.ModpackNameLabel = new System.Windows.Forms.Label();
            this.PercentageProgressBarLabel = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.installBtn = new System.Windows.Forms.Button();
            this.TITLE = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.gameIconPictureBox = new System.Windows.Forms.PictureBox();
            this.ImageContextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.changeImageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.selectImageErrorLabel = new System.Windows.Forms.Label();
            this.selectImageButton = new System.Windows.Forms.Button();
            this.InstallDirectoryLabel = new System.Windows.Forms.Label();
            this.ModpackMainLabel = new System.Windows.Forms.Label();
            this.MinecraftDirectoryLabel = new System.Windows.Forms.Label();
            this.ProgressOfInstallationProgressBar = new System.Windows.Forms.ProgressBar();
            this.ModpackInstallationProgressLabel = new System.Windows.Forms.Label();
            this.groupBox3.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gameIconPictureBox)).BeginInit();
            this.ImageContextMenuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // openModpackBtn
            // 
            this.openModpackBtn.Location = new System.Drawing.Point(6, 706);
            this.openModpackBtn.Name = "openModpackBtn";
            this.openModpackBtn.Size = new System.Drawing.Size(331, 46);
            this.openModpackBtn.TabIndex = 0;
            this.openModpackBtn.Text = "Open Modpack";
            this.openModpackBtn.UseVisualStyleBackColor = true;
            this.openModpackBtn.Click += new System.EventHandler(this.openModpackBtn_Click);
            // 
            // MinecraftDirectoryTxtBox
            // 
            this.MinecraftDirectoryTxtBox.Location = new System.Drawing.Point(379, 320);
            this.MinecraftDirectoryTxtBox.Name = "MinecraftDirectoryTxtBox";
            this.MinecraftDirectoryTxtBox.Size = new System.Drawing.Size(578, 39);
            this.MinecraftDirectoryTxtBox.TabIndex = 1;
            // 
            // chooseMinecraftDirectoryBtn
            // 
            this.chooseMinecraftDirectoryBtn.Location = new System.Drawing.Point(963, 320);
            this.chooseMinecraftDirectoryBtn.Name = "chooseMinecraftDirectoryBtn";
            this.chooseMinecraftDirectoryBtn.Size = new System.Drawing.Size(37, 39);
            this.chooseMinecraftDirectoryBtn.TabIndex = 2;
            this.chooseMinecraftDirectoryBtn.Text = "...";
            this.chooseMinecraftDirectoryBtn.UseVisualStyleBackColor = true;
            this.chooseMinecraftDirectoryBtn.Click += new System.EventHandler(this.chooseMinecraftDirectoryBtn_Click);
            // 
            // InstallDirectoryBtn
            // 
            this.InstallDirectoryBtn.Location = new System.Drawing.Point(963, 431);
            this.InstallDirectoryBtn.Name = "InstallDirectoryBtn";
            this.InstallDirectoryBtn.Size = new System.Drawing.Size(37, 39);
            this.InstallDirectoryBtn.TabIndex = 3;
            this.InstallDirectoryBtn.Text = "...";
            this.InstallDirectoryBtn.UseVisualStyleBackColor = true;
            this.InstallDirectoryBtn.Click += new System.EventHandler(this.InstallDirectoryBtn_Click);
            // 
            // InstallDirectoryTxtBox
            // 
            this.InstallDirectoryTxtBox.Location = new System.Drawing.Point(379, 431);
            this.InstallDirectoryTxtBox.Name = "InstallDirectoryTxtBox";
            this.InstallDirectoryTxtBox.Size = new System.Drawing.Size(578, 39);
            this.InstallDirectoryTxtBox.TabIndex = 4;
            // 
            // DownloadProgressBar
            // 
            this.DownloadProgressBar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.DownloadProgressBar.Location = new System.Drawing.Point(379, 662);
            this.DownloadProgressBar.Name = "DownloadProgressBar";
            this.DownloadProgressBar.Size = new System.Drawing.Size(578, 46);
            this.DownloadProgressBar.TabIndex = 5;
            // 
            // subText1
            // 
            this.subText1.AutoSize = true;
            this.subText1.Font = new System.Drawing.Font("Segoe UI", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.subText1.Location = new System.Drawing.Point(379, 473);
            this.subText1.Name = "subText1";
            this.subText1.Size = new System.Drawing.Size(342, 25);
            this.subText1.TabIndex = 6;
            this.subText1.Text = "Default location is .minecraft/.instances";
            // 
            // ModpackNameTxtBox
            // 
            this.ModpackNameTxtBox.Location = new System.Drawing.Point(15, 457);
            this.ModpackNameTxtBox.Name = "ModpackNameTxtBox";
            this.ModpackNameTxtBox.Size = new System.Drawing.Size(300, 39);
            this.ModpackNameTxtBox.TabIndex = 7;
            // 
            // ModpackNameLabel
            // 
            this.ModpackNameLabel.AutoSize = true;
            this.ModpackNameLabel.Location = new System.Drawing.Point(15, 422);
            this.ModpackNameLabel.Name = "ModpackNameLabel";
            this.ModpackNameLabel.Size = new System.Drawing.Size(184, 32);
            this.ModpackNameLabel.TabIndex = 8;
            this.ModpackNameLabel.Text = "Modpack Name";
            // 
            // PercentageProgressBarLabel
            // 
            this.PercentageProgressBarLabel.AutoSize = true;
            this.PercentageProgressBarLabel.Location = new System.Drawing.Point(379, 711);
            this.PercentageProgressBarLabel.MaximumSize = new System.Drawing.Size(578, 0);
            this.PercentageProgressBarLabel.Name = "PercentageProgressBarLabel";
            this.PercentageProgressBarLabel.Size = new System.Drawing.Size(132, 32);
            this.PercentageProgressBarLabel.TabIndex = 10;
            this.PercentageProgressBarLabel.Text = "Percentage";
            // 
            // groupBox3
            // 
            this.groupBox3.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.groupBox3.Controls.Add(this.installBtn);
            this.groupBox3.Controls.Add(this.TITLE);
            this.groupBox3.Controls.Add(this.groupBox1);
            this.groupBox3.Controls.Add(this.openModpackBtn);
            this.groupBox3.Location = new System.Drawing.Point(12, 0);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(343, 819);
            this.groupBox3.TabIndex = 26;
            this.groupBox3.TabStop = false;
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
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.gameIconPictureBox);
            this.groupBox1.Controls.Add(this.selectImageErrorLabel);
            this.groupBox1.Controls.Add(this.selectImageButton);
            this.groupBox1.Controls.Add(this.ModpackNameTxtBox);
            this.groupBox1.Controls.Add(this.ModpackNameLabel);
            this.groupBox1.Location = new System.Drawing.Point(0, 89);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(342, 557);
            this.groupBox1.TabIndex = 24;
            this.groupBox1.TabStop = false;
            // 
            // gameIconPictureBox
            // 
            this.gameIconPictureBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.gameIconPictureBox.ContextMenuStrip = this.ImageContextMenuStrip;
            this.gameIconPictureBox.Cursor = System.Windows.Forms.Cursors.Hand;
            this.gameIconPictureBox.InitialImage = null;
            this.gameIconPictureBox.Location = new System.Drawing.Point(15, 109);
            this.gameIconPictureBox.Name = "gameIconPictureBox";
            this.gameIconPictureBox.Size = new System.Drawing.Size(300, 300);
            this.gameIconPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.gameIconPictureBox.TabIndex = 23;
            this.gameIconPictureBox.TabStop = false;
            this.gameIconPictureBox.Click += new System.EventHandler(this.selectImageButton_Click);
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
            // selectImageErrorLabel
            // 
            this.selectImageErrorLabel.AutoSize = true;
            this.selectImageErrorLabel.Font = new System.Drawing.Font("Segoe UI", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.selectImageErrorLabel.ForeColor = System.Drawing.Color.Red;
            this.selectImageErrorLabel.Location = new System.Drawing.Point(15, 508);
            this.selectImageErrorLabel.MaximumSize = new System.Drawing.Size(300, 0);
            this.selectImageErrorLabel.Name = "selectImageErrorLabel";
            this.selectImageErrorLabel.Size = new System.Drawing.Size(53, 25);
            this.selectImageErrorLabel.TabIndex = 20;
            this.selectImageErrorLabel.Text = "label";
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
            // InstallDirectoryLabel
            // 
            this.InstallDirectoryLabel.AutoSize = true;
            this.InstallDirectoryLabel.Location = new System.Drawing.Point(379, 396);
            this.InstallDirectoryLabel.Name = "InstallDirectoryLabel";
            this.InstallDirectoryLabel.Size = new System.Drawing.Size(180, 32);
            this.InstallDirectoryLabel.TabIndex = 27;
            this.InstallDirectoryLabel.Text = "Install Directory";
            // 
            // ModpackMainLabel
            // 
            this.ModpackMainLabel.AutoSize = true;
            this.ModpackMainLabel.Font = new System.Drawing.Font("Rockwell", 19.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.ModpackMainLabel.Location = new System.Drawing.Point(708, 24);
            this.ModpackMainLabel.Name = "ModpackMainLabel";
            this.ModpackMainLabel.Size = new System.Drawing.Size(292, 59);
            this.ModpackMainLabel.TabIndex = 28;
            this.ModpackMainLabel.Text = "MODPACK";
            // 
            // MinecraftDirectoryLabel
            // 
            this.MinecraftDirectoryLabel.AutoSize = true;
            this.MinecraftDirectoryLabel.Location = new System.Drawing.Point(379, 285);
            this.MinecraftDirectoryLabel.Name = "MinecraftDirectoryLabel";
            this.MinecraftDirectoryLabel.Size = new System.Drawing.Size(220, 32);
            this.MinecraftDirectoryLabel.TabIndex = 29;
            this.MinecraftDirectoryLabel.Text = "Minecraft Directory";
            // 
            // ProgressOfInstallationProgressBar
            // 
            this.ProgressOfInstallationProgressBar.Location = new System.Drawing.Point(379, 546);
            this.ProgressOfInstallationProgressBar.Name = "ProgressOfInstallationProgressBar";
            this.ProgressOfInstallationProgressBar.Size = new System.Drawing.Size(578, 46);
            this.ProgressOfInstallationProgressBar.TabIndex = 30;
            // 
            // ModpackInstallationProgressLabel
            // 
            this.ModpackInstallationProgressLabel.AutoSize = true;
            this.ModpackInstallationProgressLabel.Location = new System.Drawing.Point(379, 595);
            this.ModpackInstallationProgressLabel.MaximumSize = new System.Drawing.Size(578, 0);
            this.ModpackInstallationProgressLabel.Name = "ModpackInstallationProgressLabel";
            this.ModpackInstallationProgressLabel.Size = new System.Drawing.Size(281, 32);
            this.ModpackInstallationProgressLabel.TabIndex = 31;
            this.ModpackInstallationProgressLabel.Text = "Downloading 1 out of 10";
            // 
            // Install_Modpack
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(13F, 32F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1028, 831);
            this.Controls.Add(this.ModpackInstallationProgressLabel);
            this.Controls.Add(this.ProgressOfInstallationProgressBar);
            this.Controls.Add(this.MinecraftDirectoryLabel);
            this.Controls.Add(this.ModpackMainLabel);
            this.Controls.Add(this.InstallDirectoryLabel);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.PercentageProgressBarLabel);
            this.Controls.Add(this.subText1);
            this.Controls.Add(this.DownloadProgressBar);
            this.Controls.Add(this.InstallDirectoryTxtBox);
            this.Controls.Add(this.InstallDirectoryBtn);
            this.Controls.Add(this.chooseMinecraftDirectoryBtn);
            this.Controls.Add(this.MinecraftDirectoryTxtBox);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Install_Modpack";
            this.Text = "Piston Installer --> Install Modpack";
            this.Load += new System.EventHandler(this.Install_Modpack_Load);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gameIconPictureBox)).EndInit();
            this.ImageContextMenuStrip.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Button openModpackBtn;
        private TextBox MinecraftDirectoryTxtBox;
        private Button chooseMinecraftDirectoryBtn;
        private Button InstallDirectoryBtn;
        private TextBox InstallDirectoryTxtBox;
        private ProgressBar DownloadProgressBar;
        private Label subText1;
        private TextBox ModpackNameTxtBox;
        private Label ModpackNameLabel;
        private Label PercentageProgressBarLabel;
        private GroupBox groupBox3;
        private Button installBtn;
        private Label TITLE;
        private GroupBox groupBox1;
        private PictureBox gameIconPictureBox;
        private Label selectImageErrorLabel;
        private Button selectImageButton;
        private Label InstallDirectoryLabel;
        private Label ModpackMainLabel;
        private Label MinecraftDirectoryLabel;
        private ContextMenuStrip ImageContextMenuStrip;
        private ToolStripMenuItem changeImageToolStripMenuItem;
        private ProgressBar ProgressOfInstallationProgressBar;
        private Label ModpackInstallationProgressLabel;
    }
}