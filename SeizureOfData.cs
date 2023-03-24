using System.Runtime.InteropServices.WindowsRuntime;
using System;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;
using Windows.ApplicationModel.DataTransfer;
using Windows.Storage.Streams;
using UnicodeEncoding = System.Text.UnicodeEncoding;

namespace ClipboardWindow
{
    internal class SeizureOfData
    {
        public static string DecodeText(string sourceText)
        {
            UnicodeEncoding unicode = new UnicodeEncoding();

            byte[] bytes = unicode.GetBytes(sourceText);

            string finalText = unicode.GetString(bytes);
            return finalText;
        }

        public async static Task<string> GetTxt(ClipboardHistoryItem item)
        {
            return DecodeText(await item.Content.GetTextAsync());
        }

        [STAThread]
        public static async Task<BitmapImage> GetImageFromHistoryItem(ClipboardHistoryItem item)
        {
            DataPackageView dataPackage = item.Content;

            IRandomAccessStreamReference imageReceived;
            try
            {
                imageReceived = await dataPackage.GetBitmapAsync();
            }
            catch
            { return null; }

            if (imageReceived == null)
            { return null; }

            using (var imageStream = await imageReceived.OpenReadAsync())
            {
                byte[] buffer = new byte[imageStream.Size];
                await imageStream.ReadAsync(buffer.AsBuffer(), (uint)imageStream.Size, InputStreamOptions.None);

                using (var ms = new System.IO.MemoryStream(buffer))
                {
                    var image = new BitmapImage();
                    image.BeginInit();
                    image.CacheOption = BitmapCacheOption.OnLoad;
                    image.StreamSource = ms;
                    image.EndInit();
                    return image;
                }
            }
        }
    }
}
