   M S B A M L   `   `   `  ����U  QMahApps.Metro, Version=1.5.0.23, Culture=neutral, PublicKeyToken=f4fb5a3c4d1e5b4fV;clr-namespace:MahApps.Metro.Controls;assembly=MahApps.MetroMahApps.Metro.Controls  5   	    
ParserSbis&    ParserSbis.Skins.ParcerParamView   HControls;clr-namespace:MahApps.Metro.Controls;assembly=MahApps.Metro  R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   0ignorehttp://www.galasoft.ch/ignore     5   	   n jTelerik.Windows.Controls.GridView, Version=2017.2.503.45, Culture=neutral, PublicKeyToken=5803cfa389c90ce7a ]Telerik.Windows.Data, Version=2017.2.503.45, Culture=neutral, PublicKeyToken=5803cfa389c90ce7k gTelerik.Windows.Controls.Input, Version=2017.2.503.45, Culture=neutral, PublicKeyToken=5803cfa389c90ce7e	 aTelerik.Windows.Controls, Version=2017.2.503.45, Culture=neutral, PublicKeyToken=5803cfa389c90ce7Etelerik1http://schemas.telerik.com/2008/xaml/presentation    	 5   	   $��445.97��5
   G     � DataContext  6	   �� *Main+   Locator �� Source# [   � 	Resources 5       �� 
TargetType  CustomComboTextBoxStyle �� Property �� Value��%  &	       �� 5   
   " ��6   .�5      ��  � ��
 �����6+   �� 5       � ��
 �   �6+   �� 5       � ��$ Calibri)�6+   �� 5       � ��$ 16(�6)   �� 5       � ��$ 0q�60   �� 5       � ��
 ���� 6,   5      5      .��5      �� 
������ $��0,10,0,0q�6'   .@�5   
   ��  �� Orientation$ 
Horizontal=�6   .+�5      �� $��Регион:��6   $��	0,10,0,10q�6'   $	��120��6:   *  $Telerik.Windows.Controls.RadComboBox  5      -   5          Name$ radComboBox��5   "   $	��303��67   $
��Left=�6C   $��
15,10,0,10q�6^   $	��Top=�6r   
���   � �� SelectedIndex$ 2��5   D   	 �� DisplayMemberPath$	 VisibleName��5      
   
IsEditable
 .    TextSearchMode$ Contains=�6@      IsFilteringEnabled .    TextBoxStyle# [ 6t    =� ErrorTemplate 5   �   Z�  �� SelectedItem 5      �� *SelectedRegion+��5      �� *
viewRegion+5      5      �� 5   
   $ 
Horizontal=�6   .+�5       �� $��Город:��6   $
��Left=�6%   $��	0,10,0,10q�6@   $	��Top=�6S   $	��120��6k     5!      $
��Left=�6"   $��
15,10,0,10q�6=   $	��Top=�6Q   $	��303��6i   $
	 Name��5$      
 . $ Contains=�61    . # [ 6e    5"      �� *SelectedCity+ �� Mode$ TwoWay=���5#      �� *
viewCity+5$   e   5%      �� 5&   
   $ 
Horizontal=�6   .+�5'      �� $$��Тип контрагнета:��6   $
��Left=�6/   $	��Top=�6K   $	��120��6c   �� 5(      $ 1��6   $
��Left=�6)   $	��Top=�6D   $��
15,10,0,10q�6\   $	��303��6p    6|   Z�  5)      �� *SelectedTypeKontragent+��5*      �� *TypeKontragent+5+      �� 5,   
   $ 
Horizontal=�6   $��Center=�6.   .+�5-      d� $.��(По видам деятельности��6   $
��Left=�6j   $��	10,10,0,0q�6�   $	��Top=�6�   $	��150��6�    d� 	IsChecked 6;   �� *SelectedActivityCheckBox+6�   d� 5.      $��По ОКВЭД��6   $
��Left=�6Z   $��	10,10,0,0q�6u   $	��Top=�6�   $	��150��6�    6.   �� *SelectedOKVEDCheckBox+6�   5/      �� 51   
   $ 
Horizontal=�6   .+�52      �� $(��"Виды деятельности:��6   $��	0,10,0,10q�61   $
��Left=�6D   $	��Top=�6`   $	��120��6x     53      $
��Left=�6"   $��
15,10,0,10q�6=   $	��Top=�6Q   $	��303��6i   $
	 Name��56      
 . $ Contains=�61    . # [ 6e   {�53   u   �� *SelectedActivityCheckBox+ 54      �� *SelectedActivity+$ TwoWay=���55      �� *viewActivity+56   e   59      �� 5:   
   $ 
Horizontal=�6   .+�5;      �� $��ОКВЕД:��6   $��	0,10,0,10q�6%   $
��Left=�68   $	��Top=�6T   $	��120��6l     5<      $
��Left=�6"   $��
15,10,0,10q�6=   $	��Top=�6Q   $	��303��6i   $	 NameOKVD_KodOKVD��5?      
 . $ Contains=�6L    . # [ 6�   {�5<   u   �� *SelectedOKVEDCheckBox+ 5=      �� *SelectedOKVED+$ TwoWay=���5>      �� *	viewOKVED+��5A      �� 5B      .R�5C      $� 5D      5F      5G      �� 5H   
   $ 
Horizontal=�6   .+�5I      �� $��Статус:��6   $
��Left=�6&   $��	0,10,0,10q�6A   $	��Top=�6T   $	��120��6l   �� 5J      $ 0��6   $
��Left=�6)   $��
15,10,0,10q�6D   $	��Top=�6X   $	��303��6p    5K      �� *SelectedStatus+$ TwoWay=���5L      �� *
viewStatus+5M      �� 5O   
   $ 
Horizontal=�6   .+�5P      �� $��Пагинация(20)��6   $
��Left=�6,   $��	0,10,0,10q�6G   $	��Top=�6Z   $	��120��6r   *   $MahApps.Metro.Controls.NumericUpDown  5Q      $
��Left=�6%      Minimum$ 0Q�6]      Interval$ 1Q�6k   $��
15,10,0,10q�6z   $	��303��6�   $��28��6�   $	��Top=�6�      Value 6@   �� *
Pagination+6�   5R      �� 5S   
   $ 
Horizontal=�6   .+�5T      �� $F��@Интервал между запросами к Api в сек.��6   $
��Left=�6D   $��	0,10,0,10q�6_   $	��Top=�6r   $	��227��6�     5U      $
��Left=�6%   $ 0Q�6[   $ 1Q�6i   $��
15,10,0,10q�6x   $	��303��6�   $��28��6�   $	��Top=�6�    6@   �� *
Interval+6�   5V      5W      5X      