using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using Newtonsoft.Json;

namespace Piston_Installer.utils
{
    public class FabricUtils
    {
        public static string? responseBody;

        public static List<FabricJsonRoot> fabricVersions = new List<FabricJsonRoot>();

        public static List<fabricMcVersion> FabricVersionsStableList = new List<fabricMcVersion>();
        public static List<fabricMcVersion> FabricVersionsList = new List<fabricMcVersion>();


        public class fabricMcVersion
        {
            public string version { get; set; }
            public bool stable { get; set; }
        }

        public class fabricLoaderVersion
        {
            public string separator { get; set; }
            public int build { get; set; }
            public string maven { get; set; }
            public string version { get; set; }
            public bool stable { get; set; }
        }


        public class FabricJsonRoot
        {
            public fabricMcVersion[] fabricVersionRoot { get; set; }
        }

        public static async void SetFabricMcVersionList()
        {
            string URL = "https://meta.fabricmc.net/v2/versions/game";
            HttpClient client = new HttpClient();
            HttpResponseMessage response = await client.GetAsync(URL);
            response.EnsureSuccessStatusCode();
            var responseBody = await response.Content.ReadAsStringAsync();
            FabricVersionsList = JsonConvert.DeserializeObject<List<fabricMcVersion>>(responseBody);

            for (int i = 0; i < FabricVersionsList.Count; i++)
            {
                if (FabricVersionsList[i] != null && FabricVersionsList[i].stable)
                {
                    FabricVersionsStableList.Add(FabricVersionsList[i]);
                }
            }
        }

    }
}
