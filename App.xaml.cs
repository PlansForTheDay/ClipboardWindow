using ClipboardWindow.Windows;
using Hardcodet.Wpf.TaskbarNotification.Interop;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using ClipboardWindow;

namespace ClipboardWindow
{
    /// <summary>
    /// Логика взаимодействия для App.xaml
    /// </summary>
    public partial class App : Application
    {
        private void ExitButton_Click(object sender, RoutedEventArgs e)
        {
            Current.Shutdown();
        }

        private void MenuButton_Click(object sender, RoutedEventArgs e)
        {
            foreach (Window window in MainWindow.OwnedWindows)
            {
                window.Close();
            }
            
            MainWindow.Show();
        }

        private void lastObject_Click(object sender, RoutedEventArgs e)
        {
            LoadingElements.ShowLastObj();
        }
    }
}
