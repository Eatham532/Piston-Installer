namespace PistonInstaller.net.Eatham532.pages.InstallModloaderFabricPages;

public partial class InstallFabricHomePage : ContentPage
{
	public InstallFabricHomePage()
	{
		InitializeComponent();
	}

    private void BackBtn_Clicked(object sender, EventArgs e)
    {
		this.Window.Page = new ChooseModloaderPage();
    }

    private void StartBtn_Clicked(object sender, EventArgs e)
    {
        this.Window.Page = new InstallFabricStep1Page();
    }

    private void InstallFabricHomePage_Loaded(object sender, EventArgs e)
    {
        variables.InstallFabricVariables.ResetVariables();
    }
}