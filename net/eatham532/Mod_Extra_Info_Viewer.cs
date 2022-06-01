using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Piston_Installer.utils;
using CurseForge.APIClient;
using System.Reflection;
using System.Diagnostics;
using Newtonsoft.Json;
using System.Net;

namespace Install_Mods
{
    public partial class Mod_Extra_Info_Viewer : Form
    {
        internal bool IsInitializing = false;
        internal bool IsLoaded = false;
        internal bool ChangedHtml = false;
        internal int GalleryPictureBox_Height = 0;
        internal int GalleryCount = 0;
        internal int VersionCount = 0;
        internal ModrinthUtils.ModrinthProject Project;
        internal string Modloader;
        internal string GameVersion;
        internal string ModsFolder;

        internal string SelectedVersionURI = null;
        internal string SelectedVersionID = null;

        internal bool AllowModDistrubution = true;

        public Mod_Extra_Info_Viewer(string ModID, string name, bool IsModrinth, string Version, string Modloader, string ModsFolder)
        {
            InitializeComponent();
            this.Text = name;
            InitializeModviewer(ModID, IsModrinth);
            this.Modloader = Modloader;
            this.GameVersion = Version;
            this.ModsFolder = ModsFolder;
            this.ShowDialog();
        }

        private async void InitializeModviewer(string ModID, bool IsModrinth)
        {
            while (!this.WebView.EnsureCoreWebView2Async().IsCompletedSuccessfully) {
                Application.DoEvents();
            }
            if (IsModrinth)
            {
                this.Project = await ModrinthUtils.GetProject(ModID.ToString());
                string html = CommonMark.CommonMarkConverter.Convert(Project.body);
                
                this.HtmlTextBox.Text = "<!DOCTYPE html>\n<html>\n<head>\n<meta charset = \"UTF-8\">\n</ head >\n<body>\n" + html.Replace("<img ", "<img style=\"max-width: 590px;\"") + "\n</body>\n</html>";
                this.WebView.NavigateToString("<!DOCTYPE html>\n<html>\n<head>\n<meta charset = \"UTF-8\">\n</ head >\n<body>\n" + html.Replace("<img ", "<img style=\"max-width: 590px;\"") + "\n</body>\n</html>");

                this.DownloadsLabel.Text = "Downloads: " + Project.downloads;
                this.LastUpdatedLabel.Text = "Last Updated: " + Project.updated;
                this.McVersionLabel.Text = "Version: " + GameVersion;
                

                int i = 0;

                
                foreach (var VersionID in this.Project.versions)
                {
                    var VersionsSearch = await ModrinthUtils.GetProjectVersion(VersionID);
                    if (this.AuthorLabel.Text == "Author:")
                    {
                        this.AuthorLabel.Text = "Author ID: " + VersionsSearch.author_id;
                    }
                    if (VersionsSearch.files.Count == 1)
                    {
                        if (VersionsSearch.game_versions.Contains(this.GameVersion) && VersionsSearch.loaders.Contains(Modloader.ToLower()))
                        {
                            AddVersionToVersionList(VersionsSearch.files[0].filename, VersionsSearch.game_versions, VersionsSearch.version_type, VersionsSearch.date_published.ToString(), VersionsSearch.id, VersionsSearch.files[0].url);
                        }
                    } 
                    else if (VersionsSearch.game_versions.Contains(this.GameVersion) && VersionsSearch.loaders.Contains(Modloader.ToLower()))
                    {
                        i = 0;
                        foreach (var file in VersionsSearch.files)
                        {
                            if (file.primary)
                            {
                                AddVersionToVersionList(file.filename, VersionsSearch.game_versions, VersionsSearch.version_type, VersionsSearch.date_published.ToString(), VersionsSearch.id, VersionsSearch.files[i].url);
                                i = -1;
                                break;
                            }
                            i++;
                        }
                        if (i != -1)
                        {
                            MessageBox.Show("CONTACT DEVELOPER");
                        }
                    }
                }

                foreach (var ProjectImage in ModrinthUtils.ModrinthProjectDeserialized.gallery)
                {
                    AddImageToGalleryUri(ProjectImage.url, "GalleryImage" + i.ToString());
                    i++;
                    this.GalleryCount++;
                }
            } 
            else
            {
                ApiClient client = CurseforgeUtils.GetApi();
                var Mod = await client.GetModAsync(Int32.Parse(ModID));
                if (!AllowModDistrubution)
                {
                    this.AllowModDistrubution = false;
                }
                var html = (await client.GetModDescriptionAsync(int.Parse(ModID))).Data;
                this.HtmlTextBox.Text = "<!DOCTYPE html>\n<html>\n<head>\n<meta charset = \"UTF-8\">\n</ head >\n<body>\n" + html.Replace("<img ", "<img style=\"max-width: 590px;\"") + "\n</body>\n</html>";
                this.WebView.NavigateToString("<!DOCTYPE html>\n<html>\n<head>\n<meta charset = \"UTF-8\">\n</ head >\n<body>\n" + html.Replace("<img ", "<img style=\"max-width: 590px;\"") + "\n</body>\n</html>");

                int i = 0;

                foreach (var file in Mod.Data.LatestFiles)
                {
                    if (file.GameVersions.Contains(GameVersion) && file.IsAvailable && file.GameVersions.Contains(Modloader))
                    {
                        AddVersionToVersionList(file.FileName, file.GameVersions, file.FileStatus.ToString(), file.FileDate.ToString(), file.Id.ToString(), file.DownloadUrl);
                    }
                }

                foreach (var ProjectImage in Mod.Data.Screenshots)
                {
                    AddImageToGalleryUri(ProjectImage.Url, "GalleryImage" + i.ToString());
                    i++;
                }

                
            }
        }

        private void HtmlTextBox_TextChanged(object sender, EventArgs e)
        {
            try
            {
                this.ChangedHtml = true;
                this.WebView.NavigateToString(HtmlTextBox.Text);
            } catch { }
        }

        private void WebView_NavigationStarting(object sender, Microsoft.Web.WebView2.Core.CoreWebView2NavigationStartingEventArgs e)
        {
            if (this.IsLoaded && !ChangedHtml)
            {
                Process.Start(new ProcessStartInfo(e.Uri) { UseShellExecute = true });
                e.Cancel = true;
            } 
            else
            {
                this.IsLoaded = true;
                this.ChangedHtml = false;
            }
        }

        private void AddImageToGalleryUri(string imageUri, string name)
        {
            //Add Curseforges description

            PictureBox pictureBox = new PictureBox();
            pictureBox.SizeMode = PictureBoxSizeMode.AutoSize;
            pictureBox.Load(imageUri);
            pictureBox.BorderStyle = BorderStyle.Fixed3D;
            int height = pictureBox.Height;
            int width = pictureBox.Width;
            pictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
            decimal newHeight = decimal.Divide(1200, decimal.Divide(width, height));
            pictureBox.Bounds = new Rectangle(0, GalleryPictureBox_Height, 1200, (int)decimal.Round(newHeight));
            pictureBox.Click += new EventHandler(GalleryImage_Click);
            GalleryPictureBox_Height += pictureBox.Height;
            pictureBox.Name = name;
            this.GalleryPanel.Controls.Add(pictureBox);
            this.GalleryPanel.Height += pictureBox.Height;
        }

        private void AddVersionToVersionList(string name, List<string> versions, string state, string date, string versionID, string uri)
        {
            Color color;
            if (state == "release")
            {
                color = Color.Green;
            }
            else if (state == "beta")
            {
                color = Color.Orange;
            }
            else
            {
                color = Color.Red;
            }

            this.VersionsPanel.Height += 141;
            var modVersionViewer = new Piston_Installer.UserControls.ModVersionViewer();
            modVersionViewer.Location = new System.Drawing.Point(0, 141 * VersionCount);
            this.VersionCount++;
            modVersionViewer.Name = name;
            modVersionViewer.TitleText = name;
            modVersionViewer.VersionURI = uri;

            if (state.Length == 0) { }
            else if (state.Length == 1)
            {
                state = char.ToUpper(state[0]).ToString();
            }
            else
            {
                state = char.ToUpper(state[0]) + state.Substring(1);
            }
            int i = 0;
            string Versions = "";
            foreach (var version in versions)
            {
                Versions += version + ", ";

                i++;
                if (i == 5)
                {
                    Versions += "and more..., ";
                    break;
                }
            }
            Versions = Versions.Remove(Versions.Length - 2);

            modVersionViewer.SubtitleText = Versions;
            modVersionViewer.TabIndex = 0;
            modVersionViewer.VersionID = versionID;
            modVersionViewer.VersionStateColor = color;
            modVersionViewer.DateText = date;
            modVersionViewer.VersionID = versionID;
            modVersionViewer.StateText = state;
            modVersionViewer.DateText = date;
            this.VersionsPanel.Controls.Add(modVersionViewer);
            modVersionViewer.BorderStyle = BorderStyle.FixedSingle;
            modVersionViewer.AutoSize = true;
            modVersionViewer.BackColor = System.Drawing.SystemColors.Control;
            modVersionViewer.Size = new System.Drawing.Size(542, 141);
                        
            modVersionViewer.ControlClick += new EventHandler(ModVersionViewer_Click);
        }



        private void ModVersionViewer_Click(object sender, EventArgs e)
        {
            foreach (object control in VersionsPanel.Controls)
            {
                Piston_Installer.UserControls.ModVersionViewer versionViewer = (Piston_Installer.UserControls.ModVersionViewer)control;

                if (versionViewer.BackColor != Color.Transparent)
                {
                    versionViewer.BackColor = Color.Transparent;
                }
            }

            var versionViewerClicked = (Piston_Installer.UserControls.ModVersionViewer)sender;

            versionViewerClicked.BackColor = Color.Gainsboro;

            this.SelectedVersionID = versionViewerClicked.VersionID;
            this.SelectedVersionURI = versionViewerClicked.VersionURI;
        }

        private void GalleryImage_Click(object sender, EventArgs e)
        {
            Image Image = ((PictureBox)sender).Image;
            var messagebox = new Piston_Installer.net.eatham532.UtilForms.PictureMessagebox(null, Image, this.Text + " gallery image");
        }


        private void downloadModBtn_Click(object sender, EventArgs e)
        {
            if (SelectedVersionID != null)
            {
                DownloadFile(SelectedVersionURI, ModsFolder + "\\" + Path.GetFileName(SelectedVersionURI));
                downloadModBtn.Enabled = false;
                downloadModBtn.Text = "Downloading...";
            }
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
                Directory.CreateDirectory(Path.GetPathRoot(DownloadLocation));
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
                downloadModBtn.Text = "Cancelled";
                downloadModBtn.Enabled = true;
                return;
            }

            if (e.Error != null)
            {
                MessageBox.Show("An error ocurred while trying to download file");
                MessageBox.Show(e.Error.Message);
                downloadModBtn.Text = "Error";
                downloadModBtn.Enabled = true;
                return;
            }

            downloadModBtn.Text = "Completed";
            downloadModBtn.Enabled = true;
        }
    }
}
