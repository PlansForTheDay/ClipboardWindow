using ClipboardWindow.Windows;
using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using BitmapSource = System.Windows.Media.Imaging.BitmapSource;
using System.Windows.Media;
using Clipboard = Windows.ApplicationModel.DataTransfer.Clipboard;
using ClipboardWindow.Models;

namespace ClipboardWindow
{
    internal class LoadingElements
    {
        public static async void ShowLastObj()
        {
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
                var itemButton = new Button
                {
                    Template = (ControlTemplate)Application.Current.Resources["clipboardItem"]
                };

                if (item.Content.Contains(DataFormats.Text))
                {
                    //ClipboardObject clipboardObject = new ClipboardObject(item);

                    string text = await SeizureOfData.GetTxt(item);

                    itemButton.Name = "clipboardText";
                    itemButton.Content = new TextBlock
                    {
                        Style = (Style)Application.Current.Resources["cbTextObject"],
                        Text = text
                    };

                    WindowClipboard.ClickThis(itemButton);
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

                itemsArea.Children.Add(itemButton);
            }
        }
    }
}
