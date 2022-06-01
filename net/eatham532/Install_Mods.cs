using Newtonsoft.Json;
using Piston_Installer.UserControls;
using Piston_Installer.utils;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CurseForge.APIClient;
using System.Security.Cryptography;
using CurseForge.APIClient.Models.Fingerprints;
using System.Diagnostics;
using Install_Mods;

namespace Piston_Installer
{
    public partial class Install_Mods : Form
    {
        private int CloneCount = 0;
        private string TempFolder = Path.GetTempPath() + "\\PistonInstaller";
        private int Panel_Height = 0;
        private bool IsSearching = false;
        private bool IsDownloadingMod = false;
        private bool IsProcessingModsFolder = false;
        private bool IsDownloading = false;

        private List<string> ModsInModsFolderModrinthProjectID = new List<string>();
        private List<ModrinthUtils.HashSearch> ModsInModsModrinthFolder = new List<ModrinthUtils.HashSearch>();

        private List<string> ModsInModsFolderCurseforgeProjectID = new List<string>();
        private List<FingerprintMatch> ModsInModsCurseforgeFolder = new List<FingerprintMatch>();

        public Install_Mods()
        {
            InitializeComponent();
            InitializeInstallMods();
        }

        private void InitializeInstallMods()
        {
            SetupModsFolder();
            InitialiseVersionComboBoxFabric();
        }

        //BUGS: Some mods with the same ID in both places. E.G. Mouse tweaks
        private async void SetupModsFolder()
        {
            IsProcessingModsFolder = true;
            ModsInModsModrinthFolder.Clear();
            ModsInModsFolderModrinthProjectID.Clear();
            ModsInModsCurseforgeFolder.Clear();
            ModsInModsFolderCurseforgeProjectID.Clear();
            if (Directory.Exists(ModsDirectoryTextBox.Text))
            {
                foreach (string file in Directory.GetFiles(ModsDirectoryTextBox.Text))
                {
                    if (Path.GetExtension(file) == ".jar")
                    {
                        FileInfo fileInfo = new FileInfo(file);
                        string hex = InternetUtils.FileToSha1Hash(fileInfo.FullName);
                        string URL = "https://api.modrinth.com/v2/version_file/" + hex;

                        try
                        {
                            HttpClient client = new HttpClient();
                            HttpResponseMessage response = await client.GetAsync(URL);

                            response.EnsureSuccessStatusCode();

                            var Response = await response.Content.ReadAsStringAsync();
                            ModrinthUtils.HashSearch ModFile = JsonConvert.DeserializeObject<ModrinthUtils.HashSearch>(Response);
                            ModsInModsFolderModrinthProjectID.Add(ModFile.project_id);
                            ModsInModsModrinthFolder.Add(ModFile);
                        } 
                        catch
                        {
                            ApiClient client = CurseforgeUtils.GetApi();

                            var fingerprint = await client.GetFingerprintMatchesForFileAsync(file);

                            ModsInModsFolderCurseforgeProjectID.Add(fingerprint.Data.ExactMatches[0].Id.ToString());
                            ModsInModsCurseforgeFolder.Add(fingerprint.Data.ExactMatches[0]);
                            client.Dispose();
                        }
                    } 
                }
            }

            IsProcessingModsFolder = false;
        }

        private void ModsDirectoryTextBox_Leave(object sender, EventArgs e)
        {
            SetupModsFolder();
        }


        private void InitialiseVersionComboBoxFabric()
        {
            ActiveControl = null;
            while (FabricUtils.FabricVersionsList.Count == 0 || IsProcessingModsFolder)
            {
                Application.DoEvents();
            }

            for (int i = 0; i < FabricUtils.FabricVersionsStableList.Count; i++)
            {
                if (McVersionComboBox.Text == "")
                {
                    try
                    {
                        if (FabricUtils.FabricVersionsStableList != null)
                        {
                            McVersionComboBox.Text = FabricUtils.FabricVersionsStableList[0].version;
                            IncludeSnapshotsCheckBox.Enabled = true;
                        }
                    }
                    catch { }
                }

                McVersionComboBox.Items.Add(FabricUtils.FabricVersionsStableList[i].version);
            }
            _ = AddItems();
        }






        private async Task AddItems()
        {
            if (IsSearching || IsProcessingModsFolder)
            {
                Application.DoEvents();
            }


            IsSearching = true;
            ActiveControl = null;
            ChildPanel.Controls.Clear();
            CloneCount = 0;
            Panel_Height = 0;
            ChildPanel.Height = 0;


            LoadingLabel.Visible = true;
            this.UseWaitCursor = true;
            try
            {
                Directory.Delete(TempFolder);
            }
            catch { }

            Directory.CreateDirectory(TempFolder);

            //Searching

            if (!GetModsFromCurseforgeBtn.Enabled /* Using CurseForge */)
            {
                ApiClient client = CurseforgeUtils.GetApi();


                //Add Search Filters
                var searchedMods = await client.SearchModsAsync(432, searchFilter: SearchBox.Text, modLoaderType: ModLoaderComboBox.Text == "Fabric" ? CurseForge.APIClient.Models.Mods.ModLoaderType.Fabric : CurseForge.APIClient.Models.Mods.ModLoaderType.Forge, gameVersion: McVersionComboBox.Text, pageSize: (int?)ResultsPerPageUpDown.Value);



                int i = 0;
                ChildPanel.Visible = false;
                foreach (var mod in searchedMods.Data)
                {
                    string enviroment = "";
                    if (mod.AllowModDistribution == false)
                    {
                        enviroment = "Can't download";
                    }


                    AddItemViewer("ItemViewer" + i.ToString(), mod.Logo.Url, mod.Name, mod.Summary, enviroment, mod.Id.ToString());
                    i++;
                }
                client.Dispose();
            } 
            else
            {
                if (SearchBox.Text != "")
                {
                    string search = SearchBox.Text.Replace(" ", "-").ToLower();

                    if (CategoriesComboBox.Text == "None")
                    {
                        await ModrinthUtils.ModrinthSearch(search, "[\"categories:" + ModLoaderComboBox.Text + "\"],[\"versions:" + McVersionComboBox.Text + "\"], [\"project_type: mod\"]", SortByComboBox.Text.ToLower(), 0, 20);
                    }
                    else
                    {
                        await ModrinthUtils.ModrinthSearch(search, "[\"categories:" + ModLoaderComboBox.Text + "\"],[\"versions:" + McVersionComboBox.Text + "\"],[\"categories:" + CategoriesComboBox.Text + "\"], [\"project_type: mod\"]", SortByComboBox.Text.ToLower(), 0, 20);
                    }
                }
                else
                {
                    if (CategoriesComboBox.Text == "None")
                    {
                        await ModrinthUtils.ModrinthSearch("[\"categories:" + ModLoaderComboBox.Text + "\"],[\"versions:" + McVersionComboBox.Text + "\"], [\"project_type: mod\"]", SortByComboBox.Text.ToLower(), (int)ResultsPerPageUpDown.Value);
                    }
                    else
                    {
                        await ModrinthUtils.ModrinthSearch("[\"categories:" + ModLoaderComboBox.Text + "\"],[\"versions:" + McVersionComboBox.Text + "\"],[\"categories:" + CategoriesComboBox.Text + "\"], [\"project_type: mod\"]", SortByComboBox.Text.ToLower(), (int)ResultsPerPageUpDown.Value);
                    }
                }

                ChildPanel.Visible = false;

                int i = 0;
                foreach (ModrinthUtils.Hit searchResult in ModrinthUtils.ModrinthSearchDeserialized.hits)
                {
                    string enviroment = "";
                    if (searchResult.client_side == "required")
                    {
                        if (searchResult.server_side == "unsupported")
                        {
                            enviroment = "Client mod";
                        }
                        else if (searchResult.server_side == "optional")
                        {
                            enviroment = "Client mod";
                        }
                    }
                    else if (searchResult.server_side == "required")
                    {
                        if (searchResult.client_side == "unsupported")
                        {
                            enviroment = "Server only mod";
                        }
                        else if (searchResult.client_side == "optional")
                        {
                            enviroment = "Server mod";
                        }
                    }
                    else if (searchResult.client_side == "optional")
                    {
                        if (searchResult.server_side == "optional")
                        {
                            enviroment = "Universal Mod";
                        }
                    }

                    AddItemViewer("ItemViewer" + i.ToString(), searchResult.icon_url, searchResult.title, searchResult.description, enviroment, searchResult.project_id);
                    i++;
                }
            }


            if (Panel_Height == 0)
            {
                await AddItemViewer("NoResults", "", "There are no results for your search.", "", "", "");
            }

            this.UseWaitCursor = false;
            LoadingLabel.Visible = false;
            ChildPanel.Visible = true;
            IsSearching = false;
        }

        

        private async Task AddItemViewer(string Name, string image, string Title, string Subtitle, string Enviroment, string HiddenData)
        {
            ItemViewer itemViewer = new ItemViewer();
            itemViewer.Name = Name;
            itemViewer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            
            if (GetModsFromModrinthBtn.Enabled /*Curseforge selected*/ ? ModsInModsFolderCurseforgeProjectID.Contains(HiddenData) : ModsInModsFolderModrinthProjectID.Contains(HiddenData))
            {
                itemViewer.ButtonImage = global::Piston_Installer.Properties.Resources.CheckMark;
                itemViewer.ButtonBackgroundColor = Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            }
            else
            {
                itemViewer.ButtonImage = global::Piston_Installer.Properties.Resources.downloadSymbol;
            }

            itemViewer.Location = new System.Drawing.Point(0, Panel_Height);
            Panel_Height += 150;

            if (image != "")
            {
                try
                {
                    itemViewer.SetImageFromUrl(image.Replace(".webp", ".png"));
                }
                catch
                {
                    await DownloadFile(image, TempFolder + "\\" + Name + ".png");
                    itemViewer.Image = Image.FromFile(TempFolder + "\\" + Name + ".png");
                }
            }

            itemViewer.Cursor = Cursors.Hand;
            itemViewer.MaximumSize = new System.Drawing.Size(1350, 150);
            itemViewer.MinimumSize = new System.Drawing.Size(1350, 150);
            itemViewer.Size = new System.Drawing.Size(1350, 150);
            itemViewer.SubtitleText = Subtitle;
            itemViewer.TabIndex = 0;
            itemViewer.TitleText = Title;
            itemViewer.EnviromentText = Enviroment;
            itemViewer.ImageName = Title + "-Logo";
            itemViewer.ButtonClick += new EventHandler(this.ItemViewerButton_Click);
            itemViewer.InterfaceClick += new EventHandler(this.ItemViewer_Interface_Click);
            itemViewer.ImageClick += new EventHandler(this.ItemViewer_Image_Click);
            if (HiddenData == "")
            {
                itemViewer.ButtonVisible = false;
                itemViewer.HiddenData = null;
            }
            else
            {
                itemViewer.Hidden_Data = HiddenData;
            }
            itemViewer.Show();
            ChildPanel.Controls.Add(itemViewer);
            CloneCount++;
            UpdateScrollBar();
        }

        private async void ItemViewerButton_Click(object sender, EventArgs e)
        {
            ItemViewer itemViewer = sender as ItemViewer;
            if (itemViewer.EnviromentText == "Can't download")
            {
                MessageBox.Show("Piston installer is unable to download this mod due to the mod owners disabling 3rd party downloads. Please download this mod from the curseforge website.");
                try
                {
                    string target = "https://www.curseforge.com/minecraft/mc-mods/search?search=" + itemViewer.TitleText.Replace(" ", "+").ToLower();
                    Process.Start(new ProcessStartInfo(target) { UseShellExecute = true });
                }
                catch (System.ComponentModel.Win32Exception noBrowser)
                {
                    if (noBrowser.ErrorCode == -2147467259)
                        MessageBox.Show(noBrowser.Message);
                }
                catch (System.Exception other)
                {
                    MessageBox.Show(other.Message);
                }
                return;
            }

            itemViewer.ButtonImage = global::Piston_Installer.Properties.Resources.Loading;
            itemViewer.ButtonBackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(211)))), ((int)(((byte)(211)))), ((int)(((byte)(211)))));

            if (GetModsFromModrinthBtn.Enabled /* Use Curseforge */)
            {
                DownloadMainModCurseforge(itemViewer.Hidden_Data, itemViewer);
            } 
            else
            {
                DownloadMainModModrinth(itemViewer.Hidden_Data, itemViewer);
            }

            while (itemViewer.ButtonBackgroundColor != System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128))))))
            {
                itemViewer.ButtonImage = global::Piston_Installer.Properties.Resources.Loading1;
                await Task.Delay(250);
                itemViewer.ButtonImage = global::Piston_Installer.Properties.Resources.Loading2;
                await Task.Delay(250);
                itemViewer.ButtonImage = global::Piston_Installer.Properties.Resources.Loading3;
                await Task.Delay(250);
                itemViewer.ButtonImage = global::Piston_Installer.Properties.Resources.Loading;
                await Task.Delay(250);
            }
            itemViewer.ButtonImage = global::Piston_Installer.Properties.Resources.CheckMark;
            itemViewer.ButtonBackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
        }

        private async Task DownloadMainModModrinth(string ModID, ItemViewer itemViewer)
        {
            while (IsDownloadingMod)
            {
                Application.DoEvents();
            }

            IsDownloadingMod = true;

            if (!Directory.Exists(ModsDirectoryTextBox.Text))
            {
                Directory.CreateDirectory(ModsDirectoryTextBox.Text);
            }

            await ModrinthUtils.GetProject(ModID);
            
            for (int i = 0; i < ModrinthUtils.ModrinthProjectDeserialized.versions.Count; i++)
            {
                await ModrinthUtils.GetProjectVersion(ModrinthUtils.ModrinthProjectDeserialized.versions[i]);
                if (ModrinthUtils.ModrinthVersionDeserialized.game_versions.Contains(McVersionComboBox.Text) && ModrinthUtils.ModrinthVersionDeserialized.loaders.Contains(ModLoaderComboBox.Text.ToLower()))
                {
                    Uri uri = new Uri(ModrinthUtils.ModrinthVersionDeserialized.files[0].url);
                    await DownloadFile(ModrinthUtils.ModrinthVersionDeserialized.files[0].url, ModsDirectoryTextBox.Text + "\\" + Path.GetFileName(uri.LocalPath));

                    while (IsDownloading)
                    {
                        Application.DoEvents();
                    }
                    break;
                }
            }

            itemViewer.ButtonImage = global::Piston_Installer.Properties.Resources.CheckMark;
            itemViewer.ButtonBackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            itemViewer.ButtonImage = global::Piston_Installer.Properties.Resources.CheckMark;
            await Task.Delay(500);
            itemViewer.ButtonImage = global::Piston_Installer.Properties.Resources.CheckMark;
            SetupModsFolder();
            IsDownloadingMod = false;
        }

        private async Task DownloadMainModCurseforge(string ModID, ItemViewer itemViewer)
        {
            ApiClient client = CurseforgeUtils.GetApi();

            var modFiles = await client.GetModFilesAsync(Int32.Parse(ModID));

            string modloader = "";
            int FileID = 0;
            bool IsTrue = false;

            foreach (var modFileItem in modFiles.Data)
            {
                foreach (var modVersionsItem in modFileItem.GameVersions)
                {
                    if (modVersionsItem == McVersionComboBox.Text && modloader == ModLoaderComboBox.Text)
                    {
                        IsTrue = true;
                        FileID = modFileItem.Id;
                        break;
                    }
                    else if (modVersionsItem == "Forge" || modVersionsItem == "Fabric") 
                    {
                        modloader = modVersionsItem;
                    }
                }

                if (IsTrue)
                {
                    break;
                }
            }

            client.Dispose();

            var downloadURLResponse = await client.GetModFileDownloadUrlAsync(Int32.Parse(ModID), FileID);

            await DownloadFile(downloadURLResponse.Data, ModsDirectoryTextBox.Text + "\\" + Path.GetFileName(downloadURLResponse.Data));

            while (IsDownloading)
            {
                Application.DoEvents();
            }

            itemViewer.ButtonImage = global::Piston_Installer.Properties.Resources.CheckMark;
            itemViewer.ButtonBackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            itemViewer.ButtonImage = global::Piston_Installer.Properties.Resources.CheckMark;
            await Task.Delay(500);
            itemViewer.ButtonImage = global::Piston_Installer.Properties.Resources.CheckMark;
            SetupModsFolder();
            IsDownloadingMod = false;
        }

        private async void ItemViewer_Interface_Click(object sender, EventArgs e)
        {
            this.Enabled = false;
            ItemViewer itemViewer = (ItemViewer)sender;
            if (itemViewer.HiddenData == null)
            {
                return;
            }
            ApiClient client = CurseforgeUtils.GetApi();

            Mod_Extra_Info_Viewer modViewer = new Mod_Extra_Info_Viewer(itemViewer.Hidden_Data, itemViewer.TitleText, this.GetModsFromCurseforgeBtn.Enabled, McVersionComboBox.Text, ModLoaderComboBox.Text, this.ModsDirectoryTextBox.Text);

            SetupModsFolder();
            AddItems();
            client.Dispose();
            this.Enabled = true;
        }

        private void ItemViewer_Image_Click(object sender, EventArgs e)
        {
            var ItemViewer = (ItemViewer)sender;
            Image Image = ItemViewer.Image;
            var messagebox = new net.eatham532.UtilForms.PictureMessagebox(null, Image, ItemViewer.ImageName);
        }






        //Reset Item Boxes
        private void SearchButton_Click(object sender, EventArgs e)
        {
            
            _ = AddItems();
        }
        private void ModLoaderComboBox_TextChanged(object sender, EventArgs e)
        {
            if (ModLoaderComboBox.Text == "Forge")
            {
                IncludeSnapshotsCheckBox.Checked = false;
                IncludeSnapshotsCheckBox.Enabled = false;
            } else
            {
                IncludeSnapshotsCheckBox.Enabled = true;
            }
            _ = AddItems();
        }

        private void McVersionComboBox_TextChanged(object sender, EventArgs e)
        {
            _ = AddItems();
        }

        private void SortByComboBox_TextChanged(object sender, EventArgs e)
        {
            _ = AddItems();
        }

        private void SearchBox_KeyDown(object sender, KeyEventArgs e)
        {
            if ((this.ActiveControl == SearchBox) && (e.KeyData == Keys.Return))
            {
                _ = AddItems();
            }
        }



        //Scroll
        private void UpdateScrollBar()
        {
            ParentScrollBar.Maximum = ChildPanel.Height - 550;
            ParentScrollBar.Minimum = 0;
            ChildPanel.Height = 150 * CloneCount;
        }

        private void ParentScrollBar_Scroll(object sender, ScrollEventArgs e)
        {
            ChildPanel.Top = ParentScrollBar.Value * -1;
        }
        private void ChildPanel_MouseWheel(object sender, MouseEventArgs e)
        {
            if (e.Delta > 0)
            {
                //Up
                if (ParentScrollBar.Value > 50)
                {
                    ParentScrollBar.Value -= 50;
                    ChildPanel.Top = ParentScrollBar.Value * -1;
                } 
                else if (ParentScrollBar.Value > 0)
                {
                    ParentScrollBar.Value = 0;
                    ChildPanel.Top = ParentScrollBar.Value * -1;
                }
            }
            else
            {
                //Down
                if (ParentScrollBar.Value < ParentScrollBar.Maximum - 50)
                {
                    ParentScrollBar.Value += 50;
                    ChildPanel.Top = ParentScrollBar.Value * -1;
                }
                else if (ParentScrollBar.Value < ParentScrollBar.Maximum)
                {
                    ParentScrollBar.Value = ParentScrollBar.Maximum;
                    ChildPanel.Top = ParentScrollBar.Value * -1;
                }
                
                
            }
        }

        private void ChildPanel_MouseEnter(object sender, EventArgs e)
        {
            ChildPanel.Focus();
        }

        private void ChildPanel_MouseLeave(object sender, EventArgs e)
        {
            this.ActiveControl = null;
        }



        //Active Controll = Null
        private void Install_Mods_Click(object sender, EventArgs e)
        {
            ActiveControl = null;
        }

        private void MenuGroupBox_Click(object sender, EventArgs e)
        {
            ActiveControl = null;
        }

        private void OptionsPanel_Click(object sender, EventArgs e)
        {
            ActiveControl = null;
        }

        private void ParentPanel_Click(object sender, EventArgs e)
        {
            ActiveControl = null;
        }





        private void IncludeSnapshotsCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (IncludeSnapshotsCheckBox.Checked)
            {
                McVersionComboBox.Enabled = false;
                McVersionComboBox.Items.Clear();

                for (int i = 0; i < FabricUtils.FabricVersionsList.Count; i++)
                {
                    McVersionComboBox.Items.Add(FabricUtils.FabricVersionsList[i].version);
                }
                McVersionComboBox.Enabled = true;

            }
            else
            {
                McVersionComboBox.Enabled = false;
                McVersionComboBox.Items.Clear();

                for (int i = 0; i < FabricUtils.FabricVersionsStableList.Count; i++)
                {
                    McVersionComboBox.Items.Add(FabricUtils.FabricVersionsStableList[i].version);
                }
                McVersionComboBox.Enabled = true;
            }
        }

        private void SelectModsDirectoryBtn_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            DialogResult result = fbd.ShowDialog();
            if (result == DialogResult.OK)
            {
                ModsDirectoryTextBox.Text = fbd.SelectedPath;
                SetupModsFolder();
            }
        }



        //Switch Modlocations
        private void GetModsFromModrinthBtn_Click(object sender, EventArgs e)
        {
            this.GetModsFromModrinthBtn.Enabled = false;
            this.GetModsFromCurseforgeBtn.Enabled = true;

            AddItems();
        }

        private void GetModsFromCurseforgeBtn_Click(object sender, EventArgs e)
        {
            this.GetModsFromCurseforgeBtn.Enabled = false;
            this.GetModsFromModrinthBtn.Enabled = true;

            AddItems();
        }














        /*
         *
        Download File Area
        DONT TOUCH :)
        *
        */

        private async Task DownloadFile(string Url, string DownloadLocation)
        {

            try
            {
                Uri uri = new Uri(Url);
                string filename = Path.GetFileName(uri.LocalPath);

                using (WebClient wc = new WebClient())
                {
                    IsDownloading = true;
                    //INLCUDE FILE NAME IN DOWNLOAD LOCATION

                    string path = DownloadLocation;
                    wc.DownloadProgressChanged += Wc_DownloadProgressChanged;
                    wc.DownloadFileCompleted += Wc_DownloadFileCompleted;
                    wc.DownloadFileAsync(uri, path);
                    wc.Dispose();
                }
            }
            catch
            {
                MessageBox.Show("Make sure the download link is correct");
                MessageBox.Show(Url);
            }
        }

        private void Wc_DownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {
            
        }

        private void Wc_DownloadFileCompleted(object sender, AsyncCompletedEventArgs e)
        {
            if (e.Cancelled)
            {
                MessageBox.Show("The download has been cancelled");
                IsDownloading = false;
                return;
            }

            if (e.Error != null)
            {
                MessageBox.Show("An error ocurred while trying to download file");
                MessageBox.Show(e.Error.Message);
                IsDownloading = false;
                return;
            }
            IsDownloading = false;
        }
    }
}