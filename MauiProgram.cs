using PistonInstaller.net.Eatham532.pages;
using PistonInstaller.net.Eatham532.pages.InstallModloaderFabricPages;
using PistonInstaller.net.Eatham532.interfaces;

namespace PistonInstaller;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();
		builder
			.UseMauiApp<App>()
			.ConfigureFonts(fonts =>
			{
				fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
				fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
			});

#if WINDOWS
        builder.Services.AddTransient<IFolderPicker, Platforms.Windows.FolderPicker>();
#elif MACCATALYST
		builder.Services.AddTransient<IFolderPicker, Platforms.MacCatalyst.FolderPicker>();
#endif
        builder.Services.AddTransient<App>();
        builder.Services.AddTransient<MainPage>();

        return builder.Build();
	}
}
