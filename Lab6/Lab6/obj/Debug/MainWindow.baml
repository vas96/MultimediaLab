   M S B A M L   `   `   `  ����H  DMahApps.Metro, Version=1.5.0.0, Culture=neutral, PublicKeyToken=nullV;clr-namespace:MahApps.Metro.Controls;assembly=MahApps.MetroMahApps.Metro.Controls  5      ? ;Lab6, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:Lab6Lab6 5   	      Lab6.MainWindow   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   PControls;clr-namespace:MahApps.Metro.Controls;assembly=MahApps.Metro     5      $localclr-namespace:Lab6     5   	     � Title$  Lab6(MediaPlayer)��5	   	   $	��350��6#   $	��525��60    � 	Resources 5       �� MergedDictionaries �� Source�� 5   
    5      �� 5      $ /Resources/Icons.xaml?�6%   �� 5      $M Gpack://application:,,,/MahApps.Metro;component/Styles/Accents/Blue.xaml?�6%   �� 5      $R Lpack://application:,,,/MahApps.Metro;component/Styles/Accents/BaseLight.xaml?�6%   %    5      (   "MahApps.Metro.Controls.MetroWindow   RightWindowCommands 5      +   %MahApps.Metro.Controls.WindowCommands  5   
   .@�5      �� $�� ��6   �� 5      .��5      ��  �� Orientation$ 
Horizontal=�6   .+�5      �� $��20��6    $��20��5       ��5!      ��  �� RelativeSource ��  �� AncestorType$ ButtonL� �� Path$ 
Foreground�	 J� OpacityMask	 5"      !� 5#      
 j� Stretch$

 Fill=�6*      appbar_flag_bear !� Visual# [  69   5%      �� 5&      $��4 0 0 0q�6    $��Center=�5'      $	��Vas��5(      5)      5*      5+      .��5.      �� $
��auto��6   $
��auto��6    �� CornerRadius$ 	0,30,0,30��5/      ._�50   
   �  � RowDefinitions 51      �� 52      $
��0.5* �6    61   �� 53      $��5* �6    6/   �� 55      $
��0.2* �6    61   �� 56      $
��0.7* �6    61    � ColumnDefinitions 58      �� 59      $��2* �6#   �� 5:      $	��172 �6#   .+�5=      �� $��1��6   $��2��6#   ��5>      �� 5?       �� Color$ Black��6&   ._�5A      r� -   5         r�Name$ mediaElement��5A       r� LoadedBehavior$ Manual=�66   $��0,0,0,0q�6N   $��Stretch=�6`   $
��auto��6   5C      5D      �� 5H      -   5         ��Name$ positionSlider��5H      $��2��6.     
FlatSlider#��[ 6;   $��Stretch=�6`   $��
10,0,10,33q�6�   $
��Auto��6�   $��2��6�   $��2��6�   5J      �� 5L      $��0��6   $��1��6&   $ 
Horizontal=�67   $
��Left=�6P   .+�5M      �� -   5         ��Name$ DarkThem��5M      $��	Dark Them��6+   $��Center=�6?   $��Right=�6[   $��	0,-2,8,-3q�6w   $��30��6�   $��75��6�     MetroCircleButtonStyle#���  6�   5N      �� 5O      -   5        $ 	LightThem��5O      $��
Light Them��6,   $��Center=�6A   $��Right=�6]   $��	0,-2,8,-3q�6y   $��30��6�   $��75��6�   #���  6�   5P      5Q      �� 5R      -   5        $ FileButt��5R      $��Center=�6'   $
��Left=�6B   $
��auto��6^   $��75��6l     AccentedSquareButtonStyle#��[ 6w   $��5,1,5,1q�6�   .��5T      �� $ 
Horizontal=�6   $	��Top=�66   .+�5U      �� 
���   �$��17��6-   $
��auto��68   $��Stretch=�6F   $
��Left=�6b   $��2q�6}   	 5V      !� 5W        appbar_folder_open# [ 6*   $

 Fill=�6W   5Y      �� 5Z      $��5,0,0,0q�6    File67   5[      5\      �� 5_      $��3��6   $ 
Horizontal=�6'   .+�5a      �� -   5        $ 	StartButt��5a      $��Center=�6,   $
��Left=�6G   $��30��6c   $��40��6q   #��[ 6�   $��2,2,12,2q�6�    � Triggers 5b      :� 5c       :� RoutedEvent$ Button.MouseMove��6'   .[�5d      �� .��5e      �� .��5f   "   �� 	 �� To$	 RedX�61    �� TargetProperty$1 +(Button.Background).(SolidColorBrush.Color)�5g   %    g� FillBehavior$
 Stop=�5h   %    g� Duration$ 0:0:5D�5i   %   5j      5k      5l      .��5n      �� 
���   �$��21��6-   $��18��68   $��Stretch=�6D   	 5o      !� 5p        appbar_control_play# [ 6*   $

 Fill=�6X   5r      5s      �� 5t      -   5        $ 
RewindButt��5t      $��Center=�6-   $
��Left=�6H   $��30��6d   $��40��6p   #��[ 6{   $��2q�6�   .��5u      �� 
���   �$��21��6-   $��18��68   $��Stretch=�6D   	 5v      !� 5w       ! appbar_control_rewind_variant# [ 6*   $

 Fill=�6b   5y      5z      �� 5|      -   5        $ StopButt��5|      $��Center=�6+   $
��Left=�6F   $��30��6b   $��40��6n   #��[ 6y   $��2q�6�   .��5}      �� 
���   �$��21��6-   $��18��68   $��Stretch=�6D   	 5~      !� 5        appbar_control_pause# [ 6*   $

 Fill=�6Y   5�      5�      �� 5�      -	   5        $ NoButt��5�      $��Center=�6)   $
��Left=�6D   $��30��6`   $��40��6l   #��[ 6w   $��2q�6�   .��5�      �� 
���   �$��21��6-   $��18��68   $��Stretch=�6D   	 5�      !� 5�        appbar_control_stop# [ 6*   $

 Fill=�6X   5�      5�      �� 5�      -
   5        $ ForwardButt��5�      $
��Left=�6.   $��30��6I   $��40��6U   #��[ 6`   $��2q�6�   .��5�      �� 
���   �$��21��6-   $��18��68   $��Stretch=�6D   	 5�      !� 5�       &	 "appbar_control_fastforward_variant# [	 6*   $

 Fill=�6g   5�      5�      5�      �� 5�      $��3��6   $ 
Horizontal=�6'   $��1��6A   .+�5�      �� -   5        $
 Mute��5�      $��Center=�6'   $��1��6C   $��Right=�6S   $��0,0,8,0q�6o   $��30��6�   $��40��6�   #���  6�   .��5�      �� -   5        $	��lol��5�       
���   �$��21��68   $��18��6C   $��Stretch=�6O   	 5�      !� 5�       
 appbar_music_wifi# [
 6*   $

 Fill=�6V   5�      5�      �� 5�      $��Center=�6   .+�5�      �� -   5        $ 
muteSlider��5�      $	��120��6/   $��Center=�6<   $��Right=�6X   6�   5�      5�      �� 5�      $��2��6   $��1��6&   $	��Top=�66   $��Right=�6N   $
��auto��6j   $��3��6w   $��24��6�   $��0,5,0,0q�6�   .+�5�      �� -   5        $
��time��5�      $��25��6$   $
��auto��60   $��0,0,0,0q�6=   .��6N   	0000/00006Y   5�      5�      5�      5�      