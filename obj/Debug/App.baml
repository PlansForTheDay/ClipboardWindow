   M S B A M L   `   `   `  ????J  FClipboardWindow, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null1clr-namespace:ClipboardWindowClipboardWindow  5          ClipboardWindow.App   5      W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      /localclr-namespace:ClipboardWindow     5        ?? 	Resources  5         Icon  	Clipboard  Information  Settings 
 Update  Text 	 Image  WindowBackground ?? 
StartPoint ?? EndPoint ? Color ? Offset  WindowBorder 	 MaitTextFill ?? Opacity 
 MenuButtonBorder   MenuButtonBorder_IsMouseOver  MenuButtonBorder_IsPressed  MenuBackground_IsPressed  TrayItemBackground  TopText  treyContextMenu  MenuItem J? Opacity ?? 
TargetType ?? Property	 ?? Value  windowBorder  menuTextBox  menuButtonsBorder  cbTextObject  windowImageFromCb  windowTextFromCb
 ?? 
TargetType  verticalScrollBar ??Name ?? CornerRadius  clipboardItem ?? Triggers P? Property P? Value ?? 
TargetName  menuButtons ??Name  buttonBlock  overButtons ?? Color F?Name ?? 
StartPoint ?? EndPoint  collapseButtons ??Name	 ?? X1	 ?? Y1	 ?? X2	 ?? Y2  crossButtons ?? Stretch??%?%  &	        &	 4     &	 s     &	 ?     &	 ?     &	 (    &	 Y    &	 ?    &	 )    &		 ?    &	
 8    &	 ?    &	 Z    &	 ?    &	 |    &	     &	 ?    7  7  7 	 &	 J    7  7  &	 ?    7  7  &	 ?	    7 	 &	 l
    7 
 &	 y    &	 W    &	 ?    7  &	 ?    7  7  &	     7  &	 ?    7  7  7  7  &	 U    &	 ?    &	 ?    &	 k     ?? 5   
   $ ??/Windows/Resource/Icon.ico??6   ?? 5	   
   $+??%/Windows/Resource/clipboardButton.ico??6"   ?? 5
   
   $-??'/Windows/Resource/informationButton.ico??6$   ?? 5   
   $*??$/Windows/Resource/settingsButton.ico??6!   ?? 5   
   $"??/Windows/Resource/update.png??6   ??5   
   Windows\Resource\text.ico??6>   ??5   
   Windows\Resource\image.ico??6@   ?? 5   
   $	 0,0&?5      $	 1,1&?5      .??5      ? $ #001517??6   $	 0.9Q?6+   ? 5      $ #000114??6   $ 0Q?6+   5      ?? 5   
   .??5      ? $ #27F5EB??6   $	 0.2Q?6+   ? 5      $ #26EBA9??6   5      ?? 5   
   $	 0.6Q?5      $	 1,0&?5      $	 0,1&?5      .??5      ? $ #8550D9??6   $	 0.9Q?6+   ? 5      $ #30B7CD??6   5       ?? 5!   
   $	 0.5Q?5"      .??5#      ? $ #8550D9??6   $	 0.9Q?6+   ? 5$      $ #30B7CD??6   5%      ?? 5&   
   $	 0,0&?5'      $	 1,1&?5(      $	 0.8Q?5)      .??5*      ? $ #8550D9??6   $	 0.9Q?6+   ? 5+      $ #30B7CD??6   5,      ?? 5-   
   $	 0.5Q?5.      .??5/      ? $ #8953E0??6   $	 0.8Q?6+   ? 50      $ #31BFEB??6   51      ?? 52   
   $	 0,0&?53      $	 1,1&?54      $	 0.4Q?55      .??56      ? $ #8550D9??6   $	 0.9Q?6+   ? 57      $ #30B7CD??6   58      ?? 59   
   $	 0.3Q?5:      $	 0,0&?5;      $	 1,1&?5<      .??5=      ? $ #FF3382??6   $ 1Q?6+   ? 5>      $ #40BBFF??6   5?      ?? 5@   
   $ 1Q?5A      $	 0,0&?5B      $	 1,1&?5C      .??5D      ? $ #3841E0??6   $	 1.2Q?6+   ? 5E      $ #30B7CD??6   5F      ?? 5H   
   8??  8?? $	??0.5q?5K      .@?5M      m? $??
lastObject??6   -   5        $'??!Последний элемент??5M   )   #???  6]   m? 5N      $??
menuButton??6   -   5        $??Меню??5N   )   #???  6P   ?? 5O      8?? $	 0.5Q?6C   $
??-2,2q?6Q   m? 5P      $??
exitButton??6   -   5        $??Закрыть??5P   )   #???  6S   5Q      ?? 5S   
   " m?6   .?5T      ??  ? ??8	   6+   ?? 5U       ? ??8	  6,   ?? 5V       ? ??$		 0.5q?60   5W      ?? 5Y   
   " ??6   .?5Z      ??  ? ??$	 1q?60   ?? 5[       ?@??CornerRadius$	 4??6-   ?? 5\       ? ??8	   6+   ?? 5]       ? ??8	  6,   5^      ?? 5`   
   " ??6   .?5a      ??  ? ??$		 5,3q?6'   ?? 5b       ? ??$	 11(?6)   ?? 5c       ? ??$	 Cascadia Code)?6+   ?? 5d       ? ??$
	 Wrap=?6-   ?? 5e       ? ??8	   6+   5f      ?? 5h   
   
border??" ??6    .?5i      ??  ? ??$	 2q?60   ?? 5j       ?@??CornerRadius$	 5??6-   ?? 5k       ? ??$	 40??6'   ?? 5l       ? ??$	 40??6&   ?? 5m       ? ??$	 2q?6'   ?? 5n       ? ??8	   6,   5o      ?? 5q   
   " ??6   .?5r      ??  ? ??$
	 10,7q?6'   ?? 5s       ? ??$	 8(?6)   ?? 5t       ? ??$
	 Wrap=?6-   ?? 5u       ? ??
	 ?????6+   ?? 5v       ? ??$		 110??6&   5w      ?? 5y   
   " ??6   .?5z      ??  ? ??$	 5q?6'   ?? 5{       ? ??$
	 Fill=?6(   5|      ?? 5~   
   " ??6   .?5      ??  ? ??$	 15(?6)   ?? 5?       ?@??TextWrapping$
	 Wrap=?6-   ?? 5?       ?@??AutoWordSelection	 .  62   ?? 5?       ? ??
	 ?????6+   ?? 5?       ? ??
	 ???? 6+   ?? 5?       ? ??$	 Stretch=?62   ?? 5?       ? ??$	 Stretch=?64   ?? 5?       ? ??$	 5q?6'   ?? 5?       ? ??$
	 Auto=?6I   ?? 5?       ? ??8	   69   ?? 5?       ? ??$		 0.5q?6=   ?? 5?       ? ??
	 ???? 68   5?      ?? 5?   
   "
 ??6   .R?5?      ? $??3q?6   $??Right=?6   .+?5?      ?? $ border??6   8??  $ 1Q?6U   $	??0.7q?6a   $??5??6w   $ 3??6?   n? 5?      ??5?      ?? 5?      .R?5?      ? .+?5?   "   ?? 8?? $ 3??6T   $	??1.5q?6e   $	 0.5Q?6r   5?      5?      5?      5?      5?      ?? 5?   
   "
 ??6   clipboardItem??.R?5?      ? $
??item??6   $	??120??6   $??90??6+   $??10q?67   
?????? .+?5?      ? .+?5?      ?? $??border??6   $??86??6+   $	??116??67   $ 10??6C   8??  $??2q?6|   ?? 5?      #??z??6%   5?      5?       5?      P? 5?       ?@J?IsMouseOver . . ?5?      ?? $ border??6    ?@J?Opacity$		 0.4Q?6D   ?? 5?      $ border??6    ? ??$	 1q?6L   5?      P? 5?       ? ?? . . ?5?      ?? $ border??6    ?@J?Opacity$	 1Q?6D   ?? 5?      $ border??6    ? ??$	 3q?6L   5?      5?      ?? 5?   
   "
 ??6   .R?5?      ? .+?5?      ?? $ content??6!   #??z??62   $	 0.7Q?6V   ?? 5?      $ border??6   8??  6)   5?       5?      P? 5?       ?@J?IsMouseOver . . ?5?      ?? $ border??6    ? ??$		 1.5q?6L   ?? 5?      $ border??6    ? ??	 ?#042D426H   ?? 5?      $ border??6   8	   ? ??6G   ?? 5?      $ content??6    ?@J?Opacity$	 1Q?6E   5?      P? 5?       ? ?? . . ?5?      ?? $ border??6    ? ??$	 3q?6L   ?? 5?      $ border??6   8	   ? ??6H   ?? 5?      $ border??6   8	   ? ??6G   ?? 5?      $ content??6    ?@J?Opacity$		 0.7Q?6E   5?      5?      ?? 5?   
   "
 ??6   .R?5?      ?? $	??0.1q?6   $??10(?6-   $??
10,5,10,10q?6;   $??Cascadia Mono Light)?6O   #??z??5?      #??z??69   ??5?      ?? 5?      $	 0.5Q?6*   .??5?      ? $ #3841E0??6'   $	 1.3Q?67   ? 5?      $ #26EBA9??6'   5?      5?      5?      ?? 5?   
   "
 ??6   .R?5?      ? .+?5?      ?? $ border??5?      $??20??5?      $??20??5?      $ 2??5?      $	??0.7q?5?      
?????????5?      ?? 5?      $ Black??6*   $	 0.8Q?68   ._?5?      ?? .??5?      F? $
 over??6   $	??Top=?6-   $
??Left=?6E   
???????$	??1.5??6o   ??5?      ? 5?   "   .??5?   &   ?? $ 3.3,12.3&?63   $ 9.4,6.3&?6I   ?? 5?   &   $ 8.4,6.3&?63   $ 	15.3,12.3&?6H   5?   #   5?      5?      5?      5?       5?      P? 5?       ?@J?IsMouseOver . . ?5?      ?? $ border??6    ? ??	 5?      ?? 5?      $	 0,0&?62   $	 1,1&?6C   $	 0.9Q?6R   .??5?   "   ? $ #FAD900??6/   $ 0Q?6?   ? 5?   "   $ #E3B00B??6/   $	 0.9Q?6?   5?      5?      ?? 5?      $ border??6    ? ??
	 ?   ?6H   ?? 5?      $
 over??6    ? ??
	 ?   ?6A   ?? 5?      $
 over??6    ? ??$		 2.2??6J   5?      P? 5?       ?@d?	IsChecked$
 TrueY?6/   . ?5?      ?? $ border??6    ? ??	 5?      ?? 5?      $ Black??6.   $	 0.8Q?6<   5?      ?? 5?      $ border??6    ? ??	 5?      ?? 5      $	 0,0&?62   $	 1,1&?6C   $	 0.9Q?6R   .??5  "   ? $ #FAD900??6/   $ 0Q?6?   ? 5  "   $ #E3B00B??6/   $	 0.9Q?6?   5     5     ?? 5     $
 over??6    ? ??	 5     ?? 5     $	 0,0&?62   $	 1,1&?6C   $	 0.9Q?6R   .??5	  "   ? $ #FAD900??6/   $ 0Q?6?   ? 5
  "   $ #E3B00B??6/   $	 0.9Q?6?   5     5     5     5     ?? 5  
   "
 ??6   .R?5     ? .+?5     ?? $ border??5     $??20??5     $??20??5     $ 2??5     $	??0.7q?5     
?????????5     ?? 5     $ Black??6*   $	 0.8Q?68   ._?5     ?? .??5     ?? $
 line??6   $ 0??6-   $ 1??64   $ 11??6;   $ 1??6C   $??Center=?6J   $??Center=?6g   
???????$	??1.5??5   .   5!     5"     5#      5$     P? 5%      ?@J?IsMouseOver . . ?5&     ?? $ border??6    ? ??	 5'     ?? 5(     $	 0,0&?62   $	 1,1&?6C   $	 0.9Q?6R   .??5)  "   ? $ #2EBADF??6/   $ 0Q?6?   ? 5*  "   $ #2792F5??6/   $	 0.9Q?6?   5+     5-     ?? 5.     $ border??6    ? ??$		 1.3q?6L   ?? 5/     $ border??6    ? ??
	 ?   ?6H   ?? 50     $
 line??6    ? ??
	 ?   ?6A   ?? 51     $
 line??6    ? ??$		 2.2??6J   52     54     ?? 56  
   "
 ??6   .R?57     ? .+?58     ?? $ border??59     $??20??5:     $??20??5;     $ 2??5<     $	??0.7q?5=     
?????????5?     ?? 5@     $ Black??6*   $	 0.8Q?68   ._?5B     ?? .??5C     F? $ cross??6   =????        ?@ @ ? 5  5 ?@  5 ? 5 @ ?@B @B 	$ Uniform=?5D     
???????$	??1.5??6>   5E     5F     5G      5H     P? 5I      ?@J?IsMouseOver . . ?5J     ?? $ border??6    ? ??	 5K     ?? 5L     $	 0,0&?62   $	 1,1&?6C   $	 0.9Q?6R   .??5M  "   ? $ #DD3E7B??6/   $ 0Q?6?   ? 5N  "   $ #D6042B??6/   $	 0.9Q?6?   5O     5Q     ?? 5R     $ border??6    ? ??$		 1.3q?6L   ?? 5S     $ border??6    ? ??
	 ?   ?6H   ?? 5T     $ cross??6    ? ??
	 ?   ?6B   ?? 5U     $ cross??6    ? ??$		 2.2??6K   5V     5X     5Z     5[     