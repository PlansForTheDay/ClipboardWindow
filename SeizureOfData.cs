using ClipboardWindow.Windows;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Interop;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using Windows.Graphics.Imaging;
//using Clipboard = Windows.ApplicationModel.DataTransfer.Clipboard;

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


        public static void LoadTextWindow(string text)
        {
            ObjectFromBuffer objectFromBuffer = new ObjectFromBuffer();

            objectFromBuffer.MaxHeight = SystemParameters.FullPrimaryScreenHeight;
            objectFromBuffer.MaxWidth = SystemParameters.FullPrimaryScreenWidth;

            var cbItem = new TextBox()
            {
                Style = (Style)Application.Current.Resources["windowTextFromCb"],
                Text = text,
            };

            objectFromBuffer.ContentAera.Children.Add(cbItem);
            objectFromBuffer.Icon = (ImageSource)Application.Current.Resources["Text"];
            objectFromBuffer.SizeToContent = SizeToContent.WidthAndHeight;

            objectFromBuffer.Show();

            objectFromBuffer.MaxHeight = objectFromBuffer.Height + 20;
            objectFromBuffer.MaxWidth = objectFromBuffer.Width + 20;
        }

        public static void LoadImageWindow(BitmapSource bitmap)
        {
            ObjectFromBuffer objectFromBuffer = new ObjectFromBuffer();

            objectFromBuffer.MaxHeight = SystemParameters.FullPrimaryScreenHeight;
            objectFromBuffer.MaxWidth = SystemParameters.FullPrimaryScreenWidth;

            var cbItem = new Image()
            {
                Style = (Style)Application.Current.Resources["windowImageFromCb"],
                Source = (BitmapSource)bitmap,
                //Width = bitmap.Width,
                //Height = bitmap.Height,
            };

            objectFromBuffer.ContentAera.Children.Add(cbItem);
            objectFromBuffer.Icon = (ImageSource)Application.Current.Resources["Image"];

            objectFromBuffer.Height = bitmap.Height + 55;
            objectFromBuffer.Width = bitmap.Width + 20;

            objectFromBuffer.MaxHeight = SystemParameters.FullPrimaryScreenHeight;
            objectFromBuffer.MaxWidth = SystemParameters.FullPrimaryScreenWidth;

            objectFromBuffer.Show();
        }

        public static void LoadObjectWindow(IDataObject dataObject)
        {
            //ObjectFromBuffer objectFromBuffer = new ObjectFromBuffer();

            //objectFromBuffer.MaxHeight = SystemParameters.FullPrimaryScreenHeight;
            //objectFromBuffer.MaxWidth = SystemParameters.FullPrimaryScreenWidth;

            if (dataObject.GetDataPresent(DataFormats.Text))
            {
                LoadTextWindow(DecodeText(dataObject.GetData(DataFormats.Text).ToString().Trim()));

                //var cbItem = new TextBox()
                //{
                //    Style = (Style)Application.Current.Resources["windowTextFromCb"],
                //    Text = DecodeText(dataObject.GetData(DataFormats.Text).ToString().Trim()),
                //};

                //objectFromBuffer.ContentAera.Children.Add(cbItem);
                //objectFromBuffer.Icon = (ImageSource)Application.Current.Resources["Text"];
            }
            else if (dataObject.GetDataPresent(DataFormats.Bitmap))
            {
                LoadImageWindow((BitmapSource)dataObject.GetData(DataFormats.Bitmap));

                //var cbItem = new Image()
                //{
                //    Style = (Style)Application.Current.Resources["windowImageFromCb"],
                //    Source = (BitmapSource)dataObject.GetData(DataFormats.Bitmap),
                //    Width = ((InteropBitmap)dataObject.GetData(DataFormats.Bitmap)).Width,
                //    Height = ((InteropBitmap)dataObject.GetData(DataFormats.Bitmap)).Height,
                //};

                //objectFromBuffer.ContentAera.Children.Add(cbItem);
                //objectFromBuffer.Icon = (ImageSource)Application.Current.Resources["Image"];
            }
            //objectFromBuffer.Show();

            //objectFromBuffer.MaxHeight = objectFromBuffer.Height + 20;
            //objectFromBuffer.MaxWidth = objectFromBuffer.Width + 20;
        }
    }
}
