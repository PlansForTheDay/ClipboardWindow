   M S B A M L   `   `   `  ����J  FClipboardWindow, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullA%clr-namespace:ClipboardWindow.WindowsClipboardWindow.Windows  5   	   &     ClipboardWindow.Windows.Settings   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   7local%clr-namespace:ClipboardWindow.Windows     5   	   -   5          �Name$  SettingsWindow��5   	    � Title$+ %Параметры - Clipboard Window��5	   	    � Icon$! Resource\settingsButton.ico��5
   	    � WindowStyle$
 None=�5   	    � 
ResizeMode$ NoResize=�5   	   
������  � AllowsTransparency .  � WindowStartupLocation$ CenterScreen=�5   	    � SizeToContent$ WidthAndHeight=�5   	   .��5      � $��Center=�6   $��Center=�6&   .+�5   
   ��    windowBorder#��[  6   � 5   
    � RowDefinitions 5      �� 5      $��25 �6    �� 5      �� 5      $��88 �6    .+�5      � -   5        	 �Name$	 controlButtonPanel��5      $��0��5      .+�5      �� $��Параметры��6   $��Cascadia Code SemiBold)�6,   $��13(�6P     TopText#��[ 6^   �� 5!      -   5        
 ��Name$
 controlButton��5!       �� Orientation$ 
Horizontal=�5"      $��Right=�5#      .+�5$      �� -   5         ��Name$ collapseButton��5$        collapseButtons#��[ 65   $	��2.5q�6~   �� 5%      -   5        $ closeButton��5%        crossButtons#��[ 62   $	��2.5q�6u   5&      5'      �� 5)      $��1��6   $ 
Horizontal=�6&   .+�5*      �� -   5        $
 	Сhapters��5*      $ Vertical=�5+      $��96��5,      $
��Left=�6(   .+�5.      	� -   5         	�Name$ VisualСhapter��5.   "    	� 	GroupName$ groupСhapter��5/   "   $
��Left=�50   "     Сhapter#��[ 51   "   $��Внешний вид��53   "    d� 	IsChecked$ FalseY�68   54      	� 56      -   5        $ ProgramСhapter��56   "   $ groupСhapter��57   "   $
��Left=�58   "   #��[ 59   "   $��Приложение��5;   "   5<      5>      �� 5B        WindowBorder#��[ 6   $	��0.5q�6E    �� CornerRadius$ 6,0,0,6��6[   ._�5C      �� -	   5        $
 ParametersArea��5C   !   $ Vertical=�69   $	��350��6P   $	��400��6]   5E      5F      5H      �� 5J      -
   5         ��Name$ menuButtonArea��5J        buttonsBlock#��[ 5K      $��
Назад��5L      $��2��5M      $��	10,0,10,5q�5N      .��5O      �� $ 
Horizontal=�6   .+�5P      �� -   5        $ mainMenuButton��5P      $
��Left=�5Q        menuButtons#��[ 5R      .��5T      �� $��Resource\Icon.ico��6    $��5q�6;   $��Center=�6F   5U      �� 5W        menuTextBox#��[ 6    20Вернуться в основное меню.5Y      5Z      5[      5\      5]      5^      