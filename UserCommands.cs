using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ClipboardWindow
{
    public static class UserCommands
    {
        static UserCommands()
        {
            // Можно прописать горячие клавиши по умолчанию
            InputGestureCollection inputs = new InputGestureCollection();
            inputs.Add(new KeyGesture(Key.S, ModifierKeys.Control, "Ctrl+S"));

            SomeCommand = new RoutedUICommand("Some", "SomeCommand", typeof(UserCommands), inputs);
        }

        public static RoutedCommand SomeCommand { get; private set; }
    }
}
