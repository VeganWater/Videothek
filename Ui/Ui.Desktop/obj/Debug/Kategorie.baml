   M S B A M L   `   `   `  ����O  KVideothek.Ui.Desktop, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null;"clr-namespace:Videothek.Ui.DesktopVideothek.Ui.Desktop  5      $    Videothek.Ui.Desktop.Kategorie   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      4local"clr-namespace:Videothek.Ui.Desktop     5        � DataContext  5   7   ��    Locator �� Source# [  .��5	      �  � ColumnDefinitions 5
   
   �� 5      $��90 �6   �� 5       � RowDefinitions 5   
   �� 5      �� 5      �� 5      .+�5   
   �� $	��ID:��6   $��0��6   �� 5   
   $��Bezeichnung:��6   $��1��6'   �� 5   
   $��0��6   $��1��6    �� 
IsReadOnly . ��6A   �� *Main.SelectedCategory.ID+ �� Mode$ TwoWay=� �� UpdateSourceTrigger$ PropertyChanged=��� 5   
   $��1��6   $��1��6   ��6/   �� *#!Main.SelectedCategory.Bezeichnung+$ TwoWay=�$ PropertyChanged=��� 5   
   $��	Abbrechen��6   $��7��6%   $��0��62   $��2��6C   $
��Left=�6W    
 Button#��[ 6r   �� 5   
   -   5         ��Name$ KategorieBtn��5      $��7��6v   $��1��6�   $��Right=�6�   #��[ 6�   ��6'   �� *
Main.Btn+$ PropertyChanged=�$ TwoWay=���5      �� *Main.AddOrEditCategoryStart+5      5      