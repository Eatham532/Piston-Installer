using System.Globalization;
using System.Net;
using System.Runtime.InteropServices;
using System.Security.Cryptography;

namespace PistonInstaller.net.Eatham532.utils
{
    internal class InternetUtils
    {
        public static bool CheckForInternetConnection(int timeoutMs = 10000, string url = null)
        {
            try
            {
                url ??= CultureInfo.InstalledUICulture switch
                {
                    { Name: var n } when n.StartsWith("fa") => // Iran
                        "http://www.aparat.com",
                    { Name: var n } when n.StartsWith("zh") => // China
                        "http://www.baidu.com",
                    _ =>
                        "http://www.gstatic.com/generate_204",
                };
                
                var request = (HttpWebRequest)WebRequest.Create(url);
                request.KeepAlive = false;
                request.Timeout = timeoutMs;
                using (var response = (HttpWebResponse) request.GetResponse())
                return true;
            }
            catch
            {
                return false;
            }
        }

        public static string ConvertImageToDataUri(string path)
        {
            return "data:image/"
             + Path.GetExtension(path).Replace(".", "")
             + ";base64,"
             + Convert.ToBase64String(File.ReadAllBytes(path));
        }



        // convert byte array from file to hex values
        public static string FileToSha1Hash(string pathName)
        {
            string strResult = "";
            string strHashData = "";

            byte[] arrbytHashValue;
            FileStream oFileStream = null;

            SHA1CryptoServiceProvider oSHA1Hasher = new SHA1CryptoServiceProvider();

            try
            {
                oFileStream = new FileStream(pathName, FileMode.Open);
                arrbytHashValue = oSHA1Hasher.ComputeHash(oFileStream);
                oFileStream.Close();

                strHashData = System.BitConverter.ToString(arrbytHashValue);
                strHashData = strHashData.Replace("-", "");
                strResult = strHashData;
            }
            catch (System.Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Error in FileToSha1Hash");
            }

            return (strResult);
        }


        public static async Task<FileResult> FilePickerPng()
        {
            var customFileType = new FilePickerFileType(
                new Dictionary<DevicePlatform, IEnumerable<string>>
                {
                    //May be buggy

                    { DevicePlatform.iOS, new[] { ".png" } }, // or general UTType values
                    { DevicePlatform.Android, new[] { "image/png" } },
                    { DevicePlatform.WinUI, new[] { ".png" } },
                    { DevicePlatform.Tizen, new[] { ".png" } },
                    { DevicePlatform.macOS, new[] { ".png" } }, // or general UTType values
                });

            PickOptions options = new()
            {
                PickerTitle = "Please select a png file",
                FileTypes = customFileType,
            };

            try
            {
                var result = await FilePicker.Default.PickAsync(options);
                if (result != null)
                {
                    if (result.FileName.EndsWith("jpg", StringComparison.OrdinalIgnoreCase) ||
                        result.FileName.EndsWith("png", StringComparison.OrdinalIgnoreCase))
                    {
                        using var stream = await result.OpenReadAsync();
                        var image = ImageSource.FromStream(() => stream);
                    }
                }

                return result;
            }
            catch (Exception ex)
            {
                // The user canceled or something went wrong
            }

            return null;
        }
    }

    internal class DetectOperatingSystem
    {
        public static bool IsWindows() =>
        RuntimeInformation.IsOSPlatform(OSPlatform.Windows);

        public static bool IsMacOS() =>
            RuntimeInformation.IsOSPlatform(OSPlatform.OSX);

        public static bool IsLinux() =>
            RuntimeInformation.IsOSPlatform(OSPlatform.Linux);
    }

}
