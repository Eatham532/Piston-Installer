using PistonInstaller.net.Eatham532.interfaces;
using PistonInstaller.net.Eatham532.variables;

namespace PistonInstaller.net.Eatham532.pages;

public partial class MainPage : ContentPage
{
	public MainPage(IFolderPicker folderPicker)
	{
		InitializeComponent();
		IFolderPickerVariables.folderPicker = folderPicker;
	}

    private void InstallModloaderBtn_Clicked(object sender, EventArgs e)
	{
		this.Window.Page = new ChooseModloaderPage();
    }

    private void MainPage_Loaded(object sender, EventArgs e)
    {
		utils.FabricUtils.InitVersions();
    }

    private void DiscordLogoBtn_Clicked(object sender, EventArgs e)
    {
        Browser.Default.OpenAsync("https://discord.gg/mgP9H568U5");
    }

    private void GithubLogoBtn_Clicked(object sender, EventArgs e)
    {
        Browser.Default.OpenAsync("https://github.com/Eatham532/Piston-Installer");
    }
}

