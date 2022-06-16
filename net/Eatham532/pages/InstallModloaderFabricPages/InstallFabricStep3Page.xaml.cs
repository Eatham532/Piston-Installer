using PistonInstaller.net.Eatham532.variables;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Processing;

namespace PistonInstaller.net.Eatham532.pages.InstallModloaderFabricPages;

public partial class InstallFabricStep3Page : ContentPage
{
	public InstallFabricStep3Page()
	{
		InitializeComponent();
	}

    private void NextBtn_Clicked(object sender, EventArgs e)
    {
        InstallFabricVariables.JointSelectedVersions = "Minecraft " + InstallFabricVariables.SelectedMcVersion + ", Fabric " + InstallFabricVariables.SelectedLoaderVersion;

        if (InstallationNameTxtBox.Text == null)
        {
            InstallFabricVariables.InstallationName = "fabric-loader-" + InstallFabricVariables.SelectedMcVersion;
        }

        this.Window.Page = new InstallFabricStep4Page();
    }

    private void BackBtn_Clicked(object sender, EventArgs e)
    {
        this.Window.Page = new InstallFabricStep2Page();
    }

    private void InstallationNameTxtBox_TextChanged(object sender, TextChangedEventArgs e)
    {
        InstallFabricVariables.InstallationName = this.InstallationNameTxtBox.Text;
    }

    private async void SelectImageBtn_Clicked(object sender, EventArgs e)
    {
        var image = await utils.InternetUtils.FilePickerPng();
        bool ImageAllowed = await VerifyImage(image);
    }

    private async void GameIconImageBtn_Clicked(object sender, EventArgs e)
    {
        var image = await utils.InternetUtils.FilePickerPng();
        bool ImageAllowed = await VerifyImage(image);
    }

    private async Task<bool> VerifyImage(FileResult imageFile) 
    {
        if (imageFile == null)
        {
            return false;
        }

        SixLabors.ImageSharp.Image image = await SixLabors.ImageSharp.Image.LoadAsync(imageFile.FullPath);
        

        if (Path.GetExtension(imageFile.FullPath) == ".png" && image.Width == 128 && image.Height == 128)
        {

            image.Mutate(x => x.Resize(image.Width * 4, image.Height * 4));
            InstallFabricVariables.ImageDataUri = utils.InternetUtils.ConvertImageToDataUri(imageFile.FullPath);
            Directory.CreateDirectory(Common.tempFolder);
            
            image.Save(Common.tempFolder + "\\Image_Resized.png");
            InstallFabricVariables.InstallationImageResized = Common.tempFolder + "\\Image_Resized.png";

            GameIconImageBtn.Source = Common.tempFolder + "\\Image_Resized.png";
        } else
        {
            await DisplayAlert("Invalid Image", "The image must be 128x128 pixels and a PNG file type \n\nThe dimentions of your image is " + image.Width.ToString() + "px wide and " + image.Height.ToString() + "px tall. Your image is a \"" + Path.GetExtension(imageFile.FullPath) + "\"", "Ok");
        }
        return false;
    }
}