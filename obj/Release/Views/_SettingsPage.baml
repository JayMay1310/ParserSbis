   M S B A M L   `   `   `  ���� U  QMahApps.Metro, Version=1.5.0.23, Culture=neutral, PublicKeyToken=f4fb5a3c4d1e5b4fV;clr-namespace:MahApps.Metro.Controls;assembly=MahApps.MetroMahApps.Metro.Controls  E AParserSbis, Version=0.0.0.1, Culture=neutral, PublicKeyToken=null;"clr-namespace:ParserSbis.ViewModelParserSbis.ViewModel     ParserSbis.Views._Settings   HControls;clr-namespace:MahApps.Metro.Controls;assembly=MahApps.Metro  n jTelerik.Windows.Controls.GridView, Version=2017.2.503.45, Culture=neutral, PublicKeyToken=5803cfa389c90ce7a ]Telerik.Windows.Data, Version=2017.2.503.45, Culture=neutral, PublicKeyToken=5803cfa389c90ce7k gTelerik.Windows.Controls.Input, Version=2017.2.503.45, Culture=neutral, PublicKeyToken=5803cfa389c90ce7e aTelerik.Windows.Controls, Version=2017.2.503.45, Culture=neutral, PublicKeyToken=5803cfa389c90ce7Etelerik1http://schemas.telerik.com/2008/xaml/presentation     R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R	 NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml    	 @d2http://schemas.microsoft.com/expression/blend/2008    	 Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006    	 0ignorehttp://www.galasoft.ch/ignore    	 4local"clr-namespace:ParserSbis.ViewModel    	 $	��700��  � DataContext  �� *Main+   Locator �� Source# [   � 	Resources  �� 
TargetType  CustomComboTextBoxStyle �� Property �� Value   MultipleSelectionBoxTemplate �� ElementName �� Path �� StringFormat��%/  &	       &	 �     �� " ��.���  � ��
 �������  � ��
 �   ���  � ��$ Calibri)���  � ��$ 16(���  � ��$ 0q���  � ��
 ���� �� .R��� 
���  ��$
��Bold"����� $ radComboBoxActivity��$ SelectedItems.Count�$ Selected Items Count: {0}��.���� 
������ $��	10,10,0,0q�.@��� 	 �� Orientation$	 
Horizontal=�$��Center=�.+��� $#��Выбрать регионы��$	��124��$��20������ *AddRegionCommand+�� $	 
Horizontal=�$	��600��.+��� $$��Тип контрагнета:��$
��Left=�$	��Top=�$	��120���� 
 �� SelectedIndex$
 1��$
��Left=�$	��Top=�$��
15,10,0,10q�$	��421�� =� ErrorTemplate Z�  �� SelectedItem �� *SelectedTypeKontragent+���� *TypeKontragent+�� $	 
Horizontal=�$��Center=�$	��600��.+�d� $.��(По видам деятельности��$��Center=�$��100,10,50,0q�$	��Top=�$	��150�� d� 	IsChecked �� *SelectedActivityCheckBox+�� $	 
Horizontal=�$	��600��.+��� $(��"Виды деятельности:��$��	0,10,0,10q�$
��Left=�$	��Top=�$	��136���� $	 
Horizontal=�$	��494��.+��� $6��0Добавить вид деятельности��$��26��$	��184������ *AddActivivityCommand+�� $	 
Horizontal=�$	��600���� $	 
Horizontal=�$	��600��.+��� $��Статус:��$
��Left=�$��	0,10,0,10q�$	��Top=�$	��120���� $
 0��$
��Left=�$��
15,10,0,10q�$	��Top=�$	��421�� �� *SelectedStatus+ �� Mode$ TwoWay=����� *
viewStatus+�� $	 
Horizontal=�$	��600��.+�)   #MahApps.Metro.Controls.ToggleSwitch  $ ��Соучередители��$��70,0,0,0q�   	IsChecked �� *IsOverrideChecked+  $��Сертификаты��$��	100,0,0,0q� �� *IsCertificateChecked+�� $	 
Horizontal=�$	��600��.+��� $��Count Page:��$
��Left=�$��	0,10,0,10q�$	��Top=�$��90��*   $MahApps.Metro.Controls.NumericUpDown  $
��Left=�   Minimum$ 0Q�   Interval$ 1Q�$��
15,10,0,10q�$	��136��$��28��$	��Top=�   Value �� *
Pagination+�� $��Interval request Api:��$
��Left=�$��	0,10,0,10q�$	��Top=�$	��120��  $
��Left=�$ 0Q�$ 1Q�$��
15,10,0,10q�$	��132��$��28��$	��Top=� �� *
Interval+�� $	 
Horizontal=�$	��600��.+��� $��Выручка от��$
��Left=�$��	0,10,0,10q�$	��Top=�
���   �$	��120��  $
��Left=�$ 0Q�$ 1Q�$��
15,10,0,10q�$	��120��$��30��$	��Top=�{��� *DiapozonRevenueFilter+ �� *
RevenueMin+�� -    ��Name$ label6��$
��до��$
��Left=�$��
10,10,0,10q�$	��Top=�  $
��Left=�$ 0Q�$ 1Q�$��
15,10,0,10q�$	��120��$��30��$	��Top=�{��� *DiapozonRevenueFilter+ �� *
RevenueMax+�� $��Использовать��$
��Left=�$��
15,10,0,10q�$	��Top=�$	��116�� �� *DiapozonRevenueFilter+