using Newtonsoft.Json;
using System.ComponentModel;
using System.Net;
using System.IO.Compression;
using Piston_Installer.utils;
using System.Diagnostics;

namespace Piston_Installer
{
    public partial class Install_Fabric : Form
    {
        //A bunch of variables

        public static string responseBody;

        public List<FabricUtils.fabricLoaderVersion> LoaderVersionsList;
        private static string MinecraftDirectory = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\.minecraft";
        private static string InstallDirectory = MinecraftDirectory + "\\.instances";
        private bool LastInstallTextBox_HadShown = false;
        private bool downloadComplete = false;

        public string GameVersion;
        public string LoaderVersion;
        public string ImageDataUri = utils.GetProfileUtils.fabricIcon;


        //Initialisation
        public Install_Fabric()
        {
            this.UseWaitCursor = true;
            InitializeComponent();

            try
            {
                InitializeFabricMcVersions();
                InitializeLoaderVersions();
            }
            catch
            {
                MessageBox.Show("Make sure that you have an active internet connection");
                this.Close();
                return;
            }

            selectImageErrorLabel.Visible = false;
            installProgressBar.Visible = false;
            currentOperationLabel.Visible = false;
            currentOperationLabel.Text = "";
            minecraftDirectoryTextBox.Text = MinecraftDirectory;

        }

        private void includeSnapshotsCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (includeSnapshotsCheckBox.Checked)
            {
                GameVersionComboBox.Enabled = false;
                GameVersionComboBox.Items.Clear();

                for (int i = 0; i < FabricUtils.FabricVersionsList.Count; i++)
                {
                    GameVersionComboBox.Items.Add(FabricUtils.FabricVersionsList[i].version);
                }
                GameVersionComboBox.Enabled = true;

            }
            else
            {
                GameVersionComboBox.Enabled = false;
                GameVersionComboBox.Items.Clear();

                for (int i = 0; i < FabricUtils.FabricVersionsStableList.Count; i++)
                {
                    GameVersionComboBox.Items.Add(FabricUtils.FabricVersionsStableList[i].version);
                }
                GameVersionComboBox.Enabled = true;
            }
        }


        //Initialize Versions
        private async void InitializeFabricMcVersions()
        {
            for (int i = 0; i < FabricUtils.FabricVersionsList.Count; i++)
            {
                if (GameVersionComboBox.Text == "")
                {
                    try
                    {
                        if (FabricUtils.FabricVersionsStableList != null)
                        {
                            GameVersionComboBox.Text = FabricUtils.FabricVersionsStableList[0].version;
                            includeSnapshotsCheckBox.Enabled = true;
                        }
                    }
                    catch { }
                }
            }
        }

        private async void InitializeLoaderVersions()
        {
            string URL = "https://meta.fabricmc.net/v2/versions/loader";
            HttpClient client = new HttpClient();
            HttpResponseMessage response = await client.GetAsync(URL);
            response.EnsureSuccessStatusCode();
            responseBody = await response.Content.ReadAsStringAsync();
            LoaderVersionsList = JsonConvert.DeserializeObject<List<FabricUtils.fabricLoaderVersion>>(responseBody);

            for (int i = 0; i < LoaderVersionsList.Count; i++)
            {
                if (LoaderVersionsList[i].version != null)
                {
                    LoaderVersionComboBox.Items.Add(LoaderVersionsList[i].version);

                    if (LoaderVersionComboBox.Text == "")
                    {
                        if (LoaderVersionsList[i].stable)
                        {
                            LoaderVersionComboBox.Text = LoaderVersionsList[i].version;
                        }
                    }
                }
            }


            if (LoaderVersionComboBox.Text == "")
            {
                LoaderVersionComboBox.Text = LoaderVersionsList[0].version;
            }

            installBtn.Enabled = true;
            LoaderVersionComboBox.Enabled = true;

            this.UseWaitCursor = false;
        }


        //Create instance check box
        private void asInstanceCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (asInstanceCheckBox.Checked)
            {
                installLocationBtn.Enabled = true;
                installLocationTextBox.Enabled = true;
                installLocationTextBox.Text = InstallDirectory;
                InstallDirectory = installLocationTextBox.Text;
                LastInstallTextBox_HadShown = true;
            }
            else
            {
                installLocationBtn.Enabled = false;
                installLocationTextBox.Enabled = false;
                installLocationTextBox.Text = "";
            }
        }


        //Remove textbox cursor
        private void Install_Fabric_Click(object sender, EventArgs e)
        {
            ActiveControl = null;

            if (!Directory.Exists(minecraftDirectoryTextBox.Text))
            {
                minecraftDirectoryTextBox.Text = MinecraftDirectory;
            }

            MinecraftDirectory = minecraftDirectoryTextBox.Text;

            if (installLocationTextBox.Enabled == false && LastInstallTextBox_HadShown == false)
            {
                InstallDirectory = MinecraftDirectory + "\\.Instances";
            }
            else if (installLocationTextBox.Enabled == true)
            {
                InstallDirectory = installLocationTextBox.Text;
            }
        }


        /*INSTALLATION
         * 
         * 
         * 
         * 
         * OF FABRIC */
        private void installBtn_Click(object sender, EventArgs e)
        {
            BeginInstallationOfFabricLoader();
        }


        private void BeginInstallationOfFabricLoader()
        {
            GameVersion = GameVersionComboBox.Text;
            LoaderVersion = LoaderVersionComboBox.Text;

            if (asInstanceCheckBox.Checked)
            {
                Directory.CreateDirectory(InstallDirectory + "\\" + nameTextBox.Text + "\\mods");
            } else
            {
                Directory.CreateDirectory(MinecraftDirectory + "\\mods");
            }

            string zipName = "fabric-loader-" + LoaderVersion + "-" + GameVersion;

            try
            {
                //Download Zip and wait for its completion
                if (!Directory.Exists(MinecraftDirectory + "\\versions\\" + zipName))
                {
                    var downloadZipVar = DownloadFile("https://meta.fabricmc.net/v2/versions/loader/" + GameVersion + "/" + LoaderVersion + "/profile/zip", MinecraftDirectory + "\\versions\\" + zipName + ".zip");

                    while (!downloadComplete)
                    {
                        Application.DoEvents();
                    }

                    downloadComplete = false;

                    ZipFile.ExtractToDirectory(MinecraftDirectory + "\\versions\\" + zipName + ".zip", MinecraftDirectory + "\\versions");
                }
                File.Delete(MinecraftDirectory + "\\versions\\" + zipName + ".zip");
            }
            catch
            {
                MessageBox.Show("Please make sure that you have an active internet connection or that your Minecraft directory is correct.");
                return;
            }

            try
            {
                //Add Profile
                string Launcher_Profiles = File.ReadAllText(MinecraftDirectory + "\\launcher_profiles.json");
                
                if (asInstanceCheckBox.Checked)
                {
                    string gameDir = InstallDirectory + "\\" + GetProfileName("fabric-loader-" + GameVersion);
                    gameDir = gameDir.Replace("\\", "\\\\");

                    Launcher_Profiles = Launcher_Profiles.Insert(20, GetProfileUtils.GetProfile(GetProfileUtils.GetTimeAndDate(), ImageDataUri, GetProfileUtils.GetTimeAndDate(), zipName, GetProfileName("fabric-loader-" + GameVersion), gameDir));
                }
                else
                {
                    Launcher_Profiles = Launcher_Profiles.Insert(20, GetProfileUtils.GetProfile(GetProfileUtils.GetTimeAndDate(), ImageDataUri, GetProfileUtils.GetTimeAndDate(), zipName, GetProfileName("fabric-loader-" + GameVersion), null));
                }

                File.WriteAllText(MinecraftDirectory + "\\launcher_profiles.json", Launcher_Profiles);
            }
            catch
            {
                MessageBox.Show("Could not find launcher_profiles.json. Make sure that you chose the correct Minecraft directory.");
                return;
            }


            //Close app because fabric is installed


            if (MessageBox.Show("Fabric has been successfully installed.\nMost mods require the Fabric Api to be installed. Do you also want to install that?", "Installation Complete", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                MessageBox.Show("Fabric Api will soon be in your Mods folder");
                if (asInstanceCheckBox.Checked)
                {
                    ModrinthUtils.DownloadFabricAPI(InstallDirectory + "\\" + nameTextBox.Text + "\\mods", GameVersion);
                } else
                {
                    ModrinthUtils.DownloadFabricAPI(MinecraftDirectory + "\\mods", GameVersion);
                }
            }

            if (openModsFolderCheckBox.Checked)
            {
                Process.Start("explorer.exe", InstallDirectory + "\\" + nameTextBox.Text + "\\mods");
            }

            this.Hide();
            while (ModrinthUtils.isDownloading)
            {
                Application.DoEvents();
            }

            DialogResult = DialogResult.OK;
            this.Close();
        }

        private string GetProfileName(string Name)
        {
            if (nameTextBox.Text.Length == 0)
            {
                return Name;
            }
            else
            {
                return nameTextBox.Text;
            }
        }

        private void gameIconPictureBox_MouseLeave(object sender, EventArgs e)
        {
            gameIconPictureBox.BorderStyle = BorderStyle.FixedSingle;
        }

        private void gameIconPictureBox_MouseEnter(object sender, EventArgs e)
        {
            gameIconPictureBox.BorderStyle = BorderStyle.Fixed3D;
        }






        private void installLocationBtn_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog();

            if (Directory.Exists(InstallDirectory))
            {
                folderBrowserDialog.InitialDirectory = InstallDirectory;
            }
            else
            {
                folderBrowserDialog.InitialDirectory = MinecraftDirectory;
            }


            if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
            {
                InstallDirectory = folderBrowserDialog.SelectedPath;
                installLocationTextBox.Text = InstallDirectory;
            }
            else
            {
                installLocationTextBox.Text = InstallDirectory;
            }
        }

        private void chooseMinecraftDirectoryBtn_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog();
            folderBrowserDialog.InitialDirectory = MinecraftDirectory;
            if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
            {
                MinecraftDirectory = folderBrowserDialog.SelectedPath;
                minecraftDirectoryTextBox.Text = MinecraftDirectory;
            }
        }


        private void selectImageButton_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.Filter = "PNG files (*.png)|*.png";

                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        System.Drawing.Image img = System.Drawing.Image.FromFile(ofd.FileName);
                        if (img.Width == 128 && img.Height == 128 && Path.GetExtension(ofd.FileName) == ".png")
                        {
                            gameIconPictureBox.Image = img;
                            ImageDataUri = utils.InternetUtils.ConvertImageToDataUri(ofd.FileName);
                        }
                        else
                        {
                            selectImageErrorLabel.Visible = true;
                            selectImageErrorLabel.Text = "The image must be 128x128 pixels and a PNG";
                        }
                    }
                    catch { }
                }
            }
        }

        private void gameIconPictureBox_Click(object sender, EventArgs e)
        {
            selectImageButton_Click(this, e);
        }


        private void changeImageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            selectImageButton_Click(this, e);
        }



















        //Download File Area
        //DONT TOUCH :)

        private bool DownloadFile(string Url, string DownloadLocation)
        {
            try
            {
                installProgressBar.Visible = true;
                currentOperationLabel.Visible = true;

                Uri uri = new Uri(Url);
                string filename = Path.GetFileName(uri.LocalPath);

                using (WebClient wc = new WebClient())
                {
                    //INLCUDE FILE NAME IN DOWNLOAD LOCATION
                    string path = DownloadLocation;
                    wc.DownloadProgressChanged += Wc_DownloadProgressChanged;
                    wc.DownloadFileCompleted += Wc_DownloadFileCompleted;
                    wc.DownloadFileAsync(uri, path);
                    wc.Dispose();
                    return true;
                }
            }
            catch
            {
                MessageBox.Show("Make sure the download link is correct");
                MessageBox.Show(Url);
                return false;
            }
        }

        private void Wc_DownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {
            installProgressBar.Value = e.ProgressPercentage;

            currentOperationLabel.Text = (e.ProgressPercentage + "% | " + e.BytesReceived + " bytes out of " + e.TotalBytesToReceive + " bytes downloaded.");
        }

        private void Wc_DownloadFileCompleted(object sender, AsyncCompletedEventArgs e)
        {
            if (e.Cancelled)
            {
                installProgressBar.Value = 0;
                MessageBox.Show("The download has been cancelled");
                downloadComplete = true;
                return;
            }

            if (e.Error != null)
            {
                installProgressBar.Value = 0;
                MessageBox.Show("An error ocurred while trying to download file");
                downloadComplete = true;
                return;
            }

            installProgressBar.Value = 100;
            downloadComplete = true;
        }
    }
}
