using System.Diagnostics;
using PistonInstaller.net.Eatham532.variables;

namespace PistonInstaller.net.Eatham532.pages.InstallModloaderFabricPages;

public partial class FinishInstallationFabricPage : ContentPage
{
	public FinishInstallationFabricPage()
	{
		InitializeComponent();
	}

    private void Home_Clicked(object sender, EventArgs e)
    {
        this.Window.Page = new MainPage(IFolderPickerVariables.folderPicker);
    }

    private void Quit_Clicked(object sender, EventArgs e)
    {
        Application.Current.Quit();
    }

    private void OpenModsFolderBtn_Clicked(object sender, EventArgs e)
    {
        if (DeviceInfo.Platform == DevicePlatform.WinUI)
        {
            Process.Start("explorer.exe", InstallFabricVariables.minecraftInstallLocation + "\\" + InstallFabricVariables.InstallationName + "\\mods");
        }
        else if (DeviceInfo.Platform == DevicePlatform.MacCatalyst)
        {
            Process.Start("open", InstallFabricVariables.minecraftInstallLocation + "/" + InstallFabricVariables.InstallationName + "/mods");
        }
    }
}