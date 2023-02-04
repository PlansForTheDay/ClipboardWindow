using System;
using System.Collections.Generic;
using System.Linq;
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

namespace ClipboardWindow.Windows
{
    /// <summary>
    /// Логика взаимодействия для ObjectFromBuffer.xaml
    /// </summary>
    public partial class ObjectFromBuffer : Window
    {
        public ObjectFromBuffer()
        {
            InitializeComponent();
        }

        private void controlButtonPanel_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (WindowState == WindowState.Maximized) 
            {
                WindowState = WindowState.Normal;
            }

            DragMove();
        }

        private void collapseButton_Click(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }

        private void closeButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void Window_StateChanged(object sender, EventArgs e)
        {
            if (WindowState == WindowState.Maximized)
            {
                WindowState = WindowState.Normal;
            }
        }

        private void overButton_Click(object sender, RoutedEventArgs e)
        {
            switch (Topmost)
            {
                case true: 
                    //overButton.BorderBrush = new SolidColorBrush(Colors.Black);

                    Topmost = false; 
                    break;
                case false: 
                    //LinearGradientBrush myLinearGradientBrush = new LinearGradientBrush();
                    //myLinearGradientBrush.StartPoint = new Point(0, 0);
                    //myLinearGradientBrush.EndPoint = new Point(1, 1);
                    //myLinearGradientBrush.GradientStops.Add(new GradientStop(Color.FromArgb(1, 227, 176, 11), 0.9));
                    //myLinearGradientBrush.GradientStops.Add(new GradientStop(Color.FromArgb(1, 250, 217, 0), 0));

                    //overButton.BorderBrush = myLinearGradientBrush;
                    Topmost = true;

                    break;
            }
        }
    }
}
