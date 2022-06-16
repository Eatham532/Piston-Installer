using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PistonInstaller.net.Eatham532.variables
{
    public static class InstallFabricVariables
    {
        public static string minecraftAppdataLocation = null;
        public static string minecraftInstallLocation = null;
        public static string minecraftVersionSelected = null;
        public static string minecraftLoaderVersionSelected = null;
        public static bool createInstance = true;

        public static string SelectedMcVersion = null;
        public static string SelectedLoaderVersion = null;
        public static string JointSelectedVersions = null;

        public static bool IncludeSnapshots = false;
        public static int SelctedIndexMcVersion = 0;
        public static int SelectedIndexLoaderVersion = 0;  // Not Default --> Default is the latest stable version
        public static int IndexStableLoaderVersion = -1;

        public static bool LoaderVersionSelectedIndexUseDefault = true;

        public static string ImageDataUri = ProjectSpecialData.FabricIcon;

        public static string InstallationName = null;
        public static string InstallationImageResized = "fabric_logo.png";

        public static bool InstallFabricAPI = true;

        public static void ResetVariables()
        {
            minecraftAppdataLocation = null;
            minecraftInstallLocation = null;
            minecraftVersionSelected = null;
            minecraftLoaderVersionSelected = null;
            createInstance = true;

            SelectedMcVersion = null;

            if (IndexStableLoaderVersion == -1)
            {
                SelectedLoaderVersion = null;
            }
            else
            {
                SelectedLoaderVersion = utils.FabricUtils.FabricLoaderVersionsList[IndexStableLoaderVersion].Replace(" (Stable)", "");
            }
            JointSelectedVersions = null;

            IncludeSnapshots = false;
            SelctedIndexMcVersion = 0;


            LoaderVersionSelectedIndexUseDefault = true;

            ImageDataUri = ProjectSpecialData.FabricIcon;

            InstallationName = null;
            InstallationImageResized = "fabric_logo.png";

            InstallFabricAPI = true;    
    }
}
}
