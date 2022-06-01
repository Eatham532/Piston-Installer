using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO.Compression;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CurseForge.APIClient;
using Newtonsoft.Json;
using Piston_Installer.utils;

namespace Piston_Installer
{
    public partial class Install_Modpack : Form
    {
        bool extactingModpack = false;
        bool DownloadingFiles = false;

        private string ModpackLocation = "";
        private string ModpackJson = "";
        public ModpackUtils.Root ModpackJsonDeserialized;

        private static string MinecraftDirectory = "C:\\Users\\" + SystemInformation.UserName + "\\AppData\\Roaming\\.minecraft";
        private static string InstallDirectory = MinecraftDirectory + "\\.instances";

        private string tempPath = Path.GetTempPath() + "PistonInstaller";

        private string ImageDataUri;

        public Install_Modpack()
        {
            InitializeComponent();
            Directory.CreateDirectory(tempPath);

            MinecraftDirectoryTxtBox.Text = MinecraftDirectory;
            InstallDirectoryTxtBox.Text = InstallDirectory;

            selectImageErrorLabel.Visible = false;
            PercentageProgressBarLabel.Visible = false;
            ModpackInstallationProgressLabel.Visible = false;
            ProgressOfInstallationProgressBar.Enabled = false;
            DownloadProgressBar.Enabled = false;
            ActiveControl = null;
        }

        private void Install_Modpack_Load(object sender, EventArgs e)
        {

        }

        private void openModpackBtn_Click(object sender, EventArgs e)
        {
            extactingModpack = true;
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Zip file (*.zip)|*.zip|MRPACK file (*.mrpack)|*.mrpack";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                ModpackLocation = ofd.FileName;

                Directory.Delete(tempPath, true);
                Directory.CreateDirectory(tempPath);
                ZipFile.ExtractToDirectory(ofd.FileName, tempPath);


                try
                {
                    ModpackJson = File.ReadAllText(tempPath + "\\manifest.json");
                    ModpackJsonDeserialized = JsonConvert.DeserializeObject<ModpackUtils.Root>(ModpackJson);
                    ModpackNameTxtBox.Text = ModpackJsonDeserialized.name;

                    ModpackNameTxtBox.Text = ModpackJsonDeserialized.name;
                    if (File.Exists(tempPath + "\\" + ModpackJsonDeserialized.overrides + "\\icon.png"))
                    {
                        File.Copy(tempPath + "\\" + ModpackJsonDeserialized.overrides + "\\icon.png", tempPath + "\\icon.png");
                        gameIconPictureBox.Load(tempPath + "\\icon.png");
                        ImageDataUri = InternetUtils.ConvertImageToDataUri(tempPath + "\\" + ModpackJsonDeserialized.overrides + "\\icon.png");
                    } 
                    else
                    {
                        if (ModpackJsonDeserialized.minecraft.modLoaders[0].id.Contains("fabric"))
                        {
                            gameIconPictureBox.Image = global::Piston_Installer.Properties.Resources.FabricIcon;
                            ImageDataUri = GetProfileUtils.fabricIcon;
                        } 
                        else if (ModpackJsonDeserialized.minecraft.modLoaders[0].id.Contains("forge")) 
                        {
                            gameIconPictureBox.Image = global::Piston_Installer.Properties.Resources.ForgeIcon;
                            ImageDataUri = GetProfileUtils.forgeIcon;
                        } 
                        else
                        {
                            MessageBox.Show("Piston Installer cannot work with this modpack.");
                            return;
                        }
                    }
                } catch
                {
                    MessageBox.Show("Invalid Modpack. If ");
                }
            }
            extactingModpack = false;
        }

        private async void installBtn_Click(object sender, EventArgs e)
        {
            if (ModpackJsonDeserialized.minecraft.modLoaders[0].id.Contains("forge"))
            {
                MessageBox.Show("Currently Piston Installer cannot install forge modspacks", "ERROR!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            installBtn.Enabled = false;
            ModpackNameTxtBox.Enabled = false;
            MinecraftDirectoryTxtBox.Enabled = false;
            InstallDirectoryTxtBox.Enabled = false;
            chooseMinecraftDirectoryBtn.Enabled = false;
            InstallDirectoryBtn.Enabled = false;
            selectImageButton.Enabled = false;
            
            
            openModpackBtn.Enabled = false;
            ProgressOfInstallationProgressBar.Enabled = true;

            Directory.CreateDirectory(InstallDirectory + "\\" + ModpackNameTxtBox.Text + "\\mods");
            Directory.CreateDirectory(InstallDirectory + "\\" + ModpackNameTxtBox.Text + "\\resourcepacks");

            ApiClient cfApiClient = CurseforgeUtils.GetApi();
            
            while (extactingModpack)
            {
                Application.DoEvents();
            }

            if (ModpackLocation != "")
            {
                ProgressOfInstallationProgressBar.Maximum = ModpackJsonDeserialized.files.Count + 5;
                ProgressOfInstallationProgressBar.Value = 0;
                ModpackInstallationProgressLabel.Text = "Downloading necessities...";
                ModpackInstallationProgressLabel.Visible = true;
                

                for (int i = 0; i < ModpackJsonDeserialized.files.Count; i++)
                {
                    while (DownloadingFiles)
                    {
                        Application.DoEvents();
                    }


                    if (ModpackJsonDeserialized.files.Count <= 1)
                    {
                        ModpackInstallationProgressLabel.Text = "Downloaded " + i.ToString() + " out of " + ModpackJsonDeserialized.files.Count.ToString() + " file";
                    } else
                    {
                        ModpackInstallationProgressLabel.Text = "Downloaded " + i.ToString() + " out of " + ModpackJsonDeserialized.files.Count.ToString() + " files";
                    }
                    var DownloadUrl = await cfApiClient.GetModFileDownloadUrlAsync(ModpackJsonDeserialized.files[i].projectID, ModpackJsonDeserialized.files[i].fileID);
                    //MessageBox.Show(InstallDirectory + "\\" + ModpackNameTxtBox.Text + "mods" + "\\" + Path.GetFileName(DownloadUrl.Data.ToString()));
                    
                    if (Path.GetExtension(DownloadUrl.Data.ToString()) == ".jar")
                    {
                        await DownloadFile(DownloadUrl.Data.ToString(), InstallDirectory + "\\" + ModpackNameTxtBox.Text + "\\mods\\" + Path.GetFileName(DownloadUrl.Data.ToString()));
                    } 
                    else if (Path.GetExtension(DownloadUrl.Data.ToString()) == ".zip")
                    {
                        await DownloadFile(DownloadUrl.Data.ToString(), InstallDirectory + "\\" + ModpackNameTxtBox.Text + "\\resourcepacks\\" + Path.GetFileName(DownloadUrl.Data.ToString()));
                    } 
                    else
                    {
                        MessageBox.Show("Piston Installer found a file that could not be processed. Please contact the Devs with your issue.",  "ERROR!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                    ProgressOfInstallationProgressBar.Value++;
                }

                if (ModpackJsonDeserialized.files.Count <= 1)
                {
                    ModpackInstallationProgressLabel.Text = "Downloaded " + ModpackJsonDeserialized.files.Count.ToString() + " out of " + ModpackJsonDeserialized.files.Count.ToString() + "file";
                }
                else
                {
                    ModpackInstallationProgressLabel.Text = "Downloaded " + ModpackJsonDeserialized.files.Count.ToString() + " out of " + ModpackJsonDeserialized.files.Count.ToString() + "files";
                }
            }
            cfApiClient.Dispose();

            //Install Modloader
            ModpackInstallationProgressLabel.Text = "Installing " + ModpackJsonDeserialized.minecraft.modLoaders[0];
            ProgressOfInstallationProgressBar.Value++;

            if (ModpackJsonDeserialized.minecraft.modLoaders[0].id.Contains("fabric"))
            {
                ProgressOfInstallationProgressBar.Value++;
                ModpackInstallationProgressLabel.Text = "Installing Fabric...";
                await ModpackInstallFabric(ModpackJsonDeserialized.minecraft.version, ModpackJsonDeserialized.minecraft.modLoaders[0].id.Replace("fabric-", ""));
            }
            else if (ModpackJsonDeserialized.minecraft.modLoaders[0].id.Contains("forge"))
            {
                MessageBox.Show("Currently Piston Installer cannot install forge modspacks", "ERROR!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                MessageBox.Show("OOPS! Piston installer found a modloader that is unable to be processed at this point. If you would like to have this modloader be used please contact the Developers.", "OOPS!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


            //Moving  Overrides
            ModpackInstallationProgressLabel.Text = "Moving overrides...";
            ProgressOfInstallationProgressBar.Value++;

            List<String> OverridesFiles = Directory.GetFiles(tempPath + "\\" + ModpackJsonDeserialized.overrides, "*.*", SearchOption.AllDirectories).ToList();
            DirectoryInfo dirInfo = new DirectoryInfo(InstallDirectory + "\\" + ModpackNameTxtBox.Text);
            foreach (string file in OverridesFiles)
            {
                FileInfo mFile = new FileInfo(file);
                // to remove name collisions
                if (new FileInfo(dirInfo + "\\" + mFile.Name).Exists == false)
                {
                    mFile.MoveTo(dirInfo + "\\" + mFile.Name);
                }
            }

            File.Move(tempPath + "\\modlist.html", dirInfo + "\\modlist.html");

            //Create Profile
            ModpackInstallationProgressLabel.Text = "Creating Profie...";
            ProgressOfInstallationProgressBar.Value++;

            try
            {
                string Launcher_Profiles = File.ReadAllText(MinecraftDirectory + "\\launcher_profiles.json");

                string gameDir = InstallDirectory + "\\" + ModpackNameTxtBox.Text;
                gameDir = gameDir.Replace("\\", "\\\\");

                string LastVersionId = "";
                if (ModpackJsonDeserialized.minecraft.modLoaders[0].id.Contains("fabric"))
                {
                    LastVersionId = ModpackJsonDeserialized.minecraft.modLoaders[0].id.Replace("fabric-", "fabric-loader-") + "-" + ModpackJsonDeserialized.minecraft.version;
                }

                Launcher_Profiles = Launcher_Profiles.Insert(20, GetProfileUtils.GetProfile(GetProfileUtils.GetTimeAndDate(), ImageDataUri, GetProfileUtils.GetTimeAndDate(), LastVersionId, ModpackNameTxtBox.Text, gameDir));

                File.WriteAllText(MinecraftDirectory + "\\launcher_profiles.json", Launcher_Profiles);
            }
            catch
            {
                MessageBox.Show("Could not find launcher_profiles.json. Make sure that you chose the correct Minecraft directory.");
                return;
            }

            ModpackInstallationProgressLabel.Text = "Installation Complete";
            ProgressOfInstallationProgressBar.Value++;
            installBtn.Enabled = true;
            MinecraftDirectoryTxtBox.Enabled = true;
            InstallDirectoryTxtBox.Enabled = true;
            openModpackBtn.Enabled = true;
            chooseMinecraftDirectoryBtn.Enabled = true;
            InstallDirectoryBtn.Enabled = true;
            selectImageButton.Enabled = true;
            DialogResult = DialogResult.OK;
        }

        private async Task ModpackInstallFabric(string GameVersion, string LoaderVersion)
        {
            while (DownloadingFiles)
            {
                Application.DoEvents();
            }

            string zipName = "fabric-loader-" + LoaderVersion + "-" + GameVersion;

            try
            {
                //Download Zip and wait for its completion
                if (!Directory.Exists(MinecraftDirectory + "\\versions\\" + zipName))
                {
                    var downloadZipVar = DownloadFile("https://meta.fabricmc.net/v2/versions/loader/" + GameVersion + "/" + LoaderVersion + "/profile/zip", MinecraftDirectory + "\\versions\\" + zipName + ".zip");

                    while (DownloadingFiles)
                    {
                        Application.DoEvents();
                    }

                    ZipFile.ExtractToDirectory(MinecraftDirectory + "\\versions\\" + zipName + ".zip", MinecraftDirectory + "\\versions");
                    File.Delete(MinecraftDirectory + "\\versions\\" + zipName + ".zip");
                }
            }
            catch
            {
                MessageBox.Show("Please make sure that you have an active internet connection or that your Minecraft directory is correct.");
                return;
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

        private void chooseMinecraftDirectoryBtn_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog();
            DialogResult result = folderBrowserDialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                MinecraftDirectoryTxtBox.Text = folderBrowserDialog.SelectedPath;
                MinecraftDirectory = folderBrowserDialog.SelectedPath;
            }
        }

        private void InstallDirectoryBtn_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog();
            DialogResult result = folderBrowserDialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                InstallDirectoryTxtBox.Text = folderBrowserDialog.SelectedPath;
                InstallDirectory = folderBrowserDialog.SelectedPath;
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












        //Download File Area
        //DONT TOUCH :)

        private async Task DownloadFile(string Url, string DownloadLocation)
        {
            DownloadingFiles = true;
            DownloadProgressBar.Enabled = true;
            try
            {
                DownloadProgressBar.Visible = true;
                PercentageProgressBarLabel.Visible = true;

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
                    return;
                }
            }
            catch
            {
                MessageBox.Show("Make sure the download link is correct");
                MessageBox.Show(Url);
                return;
            }
        }

        private void Wc_DownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {
            DownloadProgressBar.Value = e.ProgressPercentage;
            PercentageProgressBarLabel.Visible = true;
            PercentageProgressBarLabel.Text = (e.ProgressPercentage + "% | " + e.BytesReceived + " bytes out of " + e.TotalBytesToReceive + " bytes downloaded.");
        }

        private void Wc_DownloadFileCompleted(object sender, AsyncCompletedEventArgs e)
        {
            if (e.Cancelled)
            {
                DownloadProgressBar.Value = 0;
                MessageBox.Show("The download has been cancelled");
                DownloadingFiles = false;
                return;
            }

            if (e.Error != null)    
            {
                DownloadProgressBar.Value = 0;
                MessageBox.Show("An error ocurred while trying to download file");
                DownloadingFiles = false;
                return;
            }

            DownloadProgressBar.Value = 100;
            WebClient wc = (WebClient)sender;
            wc.Dispose();
            DownloadingFiles = false;
        }
    }
}
