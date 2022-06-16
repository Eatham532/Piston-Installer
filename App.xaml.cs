using PistonInstaller.net.Eatham532.pages;

namespace PistonInstaller;

public partial class App : Application
{
	public App(MainPage page)
	{
		InitializeComponent();

		MainPage = page;
		MainPage.DisplayAlert("Piston Installer V0.0.1.0", "THERE MAY BE BUGS! \n\n If so, report them on Discord or Github. The bugs will 99% be visual. They will not affect your minecraft.", "Start");
	}
}
