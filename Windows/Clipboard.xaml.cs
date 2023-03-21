using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using Cb = Windows.ApplicationModel.DataTransfer.Clipboard;
//using Windows.UI.Xaml.Controls;
//using static ClipboardWindow.Windows.ComObjectConverter;

namespace ClipboardWindow.Windows
{
    /// <summary>
    /// Логика взаимодействия для Clipdoard.xaml
    /// </summary>
    public partial class WindowClipboard : Window
    {
        //async Task<string> GetTxt(ClipboardHistoryItem item)
        //{
        //    return SeizureOfData.DecodeText(await item.Content.GetTextAsync());
        //}

        //[STAThread]
        //public async Task<BitmapImage> GetImageFromHistoryItem(ClipboardHistoryItem item)
        //{
        //    DataPackageView dataPackage = item.Content;

        //    IRandomAccessStreamReference imageReceived;
        //    try
        //    {
        //        imageReceived = await dataPackage.GetBitmapAsync();
        //    }
        //    catch
        //    { return null; }

        //    if (imageReceived == null)
        //    { return null; }

        //    using (var imageStream = await imageReceived.OpenReadAsync())
        //    {
        //        byte[] buffer = new byte[imageStream.Size];
        //        await imageStream.ReadAsync(buffer.AsBuffer(), (uint)imageStream.Size, InputStreamOptions.None);

        //        using (var ms = new System.IO.MemoryStream(buffer))
        //        {
        //            var image = new BitmapImage();
        //            image.BeginInit();
        //            image.CacheOption = BitmapCacheOption.OnLoad;
        //            image.StreamSource = ms;
        //            image.EndInit();
        //            return image;
        //        }
        //    }
        //}

        //public async void LoadAllObjects()
        //{
        //    ClipboardItemsArea.Children.Clear();

        //    var items = Cb.GetHistoryItemsAsync();

        //    if (items.GetResults().Items.Any() == false) 
        //    {
        //        var message = new TextBlock()
        //        {
        //            Style = (Style)Application.Current.Resources["NonObject"]
        //        };

        //        ClipboardItemsArea.Children.Add(message);
        //        return;
        //    }

        //    foreach (var item in items.GetResults().Items)
        //    {
        //        var cbItem = new Button
        //        {
        //            Template = (ControlTemplate)Application.Current.Resources["clipboardItem"]
        //        };

        //        if (item.Content.Contains(DataFormats.Text))
        //        {
        //            string text = await GetTxt(item);

        //            cbItem.Name = "clipboardText";
        //            cbItem.Content = new TextBlock
        //            {
        //                Style = (Style)Application.Current.Resources["cbTextObject"],
        //                Text = text
        //            };

        //            cbItem.Click += new RoutedEventHandler(cbItem_Click);
        //        }
        //        else if (item.Content.Contains(DataFormats.Bitmap))
        //        {
        //            var asyncBitmapImage = await GetImageFromHistoryItem(item);

        //            cbItem.Name = "clipboardImage";
        //            cbItem.Content = new Image { Source = asyncBitmapImage, MaxWidth = 97, MaxHeight = 80 };
        //            cbItem.Click += new RoutedEventHandler(cbItem_Click);
        //        }
        //        else
        //        {
        //            cbItem.Name = "clipboardRaw";
        //            cbItem.Content = new TextBox
        //            {
        //                Name = "rawObject",
        //                Text = "Необрабатываемый объект",
        //                TextAlignment = TextAlignment.Center,
        //                FontSize = 11,
        //                TextWrapping = TextWrapping.Wrap,
        //                Width = 110,
        //                Height = 30,
        //                Foreground = (Brush)Application.Current.Resources["TopText"]
        //            };
        //        }
        //        ClipboardItemsArea.Children.Add(cbItem);
        //    }   
        //}

        private static void cbItem_Click(object sender, RoutedEventArgs e)
        {
            Button targetButton = e.Source as Button;

            if (targetButton.Name == "clipboardText")
            {
                var textblock = targetButton.Content as TextBlock;

                LoadingElements.ShowTextObj(textblock.Text.ToString());
            }
            else if (targetButton.Name == "clipboardImage")
            {
                Image image = (Image)targetButton.Content;

                LoadingElements.ShowImageObj((System.Windows.Media.Imaging.BitmapSource)image.Source);
            }
        }
        public static void ClickThis(Button button)
        {
            button.Click += new RoutedEventHandler(cbItem_Click);
        }

        public WindowClipboard()
        {
            InitializeComponent();

            LoadingElements.LoadAllObjects(this);
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
            LoadingElements.LoadAllObjects(this);
        }

        private void lastObjButton_Click(object sender, RoutedEventArgs e)
        {
            LoadingElements.ShowLastObj();
        }

        private void clearButton_Click(object sender, RoutedEventArgs e)
        {
            Cb.Clear();
            LoadingElements.LoadAllObjects(this);
        }
    }
}