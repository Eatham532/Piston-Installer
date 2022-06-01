namespace Piston_Installer
{
    partial class Install_Mods
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Install_Mods));
            this.ModsDirectoryTextBox = new System.Windows.Forms.TextBox();
            this.SelectModsDirectoryBtn = new System.Windows.Forms.Button();
            this.ModLoaderComboBox = new System.Windows.Forms.ComboBox();
            this.ModLoaderLabel = new System.Windows.Forms.Label();
            this.ModsDirectoryLabel = new System.Windows.Forms.Label();
            this.IncludeSnapshotsCheckBox = new System.Windows.Forms.CheckBox();
            this.McVersionLabel = new System.Windows.Forms.Label();
            this.McVersionComboBox = new System.Windows.Forms.ComboBox();
            this.ParentPanel = new System.Windows.Forms.Panel();
            this.ChildPanel = new System.Windows.Forms.Panel();
            this.ParentScrollBar = new System.Windows.Forms.VScrollBar();
            this.LoadingLabel = new System.Windows.Forms.Label();
            this.SearchButton = new System.Windows.Forms.Button();
            this.CategoryLabel = new System.Windows.Forms.Label();
            this.CategoriesComboBox = new System.Windows.Forms.ComboBox();
            this.SortByLabel = new System.Windows.Forms.Label();
            this.SortByComboBox = new System.Windows.Forms.ComboBox();
            this.ResultsPerPageLabel = new System.Windows.Forms.Label();
            this.SearchLabel = new System.Windows.Forms.Label();
            this.ResultsPerPageUpDown = new System.Windows.Forms.NumericUpDown();
            this.SearchBox = new System.Windows.Forms.TextBox();
            this.GetModsFromModrinthBtn = new System.Windows.Forms.Button();
            this.GetModsFromCurseforgeBtn = new System.Windows.Forms.Button();
            this.MenuGroupBox = new System.Windows.Forms.GroupBox();
            this.SearchOptionsLabel = new System.Windows.Forms.Label();
            this.TITLE = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.OptionsPanel = new System.Windows.Forms.Panel();
            this.ParentPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ResultsPerPageUpDown)).BeginInit();
            this.MenuGroupBox.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.OptionsPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // ModsDirectoryTextBox
            // 
            this.ModsDirectoryTextBox.Location = new System.Drawing.Point(198, 20);
            this.ModsDirectoryTextBox.Name = "ModsDirectoryTextBox";
            this.ModsDirectoryTextBox.Size = new System.Drawing.Size(1157, 39);
            this.ModsDirectoryTextBox.TabIndex = 1;
            this.ModsDirectoryTextBox.Text = "C:\\Users\\eatha\\AppData\\Roaming\\.minecraft\\mods";
            this.ModsDirectoryTextBox.Leave += new System.EventHandler(this.ModsDirectoryTextBox_Leave);
            // 
            // SelectModsDirectoryBtn
            // 
            this.SelectModsDirectoryBtn.Location = new System.Drawing.Point(1361, 20);
            this.SelectModsDirectoryBtn.Name = "SelectModsDirectoryBtn";
            this.SelectModsDirectoryBtn.Size = new System.Drawing.Size(39, 39);
            this.SelectModsDirectoryBtn.TabIndex = 2;
            this.SelectModsDirectoryBtn.Text = "...";
            this.SelectModsDirectoryBtn.UseVisualStyleBackColor = true;
            this.SelectModsDirectoryBtn.Click += new System.EventHandler(this.SelectModsDirectoryBtn_Click);
            // 
            // ModLoaderComboBox
            // 
            this.ModLoaderComboBox.FormattingEnabled = true;
            this.ModLoaderComboBox.Items.AddRange(new object[] {
            "Fabric",
            "Forge"});
            this.ModLoaderComboBox.Location = new System.Drawing.Point(21, 93);
            this.ModLoaderComboBox.Name = "ModLoaderComboBox";
            this.ModLoaderComboBox.Size = new System.Drawing.Size(242, 40);
            this.ModLoaderComboBox.TabIndex = 3;
            this.ModLoaderComboBox.Text = "Fabric";
            this.ModLoaderComboBox.TextChanged += new System.EventHandler(this.ModLoaderComboBox_TextChanged);
            // 
            // ModLoaderLabel
            // 
            this.ModLoaderLabel.AutoSize = true;
            this.ModLoaderLabel.Location = new System.Drawing.Point(18, 54);
            this.ModLoaderLabel.Name = "ModLoaderLabel";
            this.ModLoaderLabel.Size = new System.Drawing.Size(143, 32);
            this.ModLoaderLabel.TabIndex = 4;
            this.ModLoaderLabel.Text = "Mod Loader";
            // 
            // ModsDirectoryLabel
            // 
            this.ModsDirectoryLabel.AutoSize = true;
            this.ModsDirectoryLabel.Location = new System.Drawing.Point(14, 20);
            this.ModsDirectoryLabel.Name = "ModsDirectoryLabel";
            this.ModsDirectoryLabel.Size = new System.Drawing.Size(178, 32);
            this.ModsDirectoryLabel.TabIndex = 5;
            this.ModsDirectoryLabel.Text = "Mods Directory";
            // 
            // IncludeSnapshotsCheckBox
            // 
            this.IncludeSnapshotsCheckBox.AutoSize = true;
            this.IncludeSnapshotsCheckBox.Font = new System.Drawing.Font("Segoe UI", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.IncludeSnapshotsCheckBox.Location = new System.Drawing.Point(21, 267);
            this.IncludeSnapshotsCheckBox.Name = "IncludeSnapshotsCheckBox";
            this.IncludeSnapshotsCheckBox.Size = new System.Drawing.Size(197, 29);
            this.IncludeSnapshotsCheckBox.TabIndex = 8;
            this.IncludeSnapshotsCheckBox.Text = "Include Snapshots";
            this.IncludeSnapshotsCheckBox.UseVisualStyleBackColor = true;
            this.IncludeSnapshotsCheckBox.CheckedChanged += new System.EventHandler(this.IncludeSnapshotsCheckBox_CheckedChanged);
            // 
            // McVersionLabel
            // 
            this.McVersionLabel.AutoSize = true;
            this.McVersionLabel.Location = new System.Drawing.Point(21, 176);
            this.McVersionLabel.Name = "McVersionLabel";
            this.McVersionLabel.Size = new System.Drawing.Size(201, 32);
            this.McVersionLabel.TabIndex = 7;
            this.McVersionLabel.Text = "Minecraft Version";
            // 
            // McVersionComboBox
            // 
            this.McVersionComboBox.FormattingEnabled = true;
            this.McVersionComboBox.Location = new System.Drawing.Point(21, 221);
            this.McVersionComboBox.Name = "McVersionComboBox";
            this.McVersionComboBox.Size = new System.Drawing.Size(381, 40);
            this.McVersionComboBox.TabIndex = 7;
            this.McVersionComboBox.TextChanged += new System.EventHandler(this.McVersionComboBox_TextChanged);
            // 
            // ParentPanel
            // 
            this.ParentPanel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.ParentPanel.Controls.Add(this.ChildPanel);
            this.ParentPanel.Controls.Add(this.ParentScrollBar);
            this.ParentPanel.Controls.Add(this.LoadingLabel);
            this.ParentPanel.Location = new System.Drawing.Point(447, 147);
            this.ParentPanel.Name = "ParentPanel";
            this.ParentPanel.Padding = new System.Windows.Forms.Padding(1);
            this.ParentPanel.Size = new System.Drawing.Size(1425, 750);
            this.ParentPanel.TabIndex = 8;
            this.ParentPanel.Click += new System.EventHandler(this.ParentPanel_Click);
            // 
            // ChildPanel
            // 
            this.ChildPanel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ChildPanel.Location = new System.Drawing.Point(0, 0);
            this.ChildPanel.Name = "ChildPanel";
            this.ChildPanel.Size = new System.Drawing.Size(1350, 20);
            this.ChildPanel.TabIndex = 3;
            this.ChildPanel.MouseEnter += new System.EventHandler(this.ChildPanel_MouseEnter);
            this.ChildPanel.MouseLeave += new System.EventHandler(this.ChildPanel_MouseLeave);
            this.ChildPanel.MouseWheel += new System.Windows.Forms.MouseEventHandler(this.ChildPanel_MouseWheel);
            // 
            // ParentScrollBar
            // 
            this.ParentScrollBar.Location = new System.Drawing.Point(1353, 0);
            this.ParentScrollBar.Name = "ParentScrollBar";
            this.ParentScrollBar.Size = new System.Drawing.Size(66, 747);
            this.ParentScrollBar.SmallChange = 2;
            this.ParentScrollBar.TabIndex = 2;
            this.ParentScrollBar.Scroll += new System.Windows.Forms.ScrollEventHandler(this.ParentScrollBar_Scroll);
            // 
            // LoadingLabel
            // 
            this.LoadingLabel.AutoSize = true;
            this.LoadingLabel.Font = new System.Drawing.Font("Segoe UI", 50F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.LoadingLabel.Location = new System.Drawing.Point(265, 222);
            this.LoadingLabel.Name = "LoadingLabel";
            this.LoadingLabel.Size = new System.Drawing.Size(852, 177);
            this.LoadingLabel.TabIndex = 10;
            this.LoadingLabel.Text = "⌛ Loading...";
            this.LoadingLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // SearchButton
            // 
            this.SearchButton.Location = new System.Drawing.Point(1361, 65);
            this.SearchButton.Name = "SearchButton";
            this.SearchButton.Size = new System.Drawing.Size(39, 39);
            this.SearchButton.TabIndex = 9;
            this.SearchButton.Text = "🔎";
            this.SearchButton.UseVisualStyleBackColor = true;
            this.SearchButton.Click += new System.EventHandler(this.SearchButton_Click);
            // 
            // CategoryLabel
            // 
            this.CategoryLabel.AutoSize = true;
            this.CategoryLabel.Location = new System.Drawing.Point(18, 495);
            this.CategoryLabel.Name = "CategoryLabel";
            this.CategoryLabel.Size = new System.Drawing.Size(110, 32);
            this.CategoryLabel.TabIndex = 8;
            this.CategoryLabel.Text = "Category";
            // 
            // CategoriesComboBox
            // 
            this.CategoriesComboBox.FormattingEnabled = true;
            this.CategoriesComboBox.Items.AddRange(new object[] {
            "None",
            "Adventure",
            "Cursed",
            "Decoration",
            "Equipment",
            "Food",
            "Library",
            "Magic",
            "Misc",
            "Optimization",
            "Storage",
            "Technology",
            "Utility",
            "Worldgen"});
            this.CategoriesComboBox.Location = new System.Drawing.Point(21, 530);
            this.CategoriesComboBox.Name = "CategoriesComboBox";
            this.CategoriesComboBox.Size = new System.Drawing.Size(242, 40);
            this.CategoriesComboBox.TabIndex = 7;
            this.CategoriesComboBox.Text = "None";
            // 
            // SortByLabel
            // 
            this.SortByLabel.AutoSize = true;
            this.SortByLabel.Location = new System.Drawing.Point(18, 592);
            this.SortByLabel.Name = "SortByLabel";
            this.SortByLabel.Size = new System.Drawing.Size(90, 32);
            this.SortByLabel.TabIndex = 5;
            this.SortByLabel.Text = "Sort By";
            // 
            // SortByComboBox
            // 
            this.SortByComboBox.FormattingEnabled = true;
            this.SortByComboBox.Items.AddRange(new object[] {
            "Relevance",
            "Downloads",
            "Follows",
            "Newest",
            "Updated"});
            this.SortByComboBox.Location = new System.Drawing.Point(21, 627);
            this.SortByComboBox.Name = "SortByComboBox";
            this.SortByComboBox.Size = new System.Drawing.Size(242, 40);
            this.SortByComboBox.TabIndex = 3;
            this.SortByComboBox.Text = "Relevance";
            this.SortByComboBox.TextChanged += new System.EventHandler(this.SortByComboBox_TextChanged);
            // 
            // ResultsPerPageLabel
            // 
            this.ResultsPerPageLabel.AutoSize = true;
            this.ResultsPerPageLabel.Location = new System.Drawing.Point(18, 703);
            this.ResultsPerPageLabel.Name = "ResultsPerPageLabel";
            this.ResultsPerPageLabel.Size = new System.Drawing.Size(186, 32);
            this.ResultsPerPageLabel.TabIndex = 6;
            this.ResultsPerPageLabel.Text = "Results Per Page";
            // 
            // SearchLabel
            // 
            this.SearchLabel.AutoSize = true;
            this.SearchLabel.Location = new System.Drawing.Point(14, 68);
            this.SearchLabel.Name = "SearchLabel";
            this.SearchLabel.Size = new System.Drawing.Size(92, 32);
            this.SearchLabel.TabIndex = 4;
            this.SearchLabel.Text = "Search ";
            // 
            // ResultsPerPageUpDown
            // 
            this.ResultsPerPageUpDown.Location = new System.Drawing.Point(21, 738);
            this.ResultsPerPageUpDown.Name = "ResultsPerPageUpDown";
            this.ResultsPerPageUpDown.Size = new System.Drawing.Size(242, 39);
            this.ResultsPerPageUpDown.TabIndex = 2;
            this.ResultsPerPageUpDown.Value = new decimal(new int[] {
            20,
            0,
            0,
            0});
            // 
            // SearchBox
            // 
            this.SearchBox.Location = new System.Drawing.Point(112, 65);
            this.SearchBox.Name = "SearchBox";
            this.SearchBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.SearchBox.Size = new System.Drawing.Size(1243, 39);
            this.SearchBox.TabIndex = 2;
            this.SearchBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.SearchBox_KeyDown);
            // 
            // GetModsFromModrinthBtn
            // 
            this.GetModsFromModrinthBtn.Enabled = false;
            this.GetModsFromModrinthBtn.Location = new System.Drawing.Point(18, 819);
            this.GetModsFromModrinthBtn.Name = "GetModsFromModrinthBtn";
            this.GetModsFromModrinthBtn.Size = new System.Drawing.Size(150, 46);
            this.GetModsFromModrinthBtn.TabIndex = 9;
            this.GetModsFromModrinthBtn.Text = "Modrinth";
            this.GetModsFromModrinthBtn.UseVisualStyleBackColor = true;
            this.GetModsFromModrinthBtn.Click += new System.EventHandler(this.GetModsFromModrinthBtn_Click);
            // 
            // GetModsFromCurseforgeBtn
            // 
            this.GetModsFromCurseforgeBtn.Location = new System.Drawing.Point(263, 819);
            this.GetModsFromCurseforgeBtn.Name = "GetModsFromCurseforgeBtn";
            this.GetModsFromCurseforgeBtn.Size = new System.Drawing.Size(150, 46);
            this.GetModsFromCurseforgeBtn.TabIndex = 10;
            this.GetModsFromCurseforgeBtn.Text = "Curseforge";
            this.GetModsFromCurseforgeBtn.UseVisualStyleBackColor = true;
            this.GetModsFromCurseforgeBtn.Click += new System.EventHandler(this.GetModsFromCurseforgeBtn_Click);
            // 
            // MenuGroupBox
            // 
            this.MenuGroupBox.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.MenuGroupBox.Controls.Add(this.SearchOptionsLabel);
            this.MenuGroupBox.Controls.Add(this.GetModsFromCurseforgeBtn);
            this.MenuGroupBox.Controls.Add(this.TITLE);
            this.MenuGroupBox.Controls.Add(this.groupBox1);
            this.MenuGroupBox.Controls.Add(this.GetModsFromModrinthBtn);
            this.MenuGroupBox.Controls.Add(this.ResultsPerPageUpDown);
            this.MenuGroupBox.Controls.Add(this.CategoryLabel);
            this.MenuGroupBox.Controls.Add(this.ResultsPerPageLabel);
            this.MenuGroupBox.Controls.Add(this.CategoriesComboBox);
            this.MenuGroupBox.Controls.Add(this.SortByLabel);
            this.MenuGroupBox.Controls.Add(this.SortByComboBox);
            this.MenuGroupBox.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.MenuGroupBox.Location = new System.Drawing.Point(12, -3);
            this.MenuGroupBox.Name = "MenuGroupBox";
            this.MenuGroupBox.Size = new System.Drawing.Size(429, 900);
            this.MenuGroupBox.TabIndex = 27;
            this.MenuGroupBox.TabStop = false;
            this.MenuGroupBox.Click += new System.EventHandler(this.MenuGroupBox_Click);
            // 
            // SearchOptionsLabel
            // 
            this.SearchOptionsLabel.AutoSize = true;
            this.SearchOptionsLabel.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.SearchOptionsLabel.Location = new System.Drawing.Point(18, 435);
            this.SearchOptionsLabel.Name = "SearchOptionsLabel";
            this.SearchOptionsLabel.Size = new System.Drawing.Size(220, 41);
            this.SearchOptionsLabel.TabIndex = 9;
            this.SearchOptionsLabel.Text = "Search Options";
            // 
            // TITLE
            // 
            this.TITLE.AutoSize = true;
            this.TITLE.Font = new System.Drawing.Font("Impact", 17F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point);
            this.TITLE.Location = new System.Drawing.Point(60, 29);
            this.TITLE.Name = "TITLE";
            this.TITLE.Size = new System.Drawing.Size(312, 57);
            this.TITLE.TabIndex = 24;
            this.TITLE.Text = "Piston Installer";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.ModLoaderLabel);
            this.groupBox1.Controls.Add(this.ModLoaderComboBox);
            this.groupBox1.Controls.Add(this.IncludeSnapshotsCheckBox);
            this.groupBox1.Controls.Add(this.McVersionLabel);
            this.groupBox1.Controls.Add(this.McVersionComboBox);
            this.groupBox1.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.groupBox1.Location = new System.Drawing.Point(0, 89);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(429, 330);
            this.groupBox1.TabIndex = 24;
            this.groupBox1.TabStop = false;
            // 
            // OptionsPanel
            // 
            this.OptionsPanel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.OptionsPanel.Controls.Add(this.ModsDirectoryTextBox);
            this.OptionsPanel.Controls.Add(this.SelectModsDirectoryBtn);
            this.OptionsPanel.Controls.Add(this.ModsDirectoryLabel);
            this.OptionsPanel.Controls.Add(this.SearchLabel);
            this.OptionsPanel.Controls.Add(this.SearchButton);
            this.OptionsPanel.Controls.Add(this.SearchBox);
            this.OptionsPanel.Location = new System.Drawing.Point(447, 12);
            this.OptionsPanel.Name = "OptionsPanel";
            this.OptionsPanel.Size = new System.Drawing.Size(1425, 129);
            this.OptionsPanel.TabIndex = 6;
            this.OptionsPanel.Click += new System.EventHandler(this.OptionsPanel_Click);
            // 
            // Install_Mods
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(13F, 32F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1881, 907);
            this.Controls.Add(this.MenuGroupBox);
            this.Controls.Add(this.ParentPanel);
            this.Controls.Add(this.OptionsPanel);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Install_Mods";
            this.Text = "Piston Installer --> Install Mods";
            this.Click += new System.EventHandler(this.Install_Mods_Click);
            this.ParentPanel.ResumeLayout(false);
            this.ParentPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ResultsPerPageUpDown)).EndInit();
            this.MenuGroupBox.ResumeLayout(false);
            this.MenuGroupBox.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.OptionsPanel.ResumeLayout(false);
            this.OptionsPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion


        private TextBox ModsDirectoryTextBox;
        private Button SelectModsDirectoryBtn;
        private ComboBox ModLoaderComboBox;
        private Label ModLoaderLabel;
        private Label ModsDirectoryLabel;
        private Label McVersionLabel;
        private ComboBox McVersionComboBox;
        private CheckBox IncludeSnapshotsCheckBox;
        private Panel ParentPanel;
        private Panel ChildPanel;
        private VScrollBar ParentScrollBar;
        private Label LoadingLabel;
        private Button SearchButton;
        private Label CategoryLabel;
        private ComboBox CategoriesComboBox;
        private Label SortByLabel;
        private ComboBox SortByComboBox;
        private Label ResultsPerPageLabel;
        private Label SearchLabel;
        private NumericUpDown ResultsPerPageUpDown;
        private TextBox SearchBox;
        private Button GetModsFromModrinthBtn;
        private Button GetModsFromCurseforgeBtn;
        private GroupBox MenuGroupBox;
        private Label SearchOptionsLabel;
        private Label TITLE;
        private GroupBox groupBox1;
        private Panel OptionsPanel;
    }
}