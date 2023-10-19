using ClipboardWindow.Windows;
using EnvDTE80;
using System;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Windows.Interop;

namespace ClipboardWindow
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        #region 1
        [DllImport("User32.dll")]
        private static extern bool RegisterHotKey(
            [In] IntPtr hWnd,
            [In] int id,
            [In] uint fsModifiers,
            [In] uint vk);

        [DllImport("User32.dll")]
        private static extern bool UnregisterHotKey(
            [In] IntPtr hWnd,
            [In] int id);

        [DllImport("User32.dll", CharSet = CharSet.Auto)]
        public static extern IntPtr SetClipboardViewer(IntPtr hWnd);

        private HwndSource _source;
        private const int LAST_OBJECT_SHOW = 9020;
        private const int ALL_OBJECTS_KEY = 9001;


        protected override void OnSourceInitialized(EventArgs e)
        {
            base.OnSourceInitialized(e);
            var helper = new WindowInteropHelper(this);
            _source = HwndSource.FromHwnd(helper.Handle);
            _source.AddHook(HwndHook);
            RegisterHotKey();
            SetClipboardViewer(helper.Handle);
        }

        protected override void OnClosed(EventArgs e)
        {
            _source.RemoveHook(HwndHook);
            _source = null;
            UnregisterHotKey();
            base.OnClosed(e);
        }

        private void RegisterHotKey()
        {
            var helper = new WindowInteropHelper(this);
            const uint KEY_O = 0x4F;
            const uint KEY_V = 0x56;
            const uint KEY_B = 0x42;
            const uint KEY_G = 0x47;
            const uint KEY_P = 0x50;
            const uint MOD_CTRL = 0x0002;
            const uint MOD_SHIFT = 0x10;
            const uint MOD_ALT = 0x20;
            if (!RegisterHotKey(helper.Handle, LAST_OBJECT_SHOW, MOD_CTRL, KEY_B))
            {// handle error
            }
            if (!RegisterHotKey(helper.Handle, ALL_OBJECTS_KEY, MOD_CTRL, KEY_P))
            {
            }
        }

        private void UnregisterHotKey()
        {
            var helper = new WindowInteropHelper(this);
            UnregisterHotKey(helper.Handle, LAST_OBJECT_SHOW);
            UnregisterHotKey(helper.Handle, ALL_OBJECTS_KEY);
        }

        private IntPtr HwndHook(IntPtr hwnd, int msg, IntPtr wParam, IntPtr lParam, ref bool handled)
        {
            const int WM_HOTKEY = 0x0312;
            const int WM_DRAWCLIPBOARD = 0x0308;
            switch (msg)
            {
                case WM_HOTKEY:
                    switch (wParam.ToInt32())
                    {
                        case LAST_OBJECT_SHOW:
                            ShowWindows.ShowLastObj();
                            handled = true;
                            break;

                        case ALL_OBJECTS_KEY:
                            bool windowDetected = false;
                            foreach (Window window in OwnedWindows)
                            {
                                if (window is WindowClipboard windowClipboard)
                                {
                                    windowDetected = true;
                                    break;
                                }
                            }
                            if (!windowDetected)
                            {
                                ShowWindows.ShowClipboardWindows(this);
                                Hide();
                            }
                            handled = true;
                            break;
                    }
                    break;

                case WM_DRAWCLIPBOARD:
                    Dispatcher.InvokeAsync(async () =>
                    {
                        await Task.Delay(220);
                        foreach (Window window in OwnedWindows)
                        {
                            if (window is WindowClipboard windowClipboard)
                            {
                                LoadingElements.LoadAllObjects(windowClipboard);
                                break;
                            }
                        }
                    });
                    handled = true;
                    break;
            }
            return IntPtr.Zero;
        }
        #endregion

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
            ShowWindows.ShowInfoWindow(this);

            Hide();
        }

        private void settingButton_Click(object sender, RoutedEventArgs e)
        {
            ShowWindows.ShowSettingsWindows(this);

            Hide();
        }

        private void clipboardButton_Click(object sender, RoutedEventArgs e)
        {
            ShowWindows.ShowClipboardWindows(this);

            Hide();
        }

        private void TaskbarIcon_TrayLeftMouseDown(object sender, RoutedEventArgs e)
        {
            foreach (Window childWindows in OwnedWindows)
                childWindows.Close(); 

            Show();
        }

        private void CommandBinding_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            ShowWindows.ShowLastObj();
        }

        private void Window_StateChanged(object sender, EventArgs e)
        {
        }
    }
}
