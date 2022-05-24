using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Piston_Installer.utils
{
    internal class GetProfileUtils
    {
        public static string fabricIcon = ProjectData.Default.FabricIcon;

        public static string forgeIcon = ProjectData.Default.ForgeIcon;
        
        
        
        
        public static string GetProfile(string created, string icon, string lastUsed,
            string lastVersionId, string name, string? gameDir /* + Type: Custom */)
        {
            string profile;

            if (gameDir != null)
            {
                profile = "\n    \"" + name + "\" : {\n      \"created\" :" +
                                                " \"" + created + "\",\n      \"gameDir\" : \"" + gameDir + "\",\n      \"icon\" : \"" + icon + "\",\n      \"lastUsed\" : \"" +
                                                lastUsed + "\",\n      \"lastVersionId\" : \"" + lastVersionId + "\",\n      \"name\" : \"" +
                                                name + "\",\n      \"type\" : \"custom\"\n    },";
            } else
            {
                profile = "\n    \"" + name + "\" : {\n      \"created\" :" +
                                                " \"" + created + "\",\n      \"icon\" : \"" + icon + "\",\n      \"lastUsed\" : \"" +
                                                lastUsed + "\",\n      \"lastVersionId\" : \"" + lastVersionId + "\",\n      \"name\" : \"" +
                                                name + "\",\n      \"type\" : \"custom\"\n    },";
            }
    
            return profile;
        }

        public static string GetTimeAndDate()
        {
            string dateTime = DateTime.UtcNow.ToString("yyyy-MM-dd'T'HH:mm:ss.fff'Z'");

            return dateTime; 
        }
    }
}
