   M S B A M L   `   `   `  ����U  QMahApps.Metro, Version=1.5.0.23, Culture=neutral, PublicKeyToken=f4fb5a3c4d1e5b4fV;clr-namespace:MahApps.Metro.Controls;assembly=MahApps.MetroMahApps.Metro.Controls  5   	   E AParserSbis, Version=0.0.0.1, Culture=neutral, PublicKeyToken=null;"clr-namespace:ParserSbis.ViewModelParserSbis.ViewModel 5	   	       ParserSbis.Views._Settings   5      HControls;clr-namespace:MahApps.Metro.Controls;assembly=MahApps.Metro  5   	   n jTelerik.Windows.Controls.GridView, Version=2017.2.503.45, Culture=neutral, PublicKeyToken=5803cfa389c90ce7a ]Telerik.Windows.Data, Version=2017.2.503.45, Culture=neutral, PublicKeyToken=5803cfa389c90ce7k gTelerik.Windows.Controls.Input, Version=2017.2.503.45, Culture=neutral, PublicKeyToken=5803cfa389c90ce7e aTelerik.Windows.Controls, Version=2017.2.503.45, Culture=neutral, PublicKeyToken=5803cfa389c90ce7Etelerik1http://schemas.telerik.com/2008/xaml/presentation     5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R	 NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml    	 5   	   @d2http://schemas.microsoft.com/expression/blend/2008    	 5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006    	 5   	   0ignorehttp://www.galasoft.ch/ignore    	 5   	   4local"clr-namespace:ParserSbis.ViewModel    	 5	   	   $	��700��5   G     � DataContext  6	   �� *Main+   Locator �� Source# [   � 	Resources 5       �� 
TargetType  CustomComboTextBoxStyle �� Property �� Value   MultipleSelectionBoxTemplate �� ElementName �� Path �� StringFormat��%�  &	       &	     �� 5   
   " ��6   .�5      ��  � ��
 �����6+   �� 5       � ��
 �   �6+   �� 5       � ��$ Calibri)�6+   �� 5       � ��$ 16(�6)   �� 5       � ��$ 0q�60   �� 5       � ��
 ���� 6,   5      �� 5   
   .R�5      �� 
���  ��$
��Bold"�6�   ��6   �� $ radComboBoxActivity��$ SelectedItems.Count�$ Selected Items Count: {0}��6�   5      5      .��5      �� 
������ $��	10,10,0,0q�6'   .@�5   
   �� 	 �� Orientation$	 
Horizontal=�6   $��Center=�6.   .+�5      �� $#��Выбрать регионы��6   $	��124��6U   $��20��6a   ��60   �� *AddRegionCommand+6a   5      �� 5    
   $	 
Horizontal=�6   $	��600��6.   .+�5!      �� $$��Тип контрагнета:��6   $
��Left=�6/   $	��Top=�6K   $	��120��6c   �� 5"      
 �� SelectedIndex$
 1��6   $
��Left=�6)   $	��Top=�6D   $��
15,10,0,10q�6\   $	��421��6p    =� ErrorTemplate 6|   Z�  �� SelectedItem 5#      �� *SelectedTypeKontragent+��5$      �� *TypeKontragent+5%      �� 5&   
   $	 
Horizontal=�6   $��Center=�6.   $	��600��6K   .+�5'      d� $.��(По видам деятельности��6   $��Center=�6j   $��100,10,50,0q�6�   $	��Top=�6�   $	��150��6�    d� 	IsChecked 6;   �� *SelectedActivityCheckBox+6�   5(      �� 5*   
   $	 
Horizontal=�6   $	��600��6.   .+�5+      �� $(��"Виды деятельности:��6   $��	0,10,0,10q�61   $
��Left=�6D   $	��Top=�6`   $	��136��6x   �� 5-      $	 
Horizontal=�6   $	��494��62   .+�5.      �� $6��0Добавить вид деятельности��6   $��26��6f   $	��184��6r   ��6=   �� *AddActivivityCommand+6r   5/      51      �� 52   
   $	 
Horizontal=�6   $	��600��6.   �� 53   
   $	 
Horizontal=�6   $	��600��6.   .+�54      �� $��Статус:��6   $
��Left=�6&   $��	0,10,0,10q�6A   $	��Top=�6T   $	��120��6l   �� 55      $
 0��6   $
��Left=�6)   $��
15,10,0,10q�6D   $	��Top=�6X   $	��421��6p    56      �� *SelectedStatus+ �� Mode$ TwoWay=���57      �� *
viewStatus+58      �� 59   
   $	 
Horizontal=�6   $	��600��6.   .+�5:      )   #MahApps.Metro.Controls.ToggleSwitch  $ ��Соучередители��6$   $��70,0,0,0q�6;      	IsChecked 6M   �� *IsOverrideChecked+  5;      $��Сертификаты��6$   $��	100,0,0,0q�69    6L   �� *IsCertificateChecked+5<      �� 5=   
   $	 
Horizontal=�6   $	��600��6.   .+�5>      �� $��Count Page:��6   $
��Left=�6*   $��	0,10,0,10q�6E   $	��Top=�6X   $��90��6p   *   $MahApps.Metro.Controls.NumericUpDown  5?      $
��Left=�6%      Minimum$ 0Q�6]      Interval$ 1Q�6k   $��
15,10,0,10q�6z   $	��136��6�   $��28��6�   $	��Top=�6�      Value 6@   �� *
Pagination+6�   �� 5@      $��Interval request Api:��6   $
��Left=�64   $��	0,10,0,10q�6O   $	��Top=�6b   $	��120��6z     5A      $
��Left=�6%   $ 0Q�6[   $ 1Q�6i   $��
15,10,0,10q�6x   $	��132��6�   $��28��6�   $	��Top=�6�    6@   �� *
Interval+6�   5B      �� 5C   
   $	 
Horizontal=�6   $	��600��6.   .+�5D      �� $��Выручка от��6   $
��Left=�6)   $��	0,10,0,10q�6D   $	��Top=�6W   
���   �$	��120��6�     5E      $
��Left=�6%   $ 0Q�6�   $ 1Q�6�   $��
15,10,0,10q�6�   $	��120��6�   $��30��6�   $	��Top=�6�   {�6@   �� *DiapozonRevenueFilter+ 6l   �� *
RevenueMin+6�   �� 5F      -   5         ��Name$ label6��5F      $
��до��6$   $
��Left=�61   $��
10,10,0,10q�6L   $	��Top=�6`     5G      $
��Left=�6%   $ 0Q�6�   $ 1Q�6�   $��
15,10,0,10q�6�   $	��120��6�   $��30��6�   $	��Top=�6�   {�6@   �� *DiapozonRevenueFilter+ 6l   �� *
RevenueMax+6�   �� 5H      $��Использовать��6   $
��Left=�6Z   $��
15,10,0,10q�6u   $	��Top=�6�   $	��116��6�    6.   �� *DiapozonRevenueFilter+6�   5I      5J      5K      