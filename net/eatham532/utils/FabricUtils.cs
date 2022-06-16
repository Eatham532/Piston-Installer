
using Newtonsoft.Json;

namespace PistonInstaller.net.Eatham532.utils
{
    public class FabricUtils
    {
        public static string? responseBody;

        public static List<fabricMcVersion> FabricMcVersionsStableListDeserialized = new List<fabricMcVersion>();
        public static List<fabricMcVersion> FabricMcVersionsListDeserialized = new List<fabricMcVersion>();
        
        public static List<string> FabricMcVersionsStableList = new List<string>();
        public static List<string> FabricMcVersionsList = new List<string>();


        public static List<fabricMcVersion> FabricLoaderVersionsListDeserialized = new List<fabricMcVersion>();
        public static List<string> FabricLoaderVersionsList = new List<string>();


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


        

        public static async Task SetFabricMcVersionList()
        {
            HttpClient client = new HttpClient();
            HttpResponseMessage response = await client.GetAsync("https://meta.fabricmc.net/v2/versions/game");
            response.EnsureSuccessStatusCode();
            FabricMcVersionsListDeserialized = JsonConvert.DeserializeObject<List<fabricMcVersion>>(await response.Content.ReadAsStringAsync());

            fabricMcVersion StableVersion = null;

            foreach (var version in FabricMcVersionsListDeserialized.ToList())
            {
                if (version.stable)
                {
                    FabricMcVersionsStableListDeserialized.Add(version);
                    FabricMcVersionsStableList.Add(version.version);
                }

                FabricMcVersionsListDeserialized.Add(version);
                FabricMcVersionsList.Add(version.version);
            }

            client.Dispose();
        }

        public static async Task SetFabricLoaderVersionList()
        {
            HttpClient client = new HttpClient();
            HttpResponseMessage response = await client.GetAsync("https://meta.fabricmc.net/v2/versions/loader");
            response.EnsureSuccessStatusCode();
            FabricLoaderVersionsListDeserialized = JsonConvert.DeserializeObject<List<fabricMcVersion>>(await response.Content.ReadAsStringAsync());

            foreach (var version in FabricLoaderVersionsListDeserialized.ToList())
            {
                if (version != null && version.stable)
                {
                    FabricLoaderVersionsList.Add(version.version + " (Stable)");
                    if (variables.InstallFabricVariables.IndexStableLoaderVersion == -1) {
                        variables.InstallFabricVariables.IndexStableLoaderVersion = FabricLoaderVersionsList.Count - 1;
                        variables.InstallFabricVariables.SelectedIndexLoaderVersion = FabricLoaderVersionsList.Count - 1;
                        variables.InstallFabricVariables.SelectedLoaderVersion = version.version;
                    }
                } else
                {
                    FabricLoaderVersionsList.Add(version.version);
                }
            }

            client.Dispose();
        }

        public static async void InitVersions()
        {
            await SetFabricMcVersionList();
            await SetFabricLoaderVersionList();
        }








        // Root myDeserializedClass = JsonConvert.DeserializeObject<List<Root>>(myJsonResponse);
        public class Arguments
        {
            public List<object> client { get; set; }
            public List<object> common { get; set; }
            public List<object> server { get; set; }
        }

        public class Common
        {
            public string name { get; set; }
            public string url { get; set; }
        }

        public class Intermediary
        {
            public string maven { get; set; }
            public string version { get; set; }
            public bool stable { get; set; }
        }

        public class LauncherMeta
        {
            public int version { get; set; }
            public Libraries libraries { get; set; }
            public object mainClass { get; set; }
            public Arguments arguments { get; set; }
            public Launchwrapper launchwrapper { get; set; }
        }

        public class Launchwrapper
        {
            public Tweakers tweakers { get; set; }
        }

        public class Libraries
        {
            public List<object> client { get; set; }
            public List<Common> common { get; set; }
            public List<Server> server { get; set; }
        }

        public class Loader
        {
            public string separator { get; set; }
            public int build { get; set; }
            public string maven { get; set; }
            public string version { get; set; }
            public bool stable { get; set; }
        }

        public class GameVersionLoaderVersion
        {
            public Loader loader { get; set; }
            public Intermediary intermediary { get; set; }
            public LauncherMeta launcherMeta { get; set; }
        }

        public class Server
        {
            public string _comment { get; set; }
            public string name { get; set; }
            public string url { get; set; }
        }

        public class Tweakers
        {
            public List<string> client { get; set; }
            public List<object> common { get; set; }
            public List<string> server { get; set; }
        }

        public static async Task<List<GameVersionLoaderVersion>> GetGameVersionLoaderVersions(string Version)
        {
            HttpClient client = new HttpClient();
            HttpResponseMessage response = await client.GetAsync("https://meta.fabricmc.net/v2/versions/loader/" + Version);
            response.EnsureSuccessStatusCode();
            var GameVersionLoaderVersionsDeserialized = JsonConvert.DeserializeObject<List<GameVersionLoaderVersion>>(await response.Content.ReadAsStringAsync());
            client.Dispose();
            return GameVersionLoaderVersionsDeserialized;
        }
    }
}
