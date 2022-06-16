using PistonInstaller.net.Eatham532.variables;

namespace PistonInstaller.net.Eatham532.pages.InstallModloaderFabricPages;

public partial class InstallFabricStep4Page : ContentPage
{
	public InstallFabricStep4Page()
	{
		InitializeComponent();
	}

    private void BackBtn_Clicked(object sender, EventArgs e)
    {
		this.Window.Page = new InstallFabricStep3Page();
    }

    private void HelpButton_Clicked(object sender, EventArgs e)
    {
        DisplayAlert("What is Fabric Api?", "Fabric API is a mod for Fabric that most mods require. It is advised to download this mod as well. \n\n THE FABRIC MODLOADER AND FABRIC API ARE NOT THE SAME!", "OK");
    }

    private void InstallFabricAPICheckBox_CheckedChanged(object sender, CheckedChangedEventArgs e)
    {
        if (InstallFabricAPICheckBox != null)
        {
            InstallFabricVariables.InstallFabricAPI = InstallFabricAPICheckBox.IsChecked;
        }
    }

    private void StartInstallBtn_Clicked(object sender, EventArgs e)
    {
        this.Window.Page = new StartInstallationFabricPage();
    }
}