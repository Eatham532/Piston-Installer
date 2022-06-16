using PistonInstaller.net.Eatham532.variables;

namespace PistonInstaller.net.Eatham532.pages.InstallModloaderFabricPages;

public partial class InstallFabricStep1Page : ContentPage
{

    public InstallFabricStep1Page()
	{
		InitializeComponent();
	}

    private void ContentPage_Loaded(object sender, EventArgs e)
    {
		if (InstallFabricVariables.minecraftAppdataLocation != null)
        {
            this.McAppdataLocationTxtBox.Text = InstallFabricVariables.minecraftAppdataLocation;
        }
        else
        {
            if (DeviceInfo.Platform == DevicePlatform.WinUI)
            {
                this.McAppdataLocationTxtBox.Text = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\.minecraft";
            } 
            else if (DeviceInfo.Platform == DevicePlatform.MacCatalyst)
            {
                this.McAppdataLocationTxtBox.Text = "~/Library/Application Support/minecraft";
            } 
            else
            {
                DisplayAlert("WHAT!", "Get out of here! You are not accepted! \n\n Things may not work as expected because your device is not supported.", "No");
            }
        }

        if (InstallFabricVariables.minecraftInstallLocation != null)
        {
            this.McInstallLocationTxtBox.Text = InstallFabricVariables.minecraftInstallLocation;
        } 
        else
        {
            this.McInstallLocationTxtBox.Text = InstallFabricVariables.minecraftAppdataLocation + "\\.instances";
        }
    }

    private async void McAppdataLocationBtn_Clicked(object sender, EventArgs e)
    {
        var folder = await IFolderPickerVariables.folderPicker.PickFolder();
        if (folder != "NUL")
        {
            McAppdataLocationTxtBox.Text = folder;
            SemanticScreenReader.Announce(McAppdataLocationTxtBox.Text);
        }

    }

    private void NextBtn_Clicked(object sender, EventArgs e)
    {
        if (Directory.Exists(McAppdataLocationTxtBox.Text) && McAppdataLocationTxtBox.Text != null && McInstallLocationTxtBox.Text != null)
        {
            if (File.Exists(McAppdataLocationTxtBox.Text + "\\launcher_profiles.json"))
            {
                this.Window.Page = new InstallFabricStep2Page();
            }
            else
            {
                DisplayAlert("Could not find launcher_profiles.json", "Make sure that you have launched the Minecraft Launcher before you install FabricMc", "Sure");
            }
        }
        else
        {
            DisplayAlert("Empty Loaction", "Make sure that you have specified the Appdata location and Install location", "Ok");
        }
    }

    private void BackBtn_Clicked(object sender, EventArgs e)
    {
        this.Window.Page = new InstallFabricHomePage();
    }

    private void McInstallLocationTxtBox_TextChanged(object sender, TextChangedEventArgs e)
    {
        InstallFabricVariables.minecraftInstallLocation = McInstallLocationTxtBox.Text;
    }

    private void McAppdataLocationTxtBox_TextChanged(object sender, TextChangedEventArgs e)
    {
        InstallFabricVariables.minecraftAppdataLocation = this.McAppdataLocationTxtBox.Text;
    }

    private void CreateInstanceCheckBox_CheckedChanged(object sender, CheckedChangedEventArgs e)
    {
        InstallFabricVariables.createInstance = CreateInstanceCheckBox.IsChecked;
        this.McInstallLocationBtn.IsEnabled = InstallFabricVariables.createInstance;
        this.McInstallLocationTxtBox.IsEnabled = InstallFabricVariables.createInstance;
    }
    private void HelpButton_Clicked(object sender, EventArgs e)
    {
        DisplayAlert("What is an instance?", "Creating an instance will create a new folder which will contain all the game files for that specific version. E.g. A version specific mods folder or a worlds folder with worlds specific to that version.", "I understand now");
    }
}