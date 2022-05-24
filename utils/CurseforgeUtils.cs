using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CurseForge.APIClient;

namespace Piston_Installer.utils
{
    internal class CurseforgeUtils
    {
        //Minecraft game ID = 432
        
        public static ApiClient GetApi()
        {
            //Please Don't

            ApiClient cfApiClient = new ApiClient(ProjectData.Default.ApiKey, 4047, "eatham532@gmail.com");
            return cfApiClient;
        }
    }
}
