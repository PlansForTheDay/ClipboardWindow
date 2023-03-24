using ClipboardWindow.Windows;
using Hardcodet.Wpf.TaskbarNotification;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Windows.UI.Xaml.Controls;
using Clipboard = System.Windows.Clipboard;
using IDataObject = System.Windows.IDataObject;

using System.Drawing;
using System.ComponentModel;
using System.Windows.Interop;

namespace ClipboardWindow
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        //[DllImport("user32.dll", SetLastError = true)]
        //[return: MarshalAs(UnmanagedType.Bool)]
        //public static extern bool RegisterHotKey(IntPtr hWnd, int id, uint fsModifiers, uint vk);

        #region bind

        //public const int MOD_ALT = 0x1;
        //public const int MOD_CONTROL = 0x2;
        //public const int MOD_SHIFT = 0x4;
        //public const int MOD_WIN = 0x8;
        //public const int WM_HOTKEY = (int)Keys.P;

        //protected override void OnSourceInitialized(EventArgs e)
        //{
        //    base.OnSourceInitialized(e);
        //    HwndSource source = HwndSource.FromHwnd(new WindowInteropHelper(this).Handle);
        //    source.AddHook(new HwndSourceHook(WndProc));
        //    //HwndSource source = PresentationSource.FromVisual(this) as HwndSource;
        //    //source.AddHook(WndProc);
        //}

        //private IntPtr WndProc(IntPtr hwnd, int msg, IntPtr wParam, IntPtr lParam, ref bool handled)
        //{
        //    //System.Windows.Forms.MessageBox.Show("Запустился WndProc");

        //    if (msg == WM_HOTKEY)
        //    {
        //        //IDataObject clipboardList = Clipboard.GetDataObject();
        //        //SeizureOfData.LoadObjectWindow(clipboardList);
        //        LoadingElements.ShowLastObj();
        //    }

        //    //WndProc(hwnd, msg, wParam, lParam, ref handled);
        //    return IntPtr.Zero;
        //}

        #endregion bind

        // это команда в теории принимает все сообщения от винды, но видимо расположение "приёмника" находися в определённом месте, из-за чего и функцию нужно переопределить именно там 
        // либо как то сказать что бы сообщения шли именно сюда. и возможно ответ здесь => https://stackoverflow-com.translate.goog/questions/624367/how-to-handle-wndproc-messages-in-wpf?_x_tr_sl=en&_x_tr_tl=ru&_x_tr_hl=ru&_x_tr_pto=sc
        //protected override void WndProc(ref Message m)
        //{
        //    if (m.Msg == WM_HOTKEY)
        //    {
        //        IDataObject clipboardList = Clipboard.GetDataObject();
        //        SeizureOfData.LoadObjectWindow(clipboardList);
        //        m.Result = (IntPtr)0;
        //    }
        //    WndProc(ref m);
        //}

        public MainWindow()
        {
            InitializeComponent();

            //var wdn = new WindowInteropHelper(this);

            //bool res = RegisterHotKey(wdn.Handle, 1, MOD_ALT, (uint)Keys.P);
            //if (res == false)
            //{
            //    System.Windows.Forms.MessageBox.Show("Горячая клавиша не работает");
            //}

        }


        private void closeButton_Click(object sender, RoutedEventArgs e)
        {
            Hide();
        }

        private void collapseButton_Click(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }

        private void controlButtonPanel_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }

        private void informstionButton_Click(object sender, RoutedEventArgs e)
        {
            WindowInformation informationWindow = new WindowInformation { Owner = this };
            informationWindow.Show();

            Hide();
        }

        private void settingButton_Click(object sender, RoutedEventArgs e)
        {
            Settings settings = new Settings { Owner = this };
            settings.Show();

            Hide();
        }

        private void clipboardButton_Click(object sender, RoutedEventArgs e)
        {
            WindowClipboard clipboardWindow = new WindowClipboard { Owner = this };
            clipboardWindow.Show();

            Hide();
        }

        private void TaskbarIcon_TrayLeftMouseDown(object sender, RoutedEventArgs e)
        {
            foreach (Window childWindows in OwnedWindows)
            {
                childWindows.Close();
            }

            Show();
        }

        private void CommandBinding_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            LoadingElements.ShowLastObj();
        }

        private void Window_StateChanged(object sender, EventArgs e)
        {
        }
    }
}
