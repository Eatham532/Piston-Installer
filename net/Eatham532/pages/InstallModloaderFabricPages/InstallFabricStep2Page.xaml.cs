using PistonInstaller.net.Eatham532.variables;

namespace PistonInstaller.net.Eatham532.pages.InstallModloaderFabricPages;

public partial class InstallFabricStep2Page : ContentPage
{
    private bool IsLoading = false;
	public InstallFabricStep2Page()
	{
		InitializeComponent();


        this.McVersionPicker.ItemsSource = InstallFabricVariables.IncludeSnapshots 
            ? utils.FabricUtils.FabricMcVersionsList : utils.FabricUtils.FabricMcVersionsStableList;
        this.McVersionPicker.SelectedIndex = InstallFabricVariables.SelctedIndexMcVersion;
	}

    private async void NextBtn_Clicked(object sender, EventArgs e)
    {
        if (IsLoading)
        {
            return;
        }
        if (this.LoaderVersionPicker.SelectedIndex != -1 && this.McVersionPicker.SelectedIndex != -1)
        {
            IsLoading = true;
            var Versions = await utils.FabricUtils.GetGameVersionLoaderVersions(InstallFabricVariables.SelectedMcVersion);
          
            foreach (var version in Versions)
            {
                if (version.loader.version == InstallFabricVariables.SelectedLoaderVersion)
                {
                    IsLoading = false;
                    this.Window.Page = new InstallFabricStep3Page();
                    return;
                }
            }

            IsLoading = false;

            DisplayAlert("Invalid Options", "Your selected minecraft version does not support your selected loader version " + InstallFabricVariables.SelectedLoaderVersion, "Ok");
        }
        else
        {
            DisplayAlert("Invalid Options", "One or more of your options are not valid", "Ok");
        }
    }

    private void BackBtn_Clicked(object sender, EventArgs e)
    {
        if (IsLoading)
        {
            return;
        }
        this.Window.Page = new InstallFabricStep1Page();
    }

    private void McVersionPicker_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (this.McVersionPicker.SelectedIndex == -1 || IsLoading)
        {
            return;
        }

        InstallFabricVariables.SelctedIndexMcVersion = this.McVersionPicker.SelectedIndex;

        InstallFabricVariables.SelectedMcVersion = !this.McVersionTypeCheckBox.IsChecked ? 
            utils.FabricUtils.FabricMcVersionsStableList[this.McVersionPicker.SelectedIndex] :
            utils.FabricUtils.FabricMcVersionsList[this.McVersionPicker.SelectedIndex];
    }

    private void LoaderVersionPicker_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (this.LoaderVersionPicker.SelectedIndex == -1 || IsLoading)
        {
            return;
        }

        InstallFabricVariables.SelectedIndexLoaderVersion = this.LoaderVersionPicker.SelectedIndex;

        InstallFabricVariables.SelectedLoaderVersion =
            utils.FabricUtils.FabricLoaderVersionsList[this.LoaderVersionPicker.SelectedIndex].Replace(" (Stable)", "");
    }

    private void McVersionTypeCheckBox_CheckedChanged(object sender, CheckedChangedEventArgs e)
    {
        if (McVersionTypeCheckBox != null && IsLoading)
        {
            McVersionTypeCheckBox.IsChecked = !McVersionTypeCheckBox.IsChecked;
            return;
        }
        if (McVersionTypeCheckBox != null)
        {
            InstallFabricVariables.IncludeSnapshots = this.McVersionTypeCheckBox.IsChecked;

            if (McVersionTypeCheckBox.IsChecked)
            {
                McVersionPicker.ItemsSource = utils.FabricUtils.FabricMcVersionsList;
                McVersionPicker.SelectedIndex = InstallFabricVariables.SelctedIndexMcVersion;
            }
            else
            {
                McVersionPicker.ItemsSource = utils.FabricUtils.FabricMcVersionsStableList;

                if (McVersionPicker.SelectedIndex == -1)
                {
                    McVersionPicker.SelectedIndex = 0;
                }
            }
        }
    }
}