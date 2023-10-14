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
                    Topmost = false; 
                    break;

                case false: 
                    Topmost = true;
                    break;
            }
        }

        private static void image_MouseWheel(object sender, MouseWheelEventArgs e)
        {
            Image image = sender as Image;

            var st = (ScaleTransform)image.RenderTransform;
            double zoom = e.Delta > 0 ? .2 : -.2;

            if ((st.ScaleX < 0.5 || st.ScaleY < 0.5) && zoom < 0)
                return;

            st.ScaleX += zoom;
            st.ScaleY += zoom;
            st.CenterX = image.RenderSize.Width / 2;
            st.CenterY = image.RenderSize.Height / 2;
        }

        public static void ChangeZoom(Image image)
        {
            image.MouseWheel += new MouseWheelEventHandler(image_MouseWheel);
        }

        private void Window_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            
        }
    }
}
