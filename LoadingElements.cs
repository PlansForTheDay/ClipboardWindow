using ClipboardWindow.Windows;
using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using BitmapSource = System.Windows.Media.Imaging.BitmapSource;
using System.Windows.Media;
using Clipboard = Windows.ApplicationModel.DataTransfer.Clipboard;

namespace ClipboardWindow
{
    internal class LoadingElements
    {
        public static async void ShowLastObj()
        {
            //IDataObject clipboardList = Clipboard.GetDataObject();

            //SeizureOfData.LoadObjectWindow(clipboardList);

            var lastObject = Clipboard.GetHistoryItemsAsync().GetResults().Items.First();

            if (lastObject.Content == null)
            { return; }

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
            };

            window.ContentAera.Children.Add(image);
            window.Icon = (ImageSource)Application.Current.Resources["Image"];

            window.Height = bitmap.Height + 55;
            window.Width = bitmap.Width + 20;

            window.MaxHeight = SystemParameters.FullPrimaryScreenHeight;
            window.MaxWidth = SystemParameters.FullPrimaryScreenWidth;

            window.Show();
        }


        public static async void LoadAllObjects(WindowClipboard window)
        {
            var itemsArea = window.ClipboardItemsArea;

            itemsArea.Children.Clear();

            var items = Clipboard.GetHistoryItemsAsync();

            if (items.GetResults().Items.Any() == false)
            {
                var message = new TextBlock()
                {
                    Style = (Style)Application.Current.Resources["NonObject"]
                };

                itemsArea.Children.Add(message);
                return;
            }

            foreach (var item in items.GetResults().Items)
            {
                var button = new Button
                {
                    Template = (ControlTemplate)Application.Current.Resources["clipboardItem"]
                };

                if (item.Content.Contains(DataFormats.Text))
                {
                    string text = await SeizureOfData.GetTxt(item);

                    button.Name = "clipboardText";
                    button.Content = new TextBlock
                    {
                        Style = (Style)Application.Current.Resources["cbTextObject"],
                        Text = text
                    };

                    WindowClipboard.ClickThis(button);
                }
                else if (item.Content.Contains(DataFormats.Bitmap))
                {
                    var image = await SeizureOfData.GetImageFromHistoryItem(item);

                    button.Name = "clipboardImage";
                    button.Content = new Image { Source = image, MaxWidth = 97, MaxHeight = 80 };
                    WindowClipboard.ClickThis(button);
                }
                else
                {
                    button.Name = "clipboardRaw";
                    button.Content = new TextBox
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
                itemsArea.Children.Add(button);
            }
        }

    }
}
