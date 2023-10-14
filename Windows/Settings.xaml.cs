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
    /// Логика взаимодействия для Settings.xaml
    /// </summary>
    public partial class Settings : Window
    {
        public Settings()
        {
            InitializeComponent();
        }

        private void closeButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void collapseButton_Click(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }

        private void controlButtonPanel_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }

        private void mainMenuButton_Click(object sender, RoutedEventArgs e)
        {
            Owner.Show();

            Close();
        }

        private void Сhapter_Checked(object sender, RoutedEventArgs e)
        {
            ParametersArea.Children.Clear();

            if (VisualСhapter.IsChecked == true) 
            {
                var themeBox = new GroupBox()
                {
                    Header = "Тема",
                    Style = (Style)Application.Current.Resources["Parameter"],
                    Content = new StackPanel() 
                    {
                        Orientation = Orientation.Vertical,
                        Children = 
                        {
                            new TextBlock()
                            {
                                Style = (Style)Application.Current.Resources["menuTextBox"],
                                Width = 368, 
                                VerticalAlignment = VerticalAlignment.Top,
                                HorizontalAlignment = HorizontalAlignment.Left,
                                Text = "Выберете палитру цветов приложения."
                            },
                            new WrapPanel()
                            {
                                Orientation = Orientation.Horizontal,
                                Margin = new Thickness(5, 5, 5, 5),
                                Width = 368,
                                HorizontalAlignment= HorizontalAlignment.Left,
                                Children=
                                {
                                    new Label()
                                    {
                                        Foreground = Brushes.PaleVioletRed,
                                        FontFamily = new FontFamily("Courier New"),
                                        Content = " ~~~ Пока не работает ~~~"
                                    }
                                }

                            }
                        }
                    }
                };
                ParametersArea.Children.Add(themeBox);
            }
            if (ProgramСhapter.IsChecked == true)
            {
                var autorunBox = new GroupBox()
                {
                    Header = "Автозапуск",
                    Style = (Style)Application.Current.Resources["Parameter"],
                    Content = new StackPanel()
                    {
                        Orientation = Orientation.Vertical,
                        Children =
                        {
                            new TextBlock()
                            {
                                Style = (Style)Application.Current.Resources["menuTextBox"],
                                Width = 368,
                                VerticalAlignment = VerticalAlignment.Top,
                                HorizontalAlignment = HorizontalAlignment.Left,
                                Text = "Запускать приложение вместе со стартом системы."
                            },
                            new WrapPanel()
                            {
                                Orientation = Orientation.Horizontal,
                                Margin = new Thickness(5, 5, 5, 5),
                                Width = 368,
                                HorizontalAlignment= HorizontalAlignment.Left,
                                Children=
                                {
                                    new Label()
                                    {
                                        Foreground = Brushes.PaleVioletRed,
                                        FontFamily = new FontFamily("Courier New"),
                                        Content = " ~~~ Пока не работает ~~~"
                                    }
                                }

                            }
                        }
                    }
                };

                var bindBox = new GroupBox()
                {
                    Header = "Горячие клавиши",
                    Style = (Style)Application.Current.Resources["Parameter"],
                    Content = new StackPanel()
                    {
                        Orientation = Orientation.Vertical,
                        Children =
                        {
                            new TextBlock()
                            {
                                Style = (Style)Application.Current.Resources["menuTextBox"],
                                Width = 368,
                                VerticalAlignment = VerticalAlignment.Top,
                                HorizontalAlignment = HorizontalAlignment.Left,
                                Text = "Использование горячих клавишь, для быстрого использования некоторых вункций."
                            },
                            new WrapPanel()
                            {
                                Orientation = Orientation.Horizontal,
                                Margin = new Thickness(5, 5, 5, 5),
                                Width = 368,
                                HorizontalAlignment= HorizontalAlignment.Left,
                                Children=
                                {
                                    new Label()
                                    {
                                        Foreground = Brushes.PaleVioletRed,
                                        FontFamily = new FontFamily("Courier New"),
                                        Content = " ~~~ Пока не работает ~~~"
                                    }
                                }

                            }
                        }
                    }
                };
                ParametersArea.Children.Add(autorunBox);
                ParametersArea.Children.Add(bindBox);
            }
        }
    }
}
