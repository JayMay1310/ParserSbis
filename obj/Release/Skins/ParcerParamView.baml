   M S B A M L   `   `   `  ���� U  QMahApps.Metro, Version=1.5.0.23, Culture=neutral, PublicKeyToken=f4fb5a3c4d1e5b4fV;clr-namespace:MahApps.Metro.Controls;assembly=MahApps.MetroMahApps.Metro.Controls   
ParserSbis&    ParserSbis.Skins.ParcerParamView   HControls;clr-namespace:MahApps.Metro.Controls;assembly=MahApps.Metro  R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     0ignorehttp://www.galasoft.ch/ignore     n jTelerik.Windows.Controls.GridView, Version=2017.2.503.45, Culture=neutral, PublicKeyToken=5803cfa389c90ce7a ]Telerik.Windows.Data, Version=2017.2.503.45, Culture=neutral, PublicKeyToken=5803cfa389c90ce7k gTelerik.Windows.Controls.Input, Version=2017.2.503.45, Culture=neutral, PublicKeyToken=5803cfa389c90ce7e	 aTelerik.Windows.Controls, Version=2017.2.503.45, Culture=neutral, PublicKeyToken=5803cfa389c90ce7Etelerik1http://schemas.telerik.com/2008/xaml/presentation    	 $��445.97��  � DataContext  �� *Main+   Locator �� Source# [   � 	Resources  �� 
TargetType  CustomComboTextBoxStyle �� Property �� Value��%�   &	       �� " ��.���  � ��
 �������  � ��
 �   ���  � ��$ Calibri)���  � ��$ 16(���  � ��$ 0q���  � ��
 ���� .���� 
������ $��0,10,0,0q�.@���  �� Orientation$ 
Horizontal=�.+��� $��Регион:��$��	0,10,0,10q�$	��120��*  $Telerik.Windows.Controls.RadComboBox  -     Name$ radComboBox��$	��303��$
��Left=�$��
15,10,0,10q�$	��Top=�
���   � �� SelectedIndex$ 2��	 �� DisplayMemberPath$	 VisibleName��
   
IsEditable
 .    TextSearchMode$ Contains=�   IsFilteringEnabled .    TextBoxStyle# [  =� ErrorTemplate Z�  �� SelectedItem �� *SelectedRegion+���� *
viewRegion+�� $ 
Horizontal=�.+��� $��Город:��$
��Left=�$��	0,10,0,10q�$	��Top=�$	��120��  $
��Left=�$��
15,10,0,10q�$	��Top=�$	��303��$
	 Name��
 . $ Contains=� . # [  �� *SelectedCity+ �� Mode$ TwoWay=����� *
viewCity+�� $ 
Horizontal=�.+��� $$��Тип контрагнета:��$
��Left=�$	��Top=�$	��120���� $ 1��$
��Left=�$	��Top=�$��
15,10,0,10q�$	��303�� Z�  �� *SelectedTypeKontragent+���� *TypeKontragent+�� $ 
Horizontal=�$��Center=�.+�d� $.��(По видам деятельности��$
��Left=�$��	10,10,0,0q�$	��Top=�$	��150�� d� 	IsChecked �� *SelectedActivityCheckBox+d� $��По ОКВЭД��$
��Left=�$��	10,10,0,0q�$	��Top=�$	��150�� �� *SelectedOKVEDCheckBox+�� $ 
Horizontal=�.+��� $(��"Виды деятельности:��$��	0,10,0,10q�$
��Left=�$	��Top=�$	��120��  $
��Left=�$��
15,10,0,10q�$	��Top=�$	��303��$
	 Name��
 . $ Contains=� . # [ {��� *SelectedActivityCheckBox+ �� *SelectedActivity+$ TwoWay=����� *viewActivity+�� $ 
Horizontal=�.+��� $��ОКВЕД:��$��	0,10,0,10q�$
��Left=�$	��Top=�$	��120��  $
��Left=�$��
15,10,0,10q�$	��Top=�$	��303��$	 NameOKVD_KodOKVD��
 . $ Contains=� . # [ {��� *SelectedOKVEDCheckBox+ �� *SelectedOKVED+$ TwoWay=����� *	viewOKVED+���� .R�$� �� $ 
Horizontal=�.+��� $��Статус:��$
��Left=�$��	0,10,0,10q�$	��Top=�$	��120���� $ 0��$
��Left=�$��
15,10,0,10q�$	��Top=�$	��303�� �� *SelectedStatus+$ TwoWay=����� *
viewStatus+�� $ 
Horizontal=�.+��� $��Пагинация(20)��$
��Left=�$��	0,10,0,10q�$	��Top=�$	��120��*   $MahApps.Metro.Controls.NumericUpDown  $
��Left=�   Minimum$ 0Q�   Interval$ 1Q�$��
15,10,0,10q�$	��303��$��28��$	��Top=�   Value �� *
Pagination+�� $ 
Horizontal=�.+��� $F��@Интервал между запросами к Api в сек.��$
��Left=�$��	0,10,0,10q�$	��Top=�$	��227��  $
��Left=�$ 0Q�$ 1Q�$��
15,10,0,10q�$	��303��$��28��$	��Top=� �� *
Interval+