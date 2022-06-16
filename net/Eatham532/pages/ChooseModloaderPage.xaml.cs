using PistonInstaller.net.Eatham532.variables;

namespace PistonInstaller.net.Eatham532.pages;

public partial class ChooseModloaderPage : ContentPage
{
	public ChooseModloaderPage()
	{
        InitializeComponent();
	}

    private void BackBtn_Clicked(object sender, EventArgs e)
    {
        this.Window.Page = new MainPage(IFolderPickerVariables.folderPicker);
    }

    private void InstallFabricBtn_Clicked(object sender, EventArgs e)
    {
        this.Window.Page = new InstallModloaderFabricPages.InstallFabricHomePage();
    }

    private void InstallForgeBtn_Clicked(object sender, EventArgs e)
    {

    }
}