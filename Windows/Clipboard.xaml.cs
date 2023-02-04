using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
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

namespace ClipboardWindow.Windows
{
    /// <summary>
    /// Логика взаимодействия для Clipdoard.xaml
    /// </summary>
    public partial class WindowClipboard : Window
    {
        async Task<string> GetTxt(ClipboardHistoryItem item)
        {
            string text = SeizureOfData.DecodeText(item.Content.GetTextAsync().GetResults().ToString());

            return text;
        }


        public async void ShowingCbItems()
        {
            ClipboardItemsArea.Children.Clear();

            var items = Cb.GetHistoryItemsAsync();

            //await Task.Run(() =>
            //{
            if (items != null)
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
                            var cbItem = new Button()
                            {
                                Name = "clipboardImage",
                                Template = (ControlTemplate)Application.Current.Resources["clipboardItem"],
                                //Content = new Image { Source = ((Image)item.Content.GetBitmapAsync()).Source, MaxWidth = 97, MaxHeight = 80 },
                                Content = "Тут должна быть картинка, но её не будет(",
                            };

                            ClipboardItemsArea.Children.Add(cbItem);
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
                //var image = targetButton.Content as Image;

                //SeizureOfData.LoadImageWindow((System.Windows.Media.Imaging.BitmapSource)image.Source);
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