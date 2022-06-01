using System.Reflection;

namespace Install_Mods
{
    partial class Mod_Extra_Info_Viewer
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Mod_Extra_Info_Viewer));
            this.WebViewerPanel = new System.Windows.Forms.Panel();
            this.WebView = new Microsoft.Web.WebView2.WinForms.WebView2();
            this.ModVersionsGroupBox = new System.Windows.Forms.GroupBox();
            this.ParentVersionsPanel = new System.Windows.Forms.Panel();
            this.VersionsPanel = new System.Windows.Forms.Panel();
            this.TITLE = new System.Windows.Forms.Label();
            this.MenuGroupBox = new System.Windows.Forms.GroupBox();
            this.DownloadsLabel = new System.Windows.Forms.Label();
            this.LastUpdatedLabel = new System.Windows.Forms.Label();
            this.McVersionLabel = new System.Windows.Forms.Label();
            this.AuthorLabel = new System.Windows.Forms.Label();
            this.downloadModBtn = new System.Windows.Forms.Button();
            this.TabControl = new System.Windows.Forms.TabControl();
            this.DescriptionTab = new System.Windows.Forms.TabPage();
            this.ImagesTab = new System.Windows.Forms.TabPage();
            this.panel1 = new System.Windows.Forms.Panel();
            this.GalleryPanel = new System.Windows.Forms.Panel();
            this.HtmlTab = new System.Windows.Forms.TabPage();
            this.HtmlTextBox = new System.Windows.Forms.TextBox();
            this.WebViewerPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.WebView)).BeginInit();
            this.ModVersionsGroupBox.SuspendLayout();
            this.ParentVersionsPanel.SuspendLayout();
            this.MenuGroupBox.SuspendLayout();
            this.TabControl.SuspendLayout();
            this.DescriptionTab.SuspendLayout();
            this.ImagesTab.SuspendLayout();
            this.panel1.SuspendLayout();
            this.HtmlTab.SuspendLayout();
            this.SuspendLayout();
            // 
            // WebViewerPanel
            // 
            this.WebViewerPanel.AutoScroll = true;
            this.WebViewerPanel.Controls.Add(this.WebView);
            this.WebViewerPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.WebViewerPanel.Location = new System.Drawing.Point(3, 3);
            this.WebViewerPanel.Name = "WebViewerPanel";
            this.WebViewerPanel.Size = new System.Drawing.Size(1229, 827);
            this.WebViewerPanel.TabIndex = 1;
            // 
            // WebView
            // 
            this.WebView.AllowExternalDrop = false;
            this.WebView.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.WebView.CreationProperties = null;
            this.WebView.DefaultBackgroundColor = System.Drawing.Color.White;
            this.WebView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.WebView.Location = new System.Drawing.Point(0, 0);
            this.WebView.Name = "WebView";
            this.WebView.Padding = new System.Windows.Forms.Padding(20);
            this.WebView.Size = new System.Drawing.Size(1229, 827);
            this.WebView.TabIndex = 0;
            this.WebView.ZoomFactor = 1D;
            this.WebView.NavigationStarting += new System.EventHandler<Microsoft.Web.WebView2.Core.CoreWebView2NavigationStartingEventArgs>(this.WebView_NavigationStarting);
            // 
            // ModVersionsGroupBox
            // 
            this.ModVersionsGroupBox.Controls.Add(this.ParentVersionsPanel);
            this.ModVersionsGroupBox.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.ModVersionsGroupBox.Location = new System.Drawing.Point(0, 89);
            this.ModVersionsGroupBox.Name = "ModVersionsGroupBox";
            this.ModVersionsGroupBox.Size = new System.Drawing.Size(604, 563);
            this.ModVersionsGroupBox.TabIndex = 24;
            this.ModVersionsGroupBox.TabStop = false;
            // 
            // ParentVersionsPanel
            // 
            this.ParentVersionsPanel.AutoScroll = true;
            this.ParentVersionsPanel.Controls.Add(this.VersionsPanel);
            this.ParentVersionsPanel.Location = new System.Drawing.Point(6, 21);
            this.ParentVersionsPanel.Name = "ParentVersionsPanel";
            this.ParentVersionsPanel.Size = new System.Drawing.Size(592, 525);
            this.ParentVersionsPanel.TabIndex = 5;
            // 
            // VersionsPanel
            // 
            this.VersionsPanel.BackColor = System.Drawing.Color.Transparent;
            this.VersionsPanel.Location = new System.Drawing.Point(0, 3);
            this.VersionsPanel.Name = "VersionsPanel";
            this.VersionsPanel.Size = new System.Drawing.Size(547, 26);
            this.VersionsPanel.TabIndex = 4;
            // 
            // TITLE
            // 
            this.TITLE.AutoSize = true;
            this.TITLE.Font = new System.Drawing.Font("Impact", 17F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point);
            this.TITLE.Location = new System.Drawing.Point(131, 29);
            this.TITLE.Name = "TITLE";
            this.TITLE.Size = new System.Drawing.Size(312, 57);
            this.TITLE.TabIndex = 24;
            this.TITLE.Text = "Piston Installer";
            // 
            // MenuGroupBox
            // 
            this.MenuGroupBox.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.MenuGroupBox.Controls.Add(this.DownloadsLabel);
            this.MenuGroupBox.Controls.Add(this.LastUpdatedLabel);
            this.MenuGroupBox.Controls.Add(this.McVersionLabel);
            this.MenuGroupBox.Controls.Add(this.AuthorLabel);
            this.MenuGroupBox.Controls.Add(this.downloadModBtn);
            this.MenuGroupBox.Controls.Add(this.TITLE);
            this.MenuGroupBox.Controls.Add(this.ModVersionsGroupBox);
            this.MenuGroupBox.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.MenuGroupBox.Location = new System.Drawing.Point(12, -1);
            this.MenuGroupBox.Name = "MenuGroupBox";
            this.MenuGroupBox.Size = new System.Drawing.Size(600, 900);
            this.MenuGroupBox.TabIndex = 28;
            this.MenuGroupBox.TabStop = false;
            // 
            // DownloadsLabel
            // 
            this.DownloadsLabel.AutoSize = true;
            this.DownloadsLabel.Location = new System.Drawing.Point(6, 700);
            this.DownloadsLabel.Name = "DownloadsLabel";
            this.DownloadsLabel.Size = new System.Drawing.Size(137, 32);
            this.DownloadsLabel.TabIndex = 27;
            this.DownloadsLabel.Text = "Downloads:";
            // 
            // LastUpdatedLabel
            // 
            this.LastUpdatedLabel.AutoSize = true;
            this.LastUpdatedLabel.Location = new System.Drawing.Point(6, 733);
            this.LastUpdatedLabel.Name = "LastUpdatedLabel";
            this.LastUpdatedLabel.Size = new System.Drawing.Size(156, 32);
            this.LastUpdatedLabel.TabIndex = 26;
            this.LastUpdatedLabel.Text = "Last updated:";
            // 
            // McVersionLabel
            // 
            this.McVersionLabel.AutoSize = true;
            this.McVersionLabel.Location = new System.Drawing.Point(6, 765);
            this.McVersionLabel.Name = "McVersionLabel";
            this.McVersionLabel.Size = new System.Drawing.Size(97, 32);
            this.McVersionLabel.TabIndex = 25;
            this.McVersionLabel.Text = "Version:";
            // 
            // AuthorLabel
            // 
            this.AuthorLabel.AutoSize = true;
            this.AuthorLabel.Location = new System.Drawing.Point(6, 668);
            this.AuthorLabel.Name = "AuthorLabel";
            this.AuthorLabel.Size = new System.Drawing.Size(92, 32);
            this.AuthorLabel.TabIndex = 5;
            this.AuthorLabel.Text = "Author:";
            // 
            // downloadModBtn
            // 
            this.downloadModBtn.Location = new System.Drawing.Point(6, 825);
            this.downloadModBtn.Name = "downloadModBtn";
            this.downloadModBtn.Size = new System.Drawing.Size(588, 46);
            this.downloadModBtn.TabIndex = 2;
            this.downloadModBtn.Text = "Download Mod";
            this.downloadModBtn.UseVisualStyleBackColor = true;
            this.downloadModBtn.Click += new System.EventHandler(this.downloadModBtn_Click);
            // 
            // TabControl
            // 
            this.TabControl.Controls.Add(this.DescriptionTab);
            this.TabControl.Controls.Add(this.ImagesTab);
            this.TabControl.Controls.Add(this.HtmlTab);
            this.TabControl.Location = new System.Drawing.Point(622, 12);
            this.TabControl.Name = "TabControl";
            this.TabControl.SelectedIndex = 0;
            this.TabControl.Size = new System.Drawing.Size(1251, 887);
            this.TabControl.TabIndex = 25;
            // 
            // DescriptionTab
            // 
            this.DescriptionTab.Controls.Add(this.WebViewerPanel);
            this.DescriptionTab.Location = new System.Drawing.Point(8, 46);
            this.DescriptionTab.Name = "DescriptionTab";
            this.DescriptionTab.Padding = new System.Windows.Forms.Padding(3);
            this.DescriptionTab.Size = new System.Drawing.Size(1235, 833);
            this.DescriptionTab.TabIndex = 0;
            this.DescriptionTab.Text = "Description";
            this.DescriptionTab.UseVisualStyleBackColor = true;
            // 
            // ImagesTab
            // 
            this.ImagesTab.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ImagesTab.Controls.Add(this.panel1);
            this.ImagesTab.Location = new System.Drawing.Point(8, 46);
            this.ImagesTab.Name = "ImagesTab";
            this.ImagesTab.Padding = new System.Windows.Forms.Padding(3);
            this.ImagesTab.Size = new System.Drawing.Size(1235, 833);
            this.ImagesTab.TabIndex = 1;
            this.ImagesTab.Text = "Images";
            this.ImagesTab.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            this.panel1.AutoScroll = true;
            this.panel1.Controls.Add(this.GalleryPanel);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1227, 825);
            this.panel1.TabIndex = 1;
            // 
            // GalleryPanel
            // 
            this.GalleryPanel.BackColor = System.Drawing.Color.Transparent;
            this.GalleryPanel.Location = new System.Drawing.Point(3, 3);
            this.GalleryPanel.Name = "GalleryPanel";
            this.GalleryPanel.Size = new System.Drawing.Size(1193, 27);
            this.GalleryPanel.TabIndex = 0;
            // 
            // HtmlTab
            // 
            this.HtmlTab.Controls.Add(this.HtmlTextBox);
            this.HtmlTab.Location = new System.Drawing.Point(8, 46);
            this.HtmlTab.Name = "HtmlTab";
            this.HtmlTab.Padding = new System.Windows.Forms.Padding(3);
            this.HtmlTab.Size = new System.Drawing.Size(1235, 833);
            this.HtmlTab.TabIndex = 2;
            this.HtmlTab.Text = "HTML";
            this.HtmlTab.UseVisualStyleBackColor = true;
            // 
            // HtmlTextBox
            // 
            this.HtmlTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.HtmlTextBox.Location = new System.Drawing.Point(3, 3);
            this.HtmlTextBox.Multiline = true;
            this.HtmlTextBox.Name = "HtmlTextBox";
            this.HtmlTextBox.Size = new System.Drawing.Size(1229, 827);
            this.HtmlTextBox.TabIndex = 2;
            this.HtmlTextBox.TextChanged += new System.EventHandler(this.HtmlTextBox_TextChanged);
            // 
            // Mod_Extra_Info_Viewer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(13F, 32F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1885, 911);
            this.Controls.Add(this.TabControl);
            this.Controls.Add(this.MenuGroupBox);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Mod_Extra_Info_Viewer";
            this.Text = "Mod_Viewer";
            this.WebViewerPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.WebView)).EndInit();
            this.ModVersionsGroupBox.ResumeLayout(false);
            this.ParentVersionsPanel.ResumeLayout(false);
            this.MenuGroupBox.ResumeLayout(false);
            this.MenuGroupBox.PerformLayout();
            this.TabControl.ResumeLayout(false);
            this.DescriptionTab.ResumeLayout(false);
            this.ImagesTab.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.HtmlTab.ResumeLayout(false);
            this.HtmlTab.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Panel WebViewerPanel;
        private GroupBox ModVersionsGroupBox;
        private Label TITLE;
        private GroupBox MenuGroupBox;
        private Microsoft.Web.WebView2.WinForms.WebView2 WebView;
        private TabControl TabControl;
        private TabPage DescriptionTab;
        private TabPage ImagesTab;
        private TabPage HtmlTab;
        private TextBox HtmlTextBox;
        private Panel GalleryPanel;
        private Button downloadModBtn;
        private Label LastUpdatedLabel;
        private Label McVersionLabel;
        private Label AuthorLabel;
        private Label DownloadsLabel;
        private Panel VersionsPanel;
        private Panel ParentVersionsPanel;
        private Panel panel1;
    }
}