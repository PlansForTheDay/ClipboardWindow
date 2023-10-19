using ClipboardWindow.Windows;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using Windows.ApplicationModel.DataTransfer;
using Clipboard = Windows.ApplicationModel.DataTransfer.Clipboard;

namespace ClipboardWindow
{
    internal class ShowWindows
    {
        public static void ShowClipboardWindows(Window owner)
        {
            WindowClipboard clipboardWindow = new WindowClipboard { Owner = owner };
            clipboardWindow.Show();
        }

        public static void ShowSettingsWindows(Window owner)
        {
            Settings settings = new Settings { Owner = owner };
            settings.Show();
        }

        public static void ShowInfoWindow(Window owner)
        {
            WindowInformation informationWindow = new WindowInformation { Owner = owner };
            informationWindow.Show();
        }

        public static async void ShowLastObj()
        {
            var clipboardList = Clipboard.GetHistoryItemsAsync().GetResults().Items;
            if (!clipboardList.Any())
            { return; }

            var lastObject = clipboardList.First();

            if (lastObject.Content.Contains(DataFormats.Text))
            {
                string text = await SeizureOfData.GetTxt(lastObject);
                ShowTextObj(text);
            }
            else if (lastObject.Content.Contains(DataFormats.Bitmap))
            {
                var image = await SeizureOfData.GetImageFromHistoryItem(lastObject);
                ShowImageObj(image);
            }
        }
        public static void ShowTextObj(string text)
        {
            ObjectFromBuffer window = new ObjectFromBuffer
            {
                MaxHeight = SystemParameters.FullPrimaryScreenHeight,
                MaxWidth = SystemParameters.FullPrimaryScreenWidth
            };
            var textBox = new TextBox()
            {
                Style = (Style)Application.Current.Resources["windowTextFromCb"],
                Text = text,
            };

            window.ContentAera.Children.Add(textBox);
            window.Icon = (ImageSource)Application.Current.Resources["Text"];
            window.SizeToContent = SizeToContent.WidthAndHeight;
            window.Show();
        }

        public static void ShowImageObj(BitmapSource bitmap)
        {
            ObjectFromBuffer window = new ObjectFromBuffer
            {
                MaxHeight = SystemParameters.FullPrimaryScreenHeight,
                MaxWidth = SystemParameters.FullPrimaryScreenWidth
            };
            var image = new Image()
            {
                Style = (Style)Application.Current.Resources["windowImageFromCb"],
                Source = bitmap,
                RenderTransform = new ScaleTransform(),
            };
            ObjectFromBuffer.ChangeZoom(image);

            window.ContentAera.Children.Add(image);
            window.Icon = (ImageSource)Application.Current.Resources["Image"];
            window.Height = bitmap.Height + 55;
            window.Width = bitmap.Width + 20;
            window.MaxHeight = SystemParameters.FullPrimaryScreenHeight;
            window.MaxWidth = SystemParameters.FullPrimaryScreenWidth;
            window.Show();
        }
    }
}
