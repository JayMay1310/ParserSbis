   M S B A M L   `   `   `  ���� E  AParserSbis, Version=0.0.0.1, Culture=neutral, PublicKeyToken=null3clr-namespace:ParserSbis.ViewsParserSbis.Views       ParserSbis.Views._MenuPage   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     R NMahApps.Metro.IconPacks, Version=1.9.0.0, Culture=neutral, PublicKeyToken=null=	iconPacks-http://metro.mahapps.com/winfx/xaml/iconpacks  *localclr-namespace:ParserSbis.Views    N� 
Background  �#dedede N� Title$ 	_MenuPage�� � DataContext �� *Main+   Locator �� Source# [   � 	Resources  �� MergedDictionaries �� Source��  �� $ /Resources/Icons.xaml?�%    .��� .+��� A�  A� Rows$ 1�� A� Columns$ 8��$��0,0,0,0q�$��80��$	��Top=�$��Right=�$	��590��.+��� 
�������$��75��$��75��$	��Top=�$��0,0,0,0q����� *NavigateHomeCommand+.���� 	 �� Orientation$	 Vertical=�.+��� $��20��$��20����!� 
 j� Stretch$

 Fill=� !� Visual :  4MahApps.Metro.IconPacks.PackIconFontAwesomeExtension  *Home+�� 
�������$��75��$	��Top=�$��6,0,-1,0q����� *NavigateSettingsCommand+.���� $	 Vertical=�.+��� $��20��$��20����!� $

 Fill=�   *Cog+�� $��Center=�$��Настройки���� $��Center=�$��парсера���� 
�������$��75��$��75��$	��Top=�$��5,0,0,0q�$
��Left=�{��� *CheckTaskStart+���� *
LoadIdSp+.���� $	 Vertical=�.+��� $��20��$��20����!� $

 Fill=�  appbar_arrow_down# [ �� $��Center=�$��Получить���� $��Center=�$��Данные���� $��Center=�$��Фильтра���� 
�������$��75��$	��Top=�$��6,0,0,0q����� *ContiniueParser+{��� *CheckTaskStart+.���� $	 Vertical=�.+��� $��20��$��20����!� $

 Fill=�# [ �� $��Center=�$��Получить���� $��Center=�$��Детали���� $��Center=�$�� ���� 
�������$��75��$	��Top=�$��5,0,0,0q����� *
StopTask+.���� $	 Vertical=�.+��� $��20��$��20����!� $

 Fill=�  appbar_stop# [ �� $��Center=�$�� ���� $��Center=�$
��Stop���� 
�������$��75��$	��Top=�$��4,0,5,0q����� *NavigateLogCommand+.���� $	 Vertical=�.+��� $��20��$��20����!� $

 Fill=�   *	History+�� $��Center=�$�� ���� $��Center=�$	��Log���� 
�������$��75��$��75��$	��Top=�$��0,0,0,0q����� *SaveXmlToCsv+.���� $	 Vertical=�.+��� $��20��$��20����!� $

 Fill=�  appbar_disk# [ �� $��Center=�$��Выгрузить���� $��Center=�$	��CSV��