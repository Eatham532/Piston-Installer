

using System.Globalization;
using System.Net;
using System.Runtime.InteropServices;
using System.Security.Cryptography;

namespace Piston_Installer.utils
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
            Image a = new Bitmap(path);

            using (MemoryStream ms = new MemoryStream())
            {
                a.Save(ms, a.RawFormat);
                byte[] imageBytes = ms.ToArray();

                string dataString = "data:image/png;base64," + Convert.ToBase64String(imageBytes);

                return dataString;
            }
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
                System.Windows.Forms.MessageBox.Show(ex.Message, "Error!", MessageBoxButtons.OK, 
                    MessageBoxIcon.Error,
                    MessageBoxDefaultButton.Button1);
            }

            return (strResult);
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
