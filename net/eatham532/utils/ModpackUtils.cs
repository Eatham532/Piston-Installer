namespace Piston_Installer.utils
{
    public class ModpackUtils
    {
        // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);
        public class File
        {
            public int projectID { get; set; }
            public int fileID { get; set; }
            public bool required { get; set; }
        }

        public class Minecraft
        {
            public string version { get; set; }
            public List<ModLoader> modLoaders { get; set; }
        }

        public class ModLoader
        {
            public string id { get; set; }
            public bool primary { get; set; }
        }

        public class Root
        {
            public Minecraft minecraft { get; set; }
            public string manifestType { get; set; }
            public string overrides { get; set; }
            public int manifestVersion { get; set; }
            public string version { get; set; }
            public string author { get; set; }
            public string name { get; set; }
            public List<File> files { get; set; }
        }


    }
}
