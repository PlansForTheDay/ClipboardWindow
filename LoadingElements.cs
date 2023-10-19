using ClipboardWindow.Windows;
using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using BitmapSource = System.Windows.Media.Imaging.BitmapSource;
using System.Windows.Media;
using Clipboard = Windows.ApplicationModel.DataTransfer.Clipboard;
using ClipboardWindow.Models;
using System.Threading.Tasks;
using Windows.ApplicationModel.DataTransfer;

namespace ClipboardWindow
{
    internal class LoadingElements
    {
        public static void LoadObject(object sender, RoutedEventArgs e)
        {
            Button targetButton = e.Source as Button;
            if (targetButton.Name == "clipboardText")
            {
                var textblock = targetButton.Content as TextBlock;

                ShowWindows.ShowTextObj(textblock.Text.ToString());
            }
            else if (targetButton.Name == "clipboardImage")
            {
                Image image = (Image)targetButton.Content;

                ShowWindows.ShowImageObj((BitmapSource)image.Source);
            }
        }

        public static async void LoadAllObjects(WindowClipboard window)
        {
            var itemsArea = window.ClipboardItemsArea;
            itemsArea.Children.Clear();
            if (!Clipboard.IsHistoryEnabled())
            {
                var message = new TextBlock()
                {
                    Style = (Style)Application.Current.Resources["ClipboardMessage"],
                    Text = "Журнал буфера обмена отключён. Включите его нажав Win+V"
                };
                itemsArea.Children.Add(message);
                return;
            }

            var items = Clipboard.GetHistoryItemsAsync().GetResults();
            if (items.Items.Any() == false)
            {
                var message = new TextBlock()
                {
                    Style = (Style)Application.Current.Resources["ClipboardMessage"],
                    Text = "Буфер обмена не содержит объектов"
                };
                itemsArea.Children.Add(message);
                return;
            }

            await CreateObjectsList(items, itemsArea);
        }

        public static async Task CreateObjectsList(ClipboardHistoryItemsResult items, WrapPanel area)
        {
            foreach (var item in items.Items)
            {
                var itemButton = new Button
                {
                    Template = (ControlTemplate)Application.Current.Resources["clipboardItem"]
                };

                if (item.Content.Contains(DataFormats.Text))
                {
                    string text = await SeizureOfData.GetTxt(item);

                    itemButton.Name = "clipboardText";
                    itemButton.Content = new TextBlock
                    {
                        Style = (Style)Application.Current.Resources["cbTextObject"],
                        Text = text
                    };

                    itemButton.Click += new RoutedEventHandler(LoadObject);
                }
                else if (item.Content.Contains(DataFormats.Bitmap))
                {
                    //ClipboardObject clipboardObject = new ClipboardObject(item);

                    var image = await SeizureOfData.GetImageFromHistoryItem(item);

                    itemButton.Name = "clipboardImage";
                    itemButton.Content = new Image { Source = image };
                    WindowClipboard.ClickThis(itemButton);
                }
                else
                {
                    itemButton.Name = "clipboardRaw";
                    itemButton.Content = new TextBox
                    {
                        Name = "rawObject",
                        Text = "Необрабатываемый объект",
                        TextAlignment = TextAlignment.Center,
                        FontSize = 11,
                        TextWrapping = TextWrapping.Wrap,
                        Width = 110,
                        Height = 30,
                        Foreground = (Brush)Application.Current.Resources["TopText"]
                    };
                }

                //itemButton.ToolTip = new ToolTip()
                //{
                //    Content = itemButton.Content,
                //    Style = (Style)Application.Current.Resources["ToolTip"],
                //};

                area.Children.Add(itemButton);
            }
        }

    }
}
