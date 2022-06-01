using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Piston_Installer.utils
{
    public class ModrinthUtils
    {
        public static ModrinthSearchResult ModrinthSearchDeserialized = new ModrinthSearchResult();
        public static ModrinthProject ModrinthProjectDeserialized = new ModrinthProject();
        public static ModrinthVersion ModrinthVersionDeserialized = new ModrinthVersion();

        public static string responseBody;
        public static bool isDownloading = false;

        public static async Task ModrinthSearch(string query, string index, int offset, int limit)
        {
            string URL = "https://api.modrinth.com/v2/search?query=" + query + "&index=" + index + "&offset=" + offset.ToString() + "&limit=" + limit.ToString();
            HttpClient client = new HttpClient();
            HttpResponseMessage response = await client.GetAsync(URL);
            response.EnsureSuccessStatusCode();
            responseBody = await response.Content.ReadAsStringAsync();
            ModrinthSearchDeserialized = JsonConvert.DeserializeObject<ModrinthSearchResult>(responseBody);
            client.Dispose();
        }
        public static async Task ModrinthSearch(string query, string facets, string index, int offset, int limit)
        {
            string URL = "https://api.modrinth.com/v2/search?query=" + query + "&facets=[" + facets + "]&index=" + index + "&offset=" + offset.ToString() + "&limit=" + limit.ToString();
            HttpClient client = new HttpClient();
            HttpResponseMessage response = await client.GetAsync(URL);
            response.EnsureSuccessStatusCode();
            responseBody = await response.Content.ReadAsStringAsync();
            ModrinthSearchDeserialized = JsonConvert.DeserializeObject<ModrinthSearchResult>(responseBody);
            client.Dispose();
        }
        public static async Task ModrinthSearch(string facets, string index, int limit)
        {
            string URL = "https://api.modrinth.com/v2/search?facets=[" + facets + "]&index=" + index + "&limit=" + limit.ToString();
            HttpClient client = new HttpClient();
            HttpResponseMessage response = await client.GetAsync(URL);
            response.EnsureSuccessStatusCode();
            responseBody = await response.Content.ReadAsStringAsync();
            ModrinthSearchDeserialized = JsonConvert.DeserializeObject<ModrinthSearchResult>(responseBody);
            client.Dispose();
        }





        public static async void DownloadFabricAPI(string DownloadLocation, string version)
        {
            isDownloading = true;
            await ModrinthSearch("fabric-api", "[\"categories:fabric\"],[\"versions:" + version + "\"]", "relevance", 0, 1);

            string URL = "https://api.modrinth.com/v2/project/" + ModrinthSearchDeserialized.hits[0].project_id;
            HttpClient client = new HttpClient();
            HttpResponseMessage response = await client.GetAsync(URL);
            response.EnsureSuccessStatusCode();
            responseBody = await response.Content.ReadAsStringAsync();
            ModrinthProjectDeserialized = JsonConvert.DeserializeObject<ModrinthProject>(responseBody);

            string DownloadLink = null;
            for (int i = 0; i < ModrinthProjectDeserialized.versions.Count; i++)
            {
                await GetProjectVersion(ModrinthProjectDeserialized.versions[i]);

                if (ModrinthVersionDeserialized.game_versions[0] == version)
                {
                    DownloadLink = ModrinthVersionDeserialized.files[0].url;
                    break;
                }
            }
            System.Diagnostics.Debug.WriteLine(DownloadLink);

            if (DownloadLink != null)
            {
                DownloadFile(DownloadLink, DownloadLocation);
            }
        }

        public static async Task<ModrinthVersion> GetProjectVersion(string VersionId)
        {
            string URL = "https://api.modrinth.com/v2/version/" + VersionId;
            HttpClient client = new HttpClient();
            HttpResponseMessage response = await client.GetAsync(URL);
            response.EnsureSuccessStatusCode();
            responseBody = await response.Content.ReadAsStringAsync();
            ModrinthVersionDeserialized = JsonConvert.DeserializeObject<ModrinthVersion>(responseBody);
            return ModrinthVersionDeserialized;
        }

        public static async Task<ModrinthProject> GetProject(string projectId)
        {
            string URL = "https://api.modrinth.com/v2/project/" + projectId;
            HttpClient client = new HttpClient();
            HttpResponseMessage response = await client.GetAsync(URL);
            response.EnsureSuccessStatusCode();
            responseBody = await response.Content.ReadAsStringAsync();
            ModrinthProjectDeserialized = JsonConvert.DeserializeObject<ModrinthProject>(responseBody);
            return ModrinthProjectDeserialized;
        }



















        // Root myDeserializedClass = JsonConvert.DeserializeObject<GalleryImage>(myJsonResponse);
        public class GalleryImage
        {
            public string url { get; set; }
            public bool featured { get; set; }
            public string title { get; set; }
            public string description { get; set; }
            public DateTime created { get; set; }
        }





        // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);
        public class Dependency
        {
            public string version_id { get; set; }
            public string project_id { get; set; }
            public string dependency_type { get; set; }
        }

        public class FileHash
        {
            public Hashes hashes { get; set; }
            public string url { get; set; }
            public string filename { get; set; }
            public bool primary { get; set; }
            public int size { get; set; }
        }

        public class HashSearch
        {
            public string name { get; set; }
            public string version_number { get; set; }
            public string changelog { get; set; }
            public List<Dependency> dependencies { get; set; }
            public List<string> game_versions { get; set; }
            public string version_type { get; set; }
            public List<string> loaders { get; set; }
            public bool featured { get; set; }
            public string id { get; set; }
            public string project_id { get; set; }
            public string author_id { get; set; }
            public DateTime date_published { get; set; }
            public int downloads { get; set; }
            public object changelog_url { get; set; }
            public List<FileHash> files { get; set; }
        }







        // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);

        public class File
        {
            public Hashes hashes { get; set; }
            public string url { get; set; }
            public string filename { get; set; }
            public bool primary { get; set; }
            public int size { get; set; }
        }

        public class Hashes
        {
            public string sha512 { get; set; }
            public string sha1 { get; set; }
        }

        public class ModrinthVersion
        {
            public string name { get; set; }
            public string version_number { get; set; }
            public string changelog { get; set; }
            public List<Dependency> dependencies { get; set; }
            public List<string> game_versions { get; set; }
            public string version_type { get; set; }
            public List<string> loaders { get; set; }
            public bool featured { get; set; }
            public string id { get; set; }
            public string project_id { get; set; }
            public string author_id { get; set; }
            public DateTime date_published { get; set; }
            public int downloads { get; set; }
            public object changelog_url { get; set; }
            public List<File> files { get; set; }
        }





        // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);
        public class DonationUrl
        {
            public string id { get; set; }
            public string platform { get; set; }
            public string url { get; set; }
        }

        public class Gallery
        {
            public string url { get; set; }
            public bool featured { get; set; }
            public string title { get; set; }
            public string description { get; set; }
            public DateTime created { get; set; }
        }

        public class License
        {
            public string id { get; set; }
            public string name { get; set; }
            public string url { get; set; }
        }

        public class ModrinthProject
        {
            public string slug { get; set; }
            public string title { get; set; }
            public string description { get; set; }
            public List<string> categories { get; set; }
            public string client_side { get; set; }
            public string server_side { get; set; }
            public string body { get; set; }
            public string issues_url { get; set; }
            public string source_url { get; set; }
            public string wiki_url { get; set; }
            public string discord_url { get; set; }
            public List<DonationUrl> donation_urls { get; set; }
            public string project_type { get; set; }
            public int downloads { get; set; }
            public string icon_url { get; set; }
            public string id { get; set; }
            public string team { get; set; }
            public object body_url { get; set; }
            public object moderator_message { get; set; }
            public DateTime published { get; set; }
            public DateTime updated { get; set; }
            public int followers { get; set; }
            public string status { get; set; }
            public License license { get; set; }
            public List<string> versions { get; set; }
            public List<Gallery> gallery { get; set; }
        }


    




        // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);
        public class Hit
        {
            public string project_id { get; set; }
            public string project_type { get; set; }
            public string slug { get; set; }
            public string author { get; set; }
            public string title { get; set; }
            public string description { get; set; }
            public List<string> categories { get; set; }
            public List<string> versions { get; set; }
            public int downloads { get; set; }
            public int follows { get; set; }
            public string icon_url { get; set; }
            public DateTime date_created { get; set; }
            public DateTime date_modified { get; set; }
            public string latest_version { get; set; }
            public string license { get; set; }
            public string client_side { get; set; }
            public string server_side { get; set; }
            public List<string> gallery { get; set; }
        }

        public class ModrinthSearchResult
        {
            public List<Hit> hits { get; set; }
            public int offset { get; set; }
            public int limit { get; set; }
            public int total_hits { get; set; }
        }












        //Download File Area
        //DONT TOUCH :)

        private static void DownloadFile(string URL, string DownloadLocation)
        {
            try
            {
                string desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
                Uri uri = new Uri(URL);
                string filename = Path.GetFileName(uri.LocalPath);

                using (WebClient wc = new WebClient())
                {
                    string path = Path.Combine(DownloadLocation, filename);
                    wc.DownloadProgressChanged += wc_DownloadProgressChanged;
                    wc.DownloadFileCompleted += wc_DownloadFileCompleted;
                    wc.DownloadFileAsync(uri, path);
                }
            }
            catch
            {
                System.Diagnostics.Debug.WriteLine("Make sure the download link is correct");
            }
        }

        private static void wc_DownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {
            System.Diagnostics.Debug.WriteLine(e.ProgressPercentage + "%");
        }

        private static void wc_DownloadFileCompleted(object sender, AsyncCompletedEventArgs e)
        {
            if (e.Cancelled)
            {
                System.Diagnostics.Debug.WriteLine("The download has been cancelled");
                isDownloading = false;
                return;
            }

            if (e.Error != null) // We have an error! Retry a few times, then abort.
            {
                System.Diagnostics.Debug.WriteLine("An error ocurred while trying to download file");
                isDownloading = false;
                return;
            }
            System.Diagnostics.Debug.WriteLine("File succesfully downloaded");
            isDownloading = false;
        }
    }
}
