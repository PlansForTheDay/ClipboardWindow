using System.Runtime.InteropServices;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using Cb = Windows.ApplicationModel.DataTransfer.Clipboard;
using System.Windows.Interop;

namespace ClipboardWindow.Windows
{
    /// <summary>
    /// Логика взаимодействия для Clipdoard.xaml
    /// </summary>
    public partial class WindowClipboard : Window
    {
        private static void cbItem_Click(object sender, RoutedEventArgs e)
        {
            LoadingElements.LoadObject(sender, e);
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
            ShowWindows.ShowLastObj();
        }

        private void clearButton_Click(object sender, RoutedEventArgs e)
        {
            Cb.ClearHistory();
            LoadingElements.LoadAllObjects(this);
        }
    }
}