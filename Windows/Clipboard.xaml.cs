using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using Cb = Windows.ApplicationModel.DataTransfer.Clipboard;

namespace ClipboardWindow.Windows
{
    /// <summary>
    /// Логика взаимодействия для Clipdoard.xaml
    /// </summary>
    public partial class WindowClipboard : Window
    {
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
            Cb.ClearHistory();
            LoadingElements.LoadAllObjects(this);
        }
    }
}