   M S B A M L   `   `   `  ����E  AParserSbis, Version=0.0.0.1, Culture=neutral, PublicKeyToken=null3clr-namespace:ParserSbis.ViewsParserSbis.Views  5           ParserSbis.Views._MenuPage   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      R NMahApps.Metro.IconPacks, Version=1.9.0.0, Culture=neutral, PublicKeyToken=null=	iconPacks-http://metro.mahapps.com/winfx/xaml/iconpacks  5      *localclr-namespace:ParserSbis.Views  5        N� 
Background  �#dedede N� Title$ 	_MenuPage��5       � DataContext 5      �� *Main+   Locator �� Source# [   � 	Resources 5       �� MergedDictionaries �� Source�� 5   
    5      �� 5      $ /Resources/Icons.xaml?�6%   %    5      .��5      � .+�5   
   �� 5      A� 5   
    A� Rows$ 1��6    A� Columns$ 8��6   $��0,0,0,0q�6,   $��80��6=   $	��Top=�6I   $��Right=�6a   $	��590��6}   .+�5       �� 
�������$��75��6Q   $��75��6\   $	��Top=�6h   $��0,0,0,0q�6�   ��6   �� *NavigateHomeCommand+.��5!      �� 	 �� Orientation$	 Vertical=�6   .+�5"      �� $��20��6    $��20��6+   ��5#      !� 5$      
 j� Stretch$

 Fill=�6*    !� Visual 5%      :  4MahApps.Metro.IconPacks.PackIconFontAwesomeExtension  *Home+5'      5(      5)      �� 5*      
�������$��75��6T   $	��Top=�6`   $��6,0,-1,0q�6x   ��6   �� *NavigateSettingsCommand+.��5+      �� $	 Vertical=�6   .+�5,      �� $��20��6    $��20��6+   ��5-      !� 5.      $

 Fill=�6*    5/        *Cog+51      �� 52      $��Center=�6    $��Настройки��6=   �� 53      $��Center=�6    $��парсера��6=   54      55      �� 56      
�������$��75��6j   $��75��6u   $	��Top=�6�   $��5,0,0,0q�6�   $
��Left=�6�   {�6(   �� *CheckTaskStart+��6M   �� *
LoadIdSp+.��57      �� $	 Vertical=�6   .+�58      �� $��20��6    $��20��6+   ��59      !� 5:      $

 Fill=�6*     appbar_arrow_down# [ 5;      5=      �� 5>      $��Center=�6    $��Получить��6=   �� 5?      $��Center=�6    $��Данные��6=   �� 5@      $��Center=�6    $��Фильтра��6=   5A      5B      �� 5C      
�������$��75��6q   $	��Top=�6}   $��6,0,0,0q�6�   ��6   �� *ContiniueParser+{�69   �� *CheckTaskStart+.��5D      �� $	 Vertical=�6   .+�5E      �� $��20��6    $��20��6+   ��5F      !� 5G      $

 Fill=�6*   # [ 5H      5J      �� 5K      $��Center=�6    $��Получить��6=   �� 5L      $��Center=�6    $��Детали��6=   �� 5M      $��Center=�6    $�� ��6=   5N      5O      �� 5P      
�������$��75��6E   $	��Top=�6Q   $��5,0,0,0q�6j   ��6   �� *
StopTask+.��5Q      �� $	 Vertical=�6   .+�5R      �� $��20��6    $��20��6+   ��5S      !� 5T      $

 Fill=�6*     appbar_stop# [ 5U      5W      �� 5X      $��Center=�6    $�� ��6=   �� 5Y      $��Center=�6    $
��Stop��6=   5Z      5[      �� 5\      
�������$��75��6O   $	��Top=�6[   $��4,0,5,0q�6s   ��6   �� *NavigateLogCommand+.��5]      �� $	 Vertical=�6   .+�5^      �� $��20��6    $��20��6+   ��5_      !� 5`      $

 Fill=�6*    5a        *	History+5c      �� 5d      $��Center=�6    $�� ��6=   �� 5e      $��Center=�6    $	��Log��6=   5f      5g      �� 5h      
�������$��75��6I   $��75��6T   $	��Top=�6`   $��0,0,0,0q�6x   ��6   �� *SaveXmlToCsv+.��5i      �� $	 Vertical=�6   .+�5j      �� $��20��6    $��20��6+   ��5k      !� 5l      $

 Fill=�6*     appbar_disk# [ 5m      5o      �� 5p      $��Center=�6    $��Выгрузить��6=   �� 5q      $��Center=�6    $	��CSV��6=   5r      5s      5u      5v      5w      