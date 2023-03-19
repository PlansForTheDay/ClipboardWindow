using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Windows.ApplicationModel.DataTransfer;
using Windows.Foundation;
using Windows.Storage.Streams;
using Windows.UI.Xaml.Media.Imaging;
using BitmapImage = System.Windows.Media.Imaging.BitmapImage;
using Cb = Windows.ApplicationModel.DataTransfer.Clipboard;
using Clipboard = System.Windows.Clipboard;
using IDataObject = System.Windows.IDataObject;
using drawingImage =  System.Drawing.Image;
using System.Runtime.InteropServices;
//using Windows.UI.Xaml.Controls;
using System.IO;
using static ClipboardWindow.Windows.ComObjectConverter;
using BitmapSource = System.Windows.Media.Imaging.BitmapSource;
using stdole;
using System.Runtime.InteropServices.WindowsRuntime;
//using System.Windows.Forms;

namespace ClipboardWindow.Windows
{
    /// <summary>
    /// Логика взаимодействия для Clipdoard.xaml
    /// </summary>
    public partial class WindowClipboard : Window
    {
        async Task<string> GetTxt(ClipboardHistoryItem item)
        {
            return SeizureOfData.DecodeText(await item.Content.GetTextAsync());
        }

        //public static BitmapImage ToWpfImage(drawingImage image)
        //{
        //    using (var memoryStream = new MemoryStream()) 
        //    { 
        //        image.Save(memoryStream, System.Drawing.Imaging.ImageFormat.Bmp);

        //        BitmapImage bitmapImage = new BitmapImage()
        //        {
        //            CacheOption = BitmapCacheOption.OnLoad,
        //            StreamSource = memoryStream
        //        };

        //        //bitmapImage.BeginInit();
        //        //bitmapImage.CacheOption = BitmapCacheOption.OnLoad;
        //        //bitmapImage.StreamSource = memoryStream;
        //        //bitmapImage.EndInit();

        //        return bitmapImage;
        //    }
        //}



        [STAThread]
        public async Task<BitmapImage> GetImageFromHistoryItem(ClipboardHistoryItem item)
        {
            DataPackageView dataPackage = item.Content;

            //BitmapImage image;
            //System.IO.Stream stream = null;
            //drawingImage image1 = null;
            IRandomAccessStreamReference imageReceived;
            try
            {
                imageReceived = await dataPackage.GetBitmapAsync();
            }
            catch
            { return null; }

            if (imageReceived != null)
            {
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

                    //image1 = new System.Drawing.Bitmap(imageStream.AsStreamForRead());


                    //stream = imageStream.AsStreamForRead();
                    //BitmapImage image = new BitmapImage() { StreamSource = imageStream.AsStreamForRead() };

                    //return image1;
                }

            }


                //IPictureDisp pictureDisp = (IPictureDisp)item.Content.GetBitmapAsync();
                //stdole.IPicture iPictureDisp = (stdole.IPicture)IconTools.GetImage(pictureDisp);

                //dynamic pictureDisp2 = (IPicture)pictureDisp;

                //Image image = IconTools.GetImageFromIPicture(pictureDisp);

            return null;
        }

        public async void ShowingCbItems()
        {
            ClipboardItemsArea.Children.Clear();

            var items = Cb.GetHistoryItemsAsync();

            //await Task.Run(() =>
            //{
            if (items.GetResults().Items != null) 
            {
                IDataObject data = Clipboard.GetDataObject();

                foreach (var item in items.GetResults().Items)
                {
                    if (item.Content.Contains(DataFormats.Bitmap) | item.Content.Contains(DataFormats.Text))
                    {
                        if (item.Content.Contains(DataFormats.Text))
                        {
                            //string text = await Task.Run( /*async*/ () => );

                            string text = await GetTxt(item);

                            var cbItem = new Button()
                            {
                                Name = "clipboardText",
                                Template = (ControlTemplate)Application.Current.Resources["clipboardItem"],
                                Content = new TextBlock
                                {
                                    Style = (Style)Application.Current.Resources["cbTextObject"],
                                    Text = text
                                },
                            };
                            cbItem.Click += new RoutedEventHandler(cbItem_Click);

                            ClipboardItemsArea.Children.Add(cbItem);
                        }
                        else if (item.Content.Contains(DataFormats.Bitmap))
                        {
                            #region testing area
                            //IPictureDisp comInIPicture = (IPictureDisp)item.Content.GetBitmapAsync();

                            //var comObj = item.Content.GetBitmapAsync().GetResults();

                            //stdole.IPicture iPictureDisp = (stdole.IPicture)IconTools.GetIPictureDispFromImage(image);

                            //MemoryStream ms = new MemoryStream(comInIPicture);

                            //Image image1 = (Image)dataObject.GetData(DataFormats.Bitmap);

                            //BitmapSource bitmap = (BitmapSource)item.Content.GetBitmapAsync();
                            //Image image = new Image();
                            //image.Source = bitmap;
                            #endregion

                            var asyncBitmapImage = await GetImageFromHistoryItem(item);

                            //BitmapImage image = ToWpfImage(asyncBitmapImage);

                            var cbItem = new Button()
                            {
                                Name = "clipboardImage",
                                Template = (ControlTemplate)Application.Current.Resources["clipboardItem"],
                                Content = new Image { Source = asyncBitmapImage, MaxWidth = 97, MaxHeight = 80 },
                                //Content = "Тут должна быть картинка, но её не будет(",
                            };
                            cbItem.Click += new RoutedEventHandler(cbItem_Click);

                            ClipboardItemsArea.Children.Add(cbItem);
                        }
                    }
                }   
            }

            //    return Task.CompletedTask;
            //});
        }

        private void cbItem_Click(object sender, RoutedEventArgs e)
        {
            Button targetButton = e.Source as Button;

            if (targetButton.Name == "clipboardText")
            {
                var textblock = targetButton.Content as TextBlock;

                SeizureOfData.LoadTextWindow(textblock.Text.ToString());
            }
            else if (targetButton.Name == "clipboardImage")
            {
                Image image = (Image)targetButton.Content;

                SeizureOfData.LoadImageWindow((System.Windows.Media.Imaging.BitmapSource)image.Source); // image = null
            }
        }


        public WindowClipboard()
        {
            InitializeComponent();

            ShowingCbItems();
        }

        private void controlButtonPanel_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }

        private void closeButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void collapseButton_Click(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }

        private void mainMenuButton_Click(object sender, RoutedEventArgs e)
        {
            Owner.Show();

            Close();
        }

        private void reloadButton_Click(object sender, RoutedEventArgs e)
        {
            ShowingCbItems();
        }

        private void lastObjButton_Click(object sender, RoutedEventArgs e)
        {
            IDataObject clipboardList = Clipboard.GetDataObject();

            SeizureOfData.LoadObjectWindow(clipboardList);
        }
    }
}