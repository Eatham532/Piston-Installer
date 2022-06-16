using PistonInstaller.net.Eatham532.variables;
using System.ComponentModel;
using System.Net;
using PistonInstaller.net.Eatham532.utils;
using System.IO.Compression;

namespace PistonInstaller.net.Eatham532.pages.InstallModloaderFabricPages;

public partial class StartInstallationFabricPage : ContentPage
{
    private static bool IsDownloading = false;
	public StartInstallationFabricPage()
	{
		InitializeComponent();
	}

	private async Task BeginInstallation()
    {
        await Task.Delay(2000);
        string GameVersion = InstallFabricVariables.SelectedMcVersion;
        string LoaderVersion = InstallFabricVariables.SelectedLoaderVersion;
        string MinecraftDirectory = InstallFabricVariables.minecraftAppdataLocation;
        string InstallDirectory = InstallFabricVariables.minecraftInstallLocation;


        this.CurrentOperationLabel.Text = "Creating Directory";
        this.InstallationProgressBar.Progress = 0.2;

        //Create Main Directory
        if (InstallFabricVariables.createInstance)
        {
            Directory.CreateDirectory(InstallDirectory + "\\" + InstallFabricVariables.InstallationName + "\\mods");
        }
        else
        {
            Directory.CreateDirectory(MinecraftDirectory + "\\mods");
        }


        string zipName = "fabric-loader-" + LoaderVersion + "-" + GameVersion;


        this.CurrentOperationLabel.Text = "Downloading FabricMc version";
        this.InstallationProgressBar.Progress = 0.4;

        

        try
        {
            //Download Zip and wait for its completion
            if (!Directory.Exists(MinecraftDirectory + "\\versions\\" + zipName))
            {
                await DownloadFile("https://meta.fabricmc.net/v2/versions/loader/" + GameVersion + "/" + LoaderVersion + "/profile/zip", MinecraftDirectory + "\\versions\\" + zipName + ".zip");

                ZipFile.ExtractToDirectory(MinecraftDirectory + "\\versions\\" + zipName + ".zip", MinecraftDirectory + "\\versions");

                File.Delete(MinecraftDirectory + "\\versions\\" + zipName + ".zip");
            }
        }
        catch
        {
            await DisplayAlert("Error!", "Please make sure that you have an active internet connection or that your Minecraft directory is correct.", "OK");
            return;
        }


        CurrentOperationLabel.Text = "Creating profile";
        this.InstallationProgressBar.Progress = 0.6;

        try
        {
            //Add Profile
            string Launcher_Profiles = File.ReadAllText(MinecraftDirectory + "\\launcher_profiles.json");

            if (InstallFabricVariables.createInstance)
            {
                string gameDir = InstallDirectory + "\\" + InstallFabricVariables.InstallationName;
                gameDir = gameDir.Replace("\\", "\\\\");

                Launcher_Profiles = Launcher_Profiles.Insert(20, GetProfileUtils.GetProfile(GetProfileUtils.GetTimeAndDate(), InstallFabricVariables.ImageDataUri, GetProfileUtils.GetTimeAndDate(), zipName, InstallFabricVariables.InstallationName, gameDir));
            }
            else
            {
                Launcher_Profiles = Launcher_Profiles.Insert(20, GetProfileUtils.GetProfile(GetProfileUtils.GetTimeAndDate(), InstallFabricVariables.ImageDataUri, GetProfileUtils.GetTimeAndDate(), zipName, InstallFabricVariables.InstallationName, null));
            }

            File.WriteAllText(MinecraftDirectory + "\\launcher_profiles.json", Launcher_Profiles);
        }
        catch
        {
            await DisplayAlert("No launcher_profiles.json", "Could not find launcher_profiles.json. Make sure that you chose the correct Minecraft directory.", "OK");
            return;
        }


        this.InstallationProgressBar.Progress = 0.8;

        //Download FabricAPI
        if (InstallFabricVariables.InstallFabricAPI)
        {
            this.CurrentOperationLabel.Text = "Downloading FabricAPI";
            if (InstallFabricVariables.createInstance)
            {
                await ModrinthUtils.DownloadFabricAPI(InstallDirectory + "\\" + InstallFabricVariables.InstallationName + "\\mods", GameVersion);
            }
            else
            {
                await ModrinthUtils.DownloadFabricAPI(MinecraftDirectory + "\\mods", GameVersion);
            }
        }

        this.InstallationProgressBar.Progress = 1;

        this.CurrentOperationLabel.Text = "Installation Complete";
        //Open Modsfolder
        this.Window.Page = new FinishInstallationFabricPage();
    }

    private void InstallationPage_Loaded(object sender, EventArgs e)
    {
        BeginInstallation();
    }






















    //Download File Area
    //DONT TOUCH :)

    private async Task DownloadFile(string Url, string DownloadLocation)
    {
        while (IsDownloading)
        {
            await Task.Delay(500);
        }
        IsDownloading = true;

        using (WebClient wc = new WebClient())
        {
            wc.DownloadProgressChanged += wc_DownloadProgressChanged;
            wc.DownloadFileCompleted += wc_DownloadFileCompleted;
            wc.DownloadFileAsync(
                // Param1 = Link of file
                new System.Uri(Url),
                // Param2 = Path to save
                DownloadLocation
            );



            while (IsDownloading)
            {
                await Task.Delay(500);
            }

            wc.Dispose();
        }
    }

    private void wc_DownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e)
    {
        
    }

    private void wc_DownloadFileCompleted(object sender, AsyncCompletedEventArgs e)
    {
        if (e.Cancelled)
        {
            DisplayAlert("Download Canceled", "The download has been cancelled", "OK");
            IsDownloading = false;
            return;
        }

        if (e.Error != null)
        {
            DisplayAlert("Error!", "There was an error while trying to download a file", "OK");
            IsDownloading = false;
            return;
        }
        IsDownloading = false;
    }
}